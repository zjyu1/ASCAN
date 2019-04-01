using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ascan
{
    [Serializable]
    public class UltraWedge
    {
        //type
        public string type;
        
        public string name;

        // sequence number
        public string sn;
        //manufacturer
        public string manu;

        public string date;

        //technical specification & acceptance criteia
        //machine drawing part number
        public string drawingPartNum;



        //connector and casing
        //    headLen
        //                ----.
        //               |           .
        //   height  |                 .     
        //               |                   |        
        //               ----------------
        //                      lenth

        public double length;    //mm
        public double width;
        public double height;

        public double headLen; //mm
        public double incidentAngle; //


        //velocity
        public double longVeloc; //mm/us
        public double transVeloc; //mm/us
        //recommended using conditions
        public double storeTemprMin; //storage termperature
        public double storeTemprMax;
        public double operTempMin; //operating termperature
        public double operTempMax;

        //CONSTRUCT
        public UltraWedge()
        {
            type = "";
            name = "";
            date = "";
            drawingPartNum = "";
            storeTemprMin = 0;
            operTempMin = 0;
            length = 0;
            width = 0;
            headLen = 0;
            height = 0;
            incidentAngle = 0;
            longVeloc = 0;
            transVeloc = 0;

        }

    }
}
