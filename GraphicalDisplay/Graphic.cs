using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicDLL
{
    public class Graphic
    {
        private Bitmap mainBT;
        private Image Shirt;
        public Graphic(int wh, int ht)
        {
            mainBT = new Bitmap(wh, ht);
        }
        public Bitmap Draw()
        {
            return mainBT;
        }

    }
}
