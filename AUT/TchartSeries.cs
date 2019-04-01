using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steema.TeeChart;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Steema.TeeChart.Styles;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Ascan;
using TChartHorizLine = Steema.TeeChart.Styles.HorizLine;
using TChartPoints = Steema.TeeChart.Styles.Points;
using Map = Steema.TeeChart.Styles.Map;
using TChartImage = Steema.TeeChart.Tools.ChartImage;


namespace AUT
{
    [Serializable]
    public class BaseSeries
    {
        [NonSerialized] protected TChart tchart;

        /**Delegate for the function of clear.*/
        protected delegate void clearCallback();
        /**Delegate for the function of update BScan or TOFD picture.*/
        protected delegate void updatePictureCallBack(double maxPosValue);

        [NonSerialized] protected clearCallback clearFunc;
        [NonSerialized] protected updatePictureCallBack updatePictureFunc;
        protected int maxScale;  //max yValue buffer supports

        public BaseSeries(TChart tchart)
        {
            this.tchart = tchart;
            maxScale = 0;
        }

        public virtual void initSeries() { }

        public virtual void clear() { }

        public virtual double add(GatePacket gatePacket, int boardIndex, double delay, double range) { return 0; }

        /**Just used for BScan and TOFD.*/
        public virtual void updatePicture(double maxPosValue) {}

        /**Rebuild the nonseriealized datas when read from file.*/
        public virtual bool rebuildNonSeriealizedDatas(TChart chart, double delay, double width) { return true; }

        public virtual void getRawData(ref double[] rawDataAmp, ref double[] rawDataTof, ref double PosInc)
        {
            
        }
    }

    [Serializable]
    public class StripSeries : BaseSeries
    {
        [NonSerialized] private Bitmap imageForColor;
        [NonSerialized] private Steema.TeeChart.Tools.ChartImage chartImage;
        [NonSerialized] private Steema.TeeChart.Styles.HorizLine line;
        [NonSerialized] private byte[] dateArray;
        [NonSerialized] private byte[] onePagedataArray;
        private double[] linedataArray;
        [NonSerialized] private int width;
        [NonSerialized] private int height;
        [NonSerialized] private int stride; // the size for one row
        [NonSerialized] private List<StripDate> contain;
        private double[] rawDataTof;
       
        private double thresholdForAmp;
        private double threaholdForTime;
        private double threaholdForGreenTime;
        private double threaholdForRedTime;
        private double threaholdForYellowTime;
        private double PosInc = 1;  //每个扫差点之间的距离间隔，默认为1
        private StripDateService dateService;
        private double maxValueofLine;
        
        public StripSeries(TChart tchart) 
            : base(tchart)
        {
            thresholdForAmp = 5;
            threaholdForTime = 20;
            threaholdForGreenTime = 40;
            threaholdForRedTime = 80; 
            threaholdForYellowTime = 100;
            maxValueofLine = 0;
            initSeries();

            dateService = new StripDateService(ConstParameter.PipeDiameter);
        }

