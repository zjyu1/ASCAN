using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class SetReceiverDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Active(uint ascanNum, uint ascanPort, ReceiverActive active)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.Active;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set reciviever active failed!", "错误：设置reciviever active失败!");
            }
            return error_code;
        }

        public static int AnalogHPF(uint ascanNum, uint ascanPort, FilterCutoffFreq freq)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.AnalogHPF;
            uint val = (uint)freq;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Filter cut off frequency failed!", "错误：设置截止频率失败!");
            }
            return error_code;
        }

        public static int AnalogLPF(uint ascanNum, uint ascanPort, FilterCutoffFreq analogLPF)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.AnalogLPF;
            uint val = (uint)analogLPF;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set analog low pass filter failed!", "错误：设置analog low pass filter失败!");
            }
            return error_code;
        }

        public static int DigitalHPF(uint ascanNum, uint ascanPort, FilterCutoffFreq digitalHPF)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.DigitalHPF;
            uint val = (uint)digitalHPF;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set digital high pass filter failed!", "错误：设置digital high pass filter失败!");
            }
            return error_code;
        }

        public static int DigitalLPF(uint ascanNum, uint ascanPort, FilterCutoffFreq digitalLPF)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.DigitalLPF;
            uint val = (uint)digitalLPF;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set digital low pass filter failed!", "错误：设置digital low pass filter失败!");
            }
            return error_code;
        }

        public static int RecieverPATH(uint ascanNum, uint ascanPort, ReceiverPATH receiverPATH)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.ReceiverPATH;
            uint val = (uint)receiverPATH;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set reciever PATH failed!", "错误：设置reciever PATH失败!");
            }
            return error_code;
        }

        public static int DampingActive(uint ascanNum, uint ascanPort, DampingActive active)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.DampingActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set damping active failed!", "错误：设置damping active失败!");
            }
            active = (DampingActive)val;
            return error_code;
        }


        public static int DampingValue(uint ascanNum, uint ascanPort, uint dampingValue)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.DampingValue;
            uint val = (uint)dampingValue;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set damping value failed!", "错误：设置damping value失败!");
            }
            return error_code;
        }

        public static int AnalogGain(uint ascanNum, uint ascanPort, double gain)
        {
            int error_code;
            uint attr = DaqAttrType.receiver.AnalogGain;
            double val = gain;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set analog gain failed!", "错误：设置analog gain失败!");
            }
            return error_code;
        }
    }
}
