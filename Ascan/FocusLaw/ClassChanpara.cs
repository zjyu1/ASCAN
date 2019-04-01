using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    [Serializable]
    public class ClassChanpara
    {
        public string channel;
        public string name;
        public string wave;
        public int config;  //0 Pluser-Echo 1 Picher&Catcher
        public int method;  //0 direct 1 reflect 2 series
        public double[] interfaceAngle;
        public double defectAngle;
        public int[] element;
        public int[] activenb;
        public double index;
        public double velocity;
        public int skew;
        public double defectX;
        public double defectY;
        public int zonetype;
        public double pathtime;
        public double delay;
        public double range;
        public List<GateDelay> gatedelay = new List<GateDelay> ();

        public ClassChanpara()
        {
            channel = "";
            name = "";
            wave = "";
            config = 0;
            method = 0;
            interfaceAngle = new double[2];
            defectAngle = 0;
            element = new int[2];
            activenb = new int[2];
            index = 0;
            velocity = 0;
            skew = 0;
            defectX = 0;
            defectY = 0;
            zonetype = 0;
            pathtime = 0;
            delay = 0;
            range = 0;
            for (int i = 0; i < 4; i++)
            {
                GateDelay gate = new GateDelay((GateType)i);
                gatedelay.Add(gate);
            }
        }
    }
}
