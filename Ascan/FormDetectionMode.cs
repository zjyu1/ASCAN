using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Ascan
{
    public partial class FormDetectionMode : Form, LoadandSave
    {
        public string detectionpath = "";

        //Link treenode to Chan 
        private Hashtable treechan =new Hashtable();
        private MainForm mainform;
        private UTPosition position = new UTPosition();
        private Groove groove = new Groove();
        private UltraWedge wedge = new UltraWedge();
        private UltraProbe probe = new UltraProbe();
        private bool isclick = false;
        private bool lastpa = false;
        private bool lastcouple = false;
        private bool lasttofd = false;
        private int curchanum = -1;
        private List<ClassChanpara> chanPara = new List<ClassChanpara>();
        private DetectionMode detectionmode = new DetectionMode();
        private List<SessionInfo> sessionsAttrs;

        public FormDetectionMode(MainForm mainform, List<SessionInfo> sessionsAttrs)
        {
            this.sessionsAttrs = sessionsAttrs;
            this.mainform = mainform;
            InitializeComponent();
            MultiLanguage.getNames(this);
            InitCommon();
            InitGate();
            ReadDetectionFile();
            pagetofd.Parent = null;

            foreach (SessionInfo se in sessionsAttrs)
            {
                if (se.sessionIndex == 1)
                {
                    TOFDDetectioninfo tofdinfo = new TOFDDetectioninfo();
                    detectionmode.tofdinfolist.Add(tofdinfo);
                }
            }
        }

        public void ReadDetectionFile()
        {
            namebox.Items.Clear();

            string path = Application.StartupPath + @"\DetectionMode";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            DirectoryInfo folder = new DirectoryInfo(path);

            foreach (FileInfo file in folder.GetFiles("*.xml"))
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                namebox.Items.Add(name);
            }
        }

        private void InitCommon()
        {
            if (sessionsAttrs.Count < 1 || sessionsAttrs == null)
                return;

            boardBox.Items.Clear();
            for (int i = 0; i < SessionInfo.sessionNum; i++)
                boardBox.Items.Add(sessionsAttrs[i].myHardInfo.BoardName);

            boardBox.SelectedIndex = 0;
        }

        private void InitGate()
        {
            gateBpanel.Visible = false;
        }

        public void SetChan(List<ClassChanpara> chanPara)
        {
            lastpa = false;
            lastcouple = false;
            detectionmode.painfolist.Clear();
            treechan.Clear();
            PADetectioninfo painfo;
            CoupleDetectioninfo coupleinfo;
            int i = 0;
            this.chanPara = chanPara;

            for (i = 0; i < chanPara.Count; i++)
            {
                if (chanPara[i].zonetype == (int)ZoneType.Couple)
                {
                    coupleinfo = new CoupleDetectioninfo(chanPara[i]);
                    detectionmode.coupleinfolist.Add(coupleinfo);
                }
                else
                {
                    painfo = new PADetectioninfo(chanPara[i]);                    
                    detectionmode.painfolist.Add(painfo);
                }
                treechan.Add(chanPara[i].name, i);
            }

            SetTree(); 
        }

        public void SetTree()
        {
            Hashtable zone = new Hashtable();
            int i = 0;
            int index = 0;
            string[] type = new string[5];

            tree.TopNode.Nodes.Clear();
            TreeNode node = new TreeNode("Zone");
            if (detectionmode.tofdinfolist != null)
            {
                tree.TopNode.Nodes.Add(node);
                node = new TreeNode("TOFD");
            }
            tree.TopNode.Nodes.Add(node);
            node = new TreeNode("L-Side");
            tree.TopNode.Nodes[0].Nodes.Add(node);
            node = new TreeNode("R-Side");
            tree.TopNode.Nodes[0].Nodes.Add(node);

            for (i = 0; i < chanPara.Count; i++)
            {
                if (chanPara[i].zonetype == (int)ZoneType.Fill)
                {
                    if (type[0] != "Fill")
                    {
                        type[0] = "Fill";
                        zone.Add(chanPara[i].zonetype, index);
                        index++;
                    }
                }
                else if (chanPara[i].zonetype == (int)ZoneType.HP)
                {
                    if (type[1] != "HP")
                    {
                        type[1] = "HP";
                        zone.Add(chanPara[i].zonetype, index);
                        index++;
                    }
                }
                else if (chanPara[i].zonetype == (int)ZoneType.LCP)
                {
                    if (type[2] != "LCP")
                    {
                        type[2] = "LCP";
                        zone.Add(chanPara[i].zonetype, index);
                        index++;
                    }
                }
                else if (chanPara[i].zonetype == (int)ZoneType.Root)
                {
                    if (type[3] != "Root")
                    {
                        type[3] = "Root";
                        zone.Add(chanPara[i].zonetype, index);
                        index++;
                    }
                }
                else if (chanPara[i].zonetype == (int)ZoneType.Couple)
                {
                    if (type[4] != "Couple")
                    {
                        type[4] = "Couple";
                        zone.Add(chanPara[i].zonetype, index);
                        index++;
                    }
                }
            }

            for (i = 0; i < 5; i++)
            {
                if (type[i] != null)
                {
                    TreeNode tmpnode = new TreeNode(type[i]);
                    tree.TopNode.Nodes[0].Nodes[0].Nodes.Add(tmpnode);
                    tmpnode = new TreeNode(type[i]);
                    tree.TopNode.Nodes[0].Nodes[1].Nodes.Add(tmpnode);
                }

            }

            for (i = 0; i < chanPara.Count; i++)
            {
                int dir = 0;
                if (chanPara[i].skew == 90)
                {
                    dir = 0;
                }
                else if (chanPara[i].skew == 270)
                {
                    dir = 1;
                }
                int typeindex = (int)zone[chanPara[i].zonetype];
                TreeNode tmpnode = new TreeNode(chanPara[i].name);
                tree.TopNode.Nodes[0].Nodes[dir].Nodes[typeindex].Nodes.Add(tmpnode);
            }

            tree.ExpandAll();  
        }

        public void UpdateSelectPAChannel(PADetectioninfo painfo)
        {
            bdelayBox.Text = Convert.ToString(Math.Round(painfo.delay,2));
            brangeBox.Text = Convert.ToString(Math.Round(painfo.range,2));
            bcalibraBox.Text = Convert.ToString(painfo.carlibrawave * 100);
            balarmBox.Text = Convert.ToString(painfo.alarmwave * 100);
            bsuppressBox.Text = Convert.ToString(painfo.supwave * 100);
            bdisplayBox.Text = Convert.ToString(painfo.displaywave * 100);
            if (painfo.strip)
            {
                bstrip.CheckState = CheckState.Checked;
            }
            else
            {
                bstrip.CheckState = CheckState.Unchecked;
            }
            if (painfo.bscan)
            {
                bscan.CheckState = CheckState.Checked;
            }
            else
            {
                bscan.CheckState = CheckState.Unchecked;
            }
            if (painfo.coupling)
            {
                bcoupling.CheckState = CheckState.Checked;
            }
            else
            {
                bcoupling.CheckState = CheckState.Unchecked;
            }
        }

        public void UpdateSelectCoupleChannel(CoupleDetectioninfo coupleinfo)
        {
            coupleIdelaybox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[0].delay, 2));
            coupleIrangebox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[0].range, 2));
            coupleIthrebox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[0].threshold, 2));
            coupleAdelaybox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[1].delay, 2));
            coupleArangebox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[1].range, 2));
            coupleAthrebox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[1].threshold, 2));
            coupleBdelaybox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[2].delay, 2));
            coupleBrangebox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[2].range, 2));
            coupleBthrebox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[2].threshold, 2));
            coupleCdelaybox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[3].delay, 2));
            coupleCrangebox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[3].range, 2));
            coupleCthrebox.Text = Convert.ToString(Math.Round(coupleinfo.gatedelay[3].threshold, 2));

            if (coupleinfo.coupling)
            {
                coupleBox.CheckState = CheckState.Checked;
            }
            else
            {
                coupleBox.CheckState = CheckState.Unchecked;
            }
        }

        //jpc
        public void UpdateSelectTOFD(TOFDDetectioninfo TOFDdetection)
        {
            bdelayBox.Text = Convert.ToString(Math.Round(TOFDdetection.delay, 2));
            brangeBox.Text = Convert.ToString(Math.Round(TOFDdetection.range, 2));
            bcalibraBox.Text = Convert.ToString(TOFDdetection.carlibrawave * 100);
            balarmBox.Text = Convert.ToString(TOFDdetection.alarmwave * 100);
            bsuppressBox.Text = Convert.ToString(TOFDdetection.supwave * 100);
            bdisplayBox.Text = Convert.ToString(TOFDdetection.displaywave * 100);
            if (TOFDdetection.bscan)
            {
                bscan.CheckState = CheckState.Checked;
            }
            else
            {
                bscan.CheckState = CheckState.Unchecked;
            }

            txtMateral.Text = TOFDdetection.materal;
            txtVelocity.Text = Convert.ToString(TOFDdetection.velocity);
            txtAngle.Text = Convert.ToString(TOFDdetection.angle);
            txtTLength.Text = Convert.ToString(TOFDdetection.toplength);
            txtBottomlength.Text = Convert.ToString(TOFDdetection.bottomlength);
            txtHeight.Text = Convert.ToString(TOFDdetection.height);
            txtFre.Text = Convert.ToString(TOFDdetection.freq);
            txtEleNum.Text = Convert.ToString(TOFDdetection.elenum);
            txtEleDia.Text = Convert.ToString(TOFDdetection.eledia);
            cmbReceiver.SelectedIndex = TOFDdetection.receiver;
            txtPCS.Text = Convert.ToString(TOFDdetection.pcs);
            txtRefractAngle.Text = Convert.ToString(TOFDdetection.refractangle);

        }

        public void UpdatePa()
        {
            couplepanel.Visible = false;
            gateBpanel.Visible = true;
            bstrip.Enabled = true;
            bcoupling.Enabled = true;
            this.gatePanel.Controls.Add(this.gateBpanel, 0, 0);
            ClearSet();
            pagetofd.Parent = null;
            probebtn.Visible = true;
            wedgebtn.Visible = true;
            focusbtn.Visible = true;
        }

        public void UpdateTOFD()
        {            
            this.gatePanel.Controls.Add(this.gateBpanel, 0, 0);
            gateBpanel.Visible = true;
            bstrip.Enabled = false;
            bcoupling.Enabled = false;
            couplepanel.Visible = false;
            ClearSet();
            pagetofd.Parent = settingControl;
            probebtn.Visible = false;
            wedgebtn.Visible = false;
            focusbtn.Visible = false;
        }

        public void UpdateCouple()
        {
            gateBpanel.Visible = false;
            bstrip.Enabled = true;
            bcoupling.Enabled = true;
            couplepanel.Visible = true;
            this.gatePanel.Controls.Add(this.couplepanel, 0, 0);
            pagetofd.Parent = null;
            probebtn.Visible = true;
            wedgebtn.Visible = true;
            focusbtn.Visible = true;
        }

        public void HideGatepanel()
        {
            gateBpanel.Visible = false;
            couplepanel.Visible = false;
            ClearSet();
        }

        public void ConfirmPAchan()
        {
            PADetectioninfo painfo = new PADetectioninfo(chanPara[curchanum]);
            painfo.delay = Convert.ToDouble(bdelayBox.Text);
            painfo.range = Convert.ToDouble(brangeBox.Text);
            painfo.carlibrawave = Convert.ToDouble(bcalibraBox.Text) / 100;
            painfo.alarmwave = Convert.ToDouble(balarmBox.Text) / 100;
            painfo.supwave = Convert.ToDouble(bsuppressBox.Text) / 100;
            painfo.displaywave = Convert.ToDouble(bdisplayBox.Text) / 100;
            if (bstrip.CheckState == CheckState.Checked)
            {
                painfo.strip = true;
            }
            else
            {
                painfo.strip = false;
            }
            if (bscan.CheckState == CheckState.Checked)
            {
                painfo.bscan = true;
            }
            else
            {
                painfo.bscan = false;
            }
            if (bcoupling.CheckState == CheckState.Checked)
            {
                painfo.coupling = true;
            }
            else
            {
                painfo.coupling = false;
            }

            if (checkBoxBatchSet.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < detectionmode.painfolist.Count; i++)
                {
                    detectionmode.painfolist[i].delay = painfo.delay;
                    detectionmode.painfolist[i].range = painfo.range;
                    detectionmode.painfolist[i].carlibrawave = painfo.carlibrawave;
                    detectionmode.painfolist[i].alarmwave = painfo.alarmwave;
                    detectionmode.painfolist[i].supwave = painfo.supwave;
                    detectionmode.painfolist[i].displaywave = painfo.displaywave;
                    detectionmode.painfolist[i].strip = painfo.strip;
                    detectionmode.painfolist[i].bscan = painfo.bscan;
                    detectionmode.painfolist[i].coupling = painfo.coupling;
                }
            }
            else
            {
                detectionmode.painfolist[curchanum] = painfo;
            }
            
        }

        public void ConfirmCouplechan()
        {
            CoupleDetectioninfo coupleinfo = new CoupleDetectioninfo(chanPara[curchanum]);
            coupleinfo.gatedelay[0].delay = Convert.ToDouble(coupleIdelaybox.Text);
            coupleinfo.gatedelay[0].range = Convert.ToDouble(coupleIrangebox.Text);
            coupleinfo.gatedelay[0].threshold = Convert.ToDouble(coupleIthrebox.Text);
            coupleinfo.gatedelay[1].delay = Convert.ToDouble(coupleAdelaybox.Text);
            coupleinfo.gatedelay[1].range = Convert.ToDouble(coupleArangebox.Text);
            coupleinfo.gatedelay[1].threshold = Convert.ToDouble(coupleAthrebox.Text);
            coupleinfo.gatedelay[2].delay = Convert.ToDouble(coupleBdelaybox.Text);
            coupleinfo.gatedelay[2].range = Convert.ToDouble(coupleBrangebox.Text);
            coupleinfo.gatedelay[2].threshold = Convert.ToDouble(coupleBthrebox.Text);
            coupleinfo.gatedelay[3].delay = Convert.ToDouble(coupleCdelaybox.Text);
            coupleinfo.gatedelay[3].range = Convert.ToDouble(coupleCrangebox.Text);
            coupleinfo.gatedelay[3].threshold = Convert.ToDouble(coupleCthrebox.Text);


            if (coupleBox.CheckState == CheckState.Checked)
            {
                coupleinfo.coupling = true;
            }
            else if (coupleBox.CheckState == CheckState.Unchecked)
            {
                coupleinfo.coupling = false;
            }

            detectionmode.coupleinfolist[curchanum - detectionmode.painfolist.Count()] = coupleinfo;
        }

        public void ConfirmCommon()
        {
            uint prf = 0;
            int channum = 0;
            int error_code = 0;
            channum = detectionmode.painfolist.Count + detectionmode.tofdinfolist.Count;
            try
            {
                detectionmode.detdistance = Convert.ToDouble(distanceBox.Text);
                detectionmode.circumpulse = Convert.ToInt32(circumBox.Text);
                detectionmode.detvelocity = Convert.ToDouble(velocityBox.Text);
                detectionmode.direction = directionBox.SelectedIndex;

                //int index = sessionsAttrs[0].sessionIndex;
                //int port = sessionsAttrs[0].port;
                //prf = (uint)(detectionmode.detvelocity * detectionmode.circumpulse * channum);
                //error_code = SetPulserTransmitDAQ.Prf((uint)index, (uint)port, prf);
                //if (error_code != 0)
                //    MessageShow.show("Set PRF failed!", "设置PRF失败！");
            }
            catch
            {
                MessageShow.show("Detection Mode Common Set Error", "检测模式通用设置错误");
                return;
            }


        }

        public void ConfirmTOFDchan()
        {
            TOFDDetectioninfo tofdinfo = new TOFDDetectioninfo();

            tofdinfo.delay = Convert.ToDouble(bdelayBox.Text);
            tofdinfo.range = Convert.ToDouble(brangeBox.Text);
            tofdinfo.carlibrawave = Convert.ToDouble(bcalibraBox.Text) / 100;
            tofdinfo.alarmwave = Convert.ToDouble(balarmBox.Text) / 100;
            tofdinfo.supwave = Convert.ToDouble(bsuppressBox.Text) / 100;
            tofdinfo.displaywave = Convert.ToDouble(bdisplayBox.Text) / 100;
            if (bscan.CheckState == CheckState.Checked)
            {
                tofdinfo.bscan = true;
            }
            else
            {
                tofdinfo.bscan = false;
            }
            tofdinfo.materal = txtMateral.Text;
            tofdinfo.velocity=Convert.ToDouble(txtVelocity.Text );
            tofdinfo.angle=Convert.ToInt32(txtAngle.Text);
            tofdinfo.toplength=Convert.ToDouble( txtTLength.Text);
            tofdinfo.bottomlength=Convert.ToDouble( txtBottomlength.Text);
            tofdinfo.height=Convert.ToDouble( txtHeight.Text);
            tofdinfo.freq=Convert.ToDouble(  txtFre.Text );
            tofdinfo.elenum=Convert.ToInt32( txtEleNum.Text);
            tofdinfo.eledia=Convert.ToDouble( txtEleDia.Text );
            tofdinfo.receiver = cmbReceiver.SelectedIndex;
            tofdinfo.pcs=Convert.ToDouble( txtPCS.Text );
            tofdinfo.refractangle=Convert.ToDouble( txtRefractAngle.Text);

            detectionmode.tofdinfolist[0] = tofdinfo;

        }

        public void ClearSet()
        {
            SearchControl(gateBContainer.Panel1);
            SearchControl(gateBContainer.Panel2);
        }

        public void SearchControl(Control ctrl)
        {
            foreach (Control newctrl in ctrl.Controls)
            {
                if (newctrl is TextBox)
                {
                    newctrl.Text = "";
                }

                if (newctrl is CheckBox)
                {
                    (newctrl as CheckBox).CheckState = CheckState.Unchecked;
                }
            }
        }

        public void LoadUT()
        {
            DisplayCommon();
            SetTree();
        }

        public void DisplayCommon()
        {
            distanceBox.Text = Convert.ToString(detectionmode.detdistance);
            velocityBox.Text = Convert.ToString(detectionmode.detvelocity);
            circumBox.Text = Convert.ToString(detectionmode.circumpulse);
            if (!namebox.Items.Contains(detectionmode.modename))
            {
                namebox.Items.Add(detectionmode.modename);
            }
            namebox.Text = detectionmode.modename;
            directionBox.SelectedIndex = detectionmode.direction;
        }

        public void FormLoad()
        {
            string filename = "DetectionMode";
            string filepath = SystemConfig.GlobalLoad(filename);

            if (filepath == "")
            {
                return;
            }

            try
            {
                treechan = (Hashtable)SystemConfig.ReadBase64Data(filepath, "treechan");
                chanPara = (List<ClassChanpara>)SystemConfig.ReadBase64Data(filepath, "chanPara");
                detectionmode = (DetectionMode)SystemConfig.ReadBase64Data(filepath, "detectionmode");
                mainform.SetDetection(detectionmode);
            }
            catch
            {
                MessageShow.show("DetectionMode Load Error", "检测模式载入错误");
                return;
            }
            detectionpath = filepath;
        }

        public void FormSave()
        {
            string filename = "DetectionMode";
            string filepath = "";
            filepath = SystemConfig.GlobalSave(filename);

            try
            {
                string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
                date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"

                SystemConfig.WriteConfigData(filepath, "date", date);
                SystemConfig.WriteBase64Data(filepath, "treechan", treechan);
                SystemConfig.WriteBase64Data(filepath, "chanPara", chanPara);
                SystemConfig.WriteBase64Data(filepath, "detectionmode", detectionmode);
            }
            catch
            {
                MessageShow.show("DetectionMode Save Error", "检测模式保存错误");
            }
        }

        private void focusbtn_Click(object sender, EventArgs e)
        {
            mainform.GetFocuspara(ref groove, ref wedge, ref probe, ref position);
            FormFocus formfocus = new FormFocus(mainform, groove, wedge, probe, position);
            formfocus.Show();
        }

        private void boardBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = boardBox.SelectedIndex;
            IDBox.Text = Convert.ToString(sessionsAttrs[i].port);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                TreeNode tmpnode = new TreeNode(Convert.ToString(i));
                tree.TopNode.Nodes[0].Nodes.Add(tmpnode);
            }
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (lastpa)
            {
                ConfirmPAchan();
            }
            else if (lastcouple)
            {
                ConfirmCouplechan();
            }
            else if(lasttofd)
            {
                ConfirmTOFDchan();
            }

            string name = e.Node.Text;
            if (name != "TOFD")
            {
                if (treechan[name] == null)
                {
                    HideGatepanel();
                    currentchan.Text = "";
                    lastpa = false;
                    lastcouple = false;
                    lasttofd = false;
                    settingControl.SelectedIndex = 0;
                    DisplayCommon();
                    currentchan.Text = "";
                    return;
                }

                settingControl.SelectedIndex = 1;
                curchanum = (int)treechan[name];
                if (curchanum < detectionmode.painfolist.Count)
                {
                    UpdatePa();
                    UpdateSelectPAChannel(detectionmode.painfolist[curchanum]);
                    lastpa = true;
                    lastcouple = false;
                    lasttofd = false;
                }
                else
                {
                    UpdateCouple();
                    UpdateSelectCoupleChannel(detectionmode.coupleinfolist[curchanum - detectionmode.painfolist.Count]);
                    lastpa = false;
                    lastcouple = true;
                    lasttofd = false;
                }
            }
            else
            {
                settingControl.SelectedIndex = 2;
                UpdateTOFD();
                UpdateSelectTOFD(detectionmode.tofdinfolist[0]);   //
                lastpa = false;
                lastcouple = false;
                lasttofd = true;
            }

            currentchan.Text = name;
        }

        private void probebtn_Click(object sender, EventArgs e)
        {
            FormList.FormProbe.Show();
        }

        private void wedgebtn_Click(object sender, EventArgs e)
        {
            FormList.FormWedge.Show();
        }

        private void confirm_Click(object sender, EventArgs e)
        {

        }

        private void FormDetectionMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            ConfirmCommon();
            mainform.SetDetection(detectionmode);
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            lastpa = false;
            curchanum = -1;
            detectionpath = "";
            detectionmode = new DetectionMode();
            chanPara = new List<ClassChanpara>();
            treechan = new Hashtable();
            tree.TopNode.Nodes.Clear();
            InitCommon();
            InitGate();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            detectionmode.modename = namebox.Text;
            if (detectionpath != "")
            {
                if (!System.IO.File.Exists(detectionpath))
                {
                    MessageShow.show("Current path doesn't exist ", "当前路径不存在");
                    return;
                }

                if (treechan != null && chanPara != null && detectionmode != null)
                {
                    string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
                    date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
                    SystemConfig.WriteConfigData(detectionpath, "date", date);
                    SystemConfig.WriteBase64Data(detectionpath, "treechan", treechan);
                    SystemConfig.WriteBase64Data(detectionpath, "chanPara", chanPara);
                    SystemConfig.WriteBase64Data(detectionpath, "detectionmode", detectionmode);
                }
                else
                {
                    MessageShow.show("Please check Data", "请检查数据是否正确");
                }
            }
            else
            {
                SaveFileDialog bsSaveDialog = new SaveFileDialog();
                string filepath = Application.StartupPath + @"\DetectionMode";
                bsSaveDialog.Filter = "xml文件(*.xml)|*.xml|所有文件(*.*)|*.*";

                if (!Directory.Exists(filepath))
                {
                    try
                    {
                        Directory.CreateDirectory(filepath);
                    }
                    catch
                    {
                        filepath = Application.StartupPath;
                    }
                }
                bsSaveDialog.InitialDirectory = filepath;
                bsSaveDialog.FilterIndex = 1;
                bsSaveDialog.FileName = namebox.Text;
                if (bsSaveDialog.ShowDialog() == DialogResult.OK)
                {
                    String filename = bsSaveDialog.FileName;
                    if (treechan != null && chanPara != null && detectionmode != null)
                    {
                        string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
                        date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
                        SystemConfig.WriteConfigData(filename, "date", date);
                        SystemConfig.WriteBase64Data(filename, "treechan", treechan);
                        SystemConfig.WriteBase64Data(filename, "chanPara", chanPara);
                        SystemConfig.WriteBase64Data(filename, "detectionmode", detectionmode);
                        detectionpath = filename;
                    }
                    else
                    {
                        MessageShow.show("Please check Data", "请检查数据是否正确");
                    }
                }
            }
        }

        private void loadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog bsLoadDialog = new OpenFileDialog();
            string filepath = Application.StartupPath + @"\DetectionMode";
            bsLoadDialog.Filter = "xml文件(*.xml)|*.xml|所有文件(*.*)|*.*";

            if (!Directory.Exists(filepath))
            {
                try
                {
                    Directory.CreateDirectory(filepath);
                }
                catch
                {
                    filepath = Application.StartupPath;
                }
            }
            bsLoadDialog.InitialDirectory = filepath;
            bsLoadDialog.FilterIndex = 1;
            if (bsLoadDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String filename = bsLoadDialog.FileName;
                    treechan = (Hashtable)SystemConfig.ReadBase64Data(filename, "treechan");
                    chanPara = (List<ClassChanpara>)SystemConfig.ReadBase64Data(filename, "chanPara");
                    detectionmode = (DetectionMode)SystemConfig.ReadBase64Data(filename, "detectionmode");
                    LoadUT();
                    detectionpath = filename;
                }
                catch
                {
                    MessageShow.show("Load Detection Mode error","载入检测模式错误");
                }
            }
        }

        private void namebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (namebox.SelectedItem != null && isclick)
            {
                string filename = Application.StartupPath + @"\DetectionMode"+ "\\" + Convert.ToString(namebox.SelectedItem) +".xml";
                try
                {
                    treechan = (Hashtable)SystemConfig.ReadBase64Data(filename, "treechan");
                    chanPara = (List<ClassChanpara>)SystemConfig.ReadBase64Data(filename, "chanPara");
                    detectionmode = (DetectionMode)SystemConfig.ReadBase64Data(filename, "detectionmode");
                    LoadUT();
                    detectionpath = filename;
                }
                catch
                {
                    MessageShow.show("Load Detection Mode error", "载入检测模式错误");
                }
            }
        }

        private void namebox_Click(object sender, EventArgs e)
        {
            ReadDetectionFile();
            isclick = true;
        }

        private void namebox_MouseEnter(object sender, EventArgs e)
        {
            isclick = true;
        }

        private void namebox_MouseLeave(object sender, EventArgs e)
        {
            isclick = false;
        }

        private void velocityBox_TextChanged(object sender, EventArgs e)
        {
            if (velocityBox.Text != "")
            {
                double tmp = 0;
                try
                {
                    tmp = double.Parse(velocityBox.Text);
                }
                catch
                {
                    return;
                }
                if (tmp > 15)
                {
                    velocityBox.Text = "15";
                }
            }
        }

        private void circumBox_TextChanged(object sender, EventArgs e)
        {
            if (circumBox.Text != "")
            {
                double tmp = 0;
                try
                {
                    tmp = double.Parse(circumBox.Text);
                }
                catch
                {
                    return;
                }
                if (tmp > 3)
                {
                    circumBox.Text = "3";
                }
            }
        }

        private void circumBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void velocityBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
            {
                return;
            }
            if (e.KeyChar == 46)
            {
                if (velocityBox.Text.Split('.').Length < 2)
                {

                    return;
                }
            }
            e.Handled = true;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void txtInputLimitKeyPress1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            //输入为小数点时，只能输入一次且只能输入一次
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0)
                e.Handled = true;
        }
        private void txtInputLimitKeyPress2(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            double distance=0;
            double surdis = 0;
            double tlength = Convert.ToDouble(txtTLength.Text);
            double blength = Convert.ToDouble(txtBottomlength.Text);
            double heig = Convert.ToDouble(txtHeight.Text);
            double v1 = Convert.ToDouble(txtVelocity.Text);
            double v2 = mainform.groove.transVeloc;
            double a1 = Convert.ToDouble(txtAngle.Text);
            double sina1 = System.Math.Sin(a1 / 180 *Math.PI);
            double sina2 = sina1 * v2 / v1;
            double a2 = System.Math.Round(System.Math.Asin(sina2));
            txtRefractAngle.Text = Convert.ToString(a2);

            double thick = 8;  //mm  //要改：从mainform的product中传出

            distance = 2 * System.Math.Tan(a2 / 180 * Math.PI) * (2 / 3 * thick);

            double l = (blength - tlength)/2;
            double h = l * System.Math.Tan(a1 / 180 * Math.PI);
            h = heig - h;
            surdis = h * System.Math.Tan(a1 / 180 * Math.PI);
            surdis = surdis + l;
            surdis = 2 * (blength - surdis);

            distance =  System.Math.Round(distance - surdis);
            txtPCS.Text = Convert.ToString(distance);
        }



    }

    [Serializable]
    public class DetectionMode
    {
        private const int CircumPulse = 1;
        private const double DetDistance = 300;
        private const double DetVelocity = 10;

        public string modename;
        public int circumpulse;
        public int direction;
        public double detdistance;
        public double detvelocity;
        public List<PADetectioninfo> painfolist;
        public List<TOFDDetectioninfo> tofdinfolist;
        public List<CoupleDetectioninfo> coupleinfolist;

        public DetectionMode()
        {
            modename = "";
            detdistance = DetDistance;
            circumpulse = CircumPulse;
            detvelocity = DetVelocity;
            direction = 0;
            painfolist = new List<PADetectioninfo>();
            tofdinfolist = new List<TOFDDetectioninfo>();
            coupleinfolist = new List<CoupleDetectioninfo>();
        }
    }

    [Serializable]
    public class CoupleDetectioninfo
    {
        public SessionType type;
        public int ID;
        public string name;
        public bool coupling;
        public List<GateDelay> gatedelay;

        public CoupleDetectioninfo(ClassChanpara chanpara)
        {
            type = SessionType.Couple;
            ID = 0;
            name = chanpara.name;
            coupling = true;
            this.gatedelay = new List<GateDelay>();
            this.gatedelay = chanpara.gatedelay;
        }
    }

    [Serializable]
    public class  PADetectioninfo
    {
        private const double CarlibraWave = 0.8;
        private const double AlarmWave = 0.4;
        private const double SupWave = 0.05;
        private const double DisplayWave = 0.2;

        public SessionType type;
        public int ID;
        public string name;
        public double delay;
        public double range;
        public double carlibrawave;
        public double alarmwave;
        public double supwave;
        public double displaywave;
        public bool strip;
        public bool bscan;
        public bool coupling;

        public PADetectioninfo(ClassChanpara chanpara)
        {
            type = SessionType.PA;
            ID = 0;
            name = chanpara.name;
            delay = chanpara.delay;
            range = chanpara.range;
            carlibrawave = CarlibraWave;
            alarmwave = AlarmWave;
            supwave = SupWave;
            displaywave = DisplayWave;
            strip = true;
            bscan = true;
            coupling = false;
        }
    }

    [Serializable]
    public class TOFDDetectioninfo
    {
        public SessionType type;
        public int ID;
        public string name;
        public bool bscan;

        public double delay;
        public double range;
        public double carlibrawave;
        public double alarmwave;
        public double supwave;
        public double displaywave;

        public string materal;
        public double velocity;
        public int angle;
        public double toplength;
        public double bottomlength;
        public double height;

        public double freq;
        public int elenum;
        public int receiver;
        public double eledia;

        public double pcs;
        public double refractangle;

        public TOFDDetectioninfo()
        {
            type = SessionType.TOFD;
            ID = 0;
            name = "TOFD";
            bscan = true;
            delay = 0;
            range = 0;
            carlibrawave = 0;
            alarmwave = 0;
            supwave = 0;
            displaywave = 0;
            materal = "";
            velocity = 0;
            angle = 0;
            toplength = 0;
            bottomlength = 0;
            height = 0;
            freq = 0;
            elenum = 1;
            receiver = 0;
            eledia = 0;
            pcs = 0;
            refractangle = 0;
        }
    }

    [Serializable]
    public class GateDelay
    {
        public GateType type;
        public double delay;
        public double range;
        public double threshold;

        public GateDelay(GateType type)
        {
            this.type = type;
            delay = 0;
            range = 0;
            switch (type)
            {
                case GateType.I:
                    threshold = 0.5;
                    break;
                case GateType.A:
                    threshold = 0.4;
                    break;
                case GateType.B:
                    threshold = 0.3;
                    break;
                case GateType.C:
                    threshold = 0.2;
                    break;
                default:
                    break;
            }
        }
    }

    public enum SessionType
    {
        PA = 0,
        TOFD = 1,
        Couple = 2
    }
}
