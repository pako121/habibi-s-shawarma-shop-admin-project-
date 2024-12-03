using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoundButtonDemo
{
    public partial class loadREG2 : Form
    {
        public loadREG2()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel4.Width += 3;

            if (panel4.Width >= 463)
            {
                timer1.Stop();
                LOGIN ld = new LOGIN();
                ld.Show();
                this.Hide();
            }
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {

        }
    }
}
