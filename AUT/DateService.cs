using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ascan;
using System.IO;

namespace AUT
{
    [Serializable]
    public class StripDateService
    {
        [NonSerialized] private int lastIndex;
        [NonSerialized] private StripDate lastDate;
        private int endRealPos;
        private double mergeUnit;  //unit for merge

        private int maxNum;  //max value for coder

        private double maxPos; //curPosX must <= maxPos
        
        private List<StripDate[]> source;  //for original datas
        
        /**The constructor 
         * @param diameter the diameter of the pipeline, mm
         * .*/
        public StripDateService(double diameter)
        {
            double l = 3.1415926 * diameter;

            mergeUnit = (double)l * ConstParameter.AnglePreUnit /360 ;  //distantce for 2°

            endRealPos = 0;
            maxPos = l;

            lastIndex = 0;
            lastDate = new StripDate(-1, -1);

            source = new List<StripDate[]>();

            int maxHeight = (int)(l / ConstParameter.DefaultPosInc * 1.2); //the max num of the array the stroge the datas
            maxNum = maxHeight / ConstParameter.BufferCapacity + 1;
            while (source.Count < maxNum)
            {
                StripDate[] arrays = new StripDate[ConstParameter.BufferCapacity];
                for (int i = 0; i < arrays.Length; i++)
                    arrays[i] = new StripDate(-1, -1);
                source.Add(arrays);
            }
        }

        public void clear()
        {
            lastIndex = 0;
            lastDate = new StripDate(-1, -1);

            source = null;
            GC.Collect();

            source = new List<StripDate[]>();
            while (source.Count < maxNum)
            {
                StripDate[] arrays = new StripDate[ConstParameter.BufferCapacity];
                for (int i = 0; i < arrays.Length; i++)
                    arrays[i] = new StripDate(-1, -1);
                source.Add(arrays);
            }
        }

        public void mergeDates(ref List<StripDate> contain, ref int num, GatePacket gatePacket)
        {
            num = 0;
            int curPosX = (int)(gatePacket.tag.stampPos[0] / 1000);
            int inc = (int)(gatePacket.tag.stampInc[0] / 1000);
            int bin = (int)gatePacket.head.bin;
            int cellNum = (int)gatePacket.tag.cellNum;
            int numIndex = 0;
            double value;

            if (inc < 0)            //暂时解决方案，由于PosInc一直为负，DSP需解决
                inc = inc * (-1);

            if(bin == (int)DAQ_MEAS_MODE.TOF_PEAK)
            {
                for (int i = 0; i < cellNum && curPosX < maxPos; i++)
                {
                    value = gatePacket.measureDate[i];
                    //int tofIndex = (int)(curPosX / ConstParameter.DefaultPosInc) / ConstParameter.BufferCapacity;
                    //int arrayIndex = (int)(curPosX / ConstParameter.DefaultPosInc) % ConstParameter.BufferCapacity;
                    int tofIndex = (int)(curPosX / inc) / ConstParameter.BufferCapacity;    //把DefaultPosInc改为inc
                    int arrayIndex = (int)(curPosX / inc) % ConstParameter.BufferCapacity;
                    while (source.Count <= tofIndex)
                    {
                        StripDate[] arrays = new StripDate[ConstParameter.BufferCapacity];
                        for (int j = 0; j < arrays.Length; j++)
                            arrays[j] = new StripDate(-1, -1);
                        source.Add(arrays);
                    }

                    StripDate[] curArray = source[tofIndex];
                    curArray[arrayIndex].tof = value;
                    curArray[arrayIndex].isTofReceived = true;

                    if (curArray[arrayIndex].isAmpReceived && curArray[arrayIndex].isMaxInMerge)
                    {
                        StripDate date = contain[num++];
                        date.tof = curArray[arrayIndex].tof;
                        date.amp = curArray[arrayIndex].amp;
                        date.index = curArray[arrayIndex].index;
                    }

                    curPosX += inc;
                }
                endRealPos = Math.Max(endRealPos, curPosX - inc);
            }
            else if (bin == (int)DAQ_MEAS_MODE.AMP_PERCENT)
            {
                for (int i = 0; i < cellNum && curPosX < maxPos; i++)
                {
                    //add to the source
                    value = gatePacket.measureDate[numIndex++];

                    //int ampIndex = (int)(curPosX / ConstParameter.DefaultPosInc) / ConstParameter.BufferCapacity;
                    //int arrayIndex = (int)(curPosX / ConstParameter.DefaultPosInc) % ConstParameter.BufferCapacity;
                    int ampIndex = (int)(curPosX / inc) / ConstParameter.BufferCapacity;    //把DefaultPosInc改为inc
                    int arrayIndex = (int)(curPosX / inc) % ConstParameter.BufferCapacity;
                    while (source.Count <= ampIndex)
                    {
                        StripDate[] arrays = new StripDate[ConstParameter.BufferCapacity];
                        for (int j = 0; j < arrays.Length; j++)
                            arrays[j] = new StripDate(-1, -1);
                        source.Add(arrays);
                    }

                    StripDate[] curArray = source[ampIndex];
                    curArray[arrayIndex].realPos = curPosX;
                    curArray[arrayIndex].amp = value;
                    curArray[arrayIndex].isAmpReceived = true;

                    //merge
                    //int index = (int)(curPosX / mergeUnit);   
                    int index = (int)(curPosX / inc);   //把mergeUnit改为inc 
                    curArray[arrayIndex].index = index;
                    if (arrayIndex == 64)
                    {
                        int dd = index;
                    }
                    if (index == lastIndex)
                    {
                        if (value > lastDate.amp)
                        {
                            lastDate.isMaxInMerge = false;
                            lastDate = curArray[arrayIndex];
                            lastDate.isMaxInMerge = true;
                        }
                    }
                    else
                    {
                        //is tof not arrive, just make a note
                        if (!lastDate.isTofReceived)
                            lastDate.index = lastIndex;

                        //arrive, just update
                        else
                        {
                            StripDate date = contain[num++];
                            date.tof = lastDate.tof;
                            date.amp = lastDate.amp;
                            date.index = lastIndex;
                            date.realPos = lastDate.realPos;
                        }

                        lastIndex = index;
                        lastDate = curArray[arrayIndex];
                        lastDate.isMaxInMerge = true;
                    }

                    curPosX += (int)inc;
                }
                endRealPos = Math.Max(endRealPos, curPosX - (int)inc);
            }
        }

