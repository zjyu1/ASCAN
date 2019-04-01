using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Steema.TeeChart;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using TChartFastLine = Steema.TeeChart.Styles.FastLine;
using TChartPoints = Steema.TeeChart.Styles.Points;

namespace Ascan
{
    public  class FormMeasurementMap : Form
    {
        protected bool isSaved;

        public bool IsSaved
        {
            get { return isSaved; }
        }

        public virtual void addPoints(MeasureQueueElement measureQueueElement)
        { }

        public virtual bool isBoardNameInMeasureCorrect()
        {
            return true;
        }

        public virtual void startInspect()
        { 
        }

    }


    public class FormCalibrateBase : Form 
    {
        public virtual void addPoints(MeasureQueueElement measureQueueElement)
        { }
    }


    public partial class AscanMeasureMap : FormMeasurementMap
    {
        public static double MaxSingleGateValue;
        public static double MinSingleGateValue;
        public static double MaxDoubleGatesValue;
        public static double MinDoubleGatesValue;

        private MeasurementSet formMeasurementSet;
        private TableLayoutPanel tablePanel;
        private List<MeasurementData> measurementDataList;
        private List<MapRowDatas> mapRowDataList;

        /**This is used to add points as quickly as possible.
         * For example, now we have a packet whose boardID is 2,
         * we just update all TchartSeries in cycleList[2].
         */
        private List<List<SingleGateSeries>> singleCycleList;
        private List<List<DoubleGatesSeries>> doubleCycleList;

        public const int MAXLISTCOUNT = 16;

        public AscanMeasureMap()
        {
            InitializeComponent();
            Rectangle rect = SystemInformation.WorkingArea;
            this.Height = SystemInformation.WorkingArea.Height;
            this.Width = SystemInformation.WorkingArea.Width;  
            measurementDataList = new List<MeasurementData>(MAXLISTCOUNT);
            formMeasurementSet = new MeasurementSet(measurementDataList);
            mapRowDataList = new List<MapRowDatas>();
            singleCycleList = new List<List<SingleGateSeries>>();
            doubleCycleList = new List<List<DoubleGatesSeries>>();

            for (int j = 0; j < SessionInfo.sessionNum; j++)
            {
                List<SingleGateSeries> singleSeries = new List<SingleGateSeries>();
                singleCycleList.Add(singleSeries);

                List<DoubleGatesSeries> doubleSeries = new List<DoubleGatesSeries>();
                doubleCycleList.Add(doubleSeries);
            }

            AscanMeasureMap.MaxSingleGateValue = ConstParameter.MaxAllowedMeasureValue;
            AscanMeasureMap.MinSingleGateValue = ConstParameter.MinAllowedMeasureValue;
            AscanMeasureMap.MaxDoubleGatesValue = ConstParameter.MaxAllowedDoubleGatesValue;
            AscanMeasureMap.MinDoubleGatesValue = ConstParameter.MinAllowedDoubleGatesValue;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            isSaved = true;
        }

        private void FormMeasurementMap_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
            setControls(sender, e);

