using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Timers;
using System.Runtime.InteropServices;
using autsql;
namespace Ascan
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 垃圾回收器声明引用
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="dwMinimumWorkingSetSize"></param>
        /// <param name="dwMaximumWorkingSetSize"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(int hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        /**0,1,3,...,SessionInfo.sessionNum - 1 are the real boards, and SessionInfo.sessionNum,...,sessionInfo.count - 1 are the virtual boards.*/
        public List<SessionInfo> sessionsInfo;
        public QueueManager queueManager;
        public ThreadManager threadManager;

        /**A timer to show states of thread.*/
        private System.Timers.Timer timerForStatus;

        /**Is thread running.*/
        private static bool isStart;
        public static bool IsStart                                                                                                                                                                                   
        {
            get { return isStart; }
        }

        private static object stopLock = new object();
        /**When it is true, do not use the UI thread.*/
        private static bool isToStop = false;
        public static bool IsToStop
        {
            get
            {
                lock (stopLock)
                {
                    return isToStop;
                }
            }
        }


        /**Last status of the boards.*/
        private bool lastBoardsStatus;
        /**Last status of the threads.*/
        private bool lastThreadsStatus;

        protected RunMode measMode;

        public static SynchronizationContext syncContext = null;

        private List<ClassBeamFile> beamlist = new List<ClassBeamFile>();
        private List<ClassChanpara> chanpara = new List<ClassChanpara>();
        public UTPosition position = new UTPosition();
        public Groove groove = new Groove();
        public UltraWedge wedge = new UltraWedge();
        public UltraProbe probe = new UltraProbe();
        public List<Defect> sampleDefects =new List<Defect>();
        public DetectionMode detectionmode;
        public static Motion motion;
        public OderInfo oderInfo;
        public MainForm()
        {
            FormBoot.showInfo = "[启动进程] : 程序加载中，请稍后...";
            FormBoot.Instance.updateinfo(0);
            System.Threading.Thread.Sleep(1000);

            position.probePosition = 5.5;
            position.wedgePosition = 32;
            InitializeComponent();
            //splitContainer3.Parent = splitContainer1.Panel2;
            //splitContainer2.Parent = splitContainer1.Panel1;
            FormBoot.showInfo = "[启动进程] : 初始化日志文件";
            FormBoot.Instance.updateinfo(16);
            System.Threading.Thread.Sleep(300);
            LogFile.init();

            FormBoot.showInfo = "[启动进程] : 初始化语言设置";
            FormBoot.Instance.updateinfo(33);
            System.Threading.Thread.Sleep(300);
            MultiLanguage.lang = MultiLanguage.ReadDefaultLanguage();
            MultiLanguage.getNames(this);

            FormBoot.showInfo = "[启动进程] : 初始化DAQ设置";
            FormBoot.Instance.updateinfo(50);
            DaqAttrType.init();
            foreach (ToolStripMenuItem item in languageToolStrip.DropDownItems)
            {
                if (item.Tag.ToString() == MultiLanguage.lang)
                {
                    item.Checked = true;
                }
            }

            FormBoot.showInfo = "[启动进程] : 初始化运动控制";
            FormBoot.Instance.updateinfo(66);
            System.Threading.Thread.Sleep(300);
            motion = new Motion();
            motion.Initial_Motion();

            FormBoot.showInfo = "[启动进程] : 初始化硬件板卡";
            FormBoot.Instance.updateinfo(83);
            sessionsInfo = new List<SessionInfo>();
            InitialDevice();

            FormBoot.showInfo = "[启动进程] : 初始化完成!";
            FormBoot.Instance.updateinfo(100);
            System.Threading.Thread.Sleep(300);
            if (FormBoot.Instance != null)
            {
                FormBoot.Instance.BeginInvoke(new MethodInvoker(FormBoot.Instance.Dispose));
                FormBoot.Instance = null;
            }

            if (SessionInfo.isInitSuccess)
            {
                creatSessionsList();

                //init Form of sessionHardaWare
                FormList.mySessionsListForm = new SessionHardWare(this, sessionsInfo);
                //FormList.mySessionsListForm.Show();

            }
            isStart = false;

            syncContext = SynchronizationContext.Current;
            measMode = RunMode.ManulMode;

            InitialForm(sessionsInfo);
            SetBatchDAQ.Init(sessionsInfo);
            //FormList.FormGatePosition.FormLoad();
            //FormList.MDIChild.FormLoad();
            //FormList.FormProduct.FormLoad();
            //FormList.FormProbe.FormLoad();
            //FormList.FormWedge.FormLoad();
            //FormList.mySessionsListForm.FormHide();
            oderInfo = new OderInfo();
            //startRun();
        }


        //禁止窗体缩放、移动
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg != 0xA3 && m.WParam != (IntPtr)0xF012)
        //    {
        //        base.WndProc(ref m);
        //    }
        //}





        /**Initial device and get sessionNum.*/
        private void InitialDevice()
        {
            int error_code = 0;
            uint _sessionNum;
            string filePath;

            _sessionNum = 0;
            filePath = ".\\dev\\daq.ini";

            error_code = DAQ.USCOMM_InitDevice(filePath, ref _sessionNum);
            if (error_code == 0)
            {
                SessionInfo.sessionNum = _sessionNum;
                SessionInfo.portNum = _sessionNum;
                SessionInfo.isInitSuccess = true;
                
            }
            else
            {
                SessionInfo.sessionNum = 0;
                SessionInfo.portNum = 0;
                SessionInfo.isInitSuccess = false;
                MessageBox.Show("Initialization failed, please check!");
            }
        }

        private void creatSessionsList()
        {
            int cycleNum;

            if (!SessionInfo.isInitSuccess)
            {
                return;
            }
            cycleNum = (int)SessionInfo.sessionNum;

            for (int i = 0; i < cycleNum; i++)
            {
                SessionInfo tmp_attrs = new SessionInfo(i, i, 0);
                sessionsInfo.Add(tmp_attrs);
            }
        }

        /**Change current language to Chinese.*/
        private void ChineseMenuItem_Click(object sender, EventArgs e)
        {
            selectCurrentLanguage(sender);
        }

        /**Change current language to English.*/
        private void EnglishMenuItem_Click(object sender, EventArgs e)
        {
            selectCurrentLanguage(sender);
        }

        /**Change current language.*/
        private void selectCurrentLanguage(object sender)
        {
            foreach (ToolStripMenuItem item in languageToolStrip.DropDownItems)
            {
                item.Checked = false;
            }
            MultiLanguage.lang = ((ToolStripMenuItem)sender).Tag.ToString();
            MultiLanguage.WriteDefaultLanguage(MultiLanguage.lang);
            foreach (Form Frm in Application.OpenForms)
            {
                MultiLanguage.getNames(Frm);
            }
            ((ToolStripMenuItem)sender).Checked = true;
        }

        /**
         *@brief Initial FormList.
        */
        private void InitialForm(List<SessionInfo> sessions)
        {
            //this.tbShow.Region = new Region(new RectangleF(this.tbManualMode.Left, this.tbManualMode.Top, 
                //this.tbManualMode.Width, this.tbManualMode.Height)); //don't show the title of tableControl
            
            FormList.FormDAC = new FormDAC();
            FormList.FormGatePosition = new FormGatePosition();
            FormList.FormGateInfo = new FormGateInfo();
            FormList.FormMaterialVelocity = new FormMaterialVelocity();
            FormList.FormMDAC = new FormMDAC();
            FormList.FormProbeDelay = new FormProbeDelay();
            FormList.FormToranceMonitor = new FormToleranceMonitor();
            FormList.FormLaunchParameters = new FormLaunchParameters();
            FormList.FormConditioningParameters = new FormConditioningParameters();
            FormList.FormTriggerMode = new FormTriggerMode();
            FormList.MDIChild = new MDIChild(sessions,this);
            FormList.FormProbe = new FormProbe(this);
            FormList.FormWedge = new FormWedge(this);
            FormList.FormProduct = new FormProduct(this);
            FormList.FormRecordFigure = new FormRecordFigure();
            FormList.FormDetectionMode = new FormDetectionMode(this, sessionsInfo);
            FormList.FormMotion = new FormMotion();
            FormList.FormBatch = new FrmMain();
            FormList.Formsscan = new FormSscan(this);

            addForms();
            //RefreshModeComboBox();

            //cmbType.SelectedIndex = 2;
            //cmbDirection.SelectedIndex=2;
            //cmbGroup.SelectedIndex=4;
        }

        //Refresh the tableControl according to the measurement mode
        protected virtual void RefreshTableControl()
        {
            if (this.measMode == RunMode.ManulMode)
            {
                tbManualMode.Parent = this.tbShow;
                this.tbShow.Dock = DockStyle.Fill;
                tbAutoMode.Parent = null;
            }
            else if (this.measMode == RunMode.Auto)
            {
                this.tbShow.Dock = DockStyle.Fill;
                if (FormList.FormMeasurement == null)
                {
                    FormList.FormMeasurement = new AscanMeasureMap();
                }
                addFormToPanels(FormList.FormMeasurement, this.tbAutoMode);

                tbAutoMode.Parent = this.tbShow;
                tbManualMode.Parent = null;
            }
        }

        //Refresh the mode comboBox
        //private void RefreshModeComboBox()
        //{
        //    this.toolStripMeasMode.SelectedIndex = (int)this.measMode;
        //}

        //private void toolStripMeasMode_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.measMode = (RunMode)toolStripMeasMode.SelectedIndex;
        //    RefreshTableControl();
        //    RunMode mode = this.measMode;
        //    if (mode == RunMode.CheckMode)
        //        mode = RunMode.Auto;
        //    int err = 0;
        //    if (!isStart)
        //        return;

        //    int cycleNum = (int)SessionInfo.sessionNum;

        //    for (int i = 0; i < cycleNum; i++)
        //    {
        //        err += SetGlobalControlDAQ.RunMode((uint)sessionsInfo[i].sessionIndex, (uint)sessionsInfo[i].port, mode);//this.measMode);
        //    }

        //    //err = SetGlobalControlDAQ.RunMode(0, 0,this.measMode);
        //    if (err != 0)
        //    {
        //        MessageShow.show("Set Mode failor!", "设置模式失败！");
        //        return;
        //    }

        //}

        protected virtual void measurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormList.FormMeasurement == null)
            {
                FormList.FormMeasurement = new AscanMeasureMap();
            }
            FormList.FormMeasurement.Show();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string homeFolderPath;
            string initialPath;
            string[] subfolderPath;
            string pathForSplit;//in order to get ascanNum
            uint ascanNum;

            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.ShowNewFolderButton = false;

            dialog.SelectedPath = Application.StartupPath + @"\HardWare";
            initialPath = Application.StartupPath + @"\HardWare";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                homeFolderPath = dialog.SelectedPath;
                pathForSplit = homeFolderPath + @"\Board";
                if (homeFolderPath == initialPath ||
                    !homeFolderPath.Contains(initialPath))
                {
                    MessageShow.show("Need to select a folder in" + initialPath,
                         "没有在" + initialPath + "目录下选择一个文件夹!");
                    return;
                }

                subfolderPath = Directory.GetDirectories(homeFolderPath);
                if (subfolderPath != null)
                {
                    for (int i = 0; i < subfolderPath.Length; i++)
                    {
                        int lenth = subfolderPath[i].Length;
                        //get ascanNum
                        ascanNum = Convert.ToUInt32(subfolderPath[i].Substring(pathForSplit.Length));
                        uint ascanPort = (uint)sessionsInfo[(int)ascanNum].port;
                        Config.load(subfolderPath[i], ascanNum, ascanPort);
                    }
                }
            }  

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectFilePath;
            string filePath = Application.StartupPath + @"\HardWare";

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = filePath;

            string str = Directory.GetDirectoryRoot(filePath);
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

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectFilePath = dialog.SelectedPath;
                if (selectFilePath == filePath && !selectFilePath.Contains(filePath))
                {
                    MessageShow.show("There is no new folder in" + filePath, 
                        "没有在" + filePath + "目录下新建文件夹!");
                    return;
                }
                saveDAQPara(selectFilePath);
            }
        }

        /**Save each openning board parameter to xml*/
        private void saveDAQPara(string path)
        {
            string boardIndex;
            string boardPath;//path for each board parameter to save
            int sessionIndex;
            uint ascanNum;
            bool sessionEnable = false;
            
            foreach (SessionInfo session in sessionsInfo)
            {
                sessionEnable = session.myHardInfo.enable;
                sessionIndex = session.myHardInfo.index;
                ascanNum = (uint)sessionIndex;
                uint ascanPort = (uint)sessionsInfo[(int)ascanNum].port;

                if (sessionEnable)
                {
                    boardIndex = "Board" + sessionIndex;
                    boardPath = path + @"\boardIndex";

                    if (Directory.Exists(boardPath))
                    {
                        Directory.Delete(boardPath, true);
                    }

                    Directory.CreateDirectory(boardPath);
                    Config.save(boardPath, ascanNum, ascanPort);
                }
            }
        }

        protected virtual void startToolStrip1_Click(object sender, EventArgs e)
        {
            //垃圾回收，释放资源，减少内存占用
            //SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle.ToInt32(), -1, -1);

            if (!SessionInfo.isInitSuccess)
            {
                MessageShow.show("Hardware initialization failed, please check!", "硬件初始化失败，请检查！");
            }

            if (FormList.FormMeasurement != null)
            {
                bool isCycelCorrect = FormList.FormMeasurement.isBoardNameInMeasureCorrect();
                if (!isCycelCorrect)
                {
                    MessageShow.show("Some cycles'name in measurement are not the same with those we set, please reset them.",
                        "融合配置中部分通道名称与设定不符，请重设。");
                    return;
                }
            }

            if (!isStart)
            {
                if ((FormList.FormMeasurement != null) && (!FormList.FormMeasurement.IsSaved))
                {
                    DialogResult result = MessageShow.showSelecting("Datas in measurement map are not saved and start inspecting will clear these datas. Do you want to continue?",
                   "融合图未保存，启动检测将会清空数据。是否继续?");
                    if (result == DialogResult.No)
                        return;
                }

                //We create threadManager and queueManager here because in different solution, we may have different threads,
                //we can just override this funciton to change the function of threads
                if (threadManager == null && queueManager == null)
                    initThreadsAndQueues();

                int err = SetGlobalControlDAQ.RunMode(0, 0, this.measMode);
                if (err != 0)
                {
                    MessageShow.show("Set Mode failor!", "设置模式失败！");
                    return;
                }

                threadManager.threadsStart();
                timerForStatus.Start();

                startSessions();
                LogFile.write("开始检测");

                isStart = true;

                if (FormList.FormMeasurement != null)
                    FormList.FormMeasurement.startInspect();
            }
        }

        public void startRun()
        {
            //垃圾回收，释放资源，减少内存占用
            //SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle.ToInt32(), -1, -1);

            if (!SessionInfo.isInitSuccess)
            {
                MessageShow.show("Hardware initialization failed, please check!", "硬件初始化失败，请检查！");
            }

            if (FormList.FormMeasurement != null)
            {
                bool isCycelCorrect = FormList.FormMeasurement.isBoardNameInMeasureCorrect();
                if (!isCycelCorrect)
                {
                    MessageShow.show("Some cycles'name in measurement are not the same with those we set, please reset them.",
                        "融合配置中部分通道名称与设定不符，请重设。");
                    return;
                }
            }

            if (!isStart)
            {
                if ((FormList.FormMeasurement != null) && (!FormList.FormMeasurement.IsSaved))
                {
                    DialogResult result = MessageShow.showSelecting("Datas in measurement map are not saved and start inspecting will clear these datas. Do you want to continue?",
                   "融合图未保存，启动检测将会清空数据。是否继续?");
                    if (result == DialogResult.No)
                        return;
                }

                //We create threadManager and queueManager here because in different solution, we may have different threads,
                //we can just override this funciton to change the function of threads
                if (threadManager == null && queueManager == null)
                    initThreadsAndQueues();

                int err = SetGlobalControlDAQ.RunMode(0, 0, this.measMode);
                if (err != 0)
                {
                    MessageShow.show("Set Mode failor!", "设置模式失败！");
                    return;
                }

                threadManager.threadsStart();
                timerForStatus.Start();

                startSessions();
                LogFile.write("开始检测");

                isStart = true;

                if (FormList.FormMeasurement != null)
                    FormList.FormMeasurement.startInspect();
            }
        }

        /**Init threads, queues and a timer for monitoring.*/
        private void initThreadsAndQueues()
        {
            //init queueManager and threadManager
            queueManager = new QueueManager((int)SessionInfo.sessionNum);
            threadManager = new ThreadManager((int)SessionInfo.sessionNum, queueManager);

            //init timer for monitoring
            timerForStatus = new System.Timers.Timer();
            timerForStatus.Elapsed += new ElapsedEventHandler(showStatues);
            timerForStatus.Interval = ConstParameter.TimerInterval;
            timerForStatus.AutoReset = true;

            lastBoardsStatus = false;
        }

        private void startSessions()
        {
            int err = 0;
            bool isDone = true;
            StreamEnable streamEnable = new StreamEnable();

            if (!SessionInfo.isInitSuccess)
                return;

            for (int i = 0; i < SessionInfo.sessionNum; i++)
            {
                SessionInfo info = sessionsInfo[i];
                if (!info.isRun)
                {
                    err = DAQ.daqRun((uint)info.sessionIndex);
                    if (err == 0)
                    {
                        info.isRun = true;
                        err = DAQ.USCOMM_StreamStart((uint)info.sessionIndex, ref streamEnable);
                        if (err == 0)
                            info.isStreamStart = true;
                        else
                        {
                            MessageShow.show("Session " + info.sessionIndex + " stream starts error!", "板卡" + info.sessionIndex + "数据流启动失败！");
                            isDone = false;
                            break;
                        }
                    }
                    else
                    {
                        MessageShow.show("Session " + info.sessionIndex + " starts to run error!", "板卡" + info.sessionIndex + "启动失败！");
                        isDone = false;
                        break;
                    }
                }
            }

            if (!isDone)
                stopSessions();
        }

        private void stopSessions()
        {
            int err = 0;
            int count = 0;
            StreamEnable streamEnable = new StreamEnable();

            if (!SessionInfo.isInitSuccess)
                return;

            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i < SessionInfo.sessionNum; i++)
            {
                SessionInfo info = sessionsInfo[i];
                if (info.isStreamStart)
                {
                    err = DAQ.USCOMM_StreamStop((uint)info.sessionIndex, ref streamEnable);
                    if (err == 0)
                        info.isStreamStart = false;

                    else
                    {
                        MessageShow.show("Session " + info.sessionIndex + " stream stops error!", "板卡" + info.sessionIndex + "数据流关闭失败！");
                        continue;
                    }
                }
            }

            while (count++ < 3 && !threadManager.isThreadsExit())
                Thread.Sleep(3000);

            for (int i = 0; i < SessionInfo.sessionNum; i++)
            {
                SessionInfo info = sessionsInfo[i];
                if (info.isRun)
                {
                    err = DAQ.daqStop((uint)info.sessionIndex);
                    if (err == 0)
                        info.isRun = false;
                    else
                    {
                        MessageShow.show("Session " + info.sessionIndex + " stops error!", "板卡" + info.sessionIndex + "关闭失败！");
                        continue;
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void showStatues(object source, System.Timers.ElapsedEventArgs e)
        {
            bool resultForBoards, resultForThreads;

            resultForBoards = threadManager.isBoardsStatusOK();
            resultForThreads = threadManager.isThreadsStatusOK();

            try
            {
                if (resultForBoards != lastBoardsStatus)
                {
                    if (resultForBoards)
                        statusBoards.Image = Ascan.Properties.Resources.Connect;
                    else
                        statusBoards.Image = Ascan.Properties.Resources.Disconnect;
                    lastBoardsStatus = resultForBoards;
                }

                if (resultForThreads != lastThreadsStatus)
                {
                    if (resultForThreads)
                        statusThreads.Image = Ascan.Properties.Resources.Connect;
                    else
                        statusThreads.Image = Ascan.Properties.Resources.Disconnect;
                    lastThreadsStatus = resultForThreads;
                }
            }
            catch { }
            System.GC.Collect();
        }

        /**Add hard information include hard index and assigned name to 
         * the item of cmbAscan,the format of the item name in cmbAscan
         * is index-assignedName.
         */
        public void addCheckBoxAscanItem()
        {
            List<int> cmbgroupInt = new List<int>();
            List<string> cmbgroupString = new List<string>();

            cmbGroup.Items.Clear();
            cmbAscan.Items.Clear();

            string assignedName;
            string itemName;

            for (int i = 0; i < sessionsInfo.Count; i++)
            {
                if (sessionsInfo[i].myHardInfo.enable == true)
                {
                    assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                    itemName = i + "-" + assignedName;
                    cmbAscan.Items.Add(itemName);

                    addGroupItem(sessionsInfo[i].type, ref cmbgroupInt, ref  cmbgroupString); 
                }
            }

            foreach (string str in cmbgroupString)
            {
                cmbGroup.Items.Add(str);
            }
            cmbGroup.Items.Add("ALL");

            if (cmbAscan.Items.Count > 0)
                cmbAscan.SelectedIndex = 0;

        }

        public void addGroupItem(int a,ref List<int> cmbgroupInt, ref List<string> cmbgroupString)
        {
            if (!cmbgroupInt.Contains(a))
            {
                switch (a)
                {
                    case 0:
                        {
                            cmbgroupInt.Add(a);
                            cmbgroupString.Add("FILL");
                        } break;
                    case 1:
                        {
                            cmbgroupInt.Add(a);
                            cmbgroupString.Add("HP");
                        }break;
                    case 2:
                        {
                            cmbgroupInt.Add(a);
                            cmbgroupString.Add("LCP");
                        } break;
                    case 3:
                        {
                            cmbgroupInt.Add(a);
                            cmbgroupString.Add("ROOT");
                        } break;
                    case 4:
                        {
                            cmbgroupInt.Add(a);
                            cmbgroupString.Add("Couple");
                        } break;
                }
            }
        }


        bool checkBoxBatchSetisOn = false;
        private void cmbAscan_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxBatchSetisOn = checkBoxBatchSet.Checked;

            if (FormList.MDIChild == null)
                return;
 
            uint ascanIndex = getAscanIndexAndAssignedName(cmbAscan.SelectedItem.ToString());
            uint sessionIndex = (uint)sessionsInfo[(int)ascanIndex].sessionIndex;
            uint port = (uint)sessionsInfo[(int)ascanIndex].port;

            int error_code;
            error_code = SetAscanVideoDAQ.Active(sessionIndex, port, AscanVideoActive.ON);
            if (error_code != 0)
                return;

            SelectAscan.userIndex = ascanIndex;//set selected ascan to update
            SelectAscan.sessionIndex = sessionIndex;
            SelectAscan.port = (uint)sessionsInfo[(int)ascanIndex].port;


            //if (sessionsInfo[(int)ascanIndex].zonename != null && sessionsInfo[(int)ascanIndex].zonename.Substring(0, 1) == "C")
            //{
            //    SetBatchDAQ.isOn = false;
            //    checkBoxBatchSet.Enabled = false;
            //}
            //else
            //{
            //    checkBoxBatchSet.Enabled = true;
            //    SetBatchDAQ.isOn = checkBoxBatchSetisOn;
            //}


            SetBatchDAQ.isOn = false;
            FormList.MDIChild.init();
            FormList.FormGatePosition.init();
            FormList.FormTriggerMode.init();
            FormList.FormConditioningParameters.init();
            FormList.FormLaunchParameters.init();
            //FormList.FormMaterialVelocity.initMatVelocity();
            SetBatchDAQ.isOn = checkBoxBatchSetisOn;


            if (sessionIndex == 0)
            {
                checkBoxEnvelop.Enabled = false;
                trackBarEnelopSpeed.Enabled = false;
            }
            else if (sessionIndex == 1)
            {
                checkBoxEnvelop.Enabled = true;
                trackBarEnelopSpeed.Enabled = true;
            }  
        }

        private List<SessionInfo> batchSessions;
        private void filter()
        {
            cmbAscan.Items.Clear();
            batchSessions = new List<SessionInfo>();
            string assignedName;
            string itemName;

            int typeIndex=-1, directionIndex=-1, groupIndex=-1;
            typeIndex = cmbType.SelectedIndex;
            directionIndex = cmbDirection.SelectedIndex;

            if (cmbGroup.SelectedItem == null)
            { groupIndex = -1; }
            else if (cmbGroup.SelectedItem.ToString() == "FILL")
            { groupIndex = 0; }
            else if (cmbGroup.SelectedItem.ToString() == "HP")
            { groupIndex = 1; }
            else if (cmbGroup.SelectedItem.ToString() == "LCP")
            { groupIndex = 2; }
            else if (cmbGroup.SelectedItem.ToString() == "ROOT")
            { groupIndex = 3; }
            else if (cmbGroup.SelectedItem.ToString() == "Couple")
            { groupIndex = 4; }
            else
            { groupIndex = 5; }


            //1ALL
            if (typeIndex == 2 && directionIndex != 2 && groupIndex != 5)
            {
                for (int i = 0; i < sessionsInfo.Count; i++)
                {
                    if (sessionsInfo[i].myHardInfo.enable == true)
                    {
                        if ( sessionsInfo[i].LR == directionIndex && sessionsInfo[i].type == groupIndex)
                        {
                            assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                            itemName = i + "-" + assignedName;
                            cmbAscan.Items.Add(itemName);
                            batchSessions.Add(sessionsInfo[i]);
                            //if (sessionsInfo[i].zonename != null && sessionsInfo[i].zonename.Substring(0, 1) != "C")
                            //    batchSessions.Add(sessionsInfo[i]);
                           
                        }
                    }
                }
            }
            else if (typeIndex != 2 && directionIndex == 2 && groupIndex != 5)
            {
                for (int i = 0; i < sessionsInfo.Count; i++)
                {
                    if (sessionsInfo[i].myHardInfo.enable == true)
                    {
                        if (sessionsInfo[i].sessionIndex == typeIndex && sessionsInfo[i].type == groupIndex)
                        {
                            assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                            itemName = i + "-" + assignedName;
                            cmbAscan.Items.Add(itemName);
                            //if (sessionsInfo[i].zonename != null && sessionsInfo[i].zonename.Substring(0, 1) != "C")
                            batchSessions.Add(sessionsInfo[i]);
                        }
                    }
                }
            }
            else if (typeIndex != 2 && directionIndex != 2 && groupIndex == 5)
            {
                for (int i = 0; i < sessionsInfo.Count; i++)
                {
                    if (sessionsInfo[i].myHardInfo.enable == true)
                    {
                        if (sessionsInfo[i].sessionIndex == typeIndex && sessionsInfo[i].LR == directionIndex)
                        {
                            assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                            itemName = i + "-" + assignedName;
                            cmbAscan.Items.Add(itemName);
                            //if (sessionsInfo[i].zonename != null && sessionsInfo[i].zonename.Substring(0, 1) != "C")
                            batchSessions.Add(sessionsInfo[i]);
                        }
                    }
                }
            }
            //2ALL
            else if (typeIndex == 2 && directionIndex == 2 && groupIndex != 5)
            {
                for (int i = 0; i < sessionsInfo.Count; i++)
                {
                    if (sessionsInfo[i].myHardInfo.enable == true)
                    {
                        if (sessionsInfo[i].type == groupIndex)
                        {
                            assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                            itemName = i + "-" + assignedName;
                            cmbAscan.Items.Add(itemName);
                            //if (sessionsInfo[i].zonename != null && sessionsInfo[i].zonename.Substring(0, 1) != "C")
                            batchSessions.Add(sessionsInfo[i]);
                        }
                    }
                }
            }
            else if (typeIndex != 2 && directionIndex == 2 && groupIndex ==5)
            {
                for (int i = 0; i < sessionsInfo.Count; i++)
                {
                    if (sessionsInfo[i].myHardInfo.enable == true)
                    {
                        if (sessionsInfo[i].sessionIndex == typeIndex )
                        {
                            assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                            itemName = i + "-" + assignedName;
                            cmbAscan.Items.Add(itemName);
                            //if (sessionsInfo[i].zonename != null && sessionsInfo[i].zonename.Substring(0, 1) != "C")
                            batchSessions.Add(sessionsInfo[i]);
                        }
                    }
                }

            }
            else if (typeIndex == 2 && directionIndex != 2 && groupIndex == 5)
            {
                for (int i = 0; i < sessionsInfo.Count; i++)
                {
                    if (sessionsInfo[i].myHardInfo.enable == true)
                    {
                        if (sessionsInfo[i].LR == directionIndex)
                        {
                            assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                            itemName = i + "-" + assignedName;
                            cmbAscan.Items.Add(itemName);
                            //if (sessionsInfo[i].zonename != null && sessionsInfo[i].zonename.Substring(0, 1) != "C")
                            batchSessions.Add(sessionsInfo[i]);
                        }
                    }
                }
            }
            //3ALL
            else if (typeIndex == 2 && directionIndex == 2 && groupIndex == 5)
            {
                for (int i = 0; i < sessionsInfo.Count; i++)
                {
                    if (sessionsInfo[i].myHardInfo.enable == true)
                    {
                            assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                            itemName = i + "-" + assignedName;
                            cmbAscan.Items.Add(itemName);
                            //if (sessionsInfo[i].zonename!=null&&sessionsInfo[i].zonename.Substring(0, 1) != "C")
                            batchSessions.Add(sessionsInfo[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < sessionsInfo.Count; i++)
                {
                    if (sessionsInfo[i].myHardInfo.enable == true)
                    {
                        if (sessionsInfo[i].sessionIndex == typeIndex && sessionsInfo[i].LR == directionIndex && sessionsInfo[i].type == groupIndex)
                        {
                            assignedName = sessionsInfo[i].myHardInfo.AssignedName;
                            itemName = i + "-" + assignedName;
                            cmbAscan.Items.Add(itemName);
                            //if (sessionsInfo[i].zonename != null && sessionsInfo[i].zonename.Substring(0, 1) != "C")
                            batchSessions.Add(sessionsInfo[i]);
                        }
                    }
                }

            }

            SetBatchDAQ.Init(batchSessions);

            if (cmbAscan.Items.Count > 0)
                cmbAscan.SelectedIndex=0;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 1)
            {
                cmbGroup.SelectedIndex = cmbGroup.Items.Count - 1;
                cmbDirection.SelectedIndex = 2;
            }
            filter();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 1)
            {
                cmbGroup.SelectedIndex = cmbGroup.Items.Count - 1;
              
            }
            filter();
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 1)
            {
               
                cmbDirection.SelectedIndex = 2;
            }
            filter();
        }


        /**Get ascan index and assigned name from cmbAscan select item.
         * @param comboBoxItemName, the comboBox selected item name.
         */
        private uint getAscanIndexAndAssignedName(string comboBoxItemName)
        {
            string assignedName;
            int index = comboBoxItemName.IndexOf("-");
            string result = comboBoxItemName.Substring(0, index);
            uint ascanIndex = Convert.ToUInt32(result);
            assignedName = sessionsInfo[(int)ascanIndex].myHardInfo.AssignedName;
            /*
             * 最初版本的代码，以此改变某个lable的txt（显示虚拟通道名称）。
             * 现，将MIDChild最上方panel（含虚拟通道名字、八个框框）删去
            FormList.MDIChild.AssignedNameLabel.Text = assignedName;
            */
            return ascanIndex;
        }
        
        public void addFormToPanels2(Form form, Panel panel)
        {
            form.Show();
            form.Hide();
            panel.Controls.Clear();
            form.TopLevel = false;
            form.Parent = panel; 
            panel.Controls.Add(form);
            form.Show();
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
        }
        public void addFormToPanels(Form form, Panel panel)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            form.Parent = panel;
            panel.Controls.Add(form);
            form.Show();
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
        }

        /**add FormGatePosition and FormMeasurement.*/
        public void addForms()
        {
            //add MDIChild
            addFormToPanels(FormList.MDIChild, splitContainer2.Panel1);

            //add Record Figure
            addFormToPanels(FormList.FormRecordFigure, splitContainer2.Panel2);

            //add FormGatePosition
            //addFormToPanels(FormList.FormGatePosition, splitContainer3.Panel1);
            addFormToPanels(FormList.FormGatePosition, tabGate);
            addFormToPanels(FormList.FormMotion, tabMotion);

            //add FormGateInfo
            addFormToPanels(FormList.FormGateInfo, splitContainer3.Panel2);
        }

        /*
        private void panelCheckBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(SystemColors.GradientActiveCaption, 3), panelCheckBox.Width-3, 
                0, panelCheckBox.Width-3, panelCheckBox.Height);
        }
        */

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int err;

            if (!isStart)
                return;

            lock(stopLock)
                isToStop = true;
            LogFile.flush();
            stopSessions();

            err = DAQ.USCOMM_CloseDevice();
            if (err != 0)
            {
                MessageShow.show("Close device failed!", "关闭仪器失败！");
                return;
            }

            SessionInfo.isInitSuccess = false;

            if (timerForStatus != null)
            {
                timerForStatus.Stop();
                timerForStatus = null;
            }

            if (threadManager != null)
            {
                threadManager.Clear();
                threadManager = null;
            }

            if (queueManager != null)
            {
                queueManager.Clear();
                queueManager = null;
            }

            sessionsInfo = null;
            isStart = false;
            lock (stopLock)
                isToStop = false;
        }

        private void stopRun()
        {
            int err;

            if (!isStart)
                return;

            lock (stopLock)
                isToStop = true;
            LogFile.flush();
            stopSessions();

            err = DAQ.USCOMM_CloseDevice();
            if (err != 0)
            {
                MessageShow.show("Close device failed!", "关闭仪器失败！");
                return;
            }

            SessionInfo.isInitSuccess = false;

            if (timerForStatus != null)
            {
                timerForStatus.Stop();
                timerForStatus = null;
            }

            if (threadManager != null)
            {
                threadManager.Clear();
                threadManager = null;
            }

            if (queueManager != null)
            {
                queueManager.Clear();
                queueManager = null;
            }

            sessionsInfo = null;
            isStart = false;
            lock (stopLock)
                isToStop = false;
        }

        private void initToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sessionsInfo = new List<SessionInfo>();
            InitialDevice();

            if (SessionInfo.isInitSuccess)
            {
                creatSessionsList();

                //init Form of sessionHardaWare
                SessionHardWare mySessionsListForm = new SessionHardWare(this, sessionsInfo);
                mySessionsListForm.TopMost = true;
                mySessionsListForm.Show();
            }
            isStart = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SystemConfig.saveFlag)
            {
                DialogResult result = MessageBox.Show("是否关闭", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    stopRun();
                }
                else
                {
                    e.Cancel = true;
                }
                
            }
            else
            {
                DialogResult result = MessageBox.Show("是否保存", "提示", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (SystemConfig.fname == null)
                    {
                        e.Cancel = true;
                        MessageShow.show("No Previous File,Please Save As", "无原文件，请新建保存");
                        FormSavePara savePara = new FormSavePara();
                        savePara.Show();
                        return;
                    }
                    else
                    {
                        SystemConfig.saveFlag = true;
                        FormList.mySessionsListForm.FormSave();
                        FormList.FormProduct.FormSave();
                        FormList.FormProbe.FormSave();
                        FormList.FormWedge.FormSave();
                        SystemConfig.SavePara();
                        stopRun();
                    }


                }
                else if (result == DialogResult.No)
                {
                    stopRun();
                }
                else
                {
                    e.Cancel = true;
                }
            }
                                                
        }
        private void toolStripAutoMode_Click(object sender, EventArgs e)
        {
            int err;

            if (!isStart)
                return;


            err = SetGlobalControlDAQ.RunMode((uint)SelectAscan.sessionIndex, (uint)SelectAscan.port, RunMode.Auto);
            if (err != 0)
            {
                MessageShow.show("Set AutoMode failor!", "设置自动模式失败！");
                return;
            }
        }

        private void manualModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int err;

            if (!isStart)
                return;


            err = SetGlobalControlDAQ.RunMode((uint)SelectAscan.sessionIndex, (uint)SelectAscan.port, RunMode.ManulMode);
            if (err != 0)
            {
                MessageShow.show("Set AutoMode failor!", "设置自动模式失败！");
                return;
            }
        }

        private void autoModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int err;

            if (!isStart)
                return;


            err = SetGlobalControlDAQ.RunMode((uint)SelectAscan.sessionIndex, (uint)SelectAscan.port, RunMode.Auto);
            if (err != 0)
            {
                MessageShow.show("Set AutoMode failor!", "设置自动模式失败！");
                return;
            }
        }



        private void manualModeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int err;

            if (!isStart)
                return;


            err = SetGlobalControlDAQ.RunMode((uint)SelectAscan.sessionIndex, (uint)SelectAscan.port, RunMode.ManulMode);
            if (err != 0)
            {
                MessageShow.show("Set ManualMode failor!", "设置模式失败！");
                return;
            }
        }

        private void checkBoxBatchSet_Click(object sender, EventArgs e)
        {
            if (batchSessions==null)
            {
                MessageBox.Show("虚拟通道未进行筛选，不可进行批量设置", "WARNING");
                checkBoxBatchSet.Checked = false;
            }
            else
            {
                if (checkBoxBatchSet.Checked == true)
                {
                    SetBatchDAQ.isOn = true;
                    //SetBatchDAQ.Init(batchSessions);
                    //SetBatchDAQ.Param(SelectAscan.sessionIndex, SelectAscan.port);
                }
                else
                    SetBatchDAQ.isOn = false;
            }
        }
        private void checkBoxBatchSet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBatchSet.Checked == true)
            {
                SetBatchDAQ.isOn = true;
                //SetBatchDAQ.Init(batchSessions);
                //SetBatchDAQ.Param(SelectAscan.sessionIndex, SelectAscan.port);
            }
            else
                SetBatchDAQ.isOn = false;
        }

        private void stripBtn_Hardware_Click(object sender, EventArgs e)
        {
            //if (SessionInfo.isInitSuccess)
            //{
                //creatSessionsList();

                //init Form of sessionHardaWare
            FormList.mySessionsListForm.Show();
            //}
        }


        //public List<string> zoomname;
        //public bool newVch=false; 


        public void Getgroove(Groove gro)
        {
            groove = gro;
        }

        public void Getsampledefs(List<Defect> ds)
        {
            sampleDefects = ds;
        }

        private void stripBtn_Wedge_Click(object sender, EventArgs e)
        {
            FormList.FormWedge.Show();
        }

        public void Getwedge(UltraWedge wed)
        {
            wedge = wed;
        }

        public void Getposition(UTPosition pos)
        {
            position = pos;
        }

        private void stripBtn_Probe_Click(object sender, EventArgs e)
        {
            FormList.FormProbe.Show();
        }

        public void Getprobe(UltraProbe pro)
        {
            probe = pro;
        }

        public void FocusLaw()
        {
            FormFocus FormFocus = new FormFocus(this, groove, wedge, probe, position);
            FormFocus.Show();
        }

        public void SetChan(List<ClassBeamFile> beam, List<ClassChanpara> chan)
        {
            if (beam != null && chan != null)
            {
                beamlist = beam;
                chanpara = chan;
            }
        }

        public List<ClassBeamFile> GetBeamlist()
        {
            return beamlist;
        }

        public List<ClassChanpara> GetChanpara()
        {
            return chanpara;
        }

        private void stripBtn_open_Click(object sender, EventArgs e)
        {
            FormLoadPara loadPara = new FormLoadPara();
            loadPara.Show();
        }

        private void stripBtn_save_Click(object sender, EventArgs e)
        {
            if (SystemConfig.fname == null)
            {
                MessageShow.show("No Previous File,Please Save As", "无原文件，请新建保存");
                FormSavePara savePara = new FormSavePara();
                savePara.Show();
                return;
            }
            else
            {
                SystemConfig.saveFlag = true;
                FormList.mySessionsListForm.FormSave();
                FormList.FormProduct.FormSave();
                FormList.FormProbe.FormSave();
                FormList.FormWedge.FormSave();
                SystemConfig.SavePara();
                MessageShow.show("Saved Completely", "保存完成");
            }
        }

        public void GetFocuspara(ref Groove gro, ref UltraWedge wed, ref UltraProbe pro, ref UTPosition pos)
        {
            gro = groove;
            wed = wedge;
            pro = probe;
            pos = position;
        }

        public DetectionMode GetDetection()
        {
            return detectionmode;
        }

        public void SetDetection(DetectionMode detmode)
        {
            if (detmode != null)
            {
                detectionmode = detmode;
            }
        }

        private void checkBoxEnvelop_Click(object sender, EventArgs e)
        {
            if (checkBoxEnvelop.Checked == true)
            {
                if (SetBatchDAQ.isOn)
                    SetBatchDAQ.EnvlopActive(SelectAscan.sessionIndex, AscanEnvelopActive.ON);
                else
                    SetAscanVideoDAQ.EnvlopActive(SelectAscan.sessionIndex, SelectAscan.port, AscanEnvelopActive.ON);
            }
            else
            {
                if (SetBatchDAQ.isOn)
                    SetBatchDAQ.EnvlopActive(SelectAscan.sessionIndex, AscanEnvelopActive.OFF);
                else
                    SetAscanVideoDAQ.EnvlopActive(SelectAscan.sessionIndex, SelectAscan.port, AscanEnvelopActive.OFF);
            }
        }

        private void trackBarEnelopSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            uint value = (uint)(trackBarEnelopSpeed.Value * 32767 / 1000);
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, value);
            else
                SetAscanVideoDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, SelectAscan.port, value);
        }

        private void trackBarEnelopSpeed_Scroll(object sender, EventArgs e)
        {
            uint value = (uint)(trackBarEnelopSpeed.Value * 32767 / 1000);
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, value);
            else
                SetAscanVideoDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, SelectAscan.port, value);
        }

        private void RadioButtonPositive_Click(object sender, EventArgs e)
        {
            bool isSetPre = false;
            if (SetBatchDAQ.isOn)
                isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, AscanWaveDectionMode.SemiPositve);
            else
                isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, AscanWaveDectionMode.SemiPositve);

            //if (isSetPre == true)
            //    FormList.MDIChild.preRadReceiver.Checked = true;
            //else
            //    FormList.MDIChild.preRadReceiver = RadioButtonPositive;

            FormList.MDIChild.initTeeChartAxe();
        }

        private void RadioButtonNegative_Click(object sender, EventArgs e)
        {
            bool isSetPre = false;
            if (SetBatchDAQ.isOn)
                isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, AscanWaveDectionMode.SemiNegtive);
            else
                isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, AscanWaveDectionMode.SemiNegtive);

            //if (isSetPre == true)
            //    FormList.MDIChild.preRadReceiver.Checked = true;
            //else
            //    FormList.MDIChild.preRadReceiver = RadioButtonPositive;

            FormList.MDIChild.initTeeChartAxe();
        }

        private void RadioButtonFullWave_Click(object sender, EventArgs e)
        {
            bool isSetPre = false;
            if (SetBatchDAQ.isOn)
                isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, AscanWaveDectionMode.Full);
            else
                isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, AscanWaveDectionMode.Full);

            //if (isSetPre == true)
            //    FormList.MDIChild.preRadReceiver.Checked = true;
            //else
            //    FormList.MDIChild.preRadReceiver = RadioButtonPositive;

            FormList.MDIChild.initTeeChartAxe();
        }

        private void RadioButtonRF_Click(object sender, EventArgs e)
        {
            bool isSetPre = false;
            if (SetBatchDAQ.isOn)
                isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, AscanWaveDectionMode.Rf);
            else
                isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, AscanWaveDectionMode.Rf);

            //if (isSetPre == true)
            //    FormList.MDIChild.preRadReceiver.Checked = true;
            //else
            //    FormList.MDIChild.preRadReceiver = RadioButtonPositive;

            FormList.MDIChild.initTeeChartAxe();
        }

        private void RadioButtonThrough_Click(object sender, EventArgs e)
        {
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.RecieverMode(SelectAscan.sessionIndex, RecieverType.Pc);
            else
                SetPulserTransmitDAQ.RecieverMode(SelectAscan.sessionIndex, SelectAscan.port, RecieverType.Pc);
        }

        private void RadioButtonReflection_Click(object sender, EventArgs e)
        {
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.RecieverMode(SelectAscan.sessionIndex, RecieverType.Pe);
            else
                SetPulserTransmitDAQ.RecieverMode(SelectAscan.sessionIndex, SelectAscan.port, RecieverType.Pe);
        }

        private void btndetection_Click(object sender, EventArgs e)
        {
            FormList.FormDetectionMode.Show();
            FormList.FormDetectionMode.LoadUT();
        }

        private void stripBtnproduct_Click(object sender, EventArgs e)
        {
            FormList.FormProduct.Show();
        }

        private void stripBtn_Report_Click(object sender, EventArgs e)
        {
            openReport();
        }


        protected virtual void openReport()
        { 
        
        }

        public  OderInfo GetOrderinfo()
        {
            return oderInfo;
        }

        private void stripBtnUT_Click(object sender, EventArgs e)
        {
            //this.measMode = (RunMode)toolStripMeasMode.SelectedIndex;
            this.measMode = RunMode.ManulMode;
            RefreshTableControl();
            RunMode mode = this.measMode;
            int err = 0;
            if (!isStart)
                return;

            int cycleNum = (int)SessionInfo.sessionNum;

            for (int i = 0; i < cycleNum; i++)
            {
                err += SetGlobalControlDAQ.RunMode((uint)sessionsInfo[i].sessionIndex, (uint)sessionsInfo[i].port, mode);//this.measMode);
            }
            if (err != 0)
            {
                MessageShow.show("Set Mode failor!", "设置模式失败！");
                return;
            }
        }

        private void stripBtnMeasureMode_Click(object sender, EventArgs e)
        {
            this.measMode = RunMode.CheckMode;
            RefreshTableControl();
            RunMode mode = RunMode.Auto;
            int err = 0;
            if (!isStart)
                return;

            int cycleNum = (int)SessionInfo.sessionNum;

            for (int i = 0; i < cycleNum; i++)
            {
                err += SetGlobalControlDAQ.RunMode((uint)sessionsInfo[i].sessionIndex, (uint)sessionsInfo[i].port, mode);//this.measMode);
            }
            if (err != 0)
            {
                MessageShow.show("Set Mode failor!", "设置模式失败！");
                return;
            }
        }

        private void stripBtnAUT_Click(object sender, EventArgs e)
        {
            this.measMode = RunMode.Auto;
            RefreshTableControl();
            RunMode mode = RunMode.Auto;
            int err = 0;
            if (!isStart)
                return;

            int cycleNum = (int)SessionInfo.sessionNum;

            for (int i = 0; i < cycleNum; i++)
            {
                err += SetGlobalControlDAQ.RunMode((uint)sessionsInfo[i].sessionIndex, (uint)sessionsInfo[i].port, mode);//this.measMode);
            }
            if (err != 0)
            {
                MessageShow.show("Set Mode failor!", "设置模式失败！");
                return;
            }
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            if (FormList.FormBatch == null)
            {
                FormList.FormBatch = new FrmMain();
            }
            FormList.FormBatch.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addFormToPanels(FormList.Formsscan, tbSscan);           
        }

    }

    public class FormList
    {
        public static FormDAC FormDAC;
        public static FormGatePosition FormGatePosition;
        public static FormGateInfo FormGateInfo;
        public static FormMaterialVelocity FormMaterialVelocity;
        public static FormMDAC FormMDAC;
        public static FormProbeDelay FormProbeDelay;
        public static FormToleranceMonitor FormToranceMonitor;
        public static MDIChild MDIChild;

        public static FormMeasurementMap FormMeasurement;
        public static FormMeasurementMap FormCalibrate;
        public static FormRecordFigure FormRecordFigure;
        public static FormConditioningParameters FormConditioningParameters;
        public static FormLaunchParameters FormLaunchParameters;
        public static FormTriggerMode FormTriggerMode;

        public static FormProbe FormProbe;
        public static FormWedge FormWedge;
        public static FormProduct FormProduct;
        public static FormDetectionMode FormDetectionMode;

        public static SessionHardWare mySessionsListForm;
        public static FormMotion FormMotion;
        public static FrmMain FormBatch;

        public static FormSscan Formsscan;
    }
}
