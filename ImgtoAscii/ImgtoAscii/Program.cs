using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgtoAscii
{
    class Program
    {
        static void Main(string[] args)
        {
            Ascii a = new Ascii("D:/C#/ImgtoAscii/ImgtoAscii/index.jpg");
            a.Go("D:/C#/ImgtoAscii/ImgtoAscii/ascii.txt");

        }
    }
}
