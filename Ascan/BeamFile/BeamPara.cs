using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class BeamPara
    {
        private const int SAMPLES = 1024;
        private const int OTHERPROBE = 64;
        private const int BEAMREGISTER = 32;

        public double index;
        public int centerele;
        public ClassBeamFile beamfile;
        public DrawPoint point;
        private testBlock testblock = new testBlock();
        private wedge Wedge;
        private probe Probe;
        private position Position;
        private int skewflag;
        private int activele;

        public BeamPara(ClassChanpara chanpara,testBlock block,wedge wed,probe pro, position pos)
        {
            double xd = 0;
            double yd = 0;
            testblock = block;
            Wedge = wed;
            Probe = pro;
            Position = pos;

            activele = chanpara.activenb[0];
            skewflag = GetSkewflag(chanpara.skew);
            if (chanpara.method == 0)
            {
                xd = chanpara.defectX;
                yd = chanpara.defectY;
                point = Direct(xd, yd, chanpara.interfaceAngle[0]);
                index = point.x[1];
            }
            else if (chanpara.method == 1)
            {
                xd = chanpara.defectX;
                yd = 2 * testblock.BlockHeight - chanpara.defectY;
                point = Reflect(chanpara.defectX, chanpara.defectY, chanpara.interfaceAngle[0]);
                index = point.x[2];
            }
            
            centerele = Centerelement(index,chanpara.interfaceAngle[0]);
            beamfile = Dealytime(xd, yd, centerele,chanpara.interfaceAngle[0]);
        }

        private int GetSkewflag(int skew)
        {
            if (skew == 90)
            {
                skewflag = 0;
            }
            else if (skew == 270)
            {
                skewflag = 1;
            }
            return skewflag;
        }
        //Fermat caculate the interfacepoint;
        public double Pathtime(double xe, double ye, double xt, double yt, double c1, double c2)
        {
            double xmin = 0;
            double xi = 0;
            double l1 = 0;
            double l2 = 0;
            double t1 = 0;
            double t2 = 0;
            double step = 0;
            int i = 0;
            int j = 0;
            double[] t = new double[SAMPLES];

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
                l1 = Math.Sqrt(Math.Pow((xe - xi), 2) + Math.Pow(ye, 2));
                l2 = Math.Sqrt(Math.Pow((xt - xi), 2) + Math.Pow(yt, 2));
                t1 = l1 / c1;
                t2 = l2 / c2;
                t[i] = t1 + t2;
            }
            double m = t.Min();
            j = Array.IndexOf(t, m);
            xi = xmin + step * j;
            return m;
        }

        public DrawPoint Reflect(double defectX, double defectY, double angle)
        {
            DrawPoint point = new DrawPoint();
            double xc = 0;
            double yc = 0;
            double xi = 0;
            double xr = 0;
            double radioangle = 0;

            radioangle = TurntoRadian(angle);
            xc = defectX;
            yc = 2 * testblock.BlockHeight- defectY;
            xi = (xc + yc * Math.Tan(radioangle));
            xr = (xc + (yc - testblock.BlockHeight) * Math.Tan(radioangle));

            point.x[0] = defectX;
            point.y[0] = defectY;
            point.x[1] = xr;
            point.y[1] = testblock.BlockHeight;
            point.x[2] = xi;
            point.y[2] = 0;
            point.count = 3;

            return point;
        }

        public DrawPoint Direct(double defectX, double defectY, double angle)
        {
            DrawPoint point = new DrawPoint();
            double xi = 0;
            double radioangle = 0;

            radioangle = TurntoRadian(angle);
            xi = defectX + defectY * Math.Tan(radioangle);

            point.x[0] = defectX;
            point.y[0] = defectY;
            point.x[1] = xi;
            point.y[1] = 0;
            point.count = 2;
            return point;
        }

        public static double TurntoRadian(double degree)
        {
            double radian;
            radian = (degree * Math.PI / 180f);
            return radian;
        }

        public int Centerelement(double xi, double angle)
        {
            double xw = 0;    
            double yw = 0;
            double xc = 0;    //c path cross probe
            double yc = 0;
            double k1 = 0;
            double k2 = 0;
            double[] tmp = new double[Probe.NumOfExcitation];
            int i = 0;
            double probeangle = 0;
            double reflectangle = 0;
            double sina = 0;
            int eleindex = 0;

            probeangle = TurntoRadian(Wedge.WedgeAngle);
            reflectangle = TurntoRadian(angle);
            sina = (Wedge.WedgeVelocity / testblock.TestBlockVelocity * Math.Sin(reflectangle));
            k1 = (Math.Tan(probeangle));
            k2 = (-1 * (Math.Sqrt(1 - Math.Pow(sina, 2))) /sina);
            xw = (Position.WedgePosition + (testblock.BlockHeight - testblock.BottomLength) / Math.Tan(reflectangle));
            yw = -Wedge.WedgeLeftHeight;
            xc = (k1 * xw - yw - k2 * xi) / (k1 - k2);
            yc = k2 * (xc - xi);
            for (i = 0; i < Probe.NumOfExcitation; i++)
            {
                tmp[i] = Math.Abs(xc-(xw + (Position.ProbePosition + Probe.FirstDistance + i*Probe.ElementaryPitch)*Math.Cos(probeangle)));
            }
            double m = tmp.Min();
            eleindex = Array.IndexOf(tmp, m);
            if ((eleindex - activele / 2 - 1) < 0)
            {
                eleindex = activele / 2;
            }
            else if ((eleindex + activele / 2) > (OTHERPROBE-1))
            {
                eleindex = OTHERPROBE - activele / 2;
            }
            return eleindex;
        }

        public ClassBeamFile Dealytime(double xd, double yd, int centerele,double angle)
        {
            ClassBeamFile beam = new ClassBeamFile();
            double xw = 0;
            double yw = 0;
            double xe = 0;
            double ye = 0;
            double tmax = 0;
            int i = 0;
            double[] time = new double[activele]; 
            double probeangle = 0;
            double k = 0;
            int startele = 0;
            double reflectangle = 0;

            startele =centerele - activele/2 - 1;

            probeangle = TurntoRadian(Wedge.WedgeAngle);
            k = (Math.Tan(probeangle));
            reflectangle = TurntoRadian(angle);
            xw = (Position.WedgePosition + (int)((testblock.BlockHeight - testblock.BottomLength) / Math.Tan(reflectangle)));
            yw = -Wedge.WedgeLeftHeight;

            for (i = 0; i < activele; i++)
            {
                xe = (xw + (Position.ProbePosition + Probe.FirstDistance + (i+startele)* Probe.ElementaryPitch) * Math.Cos(probeangle));
                ye = k * (xe - xw) + yw;
                time[i] = Pathtime(xe, ye, xd, yd, Wedge.WedgeVelocity, testblock.TestBlockVelocity);
            }
            tmax = time.Max();

            for (i = 0; i < activele; i++)
            {
                beam.txDelay[i] =(float) (tmax - time[i]);
                beam.rxDelay[i] =(float) (tmax - time[i]);
            }
            beam.rxSize = (uint)activele;
            beam.txSize = (uint)activele;
            beam.txElementBin = GetBeambin(startele, activele, skewflag);
            beam.rxElementBin = GetBeambin(startele, activele, skewflag);
            return beam;
        }

        public static uint[] GetBeambin(int startele,int elenum,int skewflag)
        {
            int ele = 0;
            uint[] bin = new uint[8];
            int i = 0;

            if (skewflag == 0)
            {
                ele = startele - 1;
            }
            else 
            {
                ele = startele + OTHERPROBE - 1;
            }
            for (i = 0; i < elenum; i++)
            {
                bin[(i + ele) / BEAMREGISTER] |= (uint)(1 << (i + ele));
            }
            return bin;
        }
    }
}
