using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Steema.TeeChart;
using System.IO;

namespace Ascan
{
    public partial class FormFocus : Form
    {

        private const int LEFTBORDER = -8;
        private const int RIGHTBORDER = 40;
        private const int MODIFYINDEX = 11;

        private List<ClassChanpara> chanPara = new List<ClassChanpara>();
        private List<ClassBeamFile> beamlist = new List<ClassBeamFile>();
        private List<BeamPara> beamPara = new List<BeamPara>();
        private testBlock testblock = new testBlock();
        private wedge Wedge = new wedge();
        private probe Probe = new probe();
        private position Position = new position();

        public FormFocus()
        {
            InitializeComponent();
            Getpara();
            Getchannelpara();
        }

        private void Getpara()
        {
            testblock.BlockHeight = 8.7;
            testblock.BottomLength = 0;
            testblock.TestBlockVelocity = 3.26;
            testblock.VAngle = 60;
            testblock.VerticalHeight = 0;
            testblock.Type = 0;

            Wedge.WedgeLeftHeight = 57.5;
            Wedge.WedgeTopLength = 28.5;
            Wedge.WedgeAngle = 30;
            Wedge.WedgeVelocity = 2.336;

            Probe.FirstDistance = 2.5;
            Probe.ElementaryPitch = 1;
            Probe.NumOfExcitation = 64;

            Position.WedgePosition = 32;
            Position.ProbePosition = 5.5;
        }

