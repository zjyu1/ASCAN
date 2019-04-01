using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class ClassChanpara
    {
        public string channel;
        public string name;
        public string wave;
        public int config;  //0 Pluser-Ec 1 Picher&Catcher
        public int txrx;    //0 txrx 1 tx/rx
        public int method;  //0 direct 1 reflect 2 series
        public double[] interfaceAngle;
        public double[] defectAngle;
        public int[] element;
        public int[] activenb;
        public double index;
        public double velocity;
        public int skew;
        public double defectX;
        public double defectY;

        public ClassChanpara()
        {
            channel = "";
            name = "";
            wave = "";
            config = 0;
            txrx = 0;
            method = 0;
            interfaceAngle = new double[2];
            defectAngle = new double[2];
            element = new int[2];
            activenb = new int[2];
            index = 0;
            velocity = 0;
            skew = 0;
            defectX = 0;
            defectY = 0;
        }
    }
}
