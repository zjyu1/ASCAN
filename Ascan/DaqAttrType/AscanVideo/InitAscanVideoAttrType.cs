using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitAscanVideoAttrType
    {
        /**Read PulserTransmitAttrType form PulserTransmit.xml*/
        public static void read()
        {
            StrAscanVideo param;

            AscanVideoXml ascanVideoXml = SystemConfig.DeserializeFromXml<AscanVideoXml>("DaqAttrTypeXml/AscanVideo.xml");

            if (ascanVideoXml == null)
            {
                MessageShow.show("Get Ascan video parameter from AscanVideo.xml failed",
                    "从AscanVideo.xml获取接口地址失败");
                return;
            }
            param = ascanVideoXml.ascanVideo.Param;

            DaqAttrType.ascanVideo.Active = addAddress(param.Active, DaqAttrType.baseAddr);
            DaqAttrType.ascanVideo.IFActive = addAddress(param.IFActive, DaqAttrType.baseAddr);
            DaqAttrType.ascanVideo.Delay = addAddress(param.Delay, DaqAttrType.baseAddr);
            DaqAttrType.ascanVideo.Range = addAddress(param.Range, DaqAttrType.baseAddr);
            DaqAttrType.ascanVideo.DetectionWaveMode = addAddress(param.DetectionWaveMode, DaqAttrType.baseAddr);
            DaqAttrType.ascanVideo.EnvlopActive = addAddress(param.EnvlopActive, DaqAttrType.baseAddr);
            DaqAttrType.ascanVideo.Length = addAddress(param.Length, DaqAttrType.baseAddr);
            DaqAttrType.ascanVideo.CompressedData = addAddress(param.CompressedData, DaqAttrType.baseAddr);
            DaqAttrType.ascanVideo.EnvlopDecayFactor = addAddress(param.EnvlopDecayFactor, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
