﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Interfaces
{
    public interface IForm
    {
        void UpdatePic(Bitmap bt);
        bool EnabledButton { get; set; }
        void UpdatePoints(int point);
        void UpdateMoney(int money);
    }
}