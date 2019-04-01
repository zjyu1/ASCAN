using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ascan;

namespace AUT
{
    public partial class FormStripSet : Form
    {
        //This is a Singleton.
        private volatile static FormStripSet instance;
        //Used under multiThreads
        private static readonly object lockHelper = new object();

        private List<RowControl> rowControlsList;
        private List<RowData> rowDatasList;

        public FormStripSet(List<RowData> rowDatasList)
        {
            InitializeComponent();

            this.rowDatasList = rowDatasList;

            rowControlsList = new List<RowControl>();

            RowControl newRow = new RowControl(splitContainer1.Panel1);
            rowControlsList.Add(newRow);
        }

        /**Return the singleton.*/
        public static FormStripSet CreateInstance(List<RowData> rowDatasList)
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                        instance = new FormStripSet(rowDatasList);
                }
            }
            return instance;
        }

        private void clear()
        {
            if (rowControlsList.Count != 0)
            {
                for (int i = rowControlsList.Count - 1; i >= 0; i--)
                {
                    rowControlsList[i].remove();
                    rowControlsList.RemoveAt(i);
                }
            }

            if (rowDatasList != null)
                rowDatasList.Clear();
        }

        /**Add a new row.*/
        private void btAdd_Click(object sender, EventArgs e)
        {
            RowControl newRow = new RowControl(splitContainer1.Panel1);
            rowControlsList.Add(newRow);
        }

        /**Delete the last row.*/
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (rowControlsList.Count == 0)
                return;

            rowControlsList[rowControlsList.Count - 1].remove();
            rowControlsList.RemoveAt(rowControlsList.Count - 1);
        }

        /**Save to file.*/
        private void btSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filePath = Application.StartupPath + @"\StripMap";
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
            saveFileDialog1.Filter = "stp文件(*.mmp)|*.stp|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                writeToXML(saveFileDialog1.FileName);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string filePath = Application.StartupPath + @"\StripMap";
            openFileDialog1.Filter = "stp文件(*.mmp)|*.stp|所有文件(*.*)|*.*";

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
                string fileName = openFileDialog1.FileName;
                clear();
                ReadFromXML(fileName);
            }
        }

        //Save to rowDataList
        private void FormStripSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((rowControlsList == null)||(rowDatasList == null))
                return;

            rowDatasList.Clear();

            bool result = true;
            foreach (RowControl rowControl in rowControlsList)
            {
                if (!rowControl.IsActivity)
                    continue;

                RowData rowData = new RowData();
                result = rowControl.getRowData(rowData);

                if (!result)
                {
                    MessageShow.show("Wrong strip map datas!","带状图配置错误！");
                    e.Cancel = true;
                    break;
                }

                rowDatasList.Add(rowData);
            }
        }

        private void writeToXML(string file)
        {
            FormStripSet_FormClosing(null, null);
            SystemConfig.WriteBase64Data(file, "rowDatasList", rowDatasList);
        }

        private void ReadFromXML(string file)
        {
            if (rowDatasList == null)
                return;

            rowDatasList.Clear();

            List<RowData> tmpRowList = (List<RowData>)SystemConfig.ReadBase64Data(file, "rowDatasList");

            for (int i = 0; i < tmpRowList.Count; i++)
            {
                RowControl newRow = new RowControl(splitContainer1.Panel1);
                newRow.setRowData(tmpRowList[i]);
                rowControlsList.Add(newRow);
                rowDatasList.Add(tmpRowList[i]);
            }
        }
    }

    public class RowControl
    {
        private Panel panel;
        private ComboBox cycel;
        private ComboBox source;
        private ComboBox mode;
        private Panel pActivity;
        private CheckBox activity;

        public bool IsActivity
        {
            get
            {
                if (activity == null)
                    return false;
                else
                    return activity.Checked;
            }
        }

        public RowControl(SplitterPanel parent)
        {
            panel = new Panel();
            panel.Size = new Size(600, 27);
            panel.Parent = parent;
            panel.Dock = DockStyle.Top;
            panel.BringToFront();

            initControl();
            addSourceItems();
            addModeItems();
            addCycelItems();
        }

        private void initControl()
        {
            cycel = new ComboBox();
            cycel.Size = new Size(150, 27);
            cycel.Font = new Font("微软雅黑", 9f);
            cycel.DropDownStyle = ComboBoxStyle.DropDownList;
            cycel.Parent = panel;
            cycel.Location = new Point(0, 0);

            source = new ComboBox();
            source.Size = new Size(150, 27);
            source.Font = new Font("微软雅黑", 9f);
            source.DropDownStyle = ComboBoxStyle.DropDownList;
            source.Parent = panel;
            source.Location = new Point(150, 0);

            mode = new ComboBox();
            mode.Size = new Size(150, 27);
            mode.Font = new Font("微软雅黑", 9f);
            mode.DropDownStyle = ComboBoxStyle.DropDownList;
            mode.Parent = panel;
            mode.Location = new Point(300, 0);

            pActivity = new Panel();
            pActivity.Parent = panel;
            pActivity.Size = new Size(150, 27);
            pActivity.BackColor = Color.AliceBlue;
            pActivity.BorderStyle = BorderStyle.FixedSingle;
            pActivity.Location = new Point(450, 0);

            activity = new CheckBox();
            activity.Parent = pActivity;
            activity.Location = new Point(75, 0);
            activity.Checked = true;
        }

        private void addSourceItems()
        {
            if (source == null)
                return;

            if (source.Items.Count != 0)
                source.Items.Clear();

            source.Items.Add(Source.GateI);
            source.Items.Add(Source.GateA);
            source.Items.Add(Source.GateB);
            source.Items.Add(Source.GateC);
        }

        private void addModeItems()
        {
            if (mode == null)
                return;

            if (mode.Items.Count != 0)
                mode.Items.Clear();

            mode.Items.Add(Mode.Strip);
            mode.Items.Add(Mode.BScan);
            mode.Items.Add(Mode.TOFD);
            mode.Items.Add(Mode.Couple);
        }

        private void addCycelItems()
        {
            if (cycel == null)
                return;

            if (cycel.Items.Count != 0)
                cycel.Items.Clear();

            string assignName;
            for(int i = 0; i < SessionInfo.portNum; i++)
            {
                assignName = SessionHardWare.getSessionName(i);
                if(assignName != null)
                    cycel.Items.Add(assignName);
            }

        }

        public bool getRowData(RowData rowData)
        {
            if (cycel == null || source == null || mode == null || rowData == null)
                return false;

            if (cycel.SelectedIndex < 0 || source.SelectedIndex < 0 || mode.SelectedIndex < 0)
                return false;

            rowData.Cycle = this.cycel.SelectedItem.ToString();
            rowData.Source = (Source)this.source.SelectedItem;
            rowData.Mode = (Mode)this.mode.SelectedItem;
            rowData.Activity = this.activity.Checked;

            return true;
        }

        public bool setRowData(RowData rowData)
        {
            if (cycel == null || source == null || mode == null || rowData == null)
                return false;

            this.cycel.SelectedItem = rowData.Cycle;
            this.source.SelectedItem = rowData.Source;
            this.mode.SelectedItem = rowData.Mode;
            this.activity.Checked = rowData.Activity;

            return true;
        }

        public void remove()
        {
            if(panel == null)
                return;

            if ((pActivity == null) && (activity == null))
                return;

            pActivity.Controls.Remove(activity);

            for (int i = panel.Controls.Count - 1; i >= 0; i--)
                panel.Controls.RemoveAt(i);

            if(panel != null)
                panel.Parent.Controls.Remove(panel);
        }
    }

    [Serializable]
    public class RowData
    {
        private string cycle;
        private Source source;
        private Mode mode;
        private bool activity;

        public bool Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        public string Cycle
        {
            get { return cycle; }
            set { cycle = value; }
        }
        public Source Source
        {
            get { return source; }
            set { source = value; }
        }
        public Mode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
    }

    public enum Source
    {
        GateI,
        GateA,
        GateB,
        GateC,
        Error
    }

    public enum Mode
    {
        Strip,
        BScan,
        TOFD,
        Couple
    }
}
