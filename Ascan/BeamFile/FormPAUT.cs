using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;

namespace Ascan
{
    public partial class FormPAUT : Form
    {
        #region
        //string[] section;//文件的物理地址
        string filePath = "C:\\";//该变量保存INI文件所在的具体物理地址
        ArrayList sectionsArrayList;
        ArrayList[] keyArrayList;
        #endregion

        
        float yIncrementOfTestBlockOblique = (float)0.5;
        float yIncrementOfTestBlockVertical = (float)0.5;
        int obliqueSectionNum;
        int verticalSectionNum;
        int shiftIndex = 0;
        int verticalShiftIndex = 0;
        int totalNumOfArray = 64;
        //int elementNum = 16;
        int centerEleNum = 3;
        int verticalCenterEleNum = 2;
        int[] centerEle;
        double[,] transmit_TD;
        double[,] receive_TD;
        double[,] excite_EL;
        double[,] receive_EL;
        testBlock vTestBlock = new testBlock();
        wedge wedgePara = new wedge();
        probe probePara = new probe();
        position positionPara = new position();
        pipeParaAndEleConfig pParaAndEConfig = new pipeParaAndEleConfig();
        PointF[] pointData;
        PointF[] wavePathPoint;
        PointF[] verticalWavePathPoint;
        PointF[] wedgeObliquePoint;
        PointF[] probeObliquePoint;
        PointF[] grooveVerticalSectionPoint;
        PointF[] grooveObliqueSectionPoint;
        PointF[] pipePointData;

        List<PointF> pathPoint = new List<PointF>();
        List<PointF> verticalPathPoint = new List<PointF>();
        ClassBeamFile beamFile;
        
        public FormPAUT(ClassBeamFile beamFile)
        {
            InitializeComponent();
            //显示晶振、楔块的参数
            ShowCrystalArrayToGridview();
            ShowWedgeToGridview();
            GrooveTypePic.Image = Ascan.Properties.Resources.V;
            InspectionSketch.Image = Ascan.Properties.Resources.InspectionSketchV1;
            positionConfig.Visible = true;
            testBlockPara.Visible = true;
            pipePara.Visible = false;
            eleConfig.Visible = false;
            GrooveTypePic.Image = Ascan.Properties.Resources.V;
            InspectionSketch.Image = Ascan.Properties.Resources.InspectionSketchV1;
            wavePathPoint = new PointF[128];
            verticalWavePathPoint = new PointF[128];
            wedgeObliquePoint = new PointF[totalNumOfArray];
            probeObliquePoint = new PointF[2*totalNumOfArray];
            centerEle = new int[128];
            grooveVerticalSectionPoint = new PointF[50];
            grooveObliqueSectionPoint = new PointF[50];
            verticalWavePathPoint = new PointF[128];
            pointData = new PointF[11];
            pipePointData=new PointF[20];
            transmit_TD = new double[128, 32];
            receive_TD = new double[128, 32];
            excite_EL = new double[128, 4];
            receive_EL = new double[128, 4];
            iniArray(transmit_TD, receive_TD, excite_EL, receive_EL);
            endNum.Enabled = false;

            //section = new string[11];
            filePath = Application.StartupPath + "\\BeamTest.ini";						//INI文件的物理地址
            				
            //获取ini文件所有的section  
            sectionsArrayList=new ArrayList();
            keyArrayList = new ArrayList[15];

            this.beamFile = beamFile;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (GrooveType.SelectedIndex)
            {
                case 0:
                    GrooveTypePic.Image = Ascan.Properties.Resources.V;
                    InspectionSketch.Image = Ascan.Properties.Resources.InspectionSketchV1;
                    positionConfig.Visible = true;
                    testBlockPara.Visible = true;
                    pipePara.Visible = false;
                    eleConfig.Visible = false;
                    break;
                case 1:
                    GrooveTypePic.Image = Ascan.Properties.Resources.CRC;
                    InspectionSketch.Image = Ascan.Properties.Resources.InspectionSketchCRC1;
                    positionConfig.Visible = true;
                    testBlockPara.Visible = true;
                    pipePara.Visible = false;
                    eleConfig.Visible = false;
                    break;
                case 2:
                    GrooveTypePic.Image = Ascan.Properties.Resources.X;
                    InspectionSketch.Image = Ascan.Properties.Resources.InspectionSketchX;
                    positionConfig.Visible = true;
                    testBlockPara.Visible = true;
                    pipePara.Visible = false;
                    eleConfig.Visible = false;
                    break;
                case 3:
                    label1.Text = "检测样管：";
                    GrooveTypePic.Image = Ascan.Properties.Resources.Pipe;
                    InspectionSketch.Image = Ascan.Properties.Resources.InspectionSketchPipe;
                    positionConfig.Visible = false;
                    testBlockPara.Visible = false;
                    pipePara.Visible = true;
                    eleConfig.Visible = true;
                    break;
            }

        }

        #region 将探头参数绑定到表格里
        private void ShowCrystalArrayToGridview()
        {
            CrystalArrayData.GridColor = Color.Blue;//设置网格颜色
            CrystalArrayData.DataSource = new List<CrystalArrayData>() {//绑定到数据集合
            new CrystalArrayData(){
                晶阵编号="3.5*128",
                CL="128",
                EP="1",              
                EIP="0.1",
                FD="3.5",
                EF="3.5"  
            },
            new CrystalArrayData(){
                晶阵编号="7.5*128",
                CL="128",
                EP="1",              
                EIP="0.1",
                FD="3.5",
                EF="7.5"    
            },

            new CrystalArrayData(){
                晶阵编号="",
                CL="",
                EP="",              
                EIP="",
                FD="",
                EF=""    
            },

            new CrystalArrayData(){
                晶阵编号="",
                CL="",
                EP="",              
                EIP="",
                FD="",
                EF=""    
            },

            new CrystalArrayData(){
                晶阵编号="",
                CL="",
                EP="",              
                EIP="",
                FD="",
                EF=""    
            },
            };
            CrystalArrayData.Columns[0].Width = 100;//设置列宽
            CrystalArrayData.Columns[1].Width = 90;//设置列宽
            CrystalArrayData.Columns[2].Width = 90;//设置列宽
            CrystalArrayData.Columns[3].Width = 90;//设置列宽
            CrystalArrayData.Columns[4].Width = 90;//设置列宽
            CrystalArrayData.Columns[5].Width = 90;//设置列宽
        }
        #endregion

        #region 将楔块参数绑定到表格里
        private void ShowWedgeToGridview()
        {
            WedgeData.GridColor = Color.Blue;//设置网格颜色
            WedgeData.DataSource = new List<WedgeData>() {//绑定到数据集合
            new WedgeData(){
                楔块编号="3.5*128",
                LXL="92",
                LXH="42.5",              
                LDW="28.5",
                α="30",
                WedgeVelocity="2.336",
            },
            new WedgeData(){
                楔块编号="7.5*128",
                LXL="92",
                LXH="42.5",              
                LDW="28.5",
                α="30",
                WedgeVelocity="2.336",
            },
            new WedgeData(){
                楔块编号="",
                LXL="",
                LXH="",              
                LDW="",
                α="",
                WedgeVelocity="",
            },
              new WedgeData(){
                楔块编号="",
                LXL="",
                LXH="",              
                LDW="",
                α="",
                WedgeVelocity="",
            },
            };
            CrystalArrayData.Columns[0].Width = 100;//设置列宽
            CrystalArrayData.Columns[1].Width = 90;//设置列宽
            CrystalArrayData.Columns[2].Width = 90;//设置列宽
            CrystalArrayData.Columns[3].Width = 90;//设置列宽
            CrystalArrayData.Columns[4].Width = 90;//设置列宽
            CrystalArrayData.Columns[5].Width = 90;//设置列宽
        }
        #endregion

        #region 根据选择的聚焦对象，计算聚焦法则
        private void paraConfig_Click(object sender, EventArgs e)
        {
            switch (GrooveType.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("现在进行V型坡口聚焦法则计算", "温馨提示");
                    configuration();
                    break;
                case 1:
                   

                    break;
                case 2:
                    

                    break;
                case 3:
                    MessageBox.Show("现在进行钢管聚焦法则计算", "温馨提示");
                    pipeFocusCalulation();
                    
                    break;
            }

            this.Close();
        }
        #endregion

