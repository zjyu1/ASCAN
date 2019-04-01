using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System.Threading;
using TChartHorizLine = Steema.TeeChart.Styles.HorizLine;
using TChartPoints = Steema.TeeChart.Styles.Points;
using Map = Steema.TeeChart.Styles.Map;
using TChartImage = Steema.TeeChart.Tools.ChartImage;
using Ascan;
namespace AUT
{
    public partial class FormCalibration : FormMeasurementMap
    {
        public static FormCalibResult FormCalibResult;
        private List<SessionInfo> sessionsInfoList;
        private List<Defect> sampleDefects = new List<Defect>();
        private List<SessionInfo> showSessionList;
        private List<calibStripColumn> stripColumnList;
        private List<calibTofdColumn> tofdColumnList;
        private List<calibInfoData> calibInfoDataList;
        private Hashtable MaxValueOfSessions;
        private System.Windows.Forms.Panel showPanel;
        private double maxPosValue;
        private int lastvScrollBarValue;//record last vScrollBarValue,used to update vScrollBarValue in specific step
        Motion motion;
        private int dir,range,speed;
        private int realTimeDir;
        private double realTimePos, realTimeSpeed;
        private System.Timers.Timer timer = new System.Timers.Timer(100);
        private System.Timers.Timer motiontimer = new System.Timers.Timer(100);
        private delegate void updateDelegate();
        private updateDelegate updateCallBack;
        private updateDelegate updateMotionCallBack;
        private calibStripColumn scaleColumn;
        public FormCalibration(MainForm mainForm)
        {
            InitializeComponent();
            //calibInfoDataGridView.Height = (int)(this.panel3.Height * 0.8);
            stripColumnList = new List<calibStripColumn>();
            tofdColumnList = new List<calibTofdColumn>();
            showSessionList = new List<SessionInfo>();
            calibInfoDataList = new List<calibInfoData>();
            MaxValueOfSessions = new Hashtable();
            this.sessionsInfoList = mainForm.sessionsInfo;
            this.sampleDefects = mainForm.sampleDefects;
            maxPosValue = 0;
            lastvScrollBarValue = 0;
            //justfortest();

            //initControls();
            //initScroll();
            //updateShowSessionList();
            //updateSessionGridView();
            //updateCalibInfoDataGridView();
            //updateStripMap();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateCheckAUT);
            motiontimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateMotionState);
            motion = MainForm.motion;

            //motion = new Motion();
            //motion.Initial_Motion();
            dir = 0; range = 0; speed = 0;
            realTimeDir = 0; realTimePos = 0; realTimeSpeed = 0;
        }

        private void initControls()
        {
            showPanel = new System.Windows.Forms.Panel();
            showPanel.Parent = this.splitContainer1.Panel1;
            showPanel.Dock = DockStyle.Fill;
            showPanel.BackColor = Color.White;
            this.splitContainer1.SplitterDistance = this.splitContainer1.Width - 20;
            this.splitContainer1.Height = (int)(this.panel1.Height * 3.0 / 5.0); 
            foreach (SessionInfo session in sessionsInfoList)
            {
                if (session.zonename == null)   //the TOFD session is excluded
                    continue;
                areaComboBox.Items.Add(session.zonename);

            }
            areaComboBox.Items.Add("ALL");
            areaComboBox.SelectedIndex = areaComboBox.Items.Count - 1;
            typeComboBox.SelectedIndex = typeComboBox.Items.Count - 1;
            //dircComboBox.SelectedIndex = dircComboBox.Items.Count - 1;
        }


        private void FormCalibration_Load(object sender, EventArgs e)
        {
            initControls();
            initScroll();
            updateShowSessionList();
            updateSessionGridView();
            updateCalibInfoDataGridView();
            updateStripMap();
        }

        private void initScroll()
        {
            maxPosValue = 0;
            vScrollBar.Minimum = 0;
            vScrollBar.Maximum = ConstParameter.ScalePrePage;
            vScrollBar.Value = 0;
            vScrollBar.SmallChange = 10;
            vScrollBar.LargeChange = vScrollBar.Maximum;
            //updateAxes(ConstParameter.ScalePrePage);
        }

        private void updateScroll()
        {
            if (maxPosValue <= ConstParameter.ScalePrePage + ConstParameter.DistTOFD2PA)
                return;
            else
                vScrollBar.LargeChange = (int)((ConstParameter.ScalePrePage / (maxPosValue - ConstParameter.DistTOFD2PA)) * vScrollBar.Maximum);
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int scaleperpage = ConstParameter.ScalePrePage;
            if (System.Math.Abs(e.NewValue - lastvScrollBarValue) > 10) //滚动条最小步进更新值10，即每改变10，才更新刷图一次
            {
                lastvScrollBarValue = e.NewValue;
                double reshowPosValue = e.NewValue * (maxPosValue - ConstParameter.DistTOFD2PA - scaleperpage) / (vScrollBar.Maximum - vScrollBar.LargeChange) + scaleperpage + ConstParameter.DistTOFD2PA;
                updateAxes(reshowPosValue);
            }
        }

