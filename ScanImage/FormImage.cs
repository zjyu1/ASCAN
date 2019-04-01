using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AUT;
using Ascan;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using TChartImage = Steema.TeeChart.Tools.ChartImage;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using NIMotion;


namespace ScanImage
{
    public partial class FormImage :FormMeasurementMap
    {
        BScanSeries bscanSeries;
        FormBscanSet formBscanSet;
        BscanCofig bscanCofig;

        CScanSeries cscanSeries;
        FormCscanSet formCscanSet;
        CscanConfig cscanCofig;

        int scanModeIndex;
        double gateDelay;
        double gateRange;

        private double[] ascanDataX = new double[ConstParameter.BscanPointNumPrePacket];
        private double[] ascanDataY = new double[ConstParameter.BscanPointNumPrePacket];

        BinarySerialize<GatePacket> binarySerialize = new BinarySerialize<GatePacket>();

        FormProManager promanager;
        

        public FormImage()
        {
            InitializeComponent();
            promanager = new FormProManager();
           
            addFormToPanels(promanager,splitContainer4.Panel1);
          

            bscanCofig = new BscanCofig();
            cscanCofig = new CscanConfig();
            //formBscanSet = new FormBscanSet(bscanCofig);
            
        }

        public void addFormToPanels(Form form, SplitterPanel panel)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            form.Parent = panel;
            panel.Controls.Add(form);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
            form.Dock = DockStyle.Fill;
        }

        private void FormImage_Load(object sender, EventArgs e)
        {
            initBColorbar();
            initCColorbar();
            this.FormBorderStyle = FormBorderStyle.None;
        }

         private void initBColorbar()
         {
             int len = BpicBox.Width * BpicBox.Height;
             int index;
             byte r = 0;
             byte g = 0;
             byte b = 0;
             byte[] dataForColor = new byte[len * 3];
             Bitmap imageForColor = new Bitmap(BpicBox.Width, BpicBox.Height);

             for (int i = 0; i < BpicBox.Height; i++)
             {
                 if (RGBImage.getRGB(((double)i) / BpicBox.Height, ref r, ref g, ref b))
                 {
                     for (int j = 0; j < BpicBox.Width; j++)
                     {
                         index = 3 * (i * BpicBox.Width + j);
                         dataForColor[index] = b;
                         dataForColor[index + 1] = g;
                         dataForColor[index + 2] = r;
                     }
                 }
             }
             BpicBox.Image = RGBImage.CreateBitmap(dataForColor, imageForColor);
         }

         private void initCColorbar()
         {
             int len = CpicBox.Width * CpicBox.Height;
             int index;
             byte r = 0;
             byte g = 0;
             byte b = 0;
             byte[] dataForColor = new byte[len * 3];
             Bitmap imageForColor = new Bitmap(CpicBox.Width, CpicBox.Height);

             for (int i = 0; i < CpicBox.Height; i++)
             {
                 if (RGBImage.getRGB(((double)i) / CpicBox.Height, ref r, ref g, ref b))
                 {
                     for (int j = 0; j < CpicBox.Width; j++)
                     {
                         index = 3 * (i * CpicBox.Width + j);
                         dataForColor[index] = b;
                         dataForColor[index + 1] = g;
                         dataForColor[index + 2] = r;
                     }
                 }
             }
             CpicBox.Image = RGBImage.CreateBitmap(dataForColor, imageForColor);
         }

        public void setAxis(TChart tChart, Line line, double horizontalAxisMin, double horizontalAxisMax, 
            double verticalAxisMin, double verticalAxisMax)
        {
            tChart.Axes.Left.SetMinMax(verticalAxisMin, verticalAxisMax);
            tChart.Axes.Bottom.SetMinMax(horizontalAxisMin, horizontalAxisMax);
            if (line != null)
            {
                line.Add(horizontalAxisMin, verticalAxisMin);
            }
        }

        public void setAscanAxis(TChart tChart, int selectGate)
        {
            int error_code;
            AscanWaveDectionMode mode = AscanWaveDectionMode.Rf;

            double gateDelay = 0;
            double gateRange = 0;

            error_code = GetAsacnVideoDAQ.DetectionWaveMode(0, 0, ref mode);
            if (error_code != 0)
                return;

            switch (mode)
            {
                case AscanWaveDectionMode.Rf:
                    tChart.Axes.Bottom.SetMinMax(-1, 1);
                    break;

                case AscanWaveDectionMode.Full:

                case AscanWaveDectionMode.SemiNegtive:

                case AscanWaveDectionMode.SemiPositve:
                    tChart.Axes.Bottom.SetMinMax(0, 1);
                    break;

                default:
                    error_code = -1;
                    MessageShow.show("Initial Ascan teeChart axe failed!", "初始化A扫描画图坐标轴失败！");
                    break;
            }

            GetGateDAQ.Delay(0, 0, (GateType)selectGate, ref gateDelay);
            GetGateDAQ.Width(0, 0, (GateType)selectGate, ref gateRange);
            this.gateDelay = gateDelay;
            this.gateRange = gateRange;
            tChart.Axes.Left.SetMinMax(gateDelay, gateDelay + gateRange);
        }

