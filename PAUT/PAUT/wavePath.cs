using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Steema.TeeChart.Styles;
using System.IO;

namespace PAUT
{
    public partial class WavePath : Form
    {
        public WavePath()
        {
            InitializeComponent();
        }

        #region 画试件的图
        public void drawTestBlock(PointF[] pathData,int Num)
        {
            int i;
            using (Polygon polygonToAdd = new Polygon(map1.Shapes, wavePathDisplay.Chart))
            {


                for (int j = 0; j < Num+1; j++)
                {
                    
                    polygonToAdd.Add(pathData.ElementAt<PointF>(j).X, pathData.ElementAt<PointF>(j).Y);

                }
               
                i = map1.Shapes.Add(polygonToAdd);
            }
            map1.Shapes[i].ParentBrush = false;
            map1.Shapes[i].Color = Color.Green;
            map1.Shapes[i].ParentPen = false;
            map1.Shapes[i].Pen.Visible = true;
            map1.Shapes[i].Pen.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            map1.Shapes[i].Pen.Width = 2;
            map1.Shapes[i].Pen.Color = Color.Black;
            map1.Shapes[i].Pen.Invalidate();

            wavePathDisplay.Axes.Left.Automatic = false;
            wavePathDisplay.Axes.Left.Maximum = 100;
            wavePathDisplay.Axes.Left.Minimum = 0;
            wavePathDisplay.Axes.Left.Increment = 1;
            wavePathDisplay.Axes.Bottom.Automatic = false;
            wavePathDisplay.Axes.Bottom.Maximum = 200;
            wavePathDisplay.Axes.Bottom.Minimum = 0;
            wavePathDisplay.Axes.Bottom.Increment = 1;

            wavePathDisplay.Header.Text = "中心振元波束路径图";
            wavePathDisplay.Aspect.View3D = false;
            wavePathDisplay.Panel.Gradient.Visible = true;

        }
        #endregion

        #region 画楔块的图
        public void drawWedge(PointF[] pathData,int Num,int endNum)
        {
            int i;
            using (Polygon polygonToAdd = new Polygon(map1.Shapes, wavePathDisplay.Chart))
            {


                for (int j = Num + 1; j < pathData.Length-endNum; j++)
                {

                    polygonToAdd.Add(pathData.ElementAt<PointF>(j).X, pathData.ElementAt<PointF>(j).Y);

                }

                i = map1.Shapes.Add(polygonToAdd);
            }
            map1.Shapes[i].ParentBrush = false;
            map1.Shapes[i].Color = Color.White;
            map1.Shapes[i].ParentPen = false;
            map1.Shapes[i].Pen.Visible = true;
            map1.Shapes[i].Pen.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            map1.Shapes[i].Pen.Width = 2;
            map1.Shapes[i].Pen.Color = Color.Black;
            map1.Shapes[i].Pen.Invalidate();

            //wavePathDisplay.Axes.Left.Automatic = false;
            //wavePathDisplay.Axes.Left.Maximum = 100;
            //wavePathDisplay.Axes.Left.Minimum = 0;
            //wavePathDisplay.Axes.Left.Increment = 1;
            //wavePathDisplay.Axes.Bottom.Automatic = false;
            //wavePathDisplay.Axes.Bottom.Maximum = 200;
            //wavePathDisplay.Axes.Bottom.Minimum = 0;
            //wavePathDisplay.Axes.Bottom.Increment = 1;
        }
        #endregion

        #region 垂直部分的声束路径图
        public void drawVerticalPathPoint(List<PointF> pathData)
        {
            int shift = 0;
            int focusNum = (pathData.Count+1) / 3;

            for (int i = 0; i < focusNum; i++)
            {
                FastLine Vpath = new FastLine();
                Vpath.Color = Color.Black;
                Vpath.Add(pathData.ElementAt<PointF>(shift));
                Vpath.Add(pathData.ElementAt<PointF>((shift + 1)));
                Vpath.Add(pathData.ElementAt<PointF>((shift + 2)));
                wavePathDisplay.Series.Add(Vpath);

                shift += 3;
            }
        }
        #endregion

        #region 倾斜部分的声束路径图
        public void drawObliquePathPoint(List<PointF> pathData)
        {
            int shift = 0;
            int focusNum = (pathData.Count + 1) / 4;

            for (int i = 0; i < focusNum; i++)
            {
                FastLine Vpath = new FastLine();
                Vpath.Color = Color.Black;
                Vpath.Add(pathData.ElementAt<PointF>(shift));
                Vpath.Add(pathData.ElementAt<PointF>((shift + 1)));
                Vpath.Add(pathData.ElementAt<PointF>((shift + 2)));
                Vpath.Add(pathData.ElementAt<PointF>((shift + 3)));
                wavePathDisplay.Series.Add(Vpath);
                shift += 4;
            }
        }
        #endregion


        public void draw(PointF[] pathData,int shiftIndex)
        {
            int i=0;
            for (int k = 0; k < pathData.Length; k++)
            {
                if (k % shiftIndex == 0)
                {
                    using (Polygon polygonToAdd = new Polygon(map1.Shapes, wavePathDisplay.Chart))
                    {
                        for (int j = k; j < k + shiftIndex; j++)
                        {
                            polygonToAdd.Add(pathData.ElementAt<PointF>(j).X, pathData.ElementAt<PointF>(j).Y);

                        }
                        i = map1.Shapes.Add(polygonToAdd);
                    }
                }
            }
            map1.Shapes[i].ParentBrush = false;
            map1.Shapes[i].Color = Color.Transparent;
            map1.Shapes[i].ParentPen = false;
            map1.Shapes[i].Pen.Visible = true;
            map1.Shapes[i].Pen.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            map1.Shapes[i].Pen.Width = 2;
            map1.Shapes[i].Pen.Color = Color.Black;
            map1.Shapes[i].Pen.Invalidate();

            wavePathDisplay.Axes.Left.Automatic = false;
            wavePathDisplay.Axes.Left.Maximum = 55;
            wavePathDisplay.Axes.Left.Minimum = 0;
            wavePathDisplay.Axes.Left.Increment = 1;
            wavePathDisplay.Axes.Bottom.Automatic = false;
            wavePathDisplay.Axes.Bottom.Maximum = 100;
            wavePathDisplay.Axes.Bottom.Minimum = 0;
            wavePathDisplay.Axes.Bottom.Increment = 1;
        }
    }
}
