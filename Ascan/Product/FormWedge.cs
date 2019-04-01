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
    public partial class FormWedge : Form, LoadandSave
    {
        private MainForm mainform;
        private UltraWedge wedge;
        private UTPosition positions;
        
        private string openPath;
        private string savePath;

        private bool isexist = false;

        public FormWedge(MainForm mainform)
        {
            InitializeComponent();
            wedge = new UltraWedge();
            openPath = "";
            savePath = "";
            tabControl1.Visible = false;
            this.mainform = mainform;

            initcmbName();
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbName.SelectedItem != null && isclick)
            {
                if (MessageBox.Show("是否载入参数", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string path = Application.StartupPath + "\\resources\\wedge\\" + cmbName.SelectedItem.ToString() + ".xml";

                    //deserialize
                    wedge = (UltraWedge)SystemConfig.ReadBase64Data(path, "WEDGE");
                    positions = (UTPosition)SystemConfig.ReadBase64Data(path, "POSITION");
                    //wedge =DeserializeFromXml(openPath, wedge);
                    ClassToUI();
                    openPath = path;

                    isclick = false;
                    int a = cmbName.SelectedIndex;
                    if (a < 0)
                    { a = 0; }
                    else
                    {
                        cmbName.Items[a] = wedge.name;
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
                        cmbName.Items[a] = wedge.name;
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

        private void initcmbName()
        {
            cmbName.Items.Clear();

            string path = Application.StartupPath + "\\resources\\wedge";

            DirectoryInfo folder = new DirectoryInfo(path);

            foreach (FileInfo file in folder.GetFiles("*.xml"))
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                cmbName.Items.Add(name);
            }
        }



        private void btnOpenXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "";
            openDialog.InitialDirectory = Application.StartupPath + "\\resources\\wedge";
            openDialog.RestoreDirectory = false;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                openPath = openDialog.FileName;

                //deserialize
                wedge = (UltraWedge)SystemConfig.ReadBase64Data(openPath, "WEDGE");
                positions = (UTPosition)SystemConfig.ReadBase64Data(openPath, "POSITION");
                //wedge =DeserializeFromXml(openPath, wedge);
                ClassToUI();
            }

        }

        private void ClassToUI()
        {
            //InitInterface();
            GeneralFuc.ClearTextBox(this);
            mstxtDate.Text = "00000000";
            //Print to UI
            try
            {
                mstxtDate.Text = wedge.date;
                cmbName.Text = wedge.name;
                txtType.Text = wedge.type;
                txtDrawNum.Text = wedge.drawingPartNum;
                txtManufacturer.Text = wedge.manu;
                txtSequenceNum.Text = wedge.sn;
                txtLXL.Text = wedge.length.ToString();
                txtLXW.Text = wedge.width.ToString();
                txtLXH.Text = wedge.height.ToString();
                txtLDW.Text = wedge.headLen.ToString();
                txtAngle.Text = wedge.incidentAngle.ToString();
                txtLongVeloc.Text = wedge.longVeloc.ToString();
                txtTransVeloc.Text = wedge.transVeloc.ToString();
                txtOperTempMin.Text = wedge.operTempMin.ToString();
                txtStoreTemperMin.Text = wedge.storeTemprMin.ToString();
                txtOperTempMax.Text = wedge.operTempMax.ToString();
                txtStoreTemperMax.Text = wedge.storeTemprMax.ToString();
                txtWedgePos.Text = positions.wedgePosition.ToString();
                txtProbePos.Text = positions.probePosition.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据导入失败！请检查文件是否正确！", "警告");
                init();
                return;
            }
            isexist = true;
            tabControl1.Visible = true;
        }

        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            if (tabControl1.Visible == false)
            {
                MessageBox.Show("数据不存在！", "错误");
            }
            else
            {
                if (openPath != "")
                {
                    if (!System.IO.File.Exists(openPath))
                    {
                        MessageBox.Show(openPath + " 该路径下的打开文件不存在！", "错误");
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
                            saveDialog.InitialDirectory = Application.StartupPath + "\\resources\\wedge";
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
                    saveDialog.InitialDirectory = Application.StartupPath + "\\resources\\wedge";
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
                    //SerializeToXml(savePath, wedge);
                    SystemConfig.WriteBase64Data(savePath, "WEDGE", wedge);
                    SystemConfig.WriteBase64Data(savePath, "POSITION", positions);
                }
            }


        }


        private void btnRebuild_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否新建立楔块参数", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isexist = true;
                init();
            }

        }

        private void init()
        {
            tabControl1.Visible = true;
            cmbName.SelectedItem = null;
            GeneralFuc.ClearTextBox(this);
            mstxtDate.Text = "00000000";
            wedge = new UltraWedge();
            positions = new UTPosition();
            openPath = "";
            savePath = "";
        }

        private bool EnsurePrm()
        {
            if (isexist == false)
            {
                MessageBox.Show("数据错误！", "警告");
                return false;
            }
            else
            {
                //Empty boxes are set zero 
                GeneralFuc.SetEmptyTextBox(this);
                //UI convert to class 
                try
                {
                    wedge.date = mstxtDate.Text;
                    wedge.name = cmbName.Text;
                    wedge.type = txtType.Text;
                    wedge.drawingPartNum = txtDrawNum.Text;
                    wedge.sn = txtSequenceNum.Text;
                    wedge.manu = txtManufacturer.Text;
                    wedge.length = double.Parse(txtLXH.Text);
                    wedge.width = double.Parse(txtLXW.Text);
                    wedge.height = double.Parse(txtLXH.Text);
                    wedge.headLen = double.Parse(txtLDW.Text);
                    wedge.incidentAngle = double.Parse(txtAngle.Text);
                    wedge.longVeloc = double.Parse(txtLongVeloc.Text);
                    wedge.transVeloc = double.Parse(txtTransVeloc.Text);
                    wedge.operTempMin = double.Parse(txtOperTempMin.Text);
                    wedge.operTempMax = double.Parse(txtOperTempMax.Text);
                    wedge.storeTemprMin = double.Parse(txtStoreTemperMin.Text);
                    wedge.storeTemprMax = double.Parse(txtStoreTemperMax.Text);
                    positions.probePosition = double.Parse(txtProbePos.Text);
                    positions.wedgePosition = double.Parse(txtWedgePos.Text);

                    //if (e != null)
                    //{
                    //    MessageBox.Show("data conversion success");
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据转化失败！", "警告");
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



        private void txtLXL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtLXL.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtLXH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtLXH.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtLXW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtLXW.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtLDW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtLDW.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtAngle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtAngle.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void FormWedge_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            UltraWedge wedge1 = new UltraWedge();
            UTPosition position1 = new UTPosition();

            if (EnsurePrm())
            {
                //if (wedge != wedge1 && position1!=positions)
                //{
                //    if (MessageBox.Show("楔块参数已改变，是否保存到文件？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    {
                //        btnSaveXml_Click(null, null);
                //    }
                //}
                e.Cancel = true;
                this.Hide();
                mainform.Getwedge(wedge);
                mainform.Getposition(positions);
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        public void FormLoad()
        {
            string filename = "wedge";
            string filepath = "";
            filepath = SystemConfig.GlobalLoad(filename);

            if (filepath == "")
            {
                MessageBox.Show("楔块信息配置失败","警告");
                return;
            }

            //deserialize
            wedge = (UltraWedge)SystemConfig.ReadBase64Data(filepath, "WEDGE");
            positions = (UTPosition)SystemConfig.ReadBase64Data(filepath, "POSITION");
            //wedge =DeserializeFromXml(openPath, wedge);

            ClassToUI();
            

            mainform.Getwedge(wedge);
            mainform.Getposition(positions);

        }

        public void FormSave()
        {
            string filename = "wedge";
            string filepath = "";
            filepath = SystemConfig.GlobalSave(filename);

            //SerializeToXml(savePath, wedge);
            SystemConfig.WriteBase64Data(filepath, "WEDGE", wedge);
            SystemConfig.WriteBase64Data(filepath, "POSITION", positions);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                pictureBox1.Image = Properties.Resources.InspectionSketch;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.WedgeSketch;
            }
        }

        private void txtLongVeloc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtLongVeloc.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtTransVeloc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtTransVeloc.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtWedgePos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtWedgePos.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtProbePos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtProbePos.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }




        private void txtAngle_TextChanged(object sender, EventArgs e)
        {
            if (txtAngle.Text != "")
            {
                double b = double.Parse(txtAngle.Text);
                if (b > 360)
                {
                    txtAngle.Text = "360";
                }
            }
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
        

        private void FormWedge_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureDialog pd = new PictureDialog(this.pictureBox1);
            pd.Show();
        }









    }
}

