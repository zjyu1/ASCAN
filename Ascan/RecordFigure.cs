using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace Ascan
{
    public partial class FormRecordFigure_AScan : Form
    {
        public bool start;

        private double tChart_y1, tChart_y2, tChart_x;

        private GateType selectedGate;

        private DataType gateDataType;

        public double velocity; 

        public void GetVelocity(double value)
        {
             velocity = value;
        }
        
        //

        private int totalrow;
        private int curentrow;

        private Bitmap bitmap;

        private int width;
        private int height;
        private int stride;

        private byte[] dateArray;


        public FormRecordFigure_AScan()
        {
            InitializeComponent();
            

            velocity = 5.89;    //steel velocity mm/us
            gateDataType =DataType.Amp;
            selectedGate = GateType.I;
            ResetTchart();
            tChartAscan.Header.Text= "Gate I — Amp — velocity:" + velocity + "mm/us";
            start = false;

            //
            int a = tChartBscan.Axes.Left.CalcSizeValue(10);

            int b = tChartBscan.Axes.Left.CalcPosValue(10);

            double c = tChartBscan.Axes.Left.CalcPosPoint(10);


            width = 1000;
            height = 1000;
            stride = 4 * ((width * 24 + 31) / 32);

            curentrow = 0;
            totalrow =(int) (height) / 3;

            tChartBscan.Axes.Left.SetMinMax(0, totalrow);
            tChartBscan.Axes.Bottom.SetMinMax(0, 100);

            dateArray = new byte[stride * height];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            bitmap = new Bitmap(width, height);

            

        }



        private void FormRecordFigure_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        #region  AScan Part


        public void drawLineRecord(float[] tof, float[] amp)
        {
            float[] gateData;

            switch (gateDataType)
            {
                case DataType.Amp:
                    gateData = amp;
                    break;

                case DataType.Tof:
                    gateData = tof;
                    break;

                default:
                    MessageShow.show("Error:Gate data type failed!", "错误：门数据类型错误!");
                    return;
            }

            if (selectedGate == GateType.I || selectedGate == GateType.C || selectedGate == GateType.B || selectedGate == GateType.A)
            {
                //DrawSingleGateData(gateData)
                int gateIndex = (int)selectedGate;

                Draw(gateData[gateIndex]);
                //lineRecord.Add(gateData[gateIndex]);
            }
            else if (selectedGate == GateType.AI || selectedGate == GateType.BA || selectedGate == GateType.BI || selectedGate == GateType.CI)
            {
                //drawDoubleGateData(gateData)
                //Get a double-digit ten digit
                int gateIndex1 = (int)selectedGate / 10;

                //Get a double-digit single digit
                int gateIndex2 = (int)selectedGate % 10;

                //Take the absolute value
                float data = System.Math.Abs(gateData[gateIndex1] - gateData[gateIndex2]);

                //different mode  then  diffe  data type
                if (gateDataType == DataType.Tof)
                {
                    data = data * (float)velocity;
                }
                Draw(data);
                //lineRecord.Add(data);
            }
            else
            {
                MessageShow.show("Error:Draw gate data failed!", "错误：画门内数据失败!");
                return;
            }


        }

        int a = 0;
        private void Draw(float data)
        {
            if (start == true)
            {
                if (a == 999)
                {
                    lineRecord.Add(data);
                    lineRecord.Clear();
                    a = 0;
                    
                }
                else
                {
                    lineRecord.Add(data);
                    a++;
                }
            }
        }


        private void ResetTchart()
        {
            lineRecord.Clear();

            switch (gateDataType)
            {
                case DataType.Amp:
                    {
                        tChartAscan.Axes.Left.SetMinMax(0, 1);
                        tChartAscan.Axes.Left.Title.Text=  "%";
                        tChartAscan.Axes.Bottom.SetMinMax(0, 1000);
                        tChartAscan.Axes.Bottom.Title.Text = "us";
                    }
                    break;

                case DataType.Tof:
                    {
                        if (selectedGate == GateType.I || selectedGate == GateType.C || selectedGate == GateType.B || selectedGate == GateType.A)
                        {
                            //us
                            tChartAscan.Axes.Left.SetMinMax(tChart_y1, tChart_y2);
                            tChartAscan.Axes.Left.Title.Text = "us";
                            //us
                            tChartAscan.Axes.Bottom.SetMinMax(0, 1000);
                            tChartAscan.Axes.Bottom.Title.Text = "us";
                        }
                        else
                        {//double gate mode
                            //mm   |  velocity-mm/us
                            tChartAscan.Axes.Left.SetMinMax(tChart_y1 * velocity, tChart_y2 * velocity);
                            tChartAscan.Axes.Left.Title.Text = "mm";
                            //us
                            tChartAscan.Axes.Bottom.SetMinMax(0, 1000);
                            tChartAscan.Axes.Bottom.Title.Text = "us";
                        }
                    }
                    break;

                default:
                    MessageBox.Show("坐标轴初始化失败");
                    break;
            }

        }



        //获得某点坐标
        //private void tChartA_MouseDown(object sender, MouseEventArgs e)
        //{
        //    double xValue, yValue;
        //    xValue = Convert.ToSingle(tChart.Axes.Bottom.CalcPosPoint(e.X));
        //    yValue = Convert.ToSingle(tChart.Axes.Bottom.CalcPosPoint(e.Y));
        //}
        /*————————————————————————————*/




        private void cmsItem_I_tof_Click(object sender, EventArgs e)
        {
            selectedGate= GateType.I;//I
            gateDataType = DataType.Tof;//tof
            tChartAscan.Header.Text = "Gate I — Tof — velocity:" + velocity + "mm/us";
            CalTchartY_S(selectedGate);
            ResetTchart();
        }

        private void cmsItem_I_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.I;//I
            gateDataType = DataType.Amp;//amp
            tChartAscan.Header.Text = "Gate I — Amp — velocity:" + velocity + "mm/us";
            ResetTchart();
        }

        private void cmsItem_A_tof_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.A;//A
            gateDataType = DataType.Tof;//tof
            tChartAscan.Header.Text = "Gate A — Tof — velocity:" + velocity + "mm/us";
            CalTchartY_S(selectedGate);
            ResetTchart();
        }

        private void cmsItem_A_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.A;//A
            gateDataType = DataType.Amp;//amp
            tChartAscan.Header.Text = "Gate A — Amp — velocity:" + velocity + "mm/us";

            ResetTchart();
        }

        private void cmsItem_B_tof_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.B;//B
            gateDataType = DataType.Tof;//tof

            tChartAscan.Header.Text = "Gate B — Tof — velocity:" + velocity + "mm/us";

            CalTchartY_S(selectedGate);
            ResetTchart();
        }

        private void cmsItem_B_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.B;//B
            gateDataType = DataType.Amp;//amp
            tChartAscan.Header.Text = "Gate B — Amp — velocity:" + velocity + "mm/us";
            ResetTchart();
        }

        private void cmsItem_C_tof_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.C;//C
            gateDataType = DataType.Tof;//tof
            tChartAscan.Header.Text = "Gate C — Tof — velocity:" + velocity + "mm/us";
            CalTchartY_S(selectedGate);
            ResetTchart();
        }

        private void cmsItem_C_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.C;//C
            gateDataType = DataType.Amp;//amp
            tChartAscan.Header.Text = "Gate C — Amp — velocity:" + velocity + "mm/us";
            ResetTchart();
        }

        private void cmsItem_BA_tof_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.BA;//BA
            gateDataType = DataType.Tof;//tof
            GateType gate1;
            GateType gate2;
            gate1 = GateType.B;
            gate2 = GateType.A;
            tChartAscan.Header.Text = "Gate BA — Tof — velocity:" + velocity + "mm/us";
            CalTchartY_D(gate1, gate2);
            ResetTchart();
        }

        private void cmsItem_BA_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.BA;//BA
            gateDataType = DataType.Amp;//amp
            tChartAscan.Header.Text = "Gate BA — Amp — velocity:" + velocity + "mm/us";
            ResetTchart();
        }

        private void cmsItem_AI_tof_Click(object sender, EventArgs e)
        {
            selectedGate =GateType.AI;//AI
            gateDataType = DataType.Tof;//tof
            GateType gate1;
            GateType gate2;
            gate1 = GateType.A;
            gate2 = GateType.I;
            tChartAscan.Header.Text = "Gate AI — Tof — velocity:" + velocity + "mm/us";
            CalTchartY_D(gate1, gate2);
            ResetTchart();
        }

        private void cmsItem_AI_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.AI;//AI
            gateDataType = DataType.Amp;//amp
            tChartAscan.Header.Text = "Gate AI — Amp — velocity:" + velocity + "mm/us";
            ResetTchart();
        }

        private void cmsItem_BI_tof_Click(object sender, EventArgs e)
        {

            selectedGate = GateType.BI;//BI
            gateDataType = DataType.Tof;//tof
            GateType gate1;
            GateType gate2;
            gate1 = GateType.B;
            gate2 = GateType.I;
            tChartAscan.Header.Text = "Gate BI — Tof — velocity:" + velocity + "mm/us";
            CalTchartY_D(gate1, gate2);
            ResetTchart();
        }

        private void cmsItem_BI_amp_Click(object sender, EventArgs e)
        {
            selectedGate =GateType.BI;//BI
            gateDataType = DataType.Amp;//amp
            tChartAscan.Header.Text = "Gate BI — Amp — velocity:" + velocity + "mm/us";
            ResetTchart();
        }

        private void cmsItem_CI_tof_Click(object sender, EventArgs e)
        {

            selectedGate = GateType.CI;//CI
            gateDataType = DataType.Tof;//tof
            GateType gate1;
            GateType gate2;
            gate1 = GateType.C;
            gate2 = GateType.I;
            tChartAscan.Header.Text = "Gate CI — Tof — velocity:" + velocity + "mm/us";
            CalTchartY_D(gate1, gate2);
            ResetTchart();
        }

        private void cmsItem_CI_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.CI;//CI
            gateDataType = DataType.Amp;//amp
            tChartAscan.Header.Text = "Gate CI — Amp — velocity:" + velocity + "mm/us";
            ResetTchart();
        }


        private void CalTchartY_D(GateType gate1, GateType gate2)
        {
            double delay1 = 0, delay2 = 0, width1 = 0, width2 = 0;
            int error_code;
            error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gate1, ref delay1);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                start = false;    //制成false 后就画不了图了，怎么办
                return;
            }
            error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gate2, ref delay2);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                start = false;   
                return;
            }
            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gate1, ref width1);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                start = false;
                return;
            }
            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gate2, ref width2);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                start = false;
                return;
            }

            if ((width1 + delay1) > (width2 + delay2))
            {
                this.tChart_y2 = (width1 + delay1) - delay2;
            }
            else
            {
                this.tChart_y2 = (width2 + delay2) - delay1;
            }

            this.tChart_y1 = 0;
        }
        private void CalTchartY_S(GateType selectedGate)
        {
            double delay = 0, width = 0;
            int error_code;
            error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, selectedGate, ref delay);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                start = false;
                return;
            }
            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, selectedGate, ref width);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                start = false;
                return;
            }
            this.tChart_y1 = delay;
            this.tChart_y2 = delay + width;
        }

        private enum DataType
        {
            Tof = 0,
            Amp = 1
        }


        #endregion

