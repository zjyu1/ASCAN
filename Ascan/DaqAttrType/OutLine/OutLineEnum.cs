using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum OutLineRoute
    {
        None = 0,	//0~8与旋探等在线仪器兼容
        GateIAlarm = 1,
        GateAAlarm = 2,
        GateBAlarm = 3,
        GateCAlarm = 4,
        GateBAAlarm = 5,
        GateAIAlarm = 6,
        GateBIAlarm = 7,
        GateCIAlarm = 8,
        ReadyHandShake = 9, //9是我们自己旋探系统添加的 

        //Motor drive  
        EnXDirection = 10,//10~18为UTPOCKET 等独立仪器兼容	
        DirXDirection = 11,
        StepXDirection = 12,

        EnYDirection = 13,
        DirYDirection = 14,
        StepYDirection = 15,

        EnZDirection = 16,
        DirZDirection = 17,
        StepZDirection = 18,
        GotoZero = 19,

        //pxi trig bus    
        PxiStarTrigLine = 20,//系统新增     
        PxiTrigLine0 = 21,
        PxiTrigLine1 = 22,
        PxiTrigLine2 = 23,
        PxiTrigLine3 = 24,
        PxiTrigLine4 = 25,
        PxiTrigLine5 = 26,
        PxiTrigLine6 = 27,
        PxiTrigLine7 = 28,

        //pxi local bus   
        PxiLBL0 = 29,
        PxiLBL1 = 30,
        PxiLBL2 = 31,
        PxiLBL3 = 32,
        PxiLBL4 = 33,
        PxiLBL5 = 34,
        PxiLBL6 = 35,
        PxiLBL7 = 36,
        PxiLBL8 = 37,
        PxiLBL9 = 38,
        PxiLBL10 = 39,
        PxiLBL11 = 40,
        PxiLBL12 = 41,

        PxiLBR0 = 42,
        PxiLBR1 = 43,
        PxiLBR2 = 44,
        PxiLBR3 = 45,
        PxiLBR4 = 46,
        PxiLBR5 = 47,
        PxiLBR6 = 48,
        PxiLBR7 = 49,
        PxiLBR8 = 50,
        PxiLBR9 = 51,
        PxiLBR10 = 52,
        PxiLBR11 = 53,
        PxiLBR12 = 54,

        //AD bus
        PxiAD32 = 102,
        PxiAD33 = 55,
        PxiAD34 = 56,
        PxiAD35 = 57,
        PxiAD36 = 58,
        PxiAD37 = 59,
        PxiAD38 = 60,
        PxiAD39 = 61,
        PxiAD40 = 62,
        PxiAD41 = 63,
        PxiAD42 = 64,
        PxiAD43 = 65,
        PxiAD44 = 66,
        PxiAD45 = 67,
        PxiAD46 = 68,
        PxiAD47 = 69,
        PxiAD48 = 70,
        PxiAD49 = 71,
        PxiAD50 = 72,
        PxiAD51 = 73,
        PxiAD52 = 74,
        PxiAD53 = 75,
        PxiAD54 = 76,
        PxiAD55 = 77,
        PxiAD56 = 78,
        PxiAD57 = 79,
        PxiAD58 = 80,
        PxiAD59 = 81,
        PxiAD60 = 82,
        PxiAD61 = 83,
        PxiAD62 = 84,
        PxiAD63 = 85,

        //optocoupler input line 
        InlIne0 = 86,
        InlIne1 = 87,
        InlIne2 = 88,
        InlIne3 = 89,
        InlIne4 = 90,
        InlIne5 = 91,
        InlIne6 = 92,
        InlIne7 = 93,
        InlIne8 = 94,
        InlIne9 = 95,
        InlIne10 = 96,
        InlIne11 = 97,
        InlIne12 = 98,
        InlIne13 = 99,
        InlIne14 = 100,
        InlIne15 = 101,
    }
}