        #region 钢管的聚焦法则
        private void pipeFocusCalulation()
        {
            PointF pointTemp1 = new PointF();
            PointF pointTemp2 = new PointF();
            int centerElement;
            pipeParaInitialize();

            //样管坐标
            pipePointData[0].X = 0;
            pipePointData[0].Y = pParaAndEConfig.Thickness;

            pipePointData[1].X = 0;
            pipePointData[1].Y = 0;

            pipePointData[2].X = 100 + wedgePara.WedgeBottomLength;
            pipePointData[2].Y = 0;

            pipePointData[3].X = 100 + wedgePara.WedgeBottomLength;
            pipePointData[3].Y = pParaAndEConfig.Thickness;

            pipePointData[4].X = 0;
            pipePointData[4].Y = pParaAndEConfig.Thickness;

            //楔块坐标
            pipePointData[5].X = 50;
            pipePointData[5].Y = pParaAndEConfig.Thickness;

            pipePointData[6].X = 50;
            pipePointData[6].Y = pParaAndEConfig.Thickness + wedgePara.WedgeLeftHeight;

            //斜面高点
            pipePointData[7].X = 50 + wedgePara.WedgeTopLength;
            pipePointData[7].Y = pParaAndEConfig.Thickness + wedgePara.WedgeLeftHeight;
            //斜面低点
            pipePointData[8].X = 50 + wedgePara.WedgeBottomLength;
            pipePointData[8].Y = pParaAndEConfig.Thickness + wedgePara.WedgeLeftHeight - (float)Math.Tan(wedgePara.WedgeAngle) * (wedgePara.WedgeBottomLength - wedgePara.WedgeTopLength);

            pipePointData[9].X = 50 + wedgePara.WedgeBottomLength;
            pipePointData[9].Y = pParaAndEConfig.Thickness;

            pipePointData[10].X = 50;
            pipePointData[10].Y = pParaAndEConfig.Thickness;

            //探头坐标，探头最后一个振元的坐标
            pipePointData[11].X = 50 + wedgePara.WedgeTopLength + (float)((pParaAndEConfig.WedgePosition + probePara.FirstDistance + 0.5) * Math.Cos(wedgePara.WedgeAngle));
            pipePointData[11].Y = pParaAndEConfig.Thickness + wedgePara.WedgeLeftHeight - (float)(Math.Sin(wedgePara.WedgeAngle) * (pParaAndEConfig.WedgePosition + probePara.FirstDistance + 0.5));

            //聚焦点的位置
            pipePointData[12].X = 80;
            pipePointData[12].Y = 0;

            pointTemp1=pipePathSelection(pipePointData[12]);
            centerElement=pipeProbeCenterEleCalculate(pointTemp1);
            centerElementOfProbe.Text = Convert.ToString(centerElement);
            
            //。。。。
            //聚焦钢管上表面          
            pointTemp2.X = pipePointData[12].X - pointTemp1.X;
            pointTemp2.Y = -pointTemp1.Y;
            pipeTimeDelayToArray(centerElement, pointTemp2);
           //。。。。

            //聚焦钢管内表面
            //pipeTimeDelayToArray(centerElement, pipePointData[12]);
            if(outToText(transmit_TD, receive_TD, excite_EL, receive_EL, "C:\\PipeFocusInspection.txt"))
            {
                MessageBox.Show("钢管聚焦法则文件已生成", "温馨提示");
            }
            WavePath wavePathOfPipe = new WavePath();
            wavePathOfPipe.Show();
            wavePathOfPipe.drawTestBlock(pipePointData,4);
            wavePathOfPipe.drawWedge(pipePointData,4,10);
           
        }
        #endregion

        #region 在钢管内选择一点作为聚焦点，作为传入参数，返回楔块底面折射点
        private PointF pipePathSelection(PointF PointTemp)
        {
            float k3;
            float x3, y3;
            double wedgeVelocity = 2.337;
            double shearWaveVelocity = 3.3;
            k3 = (float)Math.Tan( (Math.PI/2- Math.Asin(Math.Sin(wedgePara.WedgeAngle)*shearWaveVelocity/wedgeVelocity)));

            PointF pipePathPointTemp = new PointF();

            //与钢管上表面的交点
            y3 = pParaAndEConfig.Thickness;
            x3 = (y3 - PointTemp.Y) / k3 + PointTemp.X;
            pipePathPointTemp.X = x3;
            pipePathPointTemp.Y = y3;

            return pipePathPointTemp;
        }
        #endregion

        #region 钢管检测_探头中心振元计算
        private int pipeProbeCenterEleCalculate(PointF pointTemp)
        {
            float k1;
            float xIncrementOfWedgeOblique = (float)Math.Cos(wedgePara.WedgeAngle);
            float x1;
            float y1;

            k1 = (pipePointData[8].Y - pipePointData[7].Y) / (pipePointData[8].X - pipePointData[7].X);
            x1 = pipePointData[11].X;
            y1 = pipePointData[11].Y;


            //楔块斜面晶片的分布
            for (int k = 127; k >0||k==0; k--)
            {
                probeObliquePoint[k].X = x1;
                probeObliquePoint[k].Y = y1;
                x1 += xIncrementOfWedgeOblique;
                y1 -= (float)Math.Sin(wedgePara.WedgeAngle);
                
            }
            float k4 = (float)Math.Tan(Math.PI / 2 - wedgePara.WedgeAngle);
            float x4 = probeObliquePoint[127].X;
            float y4;
            float tempResult;
            int probeNum = 127;
            int centerEle = 0;

            //楔块内部的折射线
            y4 = k4 * (x4 - pointTemp.X) + pointTemp.Y;
            tempResult = k1 * (x4 - pipePointData[8].X) + pipePointData[8].Y - y4;

            if (tempResult < 0)
            {
                MessageBox.Show("请左移探头", "温馨提示");
            }
            else
            {
                while (tempResult > 0)
                {
                    x4 += xIncrementOfWedgeOblique;
                    y4 = k4 * (x4 - pointTemp.X) + pointTemp.Y;
                    probeNum -= 1;
                    tempResult = k1 * (x4 - pipePointData[8].X) + pipePointData[8].Y - y4;
                    if (x4 > probeObliquePoint[7].X)
                    {
                        MessageBox.Show("请右移探头", "温馨提示");
                        break;
                    }
                }

                if (probeNum > 120)
                {
                    MessageBox.Show("请左移探头，以满足中心振元上方有足够的探头参与激励", "温馨提示");
                    centerEle = 120;
                }
                else
                {
                    centerEle = probeNum;
                }
            }
            return centerEle;
        }
        #endregion