        public void rebuildDates(ref List<StripDate> contain, ref int count, ref int listIndex, ref int arrayIndex, ref bool toEnd)
        {
            int maxNum = contain.Count;
            int index = 0;
            while (index < maxNum)
            {
                listIndex += arrayIndex / ConstParameter.BufferCapacity;
                arrayIndex = arrayIndex % ConstParameter.BufferCapacity;

                StripDate[] curArray = source[listIndex];
                StripDate date = curArray[arrayIndex];
                if (date.isMaxInMerge && date.isAmpReceived && date.isTofReceived)
                {
                    StripDate tmp = contain[index++];
                    tmp.tof = date.tof;
                    tmp.amp = date.amp;
                    tmp.index = date.index;
                }
                arrayIndex++;

                if (endRealPos == date.realPos)
                {
                    toEnd = true;
                    break;
                }
            }
            count = index;
        }

        public void save(String fileName)
        {
            SystemConfig.WriteBase64Data(fileName, "stripDate", source);
        }

        private void saveToTxt(String fileName)
        {
            StreamWriter writer = new StreamWriter(fileName, false);
            bool toEnd = false;
            bool isFirst = true;
            int count = 0;
            foreach (StripDate[] array in source)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    StripDate date = array[i];

                    if (date.isAmpReceived && date.isTofReceived)
                    {
                        if (isFirst)
                        {
                            writer.WriteLine(date.tof + " " + date.amp);
                            isFirst = false;
                        }
                        else
                            writer.WriteLine(" " + date.tof + " " + date.amp);
                        count++;
                    }

                    if (date.realPos == endRealPos)
                    {
                        toEnd = true;
                        break;
                    }
                }
                if (toEnd)
                    break;
            }
            writer.WriteLine(" " + count);
            writer.Flush();
            writer.Close();
        }
    }

    [Serializable]
    public class PictureDateService
    {
        private int lastIndex;
        private double[] lastDate;
        private double mergeUnit;  //unit for merge

        private int maxNum;  //max value for coder

        private double maxPos; //curPosX must <= maxPos

        private List<PictureDate> source;

        /**The constructor 
         * @param diameter the diameter of the pipeline, mm
         * .*/
        public PictureDateService(double diameter)
        {
            double l = 2 * 3.14 * diameter;

            mergeUnit = l / 360 * ConstParameter.AnglePreUnit;  //distantce for 2°

            maxPos = l;

            source = new List<PictureDate>();

            lastIndex = 0;
            lastDate = new double[ConstParameter.BscanPointNumPrePacket];

            int maxHeight = (int)(l / ConstParameter.DefaultPosInc * 1.2); //the max num of the array the stroge the datas
            maxNum = maxHeight  + 1;
            while (source.Count < maxNum)
            {
                PictureDate pictureDate = new PictureDate();
                source.Add(pictureDate);
            }
        }

        public void clear()
        {
            lastIndex = 0;
            lastDate = new double[ConstParameter.BscanPointNumPrePacket];

            source = null;
            GC.Collect();

            source = new List<PictureDate>();
            while (source.Count < maxNum)
            {
                PictureDate pictureDate = new PictureDate();
                source.Add(pictureDate);
            }
        }

        public void mergeDates(ref List<PictureDate> contain, ref int num, GatePacket gatePacket)
        {
            int constNum = ConstParameter.BscanPointNumPrePacket;
            int index = 0;
            int curPosX = (int)(gatePacket.tag.stampPos[0] / 1000);
            int inc = (int)(gatePacket.tag.stampInc[0] / 1000);
            int cellNum = (int)gatePacket.tag.cellNum;
            int pktNum = cellNum / constNum;

            for (int k = 0; k < pktNum && curPosX < maxPos; k++)
            {
                int start = k * constNum;
                
                int sourceIndex = (int) (curPosX / ConstParameter.DefaultPosInc);

                //Add
                PictureDate cur = source[sourceIndex];
                cur.realPos = curPosX;
                Array.Copy(gatePacket.measureDate, start, cur.dates, 0, constNum);

                //merge
                index = (int)(curPosX / mergeUnit);
                if (index == lastIndex)
                {
                    for (int i = 0; i < cur.dates.Length; i++)
                        lastDate[i] = Math.Max(lastDate[i], cur.dates[i]);
                }
                else
                {
                    PictureDate date = contain[num++];
                    //date[0] is the index 
                    date.index = lastIndex;
                    Array.Copy(lastDate, 0, date.dates, 0, lastDate.Length);
                        
                    lastIndex = index;
                    Array.Clear(lastDate, 0, lastDate.Length);
                }
                curPosX += inc;
            }
        }

        public void save(String fileName)
        {
            SystemConfig.WriteBase64Data(fileName, "pictureDate", source);
        }

        public void rebuildDates(ref List<PictureDate> contain, ref int count, ref int sourceIndex, ref bool toEnd)
        {
            int maxNum = contain.Count;
            int tmpIndex = 0;

            if (sourceIndex == 0)
            {
                lastIndex = 0;
                lastDate = new double[ConstParameter.BscanPointNumPrePacket];
            }

            while (tmpIndex < maxNum)
            {
                if (sourceIndex < source.Count)
                {
                    PictureDate cur = source[sourceIndex];
                    int index = (int)(cur.realPos / mergeUnit);

                    if (index == lastIndex)
                    {
                        for (int i = 0; i < cur.dates.Length; i++)
                            lastDate[i] = Math.Max(lastDate[i], cur.dates[i]);
                    }
                    else
                    {
                        PictureDate date = contain[tmpIndex++];
                        date.index = lastIndex;
                        Array.Copy(lastDate, 0, date.dates, 0, lastDate.Length);

                        lastIndex = index;
                        Array.Clear(lastDate, 0, lastDate.Length);
                    }
                }
                else
                {
                    toEnd = true;
                    break;
                }
                sourceIndex++;
            }

            count = tmpIndex;
        }
    }

    [Serializable]
    public class CoupleDateService
    {
        private CoupleDate lastCouple;
        private double mergeUnit;  //unit for merge

        private int maxNum;  //max value for coder

        private double maxPos; //curPosX must <= maxPos

        private List<CoupleDate> source;

        /**The constructor 
         * @param diameter the diameter of the pipeline, mm
         * .*/
        public CoupleDateService(double diameter)
        {
            double l = 3.14 * diameter;

            mergeUnit = l / 360 * ConstParameter.AnglePreUnit;  //distantce for 2°

            maxPos = l;

            source = new List<CoupleDate>();

            lastCouple = new CoupleDate();

            int maxHeight = (int)(l / ConstParameter.DefaultPosInc * 1.2); //the max num of the array the stroge the datas
            maxNum = maxHeight  + 1;
            while (source.Count < maxNum)
            {
                CoupleDate coupleDate = new CoupleDate();
                source.Add(coupleDate);
            }
        }

        public void clear()
        {
            lastCouple = new CoupleDate();

            source = null;
            GC.Collect();

            source = new List<CoupleDate>();
            while (source.Count < maxNum)
            {
                CoupleDate coupleDate = new CoupleDate();
                source.Add(coupleDate);
            }
        }

        public void mergeDates(ref List<CoupleDate> contain, ref int num, GatePacket gatePacket)
        {
            num = 0;
            int curPosX = (int)(gatePacket.tag.stampPos[0] / 1000);
            int inc = (int)(gatePacket.tag.stampInc[0] / 1000);
            int bin = (int)gatePacket.head.bin;
            int cellNum = (int)gatePacket.tag.cellNum;
            double value;

            if (bin == (int)DAQ_MEAS_MODE.TOF_PEAK)
            {
                for (int i = 0; i < cellNum && curPosX < maxPos; i++)
                {
                    value = gatePacket.measureDate[i];
                    int tmpIndex = (int)(curPosX / ConstParameter.DefaultPosInc);
                    //int index = (int)(curPosX / mergeUnit);
                    int index = (int)(curPosX / inc);
                    CoupleDate cpDate = source[index];
                    cpDate.index = index;
                    cpDate.realPos = curPosX;
                    if (value < ConstParameter.CoupleThreshold)
                        cpDate.isOK = true;
                    else
                        cpDate.isOK = false;

                    if (index == lastCouple.index)
                    {
                        if (cpDate.isOK == false || lastCouple.isOK == false)
                            lastCouple.isOK = false;
                    }
                    else
                    {
                        CoupleDate date = contain[num++];
                        //date.index = lastCouple.index;
                        //date.realPos = lastCouple.realPos;
                        //date.isOK = lastCouple.isOK;

                        ////reset
                        //lastCouple.isOK = true;
                        //lastCouple.index = index;
                        ////lastCouple.realPos = 
                        date.index = cpDate.index;
                        date.realPos = cpDate.realPos;
                        date.isOK = cpDate.isOK;

                        lastCouple.index = cpDate.index;
                        lastCouple.realPos = cpDate.realPos;
                        lastCouple.isOK = cpDate.isOK;
                    }
                    curPosX += inc;
                }
            }
        }
    }

    public class StripDate
    {
        public double tof;
        public double amp;

        public int index;// angle / 2°
        public int realPos;

        public bool isAmpReceived;//for merge, if amp is the max but tof is not arrive, when get the tof just update
        public bool isTofReceived;
        public bool isMaxInMerge;

        public StripDate(double tof, double amp)
        {
            this.tof = tof;
            this.amp = amp;
            index = 0;
            realPos = 0;
            isAmpReceived = false;
            isTofReceived = false;
            isMaxInMerge = false;
        }
    }

    public class PictureDate
    {
        public int index;
        public int realPos;
        public double[] dates;

        public PictureDate()
        {
            index = 0;
            realPos = 0;
            dates = new double[ConstParameter.BscanPointNumPrePacket];
        }
    }

    public class CoupleDate
    {
        public int index;
        public int realPos;
        public bool isOK;

        public CoupleDate()
        {
            index = 0;
            realPos = 0;
            isOK = true;
        }
    }

    public class PointDate
    {
        public double scale;
        public double value;
    }
}
