using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.IO;

namespace Ascan
{
    /**This class is used to display the information of sessions.*/
    public partial class SessionHardWare : Form, LoadandSave
    {
        private const int BasicGridAssignNameColumnIndex = 4;
        private const int BasicGridTripModeColumnIndex = 5;
        //add by xll at 2017-2-28
        private const int BasicGridStartDelayColumnIndex = 6;
        private const int BasicGridStopDelayColumnIndex = 7;
        private const int BasicGridPRFColumnIndex = 8;
        //add by xll at 2017-2-28
        private const int BasicGridColumnIndex = 10;

        private const int VirtualGridBoardNameColumnIndex = 0;
        private const int VirtualGridBeamFormerColumnIndex = 5;
        private const int VirtualGridIndex = 1;

        private const int InputGridFunctionIndex = 1;
        private const int InputGridDetailIndex = 2;

        private const int OutputGridFunctionIndex = 1;
        private const int OutputGridDetailIndex = 2;

        private const int PinNum = 12;
        private MainForm mainForm;
        private static Hashtable hashTableForInfo;
        private static Hashtable hashTableForName;
        private static Hashtable hashTableForIndex;
        public List<SessionInfo> sessionsAttrs;
        public List<SBeamList> sbeamlist;

        //For the beamFile Chan and DetectionMode read From the MainForm
        private List<ClassBeamFile> beamList;
        private List<ClassChanpara> chanPara;
        private DetectionMode detectionmode;

        public SessionHardWare(MainForm mainForm, List<SessionInfo> _sessionsAttrs)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            sessionsAttrs = _sessionsAttrs;
            beamList = new List<ClassBeamFile>();
            hashTableForInfo = new Hashtable();
            hashTableForName = new Hashtable();
            hashTableForIndex = new Hashtable();
            initBacisGrid();
            initVirtualGrid();
            initInputRoute();
            initOutputRoute();
        }

        /**Initial the basicGridView.*/
        public void initBacisGrid()
        {
            if (sessionsAttrs.Count < 1 || sessionsAttrs == null)
                return;

            basicGrid.Rows.Clear();

            basicGrid.RowCount = sessionsAttrs.Count;
            for (int i = 0; i < sessionsAttrs.Count; i++)
            {
                SessionInfo info = sessionsAttrs[i];
                basicGrid.Rows[i].Cells["boardName"].Value = info.myHardInfo.BoardName;
                basicGrid.Rows[i].Cells["classicNum"].Value = info.myHardInfo.ClassicNum;
                basicGrid.Rows[i].Cells["slotNum"].Value = info.myHardInfo.SlotNum;
                basicGrid.Rows[i].Cells["version"].Value = info.myHardInfo.Version;
                basicGrid.Rows[i].Cells["assignName"].Value = info.myHardInfo.AssignedName;
                basicGrid.Rows[i].Cells["tripMode"].Value = Enum.GetName(typeof(TrigMode), info.myHardInfo.TrigMode);
                basicGrid.Rows[i].Cells["startDelay"].Value = info.myHardInfo.StartDelay;
                basicGrid.Rows[i].Cells["stopDelay"].Value = info.myHardInfo.StopDelay;
                basicGrid.Rows[i].Cells["PRF"].Value = info.myHardInfo.PRF;
                basicGrid.Rows[i].Cells["enable"].Value = info.myHardInfo.enable;
            }
            basicGrid.CellValueChanged += new DataGridViewCellEventHandler(basicGrid_CellValueChanged);
        }

        /**Initial the virtualGridView.*/
        public void initVirtualGrid()
        {
            cboxName.Visible = false;
            cboxName.Items.Clear();
            for (int i = 0; i < SessionInfo.sessionNum; i++)
                cboxName.Items.Add(sessionsAttrs[i].myHardInfo.BoardName);

            panelBF.Visible = false;
        }

        /**Initial the input route.*/
        public void initInputRoute()
        {
            for (int i = 0; i < sessionsAttrs.Count; i++)
                cboxInBoard.Items.Add(sessionsAttrs[i].myHardInfo.BoardName);

            inputGrid.RowCount = PinNum;
            for (int i = 0; i < PinNum; i++)
            {
                inputGrid.Rows[i].Cells["inPin"].Value = "IN" + i;
                inputGrid.Rows[i].Cells["routeFunction"].Value = "";
                inputGrid.Rows[i].Cells["inDetail"].Value = "";
            }
        }

        /**Initial the output route.*/
        public void initOutputRoute()
        {
            for (int i = 0; i < sessionsAttrs.Count; i++)
                cboxOutBoard.Items.Add(sessionsAttrs[i].myHardInfo.BoardName);

            outputGrid.RowCount = PinNum;
            for (int i = 0; i < PinNum; i++)
            {
                outputGrid.Rows[i].Cells["outPin"].Value = "IN" + i;
                outputGrid.Rows[i].Cells["outRouteFunction"].Value = "";
                outputGrid.Rows[i].Cells["outDetail"].Value = "";
            }
        }

