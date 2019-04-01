using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Ascan
{
    public partial class FormSscan : Form
    {
        private MainForm mainform;
        private int itemNuM;
        public int passNum;
        private int startItemIndex;
        private int startAngle;
        private int endAngle;
        private int singleAngle;
        private int skew;
        public bool isStart = false;
        public bool isSectorScan = false;

        private double startPlace = 0;
        private double scanRange = 60;
        private double grooveheight;
        private double wedgeIncidentHeight;
        private double endtostartWidth;
        private double incidentAngleEnd;
        private double incidentAngleStart;
        private double incidentAngleCenter;
        private double R0;
        private double R1;
        private double timeStart;
        private double timeSum;
        private double timeEnd;
        private double timeInterval;
        private double Rstart;
        private double Rend;
        private double Rcenter_;
        private double Rend_;
        private double Rstart_;
        private double ystart;
        private double x0;
        private double y0;
        private double x0_;
        private double y0_;
        private double yend;
        private double xend;
        private double bmpWidth;
        private double bmpHeight;
        private int pcw;
        private int pch;
        private int pcstart;
        private int pcend;
        private double bmpWidthSector;
        private double bmpHeightSector;
        private double pointWidth;
        private double gain;
        private double[][] refractPoint;

        private float[][] ascandata;
        byte[] onePagedataArray;
        private AscanVideo ascan;
        private RingBufferQueue<AscanQueueElement> ascanQueue;
        private AscanQueueElement elementdequeue;
        private Bitmap imageForColor;
        protected delegate void updatePictureCallBack();
        protected updatePictureCallBack updatePictureFunc;

        List<SBeamList> sBeamList = new List<SBeamList>(); 
        private static List<SessionInfo> sessionIfo = new List<SessionInfo>();

        private Groove groove = new Groove();
        private UltraWedge wedge = new UltraWedge();
        private UltraProbe probe = new UltraProbe();
        private UTPosition position = new UTPosition();

        public FormSscan(MainForm mainform)
        {
            InitializeComponent();
            this.mainform = mainform;
            ascanQueue = new RingBufferQueue<AscanQueueElement>();
            elementdequeue = new AscanQueueElement();

            InitFormSscan();

            wedge.length = 92.07;
            wedge.height = 43.09;
            wedge.incidentAngle = 30;
            wedge.longVeloc = 2.337;
            wedge.transVeloc = 2.337;
            wedge.headLen = 28.00;
        }

        private void InitFormSscan()
        {
            numericUpDown6.DecimalPlaces = 1;
            numericUpDown6.Increment = 0.1M;

            numericUpDown7.DecimalPlaces = 1;
            numericUpDown7.Increment = 0.1M;
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (numericUpDown1.Value >= 1 && numericUpDown1.Value <= 64)
                    {
                        itemNuM = (int)numericUpDown1.Value;
                    }
                    else
                    {
                        MessageShow.show("The data input value surpass the prescribed value", "输入值超过规定的大小");
                    }
                }
            }            
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            if (numericUpDown1.Text != "0")
            {
                if (numericUpDown1.Value >= 1 && numericUpDown1.Value <= 64)
                {
                    itemNuM = (int)numericUpDown1.Value;
                }
                else
                {
                    MessageShow.show("The data input value surpass the prescribed value", "输入值超出规定的大小");
                }
            }
        }

        private void numericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
                if (numericUpDown1.Text == "")
                {
                    MessageShow.show("Warning:Please input diameter!", "警告:请输入孔径!");
                    return;
                }
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (numericUpDown2.Value != 0 && numericUpDown2.Value <= 128)
                    {
                        startItemIndex = (int)numericUpDown2.Value;
                        if (startItemIndex <= 64)
                        {
                            if (startItemIndex + itemNuM - 1 > 64)
                            {
                                MessageShow.show("Warning:Please input again!", "警告:超出单边范围!");
                                return;
                            }
                            else
                            {
                                skew = 0;
                            }
                        }
                        else
                        {
                            if (startItemIndex + itemNuM - 1 > 128)
                            {
                                MessageShow.show("Warning:Please input again!", "警告:超出单边范围!");
                                return;
                            }
                            else
                            {
                                skew = 1;
                            }
                        }
                    }
                    else
                    {
                        MessageShow.show("The data input value surpass the prescribed value", "输入超出范围");
                    }
                }
            }       
        }

        private void numericUpDown2_Leave(object sender, EventArgs e)
        {
            if (numericUpDown2.Text != "0")
            {
                if (numericUpDown2.Value != 0 && numericUpDown2.Value <= 128)
                {
                    startItemIndex = (int)numericUpDown2.Value;
                    if (startItemIndex <= 64)
                    {
                        if (startItemIndex + itemNuM - 1 > 64)
                        {
                            MessageShow.show("Warning:Please input again!", "警告:超出单边范围!");
                            return;
                        }
                        else
                        {
                            skew = 0;
                        }
                    }
                    else
                    {
                        if (startItemIndex + itemNuM - 1 > 128)
                        {
                            MessageShow.show("Warning:Please input again!", "警告:超出单边范围!");
                            return;
                        }
                        else
                        {
                            skew = 1;
                        }
                    }
                }
                else
                {
                    MessageShow.show("The data input value surpass the prescribed value", "输入超出范围");
                }
            }
        }

        private void numericUpDown3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (numericUpDown3.Value > 0)
                    {
                        startAngle = (int)numericUpDown3.Value;
                    }
                    else
                    {
                        MessageShow.show("Warning:Please input again!", "警告:起始角必须大于0!");
                    }
                }
            }           
        }

        private void numericUpDown3_Leave(object sender, EventArgs e)
        {
            if (numericUpDown3.Text != "0")
            {
                if (numericUpDown3.Value > 0)
                {
                    startAngle = (int)numericUpDown3.Value;
                }
                else
                {
                    MessageShow.show("Warning:Please input again!", "警告:起始角必须大于0!");
                }
            }
        }

        private void numericUpDown4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if ((double)numericUpDown4.Value > startAngle)
                    {
                        endAngle = (int)numericUpDown4.Value;
                    }
                    else
                    {
                        MessageShow.show("Warning:Please input!", "警告:终止角需大于起始角!");
                        return;
                    }
                }
                
            }           
        }

        private void numericUpDown4_Leave(object sender, EventArgs e)
        {
            if (numericUpDown4.Text != "0")
            {
                if ((double)numericUpDown4.Value > startAngle)
                {
                    endAngle = (int)numericUpDown4.Value;
                }
                else
                {
                    MessageShow.show("Warning:Please input!", "警告:终止角需大于起始角!");
                    return;
                }
            }
        }

        private void numericUpDown5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if ((double)numericUpDown5.Value > (endAngle - startAngle))
                    {
                        MessageShow.show("Warning:Please input!", "警告:步进角需小于终止角与起始角之差!");
                        return;
                    }
                    else
                    {
                        singleAngle = (int)numericUpDown5.Value;
                    }
                }
                
            }       
        }

        private void numericUpDown5_Leave(object sender, EventArgs e)
        {
            if (numericUpDown5.Text != "0")
            {
                if ((double)numericUpDown5.Value > (endAngle - startAngle))
                {
                    MessageShow.show("Warning:Please input!", "警告:步进角需小于终止角与起始角之差!");
                    return;
                }
                else
                {
                    singleAngle = (int)numericUpDown5.Value;
                }
            }
            
        }

        private void numericUpDown6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (numericUpDown6.Value < 0)
                    {
                        MessageShow.show("Warning:Please input!", "警告:起始位置必须大于0!");
                        return;
                    }
                    else
                    {
                        startPlace = (double)numericUpDown6.Value;
                    }
                }
                
            }
            
        }

        private void numericUpDown6_Leave(object sender, EventArgs e)
        {
            if (numericUpDown6.Text != "")
            {
                if (numericUpDown6.Value < 0)
                {
                    MessageShow.show("Warning:Please input!", "警告:起始位置必须不小于0!");
                    return;
                }
                else
                {
                    startPlace = (double)numericUpDown6.Value;
                }
            }
        } 

        private void numericUpDown7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (numericUpDown6.Text == "")
                    {
                        MessageShow.show("Warning:Please input!", "警告:请输入起始值!");
                        return;
                    }
                    else
                    {
                        if (numericUpDown7.Value < numericUpDown6.Value)
                        {
                            MessageShow.show("Warning:Please input!", "警告:扫查范围必须大于起始位置!");
                            return;
                        }
                        else
                        {
                            scanRange = (double)numericUpDown7.Value;
                        }
                    }
                }
            }           
        }

        private void numericUpDown7_Leave(object sender, EventArgs e)
        {
            if (numericUpDown7.Text != "0.0")
            {
                if (numericUpDown6.Text == "")
                {
                    MessageShow.show("Warning:Please input!", "警告:请输入起始值!");
                    return;
                }
                else
                {
                    if (numericUpDown7.Value < numericUpDown6.Value)
                    {
                        MessageShow.show("Warning:Please input!", "警告:扫查范围必须大于起始位置!");
                        return;
                    }
                    else
                    {
                        scanRange = (double)numericUpDown7.Value;
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                && e.KeyChar != '.' && e.KeyChar != (char)109 && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && textBox1.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    gain = 0;
                    textBox1.Text = "0";
                }
                else
                {
                    gain = Convert.ToDouble(textBox1.Text);

                    if (gain > 82.0)
                    {
                        gain = 82.0;
                        textBox1.Text = "82.0";
                    }

                    if (gain < -48.0)
                    {
                        gain = -48.0;
                        textBox1.Text = "-48.0";
                    }
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageShow.show("Warning:Please input!", "警告：请输入");
                return;
            }
            gain = Convert.ToDouble(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text == "0")
            {
                MessageShow.show("Warning:Please input diameter!", "警告:请输入孔径!");
                return;
            }
            if (numericUpDown2.Text == "0")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入首晶片!");
                return;
            }
            if (numericUpDown3.Text == "0")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入起始角!");
                return;
            }
            if (numericUpDown4.Text == "0")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入终止角!");
                return;
            }
            if (numericUpDown5.Text == "0")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入扫查步距!");
                return;
            }
            if (numericUpDown6.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入起始位置!");
                return;
            }
            if (numericUpDown7.Text == "0.0")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入扫查范围!");
                return;
            }

            groove = mainform.groove;
            //wedge = mainform.wedge;
            probe = mainform.probe;
            position = mainform.position;

            groove.transVeloc = 6.305;   //铝

            passNum = (endAngle - startAngle) / singleAngle + 1;
            wedgeIncidentHeight = wedge.height - (position.probePosition + probe.eleEdge + startItemIndex * probe.eleSpace + (itemNuM - startItemIndex) / 2 * probe.eleSpace) * Math.Sin(wedge.incidentAngle * Math.PI / 180);
            incidentAngleEnd = Math.Asin(wedge.transVeloc * Math.Sin(endAngle * Math.PI / 180) / groove.transVeloc) / Math.PI * 180;
            incidentAngleStart = Math.Asin(wedge.transVeloc * Math.Sin(startAngle * Math.PI / 180) / groove.transVeloc) / Math.PI * 180;
            incidentAngleCenter = (incidentAngleStart + incidentAngleEnd) / 2;
            double singleAngleWidth = wedgeIncidentHeight * (Math.Tan(incidentAngleEnd * Math.PI / 180) - Math.Tan(incidentAngleStart * Math.PI / 180)) / (passNum - 1);
            endtostartWidth = wedgeIncidentHeight * (Math.Tan(incidentAngleEnd * Math.PI / 180) - Math.Tan(incidentAngleStart * Math.PI / 180));

            timeStart = wedgeIncidentHeight / Math.Cos(incidentAngleStart * Math.PI / 180) / (wedge.transVeloc) + startPlace / (groove.transVeloc) * 2;
            timeEnd = (wedgeIncidentHeight / Math.Cos(incidentAngleStart * Math.PI / 180) / (wedge.transVeloc) + scanRange / (groove.transVeloc)) * 2;
            timeSum = timeEnd - timeStart;
            timeInterval = timeSum / 512;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            if (mainform.groove.type == GrooveType.CRC)
            {
                grooveheight = groove.height[0] + groove.height[1] + groove.height[2] + groove.height[3];
            }
            if (mainform.groove.type == GrooveType.V || mainform.groove.type == GrooveType.X)
            {
                grooveheight = groove.height[0] + groove.height[1];
            }
            if (mainform.groove.type == GrooveType.X)
            {
                grooveheight = groove.height[0] + groove.height[1];
            }

            double bmpWidth = 0;
            double bmpHeight = grooveheight;
            double bmpWidth1 = wedge.length - ((wedge.length - wedge.headLen) / Math.Cos(wedge.incidentAngle * Math.PI / 180) - (position.probePosition + probe.eleEdge + startItemIndex * probe.eleSpace + (itemNuM - startItemIndex) / 2 * probe.eleSpace)) * Math.Cos(wedge.incidentAngle * Math.PI / 180) - wedgeIncidentHeight * Math.Tan(incidentAngleEnd * Math.PI / 180);
            if (grooveheight * Math.Tan(endAngle * Math.PI / 180) * 2 <= bmpWidth1)
            {
                bmpWidth = (bmpWidth1 + endtostartWidth) * 2 + 5;
            }
            else
            {
                bmpWidth = bmpWidth1 + grooveheight * Math.Tan(endAngle * Math.PI / 180) * 2 + endtostartWidth + 5;
            }
            double pcHeight = pictureBox1.Width * (bmpHeight / bmpWidth);
            double bmpHeightSector = pcHeight / bmpHeight;
            double bmpWidthSector = pictureBox1.Width / bmpWidth;
            if (mainform.groove.type == GrooveType.CRC)
            {
                bmp = DrawCRCGroove(groove, bmpHeightSector, bmpWidthSector);
            }
            if (mainform.groove.type == GrooveType.V)
            {
                bmp = DrawVGroove(groove, bmpHeightSector, bmpWidthSector);
            }
            if (mainform.groove.type == GrooveType.X)
            {
                bmp = DrawXGroove(groove, bmpHeightSector, bmpWidthSector);
            }

            for (int i = 0; i < passNum; i++)
            {
                double refractAngle = endAngle - i * singleAngle;
                double startx0 = wedge.length - ((wedge.length - wedge.headLen) / Math.Cos(wedge.incidentAngle * Math.PI / 180) - (position.probePosition + probe.eleEdge + probe.eleNum * probe.eleSpace / 2)) * Math.Cos(wedge.incidentAngle * Math.PI / 180) - wedgeIncidentHeight * Math.Tan(incidentAngleEnd * Math.PI / 180) + singleAngleWidth * i;
                DrawReflectLine(ref bmp, startx0, grooveheight, refractAngle, bmpHeightSector, bmpWidthSector);
            }

            GetR1();
            GetSectorPara();
            SaveRefractPoint();

            if (skew == 0)
            {
                this.pictureBox1.Image = bmp;
            }
            else
            {
                MirrorBmp(ref bmp);
                this.pictureBox1.Image = bmp;
            }

            ascandata = new float[passNum][];
            for (int i = 0; i < passNum;i++ )
            {
                ascandata[i] = new float[512];
            }
            onePagedataArray = new byte[pictureBox2.Width * pictureBox2.Height * 3];            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text == "")
            {
                MessageShow.show("Warning:Please input diameter!", "警告:请输入孔径!");
                return;
            }
            if (numericUpDown2.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入首晶片!");
                return;
            }
            if (numericUpDown3.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入起始角!");
                return;
            }
            if (numericUpDown4.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入终止角!");
                return;
            }
            if (numericUpDown5.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入扫查步距!");
                return;
            }

            passNum = (int)((endAngle - startAngle) / singleAngle + 1);
            for (int i = 0; i < passNum;i++ )
            {
                double refractAngle = i * singleAngle + startAngle;
                SBeamList sBeamFile = new SBeamList();
                if (skew == 0)
                {
                    sBeamFile.assignName = "S_L-"+i.ToString();
                }
                if (skew == 1)
                {
                    sBeamFile.assignName = "S_R-"+i.ToString();
                }                
                sBeamFile.skew = skew;
                sBeamFile.angle = refractAngle;
                sBeamFile.timeStart = timeStart;
                sBeamFile.timeSum = timeEnd;
                GetDelayTime(refractAngle, mainform.wedge.transVeloc, mainform.groove.transVeloc, mainform.probe.eleSpace, mainform.wedge.incidentAngle, ref sBeamFile);
                sBeamList.Add(sBeamFile);
            }
            FormList.mySessionsListForm.Sscanset(sBeamList);
        }

        private Bitmap DrawCRCGroove(Groove crcgroove, double bmpHeightSector, double bmpWidthSector)
        {
            int grooveHeight = (int)((crcgroove.height[0] + crcgroove.height[1] + crcgroove.height[2] + crcgroove.height[3]) * bmpHeightSector);
            int grooveWidth0 = (int)(crcgroove.height[0] * bmpWidthSector * Math.Tan(crcgroove.angle[0] * Math.PI / 180));
            int grooveWidth1 = (int)(crcgroove.height[1] * bmpWidthSector * Math.Tan(crcgroove.angle[1] * Math.PI / 180));
            int grooveWidth2 = (int)(crcgroove.height[3] * bmpWidthSector * Math.Tan(crcgroove.angle[2] * Math.PI / 180));
            int grooveHeight0 = (int)(crcgroove.height[0] * bmpHeightSector);
            int grooveHeight1 = (int)(crcgroove.height[1] * bmpHeightSector);
            int grooveHeight2 = (int)(crcgroove.height[2] * bmpHeightSector);
            int grooveHeight3 = (int)(crcgroove.height[3] * bmpHeightSector);

            int x0 = pictureBox1.Width / 2;
            int y0 = pictureBox1.Height / 2;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            //g.Clear(Color.White);
            Pen black_pen1 = new Pen(Color.Black, 2);

            g.DrawLine(black_pen1, 0, y0 - (int)(grooveHeight / 2), pictureBox1.Width, y0 - (int)(grooveHeight / 2));
            g.DrawLine(black_pen1, 0, y0 + (int)(grooveHeight / 2), pictureBox1.Width, y0 + (int)(grooveHeight / 2));

            g.DrawLine(black_pen1, x0 + grooveWidth0 + grooveWidth1, y0 - (int)(grooveHeight / 2), x0 + grooveWidth1, y0 - (int)(grooveHeight / 2) + grooveHeight0);
            g.DrawLine(black_pen1, x0 + grooveWidth1, y0 - (int)(grooveHeight / 2) + grooveHeight0, x0, y0 - (int)(grooveHeight / 2) + grooveHeight0 + grooveHeight1);
            g.DrawLine(black_pen1, x0, y0 - (int)(grooveHeight / 2) + grooveHeight0 + grooveHeight1, x0, y0 - (int)(grooveHeight / 2) + grooveHeight0 + grooveHeight1 + grooveHeight2);
            g.DrawLine(black_pen1, x0, y0 - (int)(grooveHeight / 2) + grooveHeight0 + grooveHeight1 + grooveHeight2, x0 + grooveWidth2, y0 + (int)(grooveHeight / 2));
            g.DrawLine(black_pen1, x0 - grooveWidth2, y0 + (int)(grooveHeight / 2), x0, y0 - (int)(grooveHeight / 2) + grooveHeight0 + grooveHeight1 + grooveHeight2);
            g.DrawLine(black_pen1, x0, y0 - (int)(grooveHeight / 2) + grooveHeight0 + grooveHeight1, x0 - grooveWidth1, y0 - (int)(grooveHeight / 2) + grooveHeight0);
            g.DrawLine(black_pen1, x0 - grooveWidth1, y0 - (int)(grooveHeight / 2) + grooveHeight0, x0 - grooveWidth0 - grooveWidth1, y0 - (int)(grooveHeight / 2));

            return bmp;
        }

        private Bitmap DrawVGroove(Groove vgroove, double bmpHeightSector, double bmpWidthSector)
        {
            int grooveHeight = (int)((vgroove.height[0] + vgroove.height[1]) * bmpHeightSector);
            int grooveWidth0 = (int)((vgroove.distance / 2 + vgroove.height[0] * Math.Tan(vgroove.angle[0] * Math.PI / 180)) * bmpWidthSector);
            int grooveWidth1 = (int)(vgroove.distance / 2 * bmpWidthSector);
            int grooveHeight0 = (int)(vgroove.height[0] * bmpHeightSector);

            int x0 = pictureBox1.Width / 2;
            int y0 = pictureBox1.Height / 2;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            //g.Clear(Color.White);
            Pen black_pen1 = new Pen(Color.Black, 2);

            g.DrawLine(black_pen1, 0, y0 - (int)(grooveHeight / 2), pictureBox1.Width, y0 - (int)(grooveHeight / 2));
            g.DrawLine(black_pen1, 0, y0 + (int)(grooveHeight / 2), pictureBox1.Width, y0 + (int)(grooveHeight / 2));

            g.DrawLine(black_pen1, x0 - grooveWidth0, y0 - (int)(grooveHeight / 2), x0 - grooveWidth1, y0 - (int)(grooveHeight / 2) + grooveHeight0);
            g.DrawLine(black_pen1, x0 + grooveWidth0, y0 - (int)(grooveHeight / 2), x0 + grooveWidth1, y0 - (int)(grooveHeight / 2) + grooveHeight0);
            g.DrawLine(black_pen1, x0 - grooveWidth1, y0 - (int)(grooveHeight / 2) + grooveHeight0, x0 - grooveWidth1, y0 + (int)(grooveHeight / 2));
            g.DrawLine(black_pen1, x0 + grooveWidth1, y0 - (int)(grooveHeight / 2) + grooveHeight0, x0 + grooveWidth1, y0 + (int)(grooveHeight / 2));

            return bmp;
        }

        private Bitmap DrawXGroove(Groove xgroove, double bmpHeightSector, double bmpWidthSector)
        {
            int grooveHeight = (int)((xgroove.height[0] + xgroove.height[1]) * bmpHeightSector);
            int grooveWidth = (int)(xgroove.height[0] * Math.Tan(xgroove.angle[0] * Math.PI / 180) * bmpWidthSector);

            int x0 = pictureBox1.Width / 2;
            int y0 = pictureBox1.Height / 2;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            //g.Clear(Color.White);
            Pen black_pen1 = new Pen(Color.Black, 2);

            g.DrawLine(black_pen1, 0, y0 - (int)(grooveHeight / 2), pictureBox1.Width, y0 - (int)(grooveHeight / 2));
            g.DrawLine(black_pen1, 0, y0 + (int)(grooveHeight / 2), pictureBox1.Width, y0 + (int)(grooveHeight / 2));

            g.DrawLine(black_pen1, x0 - grooveWidth, y0 - (int)(grooveHeight / 2), x0 + grooveWidth, y0 + (int)(grooveHeight / 2));
            g.DrawLine(black_pen1, x0 + grooveWidth, y0 - (int)(grooveHeight / 2), x0 - grooveWidth, y0 + (int)(grooveHeight / 2));

            return bmp;
        }

        private void DrawVGroove(Groove vgroove, int x0, int y0, PictureBox pcb, ref Bitmap bmp, double bmpWidthSector, double bmpHeightSector)
        {
            double grooveHeight = (vgroove.height[0] + vgroove.height[1]) / bmpHeightSector;
            int grooveWidth = (int)(vgroove.distance / bmpWidthSector / 2);
            int grooveWidth1 = (int)(vgroove.height[0] * Math.Tan(vgroove.angle[0] * Math.PI / 180) / bmpWidthSector);
            int grooveHeight0 = (int)(vgroove.height[0] / bmpHeightSector);
            int grooveHeight1 = (int)(vgroove.height[1] / bmpHeightSector);

            Graphics g = Graphics.FromImage(bmp);
            Pen black_pen = new Pen(Color.White, 1);

            g.DrawLine(black_pen, 0, y0, pcb.Width, y0);
            g.DrawLine(black_pen, 0, y0 + (int)(grooveHeight), pcb.Width, y0 + (int)(grooveHeight));

            g.DrawLine(black_pen, x0 + grooveWidth + grooveWidth1, y0, x0 + grooveWidth, y0 + grooveHeight0);
            g.DrawLine(black_pen, x0 + grooveWidth, y0 + grooveHeight0, x0 + grooveWidth, y0 + (int)grooveHeight);
            g.DrawLine(black_pen, x0 - grooveWidth, y0 + (int)grooveHeight, x0 - grooveWidth, y0 + (int)grooveHeight - grooveHeight1);
            g.DrawLine(black_pen, x0 - grooveWidth, y0 + (int)grooveHeight - grooveHeight1, x0 - grooveWidth - grooveWidth1, y0);
        }

        private void DrawVGroovemirror(Groove vgroove, int x0, int y0, PictureBox pcb, ref Bitmap bmp, double bmpWidthSector, double bmpHeightSector)
        {
            double grooveHeight = (vgroove.height[0] + vgroove.height[1]) / bmpHeightSector;
            int grooveWidth = (int)(vgroove.distance / bmpWidthSector / 2);
            int grooveWidth1 = (int)(vgroove.height[0] * Math.Tan(vgroove.angle[0] * Math.PI / 180) / bmpWidthSector);
            int grooveHeight0 = (int)(vgroove.height[0] / bmpHeightSector);
            int grooveHeight1 = (int)(vgroove.height[1] / bmpHeightSector);

            Graphics g = Graphics.FromImage(bmp);
            //g.Clear(Color.White);
            Pen black_pen = new Pen(Color.White, 1);

            g.DrawLine(black_pen, 0, y0, pcb.Width, y0);
            g.DrawLine(black_pen, 0, y0 + (int)(grooveHeight), pcb.Width, y0 + (int)(grooveHeight));

            g.DrawLine(black_pen, x0 - grooveWidth, y0, x0 - grooveWidth, y0 + grooveHeight1);
            g.DrawLine(black_pen, x0 - grooveWidth, y0 + grooveHeight1, x0 - grooveWidth - grooveWidth1, y0 + (int)grooveHeight);
            g.DrawLine(black_pen, x0 + grooveWidth + grooveWidth1, y0 + (int)grooveHeight, x0 + grooveWidth, y0 + (int)grooveHeight - grooveHeight0);
            g.DrawLine(black_pen, x0 + grooveWidth, y0 + (int)grooveHeight - grooveHeight0, x0 + grooveWidth, y0);

        }

        private void DrawXGroove(Groove xgroove, int x0, int y0, PictureBox pcb, ref Bitmap bmp, double bmpWidthSector, double bmpHeightSector)
        {
            double grooveHeight = (xgroove.height[0] + xgroove.height[1]) / bmpHeightSector;
            int grooveWidth = (int)(xgroove.height[0] / bmpHeightSector * Math.Tan(xgroove.angle[0] * Math.PI / 180));

            Graphics g = Graphics.FromImage(bmp);
            Pen black_pen = new Pen(Color.White, 1);

            g.DrawLine(black_pen, 0, y0, pcb.Width, y0);
            g.DrawLine(black_pen, 0, y0 + (int)(grooveHeight), pcb.Width, y0 + (int)(grooveHeight));

            g.DrawLine(black_pen, x0 - grooveWidth, y0, x0 + grooveWidth, y0 + (int)grooveHeight);
            g.DrawLine(black_pen, x0 + grooveWidth, y0, x0 - grooveWidth, y0 + (int)grooveHeight);
        }

        private void DrawCRCGroove(Groove crcgroove, int x0, int y0, PictureBox pcb, ref Bitmap bmp, double bmpWidthSector, double bmpHeightSector)
        {
            double grooveHeight = (crcgroove.height[0] + crcgroove.height[1] + crcgroove.height[2] + crcgroove.height[3]) / bmpHeightSector;
            int grooveWidth0 = (int)(crcgroove.height[0] * Math.Tan(crcgroove.angle[0] * Math.PI / 180) / bmpWidthSector + crcgroove.height[1] * Math.Tan(crcgroove.angle[1] * Math.PI / 180) / bmpWidthSector);
            int grooveWidth1 = (int)(crcgroove.height[1] * Math.Tan(crcgroove.angle[1] * Math.PI / 180) / bmpWidthSector);
            int grooveWidth3 = (int)(crcgroove.height[3] * Math.Tan(crcgroove.angle[2] * Math.PI / 180) / bmpWidthSector);
            int grooveHeight0 = (int)(crcgroove.height[0] / bmpHeightSector);
            int grooveHeight1 = (int)((crcgroove.height[0] + crcgroove.height[1]) / bmpHeightSector);
            int grooveHeight2 = (int)((crcgroove.height[0] + crcgroove.height[1] + crcgroove.height[2]) / bmpHeightSector);

            Graphics g = Graphics.FromImage(bmp);
            Pen black_pen = new Pen(Color.White, 1);

            g.DrawLine(black_pen, 0, y0, pcb.Width, y0);
            g.DrawLine(black_pen, 0, y0 + (int)(grooveHeight), pcb.Width, y0 + (int)(grooveHeight));

            g.DrawLine(black_pen, x0 - grooveWidth0, y0, x0 - grooveWidth1, y0 + grooveHeight0);
            g.DrawLine(black_pen, x0 - grooveWidth1, y0 + grooveHeight0, x0, y0 + grooveHeight1);
            g.DrawLine(black_pen, x0, y0 + grooveHeight1, x0, y0 + grooveHeight2);
            g.DrawLine(black_pen, x0, y0 + grooveHeight2, x0 - grooveWidth3, y0 + (int)(grooveHeight));
            g.DrawLine(black_pen, x0 + grooveWidth3, y0 + (int)(grooveHeight), x0, y0 + grooveHeight2);
            g.DrawLine(black_pen, x0, y0 + grooveHeight1, x0 + grooveWidth1, y0 + grooveHeight0);
            g.DrawLine(black_pen, x0 + grooveWidth1, y0 + grooveHeight0, x0 + grooveWidth0, y0);
        }

        private void DrawCRCGroovemirror(Groove crcgroove, int x0, int y0, PictureBox pcb, ref Bitmap bmp, double bmpWidthSector, double bmpHeightSector)
        {
            double grooveHeight = (crcgroove.height[0] + crcgroove.height[1] + crcgroove.height[2] + crcgroove.height[3]) / bmpHeightSector;
            int grooveWidth0 = (int)(crcgroove.height[0] * Math.Tan(crcgroove.angle[0] * Math.PI / 180) / bmpWidthSector + crcgroove.height[1] * Math.Tan(crcgroove.angle[1] * Math.PI / 180) / bmpWidthSector);
            int grooveWidth1 = (int)(crcgroove.height[1] * Math.Tan(crcgroove.angle[1] * Math.PI / 180) / bmpWidthSector);
            int grooveWidth3 = (int)(crcgroove.height[3] * Math.Tan(crcgroove.angle[2] * Math.PI / 180) / bmpWidthSector);
            int grooveHeight3 = (int)(crcgroove.height[3] / bmpHeightSector);
            int grooveHeight1 = (int)((crcgroove.height[3] + crcgroove.height[2] + crcgroove.height[1]) / bmpHeightSector);
            int grooveHeight2 = (int)((crcgroove.height[3] + crcgroove.height[2]) / bmpHeightSector);

            Graphics g = Graphics.FromImage(bmp);
            Pen black_pen = new Pen(Color.White, 1);

            g.DrawLine(black_pen, 0, y0, pcb.Width, y0);
            g.DrawLine(black_pen, 0, y0 + (int)(grooveHeight), pcb.Width, y0 + (int)(grooveHeight));

            g.DrawLine(black_pen, x0 - grooveWidth3, y0, x0, y0 + grooveHeight3);
            g.DrawLine(black_pen, x0 + grooveWidth3, y0, x0, y0 + grooveHeight3);
            g.DrawLine(black_pen, x0, y0 + grooveHeight3, x0, y0 + grooveHeight2);
            g.DrawLine(black_pen, x0, y0 + grooveHeight2, x0 + grooveWidth1, y0 + grooveHeight1);
            g.DrawLine(black_pen, x0, y0 + grooveHeight2, x0 - grooveWidth1, y0 + grooveHeight1);
            g.DrawLine(black_pen, x0 + grooveWidth1, y0 + grooveHeight1, x0 + grooveWidth0, y0 + (int)(grooveHeight));
            g.DrawLine(black_pen, x0 - grooveWidth1, y0 + grooveHeight1, x0 - grooveWidth0, y0 + (int)(grooveHeight));
        }

        private void GetDelayTime(double refractAngle, double c1, double c2, double d, double wedgeAngle, ref SBeamList sBeamFile)
        {
            double incidentAngle = Math.Asin(c1 * Math.Sin(refractAngle * Math.PI / 180) / c2) / Math.PI * 180;
            double rotateAngle = incidentAngle - wedgeAngle;
            if (rotateAngle < 0)
            {
                rotateAngle = Math.Abs(rotateAngle);

                for (int i = 0; i < itemNuM; i++)
                {
                    //delayTime[i] = i * d / c1 * Math.Sin(rotateAngle * Math.PI / 180);
                    sBeamFile.beamfile.txDelay[i] = (float)(i * d / c1 * Math.Sin(rotateAngle * Math.PI / 180));
                    sBeamFile.beamfile.rxDelay[i] = (float)(i * d / c1 * Math.Sin(rotateAngle * Math.PI / 180));
                    sBeamFile.beamfile.txSize = (uint)itemNuM;
                    sBeamFile.beamfile.rxSize = (uint)itemNuM;
                    sBeamFile.beamfile.txElementBin = BeamPara.GetBeambin(startItemIndex, itemNuM, sBeamFile.skew);
                    sBeamFile.beamfile.rxElementBin = BeamPara.GetBeambin(startItemIndex, itemNuM, sBeamFile.skew);
                }
            }
            else
            {
                for (int i = 0; i < itemNuM; i++)
                {
                    sBeamFile.beamfile.txDelay[itemNuM - 1 - i] = (float)(i * d / c1 * Math.Sin(rotateAngle * Math.PI / 180));
                    sBeamFile.beamfile.rxDelay[itemNuM - 1 - i] = (float)(i * d / c1 * Math.Sin(rotateAngle * Math.PI / 180));
                    sBeamFile.beamfile.txSize = (uint)itemNuM;
                    sBeamFile.beamfile.rxSize = (uint)itemNuM;
                    sBeamFile.beamfile.txElementBin = BeamPara.GetBeambin(startItemIndex, itemNuM, sBeamFile.skew);
                    sBeamFile.beamfile.rxElementBin = BeamPara.GetBeambin(startItemIndex, itemNuM, sBeamFile.skew);
                }
            }

        }

        private void DrawReflectLine(ref Bitmap bmp, double startx0, double grooveHeight, double refractAngle, double bmpHeightSector, double bmpWidthSector)
        {
            Graphics g = Graphics.FromImage(bmp);
            Pen black_pen2 = new Pen(Color.Blue, 1);
            int x0 = (int)(pictureBox1.Width / 2 - startx0 * bmpWidthSector);
            int y0 = (int)(pictureBox1.Height / 2 - grooveHeight / 2 * bmpHeightSector);

            int x1 = x0 + (int)(grooveHeight * Math.Tan(refractAngle * Math.PI / 180) * bmpWidthSector);
            int y1 = (int)(pictureBox1.Height / 2 + grooveHeight / 2 * bmpHeightSector);
            int x2 = x1 + (int)(grooveHeight * Math.Tan(refractAngle * Math.PI / 180) * bmpWidthSector);
            int y2 = (int)(pictureBox1.Height / 2 - grooveHeight / 2 * bmpHeightSector);

            g.DrawLine(black_pen2, x0, y0, x1, y1);
            g.DrawLine(black_pen2, x1, y1, x2, y2);
        }

        private void GetR1()
        {
            double endtostartWidth = wedgeIncidentHeight * (Math.Tan(incidentAngleEnd * Math.PI / 180) - Math.Tan(incidentAngleStart * Math.PI / 180));
            double R0 = Math.Sin((90 - endAngle) * Math.PI / 180) * endtostartWidth / Math.Sin((endAngle - startAngle) * Math.PI / 180);
            R1 = R0 + scanRange;
        }

        private double GetrefractPoint(double endtostartWidth, double x0, double y0, double x0_, double y0_, double ystart, int pcw, double x, double y)
        {
            double timeMin = 10000;
            double pointtostartWidth = 0;
            double intervalWidth = endtostartWidth / pcw;
            for (double i = 0; i <= endtostartWidth; )
            {
                double pointx = x0 + i;
                double pointy = y0 + ystart + 2;
                double pointx_ = x0_ + i;
                double pointy_ = y0_ + ystart + 2;

                double time1 = Math.Sqrt(pointx_ * pointx_ + pointy_ * pointy_) / (wedge.transVeloc) + Math.Sqrt((x - pointx) * (x - pointx) + (y - pointy) * (y - pointy)) / (groove.transVeloc);

                if (time1 < timeMin)
                {
                    timeMin = time1;
                    pointtostartWidth = i;
                }
                i = i + intervalWidth;
            }

            return pointtostartWidth;
        }

        private void MirrorBmp(ref Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width / 2 - 1; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c1 = bmp.GetPixel(i, j);
                    Color c2 = new Color();
                    int m = bmp.Width / 2 - 1 - i;
                    c2 = bmp.GetPixel(bmp.Width / 2 - 1 + m, j);
                    bmp.SetPixel(i, j, c2);
                    bmp.SetPixel(bmp.Width / 2 - 1 + m, j, c1);
                }
            }
        }

        public void enqueue(AscanQueueElement element,int port)
        {
            if (ascanQueue != null)
            {
                if (ascanQueue.Count == passNum)
                {
                    bool result = false;
                    result = this.dequeue();
                    if (!result)
                        return;
                    //updateAscans();
                }
                else
                {
                    ascan = element.ascanPacket.ascan;
                    uint len = ascan.len;
                    Array.Copy(ascan.wave, ascandata[port], len);
                    ascanQueue.Enqueue(element);                    
                }
            }
        }

        private bool dequeue()
        {
            int count = ascanQueue.Count;

            if (count == 0)
                return false;

            while (count > 0)
            {
                ascanQueue.Dequeue(ref elementdequeue);
                count--;
            }
            return true;
        }

        private void updateAscans()
        {
            InterpolationPoint();
            updatePicture();
        }

        private void GetSectorPara()
        {
            endtostartWidth = wedgeIncidentHeight * (Math.Tan(incidentAngleEnd * Math.PI / 180) - Math.Tan(incidentAngleStart * Math.PI / 180));
            R0 = Math.Sin((90 - endAngle) * Math.PI / 180) * endtostartWidth / Math.Sin((endAngle - startAngle) * Math.PI / 180);
            Rstart = R0 + startPlace;
            Rend = R1;
            Rcenter_ = wedgeIncidentHeight / Math.Cos(incidentAngleCenter * Math.PI / 180);
            Rend_ = wedgeIncidentHeight / Math.Cos(incidentAngleEnd * Math.PI / 180);
            Rstart_ = wedgeIncidentHeight / Math.Cos(incidentAngleStart * Math.PI / 180);

            ystart = wedgeIncidentHeight - wedgeIncidentHeight / Math.Cos(incidentAngleCenter * Math.PI / 180) * Math.Cos(incidentAngleEnd * Math.PI / 180);
            x0 = R0 * Math.Sin(startAngle * Math.PI / 180);
            y0 = R0 * Math.Cos(startAngle * Math.PI / 180) - ystart - 2;
            y0_ = wedgeIncidentHeight - ystart - 2;
            x0_ = wedgeIncidentHeight / Math.Cos(incidentAngleStart * Math.PI / 180) * Math.Sin(incidentAngleStart * Math.PI / 180);
            yend = R1 * Math.Cos(startAngle * Math.PI / 180) + 5;
            xend = R1 * Math.Sin(endAngle * Math.PI / 180) + 5;
            bmpWidth = xend - x0;
            bmpHeight = yend - y0;

            //校正上半部分起始点Rstart_
            double pointAngle = Math.Asin(R0 * Math.Sin((90 + startAngle) * Math.PI / 180) / Rstart) / Math.PI * 180;
            double pointAngle1 = 180 - (90 + startAngle) - pointAngle;
            pointWidth = Math.Sqrt(R0 * R0 + Rstart * Rstart - 2 * R0 * Rstart * Math.Cos(pointAngle1 * Math.PI / 180));
            double comparepointWidth = wedgeIncidentHeight * (Math.Tan(incidentAngleCenter * Math.PI / 180) - Math.Tan(incidentAngleStart * Math.PI / 180));
            if (comparepointWidth < pointWidth)
            {
                double Rstart_x = x0_ + pointWidth;
                double Rstart_y = y0_ + ystart + 2;
                Rstart_ = Math.Sqrt(Rstart_x * Rstart_x + Rstart_y * Rstart_y);
            }

            //计算X，Y坐标系数
            double pwh = (double)pictureBox2.Width / (double)pictureBox2.Height;
            if (bmpWidth / bmpHeight > pwh)
            {
                pcw = pictureBox2.Width;
                pch = pictureBox2.Height;
                pcstart = 0;
                pcend = pictureBox2.Width;
            }
            else
            {
                pch = pictureBox2.Height;
                pcw = (int)(pictureBox2.Height * (bmpWidth / bmpHeight));
                if (pcw % 2 != 0)
                {
                    pcw = pcw - 1;
                }
                pcstart = pictureBox2.Width / 2 - pcw / 2;
                pcend = pictureBox2.Width / 2 + pcw / 2;
            }

            bmpWidthSector = bmpWidth / pcw;
            bmpHeightSector = bmpHeight / pch;

            refractPoint = new double[pictureBox2.Height][];
            for (int i = 0; i < pictureBox2.Height; i++)
            {
                refractPoint[i] = new double[pictureBox2.Width];
            }
        }

        private void SaveRefractPoint()
        {
            for (int i = 0; i < pictureBox2.Height; i++)
            {
                for (int j = 0; j < pictureBox2.Width; j++)
                {
                    if (j >= pcstart && j < pcend)
                    {
                        double bmpx = (j - pcstart) * bmpWidthSector;
                        double bmpy = i * bmpHeightSector;

                        if (bmpy >= ystart + 2)
                        {
                            double x = bmpx + x0;
                            double y = bmpy + y0;

                            double r = Math.Sqrt(x * x + y * y);
                            double rotateAngle = Math.Atan(x / y) * 180 / Math.PI;
                            double rotateAngleJudge = 90 - rotateAngle;

                            if (((r > Rstart) && (r < Rend)) && ((rotateAngleJudge >= 90 - endAngle) && (rotateAngleJudge <= 90 - startAngle)))
                            {
                                refractPoint[i][j] = GetrefractPoint(endtostartWidth, x0, y0, x0_, y0_, ystart, pcw, x, y);
                            }
                        }
                    }
                }
            }
        }

        private void InterpolationPoint()
        {
            byte red = 0;
            byte green = 0;
            byte blue = 0;

            for (int i = 0; i < pictureBox2.Height; i++)
            {
                for (int j = 0; j < pictureBox2.Width; j++)
                {
                    if (j >= pcstart && j < pcend)
                    {
                        double bmpx = (j - pcstart) * bmpWidthSector;
                        double bmpy = i * bmpHeightSector;

                        if ((bmpy < ystart + 2) && (pointWidth < endtostartWidth))
                        {
                            double x_ = bmpx + x0_;
                            double y_ = bmpy + y0_;

                            double r_ = Math.Sqrt(x_ * x_ + y_ * y_);
                            double rotateAngle_ = Math.Atan(x_ / y_) * 180 / Math.PI;
                            double rotateAngle_Judge = 90 - rotateAngle_;

                            if (((r_ >= Rcenter_) && (r_ <= Rend_)) && ((rotateAngle_Judge >= 90 - incidentAngleEnd) && (rotateAngle_Judge <= 90 - incidentAngleCenter)))
                            {
                                double rotateAngle_refract = Math.Asin(Math.Sin(rotateAngle_ * Math.PI / 180) * groove.transVeloc / wedge.transVeloc) * 180 / Math.PI;
                                int m = (int)((rotateAngle_refract - startAngle) / singleAngle);
                                double incidentrotateAngle_ = Math.Asin(Math.Sin((m * singleAngle + startAngle) * Math.PI / 180) * wedge.transVeloc / groove.transVeloc) * 180 / Math.PI;
                                double singleAngle_ = Math.Asin(Math.Sin(singleAngle * Math.PI / 180) * wedge.transVeloc / groove.transVeloc) * 180 / Math.PI;
                                double timeEnd_ = wedgeIncidentHeight / Math.Cos(rotateAngle_ * Math.PI / 180) / (wedge.transVeloc) * 2;
                                double timeuse_ = timeEnd_ - timeStart;
                                int n = (int)(timeuse_ / timeInterval);

                                double eAngle = rotateAngle_ - incidentrotateAngle_;
                                //double et = (r_ - Rstart_) / (wedge.transVeloc) - timeInterval * n;
                                double et = timeuse_ - timeInterval * n;

                                if (n < 0)
                                {
                                    int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                    onePagedataArray[dataIndex] = 255;
                                    onePagedataArray[dataIndex + 1] = 0;
                                    onePagedataArray[dataIndex + 2] = 0;
                                }
                                else
                                {
                                    if (et == 0.00 && eAngle == 0.00)
                                    {
                                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                        RGBImage.getRGB(ascandata[m][n], ref red, ref green, ref blue);
                                        onePagedataArray[dataIndex] = blue;
                                        onePagedataArray[dataIndex + 1] = green;
                                        onePagedataArray[dataIndex + 2] = red;
                                    }

                                    if (et != 0.00 && eAngle != 0.00)
                                    {
                                        double z1 = ascandata[m][n] * (1 - et / timeInterval) + ascandata[m][n + 1] * et / timeInterval;
                                        double z2 = ascandata[m + 1][n] * (1 - et / timeInterval) + ascandata[m + 1][n + 1] * et / timeInterval;
                                        double z = z1 * (1 - eAngle / singleAngle_) + z2 * eAngle / singleAngle_;
                                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                        RGBImage.getRGB(z, ref red, ref green, ref blue);
                                        onePagedataArray[dataIndex] = blue;
                                        onePagedataArray[dataIndex + 1] = green;
                                        onePagedataArray[dataIndex + 2] = red;
                                    }

                                    if (et == 0.00 && eAngle != 0.00)
                                    {
                                        double z = ascandata[m][n] * (1 - eAngle / singleAngle_) + ascandata[m + 1][n] * eAngle / singleAngle_;
                                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                        RGBImage.getRGB(z, ref red, ref green, ref blue);
                                        onePagedataArray[dataIndex] = blue;
                                        onePagedataArray[dataIndex + 1] = green;
                                        onePagedataArray[dataIndex + 2] = red;
                                    }

                                    if (et != 0.00 && eAngle == 0.00)
                                    {
                                        double z = ascandata[m][n] * (1 - et / timeInterval) + ascandata[m][n + 1] * et / timeInterval;
                                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                        RGBImage.getRGB(z, ref red, ref green, ref blue);
                                        onePagedataArray[dataIndex] = blue;
                                        onePagedataArray[dataIndex + 1] = green;
                                        onePagedataArray[dataIndex + 2] = red;
                                    }
                                }

                            }
                            else
                            {
                                int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                onePagedataArray[dataIndex] = 0;
                                onePagedataArray[dataIndex + 1] = 0;
                                onePagedataArray[dataIndex + 2] = 0;
                            }
                        }
                        else
                        {
                            double x = bmpx + x0;
                            double y = bmpy + y0;

                            double x_ = bmpx + x0_;
                            double y_ = bmpy + y0_;

                            double r = Math.Sqrt(x * x + y * y);
                            double rotateAngle = Math.Atan(x / y) * 180 / Math.PI;
                            double rotateAngleJudge = 90 - rotateAngle;

                            if (((r > Rstart) && (r < Rend)) && ((rotateAngleJudge >= 90 - endAngle) && (rotateAngleJudge <= 90 - startAngle)))
                            {
                                //double pointtostartWidth = GetrefractPoint(endtostartWidth, x0, y0, x0_, y0_, ystart, pcw, x, y);
                                double pointtostartWidth = refractPoint[i][j];
                                double pointx = x0 + pointtostartWidth;
                                double pointy = y0 + ystart + 2;
                                double pointx_ = x0_ + pointtostartWidth;
                                double pointy_ = y0_ + ystart + 2;
                                double incidentroteAngle = Math.Atan(pointx_ / pointy_) / Math.PI * 180;
                                double refractroteAngle = Math.Asin(Math.Sin(incidentroteAngle * Math.PI / 180) * groove.transVeloc / wedge.transVeloc) / Math.PI * 180;
                                double timeuse1 = wedgeIncidentHeight / Math.Cos(incidentroteAngle * Math.PI / 180) / (wedge.transVeloc);
                                double timeuse2 = Math.Sqrt((x - pointx) * (x - pointx) + (y - pointy) * (y - pointy)) / (groove.transVeloc);
                                double timeuse = (timeuse1 + timeuse2) * 2 - timeStart;

                                int m = (int)((refractroteAngle - startAngle) / singleAngle);
                                int n = (int)(timeuse / timeInterval);
                                double eAngle = refractroteAngle - (int)refractroteAngle;
                                double et = timeuse - timeInterval * n;

                                if (n > 511 || n < 0)
                                {
                                    int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                    onePagedataArray[dataIndex] = 255;
                                    onePagedataArray[dataIndex + 1] = 0;
                                    onePagedataArray[dataIndex + 2] = 0;
                                }
                                else
                                {
                                    if (et == 0.00 && eAngle == 0.00)
                                    {
                                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                        RGBImage.getRGB(ascandata[m][n], ref red, ref green, ref blue);
                                        onePagedataArray[dataIndex] = blue;
                                        onePagedataArray[dataIndex + 1] = green;
                                        onePagedataArray[dataIndex + 2] = red;
                                    }

                                    if (et != 0.00 && eAngle != 0.00)
                                    {
                                        if (n == 511)
                                        {
                                            n = n - 1;
                                        }
                                        double z1 = ascandata[m][n] * (1 - et / timeInterval) + ascandata[m][n + 1] * et / timeInterval;
                                        double z2 = ascandata[m + 1][n] * (1 - et / timeInterval) + ascandata[m + 1][n + 1] * et / timeInterval;
                                        double z = z1 * (1 - eAngle / singleAngle) + z2 * eAngle / singleAngle;
                                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                        RGBImage.getRGB(z, ref red, ref green, ref blue);
                                        onePagedataArray[dataIndex] = blue;
                                        onePagedataArray[dataIndex + 1] = green;
                                        onePagedataArray[dataIndex + 2] = red;
                                    }

                                    if (et == 0.00 && eAngle != 0.00)
                                    {
                                        double z = ascandata[m][n] * (1 - eAngle / singleAngle) + ascandata[m + 1][n] * eAngle / singleAngle;
                                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                        RGBImage.getRGB(z, ref red, ref green, ref blue);
                                        onePagedataArray[dataIndex] = blue;
                                        onePagedataArray[dataIndex + 1] = green;
                                        onePagedataArray[dataIndex + 2] = red;
                                    }

                                    if (et != 0.00 && eAngle == 0.00)
                                    {
                                        if (n == 511)
                                        {
                                            n = n - 1;
                                        }
                                        double z = ascandata[m][n] * (1 - et / timeInterval) + ascandata[m][n + 1] * et / timeInterval;
                                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                        RGBImage.getRGB(z, ref red, ref green, ref blue);
                                        onePagedataArray[dataIndex] = blue;
                                        onePagedataArray[dataIndex + 1] = green;
                                        onePagedataArray[dataIndex + 2] = red;
                                    }
                                }
                            }
                            else
                            {
                                int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                                onePagedataArray[dataIndex] = 0;
                                onePagedataArray[dataIndex + 1] = 0;
                                onePagedataArray[dataIndex + 2] = 0;
                            }
                        }
                    }
                    else
                    {
                        int dataIndex = i * pictureBox2.Width * 3 + j * 3;
                        onePagedataArray[dataIndex] = 0;
                        onePagedataArray[dataIndex + 1] = 0;
                        onePagedataArray[dataIndex + 2] = 0;
                    }

                }
            }
        }

        private void updatePicture()
        {
            if (!pictureBox2.InvokeRequired)
            {
                if (imageForColor == null)
                    imageForColor = new Bitmap(pictureBox2.Width, pictureBox2.Height);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(onePagedataArray, 0, ptr, pictureBox2.Width * pictureBox2.Height * 3);
                imageForColor.UnlockBits(CanvasData);

                int vx0 = pcstart + (int)((wedgeIncidentHeight * (Math.Tan(incidentAngleEnd * Math.PI / 180) - Math.Tan(incidentAngleStart * Math.PI / 180)) + wedge.length - ((wedge.length - wedge.headLen) / Math.Cos(wedge.incidentAngle * Math.PI / 180) - (position.probePosition + probe.eleEdge + startItemIndex * probe.eleSpace + (itemNuM - startItemIndex) / 2 * probe.eleSpace)) * Math.Cos(wedge.incidentAngle * Math.PI / 180) - wedgeIncidentHeight * Math.Tan(incidentAngleEnd * Math.PI / 180)) / bmpWidthSector);
                int vy0 = (int)((ystart + 2) / bmpHeightSector);
                int cycleNum = (int)(scanRange * Math.Cos(startAngle * Math.PI / 180) / grooveheight) + 1;
                for (int i = 1; i <= cycleNum; i++)
                {
                    if (i % 2 != 0)
                    {
                        if (groove.type == GrooveType.V)
                        {
                            DrawVGroove(groove, vx0, vy0, pictureBox2, ref imageForColor, bmpWidthSector, bmpHeightSector);
                        }
                        if (groove.type == GrooveType.CRC)
                        {
                            DrawCRCGroove(groove, vx0, vy0, pictureBox2, ref imageForColor, bmpWidthSector, bmpHeightSector);
                        }
                        if (groove.type == GrooveType.X)
                        {
                            DrawXGroove(groove, vx0, vy0, pictureBox2, ref imageForColor, bmpWidthSector, bmpHeightSector);
                        }
                        
                    }
                    else
                    {
                        if (groove.type == GrooveType.V)
                        {
                            DrawVGroovemirror(groove, vx0, vy0, pictureBox2, ref imageForColor, bmpWidthSector, bmpHeightSector);
                        }
                        if (groove.type == GrooveType.CRC)
                        {
                            DrawCRCGroovemirror(groove, vx0, vy0, pictureBox2, ref imageForColor, bmpWidthSector, bmpHeightSector);
                        }
                        if (groove.type == GrooveType.X)
                        {
                            DrawXGroove(groove, vx0, vy0, pictureBox2, ref imageForColor, bmpWidthSector, bmpHeightSector);
                        }
                        
                    }
                    vy0 = vy0 + (int)(grooveheight / bmpHeightSector);
                }

                pictureBox2.Image = imageForColor;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                pictureBox2.Invoke(updatePictureFunc);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateAscans();
        }

        public void SetGainandDelay()
        {
            if (isStart)
            {
                int error_code;
                sessionIfo = FormList.mySessionsListForm.sessionsAttrs;

                for (int i = 0; i < sessionIfo.Count; i++)
                {
                    SelectAscan.sessionIndex = (uint)sessionIfo[i].sessionIndex;
                    SelectAscan.userIndex = (uint)sessionIfo[i].userIndex;
                    SelectAscan.port = (uint)sessionIfo[i].port;

                    if (SetBatchDAQ.isOn)
                    {
                        SetBatchDAQ.AnalogGain(SelectAscan.sessionIndex, gain);
                        error_code = SetBatchDAQ.Delay(SelectAscan.sessionIndex, timeStart);
                        error_code = SetBatchDAQ.Range(SelectAscan.sessionIndex, timeEnd);
                    }
                    else
                    {
                        SetReceiverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, gain);
                        error_code = SetAscanVideoDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, timeStart);
                        error_code = SetAscanVideoDAQ.Range(SelectAscan.sessionIndex, SelectAscan.port, timeEnd);
                    }
                }
            }
        }

        
       
    }

    public class SBeamList
    {
        public string assignName;
        public double angle;
        public int skew;
        public double timeStart;
        public double timeSum;
        public ClassBeamFile beamfile;

        public SBeamList()
        {
            assignName = "";
            angle = 0.00;
            skew = 0;
            timeStart = 0;
            timeSum = 0;
            beamfile = new ClassBeamFile();
        }
    }
}
