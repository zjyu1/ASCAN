using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class GetMaterialVelocityDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Longitudinal(uint ascanNum, uint ascanPort, ref double longitudinal)
        {
            int error_code;
            uint attr = DaqAttrType.matVelocity.Longitudinal;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr,ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Material longitudinal velocity failed", "错误：获得材料纵波声速失败");
            }
            longitudinal = val;
            return error_code;
        }

        public static int Transverse(uint ascanNum, uint ascanPort, ref double transverse)
        {
            int error_code;
            uint attr = DaqAttrType.matVelocity.Transverse;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Material transverse velocity failed", "错误：获得材料横波声速失败");
            }
            transverse = val;
            return error_code;
        }

        public static int Velocity(uint ascanNum, uint ascanPort, ref double velocity)
        {
            int error_code;
            uint attr = DaqAttrType.matVelocity.Velocity;
            double val = 0;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Material  velocity failed", "错误：获得材料声速失败");
            }
            velocity = val;
            return error_code;
        }
    }
}
