using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Forms
{
    public partial class BetForm : Form
    {
        private int bet;
        private int maxBet;
        public int Bet { get { return bet; } set { bet = value; } }
        public BetForm()
        {
            InitializeComponent();
        }
        private void RateForm_Load(object sender, EventArgs e)
        {
        }
        public void MyShow(int maxBet)
        {
            this.maxBet = maxBet;
            this.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(Input.Text, out bet) && bet < maxBet)
            {
                this.Close();
            }
        }
    }
}
