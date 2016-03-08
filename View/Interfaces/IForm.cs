using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Interfaces
{
    public interface IForm
    {
        void Update(Bitmap bt);
        bool EnabledButton { get; set; }
    }
}
