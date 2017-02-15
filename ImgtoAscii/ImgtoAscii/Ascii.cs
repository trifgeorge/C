using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ImgtoAscii
{
    class Ascii
    {
        private String imgLocation;

        public Ascii(String imgLocation)
        {
            this.imgLocation = imgLocation;
        }
        private string pixels= " .`-_':,;^=+/\"|)\\<>)iv%xclrs{*}I?!][1taeo7zjLunT#JCwfy325Fp6mqSghVd4EgXPGZbYkOA&8U$@KHDBWNMR0Q";
        private static double Brightness(Color c)
        {
            return (int)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }
        public void Go(String saveLocation)
        {
            
            var img =new Bitmap(imgLocation);
            using (var wrt = new StreamWriter(saveLocation))
            {
                for (var y = 0; y < img.Height; y++)
                {
                    for(var x = 0; x < img.Width; x++)
                    {
                        var color = img.GetPixel(x, y);
                        var brigh = Brightness(color);
                        var idx = brigh / 255 * (pixels.Length - 1);
                        var pxl = pixels[(int)Math.Round(idx)];
                        wrt.Write(pxl);
                        

                    }
                    wrt.WriteLine();
                }
            }
        }
    }
}
