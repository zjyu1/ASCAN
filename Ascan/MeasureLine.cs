using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Steema.TeeChart;

namespace Ascan
{
    public class PicMeasureLine
    {
        public double start;
        public double length;
        Point tmp;

        int xvalue1;
        int yvalue1;
        int xvalue2;
        int yvalue2;

        double xMin;
        double xMax;
        double yMin;
        double yMax;

        ToolTip tip1;
        ToolTip tip2;
        Graphics g;
        public bool isMesure;

        public PicMeasureLine()
        {
            xvalue1 = 0;
            yvalue1 = 0;
            xvalue2 = 0;
            yvalue2 = 0;

            xMin = 0;
            xMax = 0;
            yMin = 0;
            yMax = 0;

            isMesure = false;
            tip1 = new ToolTip();
            tip2 = new ToolTip();
        }

        private void PaintLine(PictureBox pic, int x1, int y1, int x2, int y2)
        {
            g = pic.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            pic.Refresh();
            g.DrawRectangle(new Pen(Color.Red, 2), x1, y1, Math.Abs(x1 - x2), Math.Abs(y1 - y2));
            //g.DrawLine(new Pen(Color.Red, 2), x1, y1, x2, y2);
        }

        private void clearPic(PictureBox pic)
        {
            xvalue1 = 0;
            yvalue1 = 0;
            xvalue2 = 0;
            yvalue2 = 0;
            pic.Refresh();
        }



        private void Drawstring(PictureBox pic)
        {
            float Posx, Posy;
            int x, y;
            double xdistance, ydistance;
            Posx = xvalue1+(float)(Math.Abs(xvalue1 - xvalue2) ) / 2;
            Posy = (float)(yvalue1 + yvalue2) / 2;
            x = Math.Abs(xvalue1 - xvalue2);
            y = Math.Abs(yvalue1 - yvalue2);

            xdistance = (xMax - xMin) * (double)x / (double)pic.Width;
            ydistance = (yMax - yMin) * (double)y / (double)pic.Height;

            xdistance = Math.Round(xdistance,2);
            ydistance = Math.Round(ydistance,2);

            Font drawFont = new Font("Times New Roman", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Red);// Create point for upper-left corner of drawing.

            //g.DrawString(Convert.ToString(xdistance), drawFont, drawBrush, xvalue1, yvalue1 - 15);
            //g.DrawString(Convert.ToString(ydistance), drawFont, drawBrush, xvalue1, Posy);

            start = Math.Round(yvalue1 *(yMax - yMin) / (double)pic.Height,2);
            length = ydistance;
        }





        private void mouse_move(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                PaintLine(pic, xvalue1, yvalue1, e.X, e.Y);

            }
        }

        private void mouse_down(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            PictureBox pic = sender as PictureBox;
            //clearPic(pic);
            if (e.Button == MouseButtons.Left)
            {
                if (tip2 != null)
                {
                    tip2.Hide(pic);
                }
                //tip1.Show("X:" + e.X + ",Y:" + e.Y, pic, new Point(pic.Location.X + e.X, pic.Location.Y + e.Y));


                xvalue1 = e.X;
                yvalue1 = e.Y;
                tmp = LocationOnClient(pic);
            }
        }

        private Point LocationOnClient(Control c)
        {
            Point retval = new Point(0, 0);
            for (; c.Parent != null; c = c.Parent)
            {
                retval.Offset(c.Location);
            }
            return retval;
        }


