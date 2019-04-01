using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    /**para Compare the ascan parameters setting with the ascan parameter read from thread*/
    public struct AscanPara
    {
        public uint len; //512 or 1024

        public uint ifStart; //interface tracking on/off

        public uint tofUnit;

        public uint ampUnit;

        public uint echoMax;
        //EchoMax        flag
        //	off			0
        //	on			1

        public uint waveDetectMode;
        //see ENUM_DAQ_ASCAN_VIDEO_DETECTION_WAVE_MODE

        public uint envelopStart; 
        //envelopStart     flag
        //	off			   0
        //	on			   1

        public double delay;

        public double width;

        public double gain; //


        public double bea; //

        public double decayFactor;  //decay factor
    }

    public class ComparePara
    {
        public static AscanPara[] ascanPara;

        public void init(int sessionCount)
        {
            ascanPara = new AscanPara[sessionCount];
            for (int i = 0; i < sessionCount; i++)
            {

            }
        }
    }

}
