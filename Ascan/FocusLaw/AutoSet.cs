using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class AutoSet
    {
        public List<Defectpoint> defectlist = new List<Defectpoint>();
        public int reflectcount = 0;
        public int directcount = 0;
        public int seriescount = 0;

        public AutoSet(Groove groove, double zonestep)
        {

            switch (groove.type)
            {
                case GrooveType.V:
                    VGroove(groove, zonestep);
                    break;
                case GrooveType.X:
                    XGroove(groove, zonestep);
                    break;
                case GrooveType.CRC:
                    CRCGroove(groove, zonestep);
                    break;
                default :
                    MessageShow.show("testblock type error", "坡口类型错误");
                    break;
            }
        }

        /**Set Vgroove Defect.*/
        private void VGroove(Groove groove, double zonestep)
        {
            int i = 0;
            double prehigh = 0;
            Defectpoint defectpoint = new Defectpoint();
            double reflecthigh = 0;
            double directhigh = 0;
            double reflectangle = 0;
            double[] reflectzone;
            double[] directzone;

            reflecthigh = groove.height[0];
            directhigh = groove.height[1];
            reflectangle = 90 - groove.angle[0];
            reflectzone = Getzone(reflecthigh, zonestep, ref reflectcount);
            directzone = Getzone(directhigh, zonestep, ref directcount);
            seriescount = 0;

            //direct
            for (i = 0; i < reflectcount; i++)
            {
                defectpoint = new Defectpoint();
                defectpoint.defectY = prehigh + reflectzone[i] / 2;
                defectpoint.defectX = (reflecthigh - defectpoint.defectY) / Math.Tan(BeamPara.TurntoRadian(reflectangle));
                defectpoint.defectangle = 90;
                defectlist.Add(defectpoint);
                prehigh += reflectzone[i];
            }

            prehigh = 0;
            for (i = 0; i < directcount; i++)
            {
                defectpoint = new Defectpoint();
                defectpoint.defectY = reflecthigh + prehigh + directzone[i]/2;
                defectpoint.defectX = 0;
                defectpoint.defectangle = 70;
                defectlist.Add(defectpoint);
                prehigh += directzone[i];
            }



        }

        /**Set CRCgroove Defect.*/
        private void CRCGroove(Groove groove, double zonestep)
        {
            double h = groove.height.Sum();
            //manual set CRC para
            int i = 0;
            int direct1count = 0;
            int direct2count = 0;
            double prehigh = 0;
            Defectpoint defectpoint = new Defectpoint();
            double serieshigh = groove.height[0];
            double reflecthigh = groove.height[1];
            double direct1high = groove.height[2];
            double direct2high = groove.height[3];
            double seriesangle = BeamPara.TurntoRadian(groove.angle[0]);
            double reflectangle = BeamPara.TurntoRadian(groove.angle[1]);
            double directangle = BeamPara.TurntoRadian(groove.angle[2]);
            double[] reflectzone;
            double[] serieszone;
            double[] direct1zone;
            double[] direct2zone;

            reflectzone = Getzone(reflecthigh, zonestep, ref reflectcount);
            serieszone = Getzone(serieshigh, zonestep, ref seriescount);
            direct1zone = Getzone(direct1high, zonestep, ref direct1count);
            direct2zone = Getzone(direct2high, zonestep, ref direct2count);
            directcount = direct1count + direct2count;

            for (i = 0; i < seriescount; i++)
            {
                defectpoint = new Defectpoint();
                defectpoint.defectY = prehigh + serieszone[i] / 2;
                defectpoint.defectX = reflecthigh * Math.Tan(reflectangle) + (serieshigh - defectpoint.defectY) * Math.Tan(seriesangle);
                defectpoint.defectangle = 45;
                defectlist.Add(defectpoint);
                prehigh += serieszone[i];
            }

            prehigh = 0;
            for (i = 0; i < reflectcount; i++)
            {
                defectpoint = new Defectpoint();
                defectpoint.defectY = serieshigh + prehigh + reflectzone[i] / 2;
                defectpoint.defectX = (reflecthigh + serieshigh - defectpoint.defectY) * Math.Tan(reflectangle); 
                defectpoint.defectangle = 90;
                defectlist.Add(defectpoint);
                prehigh += reflectzone[i];
            }

            prehigh = 0;
            for (i = 0; i < direct1count; i++)
            {
                defectpoint = new Defectpoint();
                defectpoint.defectY = serieshigh + reflecthigh + prehigh + direct1zone[i] / 2;
                defectpoint.defectX = 0;
                defectpoint.defectangle = 70;
                defectlist.Add(defectpoint);
                prehigh += direct1zone[i];
            }

            prehigh = 0;
            for (i = 0; i < direct2count; i++)
            {
                defectpoint = new Defectpoint();
                defectpoint.defectY = serieshigh + reflecthigh + direct1high + prehigh + direct2zone[i] / 2;
                defectpoint.defectX = (defectpoint.defectY - (h - direct2high)) * Math.Tan(directangle);
                defectpoint.defectangle = 90;
                defectlist.Add(defectpoint);
                prehigh += direct2zone[i];
            }
        }

        /**Set Xgroove Defect.*/
        private void XGroove(Groove groove, double zonestep)
        {
            int i = 0;
            double prehigh = 0;
            Defectpoint defectpoint = new Defectpoint();
            double reflecthigh = 0;
            double directhigh = 0;
            double[] reflectzone;
            double[] directzone;

            reflecthigh = groove.height[0];
            directhigh = groove.height[1];

            reflectzone = Getzone(reflecthigh, zonestep, ref reflectcount);
            directzone = Getzone(directhigh, zonestep, ref directcount);
            seriescount = 0;

            for (i = 0; i < reflectcount; i++)
            {
                defectpoint = new Defectpoint();
                defectpoint.defectY = prehigh + reflectzone[i] / 2;
                defectpoint.defectX = (reflecthigh - defectpoint.defectY) / Math.Tan(BeamPara.TurntoRadian(groove.angle[0]));
                defectpoint.defectangle = 90;
                defectlist.Add(defectpoint);
                prehigh += reflectzone[i];
            }

            prehigh = 0;
            for (i = 0; i < directcount; i++)
            {
                defectpoint = new Defectpoint();
                defectpoint.defectY = reflecthigh + prehigh + directzone[i] / 2;
                defectpoint.defectX = (defectpoint.defectY - reflecthigh) / Math.Tan(BeamPara.TurntoRadian(groove.angle[0])); //
                defectpoint.defectangle = 90;
                defectlist.Add(defectpoint);
                prehigh += directzone[i];
            }

        }

        /**Get Zone count and space.*/
        //private double[] Getzone(double high, double step, ref int count)
        //{
        //    int x = 0;
        //    double y = 0;
        //    int i = 0;
        //    double[] space;

        //    x =(int)Math.Floor(high / step);
        //    y = high % step;
        //    if (y == 0)
        //    {
        //        count = x;
        //        space = new double[count];
        //        for (i = 0; i < count; i++)
        //        {
        //            space[i] = step;
        //        }
        //    }
        //    else if (y > 0 && y <= step/2)
        //    {
        //        count = x + 1;
        //        space = new double[count];
        //        for (i = 0; i < count - 2; i++)
        //        {
        //            space[i] = step;
        //        }
        //        if (count == 1)
        //        {
        //            space[0] = high;
        //        }
        //        else
        //        {
        //            space[count - 2] = (high - (count - 2) * step) / 2;
        //            space[count - 1] = space[count - 2];
        //        }
        //    }
        //    else
        //    {
        //        count = x + 1;
        //        space = new double[count];
        //        for (i = 0; i < count - 1; i++)
        //        {
        //            space[i] = step;
        //        }
        //        space[count-1] = (high - (count - 1) * step);
        //    }
        //    return space;
        //}

        private double[] Getzone(double high, double step, ref int count)
        {
            int x = 0;
            double y = 0;
            int i = 0;
            double[] space;

            x = (int)Math.Floor(high / step);
            y = high % step;
            if (y == 0)
            {
                count = x;
                space = new double[count];
                for (i = 0; i < count; i++)
                {
                    space[i] = step;
                }
            }
            else if (y > 0 && y <= step / 2)
            {
                if (x == 0)
                {
                    count = 1;
                }
                else
                {
                    count = x;
                }
                space = new double[count];
                for (i = 0; i < count - 2; i++)
                {
                    space[i] = step;
                }
                if (count == 1)
                {
                    space[0] = high;
                }
                else
                {
                    space[count - 2] = (high - (count - 2) * step) / 2;
                    space[count - 1] = space[count - 2];
                }
            }
            else
            {
                count = x + 1;
                space = new double[count];
                for (i = 0; i < count - 1; i++)
                {
                    space[i] = step;
                }
                space[count - 1] = (high - (count - 1) * step);
            }
            return space;
        }
    }

    class Defectpoint
    {
        public double defectX;
        public double defectY;
        public double defectangle;

        public Defectpoint()
        {
            defectX = 0;
            defectY = 0;
            defectangle = 0;
        }
    }
}
