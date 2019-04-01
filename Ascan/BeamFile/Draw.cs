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
        public static void testline(DrawPoint point, Color color, TChart chart)
        {
            int i = 0;
            Steema.TeeChart.Styles.Line Tmpline = new Steema.TeeChart.Styles.Line(chart.Chart);
            for (i = 0; i < point.count; i++)
            {
                Tmpline.Add(point.x[i], point.y[i]);
            }
            Tmpline.Color = color; //LineSeries bounding lines colour 
        }
    }

    public class DrawPoint
    {
        public double[] x;
        public double[] y;
        public int count;

        public DrawPoint()
        {
            x = new double[16];
            y = new double[16];
            count = 0;
        }
    }
}