        private void justfortest()
        {
            /*for (int i = 0; i < 5; i++)
            {
                SessionInfo Session0 = new SessionInfo(0, i, i);
                Session0.myHardInfo.AssignedName = "L1";
                sessionsInfoList.Add(Session0);
            }
            SessionInfo Session1 = new SessionInfo(1, 8, 8);
            Session1.myHardInfo.AssignedName = "TOFD";
            sessionsInfoList.Add(Session1);*/
            /*rowDatasList = new List<RowData>();
            for (int i = 0; i < 8; i++)
            {
                RowData newrow = new RowData();
                newrow.Cycle = "L1"; newrow.Activity = true; newrow.Source = Source.GateB; newrow.Mode = Mode.Strip;
                rowDatasList.Add(newrow);
            }
            RowData newrow1 = new RowData();
            newrow1.Cycle = "TOFD"; newrow1.Activity = true; newrow1.Source = Source.GateB; newrow1.Mode = Mode.TOFD;
            rowDatasList.Add(newrow1);*/
            SessionInfo Session0 = new SessionInfo(0, 0, 0);
            Session0.myHardInfo.AssignedName = "L1"; Session0.type = 0; Session0.LR = 1; Session0.zonename = "FILL-0-L";
            sessionsInfoList.Add(Session0);
            SessionInfo Session1 = new SessionInfo(0, 1, 1);
            Session1.myHardInfo.AssignedName = "L2"; Session1.type = 0; Session1.LR = 1; Session1.zonename = "FILL-1-L";
            sessionsInfoList.Add(Session1);
            SessionInfo Session2 = new SessionInfo(0, 2, 2);
            Session2.myHardInfo.AssignedName = "L3"; Session2.type = 1; Session2.LR = 1; Session2.zonename = "HP-0-L";
            sessionsInfoList.Add(Session2);
            SessionInfo Session3 = new SessionInfo(0, 3, 3);
            Session3.myHardInfo.AssignedName = "R1"; Session3.type = 0; Session3.LR = 0; Session3.zonename = "FILL-0-R";
            sessionsInfoList.Add(Session3);

            Defect defect0 = new Defect();
            defect0.subregionName = "FILL-0-L"; defect0.beginRadio = 1.0; defect0.endRadio = 10.0;
            sampleDefects.Add(defect0);
            Defect defect1 = new Defect();
            defect1.subregionName = "FILL-1-L"; defect1.beginRadio = 2.0; defect1.endRadio = 9.0;
            sampleDefects.Add(defect1);
            Defect defect2 = new Defect();
            defect2.subregionName = "HP-0-L"; defect2.beginRadio = 3.0; defect2.endRadio = 8.0;
            sampleDefects.Add(defect2);
            Defect defect3 = new Defect();
            defect3.subregionName = "FILL-0-R"; defect3.beginRadio = 1.0; defect3.endRadio = 10.0;
            sampleDefects.Add(defect3);

            Defect defect4 = new Defect();
            defect4.subregionName = "FILL-0-R"; defect4.beginRadio = 11.0; defect4.endRadio = 15.0;
            sampleDefects.Add(defect4);

            MaxValueOfSessions.Add(Session0.myHardInfo.AssignedName, 0.6);
            MaxValueOfSessions.Add(Session1.myHardInfo.AssignedName, 0.7);
            MaxValueOfSessions.Add(Session2.myHardInfo.AssignedName, 0.8);
            MaxValueOfSessions.Add(Session3.myHardInfo.AssignedName, 0.9);
        }

        private void cleanSet()
        {
            showPanel.Controls.Clear();

            if (scaleColumn != null)
            {
                scaleColumn.clearSets();
                scaleColumn = null;
            }

            if (stripColumnList != null)
            {
                for (int i = stripColumnList.Count - 1; i >= 0; i--)
                {
                    stripColumnList[i].clearSets(); //clean all child Controls
                    if (stripColumnList[i] != null)
                        stripColumnList[i] = null;
                    stripColumnList.RemoveAt(i);
                }
            }

            if (tofdColumnList != null)
            {
                for (int i = tofdColumnList.Count - 1; i >= 0; i--)
                {
                    tofdColumnList[i].clearSets(); //clean all child Controls
                    if (tofdColumnList[i] != null)
                        tofdColumnList[i] = null;
                    tofdColumnList.RemoveAt(i);
                }
            }
            GC.Collect();
        }

        private void clearViews()
        {
            if (stripColumnList != null)
                for (int i = stripColumnList.Count - 1; i >= 0; i--)
                    stripColumnList[i].clearViews();
            if (tofdColumnList != null)
                for (int i = tofdColumnList.Count - 1; i >= 0; i--)
                    tofdColumnList[i].clearViews();
            this.updateAxes(ConstParameter.ScalePrePage + ConstParameter.DistTOFD2PA);
        }

