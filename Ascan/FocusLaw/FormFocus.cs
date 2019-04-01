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
using System.Collections;

namespace Ascan
{
    public partial class FormFocus : Form
    {
        private const int MODIFYFLAG = 0;
        private const int ADDFLAG = 1;
        private const int LEFTBORDER = -8;
        private const int RIGHTBORDER = 40;
        private const int MODIFYINDEX = 11;

        private MainForm mainform;
        private List<ClassChanpara> chanPara = new List<ClassChanpara>();
        private List<ClassBeamFile> beamlist = new List<ClassBeamFile>();
        private List<BeamPara> beamPara = new List<BeamPara>();
        private UTPosition position = new UTPosition();
        private Groove groove = new Groove();
        private UltraWedge wedge = new UltraWedge();
        private UltraProbe probe = new UltraProbe();
        private FormGateSetting formgatesetting;
        private GateInformation gateB;

        private int modifyisopen = 0;
        private double grooveheight = 0;

        public FormFocus(MainForm mainform,Groove gro, UltraWedge wed, UltraProbe pro, UTPosition pos)
        {
            InitializeComponent();
            MultiLanguage.getNames(this);
            SetDefaultGate();
            formgatesetting = new FormGateSetting(this, gateB);
            //Getpara();
            this.mainform = mainform;
            groove = gro;
            wedge = wed;
            probe = pro;
            position = pos;
            grooveheight = groove.height.Sum();
            AutoSetpara();
        }

        /**Set Default Gate.*/
        private void SetDefaultGate()
        {
            gateB = new GateInformation();
        }

        /**Set temp testblock,wedge,probe,position.*/
        private void Getpara()
        {
        }

        /**Creat beamfile which is used now.*/
        private void Getcurrentpara()
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
                    angle = BeamPara.TurntoRadian(groove.angle[0]);
                    defectX = 4.5-1.25*zoneindex;
                    defectY = grooveheight - defectX * Math.Tan(angle);

                    Chanpara = new ClassChanpara();
                    Chanpara.config = (int)FocusConfig.Pulse_Echo;
                    Chanpara.method = (int)PathMethod.Reflect;
                    Chanpara.name = "HP" + Convert.ToString(zoneindex) + "DS";
                    Chanpara.defectAngle = 90;
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
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle + groove.angle[0] - 90;

