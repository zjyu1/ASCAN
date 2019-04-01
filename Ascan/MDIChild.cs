using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.PowerPacks;


namespace Ascan
{
    public partial class MDIChild : Form
    {
        private const int gateTotNum = 4;//gateTotalNum
        private GatePara[] gatePara;
        private Point mouseDownPosition;
        //current baked receiver mode radioButton, if change tof mode not success, can use reback  
        public RadioButton preRadReceiver;
        //current baked transmission mode raddioButton, if change transmission not success, can use reback
        private RadioButton preRadTransmission;
        private AscanVideo ascan;
        /**0,1,3,...,SessionInfo.sessionNum - 1 are the real boards, and SessionInfo.sessionNum,...,sessionInfo.count - 1 are the virtual boards.*/
        private List<SessionInfo> sessionsInfo;

        //private List<SessionInfo> sessionInfoSave = new List<SessionInfo>();

        //the Ascan is or not freeze
        private bool isFreeze = false;

        private RingBufferQueue<AscanQueueElement> ascanQueue;
        private AscanQueueElement element;
        private AscanQueueElement tmpElement;
        private float[] bigXValue = new float[ConstParameter.MaxAscanWaveLen];
        private float[] bigYValue = new float[ConstParameter.MaxAscanWaveLen];
        private float[] smallXValue = new float[ConstParameter.MaxAscanWaveLen / 2];
        private float[] smallYValue = new float[ConstParameter.MaxAscanWaveLen / 2];

        private delegate void updateDelegate();
        private updateDelegate updateCallBack;

        MainForm mainform;

        public MDIChild(List<SessionInfo> sessions,MainForm mainform)
        {
            InitializeComponent();

            sessionsInfo = sessions; 

            gatePara = new GatePara[gateTotNum]
            {
                new GatePara(), new GatePara(),new GatePara(),new GatePara()
            };
            mouseDownPosition = new Point();

            ascanQueue = new RingBufferQueue<AscanQueueElement>();
            element = new AscanQueueElement();
            tmpElement = new AscanQueueElement();

            this.mainform = mainform;
        }

        private void MDIChild_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            MultiLanguage.getNames(this);

            init();
        }

        public void init()
        {
            int error_code = 0;
            //initControlsLocation();

            error_code = initTeeChartAxe();
            if (error_code != 0)
                return;

            error_code = initGatePara();
            if (error_code != 0)
                return;

            error_code = initRadioButtonReceiver();
            if (error_code != 0)
                return;

            error_code = initDelayAndRange();
            if (error_code != 0)
                return;

            error_code = initGain();
            if (error_code != 0)
                return;

            error_code = initEnvelop();
            if (error_code != 0)
                return;

            error_code = initEnvelopSpeed();
            if (error_code != 0)
                return;

            comboBoxMagnify.SelectedIndex = 0;
        }


        public int initTeeChartAxe()
        {
            int error_code;
            AscanWaveDectionMode mode = AscanWaveDectionMode.Rf;

            error_code = GetAsacnVideoDAQ.DetectionWaveMode(SelectAscan.sessionIndex, SelectAscan.port, ref mode);
            if (error_code != 0)
                return error_code;

            switch (mode)
            {
                case AscanWaveDectionMode.Rf:
                    tChart.Axes.Left.SetMinMax(-1, 1);
                    break;

                case AscanWaveDectionMode.Full:

                case AscanWaveDectionMode.SemiNegtive:

                case AscanWaveDectionMode.SemiPositve:
                    tChart.Axes.Left.SetMinMax(0, 1);
                    break;

                default:
                    error_code = -1;
                    MessageShow.show("Initial teeChart axe failed!", "初始化画图坐标轴失败！");
                    break;
            }

            return error_code;
        }

        private int initGatePara()
        {
            int error_code = 0;
            double delay = 0;
            double width = 0;
            double threshold = 0;
            GateType gateNum;

            for (int i = 0; i < gateTotNum; i++)
            {
                gateNum = (GateType)i;

                error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref delay);
                if (error_code != 0)
                    return error_code;

                error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref width);
                if (error_code != 0)
                    return error_code;

