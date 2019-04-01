using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;


namespace Ascan
{
    public partial class FormProduct : Form, LoadandSave
    {
        private MainForm mainform;
        private Product product;
        private string openPath;
        private string savePath;

        private bool isexist = false;

        //private List<string> subregionsNames;

        //public List<string> SubregionsNames
        //{
        //    get { return subregionsNames; }
        //}

        public FormProduct(MainForm mainform)
        {
            InitializeComponent();
            tabProduct.Visible = false;
            tabGrooveKindPrm.Visible = false;
            InitData();
            this.mainform = mainform;

            initcmbName();
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductName.SelectedItem != null && isclick)
            {
                if (MessageBox.Show("是否载入参数", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string path = Application.StartupPath + "\\resources\\product\\" + cmbProductName.SelectedItem.ToString() + ".xml";

                    //clear TextBox
                    GeneralFuc.ClearTextBox(this);
                    maskedtxtDate.Text = "00000000";
                    defectGrid.Rows.Clear();
                    //deserialize
                    product = SystemConfig.DeserializeFromXml(path, product);
                    ClassToUI();
                    openPath = path;

                    isclick = false;
                    int a = cmbProductName.SelectedIndex;
                    if (a < 0)
                    { a = 0; }
                    else
                    {
                        cmbProductName.Items[a] = product.name;
                    }
                    
                }
                else
                {
                    isclick = false;
                    int a = cmbProductName.SelectedIndex;
                    if (a < 0)
                    { a = 0; }
                    else
                    {
                        cmbProductName.Items[a] = product.name;
                    }
                }

            }
        }

        bool isclick = false;
        private void cmbProductName_Click(object sender, EventArgs e)
        {
            initcmbName();
            isclick = true;
        }

        private void cmbProductName_MouseEnter(object sender, EventArgs e)
        {
            isclick = true;
        }

        private void cmbProductName_MouseLeave(object sender, EventArgs e)
        {
            isclick = false;
        }

        private void initcmbName()
        {
            cmbProductName.Items.Clear();

            string path = Application.StartupPath + "\\resources\\product";

            DirectoryInfo folder = new DirectoryInfo(path);

            foreach (FileInfo file in folder.GetFiles("*.xml"))
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                cmbProductName.Items.Add(name);
            }
        }


