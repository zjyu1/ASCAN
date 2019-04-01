using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Ascan
{
    public class BeamPara
    {
        private const int SAMPLES = 1024;
        private const int OTHERPROBE = 64;
        private const int BEAMREGISTER = 32;

        public double index;
        public double pathtime;
        public int[] centerele = new int[2];
        public ClassBeamFile beamfile;
        public ArrowPoint[] arrowpoint = new ArrowPoint[2];
        public LinePoint[] linepoint = new LinePoint[2];
        public LinePoint gatepoint = new LinePoint();
        public double gatebefore = 0;
        private Groove groove = new Groove();
        private UltraWedge wedge = new UltraWedge();
        private UltraProbe probe = new UltraProbe();
        private UTPosition position = new UTPosition();
        private GateInformation gate;
        private double xd;
        private double yd;
        private double grooveheight = 0;
        private int skewflag;
        private int[] activele = new int[2];

        private double[] maxtime = new double[2];

        public BeamPara(ClassChanpara chanpara, Groove gro, UltraWedge wed, UltraProbe pro, UTPosition pos, GateInformation gate)
        {
            this.gate = gate;
            xd = chanpara.defectX;
            yd = chanpara.defectY;
            groove = gro;
            wedge = wed;
            probe = pro;
            position = pos;
            grooveheight = groove.height.Sum();

            skewflag = GetSkewflag(chanpara.skew);
            if (chanpara.method == (int)PathMethod.Direct)
            {
                activele[0] = chanpara.activenb[0];

                linepoint[0] = Direct(xd, yd, chanpara.interfaceAngle[0]);
                index = linepoint[0].x[1];
                centerele[0] = Centerelement(index, chanpara.interfaceAngle[0], activele[0]);
            }
            else if (chanpara.method == (int)PathMethod.Reflect)
            {
                activele[0] = chanpara.activenb[0];

                linepoint[0] = Reflect(xd, yd, chanpara.interfaceAngle[0]);
                index = linepoint[0].x[2];
                centerele[0] = Centerelement(index, chanpara.interfaceAngle[0], activele[0]);
            }
            else if (chanpara.method == (int)PathMethod.Series)
            {
                activele[0] = chanpara.activenb[0];
                activele[1] = chanpara.activenb[1];

                linepoint[0] = Reflect(xd, yd, chanpara.interfaceAngle[0]);
                index = linepoint[0].x[2];
                centerele[0] = Centerelement(index, chanpara.interfaceAngle[0], activele[0]);

                linepoint[1] = DoubleReflect(xd, yd, chanpara.interfaceAngle[1]);
                index = linepoint[1].x[3];
                centerele[1] = Centerelement(index, chanpara.interfaceAngle[1], activele[1]);
            }
            CaculateFocuspoint();
            beamfile = GetBeamfile(xd, yd, centerele, chanpara.interfaceAngle, chanpara.method);
            arrowpoint = GetArrow(linepoint, chanpara.method);
            GetPathtime(chanpara.method);
        }

        /**Get FocusPoint.*/
        private void CaculateFocuspoint()
        {
            double xbefore = 0;
            double ybefore = 0;
            double xafter = 0;
            double yafter = 0;
            double xzero = 0;
            double yzero = 0;
            double xa = linepoint[0].x[0];
            double ya = linepoint[0].y[0];
            double xb = linepoint[0].x[1];
            double yb = linepoint[0].y[1];
            double k = (ya - yb) / (xa - xb);
            double cosa = 1/(Math.Sqrt(1 + Math.Pow(k,2)));

            xbefore = xd + gate.gatebefore * cosa;
            ybefore = k*(xbefore - xa) + ya;
            if (gate.mode == GateMode.target)
            {
                xafter = xd - gate.gatebefore * cosa;
                yafter = k * (xafter - xa) + ya;
            }
            else
            {
                xzero = 0;
                yzero = k * (xzero - xa) + ya;
                xafter = xzero - gate.gatebefore * cosa;
                yafter = k * (xafter - xa) + ya;
            }

            linepoint[0].x[0] = xbefore;
            linepoint[0].y[0] = ybefore;

            xd = (xbefore + xafter) / 2;
            yd = (ybefore + yafter) / 2;

            if (yafter < 0)
            {
                double xtmp = 0;
                double ytmp = 0;
                xtmp = (xa - ya / k);
                yafter = -yafter;
                gatepoint.x[0] = xafter;
                gatepoint.y[0] = yafter;
                gatepoint.x[1] = xtmp;
                gatepoint.y[1] = ytmp;
                gatepoint.x[2] = xbefore;
                gatepoint.y[2] = ybefore;
                gatepoint.count = 3;
            }
            else if (yafter > grooveheight)
            {
                double xtmp = 0;
                double ytmp = 0;
                xtmp = (grooveheight - ya) / k + xa;
                ytmp = grooveheight;
                yafter = 2 * grooveheight - yafter;
                gatepoint.x[0] = xafter;
                gatepoint.y[0] = yafter;
                gatepoint.x[1] = xtmp;
                gatepoint.y[1] = ytmp;
                gatepoint.x[2] = xbefore;
                gatepoint.y[2] = ybefore;
                gatepoint.count = 3;
            }
            else
            {
                gatepoint.x[0] = xafter;
                gatepoint.y[0] = yafter;
                gatepoint.x[1] = xbefore;
                gatepoint.y[1] = ybefore;
                gatepoint.count = 2;
            }

            gatebefore = 2 * Math.Abs(xd - xbefore) /cosa/ groove.transVeloc;
        }



        /**Get Pathtime.*/
        private void GetPathtime(int method)
        {
            if (method == (int)PathMethod.Series)
            {
                pathtime = maxtime[0] + maxtime[1];
            }
            else
            {
                pathtime = 2 * (maxtime[0]);
            }
        }

        /**Get skewflag for judging which side probe.*/
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

        /**Fermat caculate the interfacepoint.*/
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

        /**Twice reflect pathpoint.*/
        public LinePoint DoubleReflect(double defectX, double defectY, double angle)
        {
            LinePoint point = new LinePoint();
            double xc = 0;
            double yc = 0;
            double xi = 0;
            double xrf = 0;   //floor reflect point x 
            double xrg = 0;   //gound reflect point x
            double radioangle = 0;

            radioangle = TurntoRadian(angle);
            xc = defectX;
            yc = defectY;
            xrf = xc + yc * Math.Tan(radioangle);
            xrg = xrf + grooveheight * Math.Tan(radioangle);
            xi = 2 * xrg - xrf;

            point.x[0] = defectX;
            point.y[0] = defectY;
            point.x[1] = xrf;
            point.y[1] = 0;
            point.x[2] = xrg;
            point.y[2] = grooveheight;
            point.x[3] = xi;
            point.y[3] = 0;
            point.count = 4;

            return point;
        }

        /**Reflect pathpoint.*/
        public LinePoint Reflect(double defectX, double defectY, double angle)
        {
            LinePoint point = new LinePoint();
            double xi = 0;
            double xr = 0;
            double radioangle = 0;

            radioangle = TurntoRadian(angle);
            xr = (defectX + (grooveheight - defectY) * Math.Tan(radioangle));
            xi = xr + grooveheight * Math.Tan(radioangle);

            point.x[0] = defectX;
            point.y[0] = defectY;
            point.x[1] = xr;
            point.y[1] = grooveheight;
            point.x[2] = xi;
            point.y[2] = 0;
            point.count = 3;

            return point;
        }

        /**Direct pathpoint.*/
        public LinePoint Direct(double defectX, double defectY, double angle)
        {
            LinePoint point = new LinePoint();
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

        /**Getarrowpoint.*/
        public ArrowPoint[] GetArrow(LinePoint[] Linepoint,int method)
        {
            ArrowPoint[] point = new ArrowPoint[2];
            point[0] = new ArrowPoint();
            point[1] = new ArrowPoint();
            if (method == (int)PathMethod.Direct)
            {
                point[0].xd = Linepoint[0].x[0];
                point[0].yd = Linepoint[0].y[0];
                point[0].xs = Linepoint[0].x[1];
                point[0].ys = Linepoint[0].y[1];
            }
            else if (method == (int)PathMethod.Reflect)
            {
                point[0].xd = Linepoint[0].x[0];
                point[0].yd = Linepoint[0].y[0];
                point[0].xs = Linepoint[0].x[1];
                point[0].ys = Linepoint[0].y[1];
            }
            else if (method == (int)PathMethod.Series)
            {
                point[0].xd = Linepoint[0].x[0];
                point[0].yd = Linepoint[0].y[0];
                point[0].xs = Linepoint[0].x[1];
                point[0].ys = Linepoint[0].y[1];

                point[1].xd = Linepoint[1].x[2];
                point[1].yd = Linepoint[1].y[2];
                point[1].xs = Linepoint[1].x[1];
                point[1].ys = Linepoint[1].y[1];
            }
            return point;
        }

        /**Caculate the center element.*/
        public int Centerelement(double xi, double angle,int elenum)
        {
            double xw = 0;
            double yw = 0;
            double k1 = 0;
            double k2 = 0;
            double xc = 0;    //c path cross probe
            double yc = 0;
            double[] tmp = new double[probe.eleNum];
            int i = 0;
            double probeangle = 0;
            double reflectangle = 0;
            double sina = 0;
            int eleindex = 0;

            probeangle = TurntoRadian(wedge.incidentAngle);
            reflectangle = TurntoRadian(angle);
            sina = (wedge.transVeloc / groove.transVeloc * Math.Sin(reflectangle));
            k1 = (Math.Tan(probeangle));
            k2 = (-1 * (Math.Sqrt(1 - Math.Pow(sina, 2))) /sina);
            xw = (position.wedgePosition + (groove.height[0]) / Math.Tan(reflectangle));
            yw = -wedge.height;
            xc = (k1 * xw - yw - k2 * xi) / (k1 - k2);
            yc = k2 * (xc - xi);
            for (i = 0; i < probe.eleNum; i++)
            {
                tmp[i] = Math.Abs(xc-(xw + (position.probePosition + probe.eleEdge + i*probe.eleSpace)*Math.Cos(probeangle)));
            }
            double m = tmp.Min();
            eleindex = Array.IndexOf(tmp, m);
            if ((eleindex - elenum / 2 - 1) < 0)
            {
                eleindex = elenum / 2;
            }
            else if ((eleindex + elenum / 2) > (OTHERPROBE - 1))
            {
                eleindex = OTHERPROBE - elenum / 2;
            }
            return eleindex;
        }

        /**Get Distance.*/
        public double Distance(LinePoint point)
        {
            int i = 0;
            double distance = 0;
            for (i = 0; i < point.count - 1; i++)
            {
                distance += Math.Sqrt(Math.Pow((point.x[i] - point.x[i + 1]), 2) + Math.Pow((point.y[i] - point.y[i + 1]), 2));
            }
            return distance;
        }

        /**Get Beamfile.*/
        public ClassBeamFile GetBeamfile(double defectX, double defectY, int[] centerele, double[] angle ,int method)
        {
            double xd = 0;
            double yd = 0;
            int startele =0;
            ClassBeamFile beam = new ClassBeamFile();
            if (method == (int)PathMethod.Direct)
            {
                xd = defectX;
                yd = defectY;
                startele = centerele[0] - activele[0] / 2 + 1;
                beam.txDelay = GetDelay(xd, yd, startele, angle[0],0);
                beam.rxDelay = beam.txDelay;
                beam.txSize = (uint)activele[0];
                beam.rxSize = beam.txSize;
                beam.txElementBin = GetBeambin(startele, activele[0], skewflag);
                beam.rxElementBin = beam.txElementBin;
            }
            else if (method == (int)PathMethod.Reflect)
            {
                xd = defectX;
                yd = 2 * grooveheight - defectY;
                startele = centerele[0] - activele[0] / 2 + 1;
                beam.txDelay = GetDelay(xd, yd, startele, angle[0], 0);
                beam.rxDelay = beam.txDelay;
                beam.txSize = (uint)activele[0];
                beam.rxSize = beam.txSize;
                beam.txElementBin = GetBeambin(startele, activele[0], skewflag);
                beam.rxElementBin = beam.txElementBin;
            }
            else if (method == (int)PathMethod.Series)
            {
                xd = defectX;
                yd = 2 * grooveheight - defectY;
                startele = centerele[0] - activele[0] / 2 + 1;
                beam.txDelay = GetDelay(xd, yd, startele, angle[0], 0);
                beam.txSize = (uint)activele[0];
                beam.txElementBin = GetBeambin(startele, activele[0], skewflag);

                yd = 2 * grooveheight + defectY;
                startele = centerele[1] - activele[1] / 2 + 1;
                beam.rxDelay = GetDelay(xd, yd, startele, angle[1], 1);
                beam.rxSize = (uint)activele[1];
                beam.rxElementBin = GetBeambin(startele, activele[1], skewflag);
            }               
            return beam;
        }

        /**Get Delaytime.*/
        public float[] GetDelay(double xd,double yd,int startele, double angle,int txrx)
        {
            float[] delay = new float[activele[txrx]];
            double xw = 0;
            double yw = 0;
            double xe = 0;
            double ye = 0;
            double tmax = 0;
            int i = 0;
            double[] time = new double[activele[txrx]];
            double probeangle = 0;
            double k = 0;
            double reflectangle = 0;

            probeangle = TurntoRadian(wedge.incidentAngle);
            reflectangle = TurntoRadian(angle);
            xw = (position.wedgePosition + (groove.height[0]) / Math.Tan(reflectangle));
            yw = -wedge.height;
            k = (Math.Tan(probeangle));

            for (i = 0; i < activele[txrx]; i++)
            {
                xe = (xw + (position.probePosition + probe.eleEdge + (i+startele) * probe.eleSpace) * Math.Cos(probeangle));
                ye = k * (xe - xw) + yw;
                time[i] = Pathtime(xe, ye, xd, yd, wedge.transVeloc, groove.transVeloc);
            }
            tmax = time.Max();
            maxtime[txrx] = tmax;
            for (i = 0; i < activele[txrx]; i++)
            {
                delay[i] = (float)(tmax - time[i]);
            }
            return delay;
        }

        /**Get BeamBin.*/
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

        /**Turn Degree to Radian.*/
        public static double TurntoRadian(double degree)
        {
            double radian;
            radian = (degree * Math.PI / 180f);
            return radian;
        }
    }
}