        private void SessionHardWare_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }
        /*
                /**When cellValue changed happend.*/
        private void basicGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colmIndex = e.ColumnIndex;

            //            if (rowIndex >= 0)
            //            {
            //                string str = basicGrid.Rows[rowIndex].Cells[colmIndex].Value.ToString();
            //                /*The checkBox is checked.*/

            ////                if (colmIndex == BasicGridAssignNameColumnIndex)
            ////                    sessionsAttrs[rowIndex].myHardInfo.AssignedName = str;
            ////                else if (colmIndex == BasicGridTripModeColumnIndex)
            ////                    sessionsAttrs[rowIndex].myHardInfo.TrigMode = (TrigMode)Enum.Parse(typeof(TrigMode), str);
            //                //add by xll at 2017-2-28
            ////                else if (colmIndex == BasicGridStartDelayColumnIndex)
            ////                    sessionsAttrs[rowIndex].myHardInfo.StartDelay = Convert.ToUInt32(str);
            ////                else if (colmIndex == BasicGridStopDelayColumnIndex)
            ////                    sessionsAttrs[rowIndex].myHardInfo.StopDelay = Convert.ToUInt32(str);
            ////                else if (colmIndex == BasicGridPRFColumnIndex)
            ////                    sessionsAttrs[rowIndex].myHardInfo.PRF = Convert.ToDouble(str);
            //                //add by xll at 2017-2-28
            ////                else if (colmIndex == BasicGridColumnIndex)
            //                {
            //                    if (str == "True")
            //                    {
            //                        sessionsAttrs[rowIndex].myHardInfo.enable = true;
            //                    }
            //                    /*The checkBox is unchecked.*/
            //                    else if (str == "False")
            //                    {
            //                        sessionsAttrs[rowIndex].myHardInfo.enable = false;
            //                    }
            //                }
            //            }
        }

        /**Select all the session to show or unshow.*/
        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool enabel = selectAll.Checked;
            for (int i = 0; i < sessionsAttrs.Count; i++)
                basicGrid.Rows[i].Cells["enable"].Value = enable;
        }

        private void virtualGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colmIndex = e.ColumnIndex;

            if (rowIndex >= 0)
            {
                if (colmIndex == VirtualGridBoardNameColumnIndex)
                {
                    System.Drawing.Rectangle rect = virtualGrid.GetCellDisplayRectangle(colmIndex, rowIndex, false);
                    cboxName.Size = rect.Size;
                    cboxName.Top = rect.Top;
                    cboxName.Left = rect.Left + 2;
                    cboxName.Tag = rowIndex;
                    cboxName.Visible = true;
                }
                else if (colmIndex == VirtualGridBeamFormerColumnIndex)
                {
                    System.Drawing.Rectangle rect = virtualGrid.GetCellDisplayRectangle(colmIndex, rowIndex, false);
                    panelBF.Size = rect.Size;
                    btBFCreate.Width = rect.Width / 3;
                    btBFLoad.Width = rect.Width / 3;
                    tbTInfo.Width = rect.Width / 3;
                    panelBF.Top = rect.Top;
                    panelBF.Left = rect.Left + 2;
                    btBFCreate.Tag = rowIndex;
                    btBFLoad.Tag = rowIndex;
                    panelBF.Visible = true;
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            virtualGrid.RowCount++;
            virtualGrid.Rows[virtualGrid.RowCount - 1].Cells["BeamFormer"].Value = ".........";
            virtualGrid.Rows[virtualGrid.RowCount - 1].Cells["virtualIndex"].Value = virtualGrid.RowCount - 1;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            //            int i = virtualGrid.CurrentRow.Index;
            int i;
            virtualGrid.Rows.Remove(virtualGrid.CurrentRow);
            if (virtualGrid.RowCount > 0)
            {
                for (i = virtualGrid.CurrentRow.Index; i < virtualGrid.RowCount; i++)
                {
                    virtualGrid.Rows[i].Cells["virtualIndex"].Value = i;
                }
            }
        }

        private void cboxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxName.Tag != null)
            {
                int rowIndex = (int)cboxName.Tag;
                String name = sessionsAttrs[cboxName.SelectedIndex].myHardInfo.BoardName;
                virtualGrid.Rows[rowIndex].Cells["board"].Value = name;
                virtualGrid.Rows[rowIndex].Cells["board"].Tag = cboxName.SelectedIndex;
                cboxName.Tag = null;
                cboxName.Visible = false;
                cboxName.SelectedIndex = -1;
            }
        }

        private void btTCreate_Click(object sender, EventArgs e)
        {
            if (btBFCreate.Tag != null)
            {
                int rowIndex = (int)btBFCreate.Tag;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                string filePath = Application.StartupPath + @"\BeamFile";
                openFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";

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
                    ClassBeamFile beamFile;
                    String fileName = openFileDialog1.FileName;
                    beamFile = ReadFromMatlabFile(fileName);

                    FormDelays myForm = new FormDelays(beamFile);
                    myForm.ShowDialog();

                    //ClassBeamFile beamFile = new ClassBeamFile();
                    //FormPAUT pAUT = new FormPAUT(beamFile);
                    //pAUT.ShowDialog();
                    String[] names = fileName.Split('\\');
                    virtualGrid.Rows[rowIndex].Cells["BeamFormer"].Value = names[names.Length - 1];
                    virtualGrid.Rows[rowIndex].Cells["transmitRadix"].Value = beamFile.txSize;
                    virtualGrid.Rows[rowIndex].Cells["receiveRaidx"].Value = beamFile.rxSize;
                    //                    virtualGrid.Rows[rowIndex].Cells["virtualIndex"].Value = beamFile.beamIndex;
                    virtualGrid.Rows[rowIndex].Cells["BeamFormer"].Value = beamFile.beamIndex;
                    virtualGrid.Rows[rowIndex].Cells["BeamFormer"].Tag = beamFile;
                    virtualGrid.Rows[rowIndex].Cells["BFpath"].Value = filePath;
                }

                btBFCreate.Tag = null;
                panelBF.Visible = false;
            }
        }

        private void btTLoad_Click(object sender, EventArgs e)
        {
            if (btBFLoad.Tag != null)
            {
                int rowIndex = (int)btBFLoad.Tag;

                virtualGrid.Rows[rowIndex].Cells["BeamFormer"].Value = rowIndex;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                string filePath = Application.StartupPath + @"\BeamFile";
                openFileDialog1.Filter = "bm文件(*.bm)|*.bm|所有文件(*.*)|*.*";

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
                    ClassBeamFile beamFile;
                    String fileName = openFileDialog1.FileName;
                    beamFile = ReadFromXML(fileName);
                    String[] names = fileName.Split('\\');
                    virtualGrid.Rows[rowIndex].Cells["BeamFormer"].Value = names[names.Length - 1];
                    virtualGrid.Rows[rowIndex].Cells["transmitRadix"].Value = beamFile.txSize;
                    virtualGrid.Rows[rowIndex].Cells["receiveRaidx"].Value = beamFile.rxSize;
                    //                    virtualGrid.Rows[rowIndex].Cells["virtualIndex"].Value = beamFile.beamIndex;
                    virtualGrid.Rows[rowIndex].Cells["BeamFormer"].Tag = beamFile;
                    virtualGrid.Rows[rowIndex].Cells["BFpath"].Value = fileName;

                    FormDelays myForm = new FormDelays(beamFile);
                    myForm.ShowDialog();
                }
                btBFLoad.Tag = null;
                panelBF.Visible = false;
            }
        }

        private ClassBeamFile ReadFromMatlabFile(string file)
        {
            ClassBeamFile beamFile = new ClassBeamFile();
            StreamReader sr = new StreamReader(file, Encoding.Default);
            String line;

            //tx
            if ((line = sr.ReadLine()) != null)
            {
                uint size = 0;
                uint[] bin = new uint[8];
                String[] arrays = line.Split('\t');
                for (int j = 0; j < arrays.Length - 1; j++)
                {
                    int stu = Convert.ToInt32(arrays[j]);
                    if (stu != 0 && stu != 1)
                        return null;
                    else if (stu == 1)
                    {
                        size++;
                        uint tmpBin = bin[j / 32];
                        tmpBin |= (uint)(1 << (j % 32));
                        bin[j / 32] = tmpBin;
                    }
                }
                beamFile.txSize = size;
                beamFile.txElementBin = bin;
            }
            else
                return null;

            line = null;
            if ((line = sr.ReadLine()) != null)
            {
                String[] arrays = line.Split('\t');
                int index = 0;
                for (int j = 0; j < arrays.Length - 1; j++)
                {
                    double tmp = Convert.ToDouble(arrays[j]);
                    if (tmp == 131064)
                        continue;
                    else
                    {
                        beamFile.txDelay[index] = (float)tmp;
                        index++;
                    }
                }
            }
            else
                return null;

            //rx
            if ((line = sr.ReadLine()) != null)
            {
                uint size = 0;
                uint[] bin = new uint[8];
                String[] arrays = line.Split('\t');
                for (int j = 0; j < arrays.Length - 1; j++)
                {
                    int stu = Convert.ToInt32(arrays[j]);
                    if (stu != 0 && stu != 1)
                        return null;
                    else if (stu == 1)
                    {
                        size++;
                        uint tmpBin = bin[j / 32];
                        tmpBin |= (uint)(1 << (j % 32));
                        bin[j / 32] = tmpBin;
                    }
                }
                beamFile.rxSize = size;
                beamFile.rxElementBin = bin;
            }
            else
                return null;

            line = null;
            if ((line = sr.ReadLine()) != null)
            {
                String[] arrays = line.Split('\t');
                int index = 0;
                for (int j = 0; j < arrays.Length - 1; j++)
                {
                    double tmp = Convert.ToDouble(arrays[j]);
                    if (tmp == 131064)
                        continue;
                    else
                    {
                        beamFile.rxDelay[index] = (float)tmp;
                        index++;
                    }
                }
            }
            else
                return null;

            return beamFile;
        }

        private ClassBeamFile ReadFromXML(string file)
        {
            ClassBeamFile beamFile = (ClassBeamFile)SystemConfig.ReadBase64Data(file, "beamFile");
            return beamFile;
        }

        private void btVSave_Click(object sender, EventArgs e)
        {
            int direction;
            bool result = isPortCorrect();
            if (!result)
                return;

            //remove all the virtual sessions
            while (sessionsAttrs.Count > SessionInfo.sessionNum)
                sessionsAttrs.RemoveAt(sessionsAttrs.Count - 1);
            SessionInfo.portNum = SessionInfo.sessionNum;
            for (int k = 0; k < SessionInfo.virtualNumEachBoard.Length; k++) //clear the cout of virtualNumEachBoard each time click save button
                SessionInfo.virtualNumEachBoard[k] = 0;                     //to avoid repeating adding
            
            for (int i = 0; i < virtualGrid.RowCount; i++)
            {
                int index = (int)virtualGrid.Rows[i].Cells["board"].Tag;
                int port = Convert.ToInt32(virtualGrid.Rows[i].Cells["virtualIndex"].Value);
                String assignedName = "";

                ClassBeamFile beamFile = (ClassBeamFile)virtualGrid.Rows[i].Cells["BeamFormer"].Tag;
                beamFile.beamIndex = (uint)port;
                StructBeamFile structBeam = beamFile.getStruct();

                int err = SetBeamFileDAQ.BeamFile((uint)sessionsAttrs[index].sessionIndex, (uint)port, structBeam);
                if (err == 0)
                {
                    try
                    {
                        assignedName = virtualGrid.Rows[i].Cells["virtualAssignedName"].Value.ToString();
                    }
                    catch
                    {
                        MessageShow.show("please enter assignedname", "请输入别名");
                        return;
                    }

                    direction = 0;

                    SessionInfo sessionInfo;
                    if (port == 0)
                    {
                        sessionInfo = sessionsAttrs[index];
                        if (chanPara != null)
                        {
                            if (chanPara[i].skew == 90)
                            {
                                direction = 0;
                            }
                            else if (chanPara[i].skew == 270)
                            {
                                direction = 1;
                            }
                            sessionInfo.type = chanPara[i].zonetype;
                            sessionInfo.LR = direction;
                            sessionInfo.zonename = chanPara[i].name;
                        } 
                    }
                    else
                    {
                        sessionInfo = new SessionInfo(sessionsAttrs[index].sessionIndex, sessionsAttrs.Count, port);
                        if (chanPara != null)
                        {
                            if (chanPara[i].skew == 90)
                            {
                                direction = 0;
                            }
                            else if (chanPara[i].skew == 270)
                            {
                                direction = 1;
                            }
                            sessionInfo.type = chanPara[i].zonetype;
                            sessionInfo.LR = direction;
                            sessionInfo.zonename = chanPara[i].name;
                        }          
                        sessionsAttrs.Add(sessionInfo);
                        SessionInfo.portNum++;
                    }
                    sessionInfo.myHardInfo.AssignedName = assignedName;
                    SessionInfo.virtualNumEachBoard[index]++;
                }
            }

            //Reordersessionlist();
            int error = SetBeamFileDAQ.PeriodTimes(0, 0, SessionInfo.virtualNumEachBoard[0]);   //send the num of virtualchanel in PAboard
            SetGatepara();
            FormList.Formsscan.isStart = true;
        }

        private void Reordersessionlist()
        {
            SessionInfo tmp = sessionsAttrs[1];
            sessionsAttrs.Remove(sessionsAttrs[1]);
            sessionsAttrs.Add(tmp);
        }

        //Set GatePara To Hardware
        private void SetGatepara()
        {
            if (detectionmode == null)
            {
                return;
            }
            if (detectionmode.painfolist == null && detectionmode.coupleinfolist == null)
            {
                return;
            }
            int i = 0;
            int pacount = detectionmode.painfolist.Count;
            int couplecount = detectionmode.coupleinfolist.Count;
            int offset = 0;

            //Zone Gate
            for (i = 0; i < pacount; i++)
            {
                int error_code;
                double delay = detectionmode.painfolist[i].delay;
                double range = detectionmode.painfolist[i].range;
                if (i == 1)
                {
                    offset = 1;
                }
                uint sessionIndex = (uint)sessionsAttrs[i + offset].sessionIndex;
                uint port = (uint)sessionsAttrs[i + offset].port;

                if (SetBatchDAQ.isOn)
                    error_code = SetBatchDAQ.GateDlay(sessionIndex, GateType.B, delay);
                else
                    error_code = SetGateDAQ.Delay(sessionIndex, port, GateType.B, delay);
                if (error_code != 0)
                    return;

                if (SetBatchDAQ.isOn)
                    error_code = SetBatchDAQ.GateWidth(sessionIndex, GateType.B, range);
                else
                    error_code = SetGateDAQ.Width(sessionIndex, port, GateType.B, range);
                if (error_code != 0)
                    return;
            }

            //Couple Gate
            for (i = 0; i < couplecount;i++ )
            {
                int error_code;
                offset = 1;

                uint sessionIndex = (uint)sessionsAttrs[i + offset + pacount].sessionIndex;
                uint port = (uint)sessionsAttrs[i + offset + pacount].port;

                for (int j = 0; j < 4;j++ )
                {
                    GateDelay tmp = detectionmode.coupleinfolist[i].gatedelay[j];

                        error_code = SetGateDAQ.Delay(sessionIndex, port, tmp.type, tmp.delay);
                    if (error_code != 0)
                        return;

                        error_code = SetGateDAQ.Width(sessionIndex, port, tmp.type, tmp.range);
                    if (error_code != 0)
                        return;
                }
            }
            FormList.FormGatePosition.UpdateGateLine();
        }

        private bool isPortCorrect()
        {
            if (virtualGrid.RowCount == 0)
                return true;

            Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();
            for (int i = 0; i < virtualGrid.RowCount; i++)
            {
                try
                {
                    int nameIndex = (int)virtualGrid.Rows[i].Cells["board"].Tag;
                    String name = sessionsAttrs[nameIndex].myHardInfo.BoardName;
                    int port = Convert.ToInt32(virtualGrid.Rows[i].Cells["virtualIndex"].Value);
                    /*if(port == 0)
                    {
                        MessageShow.show("New port shoudn't be 0", "新建的虚拟板卡号不能为0");
                        return false;
                    }*/

                    if (!dic.ContainsKey(name))
                    {
                        List<int> list = new List<int>();
                        list.Add(port);
                        dic.Add(name, list);
                    }
                    else
                    {
                        List<int> list = dic[name];
                        if (list.Contains(port))
                        {
                            MessageShow.show("Port must be unique for a board", "同一板卡的端口号必须唯一");
                            return false;
                        }
                        else
                            list.Add(port);
                    }
                }
                catch
                {
                    MessageShow.show("Port must be a int type and BoardName must be set", "端口号必须为整型且必须设置板卡名称");
                    return false;
                }
            }

            return true;
        }

        private void inputGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colmIndex = e.ColumnIndex;

            if (rowIndex >= 0)
            {
                if (colmIndex == InputGridFunctionIndex)
                {
                    System.Drawing.Rectangle rect = inputGrid.GetCellDisplayRectangle(colmIndex, rowIndex, false);
                    cboxInFunction.SelectedIndex = -1;
                    cboxInFunction.Size = rect.Size;
                    cboxInFunction.Top = rect.Top;
                    cboxInFunction.Left = rect.Left;
                    cboxInFunction.Tag = rowIndex;
                    cboxInFunction.Visible = true;
                }
                else if (colmIndex == InputGridDetailIndex)
                {
                    System.Drawing.Rectangle rect = inputGrid.GetCellDisplayRectangle(colmIndex, rowIndex, false);
                    switch (inputGrid.Rows[rowIndex].Cells["routeFunction"].Value.ToString())
                    {
                        case "Basic":
                            cboxInBasic.SelectedIndex = -1;
                            cboxInBasic.Size = rect.Size;
                            cboxInBasic.Top = rect.Top;
                            cboxInBasic.Left = rect.Left;
                            cboxInBasic.Tag = rowIndex;
                            cboxInBasic.Visible = true;
                            break;
                        case "Motor drive":
                            cboxInMotor.SelectedIndex = -1;
                            cboxInMotor.Size = rect.Size;
                            cboxInMotor.Top = rect.Top;
                            cboxInMotor.Left = rect.Left;
                            cboxInMotor.Tag = rowIndex;
                            cboxInMotor.Visible = true;
                            break;
                        case "Pxi trig bus":
                            cboxInTrig.SelectedIndex = -1;
                            cboxInTrig.Size = rect.Size;
                            cboxInTrig.Top = rect.Top;
                            cboxInTrig.Left = rect.Left;
                            cboxInTrig.Tag = rowIndex;
                            cboxInTrig.Visible = true;
                            break;
                        case "Pxi local bus":
                            cboxInLocal.SelectedIndex = -1;
                            cboxInLocal.Size = rect.Size;
                            cboxInLocal.Top = rect.Top;
                            cboxInLocal.Left = rect.Left;
                            cboxInLocal.Tag = rowIndex;
                            cboxInLocal.Visible = true;
                            break;
                        case "AD bus":
                            cboxInAD.SelectedIndex = -1;
                            cboxInAD.Size = rect.Size;
                            cboxInAD.Top = rect.Top;
                            cboxInAD.Left = rect.Left;
                            cboxInAD.Tag = rowIndex;
                            cboxInAD.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void cboxInBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < PinNum; i++)
            {
                inputGrid.Rows[i].Cells["inPin"].Value = "IN" + i;
                inputGrid.Rows[i].Cells["routeFunction"].Value = "";
                inputGrid.Rows[i].Cells["inDetail"].Value = "";
            }
        }

        private void cboxFunction_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboxInFunction.Tag != null)
            {
                int rowIndex = (int)cboxInFunction.Tag;

                inputGrid.Rows[rowIndex].Cells["routeFunction"].Value = cboxInFunction.SelectedItem.ToString();
                cboxInFunction.Tag = null;
                cboxInFunction.Visible = false;
            }
        }

        private void cboxBasic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxInBasic.Tag != null)
            {
                int rowIndex = (int)cboxInBasic.Tag;

                inputGrid.Rows[rowIndex].Cells["inDetail"].Value = cboxInBasic.SelectedItem.ToString();
                cboxInBasic.Tag = null;
                cboxInBasic.Visible = false;
            }
        }

        private void cboxMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxInMotor.Tag != null)
            {
                int rowIndex = (int)cboxInMotor.Tag;

                inputGrid.Rows[rowIndex].Cells["inDetail"].Value = cboxInMotor.SelectedItem.ToString();
                cboxInMotor.Tag = null;
                cboxInMotor.Visible = false;
            }
        }

        private void cboxTrig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxInTrig.Tag != null)
            {
                int rowIndex = (int)cboxInTrig.Tag;

                inputGrid.Rows[rowIndex].Cells["inDetail"].Value = cboxInTrig.SelectedItem.ToString();
                cboxInTrig.Tag = null;
                cboxInTrig.Visible = false;
            }
        }

        private void cboxLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxInLocal.Tag != null)
            {
                int rowIndex = (int)cboxInLocal.Tag;

                inputGrid.Rows[rowIndex].Cells["inDetail"].Value = cboxInLocal.SelectedItem.ToString();
                cboxInLocal.Tag = null;
                cboxInLocal.Visible = false;
            }
        }

        private void cboxAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxInAD.Tag != null)
            {
                int rowIndex = (int)cboxInAD.Tag;

                inputGrid.Rows[rowIndex].Cells["inDetail"].Value = cboxInAD.SelectedItem.ToString();
                cboxInAD.Tag = null;
                cboxInAD.Visible = false;
            }
        }

        private void outputGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colmIndex = e.ColumnIndex;

            if (rowIndex >= 0)
            {
                if (colmIndex == InputGridFunctionIndex)
                {
                    System.Drawing.Rectangle rect = outputGrid.GetCellDisplayRectangle(colmIndex, rowIndex, false);
                    cboxOutFunction.SelectedIndex = -1;
                    cboxOutFunction.Size = rect.Size;
                    cboxOutFunction.Top = rect.Top;
                    cboxOutFunction.Left = rect.Left;
                    cboxOutFunction.Tag = rowIndex;
                    cboxOutFunction.Visible = true;
                }
                else if (colmIndex == InputGridDetailIndex)
                {
                    System.Drawing.Rectangle rect = outputGrid.GetCellDisplayRectangle(colmIndex, rowIndex, false);
                    switch (outputGrid.Rows[rowIndex].Cells["outRouteFunction"].Value.ToString())
                    {
                        case "Basic":
                            cboxOutBasic.SelectedIndex = -1;
                            cboxOutBasic.Size = rect.Size;
                            cboxOutBasic.Top = rect.Top;
                            cboxOutBasic.Left = rect.Left;
                            cboxOutBasic.Tag = rowIndex;
                            cboxOutBasic.Visible = true;
                            break;
                        case "Motor drive":
                            cboxOutMotor.SelectedIndex = -1;
                            cboxOutMotor.Size = rect.Size;
                            cboxOutMotor.Top = rect.Top;
                            cboxOutMotor.Left = rect.Left;
                            cboxOutMotor.Tag = rowIndex;
                            cboxOutMotor.Visible = true;
                            break;
                        case "Pxi trig bus":
                            cboxOutTrig.SelectedIndex = -1;
                            cboxOutTrig.Size = rect.Size;
                            cboxOutTrig.Top = rect.Top;
                            cboxOutTrig.Left = rect.Left;
                            cboxOutTrig.Tag = rowIndex;
                            cboxOutTrig.Visible = true;
                            break;
                        case "Pxi local bus":
                            cboxOutLocal.SelectedIndex = -1;
                            cboxOutLocal.Size = rect.Size;
                            cboxOutLocal.Top = rect.Top;
                            cboxOutLocal.Left = rect.Left;
                            cboxOutLocal.Tag = rowIndex;
                            cboxOutLocal.Visible = true;
                            break;
                        case "AD bus":
                            cboxOutAD.SelectedIndex = -1;
                            cboxOutAD.Size = rect.Size;
                            cboxOutAD.Top = rect.Top;
                            cboxOutAD.Left = rect.Left;
                            cboxOutAD.Tag = rowIndex;
                            cboxOutAD.Visible = true;
                            break;
                        case "Input line":
                            cboxOutInLine.SelectedIndex = -1;
                            cboxOutInLine.Size = rect.Size;
                            cboxOutInLine.Top = rect.Top;
                            cboxOutInLine.Left = rect.Left;
                            cboxOutInLine.Tag = rowIndex;
                            cboxOutInLine.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void cboxOutBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < PinNum; i++)
            {
                outputGrid.Rows[i].Cells["inPin"].Value = "IN" + i;
                outputGrid.Rows[i].Cells["routeFunction"].Value = "";
                outputGrid.Rows[i].Cells["outDetail"].Value = "";
            }
        }


        private void cboxOutFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxOutFunction.Tag != null)
            {
                int rowIndex = (int)cboxOutFunction.Tag;

                outputGrid.Rows[rowIndex].Cells["outRouteFunction"].Value = cboxOutFunction.SelectedItem.ToString();
                cboxOutFunction.Tag = null;
                cboxOutFunction.Visible = false;
            }
        }

        private void cboxOutBasic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxOutBasic.Tag != null)
            {
                int rowIndex = (int)cboxOutBasic.Tag;

                outputGrid.Rows[rowIndex].Cells["outDetail"].Value = cboxOutBasic.SelectedItem.ToString();
                cboxOutBasic.Tag = null;
                cboxOutBasic.Visible = false;
            }
        }

        private void cboxOutMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxOutMotor.Tag != null)
            {
                int rowIndex = (int)cboxOutMotor.Tag;

                outputGrid.Rows[rowIndex].Cells["outDetail"].Value = cboxOutMotor.SelectedItem.ToString();
                cboxOutMotor.Tag = null;
                cboxOutMotor.Visible = false;
            }
        }

        private void cboxOutTrig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxOutTrig.Tag != null)
            {
                int rowIndex = (int)cboxOutTrig.Tag;

                outputGrid.Rows[rowIndex].Cells["outDetail"].Value = cboxOutTrig.SelectedItem.ToString();
                cboxOutTrig.Tag = null;
                cboxOutTrig.Visible = false;
            }
        }

        private void cboxOutLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxOutLocal.Tag != null)
            {
                int rowIndex = (int)cboxOutLocal.Tag;

                outputGrid.Rows[rowIndex].Cells["outDetail"].Value = cboxOutLocal.SelectedItem.ToString();
                cboxOutLocal.Tag = null;
                cboxOutLocal.Visible = false;
            }
        }

        private void cboxOutAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxOutAD.Tag != null)
            {
                int rowIndex = (int)cboxOutAD.Tag;

                outputGrid.Rows[rowIndex].Cells["outDetail"].Value = cboxOutAD.SelectedItem.ToString();
                cboxOutAD.Tag = null;
                cboxOutAD.Visible = false;
            }
        }

        private void cboxOutInLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxOutInLine.Tag != null)
            {
                int rowIndex = (int)cboxOutInLine.Tag;

                outputGrid.Rows[rowIndex].Cells["outDetail"].Value = cboxOutInLine.SelectedItem.ToString();
                cboxOutInLine.Tag = null;
                cboxOutInLine.Visible = false;
            }
        }

        private void btOutSave_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filePath = Application.StartupPath + @"\BeamFile";
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
            saveFileDialog1.Filter = "bm文件(*.bm)|*.bm|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                writeToXML(saveFileDialog1.FileName);
            }
        }

        private void writeToXML(string file)
        {
            ClassBeamFile beamFile = new ClassBeamFile();
            beamFile.txSize = 32;
            for (int i = 0; i < beamFile.txElementBin.Length; i++)
            {
                beamFile.txElementBin[i] = (uint)0;
            }

            beamFile.txElementBin[0] = 0xfffffffe;
            beamFile.txElementBin[1] = 0x00000001;

            beamFile.txDelay[0] = 0;
            beamFile.txDelay[1] = 2.585f;
            beamFile.txDelay[2] = 2.567f;
            beamFile.txDelay[3] = 2.543f;
            beamFile.txDelay[4] = 2.513f;
            beamFile.txDelay[5] = 2.478f;
            beamFile.txDelay[6] = 2.438f;
            beamFile.txDelay[7] = 2.393f;
            beamFile.txDelay[8] = 2.342f;
            beamFile.txDelay[9] = 2.287f;
            beamFile.txDelay[10] = 2.227f;
            beamFile.txDelay[11] = 2.162f;
            beamFile.txDelay[12] = 2.092f;
            beamFile.txDelay[13] = 2.018f;
            beamFile.txDelay[14] = 1.940f;
            beamFile.txDelay[15] = 1.858f;
            beamFile.txDelay[16] = 1.772f;
            beamFile.txDelay[17] = 1.682f;
            beamFile.txDelay[18] = 1.588f;
            beamFile.txDelay[19] = 1.491f;
            beamFile.txDelay[20] = 1.391f;
            beamFile.txDelay[21] = 1.288f;
            beamFile.txDelay[22] = 1.182f;
            beamFile.txDelay[23] = 1.074f;
            beamFile.txDelay[24] = 0.963f;
            beamFile.txDelay[25] = 0.849f;
            beamFile.txDelay[26] = 0.733f;
            beamFile.txDelay[27] = 0.616f;
            beamFile.txDelay[28] = 0.496f;
            beamFile.txDelay[29] = 0.374f;
            beamFile.txDelay[30] = 0.251f;
            beamFile.txDelay[31] = 0.126f;


            /*for (int i = 0; i < beamFile.txDelay.Length; i++)
                beamFile.txDelay[i] = 0f;
            for (int i = 0; i < beamFile.txIntensify.Length; i++)
                beamFile.txIntensify[i] = 1.0f;*/

            beamFile.rxSize = 32;

            for (int i = 0; i < beamFile.rxElementBin.Length; i++)
                beamFile.rxElementBin[i] = (uint)0;

            beamFile.rxElementBin[0] = 0xffffff00;
            beamFile.rxElementBin[1] = 0x000000ff;

            beamFile.rxDelay[0] = 0.5907313f;
            beamFile.rxDelay[1] = 0.5107894f;
            beamFile.rxDelay[2] = 0.4292429f;
            beamFile.rxDelay[3] = 0.3461674f;
            beamFile.rxDelay[4] = 0.2616362f;
            beamFile.rxDelay[5] = 0.1757198f;
            beamFile.rxDelay[6] = 0.08848603f;
            beamFile.rxDelay[7] = 0f;
            beamFile.rxDelay[8] = 1.804825f;
            beamFile.rxDelay[9] = 1.789227f;
            beamFile.rxDelay[10] = 1.769998f;
            beamFile.rxDelay[11] = 1.747206f;
            beamFile.rxDelay[12] = 1.720924f;
            beamFile.rxDelay[13] = 1.691225f;
            beamFile.rxDelay[14] = 1.658188f;
            beamFile.rxDelay[15] = 1.621892f;
            beamFile.rxDelay[16] = 1.582418f;
            beamFile.rxDelay[17] = 1.539851f;
            beamFile.rxDelay[18] = 1.494278f;
            beamFile.rxDelay[19] = 1.445784f;
            beamFile.rxDelay[20] = 1.394460f;
            beamFile.rxDelay[21] = 1.340395f;
            beamFile.rxDelay[22] = 1.283680f;
            beamFile.rxDelay[23] = 1.224407f;
            beamFile.rxDelay[24] = 1.162667f;
            beamFile.rxDelay[25] = 1.098550f;
            beamFile.rxDelay[26] = 1.032149f;
            beamFile.rxDelay[27] = 0.9635538f;
            beamFile.rxDelay[28] = 0.8928529f;
            beamFile.rxDelay[29] = 0.8201347f;
            beamFile.rxDelay[30] = 0.7454855f;
            beamFile.rxDelay[31] = 0.6689901f;

            /*for (int i = 0; i < beamFile.rxDelay.Length; i++)
                beamFile.rxDelay[i] = 1.0f;
            for (int i = 0; i < beamFile.rxIntensify.Length; i++)
                beamFile.rxIntensify[i] = 1.0f;*/

            string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
            SystemConfig.WriteConfigData(file, "date", date);
            SystemConfig.WriteBase64Data(file, "beamFile", beamFile);
        }


        private void SessionHardWare_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    FormSave();
            //}
            this.Hide();
            bool isCorrectDatas = true;
            isCorrectDatas = checkOutRepeatNames();
            if (!isCorrectDatas)
            {
                this.TopMost = false;
                MessageShow.show("Detecting repeate cycel name!", "检测到重名通道");
                this.TopMost = true;
                e.Cancel = true;
                return;
            }
            if (sbeamlist != null)
            {
                SetScangate();
            }
            mainForm.addCheckBoxAscanItem();
            mainForm.addForms();
            clearHashTable();
            addHashTable();
            mainForm.startRun();
        }

        public void FormHide()
        {
            bool isCorrectDatas = true;
            isCorrectDatas = checkOutRepeatNames();
            if (!isCorrectDatas)
            {
                this.TopMost = false;
                MessageShow.show("Detecting repeate cycel name!", "检测到重名通道");
                this.TopMost = true;
                return;
            }
            this.Hide();
           
            mainForm.addForms();
            clearHashTable();
            addHashTable();
            mainForm.startRun();
            mainForm.addCheckBoxAscanItem();
        }
        private void clearHashTable()
        {
            hashTableForInfo = new Hashtable();
            hashTableForName = new Hashtable();
            hashTableForIndex = new Hashtable();
        }

        private void addHashTable()
        {
            for (int i = 0; i < sessionsAttrs.Count; i++)
            {
                if (sessionsAttrs[i].myHardInfo.enable)
                {

                    hashTableForInfo.Add(sessionsAttrs[i].myHardInfo.AssignedName, sessionsAttrs[i]);
                    hashTableForName.Add(i, sessionsAttrs[i].myHardInfo.AssignedName);
                    hashTableForIndex.Add(i, sessionsAttrs[i]);
                }
            }
        }

        public static void getInfo(string assignName, out int index, out int port)
        {
            SessionInfo info;
            if ((hashTableForInfo == null) || (hashTableForInfo.Count == 0))
            {
                port = -1;
                index = -1;
                return;
            }
            else
            {
                try
                {
                    info = (SessionInfo)hashTableForInfo[assignName];
                    port = info.port;
                    index = info.userIndex;
                }
                catch
                {
                    port = -1;
                    index = -1;
                }
            }
        }

        public static void getIndexPort(string assignName, out int sessionIndex, out int port)
        {
            SessionInfo info;
            if ((hashTableForInfo == null) || (hashTableForInfo.Count == 0))
            {
                port = -1;
                sessionIndex = -1;
                return;
            }
            else
            {
                try
                {
                    info = (SessionInfo)hashTableForInfo[assignName];
                    port = info.port;
                    sessionIndex = info.sessionIndex;
                }
                catch
                {
                    port = -1;
                    sessionIndex = -1;
                }
            }
        }

        public static void getInfo(string assignName, out int upPort)
        {
            SessionInfo info;
            if ((hashTableForInfo == null) || (hashTableForInfo.Count == 0))
            {
                upPort = -1;
                return;
            }
            else
            {
                try
                {
                    info = (SessionInfo)hashTableForInfo[assignName];
                    upPort = info.myHardInfo.upPort;
                }
                catch
                {
                    upPort = -1;
                }
            }
        }

        public static int getUserIndex(string assignName)
        {
            int result;
            SessionInfo info;
            if ((hashTableForInfo == null) || (hashTableForInfo.Count == 0))
                return -1;
            else
            {
                try
                {
                    info = (SessionInfo)hashTableForInfo[assignName];
                    result = info.userIndex;
                    return result;
                }
                catch
                {
                    result = -1;
                    return result;
                }
            }
        }

        public static string getSessionName(int index)
        {
            if ((hashTableForName == null) || (hashTableForName.Count == 0) || (index >= hashTableForName.Count))
                return null;
            else
                return (string)hashTableForName[index];
        }

        public static SessionInfo getSessionAttr(int index)
        {
            if ((hashTableForName == null) || (hashTableForName.Count == 0) || (index >= hashTableForName.Count))
                return null;
            else
                return (SessionInfo)hashTableForIndex[index];
        }

        /**Check out repeat names.*/
        private bool checkOutRepeatNames()
        {
            bool isCorrectDatas = true;
            string name;
            for (int i = 0; i < sessionsAttrs.Count; i++)
            {
                if (!sessionsAttrs[i].myHardInfo.enable)
                    continue;
                name = sessionsAttrs[i].myHardInfo.AssignedName;
                for (int j = i + 1; j < sessionsAttrs.Count; j++)
                {
                    if (!sessionsAttrs[j].myHardInfo.enable)
                        continue;

                    if (sessionsAttrs[j].myHardInfo.AssignedName == name)
                    {
                        isCorrectDatas = false;
                        return isCorrectDatas;
                    }
                }
            }
            return isCorrectDatas;
        }

        private void tabPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPage.SelectedIndex == 1)
                initVirtualGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTest test = new FormTest();
            test.ShowDialog();
        }
        //added by xll at 2017/3/3

        private void bstag_Click(object sender, EventArgs e)
        {
            tabPage.SelectedIndex = 0;
            bstag.FlatAppearance.BorderSize = 0;
            tstag.FlatAppearance.BorderSize = 1;
            irtag.FlatAppearance.BorderSize = 1;
            ortag.FlatAppearance.BorderSize = 1;
        }

        private void tstag_Click(object sender, EventArgs e)
        {
            tabPage.SelectedIndex = 1;
            bstag.FlatAppearance.BorderSize = 1;
            tstag.FlatAppearance.BorderSize = 0;
            irtag.FlatAppearance.BorderSize = 1;
            ortag.FlatAppearance.BorderSize = 1;
        }

        private void irtag_Click(object sender, EventArgs e)
        {
            tabPage.SelectedIndex = 2;
            bstag.FlatAppearance.BorderSize = 1;
            tstag.FlatAppearance.BorderSize = 1;
            irtag.FlatAppearance.BorderSize = 0;
            ortag.FlatAppearance.BorderSize = 1;
        }

        private void ortag_Click(object sender, EventArgs e)
        {
            tabPage.SelectedIndex = 3;
            bstag.FlatAppearance.BorderSize = 1;
            tstag.FlatAppearance.BorderSize = 1;
            irtag.FlatAppearance.BorderSize = 1;
            ortag.FlatAppearance.BorderSize = 0;
        }

        private void btInputSave_Click(object sender, EventArgs e)
        {

        }

        //added by xll at 2017/3/3
        private void bsload_Click(object sender, EventArgs e)
        {
            int boardnum = 0;
            string boardname = "";
            int i = 0;
            int j = 0;
            int prerowcount = 0;
            int virtualnum = 0;

            OpenFileDialog bsLoadDialog = new OpenFileDialog();
            string filePath = Application.StartupPath + @"\BeamFile";
            bsLoadDialog.Filter = "xml文件(*.xml)|*.xml|所有文件(*.*)|*.*";

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
                ClassBasicSetting basicSetting;
                String fileName = bsLoadDialog.FileName;
                basicSetting = (ClassBasicSetting)SystemConfig.ReadBase64Data(fileName, "basicSetting");
                boardnum = basicSetting.boradcount;
                if(boardnum <= 0)
                {
                    MessageShow.show("LoadErr: boradnum <= 0","载入配置错误：板卡数量错误");
                    return;
                }
                try
                {
                    basicGrid.RowCount = boardnum;

                    for (i = 0; i < basicGrid.RowCount; i++)
                    {
                        basicGrid.Rows[i].Cells["StartDelay"].Value = basicSetting.startdelay[i];
                        basicGrid.Rows[i].Cells["StopDelay"].Value = basicSetting.stopdelay[i];
                        basicGrid.Rows[i].Cells["PRF"].Value = basicSetting.prf[i];
                        basicGrid.Rows[i].Cells["Function"].Value = basicSetting.function[i];
                        basicGrid.Rows[i].Cells["TripMode"].Value = basicSetting.trigmode[i];
                        basicGrid.Rows[i].Cells["assignName"].Value = basicSetting.assignname[i];
                        boardname = (string)basicGrid.Rows[i].Cells["boardName"].Value;
                        //virtual
                        virtualnum = basicSetting.virtualcount[i];
                        prerowcount = virtualGrid.RowCount;
                        virtualGrid.RowCount += virtualnum;
                        for (j = prerowcount; j < virtualGrid.RowCount; j++)
                        {
                            int err = 0;
                            virtualGrid.Rows[j].Cells["board"].Value = boardname;
                            virtualGrid.Rows[j].Cells["board"].Tag = i;
                            virtualGrid.Rows[j].Cells["virtualIndex"].Value = j;
                            virtualGrid.Rows[j].Cells["virtualAssignedName"].Value = basicSetting.assignedname[i, j];

                            if (basicSetting.savemode == 0)
                            {
                                virtualGrid.Rows[j].Cells["BFpath"].Value = basicSetting.beamformerpath[i, j];
                                virtualGrid.Rows[j].Cells["BeamFormer"].Value = basicSetting.beamformername[i, j];
                                err = autoloadBF(basicSetting.beamformerpath[i, j], j);
                                if (err != 0)
                                {
                                    MessageShow.show("LoadBFErr", "载入BF文件错误");
                                }
                            }
                            else
                            {
                                virtualGrid.Rows[j].Cells["BeamFormer"].Value = j;
                                virtualGrid.Rows[j].Cells["transmitRadix"].Value = basicSetting.beamlist[j].txSize;
                                virtualGrid.Rows[j].Cells["receiveRaidx"].Value = basicSetting.beamlist[j].rxSize;
                                virtualGrid.Rows[j].Cells["BeamFormer"].Tag = basicSetting.beamlist[j];
                            }
                        }
                    }
                    chanPara = basicSetting.chanPara;
                }
                catch
                {
                    MessageShow.show("LoadErr: settingfile error", "载入配置错误：设置文件错误");
                    return;
                }
            }
        }

        private void bssave_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            int prerownum = 0;
            int virtualnum = 0;
            SaveFileDialog bsSaveDialog = new SaveFileDialog();

            string filePath = Application.StartupPath + @"\BeamFile";
            bsSaveDialog.Filter = "xml文件(*.xml)|*.xml|所有文件(*.*)|*.*";

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
            bsSaveDialog.InitialDirectory = filePath;
            bsSaveDialog.FilterIndex = 1;
            if (bsSaveDialog.ShowDialog() == DialogResult.OK)
            {
                ClassBasicSetting basicSetting = new ClassBasicSetting();
                String filename = bsSaveDialog.FileName;
                basicSetting.boradcount = basicGrid.RowCount;
                if (basicSetting.boradcount <= 0)
                {
                    MessageShow.show("SaveErr: boradnum <= 0", "保存配置错误：板卡数量错误");
                    return;
                }

                try
                {
                    for (i = 0; i < basicSetting.boradcount; i++)
                    {
                        basicSetting.startdelay[i] = Convert.ToDouble(basicGrid.Rows[i].Cells["StartDelay"].Value);
                        basicSetting.stopdelay[i] = Convert.ToDouble(basicGrid.Rows[i].Cells["StopDelay"].Value);
                        basicSetting.prf[i] = Convert.ToDouble(basicGrid.Rows[i].Cells["PRF"].Value);
                        basicSetting.function[i] = (string)basicGrid.Rows[i].Cells["Function"].Value;
                        basicSetting.trigmode[i] = (string)basicGrid.Rows[i].Cells["TripMode"].Value;
                        basicSetting.assignname[i] = (string)basicGrid.Rows[i].Cells["assignName"].Value;
                        //count virtualnum
                        prerownum += virtualnum;
                        virtualnum = 0;
                        for (j = 0; j < virtualGrid.RowCount; j++)
                        {
                            if (Convert.ToInt32(virtualGrid.Rows[j].Cells["board"].Tag) == i)
                            {
                                virtualnum++;
                            }
                        }
                        basicSetting.virtualcount[i] = virtualnum;

                        for (j = prerownum; j < virtualnum + prerownum; j++)
                        {
                            basicSetting.assignedname[i, j] = (string)virtualGrid.Rows[j].Cells["virtualAssignedName"].Value;
                            try
                            {
                                basicSetting.beamformerpath[i, j] = (string)virtualGrid.Rows[j].Cells["BFpath"].Value;
                                basicSetting.beamformername[i, j] = (string)virtualGrid.Rows[j].Cells["BeamFormer"].Value;
                                basicSetting.savemode = 0;
                            }
                            catch
                            {
                                basicSetting.savemode = 1;
                                basicSetting.beamlist.Add((ClassBeamFile)virtualGrid.Rows[j].Cells["BeamFormer"].Tag);
                            }
                        }
                        
                    }
                    basicSetting.chanPara = chanPara;
                }
                catch
                {
                    MessageShow.show("SaveErr: setting error", "保存配置错误：设置错误");
                    return;
                }
                string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
                date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
                SystemConfig.WriteConfigData(filename, "date", date);
                SystemConfig.WriteBase64Data(filename, "basicSetting", basicSetting);
            }

        }

