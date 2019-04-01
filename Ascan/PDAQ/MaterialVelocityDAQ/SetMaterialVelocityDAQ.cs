using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class SetMaterialVelocityDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Longitudinal(uint ascanNum, uint ascanPort, double longitudinal)
        {
            int error_code;
            uint attr = DaqAttrType.matVelocity.Longitudinal;
            double val = longitudinal;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Material longitudinal velocity failed", "错误：设置材料纵波声速失败");
            }
            return error_code;
        }

        public static int Transverse(uint ascanNum, uint ascanPort, double transverse)
        {
            int error_code;
            uint attr = DaqAttrType.matVelocity.Transverse;
            double val = transverse;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Material transverse velocity failed", "错误：设置材料横波声速失败");
            }
            return error_code;
        }

        public static int Velocity(uint ascanNum, uint ascanPort, double velocity)
        {
            int error_code;
            uint attr = DaqAttrType.matVelocity.Velocity;
            double val = velocity;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Material  velocity failed", "错误：设置材料声速失败");
            }

            return error_code;
        }
    }
}