        #region 计算延时，并将结果写到数组当中
        private void pipeTimeDelayToArray(int centerElement,PointF flawPoint)
        {
            double[] maxOfTArray = new double[32];
            double[,] transmit_TD_Temp = new double[128, 32];
            double[,] receive_TD_Temp = new double[128, 32];
            double[,] excite_EL_Temp = new double[128, 4];
            double[,] receive_EL_Temp = new double[128, 4];
            int numberOfFocus = 0;
            int startEle;
            int endEle;
            int startPointOfSequence;
            int orderOfInt;
            int remainderToOrderOfInt;
            int quotient;
            int EleNum = Convert.ToInt32(eleNum.Text);
            if (0 == EleNum % 2)
            {
                startEle = centerElement - EleNum / 2 + 1;
                endEle = startEle + EleNum - 1;
            }
            else
            {
                startEle = centerElement - (EleNum + 1) / 2 + 1;
                endEle = startEle + EleNum - 1;
            }
            if (startEle < 0)
            {
                startEle = 0;
            }
            if (endEle > 127)
            {
                startEle = 128 - EleNum;
            }
            //计算起始振元在32个探头中的位置，求余后得到第一个激发振元在[128,32]的32中的位置
            startPointOfSequence = startEle % 32;
            quotient = startEle / 32;
            orderOfInt = startPointOfSequence / 8;
            remainderToOrderOfInt = startPointOfSequence % 8;
            
            for (int j = startPointOfSequence; j < startPointOfSequence + EleNum; j++)
            {
                if (j < 32)
                {
                    //delayCalculate用于计算延时，并将最短时间返回
                    transmit_TD_Temp[numberOfFocus, j] = VDelayCalculate(flawPoint, probeObliquePoint[startEle + j - startPointOfSequence]);
                    maxOfTArray[j] = transmit_TD_Temp[numberOfFocus, j];
                }
                else
                {
                    transmit_TD_Temp[numberOfFocus, j-32] = VDelayCalculate(flawPoint, probeObliquePoint[startEle + j - startPointOfSequence]);
                    maxOfTArray[j-32] = transmit_TD_Temp[numberOfFocus, j-32];
                }
            }
            Array.Sort(maxOfTArray);
            for (int j = startPointOfSequence; j < startPointOfSequence + EleNum; j++)
            {
                if (j < 32)
                {
                    //用这个数组中的最大值减去所有值得到相对延时
                    transmit_TD_Temp[numberOfFocus, j] = maxOfTArray[31] - transmit_TD_Temp[numberOfFocus, j];
                    //发射探头和接收探头为同一探头时，延时一样。
                    receive_TD_Temp[numberOfFocus, j] = transmit_TD_Temp[numberOfFocus, j];
                }
                else
                {
                    //用这个数组中的最大值减去所有值得到相对延时
                    transmit_TD_Temp[numberOfFocus, j-32] = maxOfTArray[31] - transmit_TD_Temp[numberOfFocus, j-32];
                    //发射探头和接收探头为同一探头时，延时一样。
                    receive_TD_Temp[numberOfFocus, j-32] = transmit_TD_Temp[numberOfFocus, j-32];
                }

            }
            for (int j = startPointOfSequence; j < startPointOfSequence + EleNum; j++)
            {
                if (j < 32)
                {
                    //将微秒转化为纳秒，跟底层硬件的分辨率有关系
                    transmit_TD_Temp[numberOfFocus, j] = transmit_TD_Temp[numberOfFocus, j];
                    receive_TD_Temp[numberOfFocus, j] = 16 * receive_TD_Temp[numberOfFocus, j] ;
                }
                else
                {
                    transmit_TD_Temp[numberOfFocus, j-32] = transmit_TD_Temp[numberOfFocus, j-32];
                    receive_TD_Temp[numberOfFocus, j-32] = 16 * receive_TD_Temp[numberOfFocus, j-32];
                }
            }

            for (int j = startPointOfSequence; j < startPointOfSequence + EleNum; j++)
            {
                if (j < 32)
                {
                    transmit_TD[numberOfFocus, j] = transmit_TD_Temp[numberOfFocus, j];
                    receive_TD[numberOfFocus, j] = receive_TD_Temp[numberOfFocus, j];
                }
                else
                {
                    transmit_TD[numberOfFocus, j-32] = transmit_TD_Temp[numberOfFocus, j-32];
                    receive_TD[numberOfFocus, j-32] = receive_TD_Temp[numberOfFocus, j-32];
                }
            }
            //计算探头的激发序列
            for (int j = startEle; j < startEle + EleNum; j++)
            {
                startPointOfSequence = j % 32;
                quotient = j / 32;
                orderOfInt = startPointOfSequence / 8;
                remainderToOrderOfInt = startPointOfSequence % 8;
                //计算探头的激发序列
                excite_EL_Temp[numberOfFocus, orderOfInt] += Math.Pow(2, 4 * remainderToOrderOfInt + quotient);
            }
            for (int k = 0; k < 4; k++)
            {
                excite_EL[numberOfFocus, k] = excite_EL_Temp[numberOfFocus, k];
                receive_EL[numberOfFocus, k] = excite_EL[numberOfFocus, k];
            }
        }
        #endregion

        #region   钢管参数初始化
        private void pipeParaInitialize()
        {
            //试块参数和配置参数
            //实例化放在上面，当做全局变量来用
            pParaAndEConfig.PipeBottomLength = 200;
            pParaAndEConfig.Thickness = (float)Convert.ToDouble(pipeThickness.Text);
            pParaAndEConfig.PipeDiameter = (float)Convert.ToDouble(pipeDiameter.Text);
            pParaAndEConfig.WedgePosition = (float)Convert.ToDouble(wedgePos.Text);
            pParaAndEConfig.StartEle = (int)startNum.Value;
            pParaAndEConfig.EndEle = (int)endNum.Value;

            //楔块参数
            wedgePara.WedgeTopLength = (float)Convert.ToDouble(wedgeTopLength.Text);
            wedgePara.WedgeBottomLength = (float)Convert.ToDouble(wedgeBottomLength.Text);
            wedgePara.WedgeLeftHeight = (float)Convert.ToDouble(wedgeLeftHeight.Text);
            wedgePara.WedgeVelocity = (float)Convert.ToDouble(wedgeVelocity.Text);
            wedgePara.WedgeAngle = (float)Convert.ToDouble(wedgeAngle.Text) * (float)(2 * Math.PI / 360);

            //探头参数
            probePara.CasingLength = (float)Convert.ToDouble(casingLength.Text);
            probePara.ElementaryInterSpace = (float)Convert.ToDouble(elementaryInterSpace.Text);
            probePara.ElementaryPitch = (float)Convert.ToDouble(elementaryPitch.Text);
            probePara.FirstDistance = (float)Convert.ToDouble(firstDistance.Text);
            probePara.NumOfExcitation = Convert.ToInt32(eleNum.Text);
            

        }
        #endregion

        #region   V型试块参数初始化
        private void VtestParaInitialize()
        {
            //试块参数
            //实例化放在上面，当做全局变量来用
            vTestBlock.BottomLength = (float)Convert.ToDouble(bottomLength.Text);
            vTestBlock.VerticalHeight = (float)Convert.ToDouble(verticalHeight.Text);
            vTestBlock.VAngle = (float)Convert.ToDouble(vAngle.Text) * (float)(2 * Math.PI / 360);
            vTestBlock.TestBlockVelocity = (float)Convert.ToDouble(testBlockVelocity.Text);
            vTestBlock.BlockHeight = (float)Convert.ToDouble(blockHeight.Text);

            //楔块参数            
            wedgePara.WedgeTopLength = (float)Convert.ToDouble(wedgeTopLength.Text);
            wedgePara.WedgeBottomLength = (float)Convert.ToDouble(wedgeBottomLength.Text);
            wedgePara.WedgeLeftHeight = (float)Convert.ToDouble(wedgeLeftHeight.Text);
            wedgePara.WedgeVelocity = (float)Convert.ToDouble(wedgeVelocity.Text);
            wedgePara.WedgeAngle = (float)(Convert.ToDouble(wedgeAngle.Text) * 2 * Math.PI / 360);



            //探头参数
            probePara.CasingLength = (float)Convert.ToDouble(casingLength.Text);
            probePara.ElementaryPitch = (float)Convert.ToDouble(elementaryPitch.Text);
            probePara.ElementaryInterSpace = (float)Convert.ToDouble(elementaryInterSpace.Text);
            probePara.FirstDistance = (float)Convert.ToDouble(firstDistance.Text);
            probePara.CentralFrequency = (float)Convert.ToDouble(centralFrequency.Text);
            probePara.NumOfExcitation = Convert.ToInt32(excitationNum.Text);


            //位置参数
            positionPara.WedgePosition = (float)Convert.ToDouble(wedgePosition.Text);
            positionPara.ProbePosition = (float)Convert.ToDouble(probePosition.Text);


            List<PointF> pList = new List<PointF>();

            //试块的图
            pointData[0].X = (float)0;
            pointData[0].Y = vTestBlock.BlockHeight;

            pointData[1].X = (float)0;
            pointData[1].Y = (float)0;

            pointData[2].X = vTestBlock.BottomLength / 2;
            pointData[2].Y = (float)0;

            //试块斜面低点
            pointData[3].X = pointData[2].X;
            pointData[3].Y = vTestBlock.VerticalHeight;

            //试块斜面高点
            pointData[4].X = pointData[2].X + (vTestBlock.BlockHeight - vTestBlock.VerticalHeight) / (float)Math.Tan(vTestBlock.VAngle);
            pointData[4].Y = vTestBlock.BlockHeight;

            pointData[5].X = (float)0;
            pointData[5].Y = vTestBlock.BlockHeight;

            //楔块的图
            pointData[6].X = positionPara.WedgePosition;
            pointData[6].Y = vTestBlock.BlockHeight;

            pointData[7].X = positionPara.WedgePosition;
            pointData[7].Y = vTestBlock.BlockHeight + wedgePara.WedgeLeftHeight;

            //斜坡高点
            pointData[8].X = positionPara.WedgePosition + wedgePara.WedgeTopLength;
            pointData[8].Y = vTestBlock.BlockHeight + wedgePara.WedgeLeftHeight;
            //斜坡低点
            pointData[9].X = positionPara.WedgePosition + wedgePara.WedgeBottomLength;
            pointData[9].Y = vTestBlock.BlockHeight + (wedgePara.WedgeLeftHeight - (wedgePara.WedgeBottomLength - wedgePara.WedgeTopLength) * (float)Math.Tan(wedgePara.WedgeAngle));

            pointData[10].X = positionPara.WedgePosition + wedgePara.WedgeBottomLength;
            pointData[10].Y = vTestBlock.BlockHeight;
        }
        #endregion