        /// <summary>
        /// get the calibStripType according to assignName
        /// </summary>
        /// <param name="index">the index in showSessionList</param>
        /// <returns>type of PAstrip or TOFDmap</returns>
        private calibStripType getShowType(string assignName)
        {
            //calibStripType type;
            //if ((assignName[0] == 'L') || (assignName[0] == 'R'))
            //    type = calibStripType.PAstrip;
            //else
            //    type = calibStripType.TOFDmap;
            //return type;
            if (assignName[0] == 'C' || assignName[0] == 'c')
                return calibStripType.Couple;
            else
                return calibStripType.PAstrip;
        }

        /// <summary>
        /// update the content in showSessionList when change the dircCombox or others
        /// </summary>
        private void updateShowSessionList()
        {
            //update according to area ,direc,etc...
            for (int k = showSessionList.Count - 1; k >= 0; k--)
                showSessionList.RemoveAt(k);
            /*for (int i = 0; i < sessionsInfoList.Count; i++)
                showSessionList.Add(sessionsInfoList[i]);*/
            int typeIndex = typeComboBox.SelectedIndex;
            string area = areaComboBox.SelectedItem.ToString();
            int dircIndex = dircComboBox.SelectedIndex;
            foreach (SessionInfo session in sessionsInfoList)
            {
                if ((session.type == typeIndex || typeIndex == 4) && (session.LR == dircIndex || dircIndex == 2) && (area == session.zonename || area =="ALL"))
                    showSessionList.Add(session);
            }

            /*foreach (SessionInfo session in showSessionList)
            {
                int flag = 0;
                foreach (Defect defect in sampleDefects)
                {
                    flag = 0;
                    if (defect.subregionName == session.zone && defect.type == typeIndex)
                    {
                        flag = 1;
                        break;
                    }                            
                }
                if(flag != 1)
                    showSessionList.Remove(session);
            }*/
        }


        /// <summary>
        /// use the updated showSessionList to update SessionGridView;
        /// </summary>
        private void updateSessionGridView()
        {
            int rowsNum = sessionDataGridView.Rows.Count;
            for (int i = rowsNum-1; i >= 0; i--) //remove all cells first
                sessionDataGridView.Rows.RemoveAt(i);

            if (showSessionList.Count == 0)
                return;
            for (int i = 0; i < showSessionList.Count; i++)
            {
                this.sessionDataGridView.Rows.Add();
                sessionDataGridView.Rows[i].Cells[0].Value = showSessionList[i].myHardInfo.AssignedName;
            }
        }

        /// <summary>
        /// 1)update calibInfoDataList according to showSessionList and some othres
        /// 2)update CalibInfoDataGridView
        /// </summary>
        private void updateCalibInfoDataGridView()
        {
            for (int k = calibInfoDataGridView.Rows.Count - 1; k >= 0; k--) //remove all cells first
                calibInfoDataGridView.Rows.RemoveAt(k);
            for (int j = calibInfoDataList.Count -1; j >= 0; j--)           //remove all calibInfoData
                calibInfoDataList.RemoveAt(j);

            foreach (SessionInfo session in showSessionList)
            {
                /* calibInfoData newInfoData = new calibInfoData();
                newInfoData.setCalibInfoData(showSessionList[i]);
                calibInfoDataList.Add(newInfoData);*/
                foreach (Defect defect in sampleDefects)
                {
                    if (defect.subregionName == session.zonename)    //just for test ,needed to change subregionName and zone to enum type
                    {
                        calibInfoData newcalibInfoData = new calibInfoData();
                        newcalibInfoData.setCalibInfoData(session, defect);
                        calibInfoDataList.Add(newcalibInfoData);
                    }
                }
            }

            for (int m = 0; m < calibInfoDataList.Count; m++)
            {
                calibInfoDataGridView.Rows.Add();
                calibInfoDataGridView.Rows[m].Cells["name"].Value = m;
                calibInfoDataGridView.Rows[m].Cells["session"].Value = calibInfoDataList[m].sessionName;
                calibInfoDataGridView.Rows[m].Cells["area"].Value = calibInfoDataList[m].area;
                //calibInfoDataGridView.Rows[m].Cells["type"].Value = calibInfoDataList[m].type;
                calibInfoDataGridView.Rows[m].Cells["axialStartPos"].Value = calibInfoDataList[m].axialStartPos;
                calibInfoDataGridView.Rows[m].Cells["axialEndPos"].Value = calibInfoDataList[m].axialEndPos;
                calibInfoDataGridView.Rows[m].Cells["circleStartPos"].Value = calibInfoDataList[m].circleStartPos;
                calibInfoDataGridView.Rows[m].Cells["circleEndPos"].Value = calibInfoDataList[m].circleEndPos;
                string typearea;
                switch (calibInfoDataList[m].type)
                { 
                    case 0:
                        typearea = "Fill"; break;
                    case 1:
                        typearea = "HP"; break;
                    case 2:
                        typearea = "LCP"; break;
                    case 3:
                        typearea = "ROOT"; break;
                        
                    default:
                        typearea = ""; break;

                }
                calibInfoDataGridView.Rows[m].Cells["type"].Value = typearea;
            }
        }

