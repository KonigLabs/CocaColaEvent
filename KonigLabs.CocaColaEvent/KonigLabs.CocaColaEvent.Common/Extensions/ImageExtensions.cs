using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KonigLabs.CocaColaEvent.Common.Extensions
{

        public static class ImageExtensions
        {
            public static byte[] ToBytes(this Bitmap bmp)
            {
                byte[] result = { };
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, ImageFormat.Png);
                        result = ms.ToArray();
                    }
                }
                catch (Exception e)
                {
                }

                return result;
            }

            public static ImageSource ToImage(this byte[] buffer)
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(buffer);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                return biImg;
            }
        }
    }
