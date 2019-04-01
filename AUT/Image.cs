using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AUT
{
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

    public class GrayImage
    {
        //The count of the different colors
        private static int maxColorNum = Byte.MaxValue;

        public static bool getRGB(double percent, ref byte r, ref byte g, ref byte b)
        {
            int pos = (int)(percent * maxColorNum);

            if (pos > maxColorNum || pos < 0)
                return false;
            else
            {
                r = (Byte)pos;
                g = (Byte)pos;
                b = (Byte)pos;
                return true;
            }
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