        #region 焊缝分区检测聚焦法则计算
        private void configuration()
        {

            //V型试块参数初始化
            VtestParaInitialize();
            //焊缝分区坐标点设置
            grooveSectionCoordinateSetting();
            //垂直分区部分路径选择
            PointF pointTemp = new PointF();
            pointTemp.X = 0;
            pointTemp.Y = 0;
            int indexOfFocus = 0;
            for (int m = 0; m < verticalSectionNum; m++)
            {
                //此处返回折射点
                pointTemp = verticalPointPathSelection(grooveVerticalSectionPoint[m]);

                //此处返回中心振元的编号
                //传入参数为楔块折射点和垂直分区的入射角
                centerEle[m] = wedgeCenterEleCalculate(pointTemp, 70);

                //利用中心振元的编号计算第一条聚焦法则
                timeDelayToArray(centerEle[m], indexOfFocus, grooveVerticalSectionPoint[m]);
                indexOfFocus += 1;
            }

            
            //斜面分区第一个点
            int indexOfObliqueFocus = 0;
            //对称点是从list的第三个点开始，0,1,2存储的是垂直分区的三个点
            int posIndexOfSymmetryPoint = 0;
            int indexOfRefracitonPoint = 2;
            for (int j = verticalSectionNum; j < obliqueSectionNum + 1 + verticalSectionNum; j++)
            {
                //倾斜分区部分路径选择
                obliquePointPathSelection(indexOfObliqueFocus);

                centerEle[j] = wedgeCenterEleCalculate(pathPoint.ElementAt<PointF>(indexOfRefracitonPoint));
                timeDelayToArray(centerEle[j], j, pathPoint.ElementAt<PointF>(posIndexOfSymmetryPoint));
                indexOfObliqueFocus += 1;
                posIndexOfSymmetryPoint += 4;
                indexOfRefracitonPoint += 4;
            }

            probe1ToProbe2(transmit_TD, receive_TD, excite_EL, receive_EL);
            //生成聚焦文件，并提醒用户

            if (outToText(transmit_TD, receive_TD, excite_EL, receive_EL, "C:\\GrooveFocusInspection.txt"))
            {
                MessageBox.Show("焊缝分区聚焦法则文件已生成", "温馨提示");
            }
            int numOfVC;
            numOfVC = Convert.ToInt32(numVC.Text);
            float[] txtemp = new float[32];
            float[] rxtemp = new float[32];
            for (int i = 0; i < 32; i++)
            {
                txtemp[i] = (float)transmit_TD[numOfVC, i];
                rxtemp[i] = (float)receive_TD[numOfVC, i];
            }
            writeBeamFile(numOfVC, centerEle[numOfVC], txtemp, rxtemp);

            //writeBeamFile(numVC, centerEle[numOfVC], transmit_TD[numVC, 32], receive_TD[numVC, 32]);
            return;
            //TeeChart绘图_焊缝           
            WavePath wavePath = new WavePath();
            wavePath.Show();
            wavePath.drawTestBlock(pointData,5);
            wavePath.drawWedge(pointData,5,0);
            wavePath.drawVerticalPathPoint(verticalPathPoint);
            wavePath.drawObliquePathPoint(pathPoint);
        }
        #endregion

        #region 楔块中心振元计算
        private int wedgeCenterEleCalculate(PointF wedgeRefractionPoint)
        {
            float k1;
            float xIncrementOfWedgeOblique = (float)Math.Cos(wedgePara.WedgeAngle);
            k1 = (pointData[8].Y - pointData[9].Y) / (pointData[8].X - pointData[9].X);
          
            float k4 = (float)Math.Tan(Math.PI / 2 - (Math.Asin(wedgePara.WedgeVelocity * Math.Sin(vTestBlock.VAngle) / vTestBlock.TestBlockVelocity)));
            float x4 = wedgeObliquePoint[0].X;
            float y4;
            float tempResult;
            int probeNum = 0;

            int centerEle = 0;

            //楔块内部的折射线
            y4 = k4 * (x4 - wedgeRefractionPoint.X) + wedgeRefractionPoint.Y;
            tempResult = k1 * (x4 - pointData[8].X) + pointData[8].Y - y4;

            if (tempResult < 0)
            {
                MessageBox.Show("楔块离中心线太远，聚焦法则无法生成，请左移探头！", "系统关闭提示");
                centerEle = 7;
                wavePathPoint[centerEleNum].X = wedgeObliquePoint[7].X;
                wavePathPoint[centerEleNum].Y = wedgeObliquePoint[7].Y;
                pathPoint.Add(wavePathPoint[centerEleNum]);
                //第一条聚焦法则的中心振元位置，加4后为下一条聚焦法则的中心振元位置
                centerEleNum += 4;
                //当楔块离中心线太远，程序关闭。
                //此时是关闭程序重新启动，还是将form.show();
                //this.Show();
                //Environment.Exit(0);

            }
            else
            {
                while (tempResult > 0)
                {


                    x4 += xIncrementOfWedgeOblique;
                    y4 = k4 * (x4 - wedgeRefractionPoint.X) + wedgeRefractionPoint.Y;
                    probeNum += 1;
                    tempResult = k1 * (x4 - pointData[8].X) + pointData[8].Y - y4;
                    if (x4 > wedgeObliquePoint[63].X)
                    {
                        MessageBox.Show("请右移探头", "温馨提示");
                        break;
                    }
                }
                if (probeNum < 8)
                {
                    MessageBox.Show("请左移探头，以满足中心振元上方有足够的探头参与激励", "温馨提示");
                    centerEle = 7;
                    wavePathPoint[centerEleNum].X = wedgeObliquePoint[7].X;
                    wavePathPoint[centerEleNum].Y = wedgeObliquePoint[7].Y;
                    pathPoint.Add(wavePathPoint[centerEleNum]);
                    //第一条聚焦法则的中心振元位置，加4后为下一条聚焦法则的中心振元位置
                    centerEleNum += 4;
                }
                else
                {
                    centerEle = probeNum;
                    wavePathPoint[centerEleNum].X = x4;
                    wavePathPoint[centerEleNum].Y = y4;
                    pathPoint.Add(wavePathPoint[centerEleNum]);
                    //第一条聚焦法则的中心振元位置，加4后为下一条聚焦法则的中心振元位置
                    centerEleNum += 4;
                }
            }
            return centerEle;
        }
        #endregion

        #region V型倾斜分区点路径选择，第一个点grooveVerticalSectionPoint[0]采用直接法；第二、三、四个点采用反射法
        private void obliquePointPathSelection(int indexOfGrooveObliqueSetionPoint)
        {

            float k1;
            float x1;
            float y1;
            float x2;
            float y2;
            PointF[] wavePathPointTemp = new PointF[3];
            k1 = (float)Math.Tan(Math.PI / 2 - vTestBlock.VAngle);
            //先将焊缝斜面上的点关于X轴求对称点
            PointF[] grooveObliqueSectionPointTemp = new PointF[obliqueSectionNum + 1];
            for (int i = 0; i < obliqueSectionNum + 1; i++)
            {
                grooveObliqueSectionPointTemp[i].X = grooveObliqueSectionPoint[i].X;
                grooveObliqueSectionPointTemp[i].Y = -grooveObliqueSectionPoint[i].Y;
            }
            //将斜面所有的点保存在数组中，后期绘图用
            wavePathPointTemp[0].X = grooveObliqueSectionPoint[indexOfGrooveObliqueSetionPoint].X;
            wavePathPointTemp[0].Y = grooveObliqueSectionPoint[indexOfGrooveObliqueSetionPoint].Y;

            y1 = 0;
            x1 = (y1 - grooveObliqueSectionPointTemp[indexOfGrooveObliqueSetionPoint].Y) / k1 + grooveObliqueSectionPointTemp[indexOfGrooveObliqueSetionPoint].X;

            wavePathPointTemp[1].X = x1;
            wavePathPointTemp[1].Y = y1;

            y2 = vTestBlock.BlockHeight;
            x2 = (y2 - grooveObliqueSectionPointTemp[indexOfGrooveObliqueSetionPoint].Y) / k1 + grooveObliqueSectionPointTemp[indexOfGrooveObliqueSetionPoint].X;

            wavePathPointTemp[2].X = x2;
            wavePathPointTemp[2].Y = y2;


            fillArray(ref wavePathPointTemp, shiftIndex);
            shiftIndex += 4;

        }
        #endregion

