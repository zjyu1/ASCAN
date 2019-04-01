using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class ClassCouple
    {
        private const int COUPLENUM = 16;
        
        public ClassBeamFile beamfile;
        private probe Probe;
        private wedge Wedge;

        public ClassCouple(probe pro,wedge wed,int startele)
        {
            Probe = pro;
            Wedge = wed;
            beamfile = CoupleDelay(startele);
        }

        private ClassBeamFile CoupleDelay(int startele)
        {
            ClassBeamFile beam = new ClassBeamFile();
            double angle = BeamPara.TurntoRadian(Wedge.WedgeAngle);
            int i =0;
            double delay = Math.Sin(angle) * Probe.ElementaryPitch / Wedge.WedgeVelocity;
            for (i = 0; i < COUPLENUM; i++)
            {
                beam.rxDelay[i] = (float)(i * delay);
                beam.txDelay[i] = (float)(i * delay);
            }
            beam.txSize = COUPLENUM;
            beam.rxSize = COUPLENUM;
            beam.txElementBin = BeamPara.GetBeambin(startele, COUPLENUM, 0);
            beam.rxElementBin = BeamPara.GetBeambin(startele, COUPLENUM, 0);
            return beam;
        }
    }
}