        public override void initSeries()                                    
        {
            line = new TChartHorizLine();
            tchart.Series.Add(line);

            chartImage = new TChartImage();
            chartImage.ImageMode = Steema.TeeChart.Drawing.ImageMode.Stretch;
            chartImage.Active = true;
            tchart.Tools.Add(chartImage);

            width = tchart.Graphics3D.ChartXCenter * 2;
            height = tchart.Graphics3D.ChartYCenter * 2;
            //width = tchart.Width;
            //height = tchart.Height;

            stride = 4 * ((width * 24 + 31) / 32);
            int MaxPixelHight = (int)((3.1415926 * ConstParameter.PipeDiameter / ConstParameter.ScalePrePage) * height);
            if (dateArray == null)
                //dateArray = new byte[stride * ConstParameter.MaxPixelHight];
                dateArray = new byte[stride * MaxPixelHight];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            if (onePagedataArray == null)
            {
                //int realheight = (int)((ConstParameter.DistTOFD2PA + ConstParameter.ScalePrePage) / ConstParameter.ScalePrePage * height);
                //onePagedataArray = new byte[width * realheight * 3];    //store one page pix data
                onePagedataArray = new byte[width * height * 3];
            }
            for (int k = 0; k < onePagedataArray.Length; k++)
                onePagedataArray[k] = byte.MaxValue;

            if (linedataArray == null)
                linedataArray = new double[ConstParameter.MaxPixelHight];
            for (int k = 0; k < linedataArray.Length; k++)
                    linedataArray[k] = 0;

            if (rawDataTof == null)               //the dataAmp to store
                rawDataTof = new double[ConstParameter.MaxPixelHight];
            for (int k = 0; k < rawDataTof.Length; k++)
                rawDataTof[k] = 0;

            //imageForColor = new Bitmap(width, height);

            contain = new List<StripDate>();
            for (int i = 0; i < 40; i++)
            {
                StripDate date = new StripDate(-1, -1);
                contain.Add(date);
            }

            //maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
            maxScale = (int)(3.1415926 * ConstParameter.PipeDiameter);
            /*pictureBox = new PictureBox();
            pictureBox.Width = width;
            pictureBox.Height = height;
            pictureBox.Parent = tchart;
            pictureBox.Dock = DockStyle.Top;*/

            tchart.Refresh();
        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                for (int k = 0; k < onePagedataArray.Length; k++)
                    onePagedataArray[k] = byte.MaxValue;

                for (int k = 0; k < linedataArray.Length; k++)
                    linedataArray[k] = 0;

                for (int k = 0; k < rawDataTof.Length; k++)
                    rawDataTof[k] = 0;

                if (dateService != null)
                    dateService.clear();

                maxValueofLine = 0;
               // updatePicture(ConstParameter.ScalePrePage); //清除全部数据后刷一次图
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public override bool rebuildNonSeriealizedDatas(TChart chart, double delay, double range)
        {
            if (dateService == null)
                return false;

            this.tchart = chart;
            initSeries();
            mergeSource(delay, range);

            return true;
        }

         /**Show the series according to the points get from file.*/
        private void mergeSource(double delay, double range)
        {
            bool toEnd = false;
            int num = 0;
            int listIndex = 0;
            int arrayIndex = 0;
            while (!toEnd)
            {
                dateService.rebuildDates(ref contain, ref num, ref listIndex, ref arrayIndex, ref toEnd);

                int index = 0;
                while (num != 0)
                {
                    StripDate date = contain[index++];
                    double tmp = addOneStrip(date, delay, range);
                    num--;
                }
            }
        }

        public override double add(GatePacket gatePacket, int boardIndex, double delay, double range)
        {
            int num = 0;
            dateService.mergeDates(ref contain, ref num, gatePacket);
            PosInc = (int)(gatePacket.tag.stampInc[0] / 1000);
            int index = 0;
            double maxPos = 0;
            while (num != 0)
            {
                StripDate date = contain[index++];
                linedataArray[date.index] = date.amp * 100;  //add amp data to lineArray
                //if (date.amp > maxValueofLine)              //stroye the Max value in maxValueofLine
                //    maxValueofLine = date.amp;
                double tmp = addOneStrip(date, delay, range);
                if (tmp > maxPos)
                    maxPos = tmp;
                num--;
            }
            return maxPos;
        }

        private double addOneStrip(StripDate date, double delay, double range) //添加PosInc参数
        {
            double tofValue = date.tof;
            double ampValue = date.amp * 100;
            int index = date.index;
            int realPos = ConstParameter.AnglePreUnit * index;
            double tofPercent = getTofPercent(tofValue, delay, range);
            double maxPos = 0;

            rawDataTof[date.index] = date.tof;//store tof of rawdata

            maxPos = PosInc * (index + 1);
            if (ampValue < thresholdForAmp)
                return maxPos;
            else if (ampValue < threaholdForTime)
            {
                //line.Add(ampValue, realPos, Color.Black);
                //mapPoints.addAPoint(pos, ampValue);
                return ampValue;
            }
            else if (ampValue < threaholdForGreenTime)
            {
                //line.Add(ampValue, realPos, Color.Black);
                //mapPoints.addAPoint(pos, ampValue);
                maxPos = addShapes(Color.LawnGreen, index, tofPercent);
            }
            else if (ampValue < threaholdForRedTime)
            {
                //line.Add(ampValue, realPos, Color.Black);
                //mapPoints.addAPoint(pos, ampValue);
                maxPos = addShapes(Color.Red, index, tofPercent);
            }
            else if (ampValue < threaholdForYellowTime)
            {
                //line.Add(ampValue, realPos, Color.Black);
                //mapPoints.addAPoint(pos, ampValue);
                maxPos = addShapes(Color.Yellow, index, tofPercent);
            }

            return maxPos;
        }

        private double getTofPercent(double tofValue , double delay, double range)
        {
            if (tofValue < delay || tofValue > (delay + range))
                return 0;
            else
            {
                return (tofValue - delay) * 100 / range;
            }
        }

        private void showline(double maxPosValue)
        { 
            if (maxPosValue > maxScale)
                 return;

            int startindex = 0;
            int shownum = 0;
            int showlineindex = 0;
            //int shownum = (int)(ConstParameter.ScalePrePage/PosInc);
            //if(maxPosValue > ConstParameter.ScalePrePage)
                 //startindex = (int)((maxPosValue - ConstParameter.ScalePrePage)/PosInc);    //根据实际运行位置计算显示的开始索引处，实现line的滚动
            calLinestart(maxPosValue, ref startindex, ref shownum);
            for(int i = startindex; i < startindex+shownum; i++)
            {
                double showPos = showlineindex * PosInc;    //showPos是line的显示位置，即y值，即使滚动，y也是从0开始
                double ampValue = linedataArray[i];         //而ampValue则需要从linedataArray的startindex处开始
                line.Add(ampValue, showPos, Color.Black);
                showlineindex++;
            }
        }

        private void calLinestart(double maxPosValue, ref int start, ref int displayLength)
        { 
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            if (Dir == 0)   //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    start = (int)(DistTOFD2PA / PosInc);
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    start = (int)((maxPosValue - ScalePrePage) / PosInc);
                displayLength = (int)(ScalePrePage / PosInc);
            }
            else if (Dir == 1)  //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { start = 0; displayLength = (int)((maxPosValue - DistTOFD2PA)/PosInc); }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { start = (int)((maxPosValue - ScalePrePage - DistTOFD2PA) / PosInc); displayLength = (int)(ScalePrePage / PosInc); }
            }
        }

