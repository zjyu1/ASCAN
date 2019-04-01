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

//钢管、焊缝等耦合检测
namespace Ascan
{
    class CouplingInspection
    {

      public void couplingInspct(PointF[] numOfArray, ref float[] TTimeTemp, ref float[] RTimeTemp)
        {
            switch (numOfArray.Length)
            {
                case 64:
                    grooveCouplingInspct(numOfArray,ref TTimeTemp,ref RTimeTemp);
                    break;
                case 128:
                    pipeCouplingInspct(numOfArray, ref TTimeTemp, ref RTimeTemp);
                    break;
            }
            
        }
        #region 焊缝耦合检测
        //传入探头的振元数量，返回发射数组和接收数组
       private void grooveCouplingInspct(PointF[] num, ref float[] TTimeTemp, ref float[] RTimeTemp)
        {
            //float[] TTimeTemp = new float[64];
            //float[] RTimeTemp = new float[64];

            for (int i = 0; i < num.Length / 4; i++)
            {
                TTimeTemp[i] = Math.Abs(num[15].Y - num[i].Y);
                RTimeTemp[i]=TTimeTemp[i];
                TTimeTemp[i] = (float)(TTimeTemp[i] * 1000 / 0.78125);
                RTimeTemp[i] = 16 * RTimeTemp[i] * 1000 / 10 + 131072;
            }
            for (int i = num.Length / 4; i < num.Length / 2; i++)
            {
                TTimeTemp[i] =  Math.Abs(num[31].Y - num[i].Y);
                RTimeTemp[i] = TTimeTemp[i];
                TTimeTemp[i] = (float)(TTimeTemp[i] * 1000 / 0.78125);
                RTimeTemp[i] = 16 * RTimeTemp[i] * 1000 / 10 + 131072;
            }
            for (int i = num.Length / 2; i < 3*num.Length / 4; i++)
            {
                TTimeTemp[i] =  Math.Abs(num[47].Y - num[i].Y);
                RTimeTemp[i] = TTimeTemp[i];
                TTimeTemp[i] = (float)(TTimeTemp[i] * 1000 / 0.78125);
                RTimeTemp[i] = 16 * RTimeTemp[i] * 1000 / 10 + 131072;
            }
            for (int i = 3 * num.Length / 4; i < num.Length ; i++)
            {
                TTimeTemp[i] =  Math.Abs(num[31].Y - num[i].Y);
                RTimeTemp[i] = TTimeTemp[i];
                TTimeTemp[i] = (float)(TTimeTemp[i] * 1000 / 0.78125);
                RTimeTemp[i] = 16 * RTimeTemp[i] * 1000 / 10 + 131072;
            }
            

        }
        #endregion

        #region 钢管耦合检测
        //传入探头的振元数量，返回发射数组和接收数组
       private void pipeCouplingInspct(PointF[] num, ref float[] TTimeTemp, ref float[] RTimeTemp)
        {
            //float[] TTimeTemp = new float[64];
            //float[] RTimeTemp = new float[64];

            for (int i = 0; i < num.Length / 4; i++)
            {
                TTimeTemp[i] =  Math.Abs(num[31].Y - num[i].Y);
                RTimeTemp[i]=TTimeTemp[i];
                TTimeTemp[i] = (float)(TTimeTemp[i] * 1000 / 0.78125);
                RTimeTemp[i] = 16 * RTimeTemp[i] * 1000 / 10 + 131072;
            }
            for (int i = num.Length / 4; i < num.Length / 2; i++)
            {
                TTimeTemp[i] =  Math.Abs(num[63].Y - num[i].Y);
                RTimeTemp[i] = TTimeTemp[i];
                TTimeTemp[i] = (float)(TTimeTemp[i] * 1000 / 0.78125);
                RTimeTemp[i] = 16 * RTimeTemp[i] * 1000 / 10 + 131072;
            }
            for (int i = num.Length / 2; i < 3*num.Length / 4; i++)
            {
                TTimeTemp[i] =  Math.Abs(num[95].Y - num[i].Y);
                RTimeTemp[i] = TTimeTemp[i];
                TTimeTemp[i] = (float)(TTimeTemp[i] * 1000 / 0.78125);
                RTimeTemp[i] = 16 * RTimeTemp[i] * 1000 / 10 + 131072;
            }
            for (int i = 3 * num.Length / 4; i < num.Length ; i++)
            {
                TTimeTemp[i] =  Math.Abs(num[127].Y - num[i].Y);
                RTimeTemp[i] = TTimeTemp[i];
                TTimeTemp[i] = (float)(TTimeTemp[i] * 1000 / 0.78125);
                RTimeTemp[i] = 16 * RTimeTemp[i] * 1000 / 10 + 131072;
            }

        }
        #endregion
    }
}
