using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Crow.Little.Common
{
    public static class CommonImageHelper
    {
        #region Field
        #endregion

        #region Property
        #endregion

        #region Constructor
        #endregion

        #region Event
        #endregion

        #region Method
        /// <summary>
        /// 将图片灰度处理
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ConverImageToGray(Image img)
        {
            /*
            原理：当R G B 分量值不同时，表现为彩色图像，当三个值相同时，表现为灰度图像;
            第一种转换公式:Gray(i,j) = [R(i,j) + G(i,j) + B(i,j)]/3
            适应人的视觉感应的转换公式:Gray(i,j) = 0.299*R(i,j) + 0.587*G(i,j) + 0.114*B(i,j)
            */
            Bitmap curBitmap = img.Clone() as Bitmap;
            if (curBitmap != null)
            {
                Color curColor;
                int ret;

                //二维图像数组循环
                for (int i = 0; i < curBitmap.Width; i++)
                {
                    for (int j = 0; j < curBitmap.Height; j++)
                    {
                        //获取该点的像素的RGB的颜色值
                        curColor = curBitmap.GetPixel(i, j);
                        //利用公式计算灰度值
                        ret = (int)(curColor.R * 0.229 + curColor.G * 0.587 + curColor.B * 0.114);
                        //设置该点的灰度值，R = G = B = ret
                        curBitmap.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                    }
                }
            }
            return curBitmap;
        }
        #endregion
    }
}