        /// <summary>
        /// create the stripColumnList and tofdColumnList for each showSession
        /// </summary>
        private void updateStripMap()
        {
            cleanSet();//clean all the controls before update the stripMap
            //int totalnum = showSessionList.Count;
            int totalnum = caltotalnum();
            if (totalnum == 0)
                return;
            //System.Windows.Forms.Panel showPanel = splitContainer1.Panel1;
            float totalwidth = showPanel.Width;
            float scaleWidth = 30f;
            totalwidth -= scaleWidth;
            float subpanelwidth = totalwidth / totalnum;
            float curPos = 0;

            scaleColumn = new calibStripColumn(showPanel, curPos, scaleWidth, null, calibStripType.Scale);
            curPos += scaleWidth;

            for (int i = 0; i < totalnum; i++)
            {
                //RowData rowData = rowDatasList[i];
                string assignName = showSessionList[i].myHardInfo.AssignedName;
                //SessionHardWare.getInfo(assignName, out upPort);
                calibStripType showtype = getShowType(assignName);
                if (showtype == calibStripType.PAstrip)
                {
                    calibStripColumn newColumn = new calibStripColumn(showPanel, curPos, subpanelwidth, assignName, showtype);
                    //stripColumnList newColumn = new stripColumnList(showPanel, rowData, curPos, subpanelwidth, MapType.Strip);
                    stripColumnList.Add(newColumn);
                    curPos += subpanelwidth;
                }
                else if (showtype == calibStripType.TOFDmap)
                {
                    calibStripColumn newColumn = new calibStripColumn(showPanel, curPos, subpanelwidth, assignName, calibStripType.PAstrip);
                    //PictureColumn pictureDatas = new PictureColumn(showPanel, rowData, curPos, subpanelwidth, PictureType.TOFD);
                    stripColumnList.Add(newColumn);
                    curPos += subpanelwidth;
                }

            }
        }

        private int caltotalnum()
        {
            int num = 0;
            for (int i = 0; i < showSessionList.Count; i++)
            {
                if (showSessionList[i].myHardInfo.AssignedName[0] != 'C' && showSessionList[i].myHardInfo.AssignedName[0] != 'c')
                    num++;
            }
            return num;
        }

        public override void addPoints(MeasureQueueElement measureQueueElement)
        {
            if (measureQueueElement == null)
                return;

            int boardIndex = measureQueueElement.boardIndex;
            int id = (int)measureQueueElement.gatePacket.head.id;
            int bin = (int)measureQueueElement.gatePacket.head.bin;
            int port = (int)measureQueueElement.gatePacket.head.port;
            Source source;
            double tmpMaxValue;
            switch (id)
            {
                case (int)PacketId.none:
                    source = Source.Error;
                    break;
                case (int)PacketId.IGate:
                    source = Source.GateI;
                    break;
                case (int)PacketId.AGate:
                    source = Source.GateA;
                    break;
                case (int)PacketId.BGate:
                    source = Source.GateB;
                    break;
                case (int)PacketId.CGate:
                    source = Source.GateC;
                    break;
                default:
                    source = Source.Error;
                    break;
            }

            if (id == (int)PacketId.eventId)
            {
                if (bin == (int)DAQ_EVENT.START_EVENT)
                {
                    timer.Enabled = true;
                    timer.Start();
                    motiontimer.Enabled = true;
                    motiontimer.Start();
                    maxPosValue = 0;
                    this.clearViews();
                    this.Invoke(new Action(() =>
                    {      //在主线程上执行委托，目的函数为updateScroll（）
                        initScroll();
                    }));
                    Thread.Sleep(10);
                }
                else if (bin == (int)DAQ_EVENT.STOP_EVENT)
                {
                    timer.Enabled = false;
                    timer.Stop();
                    motiontimer.Enabled = false;
                    motiontimer.Stop();
                    //startCalibrateButton.Enabled = true;
                }
                else
                {
                    //doing nothing
                }
            }

            if (source == Source.Error)
                return;

            foreach (calibStripColumn stripColumn in stripColumnList)
            {
                if ((bin == (int)DAQ_MEAS_MODE.TOF_PEAK || bin == (int)DAQ_MEAS_MODE.AMP_PERCENT) && stripColumn.isMatched(port))
                {
                    tmpMaxValue = stripColumn.add(measureQueueElement.gatePacket, boardIndex);
                    if (tmpMaxValue > maxPosValue)
                    {
                        maxPosValue = tmpMaxValue;
                        //updateAxes(maxPosValue);
                    }
                }
            }

            foreach (calibTofdColumn tofdColumn in tofdColumnList)  //tofdColumn is nearly the same as stripColumn, use TOF_PEAK and AMP_PERCENT
            {
                if ((bin == (int)DAQ_MEAS_MODE.TOF_PEAK || bin == (int)DAQ_MEAS_MODE.AMP_PERCENT) && tofdColumn.isMatched(port))
                {
                    tmpMaxValue = tofdColumn.add(measureQueueElement.gatePacket, boardIndex);
                    if (tmpMaxValue > maxPosValue)
                    {
                        maxPosValue = tmpMaxValue;
                        //updateAxes(maxPosValue);
                    }
                }
            }
        }
        public void updatePicture()
        {
            updateAxes(maxPosValue);
        }

