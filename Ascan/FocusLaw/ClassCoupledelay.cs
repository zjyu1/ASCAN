using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class ClassCouple
    {
        private const int COUPLENUM = 16;

        public List<GateDelay> gatedelay = new List<GateDelay>();
        private GateDelay gatea = new GateDelay(GateType.A);
        private GateDelay gateb = new GateDelay(GateType.B);
        private GateDelay gatec = new GateDelay(GateType.C);
        private GateDelay gatei = new GateDelay(GateType.I);

        public ClassBeamFile beamfile;
        private double grooveheight;
        private UltraProbe probe;
        private UltraWedge wedge;
        private UTPosition position;
        private Groove groove;

        public ClassCouple(UltraProbe pro, UltraWedge wed, UTPosition pos ,Groove gro,int startele, int skewflag)
        {
            probe = pro;
            wedge = wed;
            groove = gro;
            position = pos;
            grooveheight = groove.height.Sum();
            beamfile = CoupleDelay(startele,skewflag);

        }

        private ClassBeamFile CoupleDelay(int startele,int skewflag)
        {
            double gatestart = 0;
            double gaterange = 0;
            double ys = 0;
            int i = 0;
            ClassBeamFile beam = new ClassBeamFile();
            double angle = BeamPara.TurntoRadian(wedge.incidentAngle);
            double delay = Math.Sin(angle) * probe.eleSpace / wedge.transVeloc;
            for (i = 0; i < COUPLENUM; i++)
            {
                beam.rxDelay[i] = (float)(i * delay);
                beam.txDelay[i] = (float)(i * delay);
            }
            beam.txSize = COUPLENUM;
            beam.rxSize = COUPLENUM;
            beam.txElementBin = BeamPara.GetBeambin(startele, COUPLENUM, skewflag);
            beam.rxElementBin = BeamPara.GetBeambin(startele, COUPLENUM, skewflag);

            ys = wedge.height - ((position.probePosition + probe.eleEdge + startele * probe.eleSpace)) * Math.Sin(angle);
            gatestart = 2* ys / Math.Cos(angle) / wedge.transVeloc;
            gaterange = grooveheight / groove.longVeloc * 2;
            gatei.delay = gatestart;
            gatei.range = gaterange;
            gatea.delay = gatei.delay + gaterange;
            gatea.range = gaterange;
            gateb.delay = gatea.delay + gaterange;
            gateb.range = gaterange;
            gatec.delay = gateb.delay + gaterange;
            gatec.range = gaterange;

            gatedelay.Add(gatei);
            gatedelay.Add(gatea);
            gatedelay.Add(gateb);
            gatedelay.Add(gatec);
            return beam;
        }
    }
}
