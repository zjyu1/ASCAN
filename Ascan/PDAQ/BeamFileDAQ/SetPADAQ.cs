using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class SetBeamFileDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int BeamFile(uint ascanNum, uint chn, StructBeamFile structBeam)
        {
            int error_code;
            uint attr = DaqAttrType.pA.BeamFormerFile;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, chn, attr, structBeam);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Beam File failed", "错误：设置Beam File失败");
            }
            return error_code;
        }

        public static int PeriodTimes(uint ascanNum, uint chn, uint num)
        {
            int error_code;
            uint attr = DaqAttrType.pA.SeqPeriodTimes;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, chn, attr, num);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Seq Period Times failed", "错误：设置Seq Period Times失败");
            }
            return error_code;
        }
    }
}