//basic setting download
        private void bsDownload_Click(object sender, EventArgs e)
        {
            int boardcount;
            int rowIndex;
            int columnIndex;

            bool result = isPortCorrect();
            if (!result)
                return;

            boardcount = basicGrid.RowCount;
            for (rowIndex = 0; rowIndex < boardcount; rowIndex++)
            {
                for (columnIndex = 0; columnIndex < basicGrid.ColumnCount; columnIndex++)
                {
                    try
                    {
                        if (columnIndex == 9)
                        {
                            break;
                        }
                        string str = basicGrid.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                        /*The checkBox is checked.*/
                        if (columnIndex == BasicGridAssignNameColumnIndex)
                            sessionsAttrs[rowIndex].myHardInfo.AssignedName = str;
                        else if (columnIndex == BasicGridTripModeColumnIndex)
                            sessionsAttrs[rowIndex].myHardInfo.TrigMode = (TrigMode)Enum.Parse(typeof(TrigMode), str);
                        //add by xll at 2017-2-28
                        else if (columnIndex == BasicGridStartDelayColumnIndex)
                            sessionsAttrs[rowIndex].myHardInfo.StartDelay = Convert.ToDouble(str);
                        else if (columnIndex == BasicGridStopDelayColumnIndex)
                            sessionsAttrs[rowIndex].myHardInfo.StopDelay = Convert.ToDouble(str);
                        else if (columnIndex == BasicGridPRFColumnIndex)
                            sessionsAttrs[rowIndex].myHardInfo.PRF = Convert.ToDouble(str);
                        //add by xll at 2017-2-28
                        else if (columnIndex == BasicGridColumnIndex)
                        {
                            if (str == "True")
                            {
                                sessionsAttrs[rowIndex].myHardInfo.enable = true;
                            }
                            /*The checkBox is unchecked.*/
                            else if (str == "False")
                            {
                                sessionsAttrs[rowIndex].myHardInfo.enable = false;
                            }
                        }
                    }
                    catch
                    {
                        MessageShow.show("row" + Convert.ToString(rowIndex) + " column" + Convert.ToString(columnIndex)+" download error", "下发参数错误");
                        return;
                    }
                }
            }
        }
