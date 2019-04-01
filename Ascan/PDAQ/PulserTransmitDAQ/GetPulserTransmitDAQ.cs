using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class GetPulserTransmitDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Active(uint ascanNum, uint ascanPort, ref PluserActive active)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Active;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Pulser transmit reciviever active failed", "错误：获得Pulser transmit reciviever active失败");
            }
            active = (PluserActive)val;
            return error_code;
        }

        public static int Delay(uint ascanNum, uint ascanPort, ref double delay)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Delay;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Pulser transmit reciviever delay failed", "错误：获得Pulser transmit reciviever delay失败");
            }
            delay = val;
            return error_code;
        }

        public static int Width(uint ascanNum, uint ascanPort, ref double width)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Width;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Pulser transmit reciviever width failed", "错误：获得Pulser transmit reciviever width失败");
            }
            width = val;
            return error_code;
        }

        public static int Intensity(uint ascanNum, uint ascanPort, ref double intensity)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Intensity;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Pulser transmit reciviever intensity failed", "错误：获得Pulser transmit reciviever intensity失败");
            }
            intensity = val; 
            return error_code;
        }

        public static int DampingActive(uint ascanNum, uint ascanPort, ref PulserDampingActive active)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.DampingActive;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Pulser transmit reciviever damping active failed", "错误：获得Pulser transmit reciviever damping active失败");
            }
            active = (PulserDampingActive)val;
            return error_code;
        }

        public static int DampingValue(uint ascanNum, uint ascanPort, ref uint value)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.DampingValue;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Pulser transmit reciviever damping value failed", "错误：获得Pulser transmit reciviever damping value失败");
            }
            value = val;
            return error_code;
        }

        public static int RecieverMode(uint ascanNum, uint ascanPort, ref RecieverType mode)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.RecieverMode;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Pulser transmit reciviever damping value failed", "错误：获得Pulser transmit reciviever damping value失败");
            }
            mode = (RecieverType)val;
            return error_code;
        }

        public static int Prf(uint ascanNum, uint ascanPort, ref uint prf)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Prf;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Pulser transmit reciviever prf failed", "错误：获得Pulser transmit reciviever prf value失败");
            }
            prf = val;
            return error_code;
        }
    }
}