        #region 焊缝分区坐标点设置
        private void grooveSectionCoordinateSetting()
        {

            float k2;
            float groove_Point_Count;
            float groove_VerticalPoint_Count;
            float x1;
            float y1;
            float x2;
            float y2;

            k2 = (pointData[4].Y - pointData[3].Y) / (pointData[4].X - pointData[3].X);

            groove_Point_Count = (pointData[4].Y - pointData[3].Y) / yIncrementOfTestBlockOblique;
            groove_VerticalPoint_Count = (pointData[3].Y - pointData[2].Y) / yIncrementOfTestBlockVertical;
            obliqueSectionNum = (int)groove_Point_Count;
            verticalSectionNum = (int)groove_VerticalPoint_Count;

            //PointF[] testBlockObliquePoint = new PointF[obliqueSectionNum];
           // PointF[] testBlockvEerticalPoint = new PointF[verticalSectionNum];

            //垂直分区,分区高度为1mm
            x1 = pointData[2].X;
            y1 = yIncrementOfTestBlockVertical / 2;
            for (int m = 0; m < verticalSectionNum; m++)
            {
                grooveVerticalSectionPoint[m].X = x1;
                grooveVerticalSectionPoint[m].Y = y1;
                y1 += yIncrementOfTestBlockVertical;
            }

            //试块斜面分区，高度每隔1mm进行分区
            y2 = pointData[3].Y + yIncrementOfTestBlockOblique / 2;
            x2 = (y2 - pointData[3].Y) / k2 + pointData[3].X;
            //y2 = k2 * (testBlockObliquePoint[1].X - pointData[3].X) + pointData[3].Y;

            for (int m = 0; m < obliqueSectionNum+1; m++)
            {
                grooveObliqueSectionPoint[m].X = x2;
                grooveObliqueSectionPoint[m].Y = y2;
                //grooveObliqueSectionPoint[m] = testBlockObliquePoint[m];
                y2 += yIncrementOfTestBlockOblique;
                x2 = (y2 - pointData[3].Y) / k2 + pointData[3].X;
                //x2 += yIncrementOfTestBlockOblique;
                //y2 = k2 * (x2 - pointData[3].X) + pointData[3].Y;
            }
        }
        #endregion

        #region V型垂直分区点路径选择，第一个点grooveVerticalSectionPoint[0]采用直接法；第二、三、四个点采用反射法
        private PointF verticalPointPathSelection(PointF verticalPointTemp)
        {
            float k3;
            float x3, y3;
            PointF[] wavePathPointTemp = new PointF[2];
            k3 = (float)Math.Tan(20 * 2 * Math.PI / 360);
            y3 = vTestBlock.BlockHeight;
            x3 = (y3 - verticalPointTemp.Y) / k3 + verticalPointTemp.X;
            //y3 = k3 * (x3 - testBlockObliquePoint[0].X) + testBlockObliquePoint[0].Y;
            //焊缝第一个点
            wavePathPointTemp[0] = verticalPointTemp;

            //与试块上表面的交点
            wavePathPointTemp[1].X = x3;
            wavePathPointTemp[1].Y = y3;
            verticalFillArray(ref wavePathPointTemp, verticalShiftIndex);
            verticalShiftIndex += 3;
            //楔块斜面的交点,利用折射定律计算折射角
            return wavePathPointTemp[1];
        }
        #endregion

        #region 传入两个点的坐标（缺陷点，探头振元点），利用费马定理计算两个点之间的时间，折射点的计算用离散点进行逼近
        private double delayCalculate(PointF flawCenterPoint, PointF probeCenterEle)
        {
            double t = 0;

            double xIncrement = 0.1;
            PointF pointTemp = new PointF(); ;
            pointTemp.Y = vTestBlock.BlockHeight;
            pointTemp.X = flawCenterPoint.X;
            int iCount = (int)((probeCenterEle.X - flawCenterPoint.X) / xIncrement);
            double[] tTemp = new double[iCount];
            for (int i = 0; i < iCount; i++)
            {
                t = Math.Sqrt((Math.Pow(probeCenterEle.Y - pointTemp.Y, 2) + Math.Pow(probeCenterEle.X - pointTemp.X, 2))) / wedgePara.WedgeVelocity + Math.Sqrt((Math.Pow(flawCenterPoint.Y - pointTemp.Y, 2) + Math.Pow(flawCenterPoint.X - pointTemp.X, 2))) / vTestBlock.TestBlockVelocity;
                tTemp[i] = t;
                pointTemp.X += (float)xIncrement;
            }
            Array.Sort(tTemp);
            t = tTemp[0];
            return t;
        }
        #endregion

        #region 探头的分布位置，楔块中心振元计算
        private int wedgeCenterEleCalculate(PointF pointTemp, double incidentAngel)
        {
            float k1;
            float xIncrementOfWedgeOblique = (float)Math.Cos(wedgePara.WedgeAngle);
            float x1;
            float y1;

            k1 = (pointData[8].Y - pointData[9].Y) / (pointData[8].X - pointData[9].X);
            //在更改楔块的时候，此处的7.5应该换成对应的位置数据。
            x1 = positionPara.WedgePosition + wedgePara.WedgeTopLength + (float)(7.5 * Math.Cos(wedgePara.WedgeAngle));
            y1 = vTestBlock.BlockHeight + wedgePara.WedgeLeftHeight - (float)(7.5 * Math.Sin(wedgePara.WedgeAngle));


            //楔块斜面晶片的分布
            for (int k = 0; k < totalNumOfArray; k++)
            {
                wedgeObliquePoint[k].X = x1;
                wedgeObliquePoint[k].Y = y1;
                x1 += xIncrementOfWedgeOblique;
                y1 -= (float)Math.Sin(wedgePara.WedgeAngle);
                //y1 = k1 * (x1 - wedgeObliquePoint[0].X) + wedgeObliquePoint[0].Y;
            }
            float k4 = (float)Math.Tan(Math.PI / 2 - (Math.Asin(wedgePara.WedgeVelocity * Math.Sin(incidentAngel * 2 * Math.PI / 360) / vTestBlock.TestBlockVelocity)));
            float x4 = wedgeObliquePoint[0].X;
            float y4;
            float tempResult;
            int probeNum = 0;
            int centerEle = 0;

            //楔块内部的折射线
            y4 = k4 * (x4 - pointTemp.X) + pointTemp.Y;
            tempResult = k1 * (x4 - pointData[8].X) + pointData[8].Y - y4;

            if (tempResult < 0)
            {
                MessageBox.Show("请左移探头", "温馨提示");
            }
            else
            {
                while (tempResult > 0)
                {


                    x4 += xIncrementOfWedgeOblique;
                    y4 = k4 * (x4 - pointTemp.X) + pointTemp.Y;
                    probeNum += 1;
                    tempResult = k1 * (x4 - pointData[8].X) + pointData[8].Y - y4;
                    if (x4 > wedgeObliquePoint[63].X)
                    {
                        MessageBox.Show("请右移探头", "温馨提示");
                        break;
                    }
                }

                if (probeNum < 8)
                {
                    MessageBox.Show("请左移探头，以满足中心振元上方有足够的探头参与激励", "温馨提示");
                    centerEle = 7;

                    verticalWavePathPoint[verticalCenterEleNum].X = wedgeObliquePoint[7].X;
                    verticalWavePathPoint[verticalCenterEleNum].Y = wedgeObliquePoint[7].Y;
                    verticalPathPoint.Add(verticalWavePathPoint[verticalCenterEleNum]);
                    verticalCenterEleNum += 3;
                }
                else
                {
                    centerEle = probeNum;
                    verticalWavePathPoint[verticalCenterEleNum].X = x4;
                    verticalWavePathPoint[verticalCenterEleNum].Y = y4;
                    verticalPathPoint.Add(verticalWavePathPoint[verticalCenterEleNum]);
                    verticalCenterEleNum += 3;

                }
            }
            return centerEle;
        }
        #endregion