        //illustration:Index of cobGrooveKind represents the type of groove;"0"-Y\"1"-X\"2"-CRC
        private void cobGrooveKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cobGrooveKind.SelectedIndex)
            {
                case 0:
                    picGroove.Image = Properties.Resources.VGroove;
                    tabGrooveKindPrm.Visible = true;
                    tabGrooveKindPrm.SelectedTab = PageVgroove;
                    product.groove.type = GrooveType.V;
                    break;
                case 1:
                    picGroove.Image = Properties.Resources.XGroove;
                    tabGrooveKindPrm.Visible = true;
                    tabGrooveKindPrm.SelectedTab = PageXgroove;
                    product.groove.type = GrooveType.X;
                    break;
                case 2:
                    picGroove.Image = Properties.Resources.CRCGroove;
                    tabGrooveKindPrm.Visible = true;
                    tabGrooveKindPrm.SelectedTab = PageCRCgroove;
                    product.groove.type = GrooveType.CRC;
                    break;
                default:
                    break;
            }
        }

        private bool EnsurePara()
        {
            if (isexist == false)
            {
                MessageBox.Show("数据错误！", "警告");
                return false;
            }
            else if (cobGrooveKind.SelectedItem == null)
            {
                MessageBox.Show("未设置坡口参数");
                return false;
            }
            else
            {
                //Empty boxes are set zero 
                GeneralFuc.SetEmptyTextBox(this);
                //UI convert to class 
                try
                {
                    //tab1
                    product.name = cmbProductName.Text;

                    product.length = double.Parse(txtLength.Text);
                    product.outsize = double.Parse(txtOutsize.Text);
                    product.thickness = double.Parse(txtThickness.Text);

                    product.weldingMaterial = txtMaterial.Text;


                    //groove
                    product.groove.ClearList();
                    product.groove.sn = txtGrooveSn.Text;
                    product.groove.longVeloc = double.Parse(txtLongitudinal.Text);
                    product.groove.transVeloc = double.Parse(txtTransverse.Text);

                    //
                    if (tabGrooveKindPrm.SelectedTab == PageVgroove)
                    {
                        product.groove.type = GrooveType.V;
                        product.groove.distance = double.Parse(txtVGroove_d.Text);
                        product.groove.height.Add(double.Parse(txtVGroove_h0.Text));
                        product.groove.height.Add(double.Parse(txtVGroove_h1.Text));
                        product.groove.angle.Add(double.Parse(txtVGroove_a0.Text));
                    }
                    else if (tabGrooveKindPrm.SelectedTab == PageXgroove)
                    {
                        product.groove.type = GrooveType.X;
                        //product.groove.distance = double.Parse(txtXGroove_d.Text);
                        product.groove.height.Add(double.Parse(txtXGroove_h0.Text));
                        product.groove.height.Add(double.Parse(txtXGroove_h1.Text));
                        product.groove.angle.Add(double.Parse(txtXGroove_a0.Text));
                    }
                    else if (tabGrooveKindPrm.SelectedTab == PageCRCgroove)
                    {
                        product.groove.type = GrooveType.CRC;
                        //product.groove.distance = double.Parse(txtCRCGroove_d.Text);
                        product.groove.height.Add(double.Parse(txtCRCGroove_h0.Text));
                        product.groove.height.Add(double.Parse(txtCRCGroove_h1.Text));
                        product.groove.height.Add(double.Parse(txtCRCGroove_h2.Text));
                        product.groove.height.Add(double.Parse(txtCRCGroove_h3.Text));
                        product.groove.angle.Add(double.Parse(txtCRCGroove_a0.Text));
                        product.groove.angle.Add(double.Parse(txtCRCGroove_a1.Text));
                        product.groove.angle.Add(double.Parse(txtCRCGroove_a2.Text));
                    }
                    else
                    {
                        MessageBox.Show("坡口参数转化失败 ", "错误");
                    }

                    //tab3 
                    product.sample.name = txtSampleName.Text;
                    product.sample.factory = txtFactory.Text;
                    product.sample.date = maskedtxtDate.Text;
                    product.sample.drawing = txtDrawing.Text;
                    product.sample.sn = txtSampleSn.Text;
                    product.sample.material = txtSampleMat.Text;
                    product.sample.standard = txtSampleStad.Text;
                    product.sample.groType = (GrooveType)cmbSampleGroType.SelectedIndex;

                    product.sample.defects = new List<Defect>();
                    int row = defectGrid.Rows.Count;
                    for (int i = 0; i < row; i++)
                    {
                        Defect def = new Defect();

                        def.name = defectGrid.Rows[i].Cells["name"].Value.ToString();
                        def.subregionName = defectGrid.Rows[i].Cells["subregion"].Value.ToString();
                        def.type = defectGrid.Rows[i].Cells["type"].Value.ToString();
                        double.TryParse(defectGrid.Rows[i].Cells["beginaxil"].Value.ToString(), out def.beginAxial);
                        double.TryParse(defectGrid.Rows[i].Cells["endaxial"].Value.ToString(), out def.endAxial);
                        double.TryParse(defectGrid.Rows[i].Cells["beginradio"].Value.ToString(), out def.beginRadio);
                        double.TryParse(defectGrid.Rows[i].Cells["endradio"].Value.ToString(), out def.endRadio);

                        product.sample.defects.Add(def);
                    }

                    //if (e != null)
                    //{
                    //    MessageBox.Show("data conversion success");
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }


            }
            return true;
        }


        private void btnSaveProductXml_Click(object sender, EventArgs e)
        {
            if (tabProduct.Visible == false || isexist == false)
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
                            saveDialog.InitialDirectory = Application.StartupPath + "\\resources\\product";
                            saveDialog.Filter = "xml files (*.xml)|*.xml";
                            saveDialog.FileName = cmbProductName.Text;
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
                    saveDialog.InitialDirectory = Application.StartupPath + "\\resources\\product";
                    saveDialog.Filter = "xml files (*.xml)|*.xml";
                    saveDialog.FileName = cmbProductName.Text;
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
                //
                if (EnsurePara())
                {
                    //Serialize
                    SystemConfig.SerializeToXml(savePath, product);
                }
            }
        }


                
        private void btnOpenProductXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "";
            openDialog.InitialDirectory = Application.StartupPath + "\\resources\\product";
            openDialog.RestoreDirectory = false;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                openPath = openDialog.FileName;

                InitInterface();
                //deserialize
                product = SystemConfig.DeserializeFromXml(openPath, product);
                ClassToUI();
            }
        }

        private void ClassToUI()
        {
            //Print to UI
            try
            {
                cobGrooveKind.SelectedIndex = (int)product.groove.type;
                //tab1
                cmbProductName.Text = product.name;

                txtLength.Text = product.length.ToString();
                txtOutsize.Text = product.outsize.ToString();
                txtThickness.Text = product.thickness.ToString();

                txtMaterial.Text = product.weldingMaterial;

                txtLongitudinal.Text = product.groove.longVeloc.ToString();
                txtTransverse.Text = product.groove.transVeloc.ToString();

                txtGrooveSn.Text = product.groove.sn;
                //product.groove.type
                if (product.groove.type==GrooveType.V)
                {
                    txtVGroove_d.Text = product.groove.distance.ToString();
                    txtVGroove_h0.Text = product.groove.height[0].ToString();
                    txtVGroove_h1.Text = product.groove.height[1].ToString();
                    txtVGroove_a0.Text = product.groove.angle[0].ToString();
                }
                else if (product.groove.type == GrooveType.X)
                {
                    txtXGroove_h0.Text = product.groove.height[0].ToString();
                    txtXGroove_h1.Text = product.groove.height[1].ToString();
                    txtXGroove_a0.Text = product.groove.angle[0].ToString();
                }
                else if (product.groove.type == GrooveType.CRC)
                {
                    txtCRCGroove_h0.Text = product.groove.height[0].ToString();
                    txtCRCGroove_h1.Text = product.groove.height[1].ToString();
                    txtCRCGroove_h2.Text = product.groove.height[2].ToString();
                    txtCRCGroove_h3.Text = product.groove.height[3].ToString();
                    txtCRCGroove_a0.Text = product.groove.angle[0].ToString();
                    txtCRCGroove_a1.Text = product.groove.angle[1].ToString();
                    txtCRCGroove_a2.Text = product.groove.angle[2].ToString();
                }

                //tab3
                txtSampleName.Text = product.sample.name;
                txtFactory.Text = product.sample.factory;
                maskedtxtDate.Text = product.sample.date;       //data format
                txtDrawing.Text = product.sample.drawing;
                txtSampleStad.Text = product.sample.standard;
                txtSampleSn.Text = product.sample.sn;
                txtSampleMat.Text = product.sample.material;
                cmbSampleGroType.SelectedIndex = (int)product.sample.groType;

                //defect
                defectGrid.Rows.Clear();
                foreach (Defect d in product.sample.defects)
                {
                    int index = this.defectGrid.Rows.Add();
                    defectGrid.Rows[index].Cells["name"].Value = d.name;
                    defectGrid.Rows[index].Cells["subregion"].Value = d.subregionName;
                    defectGrid.Rows[index].Cells["type"].Value = d.type;
                    defectGrid.Rows[index].Cells["beginaxil"].Value = d.beginAxial;
                    defectGrid.Rows[index].Cells["endaxial"].Value = d.endAxial;
                    defectGrid.Rows[index].Cells["beginradio"].Value = d.beginRadio;
                    defectGrid.Rows[index].Cells["endradio"].Value = d.endRadio;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据导入失败！请检查文件是否正确！", "警告");

                InitData();
                InitInterface();
                return;
            }
            isexist = true;
            tabProduct.Visible = true;
        }


        private void btnNewProduct_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否新建立产品信息", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isexist = true;
                tabProduct.Visible = true;
                InitInterface();
                InitData();
            }

        }
        //initialize interface
        private void InitInterface()
        {
            //clear TextBox
            GeneralFuc.ClearTextBox(this);
            //other 
            cmbProductName.SelectedItem =null;
            maskedtxtDate.Text = "00000000";
            defectGrid.Rows.Clear();
            cmbSampleGroType.SelectedItem = null;
            cobGrooveKind.SelectedItem = null;
        }
        private void InitData()
        {
            product = new Product();
            savePath = "";
            openPath = "";
            //subregionsNames = new List<string>();
        }


        private void picGroove_Click(object sender, EventArgs e)
        {
            PictureDialog pd = new PictureDialog(this.picGroove);
            pd.Show();
        }



        //   input  of  textbox limited
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

        private void txtOutsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtOutsize.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtThickness.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtLongitudinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtLongitudinal.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtTransverse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtTransverse.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtVGroove_d_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtVGroove_d.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtVGroove_h0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtVGroove_h0.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtVGroove_h1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtVGroove_h1.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtVGroove_a0_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtVGroove_a0.Text.Split('.').Length < 2)
                {
                    
                    return;
                }
            }

            e.Handled = true;
        }


        private void txtVGroove_a0_TextChanged(object sender, EventArgs e)
        {
            if (txtVGroove_a0.Text != "")
            {
                double b = double.Parse(txtVGroove_a0.Text);
                if (b > 360)
                {
                    txtVGroove_a0.Text = "360";
                }
            }
        }


        private void txtXGroove_h0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtXGroove_h0.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtXGroove_h1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtXGroove_h1.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtXGroove_a0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtXGroove_a0.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }


        private void txtCRCGroove_h0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtCRCGroove_h0.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtCRCGroove_a0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtCRCGroove_a0.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }
       

       

        private void txtCRCGroove_h1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtCRCGroove_h1.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtCRCGroove_a1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtCRCGroove_a1.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtCRCGroove_h2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtCRCGroove_h2.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtCRCGroove_a2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtCRCGroove_a2.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtCRCGroove_h3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtCRCGroove_h3.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }


        //
        private void FormProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            Product product1 = new Product();


            if (EnsurePara())
            {
            //    if (product != product1)
            //    {
            //        if (MessageBox.Show("产品参数已改变，是否保存到文件？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            btnSaveProductXml_Click(null, null);
            //        }
            //    }

                e.Cancel = true;
                this.Hide();
                mainform.Getgroove(product.groove);
                mainform.Getsampledefs(product.sample.defects);
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }

        }

        public void FormLoad()
        {
            string filename = "product";
            string filepath = "";
            filepath = SystemConfig.GlobalLoad(filename);


            if (filepath == "")
            {
                MessageBox.Show("产品信息配置失败", "警告");
                return;
            }

            InitInterface();

            //deserialize
            product = SystemConfig.DeserializeFromXml(filepath, product);

            ClassToUI();
           

            mainform.Getgroove(product.groove);
            mainform.Getsampledefs(product.sample.defects);
        }

        public void FormSave()
        {
            string filename = "product";
            string filepath = "";
            filepath = SystemConfig.GlobalSave(filename);
            SystemConfig.SerializeToXml(filepath, product);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ////
            //if (subregionsNames.Count==0)
            //{
            //    MessageBox.Show("note: the virtual channels are not configured");
            //}
            //else
            //{
                int index = this.defectGrid.Rows.Add();

                AddDefectDialog adddefect = new AddDefectDialog(this, index);// subregionsNames

                if (adddefect.ShowDialog() == DialogResult.OK)
                {
                }
                else
                {
                    defectGrid.Rows.RemoveAt(index);
                }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (defectGrid.CurrentRow != null)
            {
                //delete defect in defects
                string str = defectGrid.CurrentRow.Cells["name"].Value.ToString();
                for (int i = product.sample.defects.Count - 1; i >= 0; i--)
                {
                    if (product.sample.defects[i].name == str)
                    {
                        product.sample.defects.RemoveAt(i);
                        break;
                    }
                }
                //delete current row of dataGridView1
                DataGridViewRow dgvr = defectGrid.CurrentRow;
                defectGrid.Rows.Remove(dgvr);
            }
            else
            {
                MessageBox.Show("未选中行");
            }
        }

        private void maskedtxtDate_Click_1(object sender, EventArgs e)
        {
            if (maskedtxtDate.Text == "0000-00-00")
            {
                maskedtxtDate.Text = "";
            }
            maskedtxtDate.SelectionStart = 0;
        }

        private void txtXGroove_a0_TextChanged(object sender, EventArgs e)
        {
            if (txtXGroove_a0.Text != "")
            {
                double b = double.Parse(txtXGroove_a0.Text);
                if (b > 360)
                {
                    txtXGroove_a0.Text = "360";
                }
            }
        }

        private void txtCRCGroove_a0_TextChanged(object sender, EventArgs e)
        {
            if (txtCRCGroove_a0.Text != "")
            {
                double b = double.Parse(txtCRCGroove_a0.Text);
                if (b > 360)
                {
                    txtCRCGroove_a0.Text = "360";
                }
            }
        }

        private void txtCRCGroove_a1_TextChanged(object sender, EventArgs e)
        {
            if (txtCRCGroove_a1.Text != "")
            {
                double b = double.Parse(txtCRCGroove_a1.Text);
                if (b > 360)
                {
                    txtCRCGroove_a1.Text = "360";
                }
            }
        }

        private void txtCRCGroove_a2_TextChanged(object sender, EventArgs e)
        {
            if (txtCRCGroove_a2.Text != "")
            {
                double b = double.Parse(txtCRCGroove_a2.Text);
                if (b > 360)
                {
                    txtCRCGroove_a2.Text = "360";
                }
            }
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }




    }
}