        private void mouse_up(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int x, y;

            PictureBox pic = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;

                if (x < 0)
                    x = 0;
                if (x > pic.Width)
                    x = pic.Width;
                if (y < 0)
                    y = 0;
                if (y > pic.Height)
                    y = pic.Height;

                //tip2.Show("X:" + x + ",Y:" + y, pic, new Point(pic.Location.X + x, pic.Location.Y + y));
                xvalue2 = x;
                yvalue2 = y;
                PaintLine(pic, xvalue1, yvalue1, xvalue2, yvalue2);
                Drawstring(pic);
            }
        }


        public void MousePicInit(PictureBox picbox, bool ismesure)
        {
            if (ismesure)
            {
                picbox.MouseDown += new System.Windows.Forms.MouseEventHandler(mouse_down);
                picbox.MouseUp += new System.Windows.Forms.MouseEventHandler(mouse_up);
                picbox.MouseMove += new System.Windows.Forms.MouseEventHandler(mouse_move);
            }
            else
            {
                tip1.Hide(picbox);
                tip2.Hide(picbox);
                picbox.Refresh();

                picbox.MouseDown -= new System.Windows.Forms.MouseEventHandler(mouse_down);
                picbox.MouseUp -= new System.Windows.Forms.MouseEventHandler(mouse_up);
                picbox.MouseMove -= new System.Windows.Forms.MouseEventHandler(mouse_move);
            }

        }

        public void Getpara(TChart tchart, double posXmin, double posXmax, double posYmin, double posYmax)
        {
            
            xMin = posXmin;
            xMax = posXmax;
            yMin = posYmin;
            yMax = posYmax;

        }

    }

    public class TchartMeasureLine
    {
        public double start;
        public double length;
        int xvalue1;
        int yvalue1;
        int xvalue2;
        int yvalue2;

        double xMin;
        double xMax;
        double yMin;
        double yMax;
        double detaX;
        double detaY;

        ToolTip tip1;
        ToolTip tip2;
        Graphics g;
        public bool isMesure;

        public TchartMeasureLine()
        {
            xvalue1 = 0;
            yvalue1 = 0;
            xvalue2 = 0;
            yvalue2 = 0;

            xMin = 0;
            xMax = 0;
            yMin = 0;
            yMax = 0;

            detaX = 0;
            detaY = 0;

            isMesure = false;
            tip1 = new ToolTip();
            tip2 = new ToolTip();
        }

        private void PaintRec(TChart tchart, int x1, int y1, int x2, int y2)
        {
            g = tchart.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            tchart.Refresh();
            g.DrawRectangle(new Pen(Color.Red, 2), x1, y1, Math.Abs(x1 - x2), Math.Abs(y1 - y2));
            //g.DrawLine(new Pen(Color.Red, 2), x1, y1, x2, y2);
        }

        private void clearPic(TChart tchart)
        {
            xvalue1 = 0;
            yvalue1 = 0;
            xvalue2 = 0;
            yvalue2 = 0;
            tchart.Refresh();
        }



        private void Drawstring()
        {
            float Posx, Posy;
            int x, y;
            double xdistance, ydistance;
            Posx = (float)(xvalue1 + xvalue2) / 2;
            Posy = (float)(yvalue1 + yvalue2) / 2;
            x = Math.Abs(xvalue1 - xvalue2);
            y = Math.Abs(yvalue1 - yvalue2);

            xdistance = detaX * (double)x / (xMax-xMin);
            ydistance = detaY * (double)y / (yMax-yMin);

            xdistance = Math.Round(xdistance, 2);
            ydistance = Math.Round(ydistance, 2);

            Font drawFont = new Font("Times New Roman", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Red);// Create point for upper-left corner of drawing.

            //g.DrawString(Convert.ToString(xdistance), drawFont, drawBrush, Posx, yvalue1 - 15);
            //g.DrawString(Convert.ToString(ydistance), drawFont, drawBrush, xvalue2, Posy);

            start = Math.Round(yvalue1 * detaY / (yMax - yMin), 2);
            length = ydistance;

        }





        private void mouse_move(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TChart tchart = sender as TChart;
            if (e.Button == MouseButtons.Left)
            {
                PaintRec(tchart, xvalue1, yvalue1, e.X, e.Y);

            }
        }

        private void mouse_down(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            TChart tchart = sender as TChart;
            clearPic(tchart);
            if (e.Button == MouseButtons.Left)
            {
                /*if (tip2 != null)
                {
                    tip2.Hide(tchart);
                }*/
                //tip1.Show("X:" + e.X + ",Y:" + e.Y, pic, new Point(pic.Location.X + e.X, pic.Location.Y + e.Y));


                xvalue1 = e.X;
                yvalue1 = e.Y;
            }
        }

        private void mouse_up(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int x, y;

            TChart tchart = sender as TChart;
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;

                if (x < 0)
                    x = 0;
                if (x > tchart.Width)
                    x = tchart.Width;
                if (y < 0)
                    y = 0;
                if (y > tchart.Height)
                    y = tchart.Height;

                //tip2.Show("X:" + x + ",Y:" + y, pic, new Point(pic.Location.X + x, pic.Location.Y + y));
                xvalue2 = x;
                yvalue2 = y;
                PaintRec(tchart, xvalue1, yvalue1, xvalue2, yvalue2);
                Drawstring();
            }
        }


        public void MouseTchartInit(TChart tchart, bool ismesure)
        {
            if (ismesure)
            {
                tchart.MouseDown += new System.Windows.Forms.MouseEventHandler(mouse_down);
                tchart.MouseUp += new System.Windows.Forms.MouseEventHandler(mouse_up);
                tchart.MouseMove += new System.Windows.Forms.MouseEventHandler(mouse_move);
            }
            else
            {
                tip1.Hide(tchart);
                tip2.Hide(tchart);
                tchart.Refresh();

                tchart.MouseDown -= new System.Windows.Forms.MouseEventHandler(mouse_down);
                tchart.MouseUp -= new System.Windows.Forms.MouseEventHandler(mouse_up);
                tchart.MouseMove -= new System.Windows.Forms.MouseEventHandler(mouse_move);
            }

        }

        public void Getpara(TChart tchart, double posXmin, double posXmax, double posYmin, double posYmax)
        {

            xMin = tchart.Axes.Bottom.CalcPosValue(posXmin);
            xMax = tchart.Axes.Bottom.CalcPosValue(posXmax);
            yMin = tchart.Axes.Left.CalcPosValue(posYmin);
            yMax = tchart.Axes.Left.CalcPosValue(posYmax);
            detaX = posXmax - posXmin;
            detaY = posYmax - posYmin;
        }
    }
}
