using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class GetRecieverDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Active(uint ascanNum, uint port, ref ReceiverActive active)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.Active;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get reciviever active failed!", "错误：获得reciviever active失败!");
            }
            active = (ReceiverActive)val;
            return error_code;
        }

        public static int AnalogHPF(uint ascanNum, uint port, ref FilterCutoffFreq freq)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.AnalogHPF;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Filter cut off frequency failed!", "错误：获得截止频率失败!");
            }
            freq = (FilterCutoffFreq)val;
            return error_code;
        }

        public static int AnalogLPF(uint ascanNum, uint port, ref FilterCutoffFreq analogLPF)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.AnalogLPF;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get analog low pass filter failed!", "错误：获得analog low pass filter失败!");
            }
            analogLPF = (FilterCutoffFreq)val;
            return error_code;
        }

        public static int DigitalHPF(uint ascanNum, uint port, ref FilterCutoffFreq digitalHPF)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.DigitalHPF;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get digital high pass filter failed!", "错误：获得digital high pass filter失败!");
            }
            digitalHPF = (FilterCutoffFreq)val;
            return error_code;
        }

        public static int DigitalLPF(uint ascanNum, uint port, ref FilterCutoffFreq digitalLPF)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.DigitalLPF;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get digital low pass filter failed!", "错误：获得digital low pass filter失败!");
            }
            digitalLPF = (FilterCutoffFreq)val;
            return error_code;
        }

        public static int ReceiverPATH(uint ascanNum, uint port, ref ReceiverPATH receiverPATH)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.ReceiverPATH;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get reciever PATH failed!", "错误：获得reciever PATH失败!");
            }
            receiverPATH = (ReceiverPATH)val;
            return error_code;
        }

        public static int DampingActive(uint ascanNum, uint port, ref DampingActive active)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.DampingActive;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get damping active failed!", "错误：获得damping active失败!");
            }
            active = (DampingActive)val;
            return error_code;
        }


        public static int DampingValue(uint ascanNum, uint port, ref uint dampingValue)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.DampingValue;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get damping value failed!", "错误：获得damping value失败!");
            }
            dampingValue = val;
            return error_code;
        }

        public static int AnalogGain(uint ascanNum, uint port, ref double gain)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.AnalogGain;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get analog gain failed!", "错误：获得analog gain失败!");
            }
            gain = val;
            return error_code;
        }
    }
}