        private void UpdateCheckAUT(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (updateCallBack == null)
                updateCallBack = new updateDelegate(updatePicture);
            this.BeginInvoke(updateCallBack);
        }

        private void updateAxes(double curPosValue)
        {
            if (curPosValue < ConstParameter.DistTOFD2PA)    //wait until running over DistTOFD2PA's distance
                return;

            //用于更新滚动条
            //this.Invoke(new Action(() =>
            //{      //在主线程上执行委托，目的函数为updateScroll（）
            updateScroll();
            //}));
            if (scaleColumn != null)
                scaleColumn.updateAxes(curPosValue - ConstParameter.DistTOFD2PA, YAxesType.Distance);

            foreach (calibStripColumn stripColumn in stripColumnList)
                stripColumn.updateAxes(curPosValue);

            foreach (calibTofdColumn tofdColumn in tofdColumnList)
                tofdColumn.updateAxes(curPosValue);

            //updateMotionState();
        }

        private void updateMotionState()
        {
            realTimePos = motion.ReadPosition();
            realTimeSpeed = motion.ReadSpeed();
            textBoxRealPos.Text = Convert.ToString(realTimePos);
            textBoxRealSpeed.Text = Convert.ToString(realTimeSpeed);
            if (realTimeSpeed >= 0)
                textBoxRealDirec.Text = "正";
            else
                textBoxRealDirec.Text = "反";
        }

        private void UpdateMotionState(object sender, System.Timers.ElapsedEventArgs e)
        { 
            if(updateMotionCallBack == null)
                updateMotionCallBack  = new updateDelegate(updateMotionState);
            this.BeginInvoke(updateMotionCallBack);
        }

        private void getMaxValueofEachLine()
        {
            double circleStartPos;
            double circleEndPos;
            foreach (calibStripColumn stripColumn in stripColumnList) //find out the calibInfoData that matches with this stripColumn
            {                                                         //then get circleStartPos and circleEndPos to calculate maxvalue                      
                circleStartPos = 0;
                circleEndPos = 0;
                foreach (calibInfoData infodata in calibInfoDataList)
                {
                    if (infodata.sessionName == stripColumn.assignName)
                    {
                        circleStartPos = infodata.circleStartPos;
                        circleEndPos = infodata.circleEndPos;
                        break;
                    }
                }
                double maxvalue = stripColumn.getMaxValueofLine(circleStartPos, circleEndPos);
                string assignName = stripColumn.assignName;
                if (MaxValueOfSessions.ContainsKey(assignName))
                    MaxValueOfSessions[assignName] = maxvalue;
                else
                    MaxValueOfSessions.Add(assignName, maxvalue);
            }
            foreach (calibTofdColumn tofdColumn in tofdColumnList)
            {
                double maxvalue = tofdColumn.getMaxValueofLine();
                string assignName = tofdColumn.assignName;
                if (MaxValueOfSessions.ContainsKey(assignName))
                    MaxValueOfSessions[assignName] = maxvalue;
                else
                    MaxValueOfSessions.Add(assignName, maxvalue);
            }
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            getMaxValueofEachLine();
            if (FormCalibResult == null)
            {
                FormCalibResult = new FormCalibResult(showSessionList, MaxValueOfSessions);
            }
            FormCalibResult.ShowDialog();
        }

