using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class GetGlobalControlDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int TrigMode(uint ascanNum, uint ascanPort, ref TrigMode trigMode)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.TrigMode;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get trig mode failed", "错误：获得触发方式失败");
            }
            trigMode = (TrigMode)val;
            return error_code;
        }

        public static int RunMode(uint ascanNum, uint ascanPort, ref RunMode runMode)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.RunMode;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get run mode failed", "错误：获得运行模式失败");
            }
            runMode = (RunMode)val;
            return error_code;
        }

        public static int PxistarTrigStartDelay(uint ascanNum, uint ascanPort, ref uint delay)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.PxistarTrigStartDelay;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get pxistar trig start delay failed", "错误：获得星形槽起始长度失败");
            }
            delay = val;
            return error_code;
        }

        public static int PxistarTrigStopDelay(uint ascanNum, uint ascanPort, ref uint delay)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.PxistarTrigStopDelay;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get pxistar trig stop delay failed", "错误：获得星形槽结束长度失败");
            }
            delay = val;
            return error_code;
        }

        public static int SoftStart(uint ascanNum, uint ascanPort, ref uint softStart)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.SoftStart;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get soft start failed", "错误：获得软件开始失败");
            }
            softStart = val;
            return error_code;
        }

        public static int SoftStop(uint ascanNum, uint ascanPort, ref uint softStop)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.SoftStop;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get soft start failed", "错误：获得软件停止失败");
            }
            softStop = val;
            return error_code;
        }

        public static int SoftReset(uint ascanNum, uint ascanPort, ref uint softReset)
        {
            int error_code;
            uint attr = DaqAttrType.globalCtrl.SoftReset;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get soft reset failed", "错误：获得软件重置失败");
            }
            softReset = val;
            return error_code;
        }
    }
}
