using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RoundButtonDemo
{
    public partial class STOREload : Form
    {
        public static STOREload instance;
        public Label userName;
        public STOREload()
        {
            InitializeComponent();
            instance = this;
            userName = accNAME;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel4.Width += 20;

            if (panel4.Width >= 1353)
            {
                timer1.Stop();
                Shop sp = new Shop();
                sp.Show();
                this.Hide();

                Shop.instance.userName.Text = accNAME.Text;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
