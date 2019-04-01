using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class SetGlobalControlDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int TrigMode(uint ascanNum, uint ascanPort, TrigMode trigMode)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.TrigMode;
            uint val = (uint)trigMode;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set trig mode failed", "错误：设置触发方式失败");
            }

            return error_code;
        }

        public static int RunMode(uint ascanNum, uint ascanPort, RunMode runMode)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.RunMode;
            uint val = (uint)runMode;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set run mode failed", "错误：设置运行模式失败");
            }
            return error_code;
        }

        public static int PxistarTrigStartDelay(uint ascanNum, uint ascanPort, uint delay)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.PxistarTrigStartDelay;
            uint val = delay;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set pxistar trig start delay failed", "错误：设置星形槽起始长度失败");
            }

            return error_code;
        }

        public static int PxistarTrigStopDelay(uint ascanNum, uint ascanPort, ref uint delay)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.PxistarTrigStopDelay;
            uint val = delay;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set pxistar trig stop delay failed", "错误：设置星形槽结束长度失败");
            }

            return error_code;
        }

        public static int SoftStart(uint ascanNum, uint ascanPort, uint softStart)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.SoftStart;
            uint val = softStart;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set soft start failed", "错误：设置软件开始失败");
            }

            return error_code;
        }

        public static int SoftStop(uint ascanNum, uint ascanPort, uint softStop)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.SoftStop;
            uint val = softStop;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set soft start failed", "错误：设置软件停止失败");
            }

            return error_code;
        }

        public static int SoftReset(uint ascanNum, uint ascanPort, uint softReset)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.SoftReset;
            uint val = softReset;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set soft reset failed", "错误：设置软件重置失败");
            }

            return error_code;
        }
    }
}