//__________________________________________________________________


#region    BScan Part

        private void tChartBscan_SizeChanged(object sender, EventArgs e)
        {
            width = 1000;
            height = 1000;
            stride = 4 * ((width * 24 + 31) / 32);

            totalrow = (int)(height) / 3;
            curentrow = 0;

            tChartBscan.Axes.Left.SetMinMax(0, totalrow);

            dateArray = new byte[stride * height];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;
        }


        public void AddData(AscanVideo ascan)
        {
            float[] bigXValue = new float[ConstParameter.MaxAscanWaveLen];
            float[] bigYValue = new float[ConstParameter.MaxAscanWaveLen];
            float[] smallXValue = new float[ConstParameter.MaxAscanWaveLen / 2];
            float[] smallYValue = new float[ConstParameter.MaxAscanWaveLen / 2];

            uint len = ascan.len;
            double xStep = ascan.width / (len - 1);//Divide width into (len - 1) part.
            float[] xValue, yValue;
            float[] amp = new float[512];
            //1024
            if (len == ConstParameter.MaxAscanWaveLen)
            {
                xValue = bigXValue;

                for (int i = 0; i < len; i++)
                    xValue[i] = (float)(ascan.delay + xStep * i);

                yValue = bigYValue;
                Array.Copy(ascan.wave, yValue, len);
                for (int i = 0; i < 512; i++)
                {
                    amp[i] = yValue[2 * i + 1];
                }
            }
            //512
            else
            {
                xValue = smallXValue;

                for (int i = 0; i < len; i++)
                    xValue[i] = (float)(ascan.delay + xStep * i);

                yValue = smallYValue;
                Array.Copy(ascan.wave, yValue, len);
                amp = yValue;
            }




            byte r = 0, g = 0, b = 0;
            int index = -1;

            if (curentrow<totalrow)
            {
                for (int i = 0; i < width; i++)
                {
                    index = i * 512 / width;
                    double data = Math.Abs(amp[index]);


                    if (RGBImage.getRGB((double)data, ref r, ref g, ref b))
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int a = (curentrow*3 +j)* stride + 3 * i;
                            dateArray[a] = b;
                            dateArray[a + 1] = g;
                            dateArray[a + 2] = r;
                        }
                    }
                    
                }
                curentrow++;

            }
            else
            {
                curentrow = 0;

                dateArray = new byte[stride * height ];
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;
            }


        }

        protected delegate void updatePictureCallBack();
        protected updatePictureCallBack updatePictureFunc;


        public void UpdateBscanPic()
        {
            if (!tChartBscan.InvokeRequired)
            {
                if (bitmap == null)
                    bitmap = new Bitmap(width, height);

                BitmapData CanvasData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(dateArray, 0, ptr, width * height * 3);
                bitmap.UnlockBits(CanvasData);

                chartImage.Image = bitmap;

            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(UpdateBscanPic);

                tChartBscan.Invoke(updatePictureFunc);
            }
        }






