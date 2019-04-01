using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class GetDACDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Active(uint ascanNum, uint ascanPort, ref DACActive active)
        {
            int error_code;
            uint attr = DaqAttrType.dac.Active;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get DAC active failed", "错误：获得DAC active失败");
            }
            active = (DACActive)val;
            return error_code;
        }

        public static int Mode(uint ascanNum, uint ascanPort, ref DACMode mode)
        {
            int error_code;
            uint attr = DaqAttrType.dac.Mode;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get DAC mode failed", "错误：获得DAC mode失败");
            }
            mode = (DACMode)val;
            return error_code;
        }

        public static int Point(uint ascanNum, uint ascanPort, ref uint point)
        {
            int error_code;
            uint attr = DaqAttrType.dac.Point;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get DAC point failed", "错误：获得DAC point失败");
            }
            point = val;
            return error_code;
        }

        public static int DACFile(uint ascanNum, uint ascanPort, ref DACParas dacParas)
        {
            int error_code;
            uint attr = DaqAttrType.dac.File;
            DACParas val = new DACParas();

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref dacParas);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get DAC file failed", "错误：获得DAC file失败");
            }
            dacParas = val;
            return error_code;
        }
    }
}
