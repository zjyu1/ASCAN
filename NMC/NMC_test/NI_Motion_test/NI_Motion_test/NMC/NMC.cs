using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace NIMotion
{
    public static class NMC
    {
        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int HardwareOpen();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int HardwareClose();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareIsOpen();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareGoZero();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareGo(int axis, double range, double speed);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareBGo(int axis, double range, double speed);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareGoThree(int axis1, double range1, double speed1, int axis2, double range2, double speed2, int axis3, double range3, double speed3);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareGoPlanar(int axis1, double range1, int axis2, double range2, double speed, double mmStep);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareBGoPlanar(int axis1, double range1, int axis2, double range2, double speed, double mmStep);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareDGo(int axis, double range, double speed);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int HardwareGetCurPos(int axis, ref double pos);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int HardwareCurVeloc(int axis, ref double v);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareIsComplete();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HardwareWaitComplete(int ms);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HardwareSetMaxWaitTime(int ms);

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HardwareEHalt();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HardwareEKill();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HardwareEStop();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HardwareSigStart2Hardware();

        [DllImport("NMC.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HardwareSigStop2Hardware();
    }
}
