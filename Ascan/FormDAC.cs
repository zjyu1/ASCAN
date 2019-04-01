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
    public partial class FormDAC : Form
    {
        private RadioButton preRadButton;
        private AmpUnit ampUnit;

        private uint dacPoint;
        private float[] dacTof;
        private float[] dacAmpPercent;
        private float[] dacAmpDB;

        private DACParas dacParas;

        public FormDAC()
        {
            InitializeComponent();

            initGCGGridView1();
            addDataToDACGridView1();
            //dacTof = new float[32];
            //dacAmpPercent = new float[32];
            //dacAmpDB = new float[32];

            //dacParas = new DACParas();
        }

        private void initGCGGridView1()
        {

            DataGridViewTextBoxColumn cloumn = new DataGridViewTextBoxColumn();
            cloumn.HeaderText = "门";
            gcgGridView.Columns.Add(cloumn);

            DataGridViewTextBoxColumn cloumn1 = new DataGridViewTextBoxColumn();
            cloumn1.HeaderText = "Amp.[%]";
            gcgGridView.Columns.Add(cloumn1);

            object[] values = new object[2];

            values[0] = "I";
            values[1] = "0";
            gcgGridView.Rows.Add(values);

            values[0] = "A";
            values[1] = "0";
            gcgGridView.Rows.Add(values);

            values[0] = "B";
            values[1] = "0";
            gcgGridView.Rows.Add(values);

            values[0] = "C";
            values[1] = "0";
            gcgGridView.Rows.Add(values);
        }

        private void addDataToDACGridView1()
        {
            dacGridView.Columns.Clear();
            dacGridView.Rows.Clear();

            DataGridViewTextBoxColumn cloumn = new DataGridViewTextBoxColumn();
            cloumn.HeaderText = "TOF.(us)";
            dacGridView.Columns.Add(cloumn);

            DataGridViewTextBoxColumn cloumn1 = new DataGridViewTextBoxColumn();
            cloumn1.HeaderText = "Amp.[%]";
            dacGridView.Columns.Add(cloumn1);
 

            object[] values = new object[2];
            values[0] = 10;
            values[1] = 12;
            dacGridView.Rows.Add(values);

            values[0] = 25;
            values[1] = 24;
            dacGridView.Rows.Add(values);

            values[0] = 40;
            values[1] = 23;
            dacGridView.Rows.Add(values);

            values[0] = 65;
            values[1] = 37;
            dacGridView.Rows.Add(values);

        }

        private void FormDAC_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            gcgGridView.Enabled = false;
            gcgTable.Enabled = true;
        }
        ///*
        //private void initDac()
        //{
        //    initGCGGridView();
        //    initAmplitudeMode();
        //    controlsEnabled(false);
        //    initDACEnable();
        //}

        //private void initAmplitudeMode()
        //{
        //    ampUnit = AmpUnit.dB;
        //    radioButtonDB.Checked = true;
        //}

        //private void initDACEnable()
        //{
        //    int error_code;
        //    error_code = GetDACDAQ.DACFile(SelectAscan.sessionIndex, SelectAscan.port, ref dacParas);
        //    if (error_code != 0)
        //        return;

        //    switch ((DACActive)dacParas.dac_on)
        //    {
        //        case DACActive.OFF:
        //            modeOff.Checked = true;
        //            preRadButton = modeOff;
        //            addDataToDACGridView(true);
        //            break;

        //        case DACActive.ON:
        //            initDACMode();
        //            break;

        //        default:
        //            MessageShow.show("Warn:Initial the dac active failed",
        //                "警告:初始化DAC失败!");
        //            break;
        //    }
        //}

        
        //private void initDACMode()
        //{
        //    switch ((DACMode)dacParas.dac_mode)
        //    {
        //        case DACMode.DAC:
        //            getDACData();
        //            addDataToDACGridView(false);
        //            modeDac.Checked = true;
        //            preRadButton = modeDac;
        //            break;

        //        case DACMode.GCG:
        //            addDataToGCGGridView();
        //            modeGCG.Checked = true;
        //            preRadButton = modeGCG;
        //            break;

        //        default:
        //            MessageShow.show("Error:Get DAC mode failed!",
        //                "错误：获得DAC模式失败!");
        //            break;
        //    }
        //}

        //private void getDACData()
        //{
        //    double ampDBMin;
        //    double percentValue;
        //    float defaultPercent = 0.10f;

        //    dacPoint = dacParas.dac_point_num;
        //    dacTof = dacParas.dac_tofs;
        //    dacAmpDB = dacParas.dac_amps;
        //    //get min amp db
        //    Array.Sort(dacParas.dac_amps);//ascending sort
        //    ampDBMin = dacParas.dac_amps[0];

        //    for (int i = 0; i < dacPoint; i++)
        //    {
        //        //the min db value correspond to 10.00% defaultly
        //        if (dacAmpDB[i] == ampDBMin)
        //        {
        //            dacAmpPercent[i] = defaultPercent;
        //            continue;
        //        }
        //        percentValue = defaultPercent / Math.Pow(10, (dacAmpDB[i] - ampDBMin) / 20);
        //        dacAmpPercent[i] = (float)Math.Round(percentValue, 2);
        //    }
        //}

        //private void addDataToDACGridView(bool isAddRow)
        //{
        //    float[] ampData;
        //    dacGridView.Columns.Clear();
        //    dacGridView.Rows.Clear();
        //    addTableColumn("TOF.(us)");

        //    if (ampUnit == AmpUnit.dB)
        //    {
        //        addTableColumn("Amp.[db]");
        //        ampData = dacAmpDB;
        //    }
        //    else
        //    {
        //        addTableColumn("Amp.[%]");
        //        ampData = dacAmpPercent;
        //    }

        //    if (isAddRow)
        //    {
        //        dacGridView.Rows.Add();
        //        return;
        //    }
            
        //    object[] values = new object[2];
        //    for (int i = 0; i < dacPoint; i++)
        //    {
        //        values[0] = dacTof[i];
        //        values[1] = ampData[i];
        //        dacGridView.Rows.Add(values);
        //    }
        //}

        //private void addTableColumn(string cloumnHeardName)
        //{
        //    DataGridViewTextBoxColumn cloumn = new DataGridViewTextBoxColumn();
        //    cloumn.HeaderText = cloumnHeardName;
        //    dacGridView.Columns.Add(cloumn);
        //}

        ///**Set the controls enabled into true or false*/
        //private void controlsEnabled(bool enabled)
        //{
        //    radioButtonPercent.Enabled = enabled;
        //    radioButtonDB.Enabled = enabled;
        //    dacGridView.Enabled = enabled;
        //    buttonDelete.Enabled = enabled;
        //    buttonRecord.Enabled = enabled;
        //}

        //private void modeOff_Click(object sender, EventArgs e)
        //{
        //    preRadButton = modeOff;
        //    dacParas.dac_on = (uint)DACActive.OFF;
        //    controlsEnabled(false);
        //    DelegateDAC dac = new DelegateDAC(SelectAscan.sessionIndex, "modeOff", 
        //        dacTof, dacAmpPercent, dacPoint);

        //    SetDACDAQ.DACFile(SelectAscan.sessionIndex, SelectAscan.port, dacParas);
        //}

        //private void modeEdit_Click(object sender, EventArgs e)
        //{
        //    preRadButton = modeEdit;
        //    controlsEnabled(true);
        //}

        //private void modeDac_Click(object sender, EventArgs e)
        //{
        //    int error_code;
        //    AscanWaveDectionMode waveMode = AscanWaveDectionMode.Rf;
        //    error_code = GetAsacnVideoDAQ.DetectionWaveMode(SelectAscan.sessionIndex, SelectAscan.port, ref waveMode);
        //    if (error_code != 0)
        //    {
        //        preRadButton.Checked = true;
        //        return;
        //    }

        //    if(waveMode != AscanWaveDectionMode.Full)
        //    {
        //        preRadButton.Checked = true;
        //        MessageShow.show("Warning:Need to set Receiver->Full wave!",
        //            "警告：必须设置检波模式为全波模式!");
        //        return;
        //    }

        //    dacParas.dac_on = (uint)DACActive.ON;
        //    dacParas.dac_point_num = dacPoint;
        //    dacParas.dac_amps = dacAmpDB;
        //    dacParas.dac_tofs = dacTof;
        //    SetDACDAQ.DACFile(SelectAscan.sessionIndex, SelectAscan.port, dacParas);

        //    preRadButton = modeDac;
        //    controlsEnabled(false);
        //}

        //private void radioButtonPercent_Click(object sender, EventArgs e)
        //{
        //    ampUnit = AmpUnit.Percent;
        //    addDataToDACGridView(false);
        //}

        //private void radioButtonDB_Click(object sender, EventArgs e)
        //{
        //    ampUnit = AmpUnit.dB;
        //    addDataToDACGridView(false);
        //}

        //private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
        //        && e.KeyChar != '.')//(char)8 is the Key of BackSpace
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void dacGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    bool isHasEmptyCell = false;
        //    int notEmptyRowCnt = 0;
        //    if (dacGridView.CurrentRow.Cells[0].Value == null||
        //           dacGridView.CurrentRow.Cells[1].Value == null)
        //        return;

        //    if (!checkRepeatTOfValue())
        //    {
        //        dacGridView.CurrentRow.Cells[0].Value = null;
        //        return;
        //    }

        //    isHasEmptyCell = isdacGridViewHaveEmptyCell(ref notEmptyRowCnt);

        //    getTofValueFromTable(notEmptyRowCnt);
        //    switch (ampUnit)
        //    {
        //        case AmpUnit.dB:
        //            ConvertDBtoPercent();
        //            break;

        //        case AmpUnit.Percent:
        //            ConvertPercentToDB();
        //            break;

        //        default:
        //            MessageShow.show("Error:Tof uint is error!", "错误：Tof单位错误！");
        //            break;
        //    }
        //    dacPoint = (uint)notEmptyRowCnt;

        //    DelegateDAC dac = new DelegateDAC(SelectAscan.sessionIndex, "modeOff",
        //              dacTof, dacAmpPercent, dacPoint);

        //    if (!isHasEmptyCell)
        //    {
        //        dacGridView.Rows.Add();
        //    }
        //    //((DataTable)dacGridView.DataSource).Rows.Add();
        //    //tableShape.Rows.Add();
        //}

        ////Judge the dacGridView has the empty row or not,if has return true，if not has return false;
        ////and return the notEmptyRowCnt.
        //private bool isdacGridViewHaveEmptyCell(ref int notEmptyRowCnt)
        //{
        //    bool isEmpty = false;
        //    for (int i = 0; i < dacGridView.RowCount; i++)
        //    {
        //        if (dacGridView[0, i].Value != null && dacGridView[0, i].Value != null)
        //            notEmptyRowCnt++;
        //        else
        //            isEmpty = true;
        //    }
        //    return isEmpty;
        //}

        //private void getTofValueFromTable(int notEmptyRowCnt)
        //{
        //    //sort tof value
        //    dacGridView.Sort(dacGridView.Columns[0], ListSortDirection.Ascending);

        //    for (int i = 0; i < notEmptyRowCnt; i++)
        //    {
        //        double value = Convert.ToDouble(dacGridView[0, i].Value);
        //        dacTof[i] = (float)value;
        //    }
        //}

        ///**Check repeat tof value*/
        //private bool checkRepeatTOfValue()
        //{
        //    bool isCorrectDatas = true;
        //    string tofValue;
        //    for (int i = 0; i < dacGridView.RowCount; i++)
        //    {
        //        tofValue = dacGridView[0,i].Value.ToString();

        //        for (int j = i + 1; j < dacGridView.RowCount; j++)
        //        {
        //            if (dacGridView[0,j].Value.ToString() == tofValue)
        //            {
        //                isCorrectDatas = false;
        //                return isCorrectDatas;
        //            }
        //        }
        //    }
        //    return isCorrectDatas;
        //}

        ///**When edit the table in the mode of ampDB, calculate the ampPercent value*/
        //private void ConvertDBtoPercent()
        //{
        //    float dBValue;
        //    double percentValue;
        //    double dBMax = 0;
        //    double dBMin = 0;
        //    float defaultPercent = 0.10f;//0.10
        //    getAmpMaxAndMinValue(ref dBMax, ref dBMin);

        //    for (int i = 0; i < dacGridView.RowCount; i++)
        //    {
        //        double value = Convert.ToDouble(dacGridView[1, i].Value);
        //        dBValue = (float)value;

        //        //the min db value correspond to 10.00% defaultly
        //        if (dBValue == dBMin)
        //        {
        //            dacAmpPercent[i] = defaultPercent;
        //            dacAmpDB[i] = dBValue;
        //            continue;
        //        }

        //        percentValue = defaultPercent / Math.Pow(10, (dBValue - dBMin) / 20);
        //        dacAmpPercent[i] = (float)Math.Round(percentValue, 2) ;
        //        dacAmpDB[i] = dBValue;
        //    }
        //}

        //private void ConvertPercentToDB()
        //{
        //    float dBValue;
        //    float percentValue;
        //    double percentMax = 0;
        //    double percentMin = 0;
        //    float defaultDB = 0f;//0dB
        //    getAmpMaxAndMinValue(ref percentMax, ref percentMin);

        //    for (int i = 0; i < dacGridView.RowCount; i++)
        //    {
        //        double value = Convert.ToDouble(dacGridView[1, i].Value);
        //        percentValue = (float)value;

        //        //the max percent value correspond to 0 dB defaultly
        //        if (percentValue == percentMax)
        //        {
        //            dacAmpPercent[i] = percentValue;
        //            dacAmpDB[i] = defaultDB;
        //            continue;
        //        }

        //        dacAmpPercent[i] = percentValue;
        //        dBValue = (float)(20 * Math.Log10(percentMax / percentValue));
        //        dacAmpDB[i] = (float)Math.Round(dBValue, 2);
        //    }
        //}

        //private void getAmpMaxAndMinValue(ref double max, ref double min)
        //{
        //    List<double> value = new List<double>();

        //    foreach (DataGridViewRow row in dacGridView.Rows)
        //    {
        //        value.Add( Convert.ToDouble(row.Cells[1].Value));
        //    }

        //    max = value.Max();
        //    min = value.Min();
        //}

        //private void dacGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    DataGridViewTextBoxEditingControl CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
        //    CellEdit.SelectAll();
        //    CellEdit.KeyPress += Cells_KeyPress; 
        //}

        //private void buttonDelete_Click(object sender, EventArgs e)
        //{
        //    dacGridView.Rows.Remove(dacGridView.CurrentRow);
        //    if (ampUnit == AmpUnit.dB)
        //        ConvertDBtoPercent();
        //    else
        //        ConvertPercentToDB();
        //}

        //private void initGCGGridView()
        //{
        //    int dacPoint = 8;
        //    gcgGridView.Columns.Clear();
        //    gcgGridView.Rows.Clear();
        //    addTableColumn("Gate");
        //    addTableColumn("Amp.[db]");
        //    object[] values = new object[2];
        //    for (int i = 0; i < dacPoint / 2; i++)
        //    {
        //        values[0] = Enum.GetName(typeof(GateType), i);//I、A、B、 C
        //        values[1] = "";
        //        dacGridView.Rows.Add(values);
        //    }
        //}

        //private void addDataToGCGGridView()
        //{
        //    int gateDrawIndex;
        //    double dbValue;
        //    int error_code;
        //    double delay = 0;
        //    DACParas dacParas = new DACParas();

        //    error_code = GetDACDAQ.DACFile(SelectAscan.sessionIndex, SelectAscan.port, ref dacParas);
        //    if (error_code != 0)
        //        return;

        //    dacPoint = dacParas.dac_point_num;
        //    dacTof = dacParas.dac_tofs;
        //    dacAmpDB = dacParas.dac_amps;
        //    for (int i = 0; i < dacPoint/2; i++)
        //    {
        //        error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, (GateType)i, ref delay);
        //        if (error_code != 0)
        //            return;

        //        gateDrawIndex = Array.IndexOf(dacTof, delay);
        //        dbValue = dacAmpDB[gateDrawIndex];
        //        dacGridView[1, i].Value = dbValue.ToString();
        //    }
        //}

        ///**Judge Gate I、A、B、C are coincident in the horizontal direction or not.
        // */
        //private bool judgeGateCoincident(double gate1Start, double gate1End, double gate2Start, double gate2End)
        //{
        //    if (gate1Start <= gate2Start && gate1End >= gate2Start)
        //        return true;

        //    else if (gate1Start <= gate2End && gate1End >= gate2End)
        //        return true;

        //    else if (gate1Start >= gate2Start && gate1End <= gate2End)
        //        return true;

        //    else
        //        return false;
        //}

        //private void setGCG()
        //{         
        //    int error_code;
        //    int gateNum = 4;
        //    double delay = 0;
        //    double width = 0;
        //    uint dacPoint = 8;
        //    bool isGateCoincident = false;
        //    float[] gatePoint = new float[8];
        //    float[] ampDB = new float[32];
        //    float[] tof = new float[32];
        //    DACParas dacParas = new DACParas();
        //    for (int i = 0; i < gateNum; i++)
        //    {
        //        error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, (GateType)i, ref delay);
        //        if (error_code != 0)
        //            return;

        //        error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, (GateType)i, ref width);
        //        if (error_code != 0)
        //            return;

        //        gatePoint[2 * i] = (float)delay;//Gate I、A、B、 C start point
        //        gatePoint[2 * i + 1] = (float)(delay + width);//Gate I、A、B、 C end point
        //    }
             
        //    for (int i = 0; i < gateNum; i++)
        //    {
        //        for (int j = i + 1; j < gateNum; j++)
        //        {
        //            isGateCoincident = judgeGateCoincident(gatePoint[2 * i], gatePoint[2 * i + 1], 
        //                gatePoint[2 * j], gatePoint[2 * j + 1]);

        //            if (isGateCoincident)
        //            {
        //                MessageShow.show("Warn:Gate I、A、B、C are coincident in the horizontal direction",
        //                    "警告：门I、A、B、C在水平方向重合");
        //                preRadButton = modeEdit;
        //                modeEdit.Checked = true;
        //                return;
        //            }
        //        }
        //    }

        //    bool isGetDataSuccess = getDBValueFromGCGGridView(gatePoint, ampDB, tof);
        //    if(!isGetDataSuccess)
        //    {
        //        preRadButton = modeEdit;
        //        modeEdit.Checked = true;
        //        return;
        //    }

        //    dacParas.dac_on = (uint)DACActive.ON;
        //    dacParas.dac_point_num = dacPoint;
        //    dacParas.dac_tofs = tof;
        //    dacParas.dac_amps = ampDB;
        //    SetDACDAQ.DACFile(SelectAscan.sessionIndex, SelectAscan.port, dacParas);
        //}

        ///**Get the DB value from gcgGridView by the order of gate I、A、B、C draw in Teechart,
        // * and get the tof by sort gatePoint.
        // *@param gatePint the point of gate I、A、B、C start point and end point,
        // *the gatePoint[]={Istart, Iend, Astart,Aend,Bstart, Bend, Cstart, Cend}
        // */
        //private bool getDBValueFromGCGGridView(float[] gatePoint, float[] ampDB, float[] tof)
        //{
        //    int gateNum = 4;
        //    int gateDrawIndex;//the index of Gate I、A、B、C draw in Teechart
        //    float[] gatePointSort = gatePoint;
        //    Array.Sort(gatePointSort);
        //    tof = gatePointSort;
        //    for (int i = 0; i < gateNum; i++)
        //    {
        //        gateDrawIndex = Array.IndexOf(gatePoint, gatePointSort[i * 2]) / 2;
        //        if (gcgGridView[1, gateDrawIndex] == null)
        //            return false;

        //        double value = Convert.ToDouble(gcgGridView[1, gateDrawIndex]);
        //        ampDB[i * 2] = (float)value;
        //        ampDB[i * 2 + 1] = ampDB[i * 2];
        //    }
        //    return true;
        //}

        //private void modeGCG_Click(object sender, EventArgs e)
        //{
        //    setGCG();
        //    preRadButton = modeGCG;
        //    controlsEnabled(false);
        //}
       
    }

    public class DelegateDAC
    {
        private string dacMode;
        private float[] tof;
        private float[] ampPercent;
        private uint dacPoint;
        private delegate void draw(string dacMode, 
            float[] tof, float[] ampPercent, uint dacPoint);
        private event draw drawEvent;

        public DelegateDAC(uint ascanNum, string dacMode, float[] tof,
            float[] ampPercent, uint dacPoint)
        {
            this.dacMode = dacMode;
            this.tof = tof;
            this.ampPercent = ampPercent;
            this.dacPoint = dacPoint;
            drawEvent += new draw(FormList.MDIChild.drawDACLine);
        }

        public void Execute(AscanQueueElement ascanQueueElement)
        {
            if (drawEvent != null)
            {
                drawEvent(dacMode, tof, ampPercent, dacPoint);
            }
        }
    }
}