        private void Getchannelpara()
        {
            ClassChanpara Chanpara;
            int zoneindex = 0;
            double defectX = 0;
            double defectY = 0;
            double angle = 0;
            int skewflag = 0;

            for (zoneindex = 0; zoneindex < 4; zoneindex++)
            {
                for(skewflag = 0; skewflag<2; skewflag++)
                {
                    angle = BeamPara.TurntoRadian(testblock.VAngle);
                    defectX = 4.5-1.25*zoneindex;
                    defectY = testblock.BlockHeight - defectX * Math.Tan(angle);

                    Chanpara = new ClassChanpara();
                    Chanpara.config = 0;
                    Chanpara.txrx = 0;
                    Chanpara.method = 1;
                    Chanpara.name = "HP" + Convert.ToString(zoneindex) + "DS";
                    Chanpara.defectAngle[0] = 90;
                    Chanpara.velocity = 3.26;
                    Chanpara.activenb[0] = 32;
                    Chanpara.wave = "shear";
                    Chanpara.defectX = defectX;
                    Chanpara.defectY = defectY;
                    if (skewflag == 0)
                    {
                        Chanpara.skew = 90;
                    }
                    else
                    {
                        Chanpara.skew = 270;
                    }
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle[0] + testblock.VAngle - 90;

                    BeamPara beampara = new BeamPara(Chanpara, testblock, Wedge, Probe, Position);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.element[0] = beampara.centerele + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }

            //for (skewflag = 0; skewflag < 2; skewflag++)
            //{
            //    angle = BeamPara.TurntoRadian(testblock.VAngle);
            //    defectX = 0.5;
            //    defectY = testblock.BlockHeight - defectX * Math.Tan(angle);

            //    Chanpara = new ClassChanpara();
            //    Chanpara.config = 0;
            //    Chanpara.txrx = 0;
            //    Chanpara.method = 0;
            //    Chanpara.name = "ROOT";
            //    Chanpara.defectAngle[0] = 70;
            //    Chanpara.velocity = 3.26;
            //    Chanpara.activenb[0] = 32;
            //    Chanpara.wave = "shear";
            //    Chanpara.defectX = defectX;
            //    Chanpara.defectY = defectY;
            //    if (skewflag == 0)
            //    {
            //        Chanpara.skew = 90;
            //    }
            //    else
            //    {
            //        Chanpara.skew = 270;
            //    }
            //    Chanpara.interfaceAngle[0] = Chanpara.defectAngle[0];

            //    BeamPara beampara = new BeamPara(Chanpara, testblock, Wedge, Probe, Position);
            //    beamPara.Add(beampara);
            //    beamlist.Add(beampara.beamfile);

            //    Chanpara.element[0] = beampara.centerele + 64 * skewflag;
            //    Chanpara.index = beampara.index;
            //    chanPara.Add(Chanpara);
            //}

        }

        /**Draw the Vgroove.*/
        private void Vgroovedraw()
        {
            DrawPoint point = new DrawPoint();
            double yv = testblock.BlockHeight - testblock.BottomLength;
            double Vangle = BeamPara.TurntoRadian(testblock.VAngle);
            double xv = (yv / Math.Tan(Vangle));
            wavepath.Series.Clear();
            wavepath.Axes.Left.Maximum = testblock.BlockHeight + 1;
            point.x[0] = LEFTBORDER;
            point.y[0] = 0;
            point.x[1] = -xv;
            point.y[1] = 0;
            point.x[2] = 0;
            point.y[2] = yv;
            point.x[3] = 0;
            point.y[3] = testblock.BlockHeight;
            point.x[4] = 0;
            point.y[4] = yv;
            point.x[5] = xv;
            point.y[5] = 0;
            point.x[6] = RIGHTBORDER;
            point.y[6] = 0;
            point.count = 7;
            Draw.testline(point, Color.Black, wavepath);

            point = new DrawPoint();
            point.x[0] = LEFTBORDER;
            point.y[0] = testblock.BlockHeight;
            point.x[1] = RIGHTBORDER;
            point.y[1] = testblock.BlockHeight;
            point.count = 2;
            Draw.testline(point, Color.Black, wavepath);
        }

        /**Draw the CRCgroove.*/
        private void CRCgroovedraw()
        {
            wavepath.Series.Clear();
            double h0 = 6.27;
            double h1 = 2.82;
            double h2 = 1;
            double h3 = 1.91;
            double h = h0 + h1 + h2 + h3;
            double angle0 = BeamPara.TurntoRadian(5);
            double angle1 = BeamPara.TurntoRadian(45);
            double angle2 = BeamPara.TurntoRadian(37.5);
            DrawPoint point = new DrawPoint();

            wavepath.Axes[0].Maximum = h+1;
            point.x[0] = LEFTBORDER;
            point.y[0] = 0;
            point.x[1] = -(h0*Math.Tan(angle0)+h1*Math.Tan(angle1));
            point.y[1] = 0;
            point.x[2] = -h1 * Math.Tan(angle1);
            point.y[2] = h0;
            point.x[3] = 0;
            point.y[3] = h0+h1;
            point.x[4] = 0;
            point.y[4] = h0+h1+h2;
            point.x[5] = 0;
            point.y[5] = h0+h1;
            point.x[6] = h1 * Math.Tan(angle1);
            point.y[6] = h0;
            point.x[7] = h0 * Math.Tan(angle0) + h1 * Math.Tan(angle1);
            point.y[7] = 0;
            point.x[8] = RIGHTBORDER;
            point.y[8] = 0;
            point.count = 9;
            Draw.testline(point, Color.Green, wavepath);

            point = new DrawPoint();
            point.x[0] = LEFTBORDER;
            point.y[0] = h;
            point.x[1] = -h3 * Math.Tan(angle2);
            point.y[1] = h;
            point.x[2] = 0;
            point.y[2] = h - h3;
            point.x[3] = h3 * Math.Tan(angle2);
            point.y[3] = h;
            point.x[4] = RIGHTBORDER;
            point.y[4] = h;
            point.count = 5;
            Draw.testline(point, Color.Green, wavepath);
        }

        /**Draw the Jgroove.*/
        private void Jgroovedraw()
        {

        }

        /**Draw the reflectpath.*/
        private void ReflectPathdraw(DrawPoint point)
        {
            Draw.testline(point, Color.Red, wavepath);
        }

        private void DisplayGrid()
        {
            int num = 0;
            int i = 0;

            paraGrid.Rows.Clear();
            num = chanPara.Count;
            for (i = 0; i < num; i++)
            {
                paraGrid.RowCount += 1;
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["channel"].Value = i;
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["config"].Value = GetConfig(chanPara[i].config);
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["txrx"].Value = GetTxRx(chanPara[i].txrx);
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["name"].Value = chanPara[i].name;
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["wave"].Value = chanPara[i].wave;
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["angle"].Value = chanPara[i].interfaceAngle[0];
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["element"].Value = chanPara[i].element[0];
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["activenb"].Value = chanPara[i].activenb[0];
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["index"].Value = Math.Round(chanPara[i].index,2);
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["velocity"].Value = chanPara[i].velocity;
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["skew"].Value = chanPara[i].skew;
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["modify"].Value = ".........";
                if (chanPara[i].config == 1)
                {
                    paraGrid.RowCount += 1;
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["channel"].Value = i;
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["config"].Value = GetConfig(chanPara[i].config);
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["txrx"].Value = "Rx";
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["name"].Value = chanPara[i].name;
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["wave"].Value = chanPara[i].wave;
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["angle"].Value = chanPara[i].interfaceAngle[1];
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["element"].Value = chanPara[i].element[1];
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["activenb"].Value = chanPara[i].activenb[1];
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["index"].Value = Math.Round(chanPara[i].index, 2);
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["velocity"].Value = chanPara[i].velocity;
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["skew"].Value = chanPara[i].skew;
                }
            }
        }

        public string GetConfig(int con)
        {
            string config;

            if (con == 0)
            {
                config = "Pluser-Ec";
            }
            else if (con == 1)
            {
                config = "Picher&Catcher";
            }
            else
            {
                config = "error";
                MessageShow.show("get config err", "获取通道设置错误");
            }
            return config;
        }

        public string GetTxRx(int tr)
        {
            string txrx = "";

            if (tr == 0)
            {
                txrx = "Tx/RX";
            }
            else if (tr == 1)
            {
                txrx = "TX";
            }
            else
            {
                MessageShow.show("get TXRX err", "获取收发模式错误");
            }
            return txrx;
        }


        private void autoset_Click(object sender, EventArgs e)
        {
            int i = 0;
            seletctedPara.Clear();
            wavepath.Series.Clear();
            DisplayGrid();
            Groovedraw();
            for (i = 0; i < beamPara.Count; i++)
            {
                ReflectPathdraw(beamPara[i].point);
            }
        }


        private void Groovedraw()
        {
            switch (testblock.Type)
            {
                case 0:
                    Vgroovedraw();
                    break;
                case 1:
                    CRCgroovedraw();
                    break;
                case 2:
                    Jgroovedraw();
                    break;
                case 3:
                    break;
                default:
                    MessageShow.show("testblock type error", "坡口类型错误");
                    break;
            }
        }

        /**Draw the seletcted reflectpath.*/
        private void test_Click(object sender, EventArgs e)
        {
            CRCgroovedraw();
        }

        private void save_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = paraGrid.CurrentRow.Index;
            SaveFileDialog bfSaveDialog = new SaveFileDialog();
            string filePath = Application.StartupPath + @"\BeamFile";
            bfSaveDialog.Filter = "bm文件(*.bm)|*.bm|所有文件(*.*)|*.*";

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
            bfSaveDialog.InitialDirectory = filePath;
            bfSaveDialog.FilterIndex = 1;
            if (bfSaveDialog.ShowDialog() == DialogResult.OK)
            {
                ClassBeamFile beamfile = beamlist[i];
                String filename = bfSaveDialog.FileName;
                string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
                date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
                SystemConfig.WriteConfigData(filename, "date", date);
                SystemConfig.WriteBase64Data(filename, "beamFile", beamfile);
            }

        }