        #region 计算延时，并将结果写到数组当中
        private void timeDelayToArray(int centerElement, int numberOfFocus, PointF flawPoint)
        {
            double[] maxOfTArray = new double[32];
            double[,] transmit_TD_Temp = new double[128, 32];
            double[,] receive_TD_Temp = new double[128, 32];
            double[,] excite_EL_Temp = new double[128, 4];
            double[,] receive_EL_Temp = new double[128, 4];
            int startEle;
            int endEle;
            int startPointOfSequence;
            int orderOfInt;
            int remainderToOrderOfInt;
            int quotient;
            int EleNum = probePara.NumOfExcitation;
            if (0 == EleNum % 2)
            {
                startEle = centerElement - EleNum / 2 + 1;
                endEle = startEle + EleNum - 1;
            }
            else
            {
                startEle = centerElement - (EleNum + 1) / 2 + 1;
                endEle = startEle + EleNum - 1;
            }
            if (startEle < 0 )
            {
                startEle = 0;               
            }
            if (endEle > 127)
            {
                startEle = 128 - EleNum;
            }
            startPointOfSequence = startEle % 32;
            quotient = startEle / 32;
            orderOfInt = startPointOfSequence / 8;
            remainderToOrderOfInt = startPointOfSequence % 8;
            //计算起始振元在32个探头中的位置，求余后得到第一个激发振元在[128,32]的32中的位置
            for (int j = startPointOfSequence; j < startPointOfSequence + EleNum; j++)
            {
                if (j < 32)
                {
                    //delayCalculate用于计算延时，并将最短时间返回
                    transmit_TD_Temp[numberOfFocus, j] = VDelayCalculate(flawPoint, wedgeObliquePoint[startEle + j - startPointOfSequence]);
                    maxOfTArray[j] = transmit_TD_Temp[numberOfFocus, j];
                }
                else
                {
                    transmit_TD_Temp[numberOfFocus, j - 32] = VDelayCalculate(flawPoint, wedgeObliquePoint[startEle + j - startPointOfSequence]);
                    maxOfTArray[j - 32] = transmit_TD_Temp[numberOfFocus, j - 32];
                }
            }
            Array.Sort(maxOfTArray);
            for (int j = startPointOfSequence; j < startPointOfSequence + EleNum; j++)
            {
                if (j < 32)
                {
                    //用这个数组中的最大值减去所有值得到相对延时
                    transmit_TD_Temp[numberOfFocus, j] = maxOfTArray[31] - transmit_TD_Temp[numberOfFocus, j];
                    //发射探头和接收探头为同一探头时，延时一样。
                    receive_TD_Temp[numberOfFocus, j] = transmit_TD_Temp[numberOfFocus, j];
                }
                else
                {
                    //用这个数组中的最大值减去所有值得到相对延时
                    transmit_TD_Temp[numberOfFocus, j - 32] = maxOfTArray[31] - transmit_TD_Temp[numberOfFocus, j - 32];
                    //发射探头和接收探头为同一探头时，延时一样。
                    receive_TD_Temp[numberOfFocus, j - 32] = transmit_TD_Temp[numberOfFocus, j - 32];
                }

            }
            for (int j = startPointOfSequence; j < startPointOfSequence + EleNum; j++)
            {
                if (j < 32)
                {
                    //将微秒转化为纳秒，跟底层硬件的分辨率有关系
                    transmit_TD_Temp[numberOfFocus, j] = transmit_TD_Temp[numberOfFocus, j];
                    receive_TD_Temp[numberOfFocus, j] = 16 * receive_TD_Temp[numberOfFocus, j];
                }
                else
                {
                    transmit_TD_Temp[numberOfFocus, j - 32] = transmit_TD_Temp[numberOfFocus, j - 32];
                    receive_TD_Temp[numberOfFocus, j - 32] = 16 * receive_TD_Temp[numberOfFocus, j - 32];
                }
            }

            for (int j = startPointOfSequence; j < startPointOfSequence + EleNum; j++)
            {
                if (j < 32)
                {
                    transmit_TD[numberOfFocus, j] = transmit_TD_Temp[numberOfFocus, j];
                    receive_TD[numberOfFocus, j] = receive_TD_Temp[numberOfFocus, j];
                }
                else
                {
                    transmit_TD[numberOfFocus, j - 32] = transmit_TD_Temp[numberOfFocus, j - 32];
                    receive_TD[numberOfFocus, j - 32] = receive_TD_Temp[numberOfFocus, j - 32];
                }
            }
            //计算探头的激发序列
            for (int j = startEle; j < startEle + probePara.NumOfExcitation; j++)
            {
                startPointOfSequence = j % 32;
                quotient = j / 32;
                orderOfInt = startPointOfSequence / 8;
                remainderToOrderOfInt = startPointOfSequence % 8;
                //计算探头的激发序列
                excite_EL_Temp[numberOfFocus, orderOfInt] += Math.Pow(2, 4 * remainderToOrderOfInt + quotient);               
            }
            for (int k = 0; k < 4; k++)
            {
                excite_EL[numberOfFocus, k] = excite_EL_Temp[numberOfFocus, k];
                receive_EL[numberOfFocus, k] = excite_EL[numberOfFocus, k];
            }
        }
        #endregion

        #region 传入两个点的坐标（缺陷点，探头振元点），利用费马定理计算两个点之间的时间，折射点的计算用离散点进行逼近
        private double VDelayCalculate(PointF flawCenterPoint, PointF probeCenterEle)
        {
            double t = 0;
            double shearWaveVelocity = 3.3;
            double xIncrement = 0.1;
            PointF pointTemp = new PointF(); ;
            pointTemp.Y = pParaAndEConfig.Thickness;
            pointTemp.X = flawCenterPoint.X;
            int iCount = (int)((probeCenterEle.X - flawCenterPoint.X) / xIncrement);
            double[] tTemp = new double[iCount];
            for (int i = 0; i < iCount; i++)
            {
                t = Math.Sqrt((Math.Pow(probeCenterEle.Y - pointTemp.Y, 2) + Math.Pow(probeCenterEle.X - pointTemp.X, 2))) / wedgePara.WedgeVelocity + Math.Sqrt((Math.Pow(flawCenterPoint.Y - pointTemp.Y, 2) + Math.Pow(flawCenterPoint.X - pointTemp.X, 2))) / shearWaveVelocity;
                tTemp[i] = t;
                pointTemp.X += (float)xIncrement;
            }
            Array.Sort(tTemp);
            t = tTemp[0];
            return t;
        }
        #endregion

        #region 传入两个点的坐标（缺陷点，探头振元点），利用费马定理计算两个点之间的时间，折射点的计算用离散点进行逼近
        private double pipeDelayCalculate(PointF flawCenterPoint, PointF probeCenterEle)
        {
            double t = 0;
            double shearWaveVelocity = 3.3;
            double xIncrement = 0.1;
            PointF pointTemp = new PointF(); ;
            pointTemp.Y = pParaAndEConfig.Thickness;
            pointTemp.X = flawCenterPoint.X;
            int iCount = (int)((probeCenterEle.X - flawCenterPoint.X) / xIncrement);
            double[] tTemp = new double[iCount];
            for (int i = 0; i < iCount; i++)
            {
                t = Math.Sqrt((Math.Pow(probeCenterEle.Y - pointTemp.Y, 2) + Math.Pow(probeCenterEle.X - pointTemp.X, 2))) / wedgePara.WedgeVelocity + Math.Sqrt((Math.Pow(flawCenterPoint.Y - pointTemp.Y, 2) + Math.Pow(flawCenterPoint.X - pointTemp.X, 2))) / shearWaveVelocity;
                tTemp[i] = t;
                pointTemp.X += (float)xIncrement;
            }
            Array.Sort(tTemp);
            t = tTemp[0];
            return t;
        }
        #endregion

