using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System.Threading;


namespace Ascan
{
    public partial class FormRecordFigure : Form
    {
        private double tChartA_y1, tChartA_y2;

        public GateType selectedGate;

        public DataType gateDataType;

        public double velocity; 

        public void GetVelocity(double value)
        {
             velocity = value;
        }

        float[] datas;
        
        //
        private bool changed;

        private int totalcolumn;
        private int currentcolumn;

        public int width;
        public int height;

        private int stride;

        private const int thick = 3;
        
        public double y1,y2;

        private byte[] dateArray;

        private PictureBox pictureBox;
        private Bitmap bitmap;

        public FormRecordFigure()
        {
            InitializeComponent();
            
            velocity = 5.89;    //steel velocity mm/us
            gateDataType =DataType.Amp;
            selectedGate = GateType.I;
            ResetTchart();
            //tChartAscan.Header.Text= "Gate I — Amp — velocity:" + velocity + "mm/us";
            labG.Text = "Gate I";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
            tChartA_y1 = 0;
            tChartA_y2 = 0;

            datas = new float[500];
            //

            changed = false;

            pictureBox = new PictureBox();
            pictureBox.Parent = tChartBscan;
            pictureBox.Visible = false;
            tChartBscan.Controls.Add(pictureBox);

            currentcolumn = 0;
            totalcolumn = 500;

            tChartBscan.Axes.Left.SetMinMax(0, 100);
            tChartBscan.Axes.Bottom.SetMinMax(0, totalcolumn);

            width = 0;
            height = 0;
            stride = 0;

            timeForSize.Enabled = false;
            tChartBscan.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control);
        }

        private void FormRecordFigure_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
            this.FormBorderStyle = FormBorderStyle.None;

            //initColorBar();
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

                if (gateDataType == DataType.Amp)
                {
                    Draw(gateData[gateIndex]*100);
                }
                else if (gateDataType == DataType.Tof)
                {
                    Draw(gateData[gateIndex]);
                }
                
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
                float data = 0;

                //different mode  then  diffe  data type
                if (gateDataType == DataType.Tof)
                {
                    data = System.Math.Abs(gateData[gateIndex1] - gateData[gateIndex2]);
                }
                else if (gateDataType == DataType.Amp)
                {
                    data = (float)Math.Log10(gateData[gateIndex1] / gateData[gateIndex2]) * 20;
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
                if (a == 500)
                {
                    for (int i = 0; i < datas.Length - 1; i++)
                    {
                        datas[i] = datas[i + 1];
                    }
                    datas[499] = data;
                    lineRecord.Clear();
                    lineRecord.Add(datas);
                }
                else
                {
                    lineRecord.Add(data);
                    datas[a] = data;
                    a++;
                }
            
        }


        private void ResetTchart()
        {
            lineRecord.Clear();
            a = 0;
            datas = new float[500];

            switch (gateDataType)
            {
                case DataType.Amp:
                    {
                        if (selectedGate == GateType.I || selectedGate == GateType.C || selectedGate == GateType.B || selectedGate == GateType.A)
                        {
                            tChartAscan.Axes.Left.SetMinMax(0, 100);
                            tChartAscan.Axes.Left.Title.Text = "%";
                            tChartAscan.Axes.Bottom.SetMinMax(0, 500);
                            //tChartAscan.Axes.Bottom.Title.Text = "us";
                        }
                        else
                        {
                            //double gate mode
                            //mm   |  velocity-mm/us
                            tChartAscan.Axes.Left.SetMinMax(-50,50);
                            tChartAscan.Axes.Left.Title.Text = "dB";
                            //us
                            tChartAscan.Axes.Bottom.SetMinMax(0, 500);
                            //tChartAscan.Axes.Bottom.Title.Text = "us";
                        }
                        
                    }
                    break;

                case DataType.Tof:
                    {
                        if (selectedGate == GateType.I || selectedGate == GateType.C || selectedGate == GateType.B || selectedGate == GateType.A)
                        {
                            //us
                            tChartAscan.Axes.Left.SetMinMax(tChartA_y1, tChartA_y2);
                            tChartAscan.Axes.Left.Title.Text = "us";
                            //us
                            tChartAscan.Axes.Bottom.SetMinMax(0, 500);
                            //tChartAscan.Axes.Bottom.Title.Text = "us";
                        }
                        else
                        {
                            //double gate mode
                            //mm   |  velocity-mm/us
                            tChartAscan.Axes.Left.SetMinMax(tChartA_y1, tChartA_y2);
                            tChartAscan.Axes.Left.Title.Text = "us";
                            //us
                            tChartAscan.Axes.Bottom.SetMinMax(0, 500);
                            //tChartAscan.Axes.Bottom.Title.Text = "us";
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
            //tChartAscan.Header.Text = "Gate I — Tof — velocity:" + velocity + "mm/us";
            labG.Text = "Gate I";
            labT.Text = "Tof";
            //labV.Text = velocity.ToString();

            CalTchartY_S(selectedGate);
            ResetTchart();
        }

        private void cmsItem_I_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.I;//I
            gateDataType = DataType.Amp;//amp
            //tChartAscan.Header.Text = "Gate I — Amp — velocity:" + velocity + "mm/us";
            labG.Text = "Gate I";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
            ResetTchart();
        }

        private void cmsItem_A_tof_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.A;//A
            gateDataType = DataType.Tof;//tof
            //tChartAscan.Header.Text = "Gate A — Tof — velocity:" + velocity + "mm/us";
            labG.Text = "Gate A";
            labT.Text = "Tof";
            //labV.Text = velocity.ToString();
            CalTchartY_S(selectedGate);
            ResetTchart();
        }

        private void cmsItem_A_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.A;//A
            gateDataType = DataType.Amp;//amp
            //tChartAscan.Header.Text = "Gate A — Amp — velocity:" + velocity + "mm/us";
            labG.Text = "Gate A";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
            ResetTchart();
        }

