using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class SetPulserTransmitDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Active(uint ascanNum, uint ascanPort, PluserActive active)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Active;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Pulser transmit reciviever active failed", "错误：设置Pulser transmit reciviever active失败");
            }
            return error_code;
        }

        public static int Delay(uint ascanNum, uint ascanPort, double delay)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Delay;
            double val = delay;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Pulser transmit reciviever delay failed", "错误：设置Pulser transmit reciviever delay失败");
            }
            return error_code;
        }

        public static int Width(uint ascanNum, uint ascanPort, double width)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Width;
            double val = width;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Pulser transmit reciviever width failed", "错误：设置Pulser transmit reciviever width失败");
            }
            return error_code;
        }

        public static int Intensity(uint ascanNum, uint ascanPort, double intensity)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Intensity;
            double val = intensity;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Pulser transmit reciviever intensity failed", "错误：设置Pulser transmit reciviever intensity失败");
            }
            return error_code;
        }

        public static int DampingActive(uint ascanNum, uint ascanPort, PulserDampingActive active)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.DampingActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Pulser transmit reciviever damping active failed", "错误：设置Pulser transmit reciviever damping active失败");
            }
            return error_code;
        }

        public static int DampingValue(uint ascanNum, uint ascanPort, uint value)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.DampingValue;
            uint val = value;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Pulser transmit reciviever damping value failed", "错误：设置Pulser transmit reciviever damping value失败");
            }
            return error_code;
        }

        public static int RecieverMode(uint ascanNum, uint ascanPort, RecieverType mode)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.RecieverMode;
            uint val = (uint)mode;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Pulser transmit reciviever damping value failed", "错误：设置Pulser transmit reciviever damping value失败");
            }
            return error_code;
        }

        public static int Prf(uint ascanNum, uint ascanPort, uint prf)
        {
            int error_code;
            uint attr = DaqAttrType.pulserTranmit.Prf;
            uint val = prf;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Pulser transmit reciviever prf failed", "错误：设置Pulser transmit reciviever prf value失败");
            }
            return error_code;
        }
    }
}
