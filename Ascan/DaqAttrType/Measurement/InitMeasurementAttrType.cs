using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitMeasurementAttrType
    {
        /**Read MaterialVelocityAttrType form MaterialVelocity.xml*/
        public static void read()
        {
            StrMeasurement param;

            MeasurementXml measurementXml = SystemConfig.DeserializeFromXml<MeasurementXml>("DaqAttrTypeXml/Measurement.xml");

            if (measurementXml == null)
            {
                MessageShow.show("Get measurement parameter from Measurement.xml failed",
                    "从Measurement.xml获取接口地址失败");
                return;
            }
            param = measurementXml.measurement.Param;

            DaqAttrType.measurement.AlarmActive = addAddress(param.AlarmActive, DaqAttrType.baseAddr);
            DaqAttrType.measurement.AlarmDisp = addAddress(param.AlarmDisp, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
