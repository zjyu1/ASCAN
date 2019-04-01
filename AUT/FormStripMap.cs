using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using Steema.TeeChart;
using System.IO;
using Ascan;
using System.Threading;
using System.Collections;
using autsql;

namespace AUT
{
    public partial class FormStripMap : FormMeasurementMap
    {
        private const int MergeNum = 6;

        private System.Windows.Forms.Panel panelTotal;

        private StripColumn scaleColumn; //A column for scale
        private List<StripColumn> mapStripColumns; //Columns for strip
        private List<PictureColumn> pictureBScanColumns; //Columns for BScan
        private List<PictureColumn> pictureTOFDColumns;  //Columns for TOFD
        private List<PictureColumn> mapMergeColumns;  //Columns for merge
        private List<RowData> rowDatasList;
        private DetectionMode detectionmode;
        private List<SessionInfo> sessionsInfo;
        //private List<batchData> batchDataList;
        private OderInfo oderInfo;
        private BatchInfo currentBatchInfo;
        private List<RecordInfo> origRecordList;
        private List<RecordInfo> newRecordList;
        private double maxPosValue; //record the max pos value(left axe) of all the teecharts
        private int lastvScrollBarValue;//record last vScrollBarValue,used to update vScrollBarValue in specific step
        private double range, speed;
        int dir;

        private System.Timers.Timer timer = new System.Timers.Timer(100);
        private delegate void updateDelegate();
        private updateDelegate updateCallBack;
        Motion motion;
        public FormStripMap(MainForm mainForm)
        {
            InitializeComponent();
            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            mapStripColumns = new List<StripColumn>();
            pictureBScanColumns = new List<PictureColumn>();
            pictureTOFDColumns = new List<PictureColumn>();
            mapMergeColumns = new List<PictureColumn>(MergeNum);
            rowDatasList = new List<RowData>();

            oderInfo = FormList.FormBatch.od;
            newRecordList = new List<RecordInfo>();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            maxPosValue = 0;
            lastvScrollBarValue = 0;
            isSaved = true;

            timer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateAUT);
            batchDataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(batchDataGridView_EditingControlShowing);
            //batchDataGridView.CellContentClick += new DataGridViewCellEventHandler(batchDataGridView_CellContentClick);

            detectionmode = mainForm.detectionmode;
            sessionsInfo = mainForm.sessionsInfo;
            motion = MainForm.motion;
            dir = detectionmode.direction; range = detectionmode.detdistance; speed = detectionmode.detvelocity * 66;
        }

