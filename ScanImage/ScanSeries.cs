using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AUT;
using Ascan;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using TChartImage = Steema.TeeChart.Tools.ChartImage;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ScanImage
{
    public class BScanSeries
    {
        protected delegate void clearCallback();
        protected clearCallback clearFunc;

        protected delegate void updatePictureCallBack();
        protected updatePictureCallBack updatePictureFunc;

        protected PictureBox pictureBox;
        private Bitmap bitmap;
        private byte[] dateArray;

        private int pictureWidth;
        private int pictureHeight;

        private int bitmapWidth;
        private int bitmapHeight;

        private int stride; // the size for one row

        private TChart tchart;
        private BscanCofig bscanCofig;

        private int sampleNum;//采样次数

        private byte[] clearArray;

        private int[] posarray=new int[1024];
        private int posindex=0;

        private int position;

        public BScanSeries(TChart tchart, BscanCofig bscanCofig)
        {
            this.tchart = tchart;
            this.bscanCofig = bscanCofig;
            initSeries();
        }

        public void initSeries()
        {
            int top = 0;
            int left = 0;
            int xMin = tchart.Axes.Bottom.CalcPosValue(bscanCofig.HorizontalAxisMin);
            int xMax = tchart.Axes.Bottom.CalcPosValue(bscanCofig.HorizontalAxisMax);
            int yMin = tchart.Axes.Left.CalcPosValue(bscanCofig.VerticalAxisMin);
            int yMax = tchart.Axes.Left.CalcPosValue(bscanCofig.VerticalAxisMax);

            sampleNum = (int)(bscanCofig.ScanLength / bscanCofig.Resolution); //采样个数

            if (pictureWidth == 0 || pictureHeight == 0)
            {
                pictureWidth = Math.Abs(xMax - xMin);
                pictureHeight = Math.Abs(yMax - yMin);
            }

            if (bitmapWidth == 0 || bitmapHeight == 0)
            {
                bitmapHeight = pictureHeight;//设置画布的高度为图片的高度
                if (sampleNum < pictureWidth)//采样个数小于图片的宽度，设置画布的长度为图片的宽度
                {
                    bitmapWidth = pictureWidth;
                }
                else
                    bitmapWidth = sampleNum;
            }

            

            if (bitmapWidth < pictureWidth)//采样个数比画布高度小
            {
                bitmapWidth = pictureWidth;
            }

            stride = 4 * ((bitmapWidth * 24 + 31) / 32);

            if (xMin < xMax)
                left = xMin;
            else
                left = xMax;
            if (yMin < yMax)
                top = yMin;
            else
                top = yMax;

            if (dateArray == null)
                dateArray = new byte[stride * bitmapHeight];
            clearArray = new byte[stride * bitmapHeight];

            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            for (int k = 0; k < clearArray.Length; k++)
                clearArray[k] = byte.MaxValue;

            bitmap = new Bitmap(bitmapWidth, bitmapHeight);

            pictureBox = new PictureBox();
            pictureBox.Width = pictureWidth;
            pictureBox.Height = pictureHeight;
            pictureBox.Location = new Point(left, top);
            //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            tchart.Controls.Add(pictureBox);
        }

        public void clear()
        {
            if (!tchart.InvokeRequired)
            {
                ArrayClear();
                    
                //if (pictureBox != null)
                    //pictureBox.Image = null;
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        public void ArrayClear()
        {
            clearArray.CopyTo(dateArray,0);
        }


        public  void add(GatePacket gatePacket, double range)
        {
            int curPos = (int)gatePacket.tag.stampPos[0];
            int num = (int)gatePacket.tag.cellNum;
            int realNum = (int)range * ConstParameter.ADSampleRate;

            //if (realNum <= ConstParameter.BscanPointNumPrePacket)
                 addNoSamplingDates(gatePacket);
            //else
                 //addSamplingDates(gatePacket, realNum);
        }

        public void addNoSamplingDates(GatePacket gatePacket)
        {
            int constNum = ConstParameter.BscanPointNumPrePacket;
            int sourceID = (int)gatePacket.head.id;
            int curPos;
            int inc;
            if (bscanCofig.AscanIndex == (int)ScanAxis.X)
            {
                curPos = (int)gatePacket.tag.stampPos[0];
                inc = (int)((gatePacket.tag.stampInc[0] / (bscanCofig.Resolution * 1000)) * bscanCofig.Resolution * 1000);
            }
            else
            {
                curPos = (int)gatePacket.tag.stampPos[1];
                inc = (int)((gatePacket.tag.stampInc[1] / (bscanCofig.Resolution * 1000)) * bscanCofig.Resolution * 1000);
            }
            int num = (int)gatePacket.tag.cellNum;
            int pktNum = num / constNum;
            byte r = 0, g = 0, b = 0;
            double amp = 0;
            int index;

            for (int k = 0; k < pktNum; k++)
            {
                int start = k * constNum;
                int pos = (int)Math.Round((curPos + inc * k) / (bscanCofig.Resolution * 1000))-2;
                //int pos = curPos + inc * k;

                //if (pos > bscanCofig.ScanLength)
                //    return;


                position = pos;

                for (int i = 0; i < pictureHeight; i++)
                {
                    index = i * constNum / pictureHeight;
                    if (index < num)
                    {
                        amp = gatePacket.measureDate[start+index];
                    }
                    else
                        amp = 0;

                    if (RGBImage.getRGB((double)amp, ref r, ref g, ref b))
                    {

                            if (bitmapWidth > sampleNum)//画布的高度大于采样个数
                            {

                                if (pos >= 0 && pos <= (sampleNum-1))
                                {
                                    

                                    for (int j = (int)(pos * bitmapWidth / bscanCofig.ScanLength); j < (pos + bscanCofig.Resolution) * bitmapWidth / bscanCofig.ScanLength; j++)
                                    {
                                        index = i * stride + 3 * j;
                                        dateArray[index] = b;
                                        dateArray[index + 1] = g;
                                        dateArray[index + 2] = r;
                                    }
                                }
 
                            }
                            else
                            {
                                int j = (int)Math.Round(curPos / bscanCofig.Resolution);//坐标规整
                                index = i * stride + 3 * (j - 1);
                                dateArray[index] = b;
                                dateArray[index + 1] = g;
                                dateArray[index + 2] = r;
                            }


                    }
                }
            }
        }

        public void addSamplingDates(GatePacket gatePacket, int realNum)
        {
            int constNum = ConstParameter.BscanPointNumPrePacket;
            int sourceID = (int)gatePacket.head.id;

            int curPos;
            int inc;
            if (bscanCofig.AscanIndex == (int)ScanAxis.X)
            {
                curPos = (int)gatePacket.tag.stampPos[0];
                inc = (int)((gatePacket.tag.stampInc[0] / (bscanCofig.Resolution * 1000)) * bscanCofig.Resolution * 1000);
            }
            else
            {
                curPos = (int)gatePacket.tag.stampPos[1];
                inc = (int)((gatePacket.tag.stampInc[1] / (bscanCofig.Resolution * 1000)) * bscanCofig.Resolution * 1000);
            }
            //int inc = (int)gatePacket.tag.stampInc[0];
            int num = (int)gatePacket.tag.cellNum;
            int pktNum = num / constNum;
            byte r = 0, g = 0, b = 0;
            double amp = 0;
            int index = 0;
            int preUnit = realNum / constNum;
            int postUnit = preUnit + 1;
            int preNum = constNum - realNum % constNum;
            int changPoint = preNum * preUnit;


            //X = (int)Math.Round((curXPos + inc * k) / (cscanCofig.XResolution * 1000));
            //Y = (int)Math.Round(curYPos / (cscanCofig.YResolution * 1000));

            for (int k = 0; k < pktNum; k++)
            {
                int start = k * constNum;
                //int pos = curPos + inc * k;
                int pos = (int)Math.Round((curPos + inc * k) / (bscanCofig.Resolution * 1000));

                if (pos > bscanCofig.ScanLength)
                    return;

                for (int i = 0; i < pictureWidth; i++)
                {
                    index = (int)(i * realNum / pictureWidth);
                    if (index < changPoint)
                        amp = gatePacket.measureDate[start + index / preUnit];
                    else
                    {
                        int count = preNum + (index - changPoint) / postUnit;
                        amp = gatePacket.measureDate[start + count];
                    }

                    if (RGBImage.getRGB((double)amp, ref r, ref g, ref b))
                    {
                        if (bitmapHeight > sampleNum)//画布的高度大于采样个数
                        {
                            for (int j = (int)(pos * bitmapHeight / bscanCofig.ScanLength); j < (pos + bscanCofig.Resolution) * bitmapHeight / bscanCofig.ScanLength; j++)
                            {
                                index = j * stride + 3 * i;
                                dateArray[index] = b;
                                dateArray[index + 1] = g;
                                dateArray[index + 2] = r;
                            }
                        }
                        else
                        {
                            int j = (int)Math.Round(pos / bscanCofig.Resolution);//坐标规整
                            index = j * stride + 3 * i;
                            dateArray[index] = b;
                            dateArray[index + 1] = g;
                            dateArray[index + 2] = r;
                        }
                    }
                }
            }
        }

        
        public void updatePicture()
        {
            
            if (!pictureBox.InvokeRequired)
            {
                if (bitmap == null)
                    bitmap = new Bitmap(bitmapWidth, bitmapHeight);

                if (position < 0 || position > (sampleNum - 1))
                {
                    ArrayClear();

                }

                BitmapData CanvasData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(dateArray, 0, ptr, bitmapWidth * bitmapHeight * 3);
                bitmap.UnlockBits(CanvasData);

                pictureBox.Image = bitmap;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                pictureBox.Invoke(updatePictureFunc);
            }
        }
    }

    public class CScanSeries
    {
        protected delegate void clearCallback();
        protected clearCallback clearFunc;

        protected delegate void updatePictureCallBack();
        protected updatePictureCallBack updatePictureFunc;

        private Bitmap bitmap;
        private byte[] dateArray;

        private int pictureWidth;
        private int pictureHeight;

        private int bitmapWidth;
        private int bitmapHeight;

        private TChart tchart;
        private CscanConfig cscanCofig;

        private int XSampleNum;//X轴采样次数
        private int YSampleNum;//Y轴采样次数

        private int xScale;//X轴缩放
        private int yScale;//Y轴缩放

        private List<String> data = new List<String>();
        private int index = 0;

        private int rcdCnt;
        private int cellnum;

        int[] rcd_posx = new int[500];
        int[] rcd_posy = new int[500];
        int[] rcd_inc = new int[500];
        int[] rcd_cell = new int[500];
        int[] rcd_X = new int[500];
        int[] rcd_Y = new int[500];

          public CScanSeries(TChart tchart, CscanConfig cscanCofig)
        {
            this.tchart = tchart;
            this.cscanCofig = cscanCofig;
            initSeries();
            this.rcdCnt = 0;
            this.cellnum = 0;
        }

        public void initSeries()
        {
            int xMin = tchart.Axes.Bottom.CalcPosValue(cscanCofig.HorizontalAxisMin);
            int xMax = tchart.Axes.Bottom.CalcPosValue(cscanCofig.HorizontalAxisMax);
            int yMin = tchart.Axes.Left.CalcPosValue(cscanCofig.VerticalAxisMin);
            int yMax = tchart.Axes.Left.CalcPosValue(cscanCofig.VerticalAxisMax);

            XSampleNum = (int)(cscanCofig.HorizontalAxisMax / cscanCofig.XResolution); //采样个数
            YSampleNum = (int)(cscanCofig.VerticalAxisMax / cscanCofig.YResolution);

            if (pictureWidth == 0 || pictureHeight == 0)
            {
                pictureWidth = Math.Abs(xMax - xMin);
                pictureHeight = Math.Abs(yMax - yMin);
            }

            if (bitmapWidth == 0 || bitmapHeight == 0)
            {
                if (pictureWidth % XSampleNum == 0)
                {
                    xScale = pictureWidth / XSampleNum;
                }
                else
                {
                    xScale = pictureWidth / XSampleNum + 1;
                }

                if (pictureHeight % YSampleNum == 0)
                {
                    yScale = pictureHeight / YSampleNum;
                }
                else
                {
                    yScale = pictureHeight / YSampleNum + 1;
                }

                bitmapWidth = xScale*XSampleNum;
                bitmapHeight = yScale*YSampleNum;
            }

            if (dateArray == null)
                dateArray = new byte[bitmapWidth * bitmapHeight * 3];

            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            bitmap = new Bitmap(bitmapWidth, bitmapHeight);
        }

        public void clear()
        {
            if (!tchart.InvokeRequired)
            {
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;
            }
            else
            {
                if (clearFunc == null)
                    clearFunc = new clearCallback(clear);

                tchart.Invoke(clearFunc);
            }
        }

        private void view(GatePacket gatePacket)
        {
           int curXPos = (int)gatePacket.tag.stampPos[0];
           int curYPos = (int)gatePacket.tag.stampPos[1];
           int num = (int)gatePacket.tag.cellNum;
           int inc = (int)gatePacket.tag.stampInc[0];

           String a = curXPos + " " + curYPos + " " + num + " " + inc;
           data.Add(a);
        }

        public void add(GatePacket gatePacket)
        {

            int sourceID = (int)gatePacket.head.id;
            int curXPos = (int)gatePacket.tag.stampPos[0];
            int curYPos = (int)gatePacket.tag.stampPos[1];
            int num = (int)gatePacket.tag.cellNum;
            byte r = 0, g = 0, b = 0;
            double amp = 0;
            int index;
            int flag;
    //        if (gatePacket.tag.stampPos[0] == 0)
   //             clear();

            /*if (gatePacket.tag.stampPos[0] <= 1000 && gatePacket.tag.stampInc[0] == 1000)
            {
                flag = 0;
            }
            else if (gatePacket.tag.stampPos[0] >= 98000 && gatePacket.tag.stampInc[0] == -1000)
            {
                flag = 1;
            }*/
            //int[] pos = new int[8192];
            
            if (this.rcdCnt < 500)
            {
            
                    rcd_posx[this.rcdCnt] = (int)gatePacket.tag.stampPos[0];
                    rcd_posy[this.rcdCnt] = (int)gatePacket.tag.stampPos[1];
                    rcd_inc[this.rcdCnt] = (int)gatePacket.tag.stampInc[0];
                    
                    rcd_cell[this.rcdCnt] = (int)gatePacket.tag.cellNum;

                    this.rcdCnt++;
                
            }
            else
            {
                flag = 1;
            }


            int X;
            int Y;
            //int X = (int)Math.Round(curXPos / cscanCofig.XResolution);//X轴坐标规整
            //int Y = (int)Math.Round(curYPos / cscanCofig.YResolution);//Y轴坐标规整
            //view(gatePacket);
            for (int k = 0; k < num; k++)
            {
                amp = gatePacket.measureDate[k];
                if (cscanCofig.ScanAxisIndex == (int)ScanAxis.X)//扫描轴为X轴
                {
                    int inc = (int)((gatePacket.tag.stampInc[0] / (cscanCofig.XResolution * 1000)) * cscanCofig.XResolution * 1000);
                    X = (int)Math.Round((double)(curXPos + inc * k) / (cscanCofig.XResolution*1000))-1;
                    Y = (int)Math.Round((double)curYPos / (cscanCofig.YResolution * 1000));
                }
                else //扫描轴为Y轴
                {
                    int inc = (int)(gatePacket.tag.stampInc[1]/(cscanCofig.YResolution*1000)*cscanCofig.YResolution*1000);
                    X = (int)Math.Round((double)curXPos / (cscanCofig.XResolution * 1000))-1;
                    Y = (int)Math.Round((double)(curYPos + inc * k) / (cscanCofig.YResolution * 1000));
                }


                 if (X > (XSampleNum-1))
                {
                    X = XSampleNum-1;
                }

                 if (Y > (YSampleNum-1))
                {
                    Y = YSampleNum-1;
                }

                if (this.rcdCnt < 500)
                {
                    rcd_X[this.rcdCnt] = X;
                    rcd_Y[this.rcdCnt] = Y;
                    this.rcdCnt++;
                }
                else
                {
                    flag = 1;
                }
                if (X >= 0 && X <= (XSampleNum - 1) && Y >= 0 && Y <= (YSampleNum - 1))
                { 
                    if (RGBImage.getRGB((double)amp, ref r, ref g, ref b))
                        {
                            for (int i = 0; i < xScale; i++)
                            {
                                for (int j = 0; j < yScale; j++)
                                {
                                
                                    index = 3 * ((Y * yScale + j) * bitmapWidth + X * xScale + i);
                                    dateArray[index] = b;
                                    dateArray[index + 1] = g;
                                    dateArray[index + 2] = r;
                                }
                            }
                        }
                }
                    
                
            }
        }


        public void updatePicture()
        {
            if (!tchart.InvokeRequired)
            {
                if (bitmap == null)
                    bitmap = new Bitmap(bitmapWidth, bitmapHeight);

                BitmapData CanvasData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(dateArray, 0, ptr, bitmapWidth * bitmapHeight * 3);
                bitmap.UnlockBits(CanvasData);

                tchart.Walls.Back.Image = bitmap;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(updatePicture);

                tchart.Invoke(updatePictureFunc);
            }
        }
    }

    public enum ScanAxis
    {
        X = 0,
        Y = 1
    }
}