                    BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }
        }


        private void AutoSetpara()
        {
            try
            {
                AutoSet autoset = new AutoSet(groove, 2);
                switch (groove.type)
                {
                    case GrooveType.V:
                        GetVgroovepara(autoset);
                        break;
                    case GrooveType.X:
                        GetXgroovepara(autoset);
                        break;
                    case GrooveType.CRC:
                        GetCRCgroovepara(autoset);
                        break;
                    default:
                        MessageShow.show("groove type error", "坡口类型错误");
                        break;
                }
            }
            catch
            {
                MessageShow.show("坡口数据有误","groove data error");
            }

        }

        private void GetVgroovepara(AutoSet autoset)
        {
            ClassChanpara Chanpara;
            int skewflag = 0;
            int i = 0;
            int j = 0;

            for (i = 0; i < autoset.reflectcount; i++)
            {
                for (skewflag = 0; skewflag < 2; skewflag++)
                {
                    Chanpara = new ClassChanpara();
                    Chanpara.zonetype = (int)ZoneType.Fill;
                    Chanpara.config = (int)FocusConfig.Pulse_Echo;
                    Chanpara.method = (int)PathMethod.Reflect;
                    Chanpara.name = "Fill" + Convert.ToString(i) + GetLeft(skewflag);
                    Chanpara.defectAngle = autoset.defectlist[i].defectangle;
                    Chanpara.velocity = 3.26;
                    Chanpara.activenb[0] = 32;
                    Chanpara.wave = "shear";
                    Chanpara.defectX = autoset.defectlist[i].defectX;
                    Chanpara.defectY = autoset.defectlist[i].defectY;
                    if (skewflag == 0)
                    {
                        Chanpara.skew = 90;
                    }
                    else
                    {
                        Chanpara.skew = 270;
                    }
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle - groove.angle[0];

                    BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                    Chanpara.range = 2 * beampara.gatebefore;
                    Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }

            for (j = 0; j < autoset.directcount; j++)
            {
                for (skewflag = 0; skewflag < 2; skewflag++)
                {
                    Chanpara = new ClassChanpara();
                    Chanpara.config = (int)FocusConfig.Pulse_Echo;
                    Chanpara.method = (int)PathMethod.Direct;
                    Chanpara.zonetype = (int)ZoneType.Root;
                    Chanpara.name = "Root" + Convert.ToString(j) + GetLeft(skewflag);
                    Chanpara.defectAngle = autoset.defectlist[i+j].defectangle;
                    Chanpara.velocity = 3.26;
                    Chanpara.activenb[0] = 32;
                    Chanpara.wave = "shear";
                    Chanpara.defectX = autoset.defectlist[i+j].defectX;
                    Chanpara.defectY = autoset.defectlist[i+j].defectY;
                    if (skewflag == 0)
                    {
                        Chanpara.skew = 90;
                    }
                    else
                    {
                        Chanpara.skew = 270;
                    }
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle;

                    BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                    Chanpara.range = 2 * beampara.gatebefore;
                    Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }
        }

        private void GetCRCgroovepara(AutoSet autoset)
        {
            ClassChanpara Chanpara;
            int skewflag = 0;
            int i = 0;
            int precount = 0;

            for (i = 0; i < autoset.seriescount; i++)
            {
                for (skewflag = 0; skewflag < 2; skewflag++)
                {
                    Chanpara = new ClassChanpara();
                    Chanpara.config = (int)FocusConfig.Pitch_Catch;
                    Chanpara.method = (int)PathMethod.Series;
                    Chanpara.zonetype = (int)ZoneType.Fill;
                    Chanpara.name = "Fill" + Convert.ToString(i) + GetLeft(skewflag);
                    Chanpara.defectAngle = autoset.defectlist[i].defectangle;
                    Chanpara.velocity = 3.26;
                    Chanpara.activenb[0] = 16;
                    Chanpara.activenb[1] = 16;
                    Chanpara.wave = "shear";
                    Chanpara.defectX = autoset.defectlist[i].defectX;
                    Chanpara.defectY = autoset.defectlist[i].defectY;
                    if (skewflag == 0)
                    {
                        Chanpara.skew = 90;
                    }
                    else
                    {
                        Chanpara.skew = 270;
                    }
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle - 5;
                    Chanpara.interfaceAngle[1] = Chanpara.defectAngle + 5;

                    BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                    Chanpara.range = 2 * beampara.gatebefore;
                    Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                    Chanpara.element[1] = beampara.centerele[1] + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }

            precount += i;
            for (i = 0; i < autoset.reflectcount; i++)
            {
                for (skewflag = 0; skewflag < 2; skewflag++)
                {
                    Chanpara = new ClassChanpara();
                    Chanpara.config = (int)FocusConfig.Pulse_Echo;
                    Chanpara.method = (int)PathMethod.Reflect;
                    Chanpara.zonetype = (int)ZoneType.HP;
                    Chanpara.name = "HP" + Convert.ToString(i) + GetLeft(skewflag);
                    Chanpara.defectAngle = autoset.defectlist[i+precount].defectangle;
                    Chanpara.velocity = 3.26;
                    Chanpara.activenb[0] = 32;
                    Chanpara.wave = "shear";
                    Chanpara.defectX = autoset.defectlist[i + precount].defectX;
                    Chanpara.defectY = autoset.defectlist[i + precount].defectY;
                    if (skewflag == 0)
                    {
                        Chanpara.skew = 90;
                    }
                    else
                    {
                        Chanpara.skew = 270;
                    }
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle + 45 - 90;

                    BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                    Chanpara.range = 2 * beampara.gatebefore;
                    Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }

            precount += i;
            for (i = 0; i < autoset.directcount; i++)
            {
                for (skewflag = 0; skewflag < 2; skewflag++)
                {
                    Chanpara = new ClassChanpara();
                    Chanpara.config = (int)FocusConfig.Pulse_Echo;
                    Chanpara.method = (int)PathMethod.Direct;
                    Chanpara.defectAngle = autoset.defectlist[i + precount].defectangle;
                    Chanpara.velocity = 3.26;
                    Chanpara.activenb[0] = 32;
                    Chanpara.wave = "shear";
                    Chanpara.defectX = autoset.defectlist[i + precount].defectX;
                    Chanpara.defectY = autoset.defectlist[i + precount].defectY;
                    if (skewflag == 0)
                    {
                        Chanpara.skew = 90;
                    }
                    else
                    {
                        Chanpara.skew = 270;
                    }

                    //Judge which direct zone 
                    if (Chanpara.defectAngle == 90)
                    {
                        Chanpara.name = "LCP" + Convert.ToString(i) + GetLeft(skewflag);
                        Chanpara.zonetype = (int)ZoneType.LCP;
                        Chanpara.interfaceAngle[0] = Chanpara.defectAngle + groove.angle[2] - 90;
                    }
                    else 
                    {
                        Chanpara.name = "Root" + Convert.ToString(i) + GetLeft(skewflag);
                        Chanpara.zonetype = (int)ZoneType.Root;
                        Chanpara.interfaceAngle[0] = Chanpara.defectAngle;
                    }

                    BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                    Chanpara.range = 2 * beampara.gatebefore;
                    Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }
        }

        private void GetXgroovepara(AutoSet autoset)
        {
            ClassChanpara Chanpara;
            int skewflag = 0;
            int i = 0;
            int j = 0;

            for (i = 0; i < autoset.reflectcount; i++)
            {
                for (skewflag = 0; skewflag < 2; skewflag++)
                {
                    Chanpara = new ClassChanpara();
                    Chanpara.config = (int)FocusConfig.Pulse_Echo;
                    Chanpara.method = (int)PathMethod.Reflect;
                    Chanpara.zonetype = (int)ZoneType.Fill;
                    Chanpara.name = "Fill" + Convert.ToString(i) + GetLeft(skewflag);
                    Chanpara.defectAngle = autoset.defectlist[i].defectangle;
                    Chanpara.velocity = 3.26;
                    Chanpara.activenb[0] = 32;
                    Chanpara.wave = "shear";
                    Chanpara.defectX = autoset.defectlist[i].defectX;
                    Chanpara.defectY = autoset.defectlist[i].defectY;
                    if (skewflag == 0)
                    {
                        Chanpara.skew = 90;
                    }
                    else
                    {
                        Chanpara.skew = 270;
                    }
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle + groove.angle[0] - 90;

                    BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                    Chanpara.range = 2 * beampara.gatebefore;
                    Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }

            for (j = 0; j < autoset.directcount; j++)
            {
                for (skewflag = 0; skewflag < 2; skewflag++)
                {
                    Chanpara = new ClassChanpara();
                    Chanpara.config = (int)FocusConfig.Pulse_Echo;
                    Chanpara.method = (int)PathMethod.Direct;
                    Chanpara.zonetype = (int)ZoneType.Root;
                    Chanpara.name = "Root" + Convert.ToString(j) + GetLeft(skewflag);
                    Chanpara.defectAngle = autoset.defectlist[i + j].defectangle;
                    Chanpara.velocity = 3.26;
                    Chanpara.activenb[0] = 32;
                    Chanpara.wave = "shear";
                    Chanpara.defectX = autoset.defectlist[i + j].defectX;
                    Chanpara.defectY = autoset.defectlist[i + j].defectY;
                    if (skewflag == 0)
                    {
                        Chanpara.skew = 90;
                    }
                    else
                    {
                        Chanpara.skew = 270;
                    }
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle + groove.angle[0] - 90;

                    BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                    beamPara.Add(beampara);
                    beamlist.Add(beampara.beamfile);

                    Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                    Chanpara.range = 2 * beampara.gatebefore;
                    Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                    Chanpara.index = beampara.index;
                    chanPara.Add(Chanpara);
                }
            }
        }

        private string GetLeft(int skew)
        {
            string direct = "";
            if (skew == 0)
            {
                direct = "R";
            }
            else if(skew ==1)
            {
                direct = "L";
            }
            return direct;
        }

        /**Draw the Vgroove.*/
        private void Vgroovedraw()
        {
            LinePoint point = new LinePoint();
            double yv = groove.height[0];
            double Vangle = BeamPara.TurntoRadian(90-groove.angle[0]);
            double xv = (yv / Math.Tan(Vangle));
            wavepath.Series.Clear();
            wavepath.Axes.Left.Maximum = grooveheight + 1;
            point.x[0] = LEFTBORDER;
            point.y[0] = 0;
            point.x[1] = -xv;
            point.y[1] = 0;
            point.x[2] = 0;
            point.y[2] = yv;
            point.x[3] = 0;
            point.y[3] = grooveheight;
            point.x[4] = 0;
            point.y[4] = yv;
            point.x[5] = xv;
            point.y[5] = 0;
            point.x[6] = RIGHTBORDER;
            point.y[6] = 0;
            point.count = 7;
            Draw.DrawLine(point, Color.Black, wavepath);

            point = new LinePoint();
            point.x[0] = LEFTBORDER;
            point.y[0] = grooveheight;
            point.x[1] = RIGHTBORDER;
            point.y[1] = grooveheight;
            point.count = 2;
            Draw.DrawLine(point, Color.Black, wavepath);
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
            LinePoint point = new LinePoint();

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
            Draw.DrawLine(point, Color.Black, wavepath);

            point = new LinePoint();
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
            Draw.DrawLine(point, Color.Black, wavepath);
        }

        /**Draw the Xgroove.*/
        private void Xgroovedraw()
        {
            LinePoint point = new LinePoint();
            double yv = groove.height[0];
            double angle = BeamPara.TurntoRadian(groove.angle[0]);
            double xv = (yv * Math.Tan(angle));
            wavepath.Series.Clear();
            wavepath.Axes.Left.Maximum = grooveheight + 1;
            point.x[0] = LEFTBORDER;
            point.y[0] = 0;
            point.x[1] = -xv;
            point.y[1] = 0;
            point.x[2] = 0;
            point.y[2] = yv;
            point.x[3] = xv;
            point.y[3] = 0;
            point.x[4] = RIGHTBORDER;
            point.y[4] = 0;
            point.count = 5;
            Draw.DrawLine(point, Color.Black, wavepath);

            point = new LinePoint();
            point.x[0] = LEFTBORDER;
            point.y[0] = grooveheight;
            point.x[1] = -(groove.height[1] * Math.Tan(angle)); 
            point.y[1] = grooveheight;
            point.x[2] = 0;
            point.y[2] = yv;
            point.x[3] = (groove.height[1] * Math.Tan(angle));
            point.y[3] = grooveheight;
            point.x[4] = RIGHTBORDER;
            point.y[4] = grooveheight;
            point.count = 5;
            Draw.DrawLine(point, Color.Black, wavepath);
        }

        /**Draw the selected path.*/
        private void Beamdraw(int channel)
        {
            Draw.DrawLine(beamPara[channel].linepoint[0], Color.Black, wavepath);
            Draw.DrawArrow(beamPara[channel].arrowpoint[0], Color.Black, wavepath);
            Draw.DrawLine(beamPara[channel].gatepoint, Color.Red, wavepath);
            if (chanPara[channel].method == (int)PathMethod.Series)
            {
                Draw.DrawLine(beamPara[channel].linepoint[1], Color.Blue, wavepath);
                Draw.DrawArrow(beamPara[channel].arrowpoint[1], Color.Blue, wavepath);
            }
        }

        /**Display the chanpara.*/
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
                paraGrid.Rows[paraGrid.RowCount - 1].Cells["txrx"].Value = GetTxRx(chanPara[i].config);
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
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["txrx"].Value = "Rx";
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["angle"].Value = chanPara[i].interfaceAngle[1];
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["element"].Value = chanPara[i].element[1];
                    paraGrid.Rows[paraGrid.RowCount - 1].Cells["activenb"].Value = chanPara[i].activenb[1];
                }
            }
        }

        public string GetConfig(int con)
        {
            string config;

            if (con == 0)
            {
                config = "Pluse-Echo";
            }
            else if (con == 1)
            {
                config = "Pitch&Catch";
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

        /**Auto set the zone.*/
        private void autoset_Click(object sender, EventArgs e)
        {
            BeamRefresh();
        }

        /**Auto set the zone.*/
        private void BeamRefresh()
        {
            int i = 0;
            seletctedPara.Clear();
            wavepath.Series.Clear();
            DisplayGrid();
            Groovedraw();
            for (i = 0; i < beamPara.Count; i++)
            {
                Beamdraw(i);
            }
        }

        /**Judge which type groove to draw.*/
        private void Groovedraw()
        {
            switch (groove.type)
            {
                case GrooveType.V:
                    Vgroovedraw();
                    break;
                case GrooveType.X:
                    Xgroovedraw();
                    break;
                case GrooveType.CRC:
                    CRCgroovedraw();
                    break;
                default:
                    MessageShow.show("testblock type error", "坡口类型错误");
                    break;
            }
        }

        
        private void test_Click(object sender, EventArgs e)
        {
            int i = 0;
            int channel = 0;
            try
            {
                i = paraGrid.CurrentRow.Index;
                channel = (int)paraGrid.Rows[i].Cells["channel"].Value;
            }
            catch
            {
                return;
            }

            BeamPara beampara = new BeamPara(chanPara[channel], groove, wedge, probe, position, gateB);
        }

        /**Save to beamfile*/
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

        /**Draw the seletcted reflectpath.*/
        private void paraGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelModify.Visible = false;
            int rowIndex = e.RowIndex;
            int columIndex = e.ColumnIndex;
            int channel = 0;
            double index;
            double defectX;
            double defectY;
            double pathtime;
            double gatestart;
            double gaterange;

            if (rowIndex >= 0)
            {
                try
                {
                    channel = (int)paraGrid.Rows[rowIndex].Cells["channel"].Value;
                }
                catch
                {
                    return;
                }

                if ((displayselected.Checked == true) && (columIndex == 0))
                {
                    wavepath.Series.Clear();
                    Groovedraw();
                    Beamdraw(channel);
                    index = Math.Round(chanPara[channel].index, 2);
                    defectX = Math.Round(chanPara[channel].defectX, 2);
                    defectY = Math.Round(chanPara[channel].defectY, 2);
                    pathtime = Math.Round(beamPara[channel].pathtime, 2);
                    gatestart = Math.Round((beamPara[channel].pathtime - beamPara[channel].gatebefore), 2);
                    gaterange = Math.Round(2*beamPara[channel].gatebefore, 2);
                    seletctedPara.Text = "Index: " + index + "mm" + "\r\n" + "X: " + defectX + "mm" + "\r\n" + "Y: " + defectY + "mm" + "\r\n" + "Pathtime: " + pathtime + "us" + "\r\n" + "Delay: " + gatestart + "us" + "\r\n" + "Range: " + gaterange + "us";
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

        /**Open the FormModify*/
        private void paraModify_Click(object sender, EventArgs e)
        {
            int i = paraGrid.CurrentRow.Index;
            int channel = (int)paraGrid.Rows[i].Cells["channel"].Value;
            if (modifyisopen == 0)
            {
                FormModify myFormModify = new FormModify(this, MODIFYFLAG, groove,chanPara[channel].method);
                myFormModify.Show();
                modifyisopen = 1;
            }
        }

        /**Change the chanpara after modify*/
        public void Modifypara(FormModify formModify,int cancelflag)
        {
            modifyisopen = 0;
            panelModify.Visible = false;
            if (cancelflag == 0)
            {
                int i = paraGrid.CurrentRow.Index;
                int channel = (int)paraGrid.Rows[i].Cells["channel"].Value;
                int method = 0;

                ClassChanpara Chanpara = new ClassChanpara();
                method = chanPara[channel].method;
                chanPara[channel].defectAngle = formModify.angled;
                chanPara[channel].defectY = formModify.yd;

                switch (groove.type)
                {
                    case GrooveType.V:
                        ModifyVgroove(chanPara[channel].defectY, chanPara[channel].defectAngle, channel);
                        break;
                    case GrooveType.X:
                        ModifyXgroove(chanPara[channel].defectY, chanPara[channel].defectAngle, channel);
                        break;
                    case GrooveType.CRC:
                        ModifyCRCgroove(chanPara[channel].defectY, chanPara[channel].defectAngle, channel);
                        break; 
                    default:
                        MessageShow.show("testblock type error", "坡口类型错误");
                        break;
                }

                BeamPara beampara = new BeamPara(chanPara[channel], groove, wedge, probe, position, gateB);
                beamPara[channel] = beampara;
                beamlist[channel] = beampara.beamfile;

                chanPara[channel].delay = beampara.pathtime - beampara.gatebefore;
                chanPara[channel].range = 2 * beampara.gatebefore;
                chanPara[channel].index = beampara.index;
                chanPara[channel].element[0] = beampara.centerele[0];
                if (method == (int)PathMethod.Series)
                {
                    chanPara[channel].element[1] = beampara.centerele[1];
                }

                BeamRefresh();
            }
        }

        public void ModifyVgroove(double yd, double angle, int channel)
        {
            int method = chanPara[channel].method;
            if (method == (int)PathMethod.Reflect)
            {
                chanPara[channel].defectX = (groove.height[0] - yd) * Math.Tan(BeamPara.TurntoRadian(groove.angle[0]));
                chanPara[channel].interfaceAngle[0] = chanPara[channel].defectAngle - groove.angle[0];
            }

            else if (method == (int)PathMethod.Direct)
            {
                chanPara[channel].defectX = 0;
                chanPara[channel].interfaceAngle[0] = chanPara[channel].defectAngle;
            }
        }

        public void ModifyXgroove(double yd, double angle, int channel)
        {
            chanPara[channel].defectX = Math.Abs((groove.height[0] - yd)) / Math.Tan(BeamPara.TurntoRadian(groove.angle[0]));
            chanPara[channel].interfaceAngle[0] = chanPara[channel].defectAngle - groove.angle[0];
        }

        public void ModifyCRCgroove(double yd, double angle, int channel)
        {
            int method = chanPara[channel].method;

            if (method == (int)PathMethod.Reflect)
            {
                chanPara[channel].defectX = (groove.height[1] + groove.height[0] - yd) * Math.Tan(BeamPara.TurntoRadian(groove.angle[1]));
                chanPara[channel].interfaceAngle[0] = groove.angle[1]; ;
            }
            else if(method == (int)PathMethod.Direct)
            {
                if (chanPara[channel].defectAngle == 90)
                {
                    chanPara[channel].defectX = (yd - (grooveheight - groove.height[3])) * Math.Tan(BeamPara.TurntoRadian(groove.angle[2]));
                    chanPara[channel].interfaceAngle[0] = groove.angle[2];
                }
                else
                {
                    chanPara[channel].defectX = 0;
                    chanPara[channel].interfaceAngle[0] = chanPara[channel].defectAngle;
                }
            }
            else if (method == (int)PathMethod.Series)
            {
                chanPara[channel].defectX = groove.height[1] * Math.Tan(BeamPara.TurntoRadian(groove.angle[1])) + (groove.height[0] - yd) * Math.Tan(BeamPara.TurntoRadian(groove.angle[0]));
                chanPara[channel].interfaceAngle[0] = chanPara[channel].defectAngle - groove.angle[0];
                chanPara[channel].interfaceAngle[1] = chanPara[channel].defectAngle + groove.angle[0];
            }
        }

        /**Add the chanpara*/
        public void Addpara(FormModify formModify, int cancelflag)
        {
            modifyisopen = 0;
            if (cancelflag == 0)
            {
                double defectY = formModify.yd;
                double angle = formModify.angled;
                int channel = chanPara.Count;
                ClassChanpara chanpara = new ClassChanpara();

                switch (groove.type)
                {
                    case GrooveType.V:
                        AddVgroove(defectY, angle, formModify.method);
                        break;
                    case GrooveType.X:
                        AddXgroove(defectY, angle, formModify.method);
                        break;
                    case GrooveType.CRC:
                        AddCRCgroove(defectY, angle, formModify.method);
                        break;
                    default:
                        MessageShow.show("testblock type error", "坡口类型错误");
                        break;
                }
                BeamRefresh();
            }
        }

        /**Add the VGroovepara*/
        public void AddVgroove(double yd,double angle,int method)
        {
            int skewflag = 0;
            ClassChanpara Chanpara;
            for (skewflag = 0; skewflag < 2; skewflag++)
            {
                Chanpara = new ClassChanpara();
                Chanpara.config = (int)FocusConfig.Pulse_Echo;
                Chanpara.method = method;
                Chanpara.defectAngle = angle;
                Chanpara.velocity = 3.26;
                Chanpara.activenb[0] = 32;
                Chanpara.wave = "shear";


                if (skewflag == 0)
                {
                    Chanpara.skew = 90;
                }
                else
                {
                    Chanpara.skew = 270;
                }

                if (method == (int)PathMethod.Reflect)
                {
                    Chanpara.name = "HP" + "DS";
                    Chanpara.defectY = yd;
                    Chanpara.defectX = (groove.height[0] - yd) * Math.Tan(BeamPara.TurntoRadian(groove.angle[0]));
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle - groove.angle[0];
                }

                else if (method == (int)PathMethod.Direct)
                {
                    Chanpara.name = "ROOT";
                    Chanpara.defectY = yd;
                    Chanpara.defectX = 0;
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle;
                }
                BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                beamPara.Add(beampara);
                beamlist.Add(beampara.beamfile);

                Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                Chanpara.range = 2 * beampara.gatebefore;
                Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                Chanpara.index = beampara.index;
                chanPara.Add(Chanpara);            
            }
        }

        /**Add the XGroovepara*/
        public void AddXgroove(double yd, double angle, int method)
        {
            int skewflag = 0;
            ClassChanpara Chanpara;
            for (skewflag = 0; skewflag < 2; skewflag++)
            {
                Chanpara = new ClassChanpara();
                Chanpara.config = (int)FocusConfig.Pulse_Echo;
                Chanpara.method = method;
                Chanpara.defectAngle = angle;
                Chanpara.velocity = 3.26;
                Chanpara.activenb[0] = 32;
                Chanpara.wave = "shear";

                if (skewflag == 0)
                {
                    Chanpara.skew = 90;
                }
                else
                {
                    Chanpara.skew = 270;
                }
                if (method == (int)PathMethod.Reflect)
                {
                    Chanpara.name = "HP" + "DS";
                    Chanpara.defectY = yd;
                    Chanpara.defectX = (groove.height[0] - yd) / Math.Tan(BeamPara.TurntoRadian(groove.angle[0]));
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle - groove.angle[0];
                }

                else if (method == (int)PathMethod.Direct)
                {
                    Chanpara.name = "ROOT";
                    Chanpara.defectY = yd;
                    Chanpara.defectX = (yd - groove.height[0]) / Math.Tan(BeamPara.TurntoRadian(groove.angle[0])); ;
                    Chanpara.interfaceAngle[0] = 90 - groove.angle[0];
                }
                BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                beamPara.Add(beampara);
                beamlist.Add(beampara.beamfile);

                Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                Chanpara.range = 2 * beampara.gatebefore;
                Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                Chanpara.index = beampara.index;
                chanPara.Add(Chanpara);
            }
        }

        /**Add the CRCGroovepara*/
        public void AddCRCgroove(double yd, double angle, int method)
        {
            int skewflag = 0;
            ClassChanpara Chanpara;
            for (skewflag = 0; skewflag < 2; skewflag++)
            {
                Chanpara = new ClassChanpara();
                Chanpara.config = (int)FocusConfig.Pulse_Echo;
                Chanpara.method = method;
                Chanpara.defectAngle = angle;
                Chanpara.velocity = 3.26;
                Chanpara.activenb[0] = 32;
                Chanpara.activenb[1] = 32;
                Chanpara.wave = "shear";

                if (skewflag == 0)
                {
                    Chanpara.skew = 90;
                }
                else
                {
                    Chanpara.skew = 270;
                }

                if (method == (int)PathMethod.Reflect)
                {
                    Chanpara.name = "HP" + "DS";
                    Chanpara.defectY = yd;
                    Chanpara.defectX = (groove.height[1] + groove.height[0] - yd) * Math.Tan(BeamPara.TurntoRadian(groove.angle[1])); 
                    Chanpara.interfaceAngle[0] = groove.angle[1];
                }
                else if (method == (int)PathMethod.Direct)
                {
                    Chanpara.name = "ROOT";
                    Chanpara.defectY = yd;

                    if (Chanpara.defectAngle == 90)
                    {
                        Chanpara.defectX = (yd - (grooveheight - groove.height[3])) * Math.Tan(BeamPara.TurntoRadian(groove.angle[2]));
                        Chanpara.interfaceAngle[0] = groove.angle[2];
                    }
                    else
                    {
                        Chanpara.defectX = 0;
                        Chanpara.interfaceAngle[0] = Chanpara.defectAngle;
                    }
                }
                else if (method == (int)PathMethod.Series)
                {
                    Chanpara.name = "Fill";
                    Chanpara.defectY = yd;
                    Chanpara.defectX = groove.height[1] * Math.Tan(BeamPara.TurntoRadian(groove.angle[1])) + (groove.height[0] - yd) * Math.Tan(BeamPara.TurntoRadian(groove.angle[0]));
                    Chanpara.interfaceAngle[0] = Chanpara.defectAngle - groove.angle[0];
                    Chanpara.interfaceAngle[1] = Chanpara.defectAngle + groove.angle[0];
                }
                BeamPara beampara = new BeamPara(Chanpara, groove, wedge, probe, position, gateB);
                beamPara.Add(beampara);
                beamlist.Add(beampara.beamfile);

                Chanpara.delay = beampara.pathtime - beampara.gatebefore;
                Chanpara.range = 2 * beampara.gatebefore;
                Chanpara.element[0] = beampara.centerele[0] + 64 * skewflag;
                if (method == (int)PathMethod.Series)
                {
                    Chanpara.element[1] = beampara.centerele[1] + 64 * skewflag;
                }
                Chanpara.index = beampara.index;
                chanPara.Add(Chanpara);
            }
        }

        /**Init to Draw the seletcted reflectpath.*/
        private void displayselected_CheckedChanged(object sender, EventArgs e)
        {
            wavepath.Series.Clear();
            Groovedraw();
        }

        private void chanAdd_Click(object sender, EventArgs e)
        {
            if (modifyisopen == 0)
            {                
                FormModify myFormModify = new FormModify(this, ADDFLAG, groove,0);
                myFormModify.Show();
                modifyisopen = 1;
            }
        }

        private void chanDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            int channel = 0;
            try
            {
                i = paraGrid.CurrentRow.Index;
                channel = (int)paraGrid.Rows[i].Cells["channel"].Value;
            }
            catch
            {
                return;
            }

            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定删除该通道?", "删除通道", messButton);
            if (dr == DialogResult.OK)
            {
                if (chanPara[channel].zonetype != (int)ZoneType.Couple)
                {
                    beamPara.Remove(beamPara[channel]);
                }
                chanPara.Remove(chanPara[channel]);
                beamlist.Remove(beamlist[channel]);
            }

            BeamRefresh();

        }

        private void Recommend_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定使用推荐设置?", "推荐设置", messButton);
            if (dr == DialogResult.OK)
            {
                chanPara = new List<ClassChanpara>();
                beamlist = new List<ClassBeamFile>();
                beamPara = new List<BeamPara>();
                AutoSetpara();
                BeamRefresh();
            }

        }

        private void FormFocus_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.SetChan(beamlist,chanPara);
            FormList.FormDetectionMode.SetChan(chanPara);
        }

        public void GetGatedata(GateInformation gateb)
        {
            gateB = gateb;
        }

        private void gatesetting_Click(object sender, EventArgs e)
        {
            formgatesetting.Show();
        }

        private void btn_addcouple_Click(object sender, EventArgs e)
        {
            int i = 0;
            int skewflag = 0;
            int startele = 0;
            int curchancount = 0;
            ClassChanpara couplechan;
            ClassCouple couplebeam;
            for (skewflag = 0; skewflag < 2; skewflag++)
            {
                for (i = 0; i < 4; i++)
                {
                    curchancount = chanPara.Count;
                    couplechan = new ClassChanpara();
                    startele = i * 16 + 1;
                    couplebeam = new ClassCouple(probe, wedge, position,groove,i * 16 + 1, skewflag);
                    couplechan.config = (int)FocusConfig.Pulse_Echo;
                    couplechan.name = "Couple" + i + GetLeft(skewflag);
                    couplechan.zonetype = (int)ZoneType.Couple;
                    if(skewflag == 0)
                    {
                        couplechan.skew = 90;
                    }
                    else
                    {
                        couplechan.skew = 270;
                    }
                    couplechan.activenb[0] = 16;
                    couplechan.element[0] = startele;
                    couplechan.gatedelay = couplebeam.gatedelay;
                    chanPara.Add(couplechan);
                    beamlist.Add(couplebeam.beamfile);
                }
            }
            DisplayGrid();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
