using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ascan
{
    [Serializable]
   public  class UltraProbe
    {
        //type:   0-   /   1-
        public int type;

        public string name;

        public string sn;

        public string manu;

        public string date;
        //machine drawing part number
        public string drawingPartNum;


        //technical specification & acceptance criteia
        public double centerFreq;  //Hz

        public double minBand;    //%


        
        public double maxPluseDuration; //ns
       
        public double maxHomoSenDiff;  //dB
       
        public double maxInterCouple;  //dB


       //阵元数
        public uint eleNum;

        public double eleSpace;

        public double eleEdge;



        //recommended using conditions
        public double storeTemprMin; //storage termperature
        public double storeTemprMax;
        public double operTempMin; //operating termperature
        public double operTempMax;
        public double maxVolt;  // V

        public double maxPrf;   // Hz

        public double maxContinuePrf; // Hz


        //connector and casing
        public string connModel;   //connector model
        public string cableType;   //transducer cable type
        public double cableLen;     //mm
        public double cableOuterDia;     //mm

        public string color;

        public double length;
        public double width;
        public double height;

        //impendace measurement of transducer
        public  List<double> Zr;    //Zr(ohm)
        public  List<double> Zi;    //Zi(ohm)
        public  List<double> interCouple; //dB



        //CONSTRUCT
        public UltraProbe()
        {
            type = -1;

            name = "";

            sn = "";

            manu = "";

            date = "";
            //machine drawing part number
            drawingPartNum = "";


            //technical specification & acceptance criteia
            centerFreq = 0;  //Hz

            minBand = 0;    //%



            maxPluseDuration = 0; //ns

            maxHomoSenDiff = 0;  //dB

            maxInterCouple = 0;  //dB


           //阵元数
            eleNum = 0;

            eleSpace = 0;

            eleEdge = 0;



            //recommended using conditions
            storeTemprMin = 0; //storage termperature

            operTempMin = 0; //operating termperature

            maxVolt = 0;  // V

            maxPrf = 0;   // Hz

            maxContinuePrf = 0; // Hz


            //connector and casing
            connModel = "";   //connector model
            cableType = "";   //transducer cable type
            cableLen = 0;     //mm
            cableOuterDia = 0;     //mm

            color = "";

            length = 0;
            width = 0;
            height = 0;

            //impendace measurement of transducer
            Zr = new List<double>();    //Zr(ohm)
            Zi = new List<double>();    //Zi(ohm)
            interCouple = new List<double>(); //dB
        }

    }    
}