                error_code = GetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref threshold);
                if (error_code != 0)
                    return error_code;

                tChart.Series[i].Clear();
                tChart.Series[i].Add(delay, threshold);
                tChart.Series[i].Add(delay + width, threshold);
            }

            return error_code;
        }

        private int initEnvelop()
        {
            int error_code = 0;
            AscanEnvelopActive active = AscanEnvelopActive.OFF;
            error_code = GetAsacnVideoDAQ.EnvlopActive(SelectAscan.sessionIndex, SelectAscan.port, ref active);
            if (error_code != 0)
                return -1;

            switch (active)
            {
                case AscanEnvelopActive.OFF:
                    mainform.checkBoxEnvelop.Checked = false;
                    break;

                case AscanEnvelopActive.ON:
                    mainform.checkBoxEnvelop.Checked = true;
                    break;

                default:
                    MessageShow.show("Warning:Initial ascan envelop active failed!",
                        "警告：初始化包络使能状态失败!");
                    return -1;
            }

            return error_code;        
        }

        private int initEnvelopSpeed()
        {
            int error_code = 0;
            uint speed = 0;
            error_code = GetAsacnVideoDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, SelectAscan.port, ref speed);
            if (error_code != 0)
                return -1;
            mainform.trackBarEnelopSpeed.Value = (int)(speed / 32767);
            return error_code;
        }

        /**Get the pixel values of gateline starting point and end point.*/
        private void getGateLinePointPixel()
        {
            double x1;//x1 is the X coordinate value of gateline's starting point
            double x2;//x2 is the X coordinate value of gateline's end point
            double y;//y is the Y coordinate value of gateline
            double tmp_x;
            for (int i = 0; i < gateTotNum; i++)
            {
                x1 = tChart.Series[i].XValues.First;
                y = tChart.Series[i].YValues.First;
                x2 = tChart.Series[i].XValues.Last;
                //the starting point of the gateline
                if (x1 > x2)
                {
                    tmp_x = x1;
                    x1 = x2;
                    x2 = tmp_x;
                }
                gatePara[i].pointPixel[0].X = tChart.Series[i].CalcXPosValue(x1);
                gatePara[i].pointPixel[0].Y = tChart.Series[i].CalcYPosValue(y);
                gatePara[i].pointPixel[1].X = tChart.Series[i].CalcXPosValue(x2);
            }
        }

        /** Judge whether the mouse can move the gate line.*/
        private void isMouseMoveGate(Point mouseDownPosition)
        {
            int x1Pixel, yPixel, x2Pixel;
            for (int i = 0; i < gateTotNum; i++)
            {
                x1Pixel = gatePara[i].pointPixel[0].X;
                yPixel = gatePara[i].pointPixel[0].Y;
                x2Pixel = gatePara[i].pointPixel[1].X;
                if ((x1Pixel < mouseDownPosition.X) && (mouseDownPosition.X < x2Pixel) &&
                    (yPixel - 2) < mouseDownPosition.Y && mouseDownPosition.Y < (yPixel + 2))
                {
                    gatePara[i].isMoveTrigger = true;
                    this.mouseDownPosition.X = mouseDownPosition.X;
                    this.mouseDownPosition.Y = mouseDownPosition.Y;
                    break;
                }
            }
        }

        private void tChart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Middle")
            {
                Point mouseDownPosition = e.Location;
                getGateLinePointPixel();
                isMouseMoveGate(mouseDownPosition);
            }
        }

        private void tChart_MouseUp(object sender, MouseEventArgs e)
        {
            int error_code;
            string mouseButton = e.Button.ToString();

            if (mouseButton == "Left")//drag gateline
            {
                bool isGateDragTrigger;
                double delay, width, threshold;
                double x1, y, x2;
                double tmp_x;
                GateType gateNum;

                for (int i = 0; i < gateTotNum; i++)
                {
                    gateNum = (GateType)i;
                    isGateDragTrigger = gatePara[i].isDragTrigger;
                    if (isGateDragTrigger)
                    {
                        x1 = tChart.Series[i].XValues.First;
                        y = tChart.Series[i].YValues.First;
                        x2 = tChart.Series[i].XValues.Last;
                        if (x1 > x2)//the startint point of gateline
                        {
                            tmp_x = x1;
                            x1 = x2;
                            x2 = tmp_x;
                        }
                        delay = x1;
                        width = x2 - x1;
                        threshold = y;
                        gatePara[i].isDragTrigger = false;

                        error_code = setGatePosition(gateNum, delay, width, threshold);
                        if (error_code != 0)
                            return;

                        FormList.FormGatePosition.UpdateGatePositionNudFromLine(i, delay, width, threshold);
                        //DelegateGatePosition delegateGatePosition = new DelegateGatePosition(FormList.FormGatePosition, i, delay, width, threshold);
                        //delegateGatePosition.GatePositionTriggerEvent += new DelegateGatePosition.GatePositionTrigger(delegateGatePosition.updatenumUpDownOfGatePosition);
                        //delegateGatePosition.Execute();
                        break;
                    }
                }
            }

            if (mouseButton == "Middle")//Move gate line
            {
                Point mouseUpPosition = e.Location;
                drawNewGate(mouseUpPosition);
            }
        }

        private void drawNewGate(Point mouseUpPosition)
        {
            double delay;
            double width;
            double threshold;
            int error_code;
            GateType gateNum;
            bool isGateMoveTrigger = false;
            int mouseMoveLenth_X, mouseMoveLenth_Y;
            Point newStart = new Point(0, 0);//the pixel value of new gateline's start point 
            Point newEnd = new Point(0, 0);//the pixel value of new gateline's end point 
            double newStart_X, newStart_Y, newEnd_X;//the coordinate values of new gateline
            for (int i = 0; i < gateTotNum; i++)
            {
                gateNum = (GateType)i;
                isGateMoveTrigger = gatePara[i].isMoveTrigger;
                if (isGateMoveTrigger)
                {
                    mouseMoveLenth_X = mouseUpPosition.X - mouseDownPosition.X;//the length(pixel value) mouse move along the x axis direction
                    mouseMoveLenth_Y = mouseUpPosition.Y - mouseDownPosition.Y;//the length(pixel value) mouse move along the y axis direction

                    newStart.X = mouseMoveLenth_X + gatePara[i].pointPixel[0].X;//the pixel value of new gateline's start point in the X direction 
                    newStart.Y = mouseMoveLenth_Y + gatePara[i].pointPixel[0].Y;//the pixel value of new gateline's start point in the Y direction
                    newEnd.X = mouseMoveLenth_X + gatePara[i].pointPixel[1].X;//the pixel value of new gateline's end point in the Y direction

                    newStart_X = tChart.Series[i].XScreenToValue(newStart.X);
                    newStart_Y = tChart.Series[i].YScreenToValue(newStart.Y);
                    newEnd_X = tChart.Series[i].XScreenToValue(newEnd.X);

                    delay = newStart_X;
                    width = newEnd_X - newStart_X;
                    threshold = newStart_Y;

                    tChart.Series[i].Clear();
                    tChart.Series[i].Add(newStart_X, newStart_Y);
                    tChart.Series[i].Add(newEnd_X, newStart_Y);
                    gatePara[i].isMoveTrigger = false;

                    error_code = setGatePosition(gateNum, delay, width, threshold);
                    if (error_code != 0)
                        return;

                    FormList.FormGatePosition.UpdateGatePositionNudFromLine(i, delay, width, threshold);
                    //DelegateGatePosition delegateGatePosition = new DelegateGatePosition(FormList.FormGatePosition, i, delay, width, threshold);
                    //delegateGatePosition.GatePositionTriggerEvent += new DelegateGatePosition.GatePositionTrigger(delegateGatePosition.updatenumUpDownOfGatePosition);
                    //delegateGatePosition.Execute();
                    break;
                }
            }
        }

        private void GateIDragPoint_Drag(Steema.TeeChart.Tools.DragPoint sender, int index)
        {
            int gateI = (int)GateType.I;
            gatePara[gateI].isDragTrigger = true;//the drag of GateI trigger
        }

        private void GateADragPoint_Drag(Steema.TeeChart.Tools.DragPoint sender, int index)
        {
            int gateA = (int)GateType.A;
            gatePara[gateA].isDragTrigger = true;//the drag of GateA trigger
        }

        private void GateBDragPoint_Drag(Steema.TeeChart.Tools.DragPoint sender, int index)
        {
            int gateB = (int)GateType.B;
            gatePara[gateB].isDragTrigger = true;//the drag of GateB trigger
        }

        private void GateCDragPoint_Drag(Steema.TeeChart.Tools.DragPoint sender, int index)
        {
            int gateC = (int)GateType.C;
            gatePara[gateC].isDragTrigger = true;//the drag of GateC trigger
        }

        private int setGatePosition(GateType type, double delay, double width, double threshold)
        {
            int error_code;

            error_code = SetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, type, delay);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, type, width);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, type, threshold);
            if (error_code != 0)
                return error_code;

            return error_code;
        }

        /**Initial wave mode bind to RadioButton*/
        private int initRadioButtonReceiver()
        {
            int error_code;

            AscanWaveDectionMode waveMode = AscanWaveDectionMode.Rf;
            error_code = GetAsacnVideoDAQ.DetectionWaveMode(SelectAscan.sessionIndex, SelectAscan.port, ref waveMode);
            if (error_code != 0)
                return error_code;

            switch (waveMode)
            {
                case AscanWaveDectionMode.SemiPositve:
                    cmbReceiver.SelectedIndex = 2;
                    //mainform.RadioButtonPositive.Checked = true;
                    //preRadReceiver = mainform.RadioButtonPositive;
                    break;

                case AscanWaveDectionMode.SemiNegtive:
                    cmbReceiver.SelectedIndex = 3;
                    //mainform.RadioButtonNegative.Checked = true;
                    //preRadReceiver = mainform.RadioButtonNegative;
                    break;

                case AscanWaveDectionMode.Full:
                    cmbReceiver.SelectedIndex = 1;
                    //mainform.RadioButtonFullWave.Checked = true;
                    //preRadReceiver = mainform.RadioButtonFullWave;
                    break;

                case AscanWaveDectionMode.Rf:
                    cmbReceiver.SelectedIndex = 0;
                    //mainform.RadioButtonRF.Checked = true;
                    //preRadReceiver = mainform.RadioButtonRF;
                    break;

                default:
                    error_code = -1;
                    MessageShow.show("Warn:Initial RadioButton of Receiver failed!", "警告:初始化检波模式的控件失败!");
                    break;
            }
            return error_code;
        }

        private void cmbReceiver_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSetPre = false;
            int waveMode = cmbReceiver.SelectedIndex;
            switch (waveMode)
            {
                case 0: 
                    {
                        if (SetBatchDAQ.isOn)
                            isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, AscanWaveDectionMode.Rf);
                        else
                            isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, AscanWaveDectionMode.Rf);

                        //if (isSetPre == true)
                        //    FormList.MDIChild.preRadReceiver.Checked = true;
                        //else
                        //    FormList.MDIChild.preRadReceiver = RadioButtonPositive;

                        initTeeChartAxe();
                    } break;

                case 1: 
                    {
                        if (SetBatchDAQ.isOn)
                            isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, AscanWaveDectionMode.Full);
                        else
                            isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, AscanWaveDectionMode.Full);

                        //if (isSetPre == true)
                        //    FormList.MDIChild.preRadReceiver.Checked = true;
                        //else
                        //    FormList.MDIChild.preRadReceiver = RadioButtonPositive;

                        initTeeChartAxe();
                    } break;

                case 2: 
                    {
                        if (SetBatchDAQ.isOn)
                            isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, AscanWaveDectionMode.SemiPositve);
                        else
                            isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, AscanWaveDectionMode.SemiPositve);

                        //if (isSetPre == true)
                        //    FormList.MDIChild.preRadReceiver.Checked = true;
                        //else
                        //    FormList.MDIChild.preRadReceiver = RadioButtonPositive;

                        initTeeChartAxe();
                    } break;

                case 3: 
                    {
                        if (SetBatchDAQ.isOn)
                            isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, AscanWaveDectionMode.SemiNegtive);
                        else
                            isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, AscanWaveDectionMode.SemiNegtive);

                        //if (isSetPre == true)
                        //    FormList.MDIChild.preRadReceiver.Checked = true;
                        //else
                        //    FormList.MDIChild.preRadReceiver = RadioButtonPositive;

                        initTeeChartAxe();
                    } break;

                default: break;


            }


        }
       

        private bool compareParaBeforeUpdate(AscanVideo ascan)
        {
            int error_code = 0;
          
            AscanVideoLength length = 0;
            error_code = GetAsacnVideoDAQ.Length(SelectAscan.sessionIndex, SelectAscan.port, ref length);
            if(error_code != 0||(uint)length != ascan.len)
               return false;

            AscanIFActive ifActive = 0;
            error_code = GetAsacnVideoDAQ.IFActive(SelectAscan.sessionIndex, SelectAscan.port, ref ifActive);
            if(error_code!=0||(uint)ifActive!=ascan.ifStart)
                return false;

            //tofUnit
            //ampUnit
            //echoMax
            AscanWaveDectionMode mode = 0;
            error_code = GetAsacnVideoDAQ.DetectionWaveMode(SelectAscan.sessionIndex, SelectAscan.port, ref mode);
            if(error_code!=0||(uint)mode!=ascan.waveDetectMode)
                return false;

            AscanEnvelopActive envlopActive = 0;
            error_code = GetAsacnVideoDAQ.EnvlopActive(SelectAscan.sessionIndex, SelectAscan.port, ref envlopActive);
            if(error_code!=0||(uint)envlopActive != ascan.envelopStart)
                return false;
            
            double delay = 0;
            error_code = GetAsacnVideoDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, ref delay);
            if(error_code!=0||delay != ascan.delay)
                return false;

            double range = 0;
            error_code = GetAsacnVideoDAQ.Range(SelectAscan.sessionIndex, SelectAscan.port, ref range);
            if(error_code !=0 ||range!=ascan.width)
                return false;

            double gain = 0;
            error_code = GetRecieverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, ref gain);
            if(error_code !=0||gain!=ascan.gain)
                return false;
            
            //bea

            uint speed = 0;
            error_code = GetAsacnVideoDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, SelectAscan.port, ref speed);
            if(error_code!=0||speed!=ascan.decayFactor)
                return false;

            return true;
        }

        /**Update ascan*/
        public void updateAscan(object element)
        {
            AscanQueueElement ascanQueueElement = null;
            uint waveDetectMode;
            uint envelopStart;
            uint ascanIfStart;
            double width = 0;
            double threshold = 0;

            if (element is AscanQueueElement)
                ascanQueueElement = element as AscanQueueElement;
            else 
                return;

            ascan = ascanQueueElement.ascanPacket.ascan;

            //if (!compareParaBeforeUpdate(ascan))
                //return;

            lineClear();

            waveDetectMode = ascan.waveDetectMode;
            envelopStart = ascan.envelopStart;
            ascanIfStart = ascan.ifStart;

            displayWaveOnTChart(ascan);

            //displayMonitorLED(ascan);

            if (envelopStart == (uint)AscanEnvelopActive.ON)
            {
                switch ((AscanWaveDectionMode)waveDetectMode)
                {
                    case AscanWaveDectionMode.Rf:
                        displayMaxUp(ascan);
                        displayMaxDown(ascan);
                        break;

                    case AscanWaveDectionMode.Full:
                        displayMaxDown(ascan);
                        break;

                    case AscanWaveDectionMode.SemiNegtive:
                        displayMaxDown(ascan);
                        break;

                    case AscanWaveDectionMode.SemiPositve:
                        displayMaxDown(ascan);
                        break;
                }
            }

            if (ascanIfStart == (uint)AscanIFActive.ON)
            {
                GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref width);
                GetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref threshold);
                GateI.Clear();
                GateI.Add(0, threshold);
                GateI.Add(width, threshold);
            }

            //FormList.FormRecordFigure.drawLineRecord(ascan.ascanGateTof,ascan.ascanGateAmp);
        }

        /**Update ascan every 100ms*/
        public void updateAscanbytimer()
        {
            updateAscans();
            ascanQueue = new RingBufferQueue<AscanQueueElement>();
        }

        /**Update ascan*/
        public void updateAscans()
        {
            bool result;
            uint waveDetectMode;
            uint envelopStart;
            uint ascanIfStart;
            uint stampinc;
            double width = 0;
            double threshold = 0;
            //stampinc = element.ascanPacket.tag.stampInc[0];
           // LogFile.write("A扫开始显示");
                  if(!isFreeze)
            {
                //Dequeue all items in the queue
                result = this.dequeue();

                //queue is empty
                if (!result)
                    return;

                ascan = element.ascanPacket.ascan;
                

                //if (!compareParaBeforeUpdate(ascan))
                //return;

                lineClear();

                waveDetectMode = ascan.waveDetectMode;
                envelopStart = ascan.envelopStart;
                ascanIfStart = ascan.ifStart;

                displayWaveOnTChart(ascan); //Ascan refresh data
            
             

                //displayMonitorLED(ascan);

                //LogFile.write("A扫显示结束");

                if (envelopStart == (uint)AscanEnvelopActive.ON)
                {
                    switch ((AscanWaveDectionMode)waveDetectMode)
                    {
                        case AscanWaveDectionMode.Rf:
                            displayMaxUp(ascan);
                            displayMaxDown(ascan);
                            break;

                        case AscanWaveDectionMode.Full:
                            displayMaxDown(ascan);
                            break;

                        case AscanWaveDectionMode.SemiNegtive:
                            displayMaxDown(ascan);
                            break;

                        case AscanWaveDectionMode.SemiPositve:
                            displayMaxDown(ascan);
                            break;
                    }
                }
           


            if (ascanIfStart == (uint)AscanIFActive.ON)
                {
                    GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref width);
                    GetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref threshold);
                    GateI.Clear();
                    GateI.Add(0, threshold);
                    GateI.Add(width, threshold);
                }
            }


                  //if (mainform.groove.longVeloc == 0 || mainform.groove.longVeloc == null)
                  //{
                  //    //FormList.FormRecordFigure_AScan.GetVelocity(5.89);
                  //}
                  //else
                  //{
                  //    FormList.FormRecordFigure.GetVelocity(mainform.groove.longVeloc);
                  //    double v = FormList.FormRecordFigure.velocity;
                  //    int d = (int)FormList.FormRecordFigure.gateDataType;
                  //    int g = (int)FormList.FormRecordFigure.selectedGate;
                  //    string G, D;
                  //    if (d == 0)
                  //    {
                  //        D = "Tpf";
                  //    }
                  //    else
                  //    {
                  //        D = "Amp";
                  //    }
                  //    if (g == 0)
                  //    {
                  //        G = "Gate I";
                  //    }
                  //    else if (g == 1)
                  //    { G = "Gate A"; }
                  //    else if (g == 2)
                  //    { G = "Gate B"; }
                  //    else if (g == 3)
                  //    { G = "Gate C"; }
                  //    else if (g == 21)
                  //    { G = "Gate BA"; }
                  //    else if (g == 10)
                  //    { G = "Gate AI"; }
                  //    else if (g == 20)
                  //    { G = "Gate BI"; }
                  //    else 
                  //    { G = "Gate CI"; }
                      
                  //    FormList.FormRecordFigure.tChartAscan.Header.Text= G+" — "+ D +" — velocity:" + v + "mm/us";
                  //}
            
            FormList.FormRecordFigure.drawLineRecord(ascan.ascanGateTof, ascan.ascanGateAmp);
            FormList.FormRecordFigure.AddData(ascan);
            FormList.FormRecordFigure.UpdateBscanPic();

            FormList.FormGateInfo.updateGateInfo(ascan.ascanGateTof, ascan.ascanGateAmp);

        }

        /**Clear line before draw*/
        private void lineClear()
        {
            int lineGeneral = (int)LineID.General;
            int lineMaxUp = (int)LineID.MaxUp;
            int lineMaxDown = (int)LineID.MaxDown;

            tChart.Series[lineGeneral].Clear();
            tChart.Series[lineMaxUp].Clear();
            tChart.Series[lineMaxDown].Clear();
        }

        /**Display wave.*/
        private void displayWaveOnTChart(AscanVideo ascan)
        {
            int lineGeneral = (int)LineID.General;
            uint len = ascan.len;
            double delay = ascan.delay;
            double width = ascan.width;           
#if TEST
            width = 1023;
#endif
            double xStep = width / (len - 1);//Divide width into (len - 1) part.
            float[] xValue, yValue;
            //1024
            if (len == ConstParameter.MaxAscanWaveLen)
            {
                xValue = bigXValue;
                for (int i = 0; i < len; i++)
                    xValue[i] = (float)(delay + xStep * i);

                yValue = bigYValue;
                Array.Copy(ascan.wave, yValue, len);
            }
            //512
            else
            {
                xValue = smallXValue;
                for (int i = 0; i < len; i++)
                    xValue[i] = (float)(delay + xStep * i);

                yValue = smallYValue;
                Array.Copy(ascan.wave, yValue, len);
            }

            tChart.Series[lineGeneral].Add(xValue, yValue);
        }

        /**Display LED*/
        //private void displayMonitorLED(AscanVideo ascan)
        //{
        //    string labelName;
        //    string rectangleShapeName;
        //    uint[] led = ascan.led;

        //    //Get collection of RectangleShape
        //    ShapeCollection shapes = shapeContainer2.Shapes;

        //    for (int i = 0; i < led.Length; i++)
        //    {
        //        rectangleShapeName = "rectangleShape" + i;
        //        labelName = "label" + i;

        //        //Get collection of label 
        //        Control[] controls = this.Controls.Find(labelName, true);

        //        foreach (Shape shape in shapes)
        //        {
        //            if (shape.Name == rectangleShapeName)
        //            {
        //                if (led[i] == (uint)Led.Gray)
        //                {
        //                    (shape as RectangleShape).FillColor = Color.Gray;
        //                    (controls[0] as Label).BackColor = Color.Gray;
        //                }
        //                else if (led[i] == (uint)Led.Green)
        //                {
        //                    (shape as RectangleShape).FillColor = Color.Green;
        //                    (controls[0] as Label).BackColor = Color.Green;
        //                }
        //                else
        //                {
        //                    (shape as RectangleShape).FillColor = Color.Red;
        //                    (controls[0] as Label).BackColor = Color.Red;
        //                }
        //            }
        //        }
        //    }
        //}

        /**Display maxEnvelop*/
        private void displayMaxUp(AscanVideo ascan)
        {
            int lineMaxUp = (int)LineID.MaxUp;
            uint len = ascan.len;
            double delay = ascan.delay;
            double width = ascan.width;
            double xStep = width / (len - 1);//Divide width into (len - 1) part.

            float[] maxEnvelop = ascan.maxEnvelop;
            for (int i = 0; i < len; i++)
            {
                tChart.Series[lineMaxUp].Add(delay + xStep * i, maxEnvelop[i]);
            }
        }

        /**Display minEnvelop*/
        private void displayMaxDown(AscanVideo ascan)
        {
            int lineMaxDown = (int)LineID.MaxDown;
            uint len = ascan.len;
            float[] minEnvelop = ascan.minEnvelop;
            double delay = ascan.delay;
            double width = ascan.width;
            double xStep = width / (len - 1);//Divide width into (len - 2) part.

            for (int i = 0; i < len; i++)
            {
                tChart.Series[lineMaxDown].Add(delay + xStep * i, minEnvelop[i]);
            }
        }

        

        /**Set transmission mode*/
        private void setTransMode(RecieverType type, RadioButton curRad) //para curRad is the RadioButton clicked now
        {
            bool setPre = false;
            int error_code;
            DACParas dacParas = new DACParas();

            error_code = GetDACDAQ.DACFile(SelectAscan.sessionIndex, SelectAscan.port, ref dacParas);
            if (error_code != 0)
                return;

            if (dacParas.dac_on == (uint)DACActive.ON)
            {
                setPre = true;
                MessageShow.show("Warn:DAC active is on, can't set transmisssion!", "警告:DAC已打开, 不能设置!");
            }

            if (setPre)
            {
                preRadTransmission.Checked = true;
                return;
            }

            SetPulserTransmitDAQ.RecieverMode(SelectAscan.sessionIndex, SelectAscan.port, type);
            preRadTransmission = curRad;
        }



        private void judgeNumUpDownInput(NumericUpDown numUpDown, KeyPressEventArgs e)
        {
            /*
            if (numUpDown.Value.ToString().Length > 8)
            {
                e.Handled = true;
                MessageShow.show("The data input length surpass the prescribed length",
                    "输入值超过规定的长度");
            }*/

            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && numUpDown.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
        }

        private void NumUpDownDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            double delay;

            judgeNumUpDownInput(NumUpDownDelay, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (NumUpDownDelay.Text == "")
                {
                    MessageShow.show("Warning:Inputting is null, please input!",
                        "警告：输入为空，请重新输入!");
                    return;
                }

                delay = Convert.ToDouble(NumUpDownDelay.Value);
                setDelay(delay);
            }
        }

        private void NumUpDownDelay_Leave(object sender, EventArgs e)
        {
            if (NumUpDownDelay.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告：请输入!");
                return;
            }

            double delay = Convert.ToDouble(NumUpDownDelay.Value);
            setDelay(delay);
        }

        private void NumUpDownRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            double delay;
            double range;

            judgeNumUpDownInput(NumUpDownRange, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (NumUpDownRange.Text == "")
                {
                    MessageShow.show("Warning:Inputting is null, please input!",
                       "警告：输入为空，请重新输入!");
                    return;
                }

                delay = Convert.ToDouble(NumUpDownDelay.Value);
                range = Convert.ToDouble(NumUpDownRange.Value);
                setRange(delay, range);
            }
        }

        private void NumUpDownRange_Leave(object sender, EventArgs e)
        {
            if (NumUpDownDelay.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告：请输入!");
                return;
            }
            double delay = Convert.ToDouble(NumUpDownDelay.Value);
            double range = Convert.ToDouble(NumUpDownRange.Value);

            setRange(delay, range);
        }

        private void setRange(double delay, double range)
        {
            int error_code;

            if (SetBatchDAQ.isOn)
                error_code = SetBatchDAQ.Range(SelectAscan.sessionIndex, range);
            else
                error_code = SetAscanVideoDAQ.Range(SelectAscan.sessionIndex, SelectAscan.port, range);

            if (error_code != 0)
                return;
            tChart.Axes.Bottom.SetMinMax(delay, delay + range);

            //FormRecordFigure
            FormList.FormRecordFigure.y1 = delay;
            FormList.FormRecordFigure.y2 = delay + range;
            FormList.FormRecordFigure.tChartBscan.Axes.Left.SetMinMax(FormList.FormRecordFigure.y1, FormList.FormRecordFigure.y2);
        }

        private void setDelay(double delay)
        {
            int error_code;
            double range = 0;

            if (SetBatchDAQ.isOn)
                error_code = SetBatchDAQ.Delay(SelectAscan.sessionIndex, delay);
            else
                error_code = SetAscanVideoDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, delay);

            if (error_code != 0)
                return;

            error_code = GetAsacnVideoDAQ.Range(SelectAscan.sessionIndex, SelectAscan.port, ref range);
            if (error_code != 0)
                return;

            tChart.Axes.Bottom.SetMinMax(delay, delay + range);

            //FormRecordFigure
            FormList.FormRecordFigure.y1 = delay;
            FormList.FormRecordFigure.y2 = delay + range;
            FormList.FormRecordFigure.tChartBscan.Axes.Left.SetMinMax(FormList.FormRecordFigure.y1, FormList.FormRecordFigure.y2);

        }

        private void NumUpDownDelay_Click(object sender, EventArgs e)
        {
            double delay = Convert.ToDouble(NumUpDownDelay.Value);
            setDelay(delay);
        }

        private void NumUpDownRange_Click(object sender, EventArgs e)
        {
            double delay = Convert.ToDouble(NumUpDownDelay.Value);
            double range = Convert.ToDouble(NumUpDownRange.Value);

            setRange(delay, range);
        }

        /**Initial the controls of NumUpDownDelay and NumUpDownRange*/
        private int initDelayAndRange()
        {
            int error_code;
            double delay = 0;
            double range = 0;

            error_code = GetAsacnVideoDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, ref delay);
            if (error_code != 0)
                return error_code;

            error_code = GetAsacnVideoDAQ.Range(SelectAscan.sessionIndex, SelectAscan.port, ref range);
            if (error_code != 0)
                return error_code;

            NumUpDownDelay.Text = delay.ToString();
            NumUpDownRange.Text = range.ToString();

            setRange(delay, range);

            return error_code;         
        }

        private void judgeTextBoxInput(TextBox textBox, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                   && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && textBox.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
        }

        private void TextBoxGain_KeyPress(object sender, KeyPressEventArgs e)
        {
            double gain;
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                  && e.KeyChar != '.' && e.KeyChar != (char)109 && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && TextBoxGain.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (TextBoxGain.Text == "")
                {
                    gain = 0;
                    TextBoxGain.Text = "0";
                }
                else
                {
                    gain = Convert.ToDouble(TextBoxGain.Text);

                    if (gain > 82.0)
                    {
                        gain = 82.0;
                        TextBoxGain.Text = "82.0";
                    }

                    if (gain < -48.0)
                    {
                        gain = -48.0;
                        TextBoxGain.Text = "-48.0";
                    }
                }
                TrackBarGain.Value = (int)(gain * 10);
                if (SetBatchDAQ.isOn)
                    SetBatchDAQ.AnalogGain(SelectAscan.sessionIndex, gain);
                else
                    SetReceiverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, gain);
            }
        }

        private void TrackBarGain_MouseUp(object sender, MouseEventArgs e)
        {
            double gain = Convert.ToDouble(TrackBarGain.Value) / 10.0;
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.AnalogGain(SelectAscan.sessionIndex, gain);
            else
                SetReceiverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, gain);
        }

        private void TrackBarGain_Scroll(object sender, EventArgs e)
        {
            double gain = Convert.ToDouble(TrackBarGain.Value) / 10.0;
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.AnalogGain(SelectAscan.sessionIndex, gain);
            else
                SetReceiverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, gain);

            TextBoxGain.Text = gain.ToString();
        }

        private void TextBoxGain_Leave(object sender, EventArgs e)
        {
            if (TextBoxGain.Text == null)
            {
                MessageShow.show("Warning:Please input!", "警告：请输入");
                return;
            }
            double gain = Convert.ToDouble(TextBoxGain.Text);
            TrackBarGain.Value = (int)(gain * 10.0);

            if (SetBatchDAQ.isOn)
                SetBatchDAQ.AnalogGain(SelectAscan.sessionIndex, gain);
            else
                SetReceiverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, gain);
        }

        /**Initial the controls of TextBoxGain and TrackBarGain.*/
        
        private int initGain()
        {
            int error_code;
            double gain = 0;

            error_code = GetRecieverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, ref gain);
            if (error_code != 0)
                return error_code;

            TextBoxGain.Text = gain.ToString();
            TrackBarGain.Value = (int)(gain * 10);
            return error_code;
        }

        /**paint DAC line.*/
        public void drawDACLine(string dacMode, float[] tof, float[] ampPercent,uint dacPoint)
        {
            if (dacMode == "modeOff")
                DACLine.Clear();
            else
            {
                DACLine.Clear();
                for (int i = 0; i < dacPoint; i++)
                {
                    DACLine.Add(tof[i], ampPercent[i]);
                }
            }
        }

        private void toranceMonitorMenuItem_Click(object sender, EventArgs e)
        {
            FormList.FormToranceMonitor.ShowDialog();
        }

        private void dACMenuItem_Click(object sender, EventArgs e)
        {
            FormList.FormDAC.ShowDialog();
        }

        private void materialVelocityMenuItem_Click(object sender, EventArgs e)
        {
            FormList.FormMaterialVelocity.ShowDialog();
        }

        private void probeDelayMenuItem_Click(object sender, EventArgs e)
        {
            FormList.FormProbeDelay.ShowDialog();
        }

        private void mDACMenuItem_Click(object sender, EventArgs e)
        {
            FormList.FormMDAC.ShowDialog();
        }

        private void triggerModeMenuItem_Click(object sender, EventArgs e)
        {
            FormList.FormTriggerMode.ShowDialog();
        }

        private void focusRuleMenuItem_Click(object sender, EventArgs e)
        {
            //聚焦法则界面未做
        }

        private void launchParametersMenuItem_Click(object sender, EventArgs e)
        {
            FormList.FormLaunchParameters.ShowDialog();
        }

        private void conditioningParametersMenuItem_Click(object sender, EventArgs e)
        {
            FormList.FormConditioningParameters.ShowDialog();
        }

        private void comboBoxMagnify_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int error_code;
            double delay = 0;
            double width = 100;

            //Magify off
            if (comboBoxMagnify.SelectedIndex == 0)
            {
                //error_code=initDelayAndRange();

                //error_code = GetAsacnVideoDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, ref delay);
                //if (error_code != 0)
                //    return;

                //error_code = GetAsacnVideoDAQ.Range(SelectAscan.sessionIndex, SelectAscan.port, ref width);
                //if (error_code != 0)
                //    return;


                setDelay(delay);
                setRange(delay,width);

                NumUpDownDelay.Text = delay.ToString();
                NumUpDownRange.Text = width.ToString();
                NumUpDownDelay.Enabled = true;
                NumUpDownRange.Enabled = true;
                tChart.Axes.Bottom.SetMinMax(delay, delay + width);
                //mdiChildSave[sessionOrder].magifyOff = 1;
            }
            else//Magnigfy I、A、B、C
            {
                GateType gateType = (GateType)(comboBoxMagnify.SelectedIndex - 1);//I、A、B、C
                error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref delay);
                if (error_code != 0)
                    return;

                error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref width);
                if (error_code != 0)
                    return;

                error_code = SetAscanVideoDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, delay);
                if (error_code != 0)
                    return;

                error_code = SetAscanVideoDAQ.Range(SelectAscan.sessionIndex, SelectAscan.port, width);
                if (error_code != 0)
                    return;

                NumUpDownDelay.Text = delay.ToString();
                NumUpDownRange.Text = width.ToString();
                NumUpDownDelay.Enabled = false;
                NumUpDownRange.Enabled = false;
                tChart.Axes.Bottom.SetMinMax(delay, delay + width);
            }
        }
        
        //when the numericUpDown of GatePosition is seted, chage the gateLine
        public void updateGateLineFromNud(int gateIndex, double delay, double width, double threshold)
        {
            tChart.Series[gateIndex].Clear();
            tChart.Series[gateIndex].Add(delay, threshold);
            tChart.Series[gateIndex].Add(delay + width, threshold);
        }


        private void checkBoxEnvelop_Click(object sender, EventArgs e)
        {
            
        }

        public void drawGateIWhenIfStartDisabled()
        {
            int error_code;
            double delay = 0;
            double width = 0;
            double threshold = 0;
            error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref delay);
            if (error_code != 0)
                return;

            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref width);
            if (error_code != 0)
                return;

            error_code = GetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref threshold);
            if (error_code != 0)
                return;

            GateI.Clear();
            GateI.Add(delay, threshold);
            GateI.Add(delay + width, threshold);
        }

        private void trackBarSlideSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void enqueue(AscanQueueElement element)
        {
            if (ascanQueue != null)
            {
                if (ascanQueue.Count == ConstParameter.MaxQueueItemCount)
                    updateAscans();
                ascanQueue.Enqueue(element);
            }
        }

        private bool dequeue()
        {
            bool isFrist = true;
            int count = ascanQueue.Count;

            if (count == 0)
                return false;

            while (count > 0)
            {
                if (isFrist)
                {
                    ascanQueue.Dequeue(ref element);
                    isFrist = false;
                }
                else
                {
                    ascanQueue.Dequeue(ref tmpElement);
                    element = merge(element, tmpElement);
                }
                count--;
            }
            return true;
        }

        private AscanQueueElement merge(AscanQueueElement element, AscanQueueElement tmpElement)
        {
            AscanVideo ascanVid = element.ascanPacket.ascan;
            AscanVideo tmpAscanVid = tmpElement.ascanPacket.ascan;
            for (int i = 0; i < ConstParameter.MaxAscanWaveLen; i++)
            {
                ascanVid.wave[i] = Math.Max(ascanVid.wave[i], tmpAscanVid.wave[i]);
                ascanVid.maxEnvelop[i] = Math.Max(ascanVid.maxEnvelop[i], tmpAscanVid.maxEnvelop[i]);
                ascanVid.minEnvelop[i] = Math.Min(ascanVid.minEnvelop[i], tmpAscanVid.minEnvelop[i]);
            }
            return element;
        }

        private void btn_freeze_Click(object sender, EventArgs e)
        {
            if (!isFreeze)
            {
                isFreeze = true;
                if (MultiLanguage.lang == "EN")
                {
                    btn_freeze.Text = "UnFreeze";
                }
                else
                {
                    btn_freeze.Text = "放开";
                }
                
            }
            else
            {
                isFreeze = false;
                if (MultiLanguage.lang == "EN")
                {
                    btn_freeze.Text = "Freeze";
                }
                else
                {
                    btn_freeze.Text = "捕获";
                }               
            }
        }











        //public void FormSave()
        //{
        //    if (mdiChildSave.Count != FormList.FormGatePosition.sessionInfoSave.Count)
        //    {
        //        MessageShow.show("Error:Save Gate failed!", "错误：门参数保存失败!");
        //        return;
        //    }
        //    string filename = SystemConfig.GlobalSave("MDIChildPara");
        //    SystemConfig.WriteBase64Data(filename, "MDIChildPara", mdiChildSave);
        //}


    }

    public enum LineID
    {
        GateI = 0,
        GateA = 1,
        GateB = 2,
        GateC = 3,
        MaxUp = 4,
        MaxDown = 5,
        General = 6,
        DACPoint = 7,
        DACLine = 8,
        TCG = 9,
        MDAC1 = 10,
        MDAC2 = 11,
        MDAC3 = 12,
        MDAC4 = 13,
    }

    public enum Led
    {
        // I, A, B, C, BA, AI, BI, CI
        //	gray					0x00            Disabled 
        //  green					0x01            OK
        //  red					0x02	        NOT OK    
        Gray = 0x00,
        Green = 0x01,
        Red = 0x02
    }

    public class GatePara
    {
        public bool isDragTrigger = false;//the trigger of drag gateline
        public bool isMoveTrigger = false;//the trigger of move gateline

        //the pixel of gateline's starting point and end point,
        //index=0 is the pixel of starting point, index=1 is the pixel of end point.
        public Point[] pointPixel = new Point[2] { new Point(0, 0), new Point(0, 0) };
    }

    
}
