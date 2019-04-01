using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class SetDACDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Active(uint ascanNum, uint ascanPort, DACActive active)
        {
            int error_code;
            uint attr = DaqAttrType.dac.Active;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set DAC active failed", "错误：设置DAC active失败");
            }
            return error_code;
        }

        public static int Mode(uint ascanNum, uint ascanPort, DACMode mode)
        {
            int error_code;
            uint attr = DaqAttrType.dac.Mode;
            uint val = (uint)mode;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set DAC mode failed", "错误：设置DAC mode失败");
            }
            return error_code;
        }

        public static int Point(uint ascanNum, uint ascanPort, uint point)
        {
            int error_code;
            uint attr = DaqAttrType.dac.Point;
            uint val = point;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set DAC point failed", "错误：设置DAC point失败");
            }
            return error_code;
        }

        public static int DACFile(uint ascanNum, uint ascanPort, DACParas dacParas)
        {
            int error_code;
            uint attr = DaqAttrType.dac.File;
            DACParas val = dacParas;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set DAC file failed", "错误：设置DAC file失败");
            }
            return error_code;  
        }
    }
}
