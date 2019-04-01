using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Ascan
{
    public partial class FormProbe : Form, LoadandSave
    {
        private MainForm mainform;
        public UltraProbe probe;
        private string openPath;
        private string savePath;

        private List<double> cache_Zr;
        private List<double> cache_Zi;
        private List<double> cache_interCouple;
        private int cacheNum;

        private bool isexist = false;

        public FormProbe(MainForm mainform)
        {
            InitializeComponent();

            probe = new UltraProbe();
            openPath = "";
            savePath = "";
            tabControl1.Visible = false;
            this.mainform = mainform;
            cache_Zr = new List<double>();
            cache_Zi = new List<double>();
            cache_interCouple = new List<double>(); 
            cacheNum = -1;
            dataGridView1.Columns[0].ReadOnly = true;

            initcmbName();

        }

        private void initcmbName()
        {
            cmbName.Items.Clear();

            string path = Application.StartupPath + "\\resources\\probe";

            DirectoryInfo folder = new DirectoryInfo(path);

            foreach (FileInfo file in folder.GetFiles("*.xml"))
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                cmbName.Items.Add(name);
            }
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbName.SelectedItem != null && isclick)
            {
                if (MessageBox.Show("是否载入参数", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string path = Application.StartupPath + "\\resources\\probe\\" + cmbName.SelectedItem.ToString() + ".xml";
                    //InitInterface();
                    GeneralFuc.ClearTextBox(this);
                    dataGridView1.Rows.Clear();
                    mstxtDate.Text = "00000000";
                    //deserialize
                    probe = SystemConfig.DeserializeFromXml(path, probe);
                    ClassToUI();

                    openPath = path;

                    isclick = false;
                    int a = cmbName.SelectedIndex;
                    if (a < 0)
                    { a = 0; }
                    else
                    {
                        cmbName.Items[a] = probe.name;
                    }
                }
                else
                {
                    isclick = false;
                    int a = cmbName.SelectedIndex;
                    if (a < 0)
                    { a = 0; }
                    else
                    {
                        cmbName.Items[a] = probe.name;
                    }
                    
                }
            }
        }

        bool isclick = false;
        private void cmbName_Click(object sender, EventArgs e)
        {
            initcmbName();
            isclick = true;  
        }
        private void cmbName_MouseEnter(object sender, EventArgs e)
        {
            isclick = true; 
        }
        private void cmbName_MouseLeave(object sender, EventArgs e)
        {
            isclick = false;
        }



        private void btnOpenXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "";
            openDialog.InitialDirectory = Application.StartupPath + "\\resources\\probe";
            openDialog.RestoreDirectory = false;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                openPath = openDialog.FileName;
               
                //InitInterface();
                GeneralFuc.ClearTextBox(this);
                dataGridView1.Rows.Clear();
                mstxtDate.Text = "00000000";
                //deserialize
                probe = SystemConfig.DeserializeFromXml(openPath, probe);
                ClassToUI();
            }
        }

        bool changing;
        private void ClassToUI()
        {
            changing = false;

            //Print to UI
            try
            {
                txtManufacturer.Text = probe.manu;
                txtSequenceNum.Text = probe.sn;
                cmbName.Text = probe.name;
                combType.SelectedIndex = probe.type;
                mstxtDate.Text = probe.date;
                txtDrawingPartNum.Text = probe.drawingPartNum;
                txtColor.Text = probe.color;
                txtLength.Text = probe.length.ToString();
                txtHight.Text = probe.height.ToString();
                txtWidth.Text = probe.width.ToString();
                txtConnModel.Text = probe.connModel;
                txtCableType.Text = probe.cableType;
                txtCableLen.Text = probe.cableLen.ToString();
                txtCableOuterDia.Text = probe.cableOuterDia.ToString();
                txtCenterFreq.Text = probe.centerFreq.ToString();
                txtMinBand.Text = probe.minBand.ToString();
                txtMaxPluDur.Text = probe.maxPluseDuration.ToString();
                txtEleEdge.Text = probe.eleEdge.ToString();
                txtEleNum.Text = probe.eleNum.ToString();
                txtEleSpace.Text = probe.eleSpace.ToString();
                txtStoreTemprMin.Text = probe.storeTemprMin.ToString();
                txtOperTempMax.Text = probe.operTempMax.ToString();
                txtStoreTemperMax.Text = probe.storeTemprMax.ToString();
                txtOperTempMin.Text = probe.operTempMin.ToString();
                txtMaxVolt.Text = probe.maxVolt.ToString();
                txtMaxPrf.Text = probe.maxPrf.ToString();
                txtMaxContinuePrf.Text = probe.maxContinuePrf.ToString();
                txtMaxInterCouple.Text = probe.maxInterCouple.ToString();
                txtMaxHomSenDiff.Text = probe.maxHomoSenDiff.ToString();
                //
                cache_interCouple = probe.interCouple;
                cache_Zi = probe.Zi;
                cache_Zr = probe.Zr;
                //tab5
                for (int i = 0; i < (int)probe.eleNum; i++)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells["dgvNum"].Value = (i + 1).ToString();
                    this.dataGridView1.Rows[index].Cells["dgvZi"].Value = probe.Zi[i].ToString();
                    this.dataGridView1.Rows[index].Cells["dgvZr"].Value = probe.Zr[i].ToString();
                    this.dataGridView1.Rows[index].Cells["dgvInterCoup"].Value = probe.interCouple[i].ToString();
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据导入失败！请检查文件是否正确！","警告");
                //
                init();
                return;
            }
            changing = true;
            isexist = true;
            tabControl1.Visible = true;
        }

        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            if (tabControl1.Visible == false||isexist==false)
            {
                MessageBox.Show("数据不存在！", "错误");
                return;
            }
            else
            {
                if (openPath != "")
                {
                    if (!System.IO.File.Exists(openPath))
                    {
                        MessageBox.Show(openPath + " 该路径下的打开文件不存在！", "错误");
                        openPath = "";
                        return;
                    }
                    else
                    {
                        SaveDialog sd = new SaveDialog();
                        sd.ShowDialog();
                        if (sd.DialogResult == DialogResult.OK)
                        {
                            savePath = openPath;
                        }
                        else if (sd.DialogResult == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (sd.DialogResult == DialogResult.Abort)
                        {
                            SaveFileDialog saveDialog = new SaveFileDialog();
                            saveDialog.Title = "";
                            saveDialog.InitialDirectory = Application.StartupPath + "\\resources\\probe"; 
                            saveDialog.Filter = "xml files (*.xml)|*.xml";
                            saveDialog.FileName = cmbName.Text;
                            saveDialog.RestoreDirectory = false;
                            if (saveDialog.ShowDialog() == DialogResult.OK)
                            {
                                //System.IO.FileStream fs = (System.IO.FileStream)saveDialog.OpenFile();
                                //fs.Close();
                                savePath = saveDialog.FileName.ToString();
                                openPath = savePath;
                            }
                            else
                            {
                                return;
                            }
                        }
                       
                    }
                }
                else
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Title = "";
                    saveDialog.InitialDirectory = Application.StartupPath + "\\resources\\probe"; ;
                    saveDialog.Filter = "xml files (*.xml)|*.xml";
                    saveDialog.FileName = cmbName.Text;
                    saveDialog.RestoreDirectory = false;
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        //System.IO.FileStream fs = (System.IO.FileStream)saveDialog.OpenFile();
                        //fs.Close();
                        savePath = saveDialog.FileName.ToString();
                        openPath = savePath;
                    }
                    else
                    {
                        return;
                    }
                    
                }

                if (EnsurePrm())
                {
                    SystemConfig.SerializeToXml(savePath, probe);
                }
            }

        }



        private void btnRebuild_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否新建立探头参数", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isexist = true;
                init();
            }

        }

        private void init()
        {
            tabControl1.Visible = true;
            GeneralFuc.ClearTextBox(this);
            mstxtDate.Text = "00000000";
            
            //cmbType.SelectedItem = null;
            cmbName.SelectedItem = null;
            probe = new UltraProbe();
            dataGridView1.Rows.Clear();
            openPath = "";
            savePath = "";
            cache_Zr = new List<double>();
            cache_Zi = new List<double>();
            cache_interCouple = new List<double>();
            cacheNum = -1;
        }

        private bool EnsurePrm()
        {
            if (isexist == false)
            {
                MessageBox.Show("数据错误！","警告");
                return false;
            }
            else
            {
                //Empty boxes are set zero 
                GeneralFuc.SetEmptyTextBox(this);
                //UI convert to class 
                try
                {
                    probe.name = cmbName.Text;
                    probe.type = combType.SelectedIndex;
                    probe.date = mstxtDate.Text;
                    probe.sn = txtSequenceNum.Text;
                    probe.manu = txtManufacturer.Text;
                    probe.drawingPartNum = txtDrawingPartNum.Text;
                    probe.color = txtColor.Text;
                    probe.length = double.Parse(txtLength.Text);
                    probe.height = double.Parse(txtHight.Text);
                    probe.width = double.Parse(txtWidth.Text);
                    probe.connModel = txtConnModel.Text;
                    probe.cableType = txtCableType.Text;
                    probe.cableLen = double.Parse(txtCableLen.Text);
                    probe.cableOuterDia = double.Parse(txtCableOuterDia.Text);
                    probe.centerFreq = double.Parse(txtCenterFreq.Text);
                    probe.minBand = double.Parse(txtMinBand.Text);
                    probe.maxPluseDuration = double.Parse(txtMaxPluDur.Text);
                    probe.eleEdge = double.Parse(txtEleEdge.Text);
                    probe.eleNum = uint.Parse(txtEleNum.Text);
                    probe.eleSpace = double.Parse(txtEleSpace.Text);
                    probe.storeTemprMin = double.Parse(txtStoreTemprMin.Text);
                    probe.operTempMin = double.Parse(txtOperTempMin.Text);
                    probe.storeTemprMax = double.Parse(txtStoreTemperMax.Text);
                    probe.operTempMax = double.Parse(txtOperTempMax.Text);
                    probe.maxVolt = double.Parse(txtMaxVolt.Text);
                    probe.maxPrf = double.Parse(txtMaxPrf.Text);
                    probe.maxContinuePrf = double.Parse(txtMaxContinuePrf.Text);
                    probe.maxInterCouple = double.Parse(txtMaxInterCouple.Text);
                    probe.maxHomoSenDiff = double.Parse(txtMaxHomSenDiff.Text);

                    probe.Zi = cache_Zi;
                    probe.Zr = cache_Zr;
                    probe.interCouple = cache_interCouple;

                    //if (e != null)
                    //{
                    //    MessageBox.Show("data conversion success");
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据转化失败！","警告");
                    return false;
                }
               
            }
            return true;
        }






        private void mstxtDate_Click(object sender, EventArgs e)
        {
            if (mstxtDate.Text == "0000-00-00")
            {
                mstxtDate.Text = "";
            }
            mstxtDate.SelectionStart = 0;
        }

        private void txtLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtLength.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtWidth.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtHight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtHight.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtCableOuterDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtCableOuterDia.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtCableLen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtHight.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtCenterFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMinBand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtMinBand.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }



        private void txtEleSpace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtEleSpace.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtEleEdge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtEleEdge.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

      
        private void txtMaxVolt_KeyPress(object sender, KeyPressEventArgs e)
        {
                        if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtMaxVolt.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtMaxPrf_KeyPress(object sender, KeyPressEventArgs e)
        {
                       if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtMaxPrf.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtMaxContinuePrf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtMaxContinuePrf.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtMaxPluDur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtMaxPluDur.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtMaxInterCouple_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtMaxInterCouple.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtMaxHomSenDiff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtMaxHomSenDiff.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void FormProbe_FormClosing(object sender, FormClosingEventArgs e)
        {
            UltraProbe probe1 = new UltraProbe();
            
            if (EnsurePrm()==true)
            {
                //if (probe != probe1)
                //{
                //    if (MessageBox.Show("探头参数已改变，是否保存到文件？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    {
                //        btnSaveXml_Click(null, null);
                //    }
                //}
                e.Cancel = true;
                this.Hide();
                mainform.Getprobe(probe);
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        public void FormLoad()
        {
            string filename = "probe";
            string filepath = "";
            filepath = SystemConfig.GlobalLoad(filename);

            if (filepath == "")
            {
                MessageBox.Show("探头信息配置失败","警告");
                return;
            }

            //InitInterface();
            GeneralFuc.ClearTextBox(this);
            mstxtDate.Text = "00000000";

            //deserialize
            probe = SystemConfig.DeserializeFromXml(filepath, probe);
            ClassToUI();
           
            mainform.Getprobe(probe);
        }

        public void FormSave()
        {
            string filename = "probe";
            string filepath = "";
            filepath = SystemConfig.GlobalSave(filename);
            SystemConfig.SerializeToXml(filepath, probe);
        }


        private void txtEleNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEleNum_Leave(null, null);
            }
        }

        private void txtEleNum_Leave(object sender, EventArgs e)
        {
            int num = int.Parse(txtEleNum.Text);
            //修改则初始化
            if (cacheNum != num)
            {
                this.dataGridView1.Rows.Clear();
                cache_Zi = new List<double>();
                cache_Zr = new List<double>();
                cache_interCouple = new List<double>();
                for (int i = 0; i < num; i++)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = i+1;
                    this.dataGridView1.Rows[index].Cells[1].Value = "10";
                    this.dataGridView1.Rows[index].Cells[2].Value = "10";
                    this.dataGridView1.Rows[index].Cells[3].Value = "10";
                    cache_Zi.Add(10);
                    cache_Zr.Add(10);
                    cache_interCouple.Add(10);
                }
            }
            cacheNum = num;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (changing == true)
            {
                int y = dataGridView1.CurrentCellAddress.Y;
                switch (dataGridView1.CurrentCellAddress.X)
                {
                    case 1:
                        {
                            cache_Zi[y] = double.Parse(dataGridView1.CurrentCell.Value.ToString());
                        } break;
                    case 2:
                        {
                            cache_Zr[y] = double.Parse(dataGridView1.CurrentCell.Value.ToString());
                        } break;
                    case 3:
                        {
                            cache_interCouple[y] = double.Parse(dataGridView1.CurrentCell.Value.ToString());
                        } break;

                }
            }
        }


        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (dataGridView1.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtInputLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 45 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            //输入为负号时，只能输入一次且只能输入一次
            if (e.KeyChar == 45 && (((TextBox)sender).SelectionStart != 0 || ((TextBox)sender).Text.IndexOf("-") >= 0))
                e.Handled = true;
            //输入为小数点时，只能输入一次且只能输入一次
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0)
                e.Handled = true;
        }

        private void FormProbe_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureDialog pd = new PictureDialog(this.pictureBox1);
            pd.Show();
        }

        private void combType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combType.SelectedIndex == 0)
            {
                pictureBox1.Image = Properties.Resources.xiang;
            }
            else if (combType.SelectedIndex == 1)
            {
                pictureBox1.Image = Properties.Resources.chang;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2 || tabControl1.SelectedIndex == 3 || tabControl1.SelectedIndex == 4)
            {
                pictureBox1.Image = Properties.Resources.ProbePara;
            }
            else
            {
                if (combType.SelectedIndex == 0)
                {
                    pictureBox1.Image = Properties.Resources.xiang;
                }
                else if (combType.SelectedIndex == 1)
                {
                    pictureBox1.Image = Properties.Resources.chang;
                }
            }
        }






 




    }
}
