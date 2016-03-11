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
        private BetForm betForm;
        public MainForm()
        {
            InitializeComponent();
            g = CreateGraphics();
            BackgroundImage = Image.FromFile(@"Images\Background.jpg");
            controller = new GameController(this, ClientRectangle.Width, ClientRectangle.Height);
            betForm = new BetForm();
        }

        private void TakeButton_Click(object sender, EventArgs e)
        {
            controller.TakeCard();
        }
        private void EnoughButton_Click(object sender, EventArgs e)
        {
            controller.Enough();
        }
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.NewGame();
        }
        public void UpdatePic(Bitmap bt)
        {
            g.DrawImage(bt, new Point(0, 0));
        }
        public void UpdatePoints(int point)
        {
            PointLabel.Text = "Очки : " + point.ToString();
        }
        public void UpdateMoney(int money)
        {
            MoneyLabel.Text = "Деньги : " + money.ToString();
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
        public int GetBet(int maxBet)
        {
            betForm.MyShow(maxBet);
            BetLabel.Text = "Ставка : " + betForm.Bet.ToString();
            return betForm.Bet;
        }

        public void Winner(string name)
        {
            MessageBox.Show("Победитель: " + name);
        }
        public void GameOver()
        {
            MessageBox.Show("У вас закончились деньги. Вы проиграли");
        }
    }
}

