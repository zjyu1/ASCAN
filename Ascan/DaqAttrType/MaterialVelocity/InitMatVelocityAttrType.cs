using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitMatVelocityAttrType
    {
        /**Read MaterialVelocityAttrType form MaterialVelocity.xml*/
        public static void read()
        {
            StrMaterialVelocity param;

            MatVelocityXml matVelocityXml = SystemConfig.DeserializeFromXml<MatVelocityXml>("DaqAttrTypeXml/MaterialVelocity.xml");

            if (matVelocityXml == null)
            {
                MessageShow.show("Get Ascan video parameter from MaterialVelocity.xml failed",
                    "从MaterialVelocity.xml获取接口地址失败");
                return;
            }
            param = matVelocityXml.matVelocity.Param;

            DaqAttrType.matVelocity.Longitudinal = addAddress(param.Longitudinal, DaqAttrType.baseAddr);
            DaqAttrType.matVelocity.Transverse = addAddress(param.Transverse, DaqAttrType.baseAddr);
            DaqAttrType.matVelocity.Velocity = addAddress(param.Velocity, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
