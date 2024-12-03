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
    public partial class DeliverPROCEED : Form
    {
        public static DeliverPROCEED instance;
        public Label subtotal;
        public Label shipp;
        public Label total;
        public Label code;
        public Label mPayment;
        public Label nPayemnt;
        public Label fS;
        public Label check;
        public Label dataView;
        
        public DeliverPROCEED()
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
            dataView = DataGrid;
            

        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }

        private void ExitBTN_MouseEnter(object sender, EventArgs e)
        {
            ExitBTN.BackColor = Color.Red;
        }

        private void ExitBTN_MouseLeave(object sender, EventArgs e)
        {
            ExitBTN.BackColor = Color.Transparent;
        }

        private void btnPROCEED_Click(object sender, EventArgs e)
        {
            DeliverLOAD load = new DeliverLOAD();
            load.Show();
            this.Hide();

            DeliverLOAD.instance.subtotal.Text = lblsubtotal.Text;
            DeliverLOAD.instance.shipp.Text = shippment.Text;
            DeliverLOAD.instance.total.Text = lbltotal.Text;
            DeliverLOAD.instance.code.Text = codeBAR.Text;
            DeliverLOAD.instance.mPayment.Text = lblpayment.Text;
            DeliverLOAD.instance.nPayemnt.Text = lblnumber.Text;
            DeliverLOAD.instance.check.Text = lblS.Text;
            DeliverLOAD.instance.fS.Text = lblstatus.Text;
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
