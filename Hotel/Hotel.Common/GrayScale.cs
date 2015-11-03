using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace Hotel.Common
{
    /// <summary>
    /// 获取灰度图像
    /// </summary>
    public class GrayScale
    {
        /// <summary>
        /// 根据Form,取得原始彩色图像
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        public static Bitmap GetFormImage(Form frm)
        {
            Graphics g = frm.CreateGraphics();
            Size s = frm.Size;
            Bitmap formImage = new Bitmap(s.Width, s.Height, g);
            Graphics mg = Graphics.FromImage(formImage);
            IntPtr dc1 = g.GetHdc();
            IntPtr dc2 = mg.GetHdc();//13369376
            BitBlt(dc2, 0, 0, frm.ClientRectangle.Width, frm.ClientRectangle.Height, dc1, 0, 0, 23369376);
            g.ReleaseHdc(dc1);
            mg.ReleaseHdc(dc2);
            return formImage;
        }

        /// <summary>
        /// 将彩色图像转换为灰度图像,速度有些慢.前台用线程进行处理比较合适.
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //make an empty bitmap the same size as original   
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //get the pixel from the original image   
                    Color originalColor = original.GetPixel(i, j);
                    //create the grayscale version of the pixel   
                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.55)
                        + (originalColor.B * .11));
                    //create the color object   
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    //set the new image's pixel to the grayscale version   
                    newBitmap.SetPixel(i, j, newColor);
                }
            }
            return newBitmap;
        }

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

    }
}