        private double addShapes(Color color, int posIndex, double value) //添加PosInc参数
        {
            int constNum = 100;
            //double defaultMinPos = ConstParameter.AnglePreUnit * posIndex;
            double defaultMinPos = PosInc * posIndex;
            if (defaultMinPos < 0)
                defaultMinPos = 0;
            //double defaultMaxPos = defaultMinPos + ConstParameter.AnglePreUnit;
            double defaultMaxPos = defaultMinPos + PosInc;
            int index;
            byte r = color.R, g = color.G, b = color.B;

            for (int j = (int)(defaultMinPos * height / ConstParameter.ScalePrePage); j < (int)(defaultMaxPos * height / ConstParameter.ScalePrePage); j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int curPos = i * constNum / width;
                    if (curPos <= value)
                    {
                        index = j * stride + 3 * i;
                        dateArray[index] = b;
                        dateArray[index + 1] = g;
                        dateArray[index + 2] = r;
                    }
                    else
                        break;
                }
            }
            return defaultMaxPos;
        }
        static int calltime = 0;
        public override void updatePicture(double maxPosValue)
        {
            int start = 0;
            int displayLength = 0;
            
            if (!tchart.InvokeRequired)
            {
                if (imageForColor == null)
                {
                    if (width == 0 || height == 0 )
                    {
                        if (calltime == 0)
                            MessageBox.Show("请更新布局！");
                        calltime++;
                        return;
                    }
                    imageForColor = new Bitmap(width, height);
                }
                if (maxPosValue > maxScale)
                    return;

                /*int startColumn = (int)(maxPosValue - ConstParameter.ScalePrePage) * height / ConstParameter.ScalePrePage;
                int start = startColumn * stride;*/
                calStartLength(maxPosValue, ref start, ref displayLength);
                Array.Copy(dateArray, start, onePagedataArray, 0, displayLength);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(onePagedataArray, 0, ptr, width * height * 3);
                imageForColor.UnlockBits(CanvasData);

                //pictureBox.Image = imageForColor;
                imageForColor.RotateFlip(RotateFlipType.Rotate180FlipX);
                chartImage.Image = imageForColor;

                line.Clear();           //每一次刷图前都将line中的点清掉
                showline(maxPosValue);  //绘制带状图中的包络线
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                //pictureBox.Invoke(updatePictureFunc, maxPosValue);
                tchart.Invoke(updatePictureFunc, maxPosValue);
            }
        }


        private void calStartLength(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            //int start = 0;
            int displayColumn = 0;
            //int displayLength = 0;

            if (Dir == 0)    //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                start = startColumn * stride;
                displayLength = width * height * 3;
            }
            else if (Dir == 1)   //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                start = startColumn * stride;
                displayLength = displayColumn * stride;
            }
        }

        public double getMaxValueofLine(double StartPos, double EndPos) //get the maxvalue of this range
        {
            int startIndex = (int)(StartPos / PosInc);
            int endIndex = (int)(EndPos / PosInc);
            double tmpvalue = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (linedataArray[i] > tmpvalue)
                    tmpvalue = linedataArray[i];
            }
            if (tmpvalue > 1 || tmpvalue < -1)
                return 0;
            return Math.Abs(tmpvalue);
        }

        public override void getRawData(ref double[] rawDataAmp, ref double[] rawDataTof, ref double PosInc)
        {
            rawDataAmp = this.linedataArray;
            rawDataTof = this.rawDataTof;
            PosInc = this.PosInc;
        }
    }

    //[Serializable]
    //public class BScanSeries : BaseSeries
    //{
    //    [NonSerialized] protected PictureBox pictureBox;
    //    [NonSerialized] private Bitmap imageForColor;
    //    [NonSerialized] private byte[] dateArray;
    //    [NonSerialized] private int width;
    //    [NonSerialized] private int height;
    //    [NonSerialized] private int stride; // the size for one row
    //    [NonSerialized] private List<PictureDate> contain;

    //    private PictureDateService dateService;

    //    public BScanSeries(TChart tchart)
    //        : base(tchart)
    //    {
    //        initSeries();
    //    }

    //    public override void initSeries()
    //    {
    //        width = tchart.Graphics3D.ChartXCenter * 2;
    //        height = tchart.Graphics3D.ChartYCenter * 2;

    //        stride = 4 * ((width * 24 + 31) / 32);

    //        if (dateArray == null)
    //            dateArray = new byte[stride * ConstParameter.MaxPixelHight];

    //        for (int k = 0; k < dateArray.Length; k++)
    //            dateArray[k] = byte.MaxValue;

    //        imageForColor = new Bitmap(width, height);

    //        pictureBox = new PictureBox();
    //        pictureBox.Width = width - 1;
    //        pictureBox.Height = height - 1;
    //        pictureBox.Parent = tchart;
    //        pictureBox.Location = new Point(0, 0);
    //        //pictureBox.Dock = DockStyle.Top;

    //        dateService = new PictureDateService(100);

    //        contain = new List<PictureDate>();
    //        for (int i = 0; i < 40; i++)
    //            contain.Add(new PictureDate());

    //        maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
    //    }

    //    public override void clear()
    //    {
    //        if (!tchart.InvokeRequired)
    //        {
    //            for (int k = 0; k < dateArray.Length; k++)
    //                dateArray[k] = byte.MaxValue;

    //            if (pictureBox != null)
    //                pictureBox.Image = null;

    //            if (dateService != null)
    //                dateService.clear();
    //        }
    //        else
    //        {
    //            if (clearFunc == null)
    //                clearFunc = new clearCallback(clear);

    //            tchart.Invoke(clearFunc);
    //        }
    //    }

    //    public override double add(GatePacket gatePacket, int boardIndex, double delay, double range)
    //    {
    //        int curPos = (int)gatePacket.tag.stampPos[0];
    //        int realNum = (int)range * ConstParameter.ADSampleRate;

    //        if (gatePacket.tag.stampPos[0] == 0)  //this conditions to clear the bscan map?
    //            clear();

    //        int num = 0;
    //        dateService.mergeDates(ref contain, ref num, gatePacket);

    //        int index = 0;
    //        double maxPos = 0;
    //        while (num != 0)
    //        {
    //            PictureDate date = contain[index++];
    //            double tmp = 0;
    //            if (realNum <= ConstParameter.BscanPointNumPrePacket)
    //                tmp = addNoSamplingDates(date, realNum);
    //            else
    //                tmp = addSamplingDates(date, realNum);

    //            if (tmp > maxPos)
    //                maxPos = tmp;
    //            num--;
    //        }
    //        return maxPos;
    //    }

    //    private double addNoSamplingDates(PictureDate date, int num)
    //    {
    //        int constNum = ConstParameter.BscanPointNumPrePacket;
    //        int posIndex = date.index;
    //        double minPos = ConstParameter.AnglePreUnit * posIndex;
    //        double maxPos = minPos + ConstParameter.AnglePreUnit;
    //        byte r = 0, g = 0, b = 0;
    //        int index = 0;
    //        double amp = 0;

    //        for (int i = 0; i < width; i++)
    //        {
    //            index = i * constNum / width;
    //            if (index < num)
    //                amp = date.dates[index];
    //            else
    //                amp = 0;

    //            if (RGBImage.getRGB((double)amp, ref r, ref g, ref b))
    //            {
    //                for (int j = (int)(minPos * height / ConstParameter.ScalePrePage); j < (int)(maxPos * height / ConstParameter.ScalePrePage); j++)
    //                {
    //                    index = j * stride + 3 * i;
    //                    dateArray[index] = b;
    //                    dateArray[index + 1] = g;
    //                    dateArray[index + 2] = r;
    //                }
    //            }
    //        }
    //        return maxPos;
    //    }

    //    private double addSamplingDates(PictureDate date, int num)
    //    {
    //        int constNum = ConstParameter.BscanPointNumPrePacket;
    //        int posIndex = date.index;
    //        double minPos = ConstParameter.AnglePreUnit * posIndex;
    //        double maxPos = minPos + ConstParameter.AnglePreUnit;
    //        int preUnit = num / constNum;
    //        int postUnit = preUnit + 1;
    //        int preNum = constNum - num % constNum;
    //        int changPoint = preNum * preUnit;
    //        byte r = 0, g = 0, b = 0;
    //        int index = 0;
    //        double amp = 0;

    //        for (int i = 0; i < width; i++)
    //        {
    //            index = i * num / width;
    //            if (index < changPoint)
    //                amp = date.dates[index / preUnit];
    //            else
    //            {
    //                int count = preNum + (index - changPoint) / postUnit;
    //                amp = date.dates[count];
    //            }

    //            if (RGBImage.getRGB((double)amp, ref r, ref g, ref b))
    //            {
    //                for (int j = (int)(minPos * height / ConstParameter.ScalePrePage); j < (int)(maxPos * height / ConstParameter.ScalePrePage); j++)
    //                {
    //                    index = j * stride + 3 * i;
    //                    dateArray[index] = b;
    //                    dateArray[index + 1] = g;
    //                    dateArray[index + 2] = r;
    //                }
    //            }
    //        }
    //        return maxPos;
    //    }

    //    public override void updatePicture(double maxPosValue)
    //    {
    //        if (!pictureBox.InvokeRequired)
    //        {
    //            if (imageForColor == null)
    //                imageForColor = new Bitmap(width, height);
    //            if (maxPosValue > maxScale)
    //                return;

    //            int startColumn = (int)(maxPosValue - ConstParameter.ScalePrePage) * height / ConstParameter.ScalePrePage;
    //            int start = startColumn * stride;

    //            BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
    //            IntPtr ptr = CanvasData.Scan0;
    //            Marshal.Copy(dateArray, start, ptr, width * height * 3);
    //            imageForColor.UnlockBits(CanvasData);

    //            pictureBox.Image = imageForColor;
    //        }
    //        else
    //        {
    //            if (updatePictureFunc == null)
    //                updatePictureFunc = new updatePictureCallBack(updatePicture);

    //            pictureBox.Invoke(updatePictureFunc, maxPosValue);
    //        }
    //    }

    //    /**Rebuild the nonseriealized datas when read from file.*/
    //    public override bool rebuildNonSeriealizedDatas(TChart chart, double delay, double range)
    //    {
    //        if (dateService == null)
    //            return false;

    //        this.tchart = chart;
    //        initSeries();
    //        mergeSource(range);

    //        return true;
    //    }

    //    private void mergeSource(double range)
    //    {
    //        bool toEnd = false;
    //        int num = 0;
    //        int sourceIndex = 0;
    //        int realNum = (int)range * ConstParameter.ADSampleRate;

    //        while (!toEnd)
    //        {
    //            dateService.rebuildDates(ref contain, ref num, ref sourceIndex, ref toEnd);

    //            int index = 0;
    //            while (num != 0)
    //            {
    //                PictureDate date = contain[index++];
    //                double tmp = 0;
    //                if (realNum <= ConstParameter.BscanPointNumPrePacket)
    //                    tmp = addNoSamplingDates(date, realNum);
    //                else
    //                    tmp = addSamplingDates(date, realNum);

    //                num--;
    //            }
    //        }
    //    }
    //}

    [Serializable]
    public class BScanSeries : BaseSeries
    {
        [NonSerialized]
        protected PictureBox pictureBox;
        [NonSerialized]
        private Bitmap imageForColor;
        [NonSerialized]
        private byte[] dateArray;
        [NonSerialized]
        private byte[] onePagedataArray;
        [NonSerialized]
        private int width;
        [NonSerialized]
        private int height;
        [NonSerialized]
        private int stride; // the size for one row
        private double[] rawDataAmp;
        private double PosInc = 1;

        private PicturePoints picturePoints;

        public BScanSeries(TChart tchart)
            : base(tchart)
        {
            initSeries();

            picturePoints = new PicturePoints();
        }

        public override void initSeries()
        {
            width = tchart.Graphics3D.ChartXCenter * 2;
            height = tchart.Graphics3D.ChartYCenter * 2;

            stride = 4 * ((width * 24 + 31) / 32);
            int MaxPixelHight = (int)((3.1415926 * ConstParameter.PipeDiameter / ConstParameter.ScalePrePage) * height);
            if (dateArray == null)
                //dateArray = new byte[stride * ConstParameter.MaxPixelHight];
                dateArray = new byte[stride * MaxPixelHight];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            if (onePagedataArray == null)
                onePagedataArray = new byte[width * height * 3];
            for (int k = 0; k < onePagedataArray.Length; k++)
                onePagedataArray[k] = byte.MaxValue;

            if (rawDataAmp == null)
                rawDataAmp = new double[ConstParameter.MaxPixelHight * ConstParameter.BscanPointNumPrePacket];
            for (int k = 0; k < rawDataAmp.Length; k++)
                rawDataAmp[k] = 0;

            imageForColor = new Bitmap(width, height);

            pictureBox = new PictureBox();
            pictureBox.Width = width - 1;
            pictureBox.Height = height - 1;
            //pictureBox.BackColor = Color.Red;
            pictureBox.Parent = tchart;
            pictureBox.Location = new Point(0, 0);

            //maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
            maxScale = (int)(3.1415926 * ConstParameter.PipeDiameter);

        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                for (int k = 0; k < onePagedataArray.Length; k++)
                    onePagedataArray[k] = byte.MaxValue;

                for (int k = 0; k < rawDataAmp.Length; k++)
                    rawDataAmp[k] = 0;

                if (picturePoints != null)
                    picturePoints.clear();

                //updatePicture(ConstParameter.ScalePrePage);//数据重置后刷一次图
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        public override double add(GatePacket gatePacket, int boardIndex, double delay, double range)
        {
            int constNum = ConstParameter.BscanPointNumPrePacket;
            int sourceID = (int)gatePacket.head.id;
            int curPos = (int)gatePacket.tag.stampPos[0] / 1000;  //pos to divid 1000
            PosInc = (int)(gatePacket.tag.stampInc[0] / 1000);
            int PosIndex = (int)(curPos / PosInc);
            int totalnum = (int)gatePacket.tag.cellNum;
            int num = (int)(totalnum / constNum);            //the num of ascan in a packet
            if (curPos > ConstParameter.MaxPixelHight)      //maxScale   to  MaxPixelHight
                return ConstParameter.MaxPixelHight;
            byte r = 0, g = 0, b = 0;
            double amp = 0;
            int index;

            for (int k = 0; k < num; k++)
            {
                for(int j = 0; j < constNum; j++)
                    rawDataAmp[PosIndex * constNum + j] = gatePacket.measureDate[k * constNum + j];

                PosIndex++;
            }

                //if (gatePacket.tag.stampPos[0] == 0)
                //    clear();
            for (int cyclenum = 0; cyclenum < num; cyclenum++)
            {
                for (int i = 0; i < width; i++)
                {
                    index = i * 256 / width;    //将256个数据显示在width个像素宽度里面
                    amp = gatePacket.measureDate[cyclenum * constNum + index];

                    if (picturePoints != null)
                        picturePoints.addPoint(curPos, i, amp);

                    if (RGBImage.getRGB((double)amp, ref r, ref g, ref b))
                    {
                        for (int j = curPos * height / ConstParameter.ScalePrePage; j < (curPos + 1) * height / ConstParameter.ScalePrePage; j++)
                        {
                            int dataindex = j * stride + 3 * i;     //index to dataindex
                            dateArray[dataindex] = b;
                            dateArray[dataindex + 1] = g;
                            dateArray[dataindex + 2] = r;
                        }
                    }
                }
                curPos++;       //cyclenum循环完一次，curPos加1，开始载入下一行的数据
            }

            return curPos;
        }

        public override void updatePicture(double maxPosValue)
        {
            int start = 0;
            int displayLength = 0;
            if (!tchart.InvokeRequired)
            {
                if (imageForColor == null)
                    imageForColor = new Bitmap(width, height);
                if (maxPosValue > maxScale)     //maxScale为运动最大距离，此时为200*6=1200mm
                    return;

                calStartLength(maxPosValue, ref start, ref displayLength);
                Array.Copy(dateArray, start, onePagedataArray, 0, displayLength);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(onePagedataArray, 0, ptr, width * height * 3);
                imageForColor.UnlockBits(CanvasData);

                pictureBox.Image = imageForColor;
            } 
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                tchart.Invoke(updatePictureFunc, maxPosValue);
            }
        }

        private void calStartLength(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            //int start = 0;
            int displayColumn = 0;
            //int displayLength = 0;

            if (Dir == 0)    //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                start = startColumn * stride;
                displayLength = width * height * 3;
            }
            else if (Dir == 1)   //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                start = startColumn * stride;
                displayLength = displayColumn * stride;
            }
        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public override bool rebuildNonSeriealizedDatas(TChart chart, double delay, double width)
        {
            this.tchart = chart;
            initSeries();
            showSeries();

            return true;
        }

        /**Show the series according to the points get from file.*/
        private void showSeries()
        {
            int columnIndex, rowIndex, index;
            double amp;
            byte r = 0, g = 0, b = 0;
            if (picturePoints == null)
            {
                MessageShow.show("The points to show is null", "用于显示的点为null");
                return;
            }

            foreach (LineDates lineDates in picturePoints.dates)
            {
                if (!lineDates.isUsed)
                    continue;

                for (int i = 0; i < width; i++)
                {
                    rowIndex = i * 256 / width;
                    columnIndex = lineDates.columnIndex;
                    amp = lineDates.lines[rowIndex];

                    if (RGBImage.getRGB((double)amp / 100, ref r, ref g, ref b))
                    {
                        for (int j = columnIndex * height / 100; j < (columnIndex + 1) * height / 100; j++)
                        {
                            index = j * stride + 3 * i;
                            dateArray[index] = b;
                            dateArray[index + 1] = g;
                            dateArray[index + 2] = r;
                        }
                    }
                }
            }
        }

        public override void getRawData(ref double[] rawDataAmp, ref double[] rawDataTof, ref double PosInc)
        {
            rawDataAmp = this.rawDataAmp;
            rawDataTof = null;
            PosInc = this.PosInc;
        }
    }

    [Serializable]
    public class TOFDSeries : BaseSeries
    {
        [NonSerialized]
        protected PictureBox pictureBox;
        [NonSerialized]
        private Bitmap imageForColor;
        [NonSerialized]
        private byte[] dateArray;
        [NonSerialized]
        private byte[] onePagedataArray;
        [NonSerialized]
        private int width;
        [NonSerialized]
        private int height;
        [NonSerialized]
        private int stride; // the size for one row
        private double[] rawDataAmp;
        private double PosInc = 1;

        private PicturePoints picturePoints;

        public TOFDSeries(TChart tchart)
            : base(tchart)
        {
            initSeries();

            picturePoints = new PicturePoints();
        }

        public override void initSeries()
        {
            width = tchart.Graphics3D.ChartXCenter * 2;
            height = tchart.Graphics3D.ChartYCenter * 2;
            //width = tchart.Width;
            //height = tchart.Height;

            stride = 4 * ((width * 24 + 31) / 32);
            int MaxPixelHight = (int)((3.1415926 * ConstParameter.PipeDiameter / ConstParameter.ScalePrePage) * height);
            if (dateArray == null)
                //dateArray = new byte[stride * ConstParameter.MaxPixelHight];
                dateArray = new byte[stride * MaxPixelHight];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            if (onePagedataArray == null)
                onePagedataArray = new byte[width * height * 3]; 
            for (int k = 0; k < onePagedataArray.Length; k++)
                onePagedataArray[k] = byte.MaxValue;

            if (rawDataAmp == null)
                rawDataAmp = new double[ConstParameter.MaxPixelHight * ConstParameter.BscanPointNumPrePacket];
            for (int k = 0; k < rawDataAmp.Length; k++)
                rawDataAmp[k] = 0;

            imageForColor = new Bitmap(width, height);

            pictureBox = new PictureBox();
            pictureBox.Width = width - 1;
            pictureBox.Height = height - 1;
            //pictureBox.BackColor = Color.Red;
            pictureBox.Parent = tchart;
            pictureBox.Location = new Point(0, 0);

            //maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
            maxScale = (int)(3.1415926 * ConstParameter.PipeDiameter);
        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                for (int k = 0; k < onePagedataArray.Length; k++)
                    onePagedataArray[k] = byte.MaxValue;

                for (int k = 0; k < rawDataAmp.Length; k++)
                    rawDataAmp[k] = 0;

                if (picturePoints != null)
                    picturePoints.clear();

                //updatePicture(ConstParameter.ScalePrePage);
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        public override double add(GatePacket gatePacket, int boardIndex, double delay, double range)
        {
            int constNum = ConstParameter.TOFDPointNumPrePacket;
            int sourceID = (int)gatePacket.head.id;
            int curPos = (int)gatePacket.tag.stampPos[0] / 1000;  //pos to divid 1000
            PosInc = (int)(gatePacket.tag.stampInc[0] / 1000);
            int PosIndex = (int)(curPos / PosInc);
            int totalnum = (int)gatePacket.tag.cellNum;
            int num = (int)(totalnum / constNum);            //the num of ascan in a packet
            if (curPos > ConstParameter.MaxPixelHight)      //maxScale   to  MaxPixelHight
                return ConstParameter.MaxPixelHight;
            byte r = 0, g = 0, b = 0;
            double amp = 0;
            int index;

            for (int k = 0; k < num; k++)
            {
                for (int j = 0; j < constNum; j++)
                    rawDataAmp[PosIndex * constNum + j] = gatePacket.measureDate[k * constNum + j];

                PosIndex++;
            }

            //if (gatePacket.tag.stampPos[0] == 0)
            //    clear();
            for (int cyclenum = 0; cyclenum < num; cyclenum++)
            { 
                for (int i = 0; i < width; i++)
                {
                    index = i * 256 / width;    //将256个数据显示在width个像素宽度里面
                        amp = gatePacket.measureDate[cyclenum * constNum + index];

                    if (picturePoints != null)
                        picturePoints.addPoint(curPos, i, amp);

                    if (GrayImage.getRGB((double)amp, ref r, ref g, ref b))
                    {
                        for (int j = curPos * height / ConstParameter.ScalePrePage; j < (curPos + 1) * height / ConstParameter.ScalePrePage; j++)
                        {
                            int dataindex = j * stride + 3 * i;     //index to dataindex
                            dateArray[dataindex] = b;
                            dateArray[dataindex + 1] = g;
                            dateArray[dataindex + 2] = r;
                        }
                    }
                }
                curPos++;       //cyclenum循环完一次，curPos加1，开始载入下一行的数据
            }

            return curPos;
        }

        public override void updatePicture(double maxPosValue)
        {
            /*int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            int displayColumn = 0;*/
            int start = 0;
            int displayLength = 0;
            if (!tchart.InvokeRequired)
            {
                if (imageForColor == null)
                    imageForColor = new Bitmap(width, height);
                if (maxPosValue > maxScale)     //maxScale为运动最大距离，此时为200*6=1200mm
                    return;

                calStartLength(maxPosValue, ref start, ref displayLength);
                Array.Copy(dateArray, start, onePagedataArray, 0, displayLength);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(onePagedataArray, 0, ptr, width * height * 3);
                imageForColor.UnlockBits(CanvasData);

                pictureBox.Image = imageForColor;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                tchart.Invoke(updatePictureFunc, maxPosValue);
            }
        }

        private void calStartLength(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            //int start = 0;
            int displayColumn = 0;
            //int displayLength = 0;

            if (Dir == 0)    //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                start = startColumn * stride;
                displayLength = displayColumn * stride;
            }
            else if (Dir == 1)   //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                start = startColumn * stride;
                displayLength = width * height * 3;
            }
        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public override bool rebuildNonSeriealizedDatas(TChart chart, double delay, double width)
        {
            this.tchart = chart;
            initSeries();
            showSeries();

            return true;
        }

        /**Show the series according to the points get from file.*/
        private void showSeries()
        {
            int columnIndex, rowIndex, index;
            double amp;
            byte r = 0, g = 0, b = 0;
            if (picturePoints == null)
            {
                MessageShow.show("The points to show is null", "用于显示的点为null");
                return;
            }

            foreach (LineDates lineDates in picturePoints.dates)
            {
                if (!lineDates.isUsed)
                    continue;

                for (int i = 0; i < width; i++)
                {
                    rowIndex = i * 256 / width;
                    columnIndex = lineDates.columnIndex;
                    amp = lineDates.lines[rowIndex];

                    if (GrayImage.getRGB((double)amp / 100, ref r, ref g, ref b))
                    {
                        for (int j = columnIndex * height / 100; j < (columnIndex + 1) * height / 100; j++)
                        {
                            index = j * stride + 3 * i;
                            dateArray[index] = b;
                            dateArray[index + 1] = g;
                            dateArray[index + 2] = r;
                        }
                    }
                }
            }
        }

        public override void getRawData(ref double[] rawDataAmp, ref double[] rawDataTof, ref double PosInc)
        {
            rawDataAmp = this.rawDataAmp;
            rawDataTof = null;
            PosInc = this.PosInc;
        }
    }


    [Serializable]
    public class MergeSeries : BaseSeries
    {
        [NonSerialized] protected PictureBox pictureBox;
        [NonSerialized] private Bitmap imageForColor;
        [NonSerialized] private byte[] dateArray;
        [NonSerialized] private byte[] onePagedataArray;
        [NonSerialized] private int width;
        [NonSerialized] private int height;
        [NonSerialized] private int stride; // the size for one row
        [NonSerialized]private List<CoupleDate> contain;        
        private double[] rawDataAmp;
        private double PosInc = 1;

        private CoupleDateService dateService;

        public MergeSeries(TChart tchart)
            : base(tchart)
        {
            initSeries();
        }

        public override void initSeries()
        {
            width = tchart.Graphics3D.ChartXCenter * 2;
            height = tchart.Graphics3D.ChartYCenter * 2;

            stride = 4 * ((width * 24 + 31) / 32);
            int MaxPixelHight = (int)((3.1415926 * ConstParameter.PipeDiameter / ConstParameter.ScalePrePage) * height);
            if (dateArray == null)
                //dateArray = new byte[stride * ConstParameter.MaxPixelHight];
                dateArray = new byte[stride * MaxPixelHight];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            if (onePagedataArray == null)
                onePagedataArray = new byte[width * height * 3];
            for (int k = 0; k < onePagedataArray.Length; k++)
                onePagedataArray[k] = byte.MaxValue;

            if (rawDataAmp == null)
                rawDataAmp = new double[ConstParameter.MaxPixelHight];
            for (int k = 0; k < rawDataAmp.Length; k++)
                rawDataAmp[k] = 0;

            imageForColor = new Bitmap(width, height);

            pictureBox = new PictureBox();
            pictureBox.Width = width - 1;
            pictureBox.Height = height - 1;
            pictureBox.Parent = tchart;
            pictureBox.Location = new Point(0, 0);
            //pictureBox.Dock = DockStyle.Top;

            dateService = new CoupleDateService(ConstParameter.PipeDiameter);

            contain = new List<CoupleDate>();
            for (int i = 0; i < 40; i++)
                contain.Add(new CoupleDate());

            //maxScale = ConstParameter.ScalePrePage * (ConstParameter.MaxPixelHight - 1) / height;
            maxScale = (int)(3.1415926 * ConstParameter.PipeDiameter);

        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                //if (mapPoints != null)
                    //mapPoints.clear();
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                for (int k = 0; k < onePagedataArray.Length; k++)
                    onePagedataArray[k] = byte.MaxValue;

                for (int k = 0; k < rawDataAmp.Length; k++)
                    rawDataAmp[k] = 0;

                if (dateService != null)
                    dateService.clear();

                //updatePicture(ConstParameter.ScalePrePage); //清除全部数据后刷一次图
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        public override double add(GatePacket gatePacket, int boardIndex, double delay, double range)
        {
            int curPos = (int)gatePacket.tag.stampPos[0];
            PosInc = (int)(gatePacket.tag.stampInc[0] / 1000);
            if (gatePacket.tag.stampPos[0] == 0)  //this conditions to clear the bscan map?
                clear();

            int num = 0;
            dateService.mergeDates(ref contain, ref num, gatePacket);

            int index = 0;
            double maxPos = 0;
            while (num != 0)
            {
                CoupleDate date = contain[index++];
                double tmp = addCoupleDates(date);

                if (tmp > maxPos)
                    maxPos = tmp;
                num--;
            }
            return maxPos;
        }

        private double addCoupleDates(CoupleDate date)
        {
            int posIndex = date.index;
            double tmpMinPos = ConstParameter.AnglePreUnit * posIndex;
            double tmpMaxPos = tmpMinPos + ConstParameter.AnglePreUnit;
            byte r = 0, g = 0, b = 0;
            int index = 0;           

            if (date.isOK)
            {
                rawDataAmp[date.index] = 1;
                r = Color.Green.R;
                g = Color.Green.G;
                b = Color.Green.B;
            }
            else
            {
                rawDataAmp[date.index] = 0;
                r = Color.Red.R;
                g = Color.Red.G;
                b = Color.Red.B;
            }

            for (int i = 0; i < width; i++)
            {

                for (int j = (int)(tmpMinPos * height / ConstParameter.ScalePrePage); j < (int)(tmpMaxPos * height / ConstParameter.ScalePrePage); j++)
                    {
                        index = j * stride + 3 * i;
                        dateArray[index] = b;
                        dateArray[index + 1] = g;
                        dateArray[index + 2] = r;
                    }
            }
            return tmpMaxPos;
        }

        public override void updatePicture(double maxPosValue)
        {
            int start = 0;
            int displayLength = 0;
            if (!pictureBox.InvokeRequired)
            {
                if (imageForColor == null)
                    imageForColor = new Bitmap(width, height);
                if (maxPosValue > maxScale)
                    return;

                /*int startColumn = (int)(maxPosValue - ConstParameter.ScalePrePage) * height / ConstParameter.ScalePrePage;
                int start = startColumn * stride;*/
                calStartLength(maxPosValue, ref start, ref displayLength);
                Array.Copy(dateArray, start, onePagedataArray, 0, displayLength);

                BitmapData CanvasData = imageForColor.LockBits(new System.Drawing.Rectangle(0, 0, imageForColor.Width, imageForColor.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(dateArray, start, ptr, width * height * 3);
                imageForColor.UnlockBits(CanvasData);

                pictureBox.Image = imageForColor;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                pictureBox.Invoke(updatePictureFunc, maxPosValue);
            }
        }

        private void calStartLength(double maxPosValue, ref int start, ref int displayLength)
        {
            int Dir = 0;
            int ScalePrePage = ConstParameter.ScalePrePage;
            double DistTOFD2PA = ConstParameter.DistTOFD2PA;
            int startColumn = 0;
            //int start = 0;
            int displayColumn = 0;
            //int displayLength = 0;

            if (Dir == 0)    //Dir++
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                    startColumn = (int)DistTOFD2PA * height / ScalePrePage;
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                    startColumn = (int)(maxPosValue - ScalePrePage) * height / ScalePrePage;

                start = startColumn * stride;
                displayLength = width * height * 3;
            }
            else if (Dir == 1)   //Dir--
            {
                if (maxPosValue < DistTOFD2PA)
                    return;
                else if ((maxPosValue >= DistTOFD2PA) && (maxPosValue < (ScalePrePage + DistTOFD2PA)))
                { startColumn = 0; displayColumn = (int)(maxPosValue - DistTOFD2PA) * height / ScalePrePage; }
                else if (maxPosValue >= ScalePrePage + DistTOFD2PA)
                { startColumn = (int)(maxPosValue - ScalePrePage - DistTOFD2PA) * height / ScalePrePage; displayColumn = height; }

                start = startColumn * stride;
                displayLength = displayColumn * stride;
            }
        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public override bool rebuildNonSeriealizedDatas(TChart chart, double delay, double width)
        {
            //if (mapPoints == null)
                //return false;

            this.tchart = chart;
            initSeries();
            showSeries();

            return true;
        }

        /**Show the series according to the points get from file.*/
        private void showSeries()
        {
           // if (mapPoints == null)
            {
                MessageShow.show("The points to show is null", "用于显示的点为null");
                return;
            }

            //mapPoints.ShowInChart(tchart, null, map, null);
        }

        public override void getRawData(ref double[] rawDataAmp, ref double[] rawDataTof, ref double PosInc)
        {
            rawDataAmp = this.rawDataAmp;
            rawDataTof = null;
            PosInc = this.PosInc;
        }
    }
}
 