//when load setting auto load BF file
        private int autoloadBF(string path, int rowIndex)
        {
            int err = 0;
            try
            {
                ClassBeamFile beamFile;
                beamFile = ReadFromXML(path);
                String[] names = path.Split('\\');
                virtualGrid.Rows[rowIndex].Cells["transmitRadix"].Value = beamFile.txSize;
                virtualGrid.Rows[rowIndex].Cells["receiveRaidx"].Value = beamFile.rxSize;
                virtualGrid.Rows[rowIndex].Cells["BeamFormer"].Tag = beamFile;
            }
            catch
            {
                err = -1;
            }

            return err;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            basicGrid.RowCount++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            basicGrid.Rows.Remove(virtualGrid.CurrentRow);
        }

        public void Sscanset(List<SBeamList> sBeamList)
        {
            this.Show();
            int i = 0;
            virtualGrid.RowCount = sBeamList.Count;
            for (i = 0; i < sBeamList.Count; i++)
            {
                virtualGrid.Rows[i].Cells["virtualIndex"].Value = i;
                virtualGrid.Rows[i].Cells["BeamFormer"].Value = i;
                virtualGrid.Rows[i].Cells["transmitRadix"].Value = sBeamList[i].beamfile.txSize;
                virtualGrid.Rows[i].Cells["receiveRaidx"].Value = sBeamList[i].beamfile.rxSize;
                virtualGrid.Rows[i].Cells["BeamFormer"].Tag = sBeamList[i].beamfile;
                virtualGrid.Rows[i].Cells["virtualAssignedName"].Value = sBeamList[i].assignName;
            }
            this.sbeamlist = sBeamList;
        }

        public void SetScangate()
        {
            int offset = 0;
            for (int i = 0; i < sbeamlist.Count(); i++)
            {
                int error_code;
                double delay = sbeamlist[i].timeStart;
                double range = sbeamlist[i].timeSum;
                if (i == 1)
                {
                    offset = 1;
                }
                uint sessionIndex = (uint)sessionsAttrs[i + offset].sessionIndex;
                uint port = (uint)sessionsAttrs[i + offset].port;

                error_code = SetGateDAQ.Delay(sessionIndex, port, GateType.B, delay);
                if (error_code != 0)
                    return;

                error_code = SetGateDAQ.Width(sessionIndex, port, GateType.B, range);
                if (error_code != 0)
                    return;
            }
        }

        public void FormLoad()
        {
            virtualGrid.Rows.Clear();
            string filename = "SessionHardWare";
            string filepath = SystemConfig.GlobalLoad(filename);

            if (filepath == "")
            {
                return;
            }
            int boardnum = 0;
            string boardname = "";
            int i = 0;
            int j = 0;
            int prerowcount = 0;
            int virtualnum = 0;

            ClassBasicSetting basicSetting;
            basicSetting = (ClassBasicSetting)SystemConfig.ReadBase64Data(filepath, "basicSetting");
            detectionmode = (DetectionMode)SystemConfig.ReadBase64Data(filepath, "detectionmode");
            boardnum = basicSetting.boradcount;
            if (boardnum <= 0)
            {
                MessageShow.show("LoadErr: boradnum <= 0", "载入配置错误：板卡数量错误");
                return;
            }
            try
            {
                basicGrid.RowCount = boardnum;

                for (i = 0; i < basicGrid.RowCount; i++)
                {
                    basicGrid.Rows[i].Cells["StartDelay"].Value = basicSetting.startdelay[i];
                    basicGrid.Rows[i].Cells["StopDelay"].Value = basicSetting.stopdelay[i];
                    basicGrid.Rows[i].Cells["PRF"].Value = basicSetting.prf[i];
                    basicGrid.Rows[i].Cells["Function"].Value = basicSetting.function[i];
                    basicGrid.Rows[i].Cells["TripMode"].Value = basicSetting.trigmode[i];
                    basicGrid.Rows[i].Cells["assignName"].Value = basicSetting.assignname[i];
                    boardname = (string)basicGrid.Rows[i].Cells["boardName"].Value;

                    //virtual
                    virtualnum = basicSetting.virtualcount[i];
                    prerowcount = virtualGrid.RowCount;
                    virtualGrid.RowCount += virtualnum;
                    for (j = prerowcount; j < virtualGrid.RowCount; j++)
                    {
                        int err = 0;
                        virtualGrid.Rows[j].Cells["board"].Value = boardname;
                        virtualGrid.Rows[j].Cells["board"].Tag = i;
                        virtualGrid.Rows[j].Cells["virtualIndex"].Value = j;
                        virtualGrid.Rows[j].Cells["virtualAssignedName"].Value = basicSetting.assignedname[i, j];
                        if(basicSetting.savemode == 0)
                        {
                            virtualGrid.Rows[j].Cells["BFpath"].Value = basicSetting.beamformerpath[i, j];
                            virtualGrid.Rows[j].Cells["BeamFormer"].Value = basicSetting.beamformername[i, j];
                            err = autoloadBF(basicSetting.beamformerpath[i, j], j);
                            if (err != 0)
                            {
                                MessageShow.show("LoadBFErr", "载入BF文件错误");
                            }
                        }
                        else
                        {
                            virtualGrid.Rows[j].Cells["BeamFormer"].Value = j;
                            virtualGrid.Rows[j].Cells["transmitRadix"].Value = basicSetting.beamlist[j].txSize;
                            virtualGrid.Rows[j].Cells["receiveRaidx"].Value = basicSetting.beamlist[j].rxSize;
                            virtualGrid.Rows[j].Cells["BeamFormer"].Tag = basicSetting.beamlist[j];                           
                        }
                    }
                }
                
                chanPara = basicSetting.chanPara;
            }
            catch
            {
                MessageShow.show("LoadErr: settingfile error", "载入配置错误：设置文件错误");
                return;
            }

            mainForm.SetDetection(detectionmode);
            btVSave_Click(null, null);
        }

        public void FormSave()
        {
            string filename = "SessionHardWare";
            string filepath = "";
            filepath = SystemConfig.GlobalSave(filename);

            int i = 0;
            int j = 0;
            int prerownum = 0;
            int virtualnum = 0;

            ClassBasicSetting basicSetting = new ClassBasicSetting();
            basicSetting.boradcount = basicGrid.RowCount;
            if (basicSetting.boradcount <= 0)
            {
                MessageShow.show("SaveErr: boradnum <= 0", "保存配置错误：板卡数量错误");
                return;
            }

            try
            {
                for (i = 0; i < basicSetting.boradcount; i++)
                {
                    basicSetting.startdelay[i] = Convert.ToDouble(basicGrid.Rows[i].Cells["StartDelay"].Value);
                    basicSetting.stopdelay[i] = Convert.ToDouble(basicGrid.Rows[i].Cells["StopDelay"].Value);
                    basicSetting.prf[i] = Convert.ToDouble(basicGrid.Rows[i].Cells["PRF"].Value);
                    basicSetting.function[i] = (string)basicGrid.Rows[i].Cells["Function"].Value;
                    basicSetting.trigmode[i] = (string)basicGrid.Rows[i].Cells["TripMode"].Value;
                    basicSetting.assignname[i] = (string)basicGrid.Rows[i].Cells["assignName"].Value;
                    //count virtualnum
                    prerownum += virtualnum;
                    virtualnum = 0;
                    for (j = 0; j < virtualGrid.RowCount; j++)
                    {
                        if (Convert.ToInt32(virtualGrid.Rows[j].Cells["board"].Tag) == i)
                        {
                            virtualnum++;
                        }
                    }
                    basicSetting.virtualcount[i] = virtualnum;

                    for (j = prerownum; j < virtualnum + prerownum; j++)
                    {
                        basicSetting.assignedname[i, j] = (string)virtualGrid.Rows[j].Cells["virtualAssignedName"].Value;
                        try
                        {
                            basicSetting.beamformerpath[i, j] = (string)virtualGrid.Rows[j].Cells["BFpath"].Value;
                            basicSetting.beamformername[i, j] = (string)virtualGrid.Rows[j].Cells["BeamFormer"].Value;
                            basicSetting.savemode = 0;
                        }
                        catch
                        {
                            basicSetting.savemode = 1;
                            basicSetting.beamlist.Add((ClassBeamFile)virtualGrid.Rows[j].Cells["BeamFormer"].Tag);
                        }
                    }
                    
                }
                basicSetting.chanPara = chanPara;
            }
            catch
            {
                MessageShow.show("SaveErr: setting error", "保存配置错误：设置错误");
                return;
            }

            string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
            
            SystemConfig.WriteConfigData(filepath, "date", date);
            SystemConfig.WriteBase64Data(filepath, "basicSetting", basicSetting);
            SystemConfig.WriteBase64Data(filepath, "detectionmode", detectionmode);
        }

        private void btnLdbeam_Click(object sender, EventArgs e)
        {
            //Read from FormFocus
            beamList = mainForm.GetBeamlist();
            chanPara = mainForm.GetChanpara();
            detectionmode = mainForm.GetDetection();
            virtualGrid.RowCount = beamList.Count;

            //Add to virtualGrid
            for (int i = 0; i < beamList.Count; i++)
            {
                virtualGrid.Rows[i].Cells["virtualIndex"].Value = i;
                virtualGrid.Rows[i].Cells["BeamFormer"].Value = i;
                virtualGrid.Rows[i].Cells["virtualAssignedName"].Value = chanPara[i].name;
                virtualGrid.Rows[i].Cells["transmitRadix"].Value = beamList[i].txSize;
                virtualGrid.Rows[i].Cells["receiveRaidx"].Value = beamList[i].rxSize;
                virtualGrid.Rows[i].Cells["BeamFormer"].Tag = beamList[i];
            }
        }
    }
}