#endregion






    }



    





    public class RGBImage
    {
        //The count of the different colors
        private static int maxColorNum = 4 * (Byte.MaxValue + 1) - 1;

        public static bool getRGB(double percent, ref byte r, ref byte g, ref byte b)
        {
            int pos = (int)(percent * maxColorNum);

            if ((pos < 0) || (pos > 1023))
            {
                r = 0;
                g = 0;
                b = 0;
                return false;
            }
            if (pos <= 255)
            {
                r = 0;
                g = (byte)pos;
                b = Byte.MaxValue;
            }
            else if (pos <= 511)
            {
                r = 0;
                g = Byte.MaxValue;
                b = (byte)(Byte.MaxValue - (pos - 256));
            }
            else if (pos <= 767)
            {
                r = (byte)(pos - 512);
                g = Byte.MaxValue;
                b = 0;
            }
            else
            {
                r = Byte.MaxValue;
                g = (byte)(Byte.MaxValue - (pos - 768));
                b = 0;
            }
            return true;
        }

        public static Bitmap CreateBitmap(byte[] imageData3, Bitmap Canvas)
        {
            if (Canvas == null)
                return Canvas;
            BitmapData CanvasData = Canvas.LockBits(new System.Drawing.Rectangle(0, 0, Canvas.Width, Canvas.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = CanvasData.Scan0;
            Marshal.Copy(imageData3, 0, ptr, imageData3.Length);
            Canvas.UnlockBits(CanvasData);
            return Canvas;
        }

    }





}
