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
        private GameController controller;
        private bool enabledButton;
        public MainForm()
        {
            InitializeComponent();
            g = CreateGraphics();
            controller = new GameController(this, ClientRectangle.Width, ClientRectangle.Height);
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

        public void UpdatePic(Bitmap bt)
        {
            g.DrawImage(bt, new Point(0, 0));
        }

        public bool EnabledButton
        {
            get { return enabledButton; }
            set 
            {
                if (!value)
                {
                    EnoughButton.Enabled = false;
                    TakeButton.Enabled = false;
                }
                else
                {
                    EnoughButton.Enabled = true;
                    TakeButton.Enabled = true;
                }
                enabledButton = value;
            }
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.NewGame();
        }


        public void UpdatePoints(int point)
        {
            throw new NotImplementedException();
        }

        public void UpdateMoney(int money)
        {
            throw new NotImplementedException();
        }
    }
}