        private void dircComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateShowSessionList();
            updateSessionGridView();
            updateCalibInfoDataGridView();
            updateStripMap();
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateShowSessionList();
            updateSessionGridView();
            updateCalibInfoDataGridView();
            updateStripMap();
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateShowSessionList();
            updateSessionGridView();
            updateCalibInfoDataGridView();
            updateStripMap();
            
        }

        private void startCalibrateButton_Click(object sender, EventArgs e)
        {
            motion.Go(dir, range, speed * 66);  //change mm/s to r/min
            if(FormCalibResult != null)
                FormCalibResult.isGainSetDown = false;
        }

        private void reCalibrateButton_Click(object sender, EventArgs e)
        {
            motion.Go(dir, range, speed * 66);  //change mm/s to r/min
            if(FormCalibResult != null)
                FormCalibResult.isGainSetDown = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            motion.Stop();
            motion.SetStopIO();
            //startCalibrateButton.Enabled = true;
        }

        private void judgeTextBoxInput(TextBox textbox, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                && e.KeyChar != '.')// '0 - 9', '.' and backspace , this three input is allowed 
            {
                e.Handled = true;   //ignore this input
            }

            if (e.KeyChar == '.' && textbox.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
        }

        private void textBoxRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeTextBoxInput(textBoxRange, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                range = (int)Convert.ToDouble(textBoxRange.Text);
            }
        }

        private void textBoxRange_Leave(object sender, EventArgs e)
        {
            if (textBoxRange.Text == "")
            {
                textBoxRange.Text = "0";
                range = 0;
            }
            range = (int)Convert.ToDouble(textBoxRange.Text);
        }

        private void textBoxSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeTextBoxInput(textBoxSpeed, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                speed = (int)Convert.ToDouble(textBoxSpeed.Text);
                if (speed > 15)
                {
                    speed = 15;
                    textBoxSpeed.Text = "15.0";
                }
            }
        }

        private void textBoxSpeed_Leave(object sender, EventArgs e)
        {
            if (textBoxSpeed.Text == "")
            {
                textBoxSpeed.Text = "0";
                speed = 0;
            }
            speed = (int)Convert.ToDouble(textBoxSpeed.Text);
            if (speed > 15)
            {
                speed = 15;
                textBoxSpeed.Text = "15.0";
            }
        }

        private void radioPosDir_Click(object sender, EventArgs e)
        {
            dir = 0;
        }

        private void radioNegDir_Click(object sender, EventArgs e)
        {
            dir = 1;
        }
    }

    [Serializable]
    public class calibStripColumn
    {
        private TChart newTchart;
        private TextBox textBox;
        private System.Windows.Forms.Panel subPanle;
        private System.Windows.Forms.Panel textPanle;
        private System.Windows.Forms.Panel showPanle;
        private StripSeries stripSeries;
        private calibStripType type;
        public string assignName;
        private double delay;
        private double range;
        private double xPos;
        public calibStripColumn(System.Windows.Forms.Panel panel, float widthPos, float subpanelwidth, string assignName, calibStripType type)
        {
            this.type = type;
            this.assignName = assignName;
            this.xPos = widthPos;
            initControls(panel, widthPos, subpanelwidth);
            switch (this.type)
            { 
                case calibStripType.PAstrip:
                    stripSeries = new StripSeries(this.newTchart);
                    break;
                case calibStripType.Scale:
                    stripSeries = null;
                    break;
            }
        }

        private void initControls(System.Windows.Forms.Panel panel, float widthPos, float subpanelwidth)
        {
            subPanle = new System.Windows.Forms.Panel();
            subPanle.Parent = panel;
            subPanle.Width = (int)subpanelwidth;
            subPanle.Height = panel.Height;
            subPanle.Location = new Point((int)widthPos, panel.Location.Y);

            textPanle = new System.Windows.Forms.Panel();
            textPanle.Parent = subPanle;
            textPanle.Width = (int)subpanelwidth;
            textPanle.Height = (int)(panel.Height * 0.04);
            textPanle.Location = new Point(0, panel.Location.Y);

            showPanle = new System.Windows.Forms.Panel();
            showPanle.Parent = subPanle;
            showPanle.Width = (int)subpanelwidth;
            int i = showPanle.Width;
            showPanle.Height = panel.Height - textPanle.Height;
            showPanle.Location = new Point(0, textPanle.Location.Y + textPanle.Height);

            textBox = new TextBox();
            textBox.Multiline = false;
            textBox.ReadOnly = true;
            textBox.BackColor = Color.FromArgb(192, 255, 192);
            textBox.BackColor = Color.White;
            textBox.Font = new Font("微软雅黑", 10f);
            textBox.Text = assignName;
            textBox.Parent = textPanle;
            textBox.Dock = DockStyle.Fill;
            textBox.Margin = new Padding(0);
            textBox.TextAlign = HorizontalAlignment.Center;

            newTchart = new TChart();
            newTchart.Axes.Left.Minimum = 0;
            newTchart.Axes.Bottom.Minimum = 0;
            newTchart.Aspect.View3D = false;
            newTchart.Header.Visible = false;

            newTchart.BackColor = Color.White; 
            newTchart.Parent = showPanle;
            newTchart.Dock = DockStyle.Fill;
            newTchart.Legend.Visible = false;
            newTchart.Walls.Visible = false;
            newTchart.Zoom.Allow = false;
            newTchart.Panel.MarginUnits = PanelMarginUnits.Percent;
            newTchart.Panel.MarginTop = 0D;
            newTchart.Panel.MarginBottom = 0D;
            newTchart.Panel.MarginRight = 0D;
            newTchart.Panel.MarginLeft = 0D;
            newTchart.Margin = new Padding(0);
            newTchart.Header.Visible = false;
            newTchart.Axes.Bottom.SetMinMax(0, 100);
            newTchart.Axes.Bottom.Increment = (30 - 20) / 10;
            newTchart.Axes.Bottom.Labels.Visible = true;
            newTchart.Axes.Bottom.Visible = false;
            newTchart.Axes.Bottom.Grid.Visible = false;
            newTchart.Axes.Left.Grid.Visible = false;
            newTchart.Axes.Left.SetMinMax(0, 200);
            newTchart.Axes.Left.Inverted = true;
            newTchart.Axes.Left.Visible = false;

            switch (this.type)
            {
                case calibStripType.PAstrip:
                    {
                        newTchart.Zoom.Allow = false;
                        newTchart.Axes.Left.Visible = false;
                        newTchart.Axes.Left.Labels.Visible = false;
                        break;
                    }
                case calibStripType.Scale:
                    {
                        newTchart.Zoom.Allow = false;
                        newTchart.Axes.Left.Visible = true;
                        newTchart.Axes.Left.Labels.Visible = true;
                        newTchart.Series.Add(new Steema.TeeChart.Styles.Map());//Add a series of map just to show the axes of left
                        break;
                    }
            }

            newTchart.Refresh();
        }

        public void clearSets()
        {
            if (newTchart != null)
            {
                for (int i = newTchart.Series.Count - 1; i >= 0; i--)
                    newTchart.Series.RemoveAt(i);
            }
            if (textBox != null) textBox = null;
            if (textPanle != null) textPanle = null;
            if (newTchart != null) newTchart = null;
            if (stripSeries != null) stripSeries = null;
            if (showPanle != null) showPanle = null;
            if (subPanle != null) subPanle = null;
        }

        public void clearViews()
        {
            if (stripSeries != null)
                stripSeries.clear();
        }

        public double add(GatePacket gatePacket, int boardIndex)
        {
            if (stripSeries == null)
                return 0;

            if (delay == -1 || delay == 0 || range == -1 || range == 0)
            {
                int port;
                int userIndex = SessionHardWare.getUserIndex(assignName);
                SessionInfo info = SessionHardWare.getSessionAttr(userIndex);
                //SessionHardWare.getInfo(assignName, out port);
                GetGateDAQ.Delay((uint)info.sessionIndex, (uint)info.port, GateType.B, ref delay);
                GetGateDAQ.Width((uint)info.sessionIndex, (uint)info.port, GateType.B, ref range);
            }

            double max = stripSeries.add(gatePacket, boardIndex, delay, range);
            return max;
        }

        public void updateAxes(double maxPosValue)                 
        {
            if (newTchart == null)
                return;
            //if (maxPosValue > ConstParameter.ScalePrePage && xPos == 0)
                //newTchart.Axes.Left.SetMinMax(maxPosValue - ConstParameter.ScalePrePage, maxPosValue);
            //{ 
            //    //newTchart.Axes.Left.
            //    newTchart.Axes.Left.Scroll(maxPosValue - ConstParameter.ScalePrePage, true); 
            //}
            if (stripSeries != null)
                stripSeries.updatePicture(maxPosValue);
        }

        public void updateAxes(double maxPosValue, YAxesType yaxestype)     //用于更新坐标轴
        {
            if (newTchart == null)
                return;

            if (yaxestype == YAxesType.Distance)    //距离显示模式，ScalePrePage(mm)一个页面
            {
                if (maxPosValue < ConstParameter.ScalePrePage)
                    maxPosValue = ConstParameter.ScalePrePage;
                newTchart.Axes.Left.SetMinMax(maxPosValue - ConstParameter.ScalePrePage, maxPosValue);  //显示范围滚动
            }
            else if (yaxestype == YAxesType.Angle)  //角度显示模式，
            {
                int scanangle = (int)(maxPosValue / (ConstParameter.PipeDiameter / 2) * (180 / 3.14)); //将距离maxPosValue转化为转动的角度
                //int angleperpage = (int)(ConstParameter.ScalePrePage / (ConstParameter.PipeDiameter / 2) * (180 / 3.14));//ScalePrePage对应的距离转化为角度显示在坐标轴上
                int angleperpage = 31;
                if (scanangle < angleperpage)
                    scanangle = angleperpage;
                newTchart.Axes.Left.SetMinMax(scanangle - angleperpage, scanangle);//显示范围滚动                     
            }

        }

        /// <summary>
        /// to identify weather the port is matched with this calibStripColumn 
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool isMatched(int port)
        {
            int upPort;
            SessionHardWare.getInfo(assignName, out upPort);
            if (upPort == -1)
                return false;
            if (upPort == port)
                return true;
            else
                return false;
        }

        public double getMaxValueofLine(double StartPos, double EndPos)
        {
            if (stripSeries == null)
                return 0;
            return stripSeries.getMaxValueofLine(StartPos,EndPos);
        }
    }

    [Serializable]
    public class calibTofdColumn
    {
        private TChart newTchart;
        private TextBox textBox;
        private System.Windows.Forms.Panel subPanle;
        private System.Windows.Forms.Panel textPanle;
        private System.Windows.Forms.Panel showPanle;
        private StripSeries tofdSeries;
        private calibStripType type;
        public string assignName;

        public calibTofdColumn(System.Windows.Forms.Panel panel, float widthPos, float subpanelwidth, string assignName, calibStripType type)
        {
            this.type = type;
            this.assignName = assignName;
            initControls(panel, widthPos, subpanelwidth);
            tofdSeries = new StripSeries(this.newTchart);
        }

        private void initControls(System.Windows.Forms.Panel panel, float widthPos, float subpanelwidth)
        {
            subPanle = new System.Windows.Forms.Panel();
            subPanle.Parent = panel;
            subPanle.Width = (int)subpanelwidth;
            subPanle.Height = panel.Height;
            subPanle.Location = new Point((int)widthPos, panel.Location.Y);

            textPanle = new System.Windows.Forms.Panel();
            textPanle.Parent = subPanle;
            textPanle.Width = (int)subpanelwidth;
            textPanle.Height = (int)(panel.Height * 0.04);
            textPanle.Location = new Point(0, panel.Location.Y);

            showPanle = new System.Windows.Forms.Panel();
            showPanle.Parent = subPanle;
            showPanle.Width = (int)subpanelwidth;
            int i = showPanle.Width;
            showPanle.Height = panel.Height - textPanle.Height;
            showPanle.Location = new Point(0, textPanle.Location.Y + textPanle.Height);

            textBox = new TextBox();
            textBox.Multiline = false;
            textBox.ReadOnly = true;
            textBox.BackColor = Color.FromArgb(192, 255, 192);
            textBox.BackColor = Color.White;
            textBox.Font = new Font("微软雅黑", 10f);
            textBox.Text = assignName;
            textBox.Parent = textPanle;
            textBox.Dock = DockStyle.Fill;
            textBox.Margin = new Padding(0);
            textBox.TextAlign = HorizontalAlignment.Center;

            newTchart = new TChart();
            newTchart.Axes.Left.Minimum = 0;
            newTchart.Axes.Bottom.Minimum = 0;
            newTchart.Aspect.View3D = false;
            newTchart.Header.Visible = false;

            newTchart.BackColor = Color.White;
            newTchart.Parent = showPanle;
            newTchart.Dock = DockStyle.Fill;
            //newTchart.Height = showPanle.Height;
            //newTchart.Width = showPanle.Width;
            newTchart.Legend.Visible = false;
            newTchart.Walls.Visible = false;
            newTchart.Zoom.Allow = false;
            newTchart.Panel.MarginUnits = PanelMarginUnits.Percent;
            newTchart.Panel.MarginTop = 0D;
            newTchart.Panel.MarginBottom = 0D;
            newTchart.Panel.MarginRight = 0D;
            newTchart.Panel.MarginLeft = 0D;
            newTchart.Margin = new Padding(0);
            newTchart.Header.Visible = false;
            newTchart.Axes.Bottom.SetMinMax(0, 100);
            newTchart.Axes.Bottom.Increment = (30 - 20) / 10;
            newTchart.Axes.Bottom.Labels.Visible = false;
            newTchart.Axes.Bottom.Visible = false;
            newTchart.Axes.Bottom.Grid.Visible = false;
            newTchart.Axes.Left.Grid.Visible = false;
            newTchart.Axes.Left.SetMinMax(0, 200);
            newTchart.Axes.Left.Inverted = true;
            if (widthPos != 0)
                newTchart.Axes.Left.Visible = false;
            newTchart.Refresh();
        }

        public void clearSets()
        {
            if (newTchart != null)
            {
                for (int i = newTchart.Series.Count - 1; i >= 0; i--)
                    newTchart.Series.RemoveAt(i);
            }
            if (textBox != null) textBox = null;
            if (textPanle != null) textPanle = null;
            if (newTchart != null) newTchart = null;
            if (tofdSeries != null) tofdSeries = null;
            if (showPanle != null) showPanle = null;
            if (subPanle != null) subPanle = null;
        }

        public void clearViews()
        {
            if (tofdSeries != null)
                tofdSeries.clear();
        }

        public double add(GatePacket gatePacket, int boardIndex)
        {
            return 0;
        }

        public void updateAxes(double maxPosValue)
        {
            if (newTchart == null)
                return;
            if (tofdSeries != null)
                tofdSeries.updatePicture(maxPosValue);
        }

        /// <summary>
        /// to identify weather the port is matched with this calibTofdColumn
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool isMatched(int port)
        {
            int upPort;
            SessionHardWare.getInfo(assignName, out upPort);
            if (upPort == -1)
                return false;
            if (upPort == port)
                return true;
            else
                return false;
        }

        public double getMaxValueofLine()
        {
            //if (tofdSeries == null)
            //    return 0;
            //return tofdSeries.getMaxValueofLine();
            return 0;
        }
    }

    public class calibInfoData
    {
        public string name;
        public string sessionName;
        public string area;
        public int type;
        public double axialStartPos;
        public double axialEndPos;
        public double circleStartPos;
        public double circleEndPos;     
        public calibInfoData()
        {
            name = "";
            sessionName = "";
            //area = hurtArea.FILL;
            area = "";
            //type = hurtType.V;
            type = 0;
            axialStartPos = 0.0;
            axialEndPos = 0.0;
            circleStartPos = 0.0;
            circleEndPos = 0.0;
        }

        public void setCalibInfoData(SessionInfo sessionInfo, Defect defect)
        {
            this.sessionName = sessionInfo.myHardInfo.AssignedName;
            this.area = sessionInfo.zonename;
            this.type = sessionInfo.type;
            this.axialStartPos = defect.beginAxial;
            this.axialEndPos = defect.endAxial; 
            this.circleStartPos =  defect.beginRadio;
            this.circleEndPos = defect.endRadio;
            //
        }
    }

    public enum calibStripType
    { 
        PAstrip,
        TOFDmap,
        Couple,
        Scale
    }

    public enum hurtArea
    { 
        FILL,
        HP,
        LCP,
        ROOT
    }

    public enum hurtType
    { 
        V,
        X
    }
}
