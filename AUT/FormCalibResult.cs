using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Ascan;

namespace AUT
{
    public partial class FormCalibResult : Form
    {
        private List<SessionInfo> resultSessionList;
        //private List<SessionInfo> showResultSessionList;
        private List<CalibResultInfo> calibResultInfoList;
        private Hashtable MaxValueOfSessions;
        public bool isGainSetDown = false;
        double stardedAmpValue = 0.8;
        public FormCalibResult(List<SessionInfo> SessionList, Hashtable maxValueTable)
        {           
            InitializeComponent();          
            //showResultSessionList = new List<SessionInfo>();
            calibResultInfoList = new List<CalibResultInfo>();
            //this.resultSessionList = SessionList;
            resultSessionList = new List<SessionInfo>();
            foreach (SessionInfo session in SessionList)
            {
                if (session.myHardInfo.AssignedName[0] != 'C' && session.myHardInfo.AssignedName[0] != 'c')
                    this.resultSessionList.Add(session);
            }
            this.MaxValueOfSessions = maxValueTable;
            initControls();
            //this.resultDataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(resultDataGridView_EditingControlShowing);
        }

        private void FormCalibResult_Load(object sender, EventArgs e)
        {
            initControls();
            updateCalibResultInfoList();
            updateResultDataGridView();
        }

        private void initControls()
        {
            areaComboBox.Items.Clear();
            foreach (SessionInfo session in resultSessionList)
            {
                if (session.sessionIndex == 1)      //if the board is TOFD, just ignore it 
                    continue;
                areaComboBox.Items.Add(session.zonename);
            }
            areaComboBox.Items.Add("ALL");
            areaComboBox.SelectedIndex = areaComboBox.Items.Count - 1;
            typeComboBox.SelectedIndex = typeComboBox.Items.Count - 1;
            dircComboBox.SelectedIndex = dircComboBox.Items.Count - 1;
        }

        private void updateCalibResultInfoList()
        {
            for (int k = calibResultInfoList.Count - 1; k >= 0; k--)
                calibResultInfoList.RemoveAt(k);
            //update according to area,direc,etc...
            int typeIndex = typeComboBox.SelectedIndex;
            string area = areaComboBox.SelectedItem.ToString();
            int dircIndex = dircComboBox.SelectedIndex;
            foreach (SessionInfo session in resultSessionList)
            {
                if ((session.type == typeIndex || typeIndex == 4) && (session.LR == dircIndex || dircIndex == 2) && (area == session.zonename || area == "ALL"))
                {
                    CalibResultInfo newResultInfo = new CalibResultInfo();
                    newResultInfo.setCalibResultInfo(session, MaxValueOfSessions);
                    calibResultInfoList.Add(newResultInfo);
                }
            }
        }

        public void updateResultDataGridView()
        {
            for (int i = resultDataGridView.Rows.Count - 1; i >= 0; i--)
                resultDataGridView.Rows.RemoveAt(i);

            for (int i = 0; i < calibResultInfoList.Count; i++)
            {
                resultDataGridView.Rows.Add();
                resultDataGridView.Rows[i].Cells["isCalibrated"].Value = calibResultInfoList[i].isCalibrated;
                //resultDataGridView.Rows[i].Cells["type"].Value = calibResultInfoList[i].type;
                resultDataGridView.Rows[i].Cells["area"].Value = calibResultInfoList[i].area;
                //resultDataGridView.Rows[i].Cells["direction"].Value = calibResultInfoList[i].LR;
                resultDataGridView.Rows[i].Cells["session"].Value = calibResultInfoList[i].sessionName;
                resultDataGridView.Rows[i].Cells["value"].Value = (calibResultInfoList[i].maxValue*100).ToString("0.00");
                resultDataGridView.Rows[i].Cells["calibrateValue"].Value = (calibResultInfoList[i].calibrateValue*100).ToString("0.00");
                string type,dir;
                switch (calibResultInfoList[i].type)
                {
                    case 0:
                        type = "Fill"; break;
                    case 1:
                        type = "HP"; break;
                    case 2:
                        type = "LCP"; break;
                    case 3:
                        type = "ROOT"; break;

                    default:
                        type = ""; break;

                }
                resultDataGridView.Rows[i].Cells["type"].Value = type;

                switch (calibResultInfoList[i].LR)
                { 
                    case 0:
                        dir = "左";break;
                    case 1:
                        dir = "右"; break;
                    default:
                        dir = " "; break;
                }
                resultDataGridView.Rows[i].Cells["direction"].Value = dir;
            }
        }