            tablePanel = new TableLayoutPanel();
            tablePanel.Parent = this.measureShow.Panel2;
            tablePanel.Dock = DockStyle.Fill;
            tablePanel.ColumnCount = 2;
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80f));
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            tablePanel.BackColor = Color.FromArgb(192, 255, 192);
        }

        private void setControls(object sender, EventArgs e)
        {
            int controlWidth;
            int controlHeigh;
            int blackWidth;
            int blackHeight;
            int buttonHeight;

            controlWidth = measureShow.Width / 7;
            controlHeigh = measureShow.Height;

            measureShow.SplitterDistance = controlWidth;

            blackWidth = controlWidth / 30;

            panelInfo.Height = controlHeigh / 10;
            blackHeight = (panelInfo.Height - comboBoxBatch.Height * 3) / 4;
            labelBatch.Width = controlWidth / 5;
            labelBatch.Height = panelInfo.Height / 3;
            labelBatch.Location = new Point(blackWidth, blackHeight);
            comboBoxBatch.Location = new Point(2 * blackWidth + labelBatch.Width, blackHeight);
            comboBoxBatch.Width = controlWidth - 3 * blackWidth - labelBatch.Width;

            labelNum.Width = controlWidth / 5;
            labelNum.Height = panelInfo.Height / 3;
            labelNum.Location = new Point(blackWidth, 2 * blackHeight + comboBoxBatch.Height);
            comboBoxNum.Location = new Point(2 * blackWidth + labelBatch.Width, 2 * blackHeight + comboBoxBatch.Height);
            comboBoxNum.Width = controlWidth - 3 * blackWidth - labelBatch.Width;

            labelConfig.Width = controlWidth / 5;
            labelConfig.Height = panelInfo.Height / 3;
            labelConfig.Location = new Point(blackWidth, 3 * blackHeight + 2 * comboBoxBatch.Height);
            comboBoxConfig.Location = new Point(2 * blackWidth + labelBatch.Width, 3 * blackHeight + 2 * comboBoxBatch.Height);
            comboBoxConfig.Width = controlWidth - 3 * blackWidth - labelBatch.Width;

            panelGrid.Height = controlHeigh / 3;

            panelControl.Height = controlHeigh / 15;
            blackHeight = (panelControl.Height - 2 * checkBoxName.Height) / 3;
            checkBoxName.Location = new Point(blackWidth, blackHeight);
            buttonAdd.Width = (controlWidth - 4 * blackWidth) / 3;
            buttonAdd.Height = checkBoxName.Height;
            buttonAdd.Location = new Point(blackWidth, 2 * blackHeight + checkBoxName.Height);
            buttonAlter.Width = (controlWidth - 4 * blackWidth) / 3;
            buttonAlter.Height = checkBoxName.Height;
            buttonAlter.Location = new Point(2 * blackWidth + buttonAdd.Width, 2 * blackHeight + checkBoxName.Height);
            buttonDelete.Width = (controlWidth - 4 * blackWidth) / 3;
            buttonDelete.Height = checkBoxName.Height;
            buttonDelete.Location = new Point(3 * blackWidth + 2 * buttonAdd.Width, 2 * blackHeight + checkBoxName.Height);

            blackHeight = controlHeigh / 40;
            buttonHeight = controlHeigh / 20;
            inspectStop.Location = new Point(0, 3 * controlHeigh / 4 - buttonHeight);
            inspectStop.Width = controlWidth;
            inspectStop.Height = buttonHeight;
            reinspect.Location = new Point(0, 3 * controlHeigh / 4 -  2 * buttonHeight - blackHeight);
            reinspect.Width = controlWidth;
            reinspect.Height = buttonHeight;
            currentNum.Location = new Point(0, 3 * controlHeigh / 4 + blackHeight);
            currentNum.Width = controlWidth;
            currentNum.Height = buttonHeight;
            inspectStatus.Location = new Point(0, 3 * controlHeigh / 4 + 2 * blackHeight + buttonHeight);
            inspectStatus.Width = controlWidth;
            inspectStatus.Height = buttonHeight;
        }

        /**Clear the datas and remove controls.*/
        private void clearDatas()
        {
            for (int i = mapRowDataList.Count - 1; i >= 0; i--)
            {
                mapRowDataList[i].removeControl();
            }
            mapRowDataList.Clear();
            measurementDataList.Clear();
            tablePanel.RowCount = 0;
            clearCycelList();
        }

        /**Clear the cycle list.*/
        private void clearCycelList()
        {
            if (singleCycleList.Count != 0)
            {
                for (int i = 0; i < singleCycleList.Count; i++)
                {
                    singleCycleList[i].Clear();
                }
            }

            if (doubleCycleList.Count != 0)
            {
                for (int i = 0; i < doubleCycleList.Count; i++)
                {
                    doubleCycleList[i].Clear();
                }
            }
        }

        /**Change the tableLayouts when source datas changed.
         * If the source datas are just edited, we just update 
         * the tableLayouts. If the source datas are added, we 
         * shoule create a new mapRowDatas.
         */
        private void refreshTabelLayout()
        {
            for (int i = 0; i < measurementDataList.Count; i++)
            {
                if (i < mapRowDataList.Count)
                {
                    mapRowDataList[i].updataSource(measurementDataList[i], singleCycleList, doubleCycleList);
                }

                else
                {
                    tablePanel.RowCount++;
                    tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                    MapRowDatas mapRowDatas = new MapRowDatas(tablePanel, measurementDataList[i], singleCycleList, doubleCycleList);
                    mapRowDataList.Add(mapRowDatas);
                }
            }
        }

        private void groupToolStrip_Click(object sender, EventArgs e)
        {
            //检测时该菜单不应该响应
            if (MainForm.IsStart)
            {
                MessageShow.show("Measurement has been started, please stop it first.", "检测已启动，请先停止检测。");
                return;
            }

            if (!isSaved)
            {
                DialogResult result = MessageShow.showSelecting("Map datas are not saved and setting the parameters will clear these datas. Do you want to continue?", 
                    "融合图未保存，重新设置融合参数将会清空数据。是否继续?");
                if (result == DialogResult.No)
                    return;
            }
            formMeasurementSet.ShowDialog();
            clearCycelList();
            refreshTabelLayout();
            MultiLanguage.getNames(this);
        }

        public override void addPoints(MeasureQueueElement measureQueueElement)
        {
            int boardIndex = measureQueueElement.boardIndex;
            int id = (int)measureQueueElement.gatePacket.head.id;

            //Single gate.
            if ((id == (int)PacketId.AGate) || (id == (int)PacketId.BGate) || (id == (int)PacketId.CGate) || (id == (int)PacketId.IGate))
            {
                if (singleCycleList == null)
                    return;
                if ((boardIndex < 0) || (boardIndex >= singleCycleList.Count))
                    return;

                List<SingleGateSeries> singleLists = singleCycleList[boardIndex];

                if (singleLists.Count == 0)
                    return;

                for (int i = 0; i < singleLists.Count; i++)
                    singleLists[i].updataFastLine(measureQueueElement.gatePacket, boardIndex);
            }
            else if ((id == (int)PacketId.BA2Gate) || (id == (int)PacketId.AI2Gate) || (id == (int)PacketId.BI2Gate) || (id == (int)PacketId.CI2Gate))
            {
                if (doubleCycleList == null)
                    return;
                if ((boardIndex < 0) || (boardIndex >= doubleCycleList.Count))
                    return;

                List<DoubleGatesSeries> doubleLists = doubleCycleList[boardIndex];

                if (doubleLists.Count == 0)
                    return;

                for (int i = 0; i < doubleLists.Count; i++)
                    doubleLists[i].updataFastLine(measureQueueElement.gatePacket, boardIndex);
            }
            else
                return;

            isSaved = false;
        }

        /**Open file.*/
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
                clearDatas();
                ReadFromXML(fileName);
                loadResult = formMeasurementSet.formReload();
                if (loadResult)
                {
                    MessageShow.show("Some cycel names are different from these names we set before, please reset these cycel names.",
                        "某些通道别名与先前设置不符，请重新设置。");
                }
            }
            isSaved = false;
        }

        /**Save file.*/
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
                writeToXML(saveFileDialog1.FileName);
            }
            isSaved = true;
        }

        private void ReadFromXML(string file)
        {
            AscanMeasureMap.MaxSingleGateValue = SystemConfig.GetConfigData(file, "maxSingleGateValue", 0.0);
            AscanMeasureMap.MinSingleGateValue = SystemConfig.GetConfigData(file, "minSingleGateValue", 0.0);
            AscanMeasureMap.MaxDoubleGatesValue = SystemConfig.GetConfigData(file, "maxDoubleGatesValue", 0.0);
            AscanMeasureMap.MinDoubleGatesValue = SystemConfig.GetConfigData(file, "minDoubleGatesValue", 0.0);

            List<MeasurementData> tmpMapList = (List<MeasurementData>)SystemConfig.ReadBase64Data(file, "measurementDataList");
            List<MapRowDatas> tmpRowList = (List<MapRowDatas>)SystemConfig.ReadBase64Data(file, "mapRowDataList");

            rebuildMeasureDatas(tmpMapList, tmpRowList);
        }

        private void writeToXML(string file)
        {
            string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
            SystemConfig.WriteConfigData(file, "date", date);
            SystemConfig.WriteConfigData(file, "maxSingleGateValue", AscanMeasureMap.MaxSingleGateValue.ToString());
            SystemConfig.WriteConfigData(file, "minSingleGateValue", AscanMeasureMap.MinSingleGateValue.ToString());
            SystemConfig.WriteConfigData(file, "maxDoubleGatesValue", AscanMeasureMap.MaxDoubleGatesValue.ToString());
            SystemConfig.WriteConfigData(file, "minDoubleGatesValue", AscanMeasureMap.MinDoubleGatesValue.ToString());
            SystemConfig.WriteBase64Data(file, "measurementDataList", measurementDataList);
            SystemConfig.WriteBase64Data(file, "mapRowDataList", mapRowDataList);
        }

        /**Update datas source.*/
        private void rebuildMeasureDatas(List<MeasurementData> mapList, List<MapRowDatas> rowList)
        {
            bool rebuildResult;
            if ((mapList == null) || (rowList == null))
                return;

            for (int i = 0; i < mapList.Count; i++)
            {
                measurementDataList.Add(mapList[i]);
            }

            for (int i = 0; i < rowList.Count; i++)
            {
                tablePanel.RowCount++;
                tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                rebuildResult = rowList[i].rebuildNonSeriealizedDatas(tablePanel, singleCycleList, doubleCycleList);

                if (rebuildResult)
                    mapRowDataList.Add(rowList[i]);
                else
                    MessageShow.show("Rebuild nonseriealized datas failed. Index:" + i, "重构非序列化数据失败。索引：" + i);
            }
        }

        /**Check the cycel name of MeasurementData.*/
        //Sometimes we get the datas from file, but the cycles'name are not the same with those we set.
        public override bool isBoardNameInMeasureCorrect()
        {
            int index;
            if ((measurementDataList == null) || (measurementDataList.Count == 0))
                return true;

            foreach (MeasurementData data in measurementDataList)
            {
                foreach (RowData rowData in data.rowDataList)
                {
                    if (rowData.activity)
                    {
                        index = SessionHardWare.getUserIndex(rowData.Cycle);
                        if (index == -1)
                            return false;
                    }
                }
            }
            return true;
        }

        private void addToGridView(int num, string status)
        {
            object[] values = new object[2];
            values[0] = num;
            values[1] = status;
            dataGridShow.Rows.Add(values);
        }

        public override void startInspect()
        {
            AscanMeasureMap.MaxSingleGateValue = ConstParameter.MaxAllowedMeasureValue;
            AscanMeasureMap.MinSingleGateValue = ConstParameter.MinAllowedMeasureValue;
            AscanMeasureMap.MaxDoubleGatesValue = ConstParameter.MaxAllowedDoubleGatesValue;
            AscanMeasureMap.MinDoubleGatesValue = ConstParameter.MinAllowedDoubleGatesValue;

            inspectStatus.BackColor = Color.FromArgb(192, 255, 192);
            inspectStatus.Enabled = true;
            if (MultiLanguage.lang == "EN")
                inspectStatus.Text = "Inspecting";
            else
                inspectStatus.Text = "正在检测";
        }

        public void stopInspect()
        {
            inspectStatus.BackColor = Color.FromArgb(224, 224, 224);
            inspectStatus.Enabled = false;
            if (MultiLanguage.lang == "EN")
                inspectStatus.Text = "DisInspecting";
            else
                inspectStatus.Text = "未在检测";
        }
    }

    [Serializable]
    public class MapRowDatas
    {
        [NonSerialized] private TChart newTchart;
        [NonSerialized] private DataGridView gridView;
        [NonSerialized] private Label label;
        [NonSerialized] private TableLayoutPanel tableLayout;
        [NonSerialized] private int rowIndex;
        public MeasurementData measurementData;
        private BaseSeries tchartSeries;

        public MapRowDatas(TableLayoutPanel tableLayout, MeasurementData measurementData, List<List<SingleGateSeries>> singleList, List<List<DoubleGatesSeries>> doubleList)
        {
            this.tableLayout = tableLayout;
            this.measurementData = measurementData;
            rowIndex = tableLayout.RowCount - 1;

            initControls();

            if (!measurementData.isDoubleGates)
            {
                tchartSeries = new SingleGateSeries(newTchart);
                tchartSeries.bindToList(measurementData.rowDataList, singleList, doubleList);
            }
            else
            {
                tchartSeries = new DoubleGatesSeries(newTchart);
                tchartSeries.bindToList(measurementData.rowDataList, singleList, doubleList);
            }
        }


        /**Rebuild the nonseriealized datas when read from file.*/
        public bool rebuildNonSeriealizedDatas(TableLayoutPanel tableLayout, List<List<SingleGateSeries>> singleList, List<List<DoubleGatesSeries>> doubleList)
        {
            if ((measurementData == null) || (tchartSeries == null) || (singleList == null) || (doubleList == null))
                return false;

            this.tableLayout = tableLayout;
            rowIndex = tableLayout.RowCount - 1;

            initControls();

            bool result = tchartSeries.rebuildNonSeriealizedDatas(newTchart);
            if (!result)
                return false;

            tchartSeries.bindToList(measurementData.rowDataList, singleList, doubleList);

            return true;
        }

        private void initControls()
        {
            newTchart = new TChart();
            newTchart.Axes.Left.Minimum = 0;
            newTchart.Axes.Bottom.Minimum = 0;
            newTchart.Aspect.View3D = false;
            newTchart.Header.Visible = false;
            newTchart.Legend.Visible = false;
            
            newTchart.Axes.Bottom.Title.Text = "mm";
            newTchart.Axes.Left.Title.Text = "%";
            newTchart.Axes.Left.Grid.Visible = true;
            newTchart.Axes.Bottom.Grid.Visible = true;
            //newTchart.Click += new EventHandler(newTchart_Click);  //注册事件
            newTchart.BackColor = Color.FromArgb(192, 255, 192);
            tableLayout.Controls.Add(newTchart, 0, rowIndex);
            newTchart.Dock = DockStyle.Fill;
            newTchart.Legend.Visible = false;

            newTchart.MouseClick += new MouseEventHandler(newTchart_MouseClick);

            //textBox = new TextBox();
            //textBox.Multiline = true;
            //textBox.ReadOnly = true;
            //textBox.BackColor = Color.FromArgb(192, 255, 192);
            //textBox.Font = new Font("微软雅黑", 10f);
            //textBox.Text = textString;
            //tableLayout.Controls.Add(textBox, 1, rowIndex);
            //textBox.Dock = DockStyle.Fill;

            gridView = new DataGridView();
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.AllowUserToAddRows = false;
            gridView.BackgroundColor = Color.FromArgb(192, 255, 192);
            gridView.Font = new Font("微软雅黑", 9f);
            tableLayout.Controls.Add(gridView, 1, rowIndex);
            gridView.Dock = DockStyle.Fill;
            addGridItems();

            label = new Label();
            label.Visible = false;
            label.AutoSize = true;
            label.Font = new Font("微软雅黑", 10f);
            label.BackColor = Color.White;
            label.Parent = newTchart;
        }

        private void addGridItems()
        {
            DataTable tableShape;
            if ((measurementData == null) || (measurementData.rowDataList[0] == null))
                return;

            if (gridView.DataSource != null)
                tableShape = (DataTable)gridView.DataSource;
            else
                tableShape = new DataTable();

            tableShape.Columns.Clear();
            tableShape.Rows.Clear();


            /**Get all properties.*/
            PropertyInfo[] props= measurementData.rowDataList[0].GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                tableShape.Columns.Add(prop.Name, prop.PropertyType);
            }

            for (int i = 0; i < measurementData.rowDataList.Count; i++)
            {
                if (!measurementData.rowDataList[i].activity)
                    continue;

                object item = measurementData.rowDataList[i];
                object[] values = new object[props.Length];

                for (int j = 0; j < values.Length; j++)
                    values[j] = props[j].GetValue(item, null);

                tableShape.Rows.Add(values);
            }

            gridView.DataSource = tableShape;

            //turn off the function of autoSorting!
            for (int i = 0; i < gridView.Columns.Count; i++)
                gridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void newTchart_MouseClick(object sender, MouseEventArgs e)
        {
            string info;
            label.Visible = false;
            info = tchartSeries.getInfo(e.X, e.Y);
            if ("".Equals(info))
                return;

            label.Location = new Point(e.X, e.Y);
            label.Text = info;
            label.Visible = true;
        }

        public void removeControl()
        {
            if ((newTchart != null) && (gridView != null))
            {
                tableLayout.Controls.Remove((Control)newTchart);
                tableLayout.Controls.Remove((Control)gridView);
            }
        }

        /**When the measurementData is changed, just update it and the text, fastline.
         * We must clear the cycelList before using this function.
         */
        public void updataSource(MeasurementData measurementData, List<List<SingleGateSeries>> singleList, List<List<DoubleGatesSeries>> doubleList)
        {
            this.measurementData = measurementData;

            if (!measurementData.isDoubleGates)
            {
                if (tchartSeries is SingleGateSeries)
                {
                    tchartSeries.clear();
                    tchartSeries.bindToList(measurementData.rowDataList, singleList, doubleList);
                }
                else
                {
                    tchartSeries.removeSeries();

                    tchartSeries = new SingleGateSeries(newTchart);
                    tchartSeries.bindToList(measurementData.rowDataList, singleList, doubleList);
                }
            }
            else
            {
                if (tchartSeries is SingleGateSeries)
                {
                    tchartSeries.removeSeries();

                    tchartSeries = new DoubleGatesSeries(newTchart);
                    tchartSeries.bindToList(measurementData.rowDataList, singleList, doubleList);
                }
                else
                {
                    tchartSeries.clear();
                    tchartSeries.bindToList(measurementData.rowDataList, singleList, doubleList);
                }
            }
            addGridItems();
        }
    }

    public class MeasureFastMatch
    {
        public int boardID;
        public Source source;
        public int port;

        public MeasureFastMatch(int id, int port, Source source)
        {
            this.boardID = id;
            this.port = port;
            this.source = source;
        }
    }
}
