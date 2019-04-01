using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steema.TeeChart;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Steema.TeeChart.Styles;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using Ascan;
using TChartHorizLine = Steema.TeeChart.Styles.HorizLine;
using TChartPoints = Steema.TeeChart.Styles.Points;
using Map = Steema.TeeChart.Styles.Map;
using TChartImage = Steema.TeeChart.Tools.ChartImage;
using autsql;



namespace AUT
{

    public partial class FormReport : Form
    {
        //transport data from stripmap
        private MainForm mainform;
        private List<ReportDefect> defectlist = new List<ReportDefect>();
        private List<RowData> rowDatasList = new List<RowData>();
        private Hashtable stripRawDataHashtable = new Hashtable();   //use Hashtable to store 
        private Hashtable bscanRawDataHashtable = new Hashtable();
        private Hashtable tofdRawDataHashtable = new Hashtable();
        private Hashtable mergeRawDataHashtable = new Hashtable();
        private int currentbatchindex;
        private int currentrecordindex;
        private int maxPosValue = 0;
        private int lastvScrollBarValue;//record last vScrollBarValue,used to update vScrollBarValue in specific step
        private StripColumn scaleColumn;
        private List<ReportStripColumn> mapStripColumns = new List<ReportStripColumn>(); //Columns for strip
        private List<ReportPictureColumn> pictureBScanColumns = new List<ReportPictureColumn>(); //Columns for BScan
        private List<ReportPictureColumn> pictureTOFDColumns = new List<ReportPictureColumn>();  //Columns for TOFD
        private List<ReportPictureColumn> mapMergeColumns = new List<ReportPictureColumn>();
        private OderInfo order = new OderInfo();
        private Product product = new Product();

        public FormReport(MainForm mainform)
        {
            this.mainform = mainform;
            InitializeComponent();
            MultiLanguage.getNames(this);
        }

        private void ReadOrder(string filepath)
        {
            order = (OderInfo)SystemConfig.ReadBase64Data(filepath, "order");
        }

        private void Display()
        {
            for(int i =0;i<order.batchList.Count;i++)
            {
                bacthBox.Items.Add(order.batchList[i].name);
            }
            bacthBox.SelectedIndex = 0;
            currentbatchindex = 0;
            SelectBacth();
        }