        #region 初始化数四大组
        private void iniArray(double[,] dataArray1, double[,] dataArray2, double[,] dataArray3, double[,] dataArray4)
        {
            for (int i = 0; i < dataArray1.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray1.GetLength(1); j++)
                {
                    dataArray1[i, j] = 131064;
                }
            }
            for (int i = 0; i < dataArray2.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray2.GetLength(1); j++)
                {
                    dataArray2[i, j] = 0;
                }
            }
            for (int i = 0; i < dataArray3.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray3.GetLength(1); j++)
                {
                    dataArray3[i, j] = 0;
                }
            }
            for (int i = 0; i < dataArray4.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray4.GetLength(1); j++)
                {
                    dataArray4[i, j] = 0;

                }
            }
        }
        #endregion

        #region
        private void fillArray(ref PointF[] arr, int index)
        {
            //arr = new PointF[3];
            for (int i = 0; i < arr.Length; i++)
            {
                wavePathPoint[i + index] = arr[i];
                pathPoint.Add(wavePathPoint[i + index]);
            }

        }
        #endregion

        #region 将文件输出到TXT
        private bool outToText(double[,] dataArray1, double[,] dataArray2, double[,] dataArray3, double[,] dataArray4,string path)
        {
            //string path = "C:\\TestV.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StreamWriter sw = new StreamWriter(path, true);
            for (int i = 0; i < dataArray1.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray1.GetLength(1); j++)
                {

                    //Console.WriteLine("{0}", change[i]);
                    sw.Write((int)dataArray1[i, j] + " ");
                    if (j == 31)
                        sw.Write("\r\n");
                }

            }
            sw.WriteLine();
            for (int i = 0; i < dataArray2.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray2.GetLength(1); j++)
                {

                    //Console.WriteLine("{0}", change[i]);
                    sw.Write((int)dataArray2[i, j] + " ");
                    if (j == 31)
                        sw.Write("\r\n");
                }

            }
            sw.WriteLine();
            for (int i = 0; i < dataArray3.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray3.GetLength(1); j++)
                {

                    //Console.WriteLine("{0}", change[i]);
                    sw.Write((uint)dataArray3[i, 3 - j] + " ");
                    if (j == 3)
                        sw.Write("\r\n");
                }

            }
            sw.WriteLine();
            for (int i = 0; i < dataArray4.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray4.GetLength(1); j++)
                {

                    //Console.WriteLine("{0}", change[i]);
                    sw.Write((uint)dataArray4[i, 3 - j] + " ");
                    if (j == 3)
                        sw.Write("\r\n");
                }

            }

            sw.Close();
            sw.Dispose();
            return true;
        }
        #endregion

        #region 将1号探头的聚焦法则复制给2号探头，并修改对应的激励序列
        private void probe1ToProbe2(double[,] dataArray1, double[,] dataArray2, double[,] dataArray3, double[,] dataArray4)
        {
            //把探头1的聚焦法则赋给探头2，依次往下排
            for (int i = 0; i < obliqueSectionNum + 1 + verticalSectionNum; i++)
            {

                for (int j = 0; j < dataArray1.GetLength(1); j++)
                {
                    dataArray1[i + obliqueSectionNum + verticalSectionNum + 1, j] = dataArray1[i, j];
                }
            }
            //发射聚焦法则复制给接收聚焦法则，相当于收发一体的探头
            for (int i = 0; i < obliqueSectionNum + 1 + verticalSectionNum; i++)
            {
                for (int j = 0; j < dataArray2.GetLength(1); j++)
                {
                    dataArray2[i + obliqueSectionNum + 1 + verticalSectionNum, j] = dataArray2[i, j];
                }
            }
            //将0-63振元的激励序列乘以4赋给64-127振元
            for (int i = 0; i < obliqueSectionNum + 1 + verticalSectionNum; i++)
            {
                for (int j = 0; j < dataArray3.GetLength(1); j++)
                {
                    dataArray3[i + obliqueSectionNum + 1 + verticalSectionNum, j] = dataArray3[i, j] * 4;
                }
            }
            //发射激励振元序列复制给接收聚焦法则，相当于收发一体的探头
            for (int i = 0; i < dataArray3.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray3.GetLength(1); j++)
                {
                    dataArray4[i, j] = dataArray3[i, j];
                }
            }
        }

        #endregion

        #region
        private void verticalFillArray(ref PointF[] arr, int index)
        {


            //arr = new PointF[3];
            for (int i = 0; i < arr.Length; i++)
            {
                verticalWavePathPoint[i + index] = arr[i];
                //grooveVerticalSectionPoint[i + index] = arr[i];
                verticalPathPoint.Add(verticalWavePathPoint[i + index]);
            }

        }
        #endregion

        private void quitAPP_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void endNum_ValueChanged(object sender, EventArgs e)
        //{
        //    float eleNumTemp;
        //    pParaAndEConfig.EndEle = (float)Convert.ToDouble(endNum.Text);
        //    pParaAndEConfig.StartEle = (float)Convert.ToDouble(startNum.Text);
        //    eleNumTemp = (float)Convert.ToDouble(eleNum.Text);
        //    if (eleNumTemp != pParaAndEConfig.EndEle - pParaAndEConfig.StartEle+1)
        //    {
        //        MessageBox.Show("终止振元设置错误", "温馨提示");
        //    }
        //}

        private void startNum_ValueChanged(object sender, EventArgs e)
        {
            
            pParaAndEConfig.StartEle = Convert.ToInt16( startNum.Value);
            pParaAndEConfig.EleNum =Convert.ToInt16( eleNum.Value);
            endNum.Value = pParaAndEConfig.EleNum + pParaAndEConfig.StartEle-1;
            //endNum.Enabled = false;
        }

        private void eleNum_ValueChanged(object sender, EventArgs e)
        {
            pParaAndEConfig.EleNum = Convert.ToInt16(eleNum.Value);
            pParaAndEConfig.StartEle = Convert.ToInt16(startNum.Value);
            endNum.Value = pParaAndEConfig.EleNum + pParaAndEConfig.StartEle - 1;
            //endNum.Enabled = false;
        }

        #region
        private void iniFile_Click(object sender, EventArgs e)
        {
            INIOperation iniOperation = new INIOperation();

            byte[] sections=new byte[65535];
            
            int value=-1;
            if (File.Exists(filePath))											//判断是否存在INI文件
            {
                sectionsArrayList = iniOperation.ReadSections(filePath);
                
                ArrayList[] keyArrayListTemp = new ArrayList[sectionsArrayList.Count];
                for (int i = 0; i < sectionsArrayList.Count; i++)
                {
                    keyArrayListTemp[i] = iniOperation.ReadKeys(filePath,sectionsArrayList[i].ToString());
                    keyArrayList[i] = keyArrayListTemp[i];
                   
                }
                int[,] keyValue = new int[sectionsArrayList.Count,10];
                for (int i = 0; i < sectionsArrayList.Count; i++)
                {
                    for (int j = 0; j < keyArrayList[i].Count; j++)
                    {
                        value = iniOperation.GetIniKeyValueForInt(filePath,sectionsArrayList[i].ToString(), keyArrayList[i][j].ToString());
                        keyValue[i, j] = value;
                    }
                }
                //WritePrivateProfileString(section[0], null, null, filePath);               //
                iniOperation.WriteToIni(sectionsArrayList[0].ToString(), keyArrayList[0][0].ToString(), "112", filePath); 		//修改INI文件中服务器节点的内容
                iniOperation.WriteToIni(sectionsArrayList[1].ToString(), keyArrayList[1][0].ToString(), "113", filePath);
                for (int i = 0; i < 8; i++)
                {
                    iniOperation.WriteToIni(sectionsArrayList[2].ToString(), keyArrayList[2][i].ToString(), "112", filePath);
                }
                iniOperation.WriteToIni(sectionsArrayList[3].ToString(), keyArrayList[3][0].ToString(), "0.0", filePath);
                iniOperation.WriteToIni(sectionsArrayList[4].ToString(), keyArrayList[4][0].ToString(), "111", filePath);
                for (int i = 0; i < 8; i++)
                {
                    iniOperation.WriteToIni(sectionsArrayList[5].ToString(), keyArrayList[5][i].ToString(), "110", filePath);
                }
                iniOperation.WriteToIni(sectionsArrayList[6].ToString(), keyArrayList[6][0].ToString(), "0.0", filePath);
                iniOperation.WriteToIni(sectionsArrayList[7].ToString(), keyArrayList[7][0].ToString(), "1.0", filePath);
                iniOperation.WriteToIni(sectionsArrayList[8].ToString(), keyArrayList[8][0].ToString(), "40.0", filePath);
                for (int i = 0; i < 8; i++)
                {
                    iniOperation.WriteToIni(sectionsArrayList[9].ToString(), keyArrayList[9][i].ToString(), "109", filePath);
                }
                iniOperation.WriteToIni(sectionsArrayList[10].ToString(), keyArrayList[10][0].ToString(), "../dac/test.ini", filePath);
                //iniOperation.WriteToIni(section[0], "Pwd", "3", filePath); 			//修改INI文件中密码节点的内容
                MessageBox.Show("恭喜你，修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("对不起，你所要修改的文件不存在，请确认后再进行修改操作！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


    
        #region 标题栏背景色的更改
        private void tabControl_tabDrowItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            SolidBrush blue = new SolidBrush(Color.Blue);
            SolidBrush green = new SolidBrush(Color.Green);
            SolidBrush orange = new SolidBrush(Color.Orange);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush activeCaption = new SolidBrush(Color.Indigo);
            SolidBrush lightSkyBlue = new SolidBrush(Color.LightSkyBlue);
            SolidBrush lightSteelBlue = new SolidBrush(Color.LightSteelBlue);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            Rectangle Rec0 = tabControl1.GetTabRect(0);
            e.Graphics.FillRectangle(lightSteelBlue, Rec0);
            //tabControl1.TabPages[0].Text = "探头设置";

            Rectangle Rec1 = tabControl1.GetTabRect(1);
            e.Graphics.FillRectangle(lightSteelBlue, Rec1);

            Rectangle Rec2 = tabControl1.GetTabRect(2);
            e.Graphics.FillRectangle(lightSteelBlue, Rec2);

            Rectangle Rec3 = tabControl1.GetTabRect(3);
            e.Graphics.FillRectangle(lightSteelBlue, Rec3);

            Rectangle Rec4 = tabControl1.GetTabRect(4);
            e.Graphics.FillRectangle(lightSteelBlue, Rec4);

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle Rec = tabControl1.GetTabRect(i);
                e.Graphics.DrawString(tabControl1.TabPages[i].Text,new Font("宋体",9),black,Rec,stringFormat);
            }
        }
        #endregion
        private void button7_Click(object sender, EventArgs e)
        {
            
        }
        #region 焊缝耦合检测
        private void grooveCouplingIns(object sender, EventArgs e)
        {
            float[] TTimeTemp = new float[64];
            float[] RTimeTemp = new float[64];
            float k1;
            float xIncrementOfWedgeOblique = (float)Math.Cos(wedgePara.WedgeAngle);
            float x1;
            float y1;
            VtestParaInitialize();
            k1 = (pointData[8].Y - pointData[9].Y) / (pointData[8].X - pointData[9].X);
            //在更改楔块的时候，此处的7.5应该换成对应的位置数据。
            x1 = positionPara.WedgePosition + wedgePara.WedgeTopLength + (float)(7.5 * Math.Cos(wedgePara.WedgeAngle));
            y1 = vTestBlock.BlockHeight + wedgePara.WedgeLeftHeight - (float)(7.5 * Math.Sin(wedgePara.WedgeAngle));


            //楔块斜面晶片的分布
            for (int k = 0; k < totalNumOfArray; k++)
            {
                wedgeObliquePoint[k].X = x1;
                wedgeObliquePoint[k].Y = y1;
                x1 += xIncrementOfWedgeOblique;
                y1 -= (float)Math.Sin(wedgePara.WedgeAngle);
                //y1 = k1 * (x1 - wedgeObliquePoint[0].X) + wedgeObliquePoint[0].Y;
            }
            CouplingInspection cpInspct = new CouplingInspection();
            cpInspct.couplingInspct(wedgeObliquePoint,ref TTimeTemp,ref RTimeTemp);
            //public void couplingInspct(PointF[] numOfArray, ref float[] TTimeTemp, ref float[] RTimeTemp)
            //transmit_TD
            for (int i = 0; i < TTimeTemp.Length/4; i++)
            {
                transmit_TD[0,i] = TTimeTemp[i];
            }
            for (int i = TTimeTemp.Length / 4; i < TTimeTemp.Length / 2; i++)
            {
                transmit_TD[1, i] = TTimeTemp[i];
            }
            for (int i = 0; i < TTimeTemp.Length / 4; i++)
            {
                transmit_TD[2, i] = TTimeTemp[i + TTimeTemp.Length / 2];
            }
            for (int i = TTimeTemp.Length / 4; i < TTimeTemp.Length / 2; i++)
            {
                transmit_TD[3, i] = TTimeTemp[i + TTimeTemp.Length / 2];
            }
            //接收延时数组
            for (int i = 0; i < TTimeTemp.Length / 4; i++)
            {
                receive_TD[0, i] = RTimeTemp[i];
            }
            for (int i = TTimeTemp.Length / 4; i < TTimeTemp.Length / 2; i++)
            {
                receive_TD[1, i] = RTimeTemp[i];
            }
            for (int i = 0; i < TTimeTemp.Length / 4; i++)
            {
                receive_TD[2, i] = RTimeTemp[i + TTimeTemp.Length / 2];
            }
            for (int i = TTimeTemp.Length / 4; i < TTimeTemp.Length / 2; i++)
            {
                receive_TD[3, i] = RTimeTemp[i + TTimeTemp.Length / 2];
            }
            //将probe1赋值给probe2
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    transmit_TD[4 + i, j] = transmit_TD[i, j];
                    receive_TD[4 + i, j] = receive_TD[i, j];
                }
            }
            //激发序列
            excite_EL[0, 0] = 0x11111111;
            excite_EL[0, 1] = 0x11111111;
            excite_EL[1, 2] = 0x11111111;
            excite_EL[1, 3] = 0x11111111;
            excite_EL[2, 0] = 0x22222222;
            excite_EL[2, 1] = 0x22222222;
            excite_EL[3, 2] = 0x22222222;
            excite_EL[3, 3] = 0x22222222;

            excite_EL[4, 0] = 0x44444444;
            excite_EL[4, 1] = 0x44444444;
            excite_EL[5, 2] = 0x44444444;
            excite_EL[5, 3] = 0x44444444;
            excite_EL[6, 0] = 0x88888888;
            excite_EL[6, 1] = 0x88888888;
            excite_EL[7, 2] = 0x88888888;
            excite_EL[7, 3] = 0x88888888;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                    receive_EL[i, j] = excite_EL[i, j];
            }
            

            //生成聚焦文件，并提醒用户
            if (outToText(transmit_TD, receive_TD, excite_EL, receive_EL, "C:\\CouplingInspection.txt"))
            {
                MessageBox.Show("焊缝耦合检测文件已生成", "温馨提示");
            }

        }
        #endregion
        
        #region 退出软件
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void OutputTXT(object sender, EventArgs e)
        {

        }
        #region 输出INI文件
        private void OutputINI(object sender, EventArgs e)
        {
            iniFile_Click(sender, e);
        }
        #endregion

        #region 将文件写入武师兄需要的格式中
        private void writeBeamFile(int beamIndex, int centerElement, float[] dataArray1, float[] dataArray2)
        {
            int[] tx = new int[8];
            int startEle;
            int endEle;
            int startPointOfSequence;
            int quotient;
            int EleNum = probePara.NumOfExcitation;
            if (0 == EleNum % 2)
            {
                startEle = centerElement - EleNum / 2 + 1;
                endEle = startEle + EleNum - 1;
            }
            else
            {
                startEle = centerElement - (EleNum + 1) / 2 + 1;
                endEle = startEle + EleNum - 1;
            }
            if (startEle < 0)
            {
                startEle = 0;
            }
            if (endEle > 127)
            {
                startEle = 128 - EleNum;
            }
            for (int i = 0; i < 8; i++)
            {
                tx[i] = 0;
            }
            for (int i = 0; i < EleNum; i++)
            {
                startPointOfSequence = (startEle + i) % 32;
                quotient = (startEle + i) / 32;
                tx[quotient] += 0x1 << startPointOfSequence;
            }

            beamFile.beamIndex = (uint)beamIndex;
            beamFile.txSize = (uint)probePara.NumOfExcitation;
            beamFile.rxSize = (uint)probePara.NumOfExcitation;
            for (int i = 0; i < 8; i++)
            {
                beamFile.txElementBin[i]=(uint)tx[i];
                beamFile.rxElementBin[i]=(uint)tx[i];
            }
            for (int i = 0; i < EleNum; i++)
            {
                beamFile.txDelay[i] = dataArray1[i + startEle];
            }
            for (int i = 0; i < EleNum; i++)
            {
                beamFile.rxDelay[i] = dataArray1[i + startEle];
            }

        }
        #endregion

        private void btWrite_Click(object sender, EventArgs e)
        {
            switch (GrooveType.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("现在进行V型坡口聚焦法则计算", "温馨提示");
                    configuration();
                    break;
                case 1:


                    break;
                case 2:


                    break;
                case 3:
                    MessageBox.Show("现在进行钢管聚焦法则计算", "温馨提示");
                    pipeFocusCalulation();

                    break;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filePath = Application.StartupPath + @"\BeamFile";
            if (filePath.IndexOf('\\') < 0 && filePath.IndexOf('/') < 0 || filePath.StartsWith(":"))
            {
                MessageShow.show("Wrong format of path!", "路径格式错误！");
                return;
            }
            string str = Directory.GetDirectoryRoot(filePath);
            //str = System.IO.Path.GetPathRoot(Path.GetFullPath( filePath));
            if (!Directory.Exists(str))
            {
                MessageShow.show(str + "the director root doesn't exist, please change the path!",
                    str + "该盘符不存在，请选择其他保存路径！");
                return;
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            saveFileDialog1.InitialDirectory = filePath;
            saveFileDialog1.Filter = "bm文件(*.bm)|*.bm|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                writeToXML(saveFileDialog1.FileName);
            }

            MessageBox.Show("生成文件成功", "温馨提示");
        }

        private void writeToXML(string file)
        {
            string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
            SystemConfig.WriteConfigData(file, "date", date);
            SystemConfig.WriteBase64Data(file, "beamFile", beamFile);
        }
    }
}
