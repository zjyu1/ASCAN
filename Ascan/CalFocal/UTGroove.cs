using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ascan
{
    //the subclass can be used to transfer of data upper
    //the representing mean of parameters(height-h0\h1.. ; angle-a0\a1..) can corresponde sketch in subclass
    //————————————————————————————————————
    public class UltraVGroove : Groove
    {
        //sketch
        //"h" represents vertical height ; "a" represents angle with vertical direction 
        //
        //  |                 d       |
        //  ---------------------              ——
        //   \                        /
        //     \                    /                    
        //       \        |       /                      h0
        //         \      |a0  /
        //           \    |   /
        //             \  | /                         ____
        //               | |                              h1
        //               --                           ____
        //

        //technical specification 
        //public float d;
        public double h0;
        public double h1;
        public double a0;

        private void GetData()
        {
            h0 = height[0];
            h1 = height[1];
            a0=angle[0];
        }

        public UltraVGroove()
        {
            h0 = 0;
            h1 = 0;
            a0 = 0;
        }

    }

    public class UltraXGroove : Groove
    {
        //sketch
        //"h" represents vertical height ; "a" represents angle with vertical direction 
        //
        //      |   d              |
        //      ---------------               ——                
        //       \        |       /                      
        //         \      |a0  /                    h0
        //           \    |   /
        //             \  | /                        
        //               \|/                        ____  
        //               /\                         
        //              /   \
        //             /      \                        h1
        //            /         \
        //           ----------                  ____

        //technical specification 
        //public double d;
        public double h0;
        public double h1;
        public double a0;

    }

    public class UltraCRCGroove:Groove
    {
         //sketch
        //"h" represents vertical height ; "a" represents angle with vertical direction 
        //
        //     |              d          |
        //     ---------------------              ——         
        //     |                      |a0|
        //     |                      |   |                  h0
        //     |  __________|  |                ____
        //      \         |            /                      
        //        \   a1|           /                    h2
        //           \    |        /
        //             \  |      /                        
        //               \|    /                        ____  
        //                 |  |                           h3
        //                 |  |                         ____
        //                /  | \                  
        //              /    |   \                        h4
        //             /     |a3 \  
        //             ----------                     ____
          
        //technical specification 
        //public double d;
        public double h0;
        public double h1;
        public double h2;
        public double h3;
        public double a0;
        public double a1;
        public double a2;


        public UltraCRCGroove()
        {
        }
 
    }

    //——————————————————————————————————

    //what height[i] and angle[i] specificly mean can look for the sketch of subclass
    [Serializable]
    public class Groove
    {
        public double distance;
        public List<double> height;
        public List<double> angle;
        public double transVeloc;
        public double longVeloc;
        //"0"-V\"1"-X\"2"-CRC
        //public int type;
        public GrooveType type;
        
        public string sn;

        public void ClearList()
        {
            type = GrooveType.NULL;
            sn = "";
            distance = 0;
            transVeloc = 0;
            longVeloc = 0;
            height.Clear();
            angle.Clear();
        }

        //CONSTRUCT
        public Groove()
        {
            type = GrooveType.NULL;
            sn = "";
            distance = 0;
            transVeloc = 0;
            longVeloc = 0;
            height = new List<double>();
            angle = new List<double>();
        }

    }

}
