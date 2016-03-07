using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Interfaces;
using View.Controllers;

namespace View.Forms
{
    public partial class MainForm : Form, IForm
    {
        private Graphics g;
        private ViewController controller;
        public MainForm()
        {
            InitializeComponent();
            g = CreateGraphics();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        private void TakeButton_Click(object sender, EventArgs e)
        {
            controller.TakeCard();
        }

        private void EnoughButton_Click(object sender, EventArgs e)
        {
            controller.Enough();
        }

        public void Update(Bitmap bt)
        {
            g.DrawImage(bt, new Point(0, 0));
        }

    }
}