        private void cmsItem_B_tof_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.B;//B
            gateDataType = DataType.Tof;//tof

            //tChartAscan.Header.Text = "Gate B — Tof — velocity:" + velocity + "mm/us";
            labG.Text = "Gate B";
            labT.Text = "Tof";
            //labV.Text = velocity.ToString();

            CalTchartY_S(selectedGate);
            ResetTchart();
        }

        private void cmsItem_B_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.B;//B
            gateDataType = DataType.Amp;//amp
            //tChartAscan.Header.Text = "Gate B — Amp — velocity:" + velocity + "mm/us";
            labG.Text = "Gate B";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
            ResetTchart();
        }

        private void cmsItem_C_tof_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.C;//C
            gateDataType = DataType.Tof;//tof
            //tChartAscan.Header.Text = "Gate C — Tof — velocity:" + velocity + "mm/us";
            labG.Text = "Gate C";
            labT.Text = "Tof";
            //labV.Text = velocity.ToString();
            CalTchartY_S(selectedGate);
            ResetTchart();
        }

        private void cmsItem_C_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.C;//C
            gateDataType = DataType.Amp;//amp
           // tChartAscan.Header.Text = "Gate C — Amp — velocity:" + velocity + "mm/us";
            labG.Text = "Gate C";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
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
            //tChartAscan.Header.Text = "Gate BA — Tof — velocity:" + velocity + "mm/us";
            labG.Text = "Gate BA";
            labT.Text = "Tof";
            //labV.Text = velocity.ToString();
            //CalTchartY_D(gate1, gate2);
            CalTchartY_D(gate1, gate2);
            ResetTchart();
        }

        private void cmsItem_BA_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.BA;//BA
            gateDataType = DataType.Amp;//amp
            //tChartAscan.Header.Text = "Gate BA — Amp — velocity:" + velocity + "mm/us";
            labG.Text = "Gate BA";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
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
            //tChartAscan.Header.Text = "Gate AI — Tof — velocity:" + velocity + "mm/us";
            labG.Text = "Gate AI";
            labT.Text = "Tof";
            //labV.Text = velocity.ToString();
            CalTchartY_D(gate1, gate2);
            ResetTchart();
        }

        private void cmsItem_AI_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.AI;//AI
            gateDataType = DataType.Amp;//amp

            labG.Text = "Gate AI";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
            //tChartAscan.Header.Text = "Gate AI — Amp — velocity:" + velocity + "mm/us";
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
            //tChartAscan.Header.Text = "Gate BI — Tof — velocity:" + velocity + "mm/us";
            labG.Text = "Gate BI";
            labT.Text = "Tof";
            //labV.Text = velocity.ToString();
            CalTchartY_D(gate1, gate2);
            ResetTchart();
        }

        private void cmsItem_BI_amp_Click(object sender, EventArgs e)
        {
            selectedGate =GateType.BI;//BI
            gateDataType = DataType.Amp;//amp
           // tChartAscan.Header.Text = "Gate BI — Amp — velocity:" + velocity + "mm/us";
            labG.Text = "Gate BI";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
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
            //tChartAscan.Header.Text = "Gate CI — Tof — velocity:" + velocity + "mm/us";
            labG.Text = "Gate CI";
            labT.Text = "Tof";
            //labV.Text = velocity.ToString();
            CalTchartY_D(gate1, gate2);
            ResetTchart();
        }

        private void cmsItem_CI_amp_Click(object sender, EventArgs e)
        {
            selectedGate = GateType.CI;//CI
            gateDataType = DataType.Amp;//amp
            //tChartAscan.Header.Text = "Gate CI — Amp — velocity:" + velocity + "mm/us";
            labG.Text = "Gate CI";
            labT.Text = "Amp";
            //labV.Text = velocity.ToString();
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
                lineRecord.Clear();
                return;
            }
            error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gate2, ref delay2);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                lineRecord.Clear();
                return;
            }
            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gate1, ref width1);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                lineRecord.Clear();
                return;
            }
            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gate2, ref width2);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                lineRecord.Clear();
                return;
            }

            if ((width1 + delay1) > (width2 + delay2))
            {
                this.tChartA_y2 = (width1 + delay1) - delay2+5;
            }
            else
            {
                this.tChartA_y2 = (width2 + delay2) - delay1+5;
            }

            this.tChartA_y1 = 0;
        }

        private void CalTchartY_S(GateType selectedGate)
        {
            double delay = 0, width = 0;
            int error_code;
            error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, selectedGate, ref delay);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                lineRecord.Clear();
                return;
            }
            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, selectedGate, ref width);
            if (error_code != 0)
            {
                MessageBox.Show("WARNING:gate data error");
                lineRecord.Clear();;
                return;
            }
            this.tChartA_y1 = delay-1;
            this.tChartA_y2 = delay + width+2;
        }

        public enum DataType
        {
            Tof = 0,
            Amp = 1
        }


        #endregion

