using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ascan
{
    public partial class MeasurementSet : Form
    {
        public List<MeasurementData> measurementDataList;
        public const int MAXLISTCOUNT = 16;
        public const int MAXROWCOUNT = 10;

        private MeasurementData currentMeasData;
        private int currentIndex;
        private int currentRow;

        //when we create a new table, some function will 
        //not response to the changes of combobox and checkbox.
        private bool isResponse;

        public MeasurementSet(List<MeasurementData> measurementDataList)
        {
            InitializeComponent();
            this.measurementDataList = measurementDataList;
            currentIndex = 0;
            currentRow = 1;

            isResponse = false;
            addNewMeasurementDataToList();
            refreshMeasureList();
            initializeCycleBox();
            isResponse = true;
        }

        /**Add the assignedNames of all the boards.*/
        private void initializeCycleBox()
        {
            string controlName;
            string assignName;
            for (int i = 1; i <= MAXROWCOUNT; i++)
            {
                controlName = "cbCycle" + i;
                Control[] controls = this.Controls.Find(controlName, true);
                foreach (Control control in controls)
                {
                    if(control is ComboBox)
                    {
                        (control as ComboBox).Items.Clear();
                        for (int j = 0; j < SessionInfo.portNum; j++)
                        {
                            assignName = SessionHardWare.getSessionName(j);
                            if(assignName != null)
                                (control as ComboBox).Items.Add(assignName);
                        }
                    }
                }
            }
        }

        private void MeasurementSet_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }

        private void clearDatas()
        {
            string controlName;
            Control control;
            for (int i = 1; i <= MAXROWCOUNT; i++)
            {
                controlName = "panelRow" + i;
                control = splitContainer2.Panel1.Controls[controlName];
                if (control is Panel)
                {
                    initRowItem(control as Panel);
                    (control as Panel).Visible = false;
                }
            }
            currentMeasData = null;
            currentIndex = 0;
            currentRow = 0;
            refreshMeasureList();
        }

        /**When the datas are loaded from the file, this funcion make the table lists and show it.*/
        public bool formReload()
        {
            bool isCycelChanged = false;
            bool setResult;
            string controlName;
            List<RowData> rowList;
            Control control;

            isResponse = false;
            clearDatas();
            for (int j = 1; j <= measurementDataList.Count; j++)
            {
                currentMeasData = measurementDataList[j - 1];
                rowList = currentMeasData.rowDataList;
                currentIndex = j;
                currentRow = rowList.Count;

                for (int i = 1; i <= MAXROWCOUNT; i++)
                {
                    controlName = "panelRow" + i;
                    control = splitContainer2.Panel1.Controls[controlName];
                    if (control is Panel)
                    {
                        if (i <= currentRow)
                        {
                            setResult = setRowItem((Panel)control, rowList[i - 1]);
                            if (setResult)
                                isCycelChanged = true;
                            (control as Panel).Visible = true;
                        }
                        else
                            (control as Panel).Visible = false;
                    }
                }
            }
            setCurrentRadionButtonChecked();
            isResponse = true;
            return isCycelChanged;
        }

        /**Add a new measurement data to the list and inital the table.*/
        private void addNewMeasurementDataToList()
        {
            string controlName;
            Control control; 

            for (int i = currentRow; i > 0; i--)
            {
                controlName = "panelRow" + i;
                control = splitContainer2.Panel1.Controls[controlName];
                if (control is Panel)
                {
                    initRowItem((Panel)control);
                    (control as Panel).Visible = false;
                }
            }
            panelRow1.Visible = true;

            currentMeasData = new MeasurementData();
            measurementDataList.Add(currentMeasData);
            currentIndex++;
            currentRow = 1;
            RowData newRowData = new RowData();
            currentMeasData.rowDataList.Add(newRowData);
            currentMeasData.isChagesSaved = false;
        }

        /**Initial the specified row's item.
         * @param father the specified row's father panel
         */
        private void initRowItem(Panel father)
        {
            foreach (Control control in father.Controls)
            {
                if (control is ComboBox)
                    ((ComboBox)control).SelectedIndex = -1;
                else if (control is Panel)
                {
                    foreach (Control subControl in control.Controls)
                    {
                        if (subControl is CheckBox)
                            ((CheckBox)subControl).Checked = false;
                    }
                }
            }
        }

        /**Set the specified row's item.
         * @param father the specified row's father panel
         * @param rowData the data source
         */
        private bool setRowItem(Panel father, RowData rowData)
        {
            bool isCycelChanged = false;
            foreach (Control control in father.Controls)
            {
                if (control is ComboBox)
                {
                    if (((ComboBox)control).Name.Contains("cbCycle"))
                    {
                        if (((ComboBox)control).Items.IndexOf(rowData.Cycle) == -1)
                        {
                            isCycelChanged = true;
                            continue;
                        }
                        ((ComboBox)control).Text = rowData.Cycle;
                    }
                    else if (((ComboBox)control).Name.Contains("cbSource"))
                        ((ComboBox)control).SelectedIndex = (int)rowData.Source;
                    else if (((ComboBox)control).Name.Contains("cbMode"))
                        ((ComboBox)control).SelectedIndex = (int)rowData.Mode;
                }
                else if (control is Panel)
                {
                    foreach (Control subControl in control.Controls)
                    {
                        if (subControl is CheckBox)
                            ((CheckBox)subControl).Checked = rowData.activity;
                    }
                }
            }
            return isCycelChanged;
        }

        /**Set the radionbutton of current handling measurement data to checked.*/
        private void setCurrentRadionButtonChecked()
        {
            string controlName;
            Control control;

            controlName = "radioBList" + currentIndex;
            control = splitContainer1.Panel1.Controls[controlName];
            if (control is RadioButton)
                (control as RadioButton).Checked = true;
        }

        /**When add a new  measurement data, we use this function to initial the radionbutton's enable.*/
        private void refreshMeasureList()
        {
            int count = measurementDataList.Count;
            if (count > MAXLISTCOUNT)
            {
                return;
            }
            for (int i = 1; i <= count; i++)
            {
                string controlName = "radioBList" + i;
                Control control = splitContainer1.Panel1.Controls[controlName];
                if (control is RadioButton)
                {
                    (control as RadioButton).Enabled = true;
                }
            }
            for (int i = count + 1; i <= MAXLISTCOUNT; i++)
            {
                string controlName = "radioBList" + i;
                Control control = splitContainer1.Panel1.Controls[controlName];
                if (control is RadioButton)
                {
                    (control as RadioButton).Enabled = false;
                }
            }
        }

        /**When the button of NewTable clicked, this function is called.*/
        private void buttonNewTable_Click(object sender, EventArgs e)
        {

            int oldIndex;

            if (!currentMeasData.isChagesSaved)
            {
                MessageShow.show("Please save current datas first!", "请先保存当前配置！");
                return;
            }

            isResponse = false;
            oldIndex = currentIndex;
            currentIndex = measurementDataList.Count;
            if (currentIndex == MAXLISTCOUNT)
            {
                MessageShow.show("The count is out of range!", "带状图个数超过最大值！");
                currentIndex = oldIndex;
                return;
            }

            addNewMeasurementDataToList();
            refreshMeasureList();

            setCurrentRadionButtonChecked();

            isResponse = true;
        }

        /**When the button of AddRow clicked, this function is called to add a new row.*/
        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            if (++currentRow > MAXROWCOUNT)
            {
                MessageShow.show("The row is out of range!", "行数超过最大限定！");
                currentRow--;
                return;
            }
            
            string controlName = "panelRow" + currentRow;
            Control control = splitContainer2.Panel1.Controls[controlName];
            if (control is Panel)
            {
                initRowItem(control as Panel);
                (control as Panel).Visible = true;
            }
            currentMeasData.isChagesSaved = false;

            RowData newRowData = new RowData();
            currentMeasData.rowDataList.Add(newRowData);
        }

        /**When the button of Save clicked, this function is called to save all the datas of the table.*/
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string controlName;
            string panelName;
            Control control;
            Control controlPanel;
            List<RowData> rowList = currentMeasData.rowDataList;
            for (int i = 1; i <= rowList.Count; i++)
            {
                panelName = "panelRow" + i;
                controlPanel = splitContainer2.Panel1.Controls[panelName];

                controlName = "cbCycle" + i;
                control = controlPanel.Controls[controlName];
                if (control is ComboBox)
                {
                    rowList[i - 1].Cycle = (control as ComboBox).Text;
                }

                controlName = "cbSource" + i;
                control = controlPanel.Controls[controlName];
                if (control is ComboBox)
                {
                    rowList[i - 1].Source = (Source)(control as ComboBox).SelectedIndex;
                }

                controlName = "cbMode" + i;
                control = controlPanel.Controls[controlName];
                if (control is ComboBox)
                {
                    rowList[i - 1].Mode = (Mode)(control as ComboBox).SelectedIndex;
                }

                controlName = "pActivity" + i;
                control = controlPanel.Controls[controlName];
                if (control is Panel)
                {
                    foreach (Control subControl in control.Controls)
                    {
                        if (subControl is CheckBox)
                            rowList[i - 1].activity = ((CheckBox)subControl).Checked;
                    }
                }
            }
            if (!isMearDataCorrect())
            {
                MessageShow.show("The data of the tabel is missing or repeating!", "表中数据有遗漏或重复！");
                return;
            }
            if (!haveCheckedOne())
            {
                DialogResult dialogResult = MessageShow.showSelecting("No row is selected, want to continue?", "没有一行被选中，是否继续？");
                if(dialogResult == System.Windows.Forms.DialogResult.No)
                return;
            }
            if (!isSourceSameType())
            {
                MessageShow.show("The sources of the list are not the same type, please check!", "列表中数据源类型不一致，请检查！");
                return;
            }

            for (int i = 0; i < rowList.Count; i++)
            {
                if (rowList[i].activity)
                {
                    int type = getSourceType(rowList[i].Source);
                    if (type == 1)
                        currentMeasData.isDoubleGates = false;
                    else
                        currentMeasData.isDoubleGates = true;
                    break;
                }
            }

            currentMeasData.isChagesSaved = true;
            MessageShow.show("Config datas saved successfully.", "配置数据保存成功。");
        }

        /**Change the datas of the table accroding to the specified radionbutton.*/
        private void showSelectedTable(object sender, EventArgs e)
        {
            string controlName;
            int tableIndex;
            List<RowData> rowList;
            Control control;
            RadioButton radionButton;

            if (sender is RadioButton)
                radionButton = (RadioButton)sender;
            else
                return;
            if (!radionButton.Checked)
                return;  // If the button is unchecked, we just do nothing beacuse we use radioButton.
            if (!isResponse)
                return;  // If isResponse is false, it means we just ignorge the change.

            if (!currentMeasData.isChagesSaved)
            {
                isResponse = false;
                setCurrentRadionButtonChecked();
                MessageShow.show("Please save current datas first!", "请先保存当前配置！");
                isResponse = true;
                return;
            }

            try
            {
                string str = radionButton.Tag.ToString();
                tableIndex = Convert.ToInt32(str);
                if (tableIndex > measurementDataList.Count)
                    return;
            }
            catch
            {
                MessageShow.show("Error of CheckBox CheckedChanged!", "列表TAG值异常！");
                return;
            }

            isResponse = false; 
            currentMeasData = measurementDataList[tableIndex - 1];
            rowList = currentMeasData.rowDataList;
            currentIndex = tableIndex;
            currentRow = rowList.Count;

            for (int i = 1; i <= MAXROWCOUNT; i++)
            {
                controlName = "panelRow" + i;
                control = splitContainer2.Panel1.Controls[controlName];
                if (control is Panel)
                {
                    if (i <= currentRow)
                    {
                        setRowItem((Panel)control, rowList[i - 1]);
                        (control as Panel).Visible = true;
                    }
                    else
                        (control as Panel).Visible = false;
                }
            }

            setCurrentRadionButtonChecked();
            isResponse = true; 
        }

        /**Pointing out that the current measurement datas have changed.*/
        private void itemChanged(object sender, EventArgs e)
        {
            if (!isResponse)
                return;

            currentMeasData.isChagesSaved = false;
        }

        /**Just warning closing an unsaved form.*/
        private void MeasurementSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!currentMeasData.isChagesSaved)
            {
                MessageShow.show("Please save current datas first!", "请先保存当前配置！");
                e.Cancel = true;
            }
        }

        /**To check if the datas is intact and unrepeated. We just check the row 
         * whoes activity is checked.
         */
        private bool isMearDataCorrect()
        {
            List<RowData> rowList = currentMeasData.rowDataList;

            for (int i = 0; i < rowList.Count; i++)
            {
                if (!rowList[i].activity)
                    continue;
                if (!isRowDataCorrect(i))
                    return false;

                for (int j = i + 1; j < rowList.Count; j++)
                {
                    if (!rowList[j].activity)
                        continue;
                    if ((rowList[i].Cycle == rowList[j].Cycle) && (rowList[i].Source == rowList[j].Source)
                        && (rowList[i].Mode == rowList[j].Mode))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /**To check if the table has selected at least a row.*/
        private bool haveCheckedOne()
        {
            bool isActive = false;
            List<RowData> rowList = currentMeasData.rowDataList;
            for (int i = 0; i < rowList.Count; i++)
            {
                if (!rowList[i].activity)
                    continue;
                isActive = true;
            }
            return isActive;
        }

        /**To check if the row datas is intact.*/
        private bool isRowDataCorrect(int index)
        {
            RowData currRowData = currentMeasData.rowDataList[index];
            if (currRowData.Cycle == "")
                return false;
            else if (currRowData.Source == (Source)(-1))
                return false;
            else if (currRowData.Mode == (Mode)(-1))
                return false;
            return true;
        }

        /**To check if the row datas' sources are the same type.*/
        private bool isSourceSameType()
        {
            int type = 0; //0:init value; 1:single gate; 2:double gates
            int tmpType;
            List<RowData> rowList = currentMeasData.rowDataList;
            for (int i = 0; i < rowList.Count; i++)
            {
                if (rowList[i].activity)
                {
                    tmpType = getSourceType(rowList[i].Source);
                    if (type == 0)
                        type = tmpType;
                    else
                    {
                        if (tmpType != type)
                            return false;
                    }
                }
            }
            return true;
        }

        /**Return the type of Source.
         * 1: single gate; 2: doble gates
         */
        private int getSourceType(Source source)
        {
            int type = (int) source;
            if (type < (int)Source.GateBA)
                return 1;
            else
                return 2;
        }
    }

    [Serializable]
    public class MeasurementData
    {
        public List<RowData> rowDataList;

        public bool isChagesSaved;

        public bool isDoubleGates;

        public MeasurementData()
        {
            rowDataList = new List<RowData>();
            isChagesSaved = true;
            isDoubleGates = false;
        }
    }

    [Serializable]
    public class RowData
    {
        private string cycle;
        private Source source;
        private Mode mode;
        public string gateStates;
        public bool activity;

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
        GateBA,
        GateAI,
        GateBI,
        GateCI
    }

    public enum Mode
    {
        TOFPeak,
        TOFMax,
        TOFMin,
        ThicknessMax,
        ThicknessMin,
        ThicknessAvrg,
        AmpPersent,
        AmpDB,
        AmpDACPersent,
        AmpDACDB,
        AmpDiffPersent,
        AmpDiffDB,
        GenerateData
    }

}