        private int setNewGain()
        {
            int error_code = 0;
            bool isGainExceeds = false;
            List<string> worrySessionList = new List<string>();
            if (isGainSetDown == true) //if Gain is already set down,then just return; 
                return 1;
            foreach(CalibResultInfo calibResultInfo in calibResultInfoList)
            {
                double newGain = 0;
                double oldgain = 0;
                int sessionIndex;
                int port;
                if (calibResultInfo.isCalibrated == true)
                {
                    SessionHardWare.getIndexPort(calibResultInfo.sessionName, out sessionIndex, out port);
                    if (sessionIndex == -1 || port == -1)
                        return error_code = -1;
                    error_code = GetRecieverDAQ.AnalogGain((uint)sessionIndex, (uint)port, ref oldgain);
                    if (error_code != 0)
                        return error_code;
                    newGain = 20 * Math.Log10(stardedAmpValue / calibResultInfo.maxValue) + oldgain;
                    if (newGain > 84)   //gain can not larger than 84
                    {
                        isGainExceeds = true;
                        worrySessionList.Add(calibResultInfo.sessionName);
                        continue;
                    }
                    error_code = SetReceiverDAQ.AnalogGain((uint)sessionIndex, (uint)port, newGain);
                    if (error_code != 0)
                        return error_code;
                }
            }
            if (isGainExceeds == true)
            {
                string errsession = null;
                foreach (string str in worrySessionList)
                {
                    errsession += str+" ";
                }
                MessageBox.Show("以下通道增益值超出范围，请重新校准增益！" + errsession);
            }
            isGainSetDown = true;
            return error_code;
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCalibResultInfoList();
            updateResultDataGridView();
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCalibResultInfoList();
            updateResultDataGridView();
        }

        private void dircComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCalibResultInfoList();
            updateResultDataGridView();
        }

        private void ensureButton_Click(object sender, EventArgs e)
        {
            int error_code = 0;
            updateisCalibratedColumn();
            error_code = setNewGain();
            if (error_code != 0 && error_code != 1)
            {
                MessageBox.Show("错误：设置增益值失败!");
                return;
            }
            if (error_code == 1)
                MessageBox.Show("增益值已设置!");
            if (error_code == 0)
                 MessageBox.Show("设置增益值成功!");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chooseAllButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < calibResultInfoList.Count; i++)
            {
                calibResultInfoList[i].isCalibrated = true;
                resultDataGridView.Rows[i].Cells["isCalibrated"].Value = calibResultInfoList[i].isCalibrated;
            }
        }

        private void chooseNoneButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < calibResultInfoList.Count; i++)
            {
                calibResultInfoList[i].isCalibrated = false;
                resultDataGridView.Rows[i].Cells["isCalibrated"].Value = calibResultInfoList[i].isCalibrated;
            }
        }

        private void nonCalibrateButton_Click(object sender, EventArgs e)
        {
            //DataGridViewImageColumn picturecolumn = new DataGridViewImageColumn();  
            //picturecolumn.Name = "picture";
            //resultDataGridView.Columns.Add(picturecolumn);   
            //picturecolumn.HeaderText = "图片";   
            ////picturecolumn.Image = System.Drawing.Image.FromFile("路径");
            //((DataGridViewImageCell)this.resultDataGridView.Rows[0].Cells["picture"]).Value = System.Drawing.Image.FromFile(Application.StartupPath + "\\Connect.jpg");
        }

        //private void dataGridView_dbGate_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    DataGridView dgv = sender as DataGridView;

        //    if (dgv.CurrentCell.ColumnIndex == 0)
        //    {
        //        updateisCalibratedColumn();
        //    }
        //}

        private void updateisCalibratedColumn()
        {
            int count = resultDataGridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if ((bool)resultDataGridView.Rows[i].Cells["isCalibrated"].Value == true)
                    calibResultInfoList[i].isCalibrated = true;
                else
                    calibResultInfoList[i].isCalibrated = false;
            }
        }
    }

    public class CalibResultInfo
    {
        public bool isCalibrated;
        public int type;
        public string area;
        public int LR;
        public string sessionName;
        public double maxValue;
        public double calibrateValue;

        public CalibResultInfo()
        {
            isCalibrated = true;
        }

        public void setCalibResultInfo(SessionInfo session, Hashtable maxValueTable)
        {
            this.type = session.type;
            this.area = session.zonename;
            this.LR = session.LR;
            this.sessionName = session.myHardInfo.AssignedName;
            this.maxValue = (double)maxValueTable[sessionName];  //search in hashtable according to sessionName
            this.calibrateValue = 0.8 - maxValue;
        }
    }
}