        public override void addPoints(MeasureQueueElement measureQueueElement)
        {
            int bin = (int)measureQueueElement.gatePacket.head.bin;
            int id = (int)measureQueueElement.gatePacket.head.id;
            if (id == (int)PacketId.eventId && bin == (int)DAQ_EVENT.STOP_EVENT)
            {
                if (scanModeIndex == (int)ScanMode.Bscan)
                {
                    bscanSeries.clear();
                    //if (bscanCofig.IsSave)
                        //binarySerialize.SetializeClose();
                }
                else
                {
                    cscanSeries.clear();
                    //if (cscanCofig.IsSave)
                        //binarySerialize.SetializeClose();
                }
                return;
            }
            if (id == (int)PacketId.eventId && bin == (int)DAQ_EVENT.START_EVENT) ;


      
                updateCscan(measureQueueElement);
                updateBscan(measureQueueElement);

        }

        public override bool isBoardNameInMeasureCorrect()
        {return true;}

        public override void startInspect()
        { }



        private void updateBscan(MeasureQueueElement measureQueueElement)
        {
            int boardIndex = measureQueueElement.boardIndex;
            int id = (int)measureQueueElement.gatePacket.head.id;
            int bin = (int)measureQueueElement.gatePacket.head.bin;

            if (boardIndex == bscanCofig.AscanIndex && id == (int)PacketId.BGate && bin == (int)DAQ_MEAS_MODE.GATEIN_DATA)
            {
                GatePacket gatePacket = measureQueueElement.gatePacket;
                bscanSeries.add(gatePacket, bscanCofig.Range);
                bscanSeries.updatePicture();
                //showAscan(measureQueueElement);
                if (bscanCofig.IsSave)
                    binarySerialize.SerializeWrite(gatePacket);

            }
        }

        private void updateCscan(MeasureQueueElement measureQueueElement)
        {
            int boardIndex = measureQueueElement.boardIndex;
            int id = (int)measureQueueElement.gatePacket.head.id;
            int bin = (int)measureQueueElement.gatePacket.head.bin;
            if (boardIndex == cscanCofig.AscanIndex && id == cscanCofig.SelectGate && bin == (int)DAQ_MEAS_MODE.AMP_PERCENT)
            {
                GatePacket gatePacket = measureQueueElement.gatePacket;
                cscanSeries.add(gatePacket);
                cscanSeries.updatePicture();
                showAscan(measureQueueElement);
                if (cscanCofig.IsSave)
                    binarySerialize.SerializeWrite(gatePacket);
            }

        }

        private void showAscan(MeasureQueueElement measureQueueElement)
        {
            int num = ConstParameter.BscanPointNumPrePacket;//256点

            float[] measureDate = measureQueueElement.gatePacket.measureDate;
            float measureDateMax = measureDate.Max();
            int measureDateMaxIndex = Array.IndexOf(measureDate, measureDateMax);

            int k = measureDateMaxIndex / num; //第k条Bscan数据的

            k = k * num;
            double delay = gateDelay;
            double width = gateRange;
            double yStep = width / (num - 1);//Divide width into (ConstParameter.BscanPointNumPrePacket - 1) part.
            for (int i = 0; i < num; i++)
            {
                ascanDataX[i] = measureDate[k + i];
                ascanDataY[i] = delay + yStep * i;
            }

            AscanLine.Add(ascanDataX, ascanDataY);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (scanModeIndex == (int)ScanMode.Bscan)
            {
                if (bscanSeries == null)
                    bscanSeries = new BScanSeries(tChartBscan, bscanCofig);
            }
            else if (scanModeIndex == (int)ScanMode.Cscan)
            {
                if (cscanSeries == null)
                    cscanSeries = new CScanSeries(tChartCscan, cscanCofig);
                if (bscanSeries == null)
                    bscanSeries = new BScanSeries(tChartBscan, bscanCofig);
                bscanSeries.clear();
                cscanSeries.clear();
            }
            else
                MessageShow.show("please set paramiter!", "请设置参数！");


        }

        private void btnBscanMove_Click(object sender, EventArgs e)
        {
            BscanMotion bscanMotion = new BscanMotion();
            bscanMotion.Show();
        }

        private void btnCscanMove_Click(object sender, EventArgs e)
        {
            CscanMotion cscanMotion = new CscanMotion();
            cscanMotion.Show();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            UnionMove unionMove = new UnionMove();
            unionMove.Show();
        }

        private void btn_paramater_Click(object sender, EventArgs e)
        {
            formCscanSet = new FormCscanSet(cscanCofig, bscanCofig);
            formCscanSet.ShowDialog();

            setAxis(tChartCscan, lineC, cscanCofig.HorizontalAxisMin, cscanCofig.HorizontalAxisMax,
                    cscanCofig.VerticalAxisMin, cscanCofig.VerticalAxisMax);

            setAxis(tChartBscan, lineB, bscanCofig.HorizontalAxisMin, bscanCofig.HorizontalAxisMax,
                    bscanCofig.VerticalAxisMin, bscanCofig.VerticalAxisMax);

            int selectGate = (int)System.Math.Sqrt(cscanCofig.SelectGate);
            setAscanAxis(tChartAscan, selectGate);
            if (cscanCofig.IsSave)
                binarySerialize.SerializeOpen(cscanCofig.FileName);


        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            if (cscanSeries == null)
                cscanSeries = new CScanSeries(tChartCscan, cscanCofig);
            if (bscanSeries == null)
                bscanSeries = new BScanSeries(tChartBscan, bscanCofig);
            bscanSeries.clear();
            //cscanSeries.clear();

            CscanMotion cscanMotion = new CscanMotion();
            cscanMotion.Show();
        }

    }

    public enum ScanMode
    {
        Bscan=0,
        Cscan=1
    }


}
