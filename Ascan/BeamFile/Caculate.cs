using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class Caculate
    {
        private const int SAMPLES = 1024;
        //Fermat caculate the interfacepoint;
        public static float Pathtime(float xe, float ye, float xt, float yt, float c1, float c2)
        {
            float xmin = 0;
            float xi = 0;
            float l1 = 0;
            float l2 = 0;
            float t1 = 0;
            float t2 = 0;
            float step = 0;
            int i = 0;
            int j = 0;
            float[] t = new float[SAMPLES];

            step = Math.Abs(xe - xt) / SAMPLES;
            if (xe < xt)
            {
                xmin = xe;
            }
            else
            {
                xmin = xt;
            }
            for (i = 0; i < SAMPLES; i++)
            {
                xi = xmin + i * step;
                l1 = (float)Math.Sqrt(Math.Pow((xe - xi), 2) + Math.Pow(ye, 2));
                l2 = (float)Math.Sqrt(Math.Pow((xt - xi), 2) + Math.Pow(yt, 2));
                t1 = l1 / c1;
                t2 = l2 / c2;
                t[i] = t1 + t2;
            }
            float m = t.Min();
            j = Array.IndexOf(t, m);
            xi = xmin + step * j;
            return m;
        }

        public static DrawPoint Reflect(float defectX, float defectY, float height, float angle)
        {
            DrawPoint point = new DrawPoint();
            float xc = 0;
            float yc = 0;
            float xi = 0;
            float xr = 0;
            float radioangle = 0;

            radioangle = TurntoRadian(angle);
            xc = defectX;
            yc = 2 * height - defectY;
            xi = (float)(xc + yc * Math.Tan(radioangle));
            xr = (float)(xc + (yc - height) * Math.Tan(radioangle));

            point.x[0] = defectX;
            point.y[0] = defectY;
            point.x[1] = xr;
            point.y[1] = height;
            point.x[2] = xi;
            point.y[2] = 0;
            point.count = 3;

            return point;
        }

        public static float Reflectpoint(float defectX, float defectY, float height, float angle)
        {
            float xc = 0;
            float yc = 0;
            float xi = 0;
            float radioangle = 0;

            radioangle = TurntoRadian(angle);
            xc = defectX;
            yc = 2 * height - defectY;
            xi = (float)(xc + yc * Math.Tan(radioangle));
            return xi;
        }
        

        public static float TurntoRadian(float degree)
        {
            float radian;
            radian = (float)(degree * Math.PI / 180f);
            return radian;
        }

        public static int Centerelement(float xi, wedge Wedge, probe Probe, position Position,testBlock testblock)
        {
            float xw = 0;    
            float yw = 0;
            float xc = 0;    //c path cross probe
            float yc = 0;
            float k1 = 0;
            float k2 = 0;
            float[] tmp = new float[Probe.NumOfExcitation];
            int i = 0;
            float probeangle = 0;
            float reflectangle = 0;
            float sina = 0;
            int eleindex = 0;

            probeangle = TurntoRadian(Wedge.WedgeAngle);
            reflectangle = TurntoRadian(testblock.VAngle);
            sina = (float)(Wedge.WedgeVelocity / testblock.TestBlockVelocity * Math.Sin(reflectangle));
            k1 = (float)(Math.Tan(probeangle));
            k2 = (float)(-1 * (Math.Sqrt(1 - Math.Pow(sina, 2))) /sina);
            xw = (float)(Position.WedgePosition + (testblock.BlockHeight - testblock.BottomLength) / Math.Tan(reflectangle));
            yw = -Wedge.WedgeLeftHeight;
            xc = (k1 * xw - yw - k2 * xi) / (k1 - k2);
            yc = k2 * (xc - xi);
            for (i = 0; i < Probe.NumOfExcitation; i++)
            {
                tmp[i] = (float)Math.Abs(xc-(xw + (Position.ProbePosition + Probe.FirstDistance + i*Probe.ElementaryInterSpace)*Math.Cos(probeangle)));
            }
            float m = tmp.Min();
            eleindex = Array.IndexOf(tmp, m);
            return eleindex;
        }

        public static ClassBeamFile Dealytime(float xd, float yd, int centerele, wedge Wedge, probe Probe, position Position, testBlock testblock)
        {
            ClassBeamFile beamfile = new ClassBeamFile();
            float xw = 0;
            float yw = 0;
            float xe = 0;
            float ye = 0;
            float tmax = 0;
            int i = 0;
            float[] time = new float[32]; 
            float probeangle = 0;
            float k = 0;
            int startele = 0;
            float reflectangle = 0;

            startele = centerele - 15;
            probeangle = TurntoRadian(Wedge.WedgeAngle);
            k = (float)(Math.Tan(probeangle));
            reflectangle = TurntoRadian(testblock.VAngle);
            xw = (float)(Position.WedgePosition + (testblock.BlockHeight - testblock.BottomLength) / Math.Tan(reflectangle));
            yw = -Wedge.WedgeLeftHeight;

            for (i = 0; i < 32; i++)
            {
                xe = (float)(xw + (Position.ProbePosition + Probe.FirstDistance + (i+startele)* Probe.ElementaryInterSpace) * Math.Cos(probeangle));
                ye = k * (xe - xw) + yw;
                time[i] = Pathtime(xe, ye, xd, 2 * testblock.BlockHeight - yd, Wedge.WedgeVelocity, testblock.TestBlockVelocity);
            }
            tmax = time.Max();

            for (i = 0; i < 32; i++)
            {
                beamfile.txDelay[i] = tmax - time[i];
                beamfile.rxDelay[i] = tmax - time[i];
            }
            beamfile.rxSize = 32;
            beamfile.txSize = 32;
            beamfile.txElementBin = beamfileinit(startele, 32);
            beamfile.rxElementBin = beamfileinit(startele, 32);
            return beamfile;
        }

        private static uint[] beamfileinit(int startele,int elenum)
        {
            uint[] bin = new uint[8];
            int i = 0;
            for (i = 0; i < elenum; i++)
            {
                bin[(i+startele)/32] |= (uint)(1<<(i + startele));
            }
            return bin;
        }
    }
}