//__________________________________________________________________


#region    BScan Part

        //private void initColorBar()
        //{
        //    int st = 4 * ((panelColorBar.Width * 24 + 31) / 32);
        //    int index;
        //    byte r = 0;
        //    byte g = 0;
        //    byte b = 0;
        //    byte[] dataForColor = new byte[3*panelColorBar.Height * panelColorBar.Height];
        //    Bitmap imageForColor = new Bitmap(panelColorBar.Width, panelColorBar.Height);

        //    for (int i = 0; i < panelColorBar.Height; i++)
        //    {
        //        if (RGBImage.getRGB(((double)i) / panelColorBar.Height, ref r, ref g, ref b))
        //        {
        //            for (int j = 0; j < panelColorBar.Width; j++)
        //            {
        //                index = 3 * (i * panelColorBar.Width + j);
        //                dataForColor[index] = b;
        //                dataForColor[index + 1] = g;
        //                dataForColor[index + 2] = r;
        //            }
        //        }
        //    }
        //    panelColorBar.BackgroundImage = RGBImage.CreateBitmap(dataForColor, imageForColor);
        //}


        public void AddData(AscanVideo ascan)
        {
            if (width == 0 || height == 0 || stride == 0)
            {
                int top = 0;
                int left = 0;
                int yMin = tChartBscan.Axes.Left.CalcPosValue(0);
                int yMax = tChartBscan.Axes.Left.CalcPosValue(100);
                int xMin = tChartBscan.Axes.Bottom.CalcPosValue(0);
                int xMax = tChartBscan.Axes.Bottom.CalcPosValue(totalcolumn);

                if (xMin < xMax)
                    left = xMin;
                else
                    left = xMax;
                if (yMin < yMax)
                    top = yMin;
                else
                    top = yMax;

                pictureBox.Location = new Point(left+1, top+1);

                width = Math.Abs(xMin-xMax)-2;
                height = Math.Abs(yMax - yMin)-2;

                stride = 4 * ((width * 24 + 31) / 32);

                currentcolumn = 0;
                totalcolumn =(int) width / thick;
                tChartBscan.Axes.Bottom.SetMinMax(0,totalcolumn);

                dateArray = new byte[stride * height];
                for (int k = 0; k < dateArray.Length; k++)
                    dateArray[k] = byte.MaxValue;

                pictureBox.Width = width;
                pictureBox.Height = height;

                bitmap = new Bitmap(width, height);

                changed = true;
            }

            

            float[] bigYValue = new float[ConstParameter.MaxAscanWaveLen];
            float[] smallYValue = new float[ConstParameter.MaxAscanWaveLen / 2];

            uint len = ascan.len;
            float[]  yValue;
            float[] amp = new float[512];
            //1024
            if (len == ConstParameter.MaxAscanWaveLen)
            {
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
                yValue = smallYValue;
                Array.Copy(ascan.wave, yValue, len);
                amp = yValue;
            }

            byte r = 0, g = 0, b = 0;
            int index = -1;

            //未满时填满
            if (currentcolumn < totalcolumn)
            {
                for (int i = 0; i < height; i++)
                {
                    index = (int)i * 512 / height;
                    double data = Math.Abs(amp[index]);

                    if (RGBImage.getRGB((double)data, ref r, ref g, ref b))
                    {
                        for (int j = 0; j < thick; j++)
                        {
                            int a = i * stride + 3 * currentcolumn * thick + j*3;
                            dateArray[a] = b;
                            dateArray[a + 1] = g;
                            dateArray[a + 2] = r;
                        }
                    }
                    
                }
                currentcolumn++;

            }
             //满后推动的感觉
            else
            {
                currentcolumn--;
                //
                for (int i = 0; i < height; i++)
                {
                    
                    for (int j = 0; j < totalcolumn-1; j++)
                    {
                        int a = i * stride+9*j;
                        dateArray[a] = dateArray[a + 9];
                        dateArray[a + 1] = dateArray[a + 1 + 9];
                        dateArray[a + 2] = dateArray[a + 2 + 9];
                        dateArray[a + 3] = dateArray[a + 3 + 9];
                        dateArray[a + 4] = dateArray[a + 4 + 9];
                        dateArray[a + 5] = dateArray[a + 5 + 9];
                        dateArray[a + 6] = dateArray[a + 6 + 9];
                        dateArray[a + 7] = dateArray[a + 7 + 9];
                        dateArray[a + 8] = dateArray[a + 8 + 9];

                    }

                }

                for (int i = 0; i < height; i++)
                {
                    index = (int)i * 512 / height;
                    double data = Math.Abs(amp[index]);

                    if (RGBImage.getRGB((double)data, ref r, ref g, ref b))
                    {
                        for (int j = 0; j < thick; j++)
                        {
                            int a = i * stride + 3 * currentcolumn * thick + j * 3;
                            dateArray[a] = b;
                            dateArray[a + 1] = g;
                            dateArray[a + 2] = r;
                        }
                        
                    }
                }

                currentcolumn++;
            }


        }

        protected delegate void updatePictureCallBack();
        protected updatePictureCallBack updatePictureFunc;


        public void UpdateBscanPic()
        {
            if (!pictureBox.InvokeRequired)
            {
                if (bitmap == null)
                    bitmap = new Bitmap(width, height);

                BitmapData CanvasData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr ptr = CanvasData.Scan0;
                Marshal.Copy(dateArray, 0, ptr, width * height * 3);
                bitmap.UnlockBits(CanvasData);

                if (pictureBox.Visible ==false)
                    pictureBox.Visible = true;
                pictureBox.Image = bitmap;
            }
            else
            {
                if (updatePictureFunc == null)
                    updatePictureFunc = new updatePictureCallBack(UpdateBscanPic);

                pictureBox.Invoke(updatePictureFunc);
            }
        }








        private void tChartBscan_SizeChanged(object sender, EventArgs e)
        {
            if(changed)
            {
            timeForSize.Enabled = true;
            }
        }

        private void timeForSize_Tick(object sender, EventArgs e)
        {
            int top = 0;
            int left = 0;
            int yMin = tChartBscan.Axes.Left.CalcPosValue(y1);
            int yMax = tChartBscan.Axes.Left.CalcPosValue(y2);
            int xMin = tChartBscan.Axes.Bottom.CalcPosValue(0);
            int xMax = tChartBscan.Axes.Bottom.CalcPosValue(totalcolumn);

            if (xMin < xMax)
                left = xMin;
            else
                left = xMax;
            if (yMin < yMax)
                top = yMin;
            else
                top = yMax;

            pictureBox.Location = new Point(left + 1, top + 1);

            width = Math.Abs(xMin - xMax) - 2;
            height = Math.Abs(yMax - yMin) - 2;

            stride = 4 * ((width * 24 + 31) / 32);

            totalcolumn = (int)width / thick;
            tChartBscan.Axes.Bottom.SetMinMax(0, totalcolumn);

            dateArray = new byte[stride * height];
            for (int k = 0; k < dateArray.Length; k++)
                dateArray[k] = byte.MaxValue;

            pictureBox.Width = width;
            pictureBox.Height = height;

            bitmap = new Bitmap(width, height);


            currentcolumn = 0;

            timeForSize.Enabled = false;

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
            Marshal.Copy(imageData3, 0, ptr, Canvas.Width * Canvas.Height * 3);
            Canvas.UnlockBits(CanvasData);
            return Canvas;
        }

    }





}
