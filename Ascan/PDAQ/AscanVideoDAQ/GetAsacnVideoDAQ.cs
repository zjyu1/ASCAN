using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class GetAsacnVideoDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Active(uint ascanNum, uint port, ref AscanVideoActive active)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.Active;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Ascan video active failed", "错误：获得Ascan video active失败");
            }
            active = (AscanVideoActive)val;
            return error_code;
        }

        public static int IFActive(uint ascanNum, uint port, ref AscanIFActive active)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.IFActive;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Ascan if active failed", "错误：获得Ascan if active失败");
            }
            active = (AscanIFActive)val;
            return error_code;
        }


        public static int Delay(uint ascanNum, uint port, ref double delay)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.Delay;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Ascan delay failed", "错误：获得Ascan delay失败");
            }
            delay = val;
            return error_code;
        }

        public static int Range(uint ascanNum, uint port, ref double range)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.Range;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Ascan range failed", "错误：获得Ascan range失败");
            }
            range = val;
            return error_code;
        }

        public static int DetectionWaveMode(uint ascanNum, uint port, ref AscanWaveDectionMode mode)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.DetectionWaveMode;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Detection wave mode of Asacn failed", "错误：获得A扫的检波失败");
            }
            mode = (AscanWaveDectionMode)val;
            return error_code;
        }

        public static int EnvlopActive(uint ascanNum, uint port, ref AscanEnvelopActive active)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.EnvlopActive;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Envelop active failed", "错误：获得Envelop active失败");
            }
            active = (AscanEnvelopActive)val;
            return error_code;
        }

        public static int Length(uint ascanNum, uint port, ref AscanVideoLength length)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.Length;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Ascan video length failed", "错误：获得Ascan video length失败");
            }
            length = (AscanVideoLength)val;
            return error_code;
        }

        public static int CompressdData(uint ascanNum, uint port, ref AscanCompressedActive active)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.CompressedData;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Compressed Data failed", "错误：获得Ascan Compressed Data失败");
            }
            active = (AscanCompressedActive)val;
            return error_code;
        }

        public static int EnvlopDecayFactor(uint ascanNum, uint port, ref uint speed)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.EnvlopDecayFactor;
            uint val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, port, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Envlop Decay Factor failed！", "错误：获得包络速度失败！");
            }
            speed = val;
            return error_code;
        }
    }
}
