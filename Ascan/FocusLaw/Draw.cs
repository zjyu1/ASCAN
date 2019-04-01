using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Steema.TeeChart;

namespace Ascan
{
    public class Draw
    {
        public static void DrawLine(LinePoint point, Color color, TChart chart)
        {
            int i = 0;
            Steema.TeeChart.Styles.Line Tmpline = new Steema.TeeChart.Styles.Line(chart.Chart);
            for (i = 0; i < point.count; i++)
            {
                Tmpline.Add(point.x[i], point.y[i]);
            }
            Tmpline.Color = color; //LineSeries bounding lines colour 
        }

        public static void DrawArrow(ArrowPoint point, Color color, TChart chart)
        {
            Steema.TeeChart.Styles.Arrow Tmparrow = new Steema.TeeChart.Styles.Arrow(chart.Chart);
            Tmparrow.Add(point.xs,point.ys);
            Tmparrow.EndXValues[0] = point.xd;
            Tmparrow.EndYValues[0] = point.yd;
            Tmparrow.Color = color;
        }
    }


    public class LinePoint
    {
        public double[] x;
        public double[] y;
        public int count;

        public LinePoint()
        {
            x = new double[16];
            y = new double[16];
            count = 0;
        }
    }

    public class ArrowPoint
    {
        public double xs;
        public double ys;
        public double xd;
        public double yd;
        public ArrowPoint()
        {
            xs = 0;
            ys = 0;
            xd = 0;
            yd = 0;
        }
    }
}