        private void SelectBacth()
        {
            int selectnum = currentbatchindex;
            settingBox.Text = "setting0";
            
            //read  and display current bacth's product
            product = SystemConfig.DeserializeFromXml(order.batchList[selectnum].productTypeFullPath, product);
            if (product != null)
            {
                productBox.Text = product.name;
            }

            //weldgrid display
            WeldGrid.RowCount = order.batchList[selectnum].recordList.Count;
            for (int i = 0; i < WeldGrid.RowCount; i++)
            {
                WeldGrid.Rows[i].Cells["num"].Value = i;
                WeldGrid.Rows[i].Cells["time"].Value = 1;
                WeldGrid.Rows[i].Cells["result"].Value = order.batchList[selectnum].recordList[i].result;
                WeldGrid.Rows[i].Cells["load"].Value = ".........";
            }

            //num display
            testnumBox.Text = Convert.ToString(order.batchList[selectnum].nbDetected);
            passednumBox.Text = Convert.ToString(order.batchList[selectnum].nbGood);
            rejectBox.Text = Convert.ToString(order.batchList[selectnum].nbFail);

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

        private void updateStripMap()
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
                            ReportStripColumn mapDatas = new ReportStripColumn(panelTotal, rowData, curPos, stripWidth, MapType.Strip);
                            curPos += stripWidth;
                            mapStripColumns.Add(mapDatas);
                        }
                        else if (rowData.Mode == Mode.BScan)
                        {
                            ReportPictureColumn pictureDatas = new ReportPictureColumn(panelTotal, rowData, curPos, pictureWidth, PictureType.BScan);
                            curPos += pictureWidth;
                            pictureBScanColumns.Add(pictureDatas);
                        }
                        else if (rowData.Mode == Mode.TOFD)
                        {
                            ReportPictureColumn pictureDatas = new ReportPictureColumn(panelTotal, rowData, curPos, pictureWidth, PictureType.TOFD);
                            curPos += pictureWidth;
                            pictureTOFDColumns.Add(pictureDatas);
                        }
                        else
                        {
                            ReportPictureColumn mapDatas = new ReportPictureColumn(panelTotal, rowData, curPos, mergeWidth, PictureType.Merge);
                            curPos += mergeWidth;
                            mapMergeColumns.Add(mapDatas);
                        }
                    }
                }
            }
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

        private void FormReport_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                updateStripMap();
            }  

        }

        private void updateScroll()
        {
            if (maxPosValue <= ConstParameter.ScalePrePage + ConstParameter.DistTOFD2PA)
                return;
            else
                vScrollBar.LargeChange = (int)((ConstParameter.ScalePrePage / (maxPosValue - ConstParameter.DistTOFD2PA)) * vScrollBar.Maximum);
        }

        private void Adddata()
        {
            foreach (ReportStripColumn stripcolumn in mapStripColumns)
            {
                rawDataInOneSession r = (rawDataInOneSession)stripRawDataHashtable[stripcolumn.rowData.Cycle];
                stripcolumn.baseSeries.add(r.rawDataAmp, 66, 4, (int)DAQ_MEAS_MODE.AMP_PERCENT);
                stripcolumn.baseSeries.add(r.rawDataTof, 66, 4, (int)DAQ_MEAS_MODE.TOF_PEAK);
                maxPosValue = r.rawDataAmp.Count();
            }

            foreach (ReportPictureColumn bscancolumn in pictureBScanColumns)
            {
                rawDataInOneSession r = (rawDataInOneSession)bscanRawDataHashtable[bscancolumn.rowData.Cycle];
                bscancolumn.baseSeries.add(r.rawDataAmp, r.delay, r.range, 0);
            }

            foreach (ReportPictureColumn tofdcolumn in pictureTOFDColumns)
            {
                rawDataInOneSession r = (rawDataInOneSession)tofdRawDataHashtable[tofdcolumn.rowData.Cycle];
                tofdcolumn.baseSeries.add(r.rawDataAmp, r.delay, r.range, 0);
            }

            foreach (ReportPictureColumn mergecolumn in mapMergeColumns)
            {
                rawDataInOneSession r = (rawDataInOneSession)mergeRawDataHashtable[mergecolumn.rowData.Cycle];
                mergecolumn.baseSeries.add(r.rawDataAmp, r.delay, r.range, 0);
            }
        }

        private void updateAxes(double curPosValue)
        {
            /*if (curPosValue < ConstParameter.ScalePrePage)
                curPosValue = ConstParameter.ScalePrePage;*/
            if (curPosValue < ConstParameter.DistTOFD2PA)    //wait until running over DistTOFD2PA's distance
                return;

            if (scaleColumn != null)
            {
                scaleColumn.updateAxes(curPosValue);                    //用于更新图像
                scaleColumn.updateAxes(curPosValue - ConstParameter.DistTOFD2PA, YAxesType.Distance);    //用于更新竖直轴坐标,可选择为距离模式和角度模式
            }

            foreach (ReportStripColumn mapColumn in mapStripColumns)
                mapColumn.updateAxes(curPosValue);

            foreach (ReportPictureColumn pictureColumn in pictureBScanColumns)
                pictureColumn.updateAxes(curPosValue);

            foreach (ReportPictureColumn pictureColumn in pictureTOFDColumns)
                pictureColumn.updateAxes(curPosValue);

            foreach (ReportPictureColumn mapColumn in mapMergeColumns)
                mapColumn.updateAxes(curPosValue);
        }

        private void SaveToPicture(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Bitmap bit = CaptruePanel();
            bit.Save(path + "capture.jpg", ImageFormat.Jpeg);
        }

        /**Function For Capture the Screen.*/
        private Bitmap CaptruePanel()
        {
            Graphics mygraphics = this.panelTotal.CreateGraphics();
            Size s = panelTotal.Size;
            Bitmap bit = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(bit);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, s.Width, s.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
            return bit;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
            IntPtr hdcDest,
            int nXDest,
            int nYDest,
            int nWidth,
            int nHeight,
            IntPtr hdcSrc, 
            int nXSrc,
            int nYSrc,
            System.Int32 dwRop 
            );

        private void Defult_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Report\\";
            SaveToPicture(path);
            Groove groove = product.groove;
            WordFunction templet = new WordFunction();
            templet.Creat(Application.StartupPath + "\\report" + "\\report.doc");
            templet.InsertPicture("ResultGraph", Application.StartupPath + "\\report" + "\\capture.jpg", 398.75f, 500);

            InsertGroove(groove, templet);
            InsertData(templet);


            for (int i = 0; i < defectlist.Count; i++)
            {
                templet.InsertCell(templet.wordDoc.Tables[templet.wordDoc.Tables.Count], 2 + i, 1, i.ToString());
                templet.InsertCell(templet.wordDoc.Tables[templet.wordDoc.Tables.Count], 2 + i, 3, defectlist[i].channel);
                templet.InsertCell(templet.wordDoc.Tables[templet.wordDoc.Tables.Count], 2 + i, 5, defectlist[i].start.ToString());
                templet.InsertCell(templet.wordDoc.Tables[templet.wordDoc.Tables.Count], 2 + i, 6, defectlist[i].length.ToString());
            }
            templet.SaveDocument(Application.StartupPath + "\\report" + "\\" + order.name + "report.doc");


        }



        private void InsertGroove(Groove groove,WordFunction templet)
        {
            double grooveheight = groove.height.Sum();
            if(groove.type==GrooveType.V)
            {
                templet.InsertPicture("GrooveGraph", Application.StartupPath + "\\report" + "\\reportVgroove.png", 0, 0);
                templet.InsertValue("D", Convert.ToString(groove.distance)+"mm");
                templet.InsertValue("H", Convert.ToString(grooveheight)+"mm");
                templet.InsertValue("Vh0", Convert.ToString(groove.height[0]+"mm"));
                templet.InsertValue("Vh1", Convert.ToString(groove.height[1])+"mm");
                templet.InsertValue("Vangle", Convert.ToString(groove.angle[0])+"°C");
            }
            else if (groove.type == GrooveType.CRC)
            {
                templet.InsertPicture("GrooveGraph", Application.StartupPath + "\\report" + "\\reportCRCgroove.png", 0, 0);
                templet.InsertValue("H", Convert.ToString(grooveheight) + "mm");
                templet.InsertValue("CRCh0", Convert.ToString(groove.height[0]) + "mm");
                templet.InsertValue("CRCh1", Convert.ToString(groove.height[1]) + "mm");
                templet.InsertValue("CRCh2", Convert.ToString(groove.height[2]) + "mm");
                templet.InsertValue("CRCh3", Convert.ToString(groove.height[3]) + "mm");
                templet.InsertValue("CRCa0", Convert.ToString(groove.angle[0]) + "°C");
                templet.InsertValue("CRCa1", Convert.ToString(groove.angle[1]) + "°C");
                templet.InsertValue("CRCa2", Convert.ToString(groove.angle[2]) + "°C");
            }
            else if (groove.type == GrooveType.X)
            {
                templet.InsertPicture("GrooveGraph", Application.StartupPath + "\\report" + "\\reportXgroove.png", 0, 0);
                templet.InsertValue("H", Convert.ToString(grooveheight));
                templet.InsertValue("Xh0", Convert.ToString(groove.height[0]) + "mm");
                templet.InsertValue("Xh1", Convert.ToString(groove.height[1]) + "mm");
                templet.InsertValue("Xangle", Convert.ToString(groove.angle[0]) + "°C");
            }
        }

        private void InsertData(WordFunction templet)
        {
            BatchInfo batch = order.batchList[currentbatchindex];
            RecordInfo record = batch.recordList[currentrecordindex];
            templet.InsertValue("WeldNumber", Convert.ToString(record.weldNo));
            templet.InsertValue("WeldStatus", record.result);
            templet.InsertValue("Company", "教一128");
            templet.InsertValue("Customer", batch.custormerName);
            templet.InsertValue("BatchName", batch.name);
            templet.InsertValue("Product", product.name);
            templet.InsertValue("OperatorID", batch.operatorId);
            templet.InsertValue("OperatorName", batch.operatorName);
            templet.InsertValue("BatchNumber", Convert.ToString(currentbatchindex));
            templet.InsertValue("Location", batch.area);
            templet.InsertValue("Thickness", Convert.ToString(product.groove.height.Sum()));
            templet.InsertValue("Material", product.weldingMaterial);
            templet.InsertValue("RecordNumber", Convert.ToString(currentrecordindex));
            templet.InsertValue("LocalDate", batch.startDateTime);
            templet.InsertValue("ControlSpec", batch.controlSpec);
            templet.InsertValue("Temp","30°C");
        }

        private void loadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog bsLoadDialog = new OpenFileDialog();
            string filePath = Application.StartupPath;
            bsLoadDialog.Filter = "odr文件(*.odr)|*.odr|所有文件(*.*)|*.*";

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
            bsLoadDialog.InitialDirectory = filePath;
            bsLoadDialog.FilterIndex = 1;
            if (bsLoadDialog.ShowDialog() == DialogResult.OK)
            {
                String fileName = bsLoadDialog.FileName;
                ReadOrder(fileName);
                if (order != null)
                {
                    updateStripMap();
                    initScroll();
                    Display();
                }
                else
                {
                    MessageShow.show("Read File Error！", "读取文件错误！");
                    return;
                }

            }
            //order = mainform.GetOrderinfo();
            //if (order == null)
            //{
            //    MessageShow.show("Get OrderInfo Error", "获取订单失败");
            //    return;
            //}
            //bsLoadDialog.InitialDirectory = filePath;
            //bsLoadDialog.FilterIndex = 1;
            //if (bsLoadDialog.ShowDialog() == DialogResult.OK)
            //{
            //    String fileName = bsLoadDialog.FileName;
            //    ReadOrder(fileName);
            //    if (order != null)
            //    {
            //        updateStripMap();
            //        initScroll();
            //        Display();
            //    }
            //    else
            //    {
            //        MessageShow.show("Read File Error！", "读取文件错误！");
            //        return;
            //    }

            //}
            //order = mainform.GetOrderinfo();
            order = FormList.FormBatch.od;
            if (order == null)
            {
                MessageShow.show("Get OrderInfo Error", "获取订单失败");
                return;
            }
            initScroll();
            Display();
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int scaleperpage = ConstParameter.ScalePrePage;
            if (System.Math.Abs(e.NewValue - lastvScrollBarValue) > 10) //when scroll change >10 update
            {
                lastvScrollBarValue = e.NewValue;
                double reshowPosValue = e.NewValue * (maxPosValue - ConstParameter.DistTOFD2PA - scaleperpage) / (vScrollBar.Maximum - vScrollBar.LargeChange) + scaleperpage + ConstParameter.DistTOFD2PA;
                updateAxes(reshowPosValue);
            }
        }

        private void bacthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentbatchindex = bacthBox.SelectedIndex;
            SelectBacth();
            clearSets();
            initScroll();
        }

        private bool ReadRecord(string fileName)
        {
            rowDatasList = (List<RowData>)SystemConfig.ReadBase64Data(fileName, "rowDatasList");
            stripRawDataHashtable = (Hashtable)SystemConfig.ReadBase64Data(fileName, "stripRawDataHashtable");
            bscanRawDataHashtable = (Hashtable)SystemConfig.ReadBase64Data(fileName, "bscanRawDataHashtable");
            tofdRawDataHashtable = (Hashtable)SystemConfig.ReadBase64Data(fileName, "tofdRawDataHashtable");
            mergeRawDataHashtable = (Hashtable)SystemConfig.ReadBase64Data(fileName, "mergeRawDataHashtable");

            if (rowDatasList == null || stripRawDataHashtable == null || bscanRawDataHashtable == null || tofdRawDataHashtable == null || mergeRawDataHashtable==null)
            {
                return false;
            }

            return true;
        }

        private void WeldGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            currentrecordindex = rowIndex;
            if (columIndex == 3)
            {
                System.Drawing.Rectangle rect = WeldGrid.GetCellDisplayRectangle(columIndex, rowIndex, false);
                panelload.Size = rect.Size;
                panelload.Top = rect.Top;
                panelload.Left = rect.Left;
                panelload.Visible = true;
            }
        }

        private void btload_Click(object sender, EventArgs e)
        {
            bool readresult;
            readresult = ReadRecord(order.batchList[currentbatchindex].recordList[currentrecordindex].fileFullPath);
            if (readresult == true)
            {
                updateStripMap();
                Adddata();
                vScrollBar.Maximum = maxPosValue;
                updateAxes(250);
            }
            else
            {
                MessageShow.show("Load err","载入错误");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ReportPictureColumn tmp in pictureBScanColumns)
            {
                tmp.baseSeries.disposemesure();
            }
        }


        private void FormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach(ReportPictureColumn tmp in pictureBScanColumns)
            {
                double start = 0;
                double length = 0;        
                tmp.baseSeries.GetDefect(ref start, ref length);
                if (start != 0 && length != 0)
                {
                    ReportDefect deftect = new ReportDefect(tmp.rowData, start, length);
                    defectlist.Add(deftect);
                }
            }
            foreach (ReportStripColumn tmp in mapStripColumns)
            {
                double start = 0;
                double length = 0;
                tmp.baseSeries.GetDefect(ref start, ref length);
                if (start != 0 && length != 0)
                {
                    ReportDefect deftect = new ReportDefect(tmp.rowData, start, length);
                    defectlist.Add(deftect);
                }
            }
        }
    }

    [Serializable]
    public class ReportStripColumn
    {
        [NonSerialized]
        private TChart newTchart;
        [NonSerialized]
        private TextBox textBox;
        [NonSerialized]
        private System.Windows.Forms.Panel subPanle;
        [NonSerialized]
        private System.Windows.Forms.Panel textPanle;
        [NonSerialized]
        private System.Windows.Forms.Panel showPanle;

        public ReportBaseSeries baseSeries;
        private MapType type;
        public RowData rowData;

        private double delay;
        private double range;

        public ReportStripColumn(System.Windows.Forms.Panel panel, RowData rowData, float curPos, float width, MapType type)
        {
            this.type = type;
            this.rowData = rowData;

            initControls(panel, curPos, width);

            switch (this.type)
            {
                case MapType.Strip:
                    baseSeries = new ReportStripSeries(this.newTchart);
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
                result = baseSeries.rebuildNonSeriealizedDatas(newTchart, delay, range);

            return result;
        }

        public void updateAxes(double maxPosValue)      //用于更新绘图             
        {
            if (newTchart == null)
                return;
            /*if (maxPosValue < ConstParameter.ScalePrePage)
                maxPosValue = ConstParameter.ScalePrePage;*/

            //newTchart.Axes.Left.SetMinMax(maxPosValue - 200, maxPosValue);
            if (baseSeries != null)
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

        public double add(double[] amp,double delay,double range,int type)
        {
            if (baseSeries == null)
                return 0;

            if (rowData == null)
                return 0;

            double max = baseSeries.add(amp, delay, range, type);
            return max;
        }
    }

    [Serializable]
    public class ReportPictureColumn
    {
        [NonSerialized]
        private TChart newTchart;
        [NonSerialized]
        private TextBox textBox;
        [NonSerialized]
        private System.Windows.Forms.Panel subPanle;
        [NonSerialized]
        private System.Windows.Forms.Panel textPanle;
        [NonSerialized]
        private System.Windows.Forms.Panel showPanle;

        public ReportBaseSeries baseSeries;
        private PictureType type;
        public RowData rowData;

        private double width;

        public ReportPictureColumn(System.Windows.Forms.Panel panel, RowData rowData, float curPos, float width, PictureType type)
        {
            this.type = type;
            this.rowData = rowData;

            initControls(panel, curPos, width);

            switch (this.type)
            {
                case PictureType.BScan:
                    baseSeries = new ReportBScanSeries(newTchart);
                    break;
                case PictureType.TOFD:
                    baseSeries = new ReportTOFDSeries(newTchart);
                    break;
                case PictureType.Merge:
                    baseSeries = new ReportMergeSeries(newTchart);
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
                result = baseSeries.rebuildNonSeriealizedDatas(newTchart, 0, width);

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

        public double add(double[] amp,double delay,double range,int type)
        {
            if (baseSeries == null)
                return 0;
            double max = baseSeries.add(amp,delay,range,type);
            return max;
        }
    }

    [Serializable]
    public class ReportStripSeries : ReportBaseSeries
    {
        [NonSerialized]
        private TchartMeasureLine measureline;
        [NonSerialized]
        private Bitmap imageForColor;
        [NonSerialized]
        private Steema.TeeChart.Tools.ChartImage chartImage;
        [NonSerialized]
        private Steema.TeeChart.Styles.HorizLine line;
        [NonSerialized]
        private byte[] dateArray;
        [NonSerialized]
        private byte[] onePagedataArray;
        [NonSerialized]
        private double[] linedataArray;
        [NonSerialized]
        private int width;
        [NonSerialized]
        private int height;
        [NonSerialized]
        private int stride; // the size for one row
        [NonSerialized]
        private List<StripDate> contain;

        private double thresholdForAmp;
        private double threaholdForTime;
        private double threaholdForGreenTime;
        private double threaholdForRedTime;
        private double threaholdForYellowTime;
        private double PosInc = 1;  //每个扫差点之间的距离间隔，默认为1
        private ReportStripDateService dateService;

        public ReportStripSeries(TChart tchart)
            : base(tchart)
        {
            thresholdForAmp = 5;
            threaholdForTime = 20;
            threaholdForGreenTime = 40;
            threaholdForRedTime = 80;
            threaholdForYellowTime = 100;

            initSeries();

            dateService = new ReportStripDateService(ConstParameter.PipeDiameter);
        }

        public override void initSeries()
        {
            line = new TChartHorizLine();
            tchart.Series.Add(line);

            chartImage = new TChartImage();
            chartImage.ImageMode = Steema.TeeChart.Drawing.ImageMode.Stretch;
            chartImage.Active = true;
            tchart.Tools.Add(chartImage);

            width = tchart.Graphics3D.ChartXCenter * 2;
            height = tchart.Graphics3D.ChartYCenter * 2;
            //width = tchart.Width;
            //height = tchart.Height;

            stride = 4 * ((width * 24 + 31) / 32);
            int MaxPixelHight = (int)((3.1415926 * ConstParameter.PipeDiameter / ConstParameter.ScalePrePage) * height);
            if (dateArray == null)
                //dateArray = new byte[stride * ConstParameter.MaxPixelHight];
                dateArray = new byte[stride * MaxPixelHight];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            if (onePagedataArray == null)
            {
                //int realheight = (int)((ConstParameter.DistTOFD2PA + ConstParameter.ScalePrePage) / ConstParameter.ScalePrePage * height);
                //onePagedataArray = new byte[width * realheight * 3];    //store one page pix data
                onePagedataArray = new byte[width * height * 3];
            }
            for (int k = 0; k < onePagedataArray.Length; k++)
                onePagedataArray[k] = byte.MaxValue;

            if (linedataArray == null)
                linedataArray = new double[ConstParameter.MaxPixelHight];
            for (int k = 0; k < ConstParameter.MaxPixelHight; k++)
                linedataArray[k] = 0;

            imageForColor = new Bitmap(width, height);

            contain = new List<StripDate>();
            for (int i = 0; i < 1000; i++)
            {
                StripDate date = new StripDate(-1, -1);
                contain.Add(date);
            }

            measureline = new TchartMeasureLine();
            measureline.MouseTchartInit(tchart, true);
            measureline.Getpara(tchart, tchart.Axes.Bottom.Minimum, tchart.Axes.Bottom.Maximum, tchart.Axes.Left.Minimum, tchart.Axes.Left.Maximum);


            //maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
            maxScale = (int)(3.1415926 * ConstParameter.PipeDiameter);
            /*pictureBox = new PictureBox();
            pictureBox.Width = width;
            pictureBox.Height = height;
            pictureBox.Parent = tchart;
            pictureBox.Dock = DockStyle.Top;*/

            tchart.Refresh();
        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                for (int k = 0; k < onePagedataArray.Length; k++)
                    onePagedataArray[k] = byte.MaxValue;

                for (int k = 0; k < ConstParameter.MaxPixelHight; k++)
                    linedataArray[k] = 0;

                if (dateService != null)
                    dateService.clear();

                // updatePicture(ConstParameter.ScalePrePage); //清除全部数据后刷一次图
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        public override double add(double[] newdata,double delay,double range, int type)
        {
            int num = 0;
            dateService.mergeDates(ref contain, ref num, newdata, type);
            int index = 0;
            double maxPos = 0;
            while (num != 0)
             {
                StripDate date = contain[index++];
                linedataArray[date.index] = date.amp;  //将line的数据单独加入到linedataArray数组中
                double tmp = addOneStrip(date, delay, range);
                if (tmp > maxPos)
                    maxPos = tmp;
                num--;
            }
            return maxPos;
        }

        private double addOneStrip(StripDate date, double delay, double range) //添加PosInc参数
        {
            double tofValue = date.tof;
            double ampValue = date.amp;
            int index = date.index;
            int realPos = ConstParameter.AnglePreUnit * index;
            double tofPercent = getTofPercent(tofValue, delay, range);
            double maxPos = 0;

            if (ampValue < thresholdForAmp)
                return maxPos;
            else if (ampValue < threaholdForTime)
            {
                //line.Add(ampValue, realPos, Color.Black);
                //mapPoints.addAPoint(pos, ampValue);
                return ampValue;
            }
            else if (ampValue < threaholdForGreenTime)
            {
                //line.Add(ampValue, realPos, Color.Black);
                //mapPoints.addAPoint(pos, ampValue);
                maxPos = addShapes(Color.LawnGreen, index, tofPercent);
            }
            else if (ampValue < threaholdForRedTime)
            {
                //line.Add(ampValue, realPos, Color.Black);
                //mapPoints.addAPoint(pos, ampValue);
                maxPos = addShapes(Color.Red, index, tofPercent);
            }
            else if (ampValue < threaholdForYellowTime)
            {
                //line.Add(ampValue, realPos, Color.Black);
                //mapPoints.addAPoint(pos, ampValue);
                maxPos = addShapes(Color.Yellow, index, tofPercent);
            }

            return maxPos;
        }

        private double getTofPercent(double tofValue, double delay, double range)
        {
            if (tofValue < delay || tofValue > (delay + range))
                return 0;
            else
            {
                return (tofValue - delay) * 100 / range;
            }
        }

        private void showline(double maxPosValue)
        {
            if (maxPosValue > maxScale)
                return;

            int startindex = 0;
            int shownum = 0;
            int showlineindex = 0;
            //int shownum = (int)(ConstParameter.ScalePrePage/PosInc);
            //if(maxPosValue > ConstParameter.ScalePrePage)
            //startindex = (int)((maxPosValue - ConstParameter.ScalePrePage)/PosInc);    //根据实际运行位置计算显示的开始索引处，实现line的滚动
            calLinestart(maxPosValue, ref startindex, ref shownum);
            for (int i = startindex; i < startindex + shownum; i++)
            {
                double showPos = showlineindex * PosInc;    //showPos是line的显示位置，即y值，即使滚动，y也是从0开始
                double ampValue = linedataArray[i];         //而ampValue则需要从linedataArray的startindex处开始
                line.Add(ampValue, showPos, Color.Black);
                showlineindex++;
            }
        }

        private void calLinestart(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            if (Dir == 0)   //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    start = (int)(DistTOFD2PA / PosInc);
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    start = (int)((maxPosValue - ScalePrePage) / PosInc);
                displayLength = (int)(ScalePrePage / PosInc);
            }
            else if (Dir == 1)  //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { start = 0; displayLength = (int)((maxPosValue - DistTOFD2PA) / PosInc); }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { start = (int)((maxPosValue - ScalePrePage - DistTOFD2PA) / PosInc); displayLength = (int)(ScalePrePage / PosInc); }
            }
        }

        private double addShapes(Color color, int posIndex, double value) //添加PosInc参数
        {
            int constNum = 100;
            //double defaultMinPos = ConstParameter.AnglePreUnit * posIndex;
            double defaultMinPos = PosInc * posIndex;
            if (defaultMinPos < 0)
                defaultMinPos = 0;
            //double defaultMaxPos = defaultMinPos + ConstParameter.AnglePreUnit;
            double defaultMaxPos = defaultMinPos + PosInc;
            int index;
            byte r = color.R, g = color.G, b = color.B;

            for (int j = (int)(defaultMinPos * height / ConstParameter.ScalePrePage); j < (int)(defaultMaxPos * height / ConstParameter.ScalePrePage); j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int curPos = i * constNum / width;
                    if (curPos <= value)
                    {
                        index = j * stride + 3 * i;
                        dateArray[index] = b;
                        dateArray[index + 1] = g;
                        dateArray[index + 2] = r;
                    }
                    else
                        break;
                }
            }
            return defaultMaxPos;
        }

        public override void updatePicture(double maxPosValue)
        {
            int start = 0;
            int displayLength = 0;
            //if (!pictureBox.InvokeRequired)
            if (!tchart.InvokeRequired)
            {
                if (imageForColor == null)
                    imageForColor = new Bitmap(width, height);
                if (maxPosValue > maxScale)
                    return;

                /*int startColumn = (int)(maxPosValue - ConstParameter.ScalePrePage) * height / ConstParameter.ScalePrePage;
                int start = startColumn * stride;*/
                calStartLength(maxPosValue, ref start, ref displayLength);
                Array.Copy(dateArray, start, onePagedataArray, 0, displayLength);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(onePagedataArray, 0, ptr, width * height * 3);
                imageForColor.UnlockBits(CanvasData);

                //pictureBox.Image = imageForColor;
                imageForColor.RotateFlip(RotateFlipType.Rotate180FlipX);
                chartImage.Image = imageForColor;

                line.Clear();           //每一次刷图前都将line中的点清掉
                showline(maxPosValue);  //绘制带状图中的包络线
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                //pictureBox.Invoke(updatePictureFunc, maxPosValue);
                tchart.Invoke(updatePictureFunc, maxPosValue);
            }
        }


        private void calStartLength(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            //int start = 0;
            int displayColumn = 0;
            //int displayLength = 0;

            if (Dir == 0)    //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                start = startColumn * stride;
                displayLength = width * height * 3;
            }
            else if (Dir == 1)   //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                start = startColumn * stride;
                displayLength = displayColumn * stride;
            }
        }

        public override void GetDefect(ref double start, ref double length)
        {
            start = measureline.start;
            length = measureline.length;
        }
    }

    [Serializable]
    public class ReportBScanSeries : ReportBaseSeries
    {
        [NonSerialized]
        private PicMeasureLine measureline;
        [NonSerialized]
        protected PictureBox pictureBox;
        [NonSerialized]
        private Bitmap imageForColor;
        [NonSerialized]
        private byte[] dateArray;
        [NonSerialized]
        private byte[] onePagedataArray;
        [NonSerialized]
        private int width;
        [NonSerialized]
        private int height;
        [NonSerialized]
        private int stride; // the size for one row

        private PicturePoints picturePoints;

        public ReportBScanSeries(TChart tchart)
            : base(tchart)
        {
            initSeries();

            picturePoints = new PicturePoints();
        }

        public override void initSeries()
        {
            width = tchart.Graphics3D.ChartXCenter * 2;
            height = tchart.Graphics3D.ChartYCenter * 2;
            //width = tchart.Width;
            //height = tchart.Height;
            stride = 4 * ((width * 24 + 31) / 32);
            int MaxPixelHight = (int)((3.1415926 * ConstParameter.PipeDiameter / ConstParameter.ScalePrePage) * height);
            if (dateArray == null)
                //dateArray = new byte[stride * ConstParameter.MaxPixelHight];
                dateArray = new byte[stride * MaxPixelHight];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            if (onePagedataArray == null)
            {
                //int realheight = (int)((ConstParameter.DistTOFD2PA + ConstParameter.ScalePrePage) / ConstParameter.ScalePrePage * height);
                //onePagedataArray = new byte[width * realheight * 3];    //store one page pix data
                onePagedataArray = new byte[width * height * 3];
            }
            for (int k = 0; k < onePagedataArray.Length; k++)
                onePagedataArray[k] = byte.MaxValue;

            imageForColor = new Bitmap(width, height);

            pictureBox = new PictureBox();
            pictureBox.Width = width - 1;
            pictureBox.Height = height - 1;
            //pictureBox.BackColor = Color.Red;
            pictureBox.Parent = tchart;
            pictureBox.Location = new Point(0, 0);

            measureline = new PicMeasureLine();
            measureline.MousePicInit(pictureBox, true);
            measureline.Getpara(tchart, 0, tchart.Axes.Bottom.Maximum, 0, tchart.Axes.Left.Maximum);
            //maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
            maxScale = (int)(3.1415926 * ConstParameter.PipeDiameter);

        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                for (int k = 0; k < onePagedataArray.Length; k++)
                    onePagedataArray[k] = byte.MaxValue;

                /*if (pictureBox != null)           //不需在这里置null，只完成数据清理工作即可
                    pictureBox.Image = null;*/

                if (picturePoints != null)
                    picturePoints.clear();

                //updatePicture(ConstParameter.ScalePrePage);//数据重置后刷一次图
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        public override void disposemesure()
        {
            //measureline.MouseInit(pictureBox, false);
        }

        public override double add(double[] newamp, double delay, double range, int type)
        {
            int constNum = ConstParameter.BscanPointNumPrePacket;
            int curPos = 0;
            int totalnum = newamp.Length;
            int num = (int)(totalnum / constNum);            //the num of ascan

            //if (curPos > ConstParameter.MaxPixelHight)      //maxScale   to  MaxPixelHight
            //    return ConstParameter.MaxPixelHight;
            byte r = 0, g = 0, b = 0;
            double amp = 0;
            int index;

            clear();
            for (int cyclenum = 0; cyclenum < num; cyclenum++)
            {
                for (int i = 0; i < width; i++)
                {
                    index = i * 256 / width;    //将256个数据显示在width个像素宽度里面
                    amp = newamp[index + 256 * cyclenum];
                    if (picturePoints != null)
                        picturePoints.addPoint(curPos, i, amp);

                    if (RGBImage.getRGB((double)amp, ref r, ref g, ref b))
                    {
                        for (int j = curPos * height / ConstParameter.ScalePrePage; j < (curPos + 1) * height / ConstParameter.ScalePrePage; j++)
                        {
                            int dataindex = j * stride + 3 * i;     //index to dataindex
                            dateArray[dataindex] = b;
                            dateArray[dataindex + 1] = g;
                            dateArray[dataindex + 2] = r;
                        }
                    }
                }
                curPos++;       //cyclenum循环完一次，curPos加1，开始载入下一行的数据
            }
            return curPos;
        }

        public override void updatePicture(double maxPosValue)
        {
            /*int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            int displayColumn = 0;*/
            int start = 0;
            int displayLength = 0;
            if (!tchart.InvokeRequired)
            {
                if (imageForColor == null)
                    imageForColor = new Bitmap(width, height);
                if (maxPosValue > maxScale)     //maxScale为运动最大距离，此时为200*6=1200mm
                    return;

                /*int startColumn = (int)(maxPosValue - ConstParameter.ScalePrePage) * height / ConstParameter.ScalePrePage;//每一个page只显示ScalePrePage行数据，对应的像素点高度为height，maxPosValue小于200时取200
                int start = startColumn * stride;*/
                //当扫查长度超过ScalePrePage时，就需要计算图像显示的开始位置，并计算其在dataArray中的存储位置start
                /*if (Dir == 0)    //Dir++
                {
                    if (maxPosValue < DistTOFD2PA)
                        return;
                    else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                        startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                    else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                        startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                    start = startColumn * stride;
                    displayLength = width * height * 3;
                }
                else if (Dir == 1)   //Dir--
                {
                    if (maxPosValue < DistTOFD2PA)
                        return;
                    else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                        {startColumn = 0;   displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage;}
                    else if(maxPosValue >= ScalePrePage + DistTOFD2PA)
                        {startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height;}

                    start = startColumn * stride;
                    displayLength = displayColumn * stride;
                }*/
                calStartLength(maxPosValue, ref start, ref displayLength);
                Array.Copy(dateArray, start, onePagedataArray, 0, displayLength);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(onePagedataArray, 0, ptr, width * height * 3);
                imageForColor.UnlockBits(CanvasData);

                pictureBox.Image = imageForColor;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                tchart.Invoke(updatePictureFunc, maxPosValue);
            }
        }

        private void calStartLength(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            //int start = 0;
            int displayColumn = 0;
            //int displayLength = 0;

            if (Dir == 0)    //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;
               start = startColumn * stride;
                displayLength = width * height * 3;
            }
            else if (Dir == 1)   //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                start = startColumn * stride;
                displayLength = displayColumn * stride;
            }
        }

        public override void GetDefect(ref double start, ref double length)
        {
            start = measureline.start;
            length = measureline.length;
        }
    }

    [Serializable]
    public class ReportTOFDSeries : ReportBaseSeries
    {
        [NonSerialized]
        private PicMeasureLine measureline;
        [NonSerialized]
        protected PictureBox pictureBox;
        [NonSerialized]
        private Bitmap imageForColor;
        [NonSerialized]
        private byte[] dateArray;
        [NonSerialized]
        private byte[] onePagedataArray;
        [NonSerialized]
        private int width;
        [NonSerialized]
        private int height;
        [NonSerialized]
        private int stride; // the size for one row

        private PicturePoints picturePoints;

        public ReportTOFDSeries(TChart tchart)
            : base(tchart)
        {
            initSeries();

            picturePoints = new PicturePoints();
        }

        public override void initSeries()
        {
            width = tchart.Graphics3D.ChartXCenter * 2;
            height = tchart.Graphics3D.ChartYCenter * 2;

            //width = tchart.Width;
            //height = tchart.Height;

            stride = 4 * ((width * 24 + 31) / 32);
            int MaxPixelHight = (int)((3.1415926 * ConstParameter.PipeDiameter / ConstParameter.ScalePrePage) * height);
            if (dateArray == null)
                //dateArray = new byte[stride * ConstParameter.MaxPixelHight];
                dateArray = new byte[stride * MaxPixelHight];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            if (onePagedataArray == null)
            {
                //int realheight = (int)((ConstParameter.DistTOFD2PA + ConstParameter.ScalePrePage) / ConstParameter.ScalePrePage * height);
                //onePagedataArray = new byte[width * realheight * 3];    //store one page pix data
                //onePagedataArray = new byte[width * height * 3];
                onePagedataArray = new byte[stride * height];
            }
            for (int k = 0; k < onePagedataArray.Length; k++)
                onePagedataArray[k] = byte.MaxValue;

            imageForColor = new Bitmap(width, height);

            pictureBox = new PictureBox();
            pictureBox.Width = width - 1;
            pictureBox.Height = height - 1;
            //pictureBox.BackColor = Color.Red;
            pictureBox.Parent = tchart;
            pictureBox.Location = new Point(0, 0);

            measureline = new PicMeasureLine();
            measureline.MousePicInit(pictureBox, true);
            measureline.Getpara(tchart, 0, tchart.Axes.Bottom.Maximum, 0, tchart.Axes.Left.Maximum);

            //maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
            maxScale = (int)(3.1415926 * ConstParameter.PipeDiameter);
        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                for (int k = 0; k < onePagedataArray.Length; k++)
                    onePagedataArray[k] = byte.MaxValue;

                /*if (pictureBox != null)
                    pictureBox.Image = null;*/

                if (picturePoints != null)
                    picturePoints.clear();

                //updatePicture(ConstParameter.ScalePrePage);
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        public override double add(double[] newamp ,double delay, double range, int type)
        {
            int constNum = ConstParameter.BscanPointNumPrePacket;
            int curPos = 0;
            int totalnum = newamp.Length;
            int num = (int)(totalnum / constNum);            //the num of ascan

            //if (curPos > ConstParameter.MaxPixelHight)      //maxScale   to  MaxPixelHight
            //    return ConstParameter.MaxPixelHight;
            byte r = 0, g = 0, b = 0;
            double amp = 0;
            int index;
            clear();
            for (int cyclenum = 0; cyclenum < num; cyclenum++)
            {
                for (int i = 0; i < width; i++)
                {
                    index = i * 256 / width;    //将256个数据显示在width个像素宽度里面
 
                    //if (index < totalnum)
                    //{
                    amp = newamp[index + 256 * cyclenum];
#if TEST
                    amp = amp * 100 % 100;
#endif
                    // }
#if TEST
                else
                {
                    amp = rd.Next(100);
                }
#endif

                    if (picturePoints != null)
                        picturePoints.addPoint(curPos, i, amp);

                    if (GrayImage.getRGB((double)amp, ref r, ref g, ref b))
                    {
                        for (int j = curPos * height / ConstParameter.ScalePrePage; j < (curPos + 1) * height / ConstParameter.ScalePrePage; j++)
                        {
                            int dataindex = j * stride + 3 * i;     //index to dataindex
                            dateArray[dataindex] = b;
                            dateArray[dataindex + 1] = g;
                            dateArray[dataindex + 2] = r;
                        }
                    }
                }
                curPos++;       //cyclenum循环完一次，curPos加1，开始载入下一行的数据
            }

            return curPos;
        }

        public override void updatePicture(double maxPosValue)
        {
            /*int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            int displayColumn = 0;*/
            int start = 0;
            int displayLength = 0;
            if (!tchart.InvokeRequired)
            {
                if (imageForColor == null)
                    imageForColor = new Bitmap(width, height);
                if (maxPosValue > maxScale)     //maxScale为运动最大距离，此时为200*6=1200mm
                    return;

                /*int startColumn = (int)(maxPosValue - ConstParameter.ScalePrePage) * height / ConstParameter.ScalePrePage;//每一个page只显示ScalePrePage行数据，对应的像素点高度为height，maxPosValue小于200时取200
                int start = startColumn * stride;*/
                //当扫查长度超过ScalePrePage时，就需要计算图像显示的开始位置，并计算其在dataArray中的存储位置start
                /* if (Dir == 1)    //Dir++
                 {
                     if (maxPosValue < DistTOFD2PA)
                         return;
                     else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                         startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                     else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                         startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                     start = startColumn * stride;
                     displayLength = width * height * 3;
                 }
                 else if (Dir == 0)   //Dir--
                 {
                     if (maxPosValue < DistTOFD2PA)
                         return;
                     else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                     { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                     else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                     { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                     start = startColumn * stride;
                     displayLength = displayColumn * stride;
                 }*/
                calStartLength(maxPosValue, ref start, ref displayLength);
                Array.Copy(dateArray, start, onePagedataArray, 0, displayLength);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(onePagedataArray, 0, ptr, width * height * 3);
                imageForColor.UnlockBits(CanvasData);

                pictureBox.Image = imageForColor;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                tchart.Invoke(updatePictureFunc, maxPosValue);
            }
        }

        private void calStartLength(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            //int start = 0;
            int displayColumn = 0;
            //int displayLength = 0;

            if (Dir == 0)    //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                start = startColumn * stride;
                displayLength = displayColumn * stride;
            }
            else if (Dir == 1)   //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                start = startColumn * stride;
                displayLength = width * height * 3;
            }
        }

        public override void GetDefect(ref double start, ref double length)
        {
            start = measureline.start;
            length = measureline.length;
        }

    }

    [Serializable]
    public class ReportMergeSeries : ReportBaseSeries
    {
        [NonSerialized]
        private PicMeasureLine measureline;
        [NonSerialized]
        protected PictureBox pictureBox;
        [NonSerialized]
        private Bitmap imageForColor;
        [NonSerialized]
        private byte[] dateArray;
        [NonSerialized]
        private byte[] onePagedataArray;
        [NonSerialized]
        private int width;
        [NonSerialized]
        private int height;
        [NonSerialized]
        private int stride; // the size for one row
        [NonSerialized]
        private List<CoupleDate> contain;

        private CoupleDateService dateService;

        public ReportMergeSeries(TChart tchart)
            : base(tchart)
        {
            initSeries();
        }

        public override void initSeries()
        {
            width = tchart.Graphics3D.ChartXCenter * 2;
            height = tchart.Graphics3D.ChartYCenter * 2;

            stride = 4 * ((width * 24 + 31) / 32);
            int MaxPixelHight = (int)((3.1415926 * ConstParameter.PipeDiameter / ConstParameter.ScalePrePage) * height);
            if (dateArray == null)
                //dateArray = new byte[stride * ConstParameter.MaxPixelHight];
                dateArray = new byte[stride * MaxPixelHight];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            if (onePagedataArray == null)
            {
                //int realheight = (int)((ConstParameter.DistTOFD2PA + ConstParameter.ScalePrePage) / ConstParameter.ScalePrePage * height);
                //onePagedataArray = new byte[width * realheight * 3];    //store one page pix data
                onePagedataArray = new byte[width * height * 3];
            }
            for (int k = 0; k < onePagedataArray.Length; k++)
                onePagedataArray[k] = byte.MaxValue;

            imageForColor = new Bitmap(width, height);

            pictureBox = new PictureBox();
            pictureBox.Width = width - 1;
            pictureBox.Height = height - 1;
            pictureBox.Parent = tchart;
            pictureBox.Location = new Point(0, 0);
            //pictureBox.Dock = DockStyle.Top;

            dateService = new CoupleDateService(ConstParameter.PipeDiameter);

            contain = new List<CoupleDate>();
            for (int i = 0; i < 40; i++)
                contain.Add(new CoupleDate());

            //maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
            maxScale = (int)(3.1415926 * ConstParameter.PipeDiameter);

            measureline = new PicMeasureLine();
            measureline.MousePicInit(pictureBox, true);
            measureline.Getpara(tchart, 0, tchart.Axes.Bottom.Maximum, 0, tchart.Axes.Left.Maximum);

        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                //if (mapPoints != null)
                //mapPoints.clear();
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                for (int k = 0; k < onePagedataArray.Length; k++)
                    onePagedataArray[k] = byte.MaxValue;

                if (dateService != null)
                    dateService.clear();

                //updatePicture(ConstParameter.ScalePrePage); //清除全部数据后刷一次图
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        public override double add(double[] newamp, double delay, double range, int type)
        {
            double tmpMinPos = 0;
            double tmpMaxPos = 0;
            for (int n = 0; n < newamp.Count(); n++)
            {
                int posIndex = n;
                tmpMinPos = ConstParameter.AnglePreUnit * posIndex;
                tmpMaxPos = tmpMinPos + ConstParameter.AnglePreUnit;

                byte r = 0, g = 0, b = 0;
                int index = 0;

                if (newamp[n] == 0)
                {
                    r = Color.Green.R;
                    g = Color.Green.G;
                    b = Color.Green.B;
                }
                else
                {
                    r = Color.Red.R;
                    g = Color.Red.G;
                    b = Color.Red.B;
                }

                for (int i = 0; i < width; i++)
                {

                    for (int j = (int)(tmpMinPos * height / ConstParameter.ScalePrePage); j < (int)(tmpMaxPos * height / ConstParameter.ScalePrePage); j++)
                    {
                        index = j * stride + 3 * i;
                        dateArray[index] = b;
                        dateArray[index + 1] = g;
                        dateArray[index + 2] = r;
                    }
                }
            }
            return tmpMaxPos;
        }

        //private double addCoupleDates(CoupleDate date)
        //{
        //    int posIndex = date.index;
        //    double tmpMinPos = ConstParameter.AnglePreUnit * posIndex;
        //    double tmpMaxPos = tmpMinPos + ConstParameter.AnglePreUnit;

        //    byte r = 0, g = 0, b = 0;
        //    int index = 0;

        //    if (date.isOK)
        //    {
        //        r = Color.Green.R;
        //        g = Color.Green.G;
        //        b = Color.Green.B;
        //    }
        //    else
        //    {
        //        r = Color.Red.R;
        //        g = Color.Red.G;
        //        b = Color.Red.B;
        //    }

        //    for (int i = 0; i < width; i++)
        //    {

        //        for (int j = (int)(tmpMinPos * height / ConstParameter.ScalePrePage); j < (int)(tmpMaxPos * height / ConstParameter.ScalePrePage); j++)
        //        {
        //            index = j * stride + 3 * i;
        //            dateArray[index] = b;
        //            dateArray[index + 1] = g;
        //            dateArray[index + 2] = r;
        //        }
        //    }
        //    return tmpMaxPos;
        //}

        public override void updatePicture(double maxPosValue)
        {
            int start = 0;
            int displayLength = 0;
            if (!pictureBox.InvokeRequired)
            {
                if (imageForColor == null)
                    imageForColor = new Bitmap(width, height);
                if (maxPosValue > maxScale)
                    return;

                /*int startColumn = (int)(maxPosValue - ConstParameter.ScalePrePage) * height / ConstParameter.ScalePrePage;
                int start = startColumn * stride;*/
                calStartLength(maxPosValue, ref start, ref displayLength);
                Array.Copy(dateArray, start, onePagedataArray, 0, displayLength);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(dateArray, start, ptr, width * height * 3);
                imageForColor.UnlockBits(CanvasData);

                pictureBox.Image = imageForColor;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                pictureBox.Invoke(updatePictureFunc, maxPosValue);
            }
        }

        private void calStartLength(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            //int start = 0;
            int displayColumn = 0;
            //int displayLength = 0;

            if (Dir == 0)    //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                start = startColumn * stride;
                displayLength = width * height * 3;
            }
            else if (Dir == 1)   //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                start = startColumn * stride;
                displayLength = displayColumn * stride;
            }
        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public override bool rebuildNonSeriealizedDatas(TChart chart, double delay, double width)
        {
            //if (mapPoints == null)
            //return false;

            this.tchart = chart;
            initSeries();
            showSeries();

            return true;
        }

        /**Show the series according to the points get from file.*/
        private void showSeries()
        {
            // if (mapPoints == null)
            {
                MessageShow.show("The points to show is null", "用于显示的点为null");
                return;
            }

            //mapPoints.ShowInChart(tchart, null, map, null);
        }

        public override void SetRawData(byte[] dataArray, double[] linedataArray)
        {
            this.dateArray = dataArray;
        }

        public override void GetDefect(ref double start, ref double length)
        {
            start = measureline.start;
            length = measureline.length;
        }
    }

    [Serializable]
    public class ReportBaseSeries
    {
        [NonSerialized]
        protected TChart tchart;

        /**Delegate for the function of clear.*/
        protected delegate void clearCallback();
        /**Delegate for the function of update BScan or TOFD picture.*/
        protected delegate void updatePictureCallBack(double maxPosValue);

        [NonSerialized]
        protected clearCallback clearFunc;
        [NonSerialized]
        protected updatePictureCallBack updatePictureFunc;
        protected int maxScale;  //max yValue buffer supports

        public ReportBaseSeries(TChart tchart)
        {
            this.tchart = tchart;
            maxScale = 0;
        }

        public virtual void initSeries() { }

        public virtual void clear() { }

        public virtual double add(double[] amp,double delay,double range,int type) { return 0; }

        /**Just used for BScan and TOFD.*/
        public virtual void updatePicture(double maxPosValue) { }

        /**Rebuild the nonseriealized datas when read from file.*/
        public virtual bool rebuildNonSeriealizedDatas(TChart chart, double delay, double width) { return true; }

        public virtual void disposemesure()
        { }

        public virtual void SetRawData(byte[] dataArray, double[] linedataArray)
        {

        }

        public virtual void GetDefect(ref double start,ref double length)
        {

        }
    }

    public class ReportStripDateService
    {
        [NonSerialized]
        private int lastIndex;
        [NonSerialized]
        private StripDate lastDate;
        private int endRealPos;
        private double mergeUnit;  //unit for merge

        private int maxNum;  //max value for coder

        private double maxPos; //curPosX must <= maxPos

        private List<StripDate[]> source;  //for original datas

        /**The constructor 
         * @param diameter the diameter of the pipeline, mm
         * .*/
        public ReportStripDateService(double diameter)
        {
            double l = 3.1415926 * diameter;

            mergeUnit = (double)l * ConstParameter.AnglePreUnit / 360;  //distantce for 2°

            endRealPos = 0;
            maxPos = l;

            lastIndex = 0;
            lastDate = new StripDate(-1, -1);

            source = new List<StripDate[]>();

            int maxHeight = (int)(l / ConstParameter.DefaultPosInc * 1.2); //the max num of the array the stroge the datas
            maxNum = maxHeight / ConstParameter.BufferCapacity + 1;
            while (source.Count < maxNum)
            {
                StripDate[] arrays = new StripDate[ConstParameter.BufferCapacity];
                for (int i = 0; i < arrays.Length; i++)
                    arrays[i] = new StripDate(-1, -1);
                source.Add(arrays);
            }
        }

        public void clear()
        {
            lastIndex = 0;
            lastDate = new StripDate(-1, -1);

            source = null;
            GC.Collect();

            source = new List<StripDate[]>();
            while (source.Count < maxNum)
            {
                StripDate[] arrays = new StripDate[ConstParameter.BufferCapacity];
                for (int i = 0; i < arrays.Length; i++)
                    arrays[i] = new StripDate(-1, -1);
                source.Add(arrays);
            }
        }

        public void mergeDates(ref List<StripDate> contain, ref int num, double[] ampdata,int type)
        {
            num = 0;
            int curPosX = 0;
            int bin = type;
            int inc = 1;
            int cellNum = ampdata.Count();
            int numIndex = 0;
            double value;

            if (bin == (int)DAQ_MEAS_MODE.TOF_PEAK)
            {
                for (int i = 0; i < cellNum; i++)
                {
                    value = ampdata[numIndex++];
                    //int tofIndex = (int)(curPosX / ConstParameter.DefaultPosInc) / ConstParameter.BufferCapacity;
                    //int arrayIndex = (int)(curPosX / ConstParameter.DefaultPosInc) % ConstParameter.BufferCapacity;
                    int tofIndex = (int)(curPosX / inc) / ConstParameter.BufferCapacity;    //把DefaultPosInc改为inc
                    int arrayIndex = (int)(curPosX / inc) % ConstParameter.BufferCapacity;
                    while (source.Count <= tofIndex)
                    {
                        StripDate[] arrays = new StripDate[ConstParameter.BufferCapacity];
                        for (int j = 0; j < arrays.Length; j++)
                            arrays[j] = new StripDate(-1, -1);
                        source.Add(arrays);
                    }

                    StripDate[] curArray = source[tofIndex];
                    curArray[arrayIndex].tof = value;
                    curArray[arrayIndex].isTofReceived = true;

                    //if (arrayIndex == 499)
                    //{
                    StripDate date = contain[num++];
                    date.tof = curArray[arrayIndex].tof;
                    date.amp = curArray[arrayIndex].amp;
                    date.index = i;
                    //}

                    curPosX += inc;
                }
                endRealPos = Math.Max(endRealPos, curPosX - inc);
            }
            else if (bin == (int)DAQ_MEAS_MODE.AMP_PERCENT)
            {
                for (int i = 0; i < cellNum; i++)
                {
                    //add to the source
                    value = ampdata[numIndex++];

                    //int ampIndex = (int)(curPosX / ConstParameter.DefaultPosInc) / ConstParameter.BufferCapacity;
                    //int arrayIndex = (int)(curPosX / ConstParameter.DefaultPosInc) % ConstParameter.BufferCapacity;
                    int ampIndex = (int)(curPosX / inc) / ConstParameter.BufferCapacity;    //把DefaultPosInc改为inc
                    int arrayIndex = (int)(curPosX / inc) % ConstParameter.BufferCapacity;
                    while (source.Count <= ampIndex)
                    {
                        StripDate[] arrays = new StripDate[ConstParameter.BufferCapacity];
                        for (int j = 0; j < arrays.Length; j++)
                            arrays[j] = new StripDate(-1, -1);
                        source.Add(arrays);
                    }

                    StripDate[] curArray = source[ampIndex];
                    curArray[arrayIndex].realPos = curPosX;
                    curArray[arrayIndex].amp = value;
                    curArray[arrayIndex].isAmpReceived = true;

                    //merge
                    //int index = (int)(curPosX / mergeUnit);   
                    //int index = (int)(curPosX / inc);   //把mergeUnit改为inc 
                    //curArray[arrayIndex].index = index;
                    //if (arrayIndex == 64)
                    //{
                    //    int dd = index;
                    //}
                    //if (index == lastIndex)
                    //{
                    //    if (value > lastDate.amp)
                    //    {
                    //        lastDate.isMaxInMerge = false;
                    //        lastDate = curArray[arrayIndex];
                    //        lastDate.isMaxInMerge = true;
                    //    }
                    //}
                    //else
                    //{
                    //    //is tof not arrive, just make a note
                    //    //if (!lastDate.isTofReceived)
                    //    //    lastDate.index = lastIndex;

                    //    //arrive, just update
                    //if (arrayIndex == 499)
                    //{
                    StripDate date = contain[num++];
                    date.tof = curArray[arrayIndex].tof;
                    date.amp = curArray[arrayIndex].amp;
                    date.index = i;
                    date.realPos = i;
                    //}

                    //    lastIndex = index;
                    //    lastDate = curArray[arrayIndex];
                    //    lastDate.isMaxInMerge = true;
                    //}

                    curPosX += (int)inc;
                }
                endRealPos = Math.Max(endRealPos, curPosX - (int)inc);
            }
        }
    }

    public class ReportDefect
    {
        public string channel;
        public double start;
        public double length;

        public ReportDefect(RowData row, double start,double length)
        {
            channel = row.Cycle;
            this.start = start;
            this.length = length;
        }
    }
}
     