        /**Set the size and position of controls.*/
        private void FormStripMap_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);

            mainArea.SplitterDistance = mainArea.Width - 20;
            mainArea.IsSplitterFixed = true;
            mainArea.Panel2Collapsed = false;

            vScrollBar = new VScrollBar();
            vScrollBar.Parent = this.mainArea.Panel2;
            vScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            //vScrollBar.Width = 20;
            vScrollBar.Visible = true;
            vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(vScrollBar_ValueChanged);

            panelTotal = new System.Windows.Forms.Panel();
            //panelTotal.Parent = this.mainArea.Panel1;
            panelTotal.Parent = this.splitContainer1.Panel2;
            panelTotal.Dock = DockStyle.Fill;
            panelTotal.BackColor = Color.White;

            batchDataGridView.Width = splitContainer1.Panel1.Width;
            this.weldColumn.Width = (int)batchDataGridView.Width * 3 / 10;
            this.measureNumColumn.Width = (int)batchDataGridView.Width * 4 / 10;
            this.resultColumn.Width = (int)batchDataGridView.Width * 3 / 10;
            autoNamecheckBox.Checked = true;

            productComboBox.Items.Add("Pro1");
            productComboBox.Items.Add("Pro");
            settingComboBox.Items.Add("MSet1");
            settingComboBox.Items.Add("MSet2");

            //if (oderInfo == null || oderInfo.batchList == null)
            //{
            //    MessageBox.Show("没有可选的批次，请在批次管理面板中新建或打开一个批次！");
            //    return;
            //}

            foreach (BatchInfo batchinfo in oderInfo.batchList)
            {
                batchComboBox.Items.Add(batchinfo.name);
            }
        }

        private void FormStripMap_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.Visible == true)
            //{
            //    foreach (BatchInfo batchinfo in oderInfo.batchList)
            //    {
            //        batchComboBox.Items.Add(batchinfo.name);
            //    }
            //}
        }

        private void initScroll()
        {
            maxPosValue = 0;
            mainArea.Panel2Collapsed = false;

            vScrollBar.Minimum = 0;
            vScrollBar.Maximum = ConstParameter.ScalePrePage;
            vScrollBar.Value = 0;
            vScrollBar.SmallChange = 10;
            vScrollBar.LargeChange = vScrollBar.Maximum;
            //updateAxes(ConstParameter.ScalePrePage);
        }

        public void clearSets()
        {
            panelTotal.Controls.Clear();            //清除对所有子控件的控制
            if (scaleColumn != null)
            {
                scaleColumn.clearSets();
                scaleColumn = null;
            }

            if (mapStripColumns != null)
            {
                for (int i = mapStripColumns.Count - 1; i >= 0; i--)
                {
                    mapStripColumns[i].clearSets(); //删除所有子类引用
                    if (mapStripColumns[i] != null)
                        mapStripColumns[i] = null;
                    mapStripColumns.RemoveAt(i);
                }
            }

            if (pictureBScanColumns != null)
            {
                for (int i = pictureBScanColumns.Count - 1; i >= 0; i--)
                {
                    pictureBScanColumns[i].clearSets();
                    if (pictureBScanColumns[i] != null)
                        pictureBScanColumns[i] = null;
                    pictureBScanColumns.RemoveAt(i);
                }
            }

            if (pictureTOFDColumns != null)
            {
                for (int i = pictureTOFDColumns.Count - 1; i >= 0; i--)
                {
                    pictureTOFDColumns[i].clearSets();
                    if (pictureTOFDColumns[i] != null)
                        pictureTOFDColumns[i] = null;
                    pictureTOFDColumns.RemoveAt(i);
                }
            }

            if (mapMergeColumns != null)
            {
                for (int i = mapMergeColumns.Count - 1; i >= 0; i--)
                {
                    mapMergeColumns[i].clearSets();
                    if (mapMergeColumns[i] != null)
                        mapMergeColumns[i] = null;
                    mapMergeColumns.RemoveAt(i);
                }
            }

            GC.Collect();
        }

        public void clearViews()
        {
            if (mapStripColumns != null)
                for (int i = mapStripColumns.Count - 1; i >= 0; i--)
                    mapStripColumns[i].clearViews();

            if (pictureBScanColumns != null)
                for (int i = pictureBScanColumns.Count - 1; i >= 0; i--)
                    pictureBScanColumns[i].clearViews();

            if (pictureTOFDColumns != null)
                for (int i = pictureTOFDColumns.Count - 1; i >= 0; i--)
                    pictureTOFDColumns[i].clearViews();

            if (mapMergeColumns != null)
                for (int i = mapMergeColumns.Count - 1; i >= 0; i--)
                    mapMergeColumns[i].clearViews();

            this.updateAxes(ConstParameter.ScalePrePage + ConstParameter.DistTOFD2PA);
        }

        public override void addPoints(MeasureQueueElement measureQueueElement)
        {
            if (rowDatasList == null || measureQueueElement == null)
                return;

            int boardIndex = measureQueueElement.boardIndex;
            int id = (int)measureQueueElement.gatePacket.head.id;
            int bin = (int)measureQueueElement.gatePacket.head.bin;
            int port = (int)measureQueueElement.gatePacket.head.port;
            Source source;
            double tmpMaxValue;
            switch(id)
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
                    this.clearViews();
                    maxPosValue = 0;
                    this.Invoke(new Action(() =>
                    {      //在主线程上执行委托，目的函数为updateScroll（）
                        initScroll();
                    }));
                }
                else if (bin == (int)DAQ_EVENT.STOP_EVENT)
                {
                    timer.Enabled = false;
                    timer.Stop();
                }
                else
                {
                    //doing nothing
                }
            }
            else if (id == (int)PacketId.couple)
            {
                foreach (PictureColumn mapColumn in mapMergeColumns)
                {
                    if (mapColumn.isMatched(port, source))
                    {
                        tmpMaxValue = mapColumn.add(measureQueueElement.gatePacket, boardIndex);
                        if (tmpMaxValue > maxPosValue)
                        {
                            maxPosValue = tmpMaxValue;
                            //updateAxes(maxPosValue);
                        }
                        isSaved = false;
                    }
                }
            }

            if (source == Source.Error)
                return;

            foreach (StripColumn mapColumn in mapStripColumns)
            {
                if ((bin == (int)DAQ_MEAS_MODE.TOF_PEAK || bin == (int)DAQ_MEAS_MODE.AMP_PERCENT) && mapColumn.isMatched(port, source))
                {
                    tmpMaxValue = mapColumn.add(measureQueueElement.gatePacket, boardIndex);
                    if (tmpMaxValue > maxPosValue)
                    {
                        maxPosValue = tmpMaxValue;
                        //updateAxes(maxPosValue);
                    }

                    isSaved = false;
                }
            }

            foreach (PictureColumn pictureColumn in pictureBScanColumns)
            {
                if (bin == (int)DAQ_MEAS_MODE.GATEIN_DATA && pictureColumn.isMatched(port, source))
                {
                    tmpMaxValue = pictureColumn.add(measureQueueElement.gatePacket, boardIndex);
                    if (tmpMaxValue > maxPosValue)
                    {
                        maxPosValue = tmpMaxValue;
                        //updateAxes(maxPosValue);
                    }

                    isSaved = false;
                }
            }

            foreach (PictureColumn pictureColumn in pictureTOFDColumns)
            {
                if (pictureColumn.isMatched(port, source))
                {
                    tmpMaxValue = pictureColumn.add(measureQueueElement.gatePacket, boardIndex);
                    if (tmpMaxValue > maxPosValue)
                    {
                        maxPosValue = tmpMaxValue;
                        //updateAxes(maxPosValue);
                    }

                    isSaved = false;
                }
            }
        }

        public void updatePicture()
        {
            updateAxes(maxPosValue);
        }

        private void UpdateAUT(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (updateCallBack == null)
                updateCallBack = new updateDelegate(updatePicture);
            this.BeginInvoke(updateCallBack);
        }
        /**Update the show scope of the left axes accroding to the parameter.*/
        private void updateAxes(double curPosValue)
        {
            /*if (curPosValue < ConstParameter.ScalePrePage)
                curPosValue = ConstParameter.ScalePrePage;*/
            if (curPosValue < ConstParameter.DistTOFD2PA)    //wait until running over DistTOFD2PA's distance
                return;
           
             //用于更新滚动条
            //this.Invoke(new Action(() =>
            //{      //在主线程上执行委托，目的函数为updateScroll（）
                updateScroll();
            //}));

            if (scaleColumn != null)
            {
                scaleColumn.updateAxes(curPosValue);                    //用于更新图像
                scaleColumn.updateAxes(curPosValue - ConstParameter.DistTOFD2PA, YAxesType.Distance);    //用于更新竖直轴坐标,可选择为距离模式和角度模式
            }

            foreach (StripColumn mapColumn in mapStripColumns)
                mapColumn.updateAxes(curPosValue);

            foreach (PictureColumn pictureColumn in pictureBScanColumns)
                pictureColumn.updateAxes(curPosValue);

            foreach (PictureColumn pictureColumn in pictureTOFDColumns)
                pictureColumn.updateAxes(curPosValue);

            foreach (PictureColumn mapColumn in mapMergeColumns)
                mapColumn.updateAxes(curPosValue);
        }

        /**Show the scroll when ended.*/
        /*private void updateScroll()
        {
            if (maxPosValue <= 100)
                return;

            mainArea.Panel2Collapsed = false;   //change false to true 
            vScrollBar.Minimum = 0;
            vScrollBar.Maximum = 109;
            vScrollBar.Value = 100;
            updateAxes(maxPosValue);
        }*/

        private void updateScroll()
        {
            if (maxPosValue <= ConstParameter.ScalePrePage + ConstParameter.DistTOFD2PA)
                return;
            else
                vScrollBar.LargeChange = (int)((ConstParameter.ScalePrePage / (maxPosValue - ConstParameter.DistTOFD2PA)) * vScrollBar.Maximum);
        }

        private void vScrollBar_ValueChanged(object sender, ScrollEventArgs e)
        {
            int scaleperpage = ConstParameter.ScalePrePage;
            if (System.Math.Abs(e.NewValue - lastvScrollBarValue) > 10) //滚动条最小步进更新值10，即每改变10，才更新刷图一次
            {
                lastvScrollBarValue = e.NewValue;
                double reshowPosValue = e.NewValue * (maxPosValue - ConstParameter.DistTOFD2PA - scaleperpage) / (vScrollBar.Maximum - vScrollBar.LargeChange) + scaleperpage + ConstParameter.DistTOFD2PA;
                updateAxes(reshowPosValue);
            }
        }

        public override bool isBoardNameInMeasureCorrect()
        {
            int index;
            if ((rowDatasList == null) || (rowDatasList.Count == 0))
                return true;

            foreach (RowData rowData in rowDatasList)
            {
                if (rowData.Activity)
                {
                    index = SessionHardWare.getUserIndex(rowData.Cycle);
                    if (index == -1)
                        return false;
                }
            }
            return true;
        }

        public override void startInspect()
        {
            initScroll();
        }

        public void stopInspect()
        {
            updateScroll();
        }

        //private void creatrowDatasList()
        //{
        //    rowDatasList.Clear();
        //    List<PADetectioninfo> painfolist = detectionmode.painfolist;
        //    List<TOFDDetectioninfo> tofdinfolist = detectionmode.tofdinfolist;
        //    List<CoupleDetectioninfo> coupleinfolist = detectionmode.coupleinfolist;
        //    int sessionNum = painfolist.Count + tofdinfolist.Count + coupleinfolist.Count;
        //    RowData[] rowdataArray = new RowData[sessionNum];
        //    int sortindex;
        //    foreach (PADetectioninfo painfo in painfolist)
        //    {
        //        foreach (SessionInfo session in sessionsInfo)
        //        {
        //            if (session.zonename == painfo.name)
        //            {
        //                if (session.LR == 0)    //L
        //                if (painfo.bscan == true)
        //                {
        //                    RowData newrowdata = new RowData();
        //                    newrowdata.Cycle = session.myHardInfo.AssignedName;
        //                    newrowdata.Source = Source.GateB;
        //                    newrowdata.Mode = Mode.BScan;
        //                    newrowdata.Activity = true;
        //                    //if (session.LR == 0)
        //                    //    sortindex = 
        //                    rowDatasList.Add(newrowdata);
        //                }
        //                if (painfo.strip == true)
        //                {
        //                    RowData newrowdata = new RowData();
        //                    newrowdata.Cycle = session.myHardInfo.AssignedName;
        //                    newrowdata.Source = Source.GateB;
        //                    newrowdata.Mode = Mode.Strip;
        //                    newrowdata.Activity = true;
        //                    rowDatasList.Add(newrowdata);
        //                }
        //                break;
        //            }
        //        }
        //    }

        //    foreach (TOFDDetectioninfo toinfo in tofdinfolist)
        //    {
        //        foreach (SessionInfo session in sessionsInfo)
        //        {
        //            if (session.zonename == toinfo.name)  //tofd has no zonename!
        //            {
        //                RowData newrowdata = new RowData();
        //                newrowdata.Cycle = session.myHardInfo.AssignedName; //tofd have no AssignedName????
        //                newrowdata.Source = Source.GateB;
        //                newrowdata.Mode = Mode.TOFD;
        //                newrowdata.Activity = true;
        //                rowDatasList.Add(newrowdata);
        //                break;
        //            }
        //        }
        //    }

        //    foreach (CoupleDetectioninfo coupleinfo in coupleinfolist)
        //    {
        //        //if (painfo.coupling == true) //coupling is not in PADetectioninfo ,it's in CoupleDetectioninfo
        //        //{
        //        //    RowData newrowdata = new RowData();
        //        //    newrowdata.Cycle = session.myHardInfo.AssignedName;
        //        //    newrowdata.Source = Source.GateB;
        //        //    newrowdata.Mode = Mode.Couple;
        //        //    newrowdata.Activity = true;
        //        //    rowDatasList.Add(newrowdata);
        //        //}
        //    }
        //}

        private void creatrowDatasList()
        {
            rowDatasList.Clear();
            List<PADetectioninfo> painfolist = detectionmode.painfolist;
            List<TOFDDetectioninfo> tofdinfolist = detectionmode.tofdinfolist;
            List<CoupleDetectioninfo> coupleinfolist = detectionmode.coupleinfolist;
            int painfoNum = painfolist.Count;
            for (int i = 0; i < painfoNum; i += 2)  //all L session
            {
                PADetectioninfo painfo = painfolist[i];
                foreach (SessionInfo session in sessionsInfo)
                {
                    if (session.zonename == painfo.name)
                    {
                        if (painfo.bscan == true)
                        {
                            RowData newrowdata = new RowData();
                            newrowdata.Cycle = session.myHardInfo.AssignedName;
                            newrowdata.Source = Source.GateB;
                            newrowdata.Mode = Mode.BScan;
                            newrowdata.Activity = true;
                            rowDatasList.Add(newrowdata);
                        }
                        if (painfo.strip == true)
                        {
                            RowData newrowdata = new RowData();
                            newrowdata.Cycle = session.myHardInfo.AssignedName;
                            newrowdata.Source = Source.GateB;
                            newrowdata.Mode = Mode.Strip;
                            newrowdata.Activity = true;
                            rowDatasList.Add(newrowdata);
                        }
                        break;
                    }
                }
            }

            foreach (TOFDDetectioninfo toinfo in tofdinfolist)  //tofd session
            {
                RowData newrowdata = new RowData();
                newrowdata.Cycle = "0-0"; //tofd have no AssignedName????
                newrowdata.Source = Source.GateB;
                newrowdata.Mode = Mode.TOFD;
                newrowdata.Activity = true;
                rowDatasList.Add(newrowdata);
            }

            for (int i = painfoNum - 1; i > 0; i -= 2)  //all R session
            {
                PADetectioninfo painfo = painfolist[i];
                foreach (SessionInfo session in sessionsInfo)
                {
                    if (session.zonename == painfo.name)
                    {
                        if (painfo.bscan == true)
                        {
                            RowData newrowdata = new RowData();
                            newrowdata.Cycle = session.myHardInfo.AssignedName;
                            newrowdata.Source = Source.GateB;
                            newrowdata.Mode = Mode.BScan;
                            newrowdata.Activity = true;
                            rowDatasList.Add(newrowdata);
                        }
                        if (painfo.strip == true)
                        {
                            RowData newrowdata = new RowData();
                            newrowdata.Cycle = session.myHardInfo.AssignedName;
                            newrowdata.Source = Source.GateB;
                            newrowdata.Mode = Mode.Strip;
                            newrowdata.Activity = true;
                            rowDatasList.Add(newrowdata);
                        }
                        break;
                    }
                }
            }

            foreach (CoupleDetectioninfo coupleinfo in coupleinfolist)
            {
                foreach (SessionInfo session in sessionsInfo)
                {
                    if (session.zonename == coupleinfo.name)
                    {
                        if (coupleinfo.coupling == true)
                        {
                            RowData newrowdata = new RowData();
                            newrowdata.Cycle = session.myHardInfo.AssignedName;
                            newrowdata.Source = Source.GateB;
                            newrowdata.Mode = Mode.Couple;
                            newrowdata.Activity = true;
                            rowDatasList.Add(newrowdata);
                        }
                    }
                }
            }
        }

        /**Called after FormStripSet closed in order to update the strip map.*/
        private void updateStripMap()
        {
            //test();
            int totalNum = 0, stripNum = 0, BScanNum = 0, TOFDNum = 0, coupleNum = 0;

            clearSets();
            totalNum = calculateTotalNums(ref stripNum, ref BScanNum, ref TOFDNum, ref coupleNum);

            if (totalNum == 0)
                return;
            totalNum += 1; //The first column(whose index is 0) is used to show the scale 

            int culNum = stripNum + 2 * (BScanNum + TOFDNum);//pictureWidth = 2 * stripWidth
            float totalWidth = panelTotal.Width;

            float scaleWidth = 30f;
            totalWidth -= 30f;
            float mergeWidth = 0.02f * totalWidth;
            float stripWidth = (totalWidth - mergeWidth * coupleNum) / culNum;
            float pictureWidth = 2 * stripWidth;

            float curPos = 0;

            for (int i = 0; i < totalNum; i++)
            {
                if (i == 0)
                {
                    StripColumn mapDatas = new StripColumn(panelTotal, null, curPos, scaleWidth, MapType.Scale);
                    curPos += scaleWidth;
                    scaleColumn = mapDatas;
                }
                else if (i <= rowDatasList.Count)
                {
                    RowData rowData = rowDatasList[i - 1];

                    if (rowData.Activity)
                    {
                        if (rowData.Mode == Mode.Strip)
                        {
                            StripColumn mapDatas = new StripColumn(panelTotal, rowData, curPos, stripWidth, MapType.Strip);
                            curPos += stripWidth;
                            mapStripColumns.Add(mapDatas);
                        }
                        else if (rowData.Mode == Mode.BScan)
                        {
                            PictureColumn pictureDatas = new PictureColumn(panelTotal, rowData, curPos, pictureWidth, PictureType.BScan);
                            curPos += pictureWidth;
                            pictureBScanColumns.Add(pictureDatas);
                        }
                        else if (rowData.Mode == Mode.TOFD)
                        {
                            PictureColumn pictureDatas = new PictureColumn(panelTotal, rowData, curPos, pictureWidth, PictureType.TOFD);
                            curPos += pictureWidth;
                            pictureTOFDColumns.Add(pictureDatas);
                        }
                        else
                        {
                            PictureColumn mapDatas = new PictureColumn(panelTotal, rowData, curPos, mergeWidth, PictureType.Merge);
                            curPos += mergeWidth;
                            mapMergeColumns.Add(mapDatas);
                        }
                    }
                }
            }
        }

        //Get the number of strip, BScan and TOFD
        private int calculateTotalNums(ref int stripNum, ref int BScanNum, ref int TOFDNum, ref int coupleNum)
        {
            stripNum = 0;
            BScanNum = 0;
            TOFDNum = 0;
            coupleNum = 0;

            if (rowDatasList == null)
                return 0;

            int totalNums = 0;

            foreach (RowData rowData in rowDatasList)
            {
                if (rowData.Activity)
                {
                    totalNums++;

                    if (rowData.Mode == Mode.Strip)
                        stripNum++;
                    else if (rowData.Mode == Mode.BScan)
                        BScanNum++;
                    else if (rowData.Mode == Mode.TOFD)
                        TOFDNum++;
                    else
                        coupleNum++;
                }
            }
            return totalNums;
        }

        private void test()
        {
            for (int i = 0; i < 1; i++)
            {
                RowData newrow = new RowData();
                newrow.Cycle = "L1"; newrow.Activity = true; newrow.Source = Source.GateB; newrow.Mode = Mode.Strip;
                rowDatasList.Add(newrow);
            }
            RowData newrow1 = new RowData();
            newrow1.Cycle = "TOFD"; newrow1.Activity = true; newrow1.Source = Source.GateB; newrow1.Mode = Mode.TOFD;
            rowDatasList.Add(newrow1);
        }

        /**Called after ReadFromXML to update the strip map.*/
        private void rebuildStripMap()
        {
            int totalNum = 0, stripNum = 0, BScanNum = 0, TOFDNum = 0, coupleNum = 0;

            clearSets();
            totalNum = calculateTotalNums(ref stripNum, ref BScanNum, ref TOFDNum, ref coupleNum);

            if (totalNum == 0)
                return;
            totalNum += 1; //The first column(whose index is 0) is used to show the scale 

            int culNum = stripNum + 2 * (BScanNum + TOFDNum);//pictureWidth = 2 * stripWidth
            float totalWidth = panelTotal.Width;

            float scaleWidth = 30f;
            totalWidth -= 30f;
            float mergeWidth = 0.02f * totalWidth;
            float stripWidth = (totalWidth - mergeWidth * coupleNum) / culNum;
            float pictureWidth = 2 * stripWidth;
            float curPos = 0;
            int stripIndex = 0, BScanIndex = 0, TOFDIndex = 0;

            if (scaleColumn != null)
            {
                scaleColumn.rebuildNonSeriealizedDatas(panelTotal, curPos, scaleWidth);
                curPos += scaleWidth;
            }

            foreach (RowData rowData in rowDatasList)
            {
                if (rowData.Activity)
                {
                    if (rowData.Mode == Mode.Strip && stripIndex < mapStripColumns.Count)
                    {
                        mapStripColumns[stripIndex].rebuildNonSeriealizedDatas(panelTotal, curPos, stripWidth);
                        curPos += stripWidth;
                        stripIndex++;
                    }
                    else if (rowData.Mode == Mode.BScan && BScanIndex < pictureBScanColumns.Count)
                    {
                        pictureBScanColumns[BScanIndex].rebuildNonSeriealizedDatas(panelTotal, curPos, pictureWidth);
                        curPos += pictureWidth;
                        BScanIndex++;
                    }
                    else if (rowData.Mode == Mode.TOFD && TOFDIndex < pictureTOFDColumns.Count)
                    {
                        pictureTOFDColumns[TOFDIndex].rebuildNonSeriealizedDatas(panelTotal, curPos, pictureWidth);
                        curPos += pictureWidth;
                        TOFDIndex++;
                    }
                }
            }

            /*foreach (SerieColumn mapColumn in mapMergeColumns)
            {
                mapColumn.rebuildNonSeriealizedDatas(tablePanel, columnIndex);
                columnIndex++;
            }*/
        }

        private void groupToolStrip_Click(object sender, EventArgs e)
        {
            //FormStripSet formStripSet = FormStripSet.CreateInstance(rowDatasList);
            //formStripSet.ShowDialog();
            //updateStripMap();
            //initScroll();
            //creatrowDatasList();
            //updateStripMap();
            //initScroll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            rowDatasList = null;
            updateScroll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            initScroll();
        }

        private void toolStripButtonclean_Click(object sender, EventArgs e)
        {
            this.clearViews();
            initScroll();
        }

        private void openToolStrip_Click(object sender, EventArgs e)
        {
            bool loadResult;
            string fileName;

            if (!isSaved)
            {
                DialogResult result = MessageShow.showSelecting("Map datas are not saved and open files will clear these datas. Do you want to continue?",
                    "融合图未保存，打开文件将会清空数据。是否继续?");
                if (result == DialogResult.No)
                    return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            string filePath = Application.StartupPath + @"\MeasurementMap";
            openFileDialog1.Filter = "mmp文件(*.mmp)|*.mmp|所有文件(*.*)|*.*";

            if (!Directory.Exists(filePath))
            {
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch
                {
                    filePath = Application.StartupPath;
                }
            }
            openFileDialog1.InitialDirectory = filePath;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                clearSets();
                loadResult = ReadFromXML(fileName);
                if (!loadResult)
                {
                    MessageShow.show("Fail to load the datas, please check.", "数据加载失败，请检查数据源。");
                    return;
                }

                rebuildStripMap();
                updateScroll();
            }
            isSaved = false;
        }

        private void saveToolStrip_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filePath = Application.StartupPath + @"\MeasurementMap";
            if (filePath.IndexOf('\\') < 0 && filePath.IndexOf('/') < 0 || filePath.StartsWith(":"))
            {
                MessageShow.show("Wrong format of path!", "路径格式错误！");
                return;
            }
            string str = Directory.GetDirectoryRoot(filePath);
            //str = System.IO.Path.GetPathRoot(Path.GetFullPath( filePath));
            if (!Directory.Exists(str))
            {
                MessageShow.show(str + "the director root doesn't exist, please change the path!",
                    str + "该盘符不存在，请选择其他保存路径！");
                return;
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            saveFileDialog1.InitialDirectory = filePath;
            saveFileDialog1.Filter = "mmp文件(*.mmp)|*.mmp|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //writeToXML(saveFileDialog1.FileName);
                writeRawDataToXML(saveFileDialog1.FileName);
            }
            isSaved = true;
        }

        private bool ReadFromXML(string file)
        {
            scaleColumn = (StripColumn)SystemConfig.ReadBase64Data(file, "scaleColumn");
            mapStripColumns = (List<StripColumn>)SystemConfig.ReadBase64Data(file, "mapStripColumns");
            pictureBScanColumns = (List<PictureColumn>)SystemConfig.ReadBase64Data(file, "pictureBScanColumns");
            pictureTOFDColumns = (List<PictureColumn>)SystemConfig.ReadBase64Data(file, "pictureTOFDColumns");
            mapMergeColumns = (List<PictureColumn>)SystemConfig.ReadBase64Data(file, "mapMergeColumns");
            rowDatasList = (List<RowData>)SystemConfig.ReadBase64Data(file, "rowDatasList");
            maxPosValue = SystemConfig.GetConfigData(file, "maxPosValue", 0.0);

            if (scaleColumn == null || mapStripColumns == null || pictureBScanColumns == null || pictureTOFDColumns == null
                || mapMergeColumns == null || rowDatasList == null)
                return false;
            return true;
        }

        private void writeToXML(string file)
        {
            string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
            SystemConfig.WriteConfigData(file, "date", date);
            SystemConfig.WriteBase64Data(file, "scaleColumn", scaleColumn);
            SystemConfig.WriteBase64Data(file, "mapStripColumns", mapStripColumns);
            SystemConfig.WriteBase64Data(file, "pictureBScanColumns", pictureBScanColumns);
            SystemConfig.WriteBase64Data(file, "pictureTOFDColumns", pictureTOFDColumns);
            SystemConfig.WriteBase64Data(file, "mapMergeColumns", mapMergeColumns);
            SystemConfig.WriteBase64Data(file, "rowDatasList", rowDatasList);
            SystemConfig.WriteConfigData(file, "maxPosValue", maxPosValue.ToString());
        }

        private void writeRawDataToXML(string file)
        {
            string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
            SystemConfig.WriteConfigData(file, "date", date);
            SystemConfig.WriteBase64Data(file, "rowDatasList", rowDatasList);

            double[] rawDataAmp = null;
            double[] rawDataTof = null;
            double PosInc = 1;

            Hashtable stripRawDataHashtable = new Hashtable();   //use Hashtable to store 
            Hashtable bscanRawDataHashtable = new Hashtable();
            Hashtable tofdRawDataHashtable = new Hashtable();
            Hashtable mergeRawDataHashtable = new Hashtable();

            foreach (StripColumn stripcolum in mapStripColumns)
            {
                string assignName = stripcolum.rowData.Cycle;
                stripcolum.baseSeries.getRawData(ref rawDataAmp, ref rawDataTof, ref PosInc);

                double delay = 0;
                double range = 0;
                double[] rawDataAmpCopy = new double[(int)(maxPosValue/PosInc)];
                double[] rawDataTofCopy = new double[(int)(maxPosValue / PosInc)];
                Array.Copy(rawDataAmp, rawDataAmpCopy, rawDataAmpCopy.Length);
                Array.Copy(rawDataTof, rawDataTofCopy, rawDataTofCopy.Length);

                RowData rowData = stripcolum.rowData;
                int userIndex = SessionHardWare.getUserIndex(rowData.Cycle);
                SessionInfo info = SessionHardWare.getSessionAttr(userIndex);
                GetGateDAQ.Delay((uint)info.sessionIndex, (uint)info.port, (GateType)rowData.Source, ref delay);
                GetGateDAQ.Width((uint)info.sessionIndex, (uint)info.port, (GateType)rowData.Source, ref range);

                rawDataInOneSession rawdataonesession = new rawDataInOneSession(assignName, rawDataAmpCopy, rawDataTofCopy, delay, range);
                stripRawDataHashtable.Add(assignName, rawdataonesession);
            }

            foreach (PictureColumn bscancolumn in pictureBScanColumns)
            {
                string assignName = bscancolumn.rowData.Cycle;
                bscancolumn.baseSeries.getRawData(ref rawDataAmp, ref rawDataTof, ref PosInc);

                double[] rawDataAmpCopy = new double[(int)(maxPosValue / PosInc) * ConstParameter.BscanPointNumPrePacket];
                Array.Copy(rawDataAmp, rawDataAmpCopy, rawDataAmpCopy.Length);

                rawDataInOneSession rawdataonesession = new rawDataInOneSession(assignName, rawDataAmpCopy, rawDataTof);
                bscanRawDataHashtable.Add(assignName, rawdataonesession);
            }

            foreach (PictureColumn tofdcolumn in pictureTOFDColumns)
            {
                string assignName = tofdcolumn.rowData.Cycle;
                tofdcolumn.baseSeries.getRawData(ref rawDataAmp, ref rawDataTof, ref PosInc);

                double[] rawDataAmpCopy = new double[(int)(maxPosValue / PosInc) * ConstParameter.TOFDPointNumPrePacket];
                Array.Copy(rawDataAmp, rawDataAmpCopy, rawDataAmpCopy.Length);

                rawDataInOneSession rawdataonesession = new rawDataInOneSession(assignName, rawDataAmpCopy, rawDataTof);
                tofdRawDataHashtable.Add(assignName, rawdataonesession);
            }

            foreach (PictureColumn mergecolumn in mapMergeColumns)
            {
                string assignName = mergecolumn.rowData.Cycle;
                mergecolumn.baseSeries.getRawData(ref rawDataAmp, ref rawDataTof, ref PosInc);

                double[] rawDataAmpCopy = new double[(int)(maxPosValue / PosInc)];
                Array.Copy(rawDataAmp, rawDataAmpCopy, rawDataAmpCopy.Length);

                rawDataInOneSession rawdataonesession = new rawDataInOneSession(assignName, rawDataAmpCopy, rawDataTof);
                mergeRawDataHashtable.Add(assignName, rawdataonesession);
            }

            SystemConfig.WriteBase64Data(file, "stripRawDataHashtable", stripRawDataHashtable);
            SystemConfig.WriteBase64Data(file, "bscanRawDataHashtable", bscanRawDataHashtable);
            SystemConfig.WriteBase64Data(file, "tofdRawDataHashtable", tofdRawDataHashtable);
            SystemConfig.WriteBase64Data(file, "mergeRawDataHashtable", mergeRawDataHashtable);
            MessageBox.Show("数据保存成功");      
        }

        private void saveToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //add newRecordList to origRecordList
            foreach (RecordInfo record in newRecordList)
            {
                origRecordList.Add(record);
            }
            OderInfo.ReSync(oderInfo);
        }

        private void batchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = batchComboBox.SelectedIndex;
            currentBatchInfo = oderInfo.batchList[index];
            //currentBatchInfo.dt = dataType.modify;

            origRecordList = currentBatchInfo.recordList;
            //newRecordList = currentBatchInfo.recordList;
            batchDataGridView.Rows.Clear();
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentBatchInfo.productTypeFullPath = @"D:\svn\USTMDI\Ascan\bin\Debug\LoadData\0617\product.xml";
        }

        private void settingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentBatchInfo.productTypeFullPath = @"D:\svn\USTMDI\Ascan\bin\Debug\LoadData\0617\DetectionMode.xml";
            creatrowDatasList();
            updateStripMap();
            initScroll();
        }

        private void autoNamecheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            RecordInfo recordInfo = new RecordInfo();
            if (autoNamecheckBox.Checked == true)
            {
                if (newRecordList.Count == 0)
                {
                    recordInfo.weldNo = 1;
                    recordInfo.num = 1;
                }
                else
                {
                    recordInfo.weldNo = newRecordList[newRecordList.Count - 1].weldNo;    //equals to last batchData
                    recordInfo.num = newRecordList[newRecordList.Count - 1].num + 1;
                }
                recordInfo.dt = dataType.add;
                recordInfo.batchName = currentBatchInfo.name;
                newRecordList.Add(recordInfo);
                batchDataGridView.Rows.Add(new object[] { recordInfo.weldNo, recordInfo.num });
            }
            else if (autoNamecheckBox.Checked == false)
            {
                recordInfo.dt = dataType.add;
                recordInfo.batchName = currentBatchInfo.name;
                newRecordList.Add(recordInfo);
                batchDataGridView.Rows.Add(new object[] { null, null});
            }
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (newRecordList.Count == 0)
                return;
            newRecordList.RemoveAt(newRecordList.Count - 1);
            batchDataGridView.Rows.RemoveAt(batchDataGridView.Rows.Count - 1);
        }

        /// <summary>
        /// edit event of batchDataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void batchDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (autoNamecheckBox.Checked == true)
            {
                if (dgv.CurrentCell.ColumnIndex == 0 && dgv.CurrentCell.RowIndex == newRecordList.Count - 1)
                {
                    //when the last WeldNumChanged
                    (e.Control as TextBox).TextChanged += new EventHandler(batch_lastWeldNumChanged);
                }
                if (dgv.CurrentCell.ColumnIndex == 0 && dgv.CurrentCell.RowIndex != newRecordList.Count - 1)
                {
                    //when the front WeldNumChanged
                    (e.Control as TextBox).TextChanged += new EventHandler(batch_frontWeldNumChanged);
                }
            }
            else if(autoNamecheckBox.Checked == false)
            {
                if (dgv.CurrentCell.ColumnIndex != 2)
                    (e.Control as TextBox).TextChanged += new EventHandler(anyCellchanged);
            }

            if(dgv.CurrentCell.ColumnIndex == 2)
                (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(resultComboxChanged);
        }
        /// <summary>
        /// button_click event of batchDataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void batchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;

                if (dgv.CurrentCell.ColumnIndex == 2)
                {
                    //batch_ResultClick();
                }
            }
        }

        private void batch_lastWeldNumChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.Leave += new EventHandler(batch_lastWeldNum_Leave);
            int id = Convert.ToInt32(textbox.Text);
            bool isweldNumberExist = false;
            foreach (RecordInfo recordinfo in newRecordList)
            {
                if (recordinfo.weldNo == id)
                {
                    isweldNumberExist = true;
                    break;
                }       
            }
            if (isweldNumberExist == false)
            {
                newRecordList[newRecordList.Count - 1].weldNo = id;
                newRecordList[newRecordList.Count - 1].num = 1;
                batchDataGridView.Rows[batchDataGridView.Rows.Count - 1].Cells[0].Value = id;
                batchDataGridView.Rows[batchDataGridView.Rows.Count - 1].Cells[1].Value = 1;
            }
        }

        private void batch_lastWeldNum_Leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.TextChanged -= new EventHandler(batch_lastWeldNumChanged);
        }

        private void batch_frontWeldNumChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.Leave += new EventHandler(batch_frontWeldNum_Leave);
            int index = batchDataGridView.CurrentCell.RowIndex;
            int newid = Convert.ToInt32(textbox.Text);
            int lastid = newRecordList[index].weldNo;
            if (newid == lastid)
                return;
            for (int i = 0; i < newRecordList.Count; i++)
            {
                if (newRecordList[i].weldNo == lastid) //find the same weldnumber,and change it to the same new weldNumber
                {
                    newRecordList[i].weldNo = newid;
                    batchDataGridView.Rows[i].Cells[0].Value = newid;
                }
            }
        }

        private void batch_frontWeldNum_Leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.TextChanged -= new EventHandler(batch_frontWeldNumChanged);
        }

        private void anyCellchanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.Leave += new EventHandler(anyCell_Leave);
            int changedValue = Convert.ToInt32(textbox.Text);
            int rowsIndex = batchDataGridView.CurrentCell.RowIndex;
            int columnsIndex = batchDataGridView.CurrentCell.ColumnIndex;
            if (columnsIndex == 0)
                newRecordList[rowsIndex].weldNo = changedValue;
            if(columnsIndex == 1)
                newRecordList[rowsIndex].num = changedValue;
        }

        private void anyCell_Leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.TextChanged -= new EventHandler(anyCellchanged);
        }

        //private void batch_ResultClick()
        //{
        //    string dataPath = batch_ChooseResult();
        //    if (dataPath == null)
        //        return;
        //    int index = batchDataGridView.CurrentCell.RowIndex;
        //    batchDataList[index].rawDadaPath = dataPath;
        //    batchDataGridView.Rows[index].Cells[2].Value = "已保存";
        //}

        private void resultComboxChanged(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            combox.Leave += new EventHandler(resultCombox_Leave);
            int rowsIndex = batchDataGridView.CurrentCell.RowIndex;
            if (combox.SelectedIndex == 0)
                newRecordList[rowsIndex].result = "好";
            else
                newRecordList[rowsIndex].result = "差";
        }

        private void resultCombox_Leave(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            combox.SelectedIndexChanged -= new EventHandler(resultComboxChanged);
        }

        private string batch_ChooseResult()
        {
            string fileName;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string filePath = Application.StartupPath + @"\MeasurementMap";
            openFileDialog1.Filter = "mmp文件(*.mmp)|*.mmp|所有文件(*.*)|*.*";

            if (!Directory.Exists(filePath))
            {
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch
                {
                    filePath = Application.StartupPath;
                }
            }
            openFileDialog1.InitialDirectory = filePath;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                return fileName;
            }

            return null;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (newRecordList.Count == 0)
            {
                MessageBox.Show("请先插入一条记录");
                return;
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filePath = Application.StartupPath + @"\MeasurementMap";
            if (filePath.IndexOf('\\') < 0 && filePath.IndexOf('/') < 0 || filePath.StartsWith(":"))
            {
                MessageShow.show("Wrong format of path!", "路径格式错误！");
                return;
            }
            string str = Directory.GetDirectoryRoot(filePath);
            //str = System.IO.Path.GetPathRoot(Path.GetFullPath( filePath));
            if (!Directory.Exists(str))
            {
                MessageShow.show(str + "the director root doesn't exist, please change the path!",
                    str + "该盘符不存在，请选择其他保存路径！");
                return;
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            saveFileDialog1.InitialDirectory = filePath;
            saveFileDialog1.Filter = "mmp文件(*.mmp)|*.mmp|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //writeToXML(saveFileDialog1.FileName);
                writeRawDataToXML(saveFileDialog1.FileName);
            }

            newRecordList[newRecordList.Count - 1].fileFullPath = saveFileDialog1.FileName;
        }

        private void toolStripButtontest_Click(object sender, EventArgs e)
        {
            motion.Go((int)detectionmode.direction, (int)detectionmode.detdistance, (int)detectionmode.detvelocity * 66);
            System.Threading.Thread.Sleep(300);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            motion.Go((int)detectionmode.direction, (int)detectionmode.detdistance, (int)detectionmode.detvelocity * 66);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            motion.Stop();
            motion.SetStopIO();
        }

        private void batchComboBox_DropDown(object sender, EventArgs e)
        {
            
            batchComboBox.Items.Clear();
            oderInfo = FormList.FormBatch.od;
             foreach (BatchInfo batchinfo in oderInfo.batchList)
             {
                 batchComboBox.Items.Add(batchinfo.name);
             }           
        }

    }

    [Serializable]
    public class StripColumn
    {
        [NonSerialized] private TChart newTchart;
        [NonSerialized] private TextBox textBox;
        [NonSerialized] private System.Windows.Forms.Panel subPanle;
        [NonSerialized] private System.Windows.Forms.Panel textPanle;
        [NonSerialized] private System.Windows.Forms.Panel showPanle;

        public BaseSeries baseSeries;
        private MapType type;
        public RowData rowData;

        private double delay;
        private double range;

        public StripColumn(System.Windows.Forms.Panel panel, RowData rowData, float curPos, float width, MapType type)
        {
            this.type = type;
            this.rowData = rowData;

            initControls(panel, curPos, width);

            switch (this.type)
            {
                case MapType.Strip:
                    baseSeries = new StripSeries(this.newTchart);
                    break;
                case MapType.Scale:
                    baseSeries = null;
                    break;
            }
        }

        private void initControls(System.Windows.Forms.Panel panel, float curPos, float width)
        {
            subPanle = new System.Windows.Forms.Panel();
            subPanle.Parent = panel;
            subPanle.Width = (int)width;
            subPanle.Height = panel.Height;
            subPanle.Location = new Point((int)curPos, panel.Location.Y);

            textPanle = new System.Windows.Forms.Panel();
            textPanle.Parent = subPanle;
            textPanle.Width = (int)width;
            textPanle.Height = (int)(panel.Height * 0.04);
            textPanle.Location = new Point(0, panel.Location.Y);

            showPanle = new System.Windows.Forms.Panel();
            showPanle.Parent = subPanle;
            showPanle.Width = (int)width;
            int i = showPanle.Width;
            showPanle.Height = panel.Height - textPanle.Height;
            showPanle.Location = new Point(0, textPanle.Location.Y + textPanle.Height);

            textBox = new TextBox();
            textBox.Multiline = false;
            textBox.ReadOnly = true;
            textBox.BackColor = Color.FromArgb(192, 255, 192);
            textBox.BackColor = Color.White;
            textBox.Font = new Font("微软雅黑", 10f);
            if (rowData == null)
                textBox.Text = "";
            else
                textBox.Text = rowData.Cycle;
            textBox.Parent = textPanle;
            textBox.Dock = DockStyle.Fill;
            textBox.Margin = new Padding(0);
            textBox.TextAlign = HorizontalAlignment.Center;
            if (type == MapType.Scale)
                textBox.Visible = false;

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
            //newTchart.Zoom.Allow = false;
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
            newTchart.Axes.Bottom.Visible = true;
            newTchart.Axes.Bottom.Grid.Visible = false;
            newTchart.Axes.Left.Grid.Visible = false;
            newTchart.Axes.Left.SetMinMax(0, 200);
            newTchart.Axes.Left.Inverted = true;

            switch (this.type)
            {
                case MapType.Strip:
                    {
                        newTchart.Zoom.Allow = false;
                        newTchart.Axes.Left.Visible = false;
                        newTchart.Axes.Left.Labels.Visible = false;
                        break;
                    }
                case MapType.Scale:
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

        /**Rebuild the nonseriealized datas when read from file.*/
        public bool rebuildNonSeriealizedDatas(System.Windows.Forms.Panel panel, float curPos, float panelWidth)
        {
            bool result = true;

            initControls(panel, curPos, panelWidth);

            if (baseSeries != null)
                //result = baseSeries.rebuildNonSeriealizedDatas(newTchart, delay, range);
                baseSeries.updatePicture(ConstParameter.ScalePrePage+ConstParameter.DistTOFD2PA);

            return result;
        }

        public void updateAxes(double maxPosValue)      //用于更新绘图             
        {
            if (newTchart == null)
                return;
            /*if (maxPosValue < ConstParameter.ScalePrePage)
                maxPosValue = ConstParameter.ScalePrePage;*/

            //newTchart.Axes.Left.SetMinMax(maxPosValue - 200, maxPosValue);
            if(baseSeries != null)
                baseSeries.updatePicture(maxPosValue);
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

        public void clearSets()
        {
            //this.clearViews();

            /*if (newTchart != null && textBox != null)
            {
                for (int i = newTchart.Series.Count - 1; i >= 0; i--)
                    newTchart.Series.RemoveAt(i);

                textBox = null;
                newTchart = null;
            }*/
            if (newTchart != null)
            {
                for (int i = newTchart.Series.Count - 1; i >= 0; i--)
                    newTchart.Series.RemoveAt(i);
            }
            if (textBox != null) textBox = null;
            if (textPanle != null) textPanle = null;
            if (newTchart != null) newTchart = null;
            if (baseSeries != null) baseSeries = null;
            if (showPanle != null) showPanle = null;
            if (rowData != null) rowData = null;
        }

        public void clearViews()
        {
            if (baseSeries != null)
                baseSeries.clear();
        }

        public bool isMatched(int port, Source source)
        {
            if (rowData == null)
                return false;
            int upPort;
            SessionHardWare.getInfo(rowData.Cycle, out upPort);
            if (upPort == -1)
                return false;

            if (rowData.Activity && upPort == port && rowData.Source == source)
                return true;
            else
                return false;
        }

        public double add(GatePacket gatePacket, int boardIndex)
        {
            if (baseSeries == null)
                return 0;

            if (rowData == null)
                return 0;

            int upPort;
            SessionHardWare.getInfo(rowData.Cycle, out upPort);

            if (delay == -1 || delay == 0)
            {
                int userIndex = SessionHardWare.getUserIndex(rowData.Cycle);
                SessionInfo info = SessionHardWare.getSessionAttr(userIndex);
                GetGateDAQ.Delay((uint)info.sessionIndex, (uint)info.port, (GateType)rowData.Source, ref delay);
            }

            if (range == -1 || range == 0)
            {
                int userIndex = SessionHardWare.getUserIndex(rowData.Cycle);
                SessionInfo info = SessionHardWare.getSessionAttr(userIndex);
                GetGateDAQ.Width((uint)info.sessionIndex, (uint)info.port, (GateType)rowData.Source, ref range);
            }

            double max = baseSeries.add(gatePacket, boardIndex, delay, range);
            return max;
        }
    }

    [Serializable]
    public class PictureColumn
    {
        [NonSerialized] private TChart newTchart;
        [NonSerialized] private TextBox textBox;
        [NonSerialized] private System.Windows.Forms.Panel subPanle;
        [NonSerialized] private System.Windows.Forms.Panel textPanle;
        [NonSerialized] private System.Windows.Forms.Panel showPanle;

        public BaseSeries baseSeries;
        private PictureType type;
        public RowData rowData;

        private double width;

        public PictureColumn(System.Windows.Forms.Panel panel, RowData rowData, float curPos, float width, PictureType type)
        {
            this.type = type;
            this.rowData = rowData;

            initControls(panel, curPos, width);

            switch (this.type)
            {
                case PictureType.BScan:
                    baseSeries = new BScanSeries(newTchart);
                    break;
                case PictureType.TOFD:
                    baseSeries = new TOFDSeries(newTchart);
                    break;
                case PictureType.Merge:
                    baseSeries = new MergeSeries(newTchart);
                    break;
            }
        }

        private void initControls(System.Windows.Forms.Panel panel, float curPos, float width)
        {
            subPanle = new System.Windows.Forms.Panel();
            subPanle.Parent = panel;
            subPanle.Width = (int)width;
            subPanle.Height = panel.Height;
            subPanle.Location = new Point((int)curPos, panel.Location.Y);

            textPanle = new System.Windows.Forms.Panel();
            textPanle.Parent = subPanle;
            textPanle.Width = (int)width;
            textPanle.Height = (int)(panel.Height * 0.04);
            textPanle.Location = new Point(0, panel.Location.Y);

            showPanle = new System.Windows.Forms.Panel();
            showPanle.Parent = subPanle;
            showPanle.Width = (int)width;
            showPanle.Height = panel.Height - textPanle.Height;
            showPanle.Location = new Point(0, textPanle.Location.Y + textPanle.Height);

            textBox = new TextBox();
            textBox.Multiline = false;
            textBox.ReadOnly = true;
            textBox.BackColor = Color.FromArgb(192, 255, 192);
            textBox.BackColor = Color.White;
            textBox.Font = new Font("微软雅黑", 10f);
            if (rowData == null)
                textBox.Text = "";
            else
                textBox.Text = rowData.Cycle;
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
            //newTchart.Zoom.Allow = false;
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
            newTchart.Axes.Bottom.Visible = true;
            newTchart.Axes.Bottom.Grid.Visible = false;
            newTchart.Axes.Left.Grid.Visible = false;
            newTchart.Axes.Left.SetMinMax(0, 200);
            newTchart.Axes.Left.Inverted = true;
            newTchart.Zoom.Allow = false;
            newTchart.Axes.Left.Visible = false;
            newTchart.Axes.Left.Labels.Visible = false;
            newTchart.Series.Add(new Steema.TeeChart.Styles.Map());//Add a series of map just to show the axes
            newTchart.Refresh();

        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public bool rebuildNonSeriealizedDatas(System.Windows.Forms.Panel panel, float curPos, float panelWidth)
        {
            bool result = true;

            initControls(panel, curPos, panelWidth);

            if (baseSeries != null)
                //result = baseSeries.rebuildNonSeriealizedDatas(newTchart, 0, width);
                baseSeries.updatePicture(ConstParameter.ScalePrePage+ConstParameter.DistTOFD2PA);

            return result;
        }

        public void clearSets()
        {
            //this.clearViews();

            /*if (textBox != null)
            {
                textBox = null;
                textPanle = null;
                showPanle = null;
                subPanle = null;
            }*/
            if (newTchart != null)
            {
                for (int i = newTchart.Series.Count - 1; i >= 0; i--)
                    newTchart.Series.RemoveAt(i);
            }
            if (textBox != null) textBox = null;
            if (textPanle != null) textPanle = null;
            if (newTchart != null) newTchart = null;
            if (baseSeries != null) baseSeries = null;
            if (showPanle != null) showPanle = null;
            if (rowData != null) rowData = null;
        }

        public void clearViews()
        {
            if (baseSeries != null)
                baseSeries.clear();
        }

        public void updateAxes(double maxPosValue)
        {
            if (baseSeries == null)
                return;
            /*if (maxPosValue < ConstParameter.ScalePrePage)
                maxPosValue = ConstParameter.ScalePrePage;*/
            
            baseSeries.updatePicture(maxPosValue);
            //newTchart.Axes.Left.SetMinMax(maxPosValue - 100, maxPosValue);
        }

        public bool isMatched(int port, Source source)
        {
            if (rowData == null)
                return false;
            int upPort;
            SessionHardWare.getInfo(rowData.Cycle, out upPort);
            /*delete after test*/
            if (this.type == PictureType.TOFD)
                upPort = 0;//为了保证和上传的数据中的port相一致，将查询结果主动改为0，实际根据rowData.Cycle查询有误
            /*delete after test*/

            if (upPort == -1)
                return false;

            if (this.type == PictureType.Merge)
            {
                if (rowData.Activity && upPort == port)
                    return true;
                else 
                    return false;
            }
            else
            {
                if (rowData.Activity && upPort == port && rowData.Source == source)
                    return true;
                else
                    return false;
            } 
        }

        public double add(GatePacket gatePacket, int boardIndex)
        {
            if (baseSeries == null)
                return 0;

            int upPort;
            SessionHardWare.getInfo(rowData.Cycle, out upPort);
            width = SetGateDAQ.getWidthDictionary(upPort, (int)rowData.Source);

            if (width == -1 || width == 0)
            {
                int userIndex = SessionHardWare.getUserIndex(rowData.Cycle);
                SessionInfo info = SessionHardWare.getSessionAttr(userIndex);
                GetGateDAQ.Width((uint)info.sessionIndex, (uint)info.port, (GateType)rowData.Source, ref width);
            }

            double max = baseSeries.add(gatePacket, boardIndex, 0, width);
            return max;
        }
    }

    [Serializable]
    public class rawDataInOneSession
    {
        public string assignName;
        public double[] rawDataAmp;
        public double[] rawDataTof;
        public double delay = 0;
        public double range = 0;

        public rawDataInOneSession(string assignName, double[] rawDataAmp, double[] rawDataTof)
        {
            this.assignName = assignName;
            this.rawDataAmp = rawDataAmp;
            this.rawDataTof = rawDataTof;
        }

        public rawDataInOneSession(string assignName, double[] rawDataAmp, double[] rawDataTof, double delay, double range)
        {
            this.assignName = assignName;
            this.rawDataAmp = rawDataAmp;
            this.rawDataTof = rawDataTof;
            this.delay = delay;
            this.range = range;
        }
    }

    public enum MapType
    {
        Strip,
        Scale
    }

    public enum PictureType
    {
        Merge,
        BScan,
        TOFD
    }

    public enum YAxesType
    {
        Distance,
        Angle
    }
}