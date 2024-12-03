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
    public partial class DeliverLOAD : Form
    {
        public static DeliverLOAD instance;
        public Label subtotal;
        public Label shipp;
        public Label total;
        public Label code;
        public Label mPayment;
        public Label nPayemnt;
        public Label fS;
        public Label check;
        public Label dataView;
        public DeliverLOAD()
        {
            InitializeComponent();
            instance = this;
            subtotal = lblsubtotal;
            shipp = shippment;
            total = lbltotal;
            code = codeBAR;
            mPayment = lblpayment;
            nPayemnt = lblnumber;
            fS = lblstatus;
            check = lblS;

        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel4.Width += 3;

            if (panel4.Width >= 463)
            {
                timer1.Stop();

                HistoryPAYMENT hp = new HistoryPAYMENT();
                hp.Show();
                this.Hide();

                HistoryPAYMENT.instance.subtotal.Text = lblsubtotal.Text;
                HistoryPAYMENT.instance.shipp.Text = shippment.Text;
                HistoryPAYMENT.instance.total.Text = lbltotal.Text;
                HistoryPAYMENT.instance.code.Text = codeBAR.Text;
                HistoryPAYMENT.instance.mPayment.Text = lblpayment.Text;
                HistoryPAYMENT.instance.nPayemnt.Text = lblnumber.Text;
                HistoryPAYMENT.instance.check.Text = lblS.Text;
                HistoryPAYMENT.instance.fS.Text = lblstatus.Text;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