        private void paraGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelModify.Visible = false;
            int rowIndex = e.RowIndex;
            int columIndex = e.ColumnIndex;
            int channel = 0;
            double index;
            double defectX;
            double defectY;

            if (rowIndex >= 0)
            {
                if ((displayselected.Checked == true) && (columIndex == 0))
                {
                    channel = (int)paraGrid.Rows[rowIndex].Cells["channel"].Value;
                    wavepath.Series.Clear();
                    Groovedraw();
                    ReflectPathdraw(beamPara[channel].point);
                    index = Math.Round(chanPara[channel].index, 2);
                    defectX = Math.Round(chanPara[channel].defectX, 2);
                    defectY = Math.Round(chanPara[channel].defectY, 2);
                    seletctedPara.Text = "Index: " + index + "\r\n" + "X: " + defectX + "\r\n" + "Y: " + defectY;
                }
                else if (columIndex == MODIFYINDEX)
                {
                    System.Drawing.Rectangle rect = paraGrid.GetCellDisplayRectangle(columIndex, rowIndex, false);
                    panelModify.Size = rect.Size;
                    panelModify.Top = rect.Top;
                    panelModify.Left = rect.Left;
                    panelModify.Visible = true;
                }
            }
        }


        private void paraModify_Click(object sender, EventArgs e)
        {
            FormModify myFormModify = new FormModify(this);
            myFormModify.Show();
        }


        public void Modifypara(FormModify formModify,int cancelflag)
        {
            panelModify.Visible = false;
            if (cancelflag == 0)
            {
                int i = paraGrid.CurrentRow.Index;
                int channel = (int)paraGrid.Rows[i].Cells["channel"].Value;
                double defectX = 0;
                double defectY = 0;
                double angle = 0;

                ClassChanpara Chanpara = new ClassChanpara();
                angle = BeamPara.TurntoRadian(testblock.VAngle);
                defectX = formModify.xd;
                defectY = testblock.BlockHeight - defectX * Math.Tan(angle);

                chanPara[channel].defectAngle[0] = angle;
                chanPara[channel].interfaceAngle[0] = Chanpara.defectAngle[0] + testblock.VAngle - 90; ;
                BeamPara beampara = new BeamPara(Chanpara, testblock, Wedge, Probe, Position);
                beamPara[channel] = beampara;
                beamlist[channel] = beampara.beamfile;

                chanPara[channel].index = beampara.index;
                chanPara[channel].element[0] = beampara.centerele;
            }
        }

        private void displayselected_CheckedChanged(object sender, EventArgs e)
        {
            wavepath.Series.Clear();
            Groovedraw();
        }

       


    }

}
