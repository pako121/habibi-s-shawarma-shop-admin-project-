using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RoundButtonDemo
{
    public partial class HistoryPAYMENT : Form
    {
        private OleDbConnection relation = new OleDbConnection();


        public static HistoryPAYMENT instance;
        public Label subtotal;
        public Label shipp;
        public Label total;
        public Label code;
        public Label mPayment;
        public Label nPayemnt;
        public Label fS;
        public Label check;
        public HistoryPAYMENT()
        {
            InitializeComponent();
            relation.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nielm\OneDrive\Documents\SHAWARMA.accdb;
Persist Security Info=False;";

            instance = this;
            subtotal = lblsubtotal;
            shipp = lblshippment;
            total = historyTOTAL;
            code = codeBAR;
            mPayment = lblpayment;
            nPayemnt = lblnumber;
            fS = historySTATUS;
            check = lblS;

        }

        private void ExitBTN_MouseEnter(object sender, EventArgs e)
        {
            ExitBTN.BackColor = Color.Red;
        }

        private void ExitBTN_MouseLeave(object sender, EventArgs e)
        {
            ExitBTN.BackColor = Color.Transparent; 
        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void HistoryPAYMENT_Load(object sender, EventArgs e)
        {
            Reciept.Visible = false;
            DeliveryDtl.Visible = true;

            timeNOW.Text = DateTime.Now.ToLongTimeString();
            dateNOW.Text = DateTime.Now.ToLongDateString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            relation.Open();

            OleDbCommand con = new OleDbCommand();
            con.Connection = relation;
            con.CommandText = "insert into History (First_Name, Middle_Name, Last_Name, Contact_Number, Province, City, Barangay, Zip_Code, Total_Item, Time_of_Order, Date_of_Order, Status) " +
                "values('" + txtFIRST.Text + "','" + txtMIDDLE.Text + "','" + txtLAST.Text + "','" + txtCONTACT.Text + "','" + txtPROVINCE.Text + "','" + txtCITY.Text + "','" + txtBRGY.Text + "','" + txtCODE.Text + "','" 
                + historyTOTAL.Text + "','" + timeNOW.Text + "','" + dateNOW.Text + "','" + historySTATUS.Text + "')";

            con.ExecuteNonQuery();

            relation.Close();


            this.Close();
        }
        private void btnPROCEED_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }
        private void txtCONTACT_TextChanged(object sender, EventArgs e)
        {
            txtCONTACT.MaxLength = 11;

            if (System.Text.RegularExpressions.Regex.IsMatch(txtCONTACT.Text, "[^0-9]"))
            {
                notice.Text = "🞽 Only accepts numbers. Try Again.";
                txtCONTACT.Text = txtCONTACT.Text.Remove(txtCONTACT.Text.Length - 1);
            }

            if (historyTOTAL.Text == string.Empty)
            {
                txtCONTACT.Text = "";
            }
        }

        private void txtCODE_TextChanged(object sender, EventArgs e)
        {
            txtCODE.MaxLength = 4;

            if (System.Text.RegularExpressions.Regex.IsMatch(txtCODE.Text, "[^0-9]"))
            {
                notice.Text = "🞽 Only accepts numbers. Try Again.";
                txtCODE.Text = txtCODE.Text.Remove(txtCODE.Text.Length - 1);
            }

            if (historyTOTAL.Text == string.Empty)
            {
                txtCODE.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            btnEXIT.BackColor = Color.Red;
        }

        private void btnEXIT_MouseLeave(object sender, EventArgs e)
        {
            btnEXIT.BackColor = Color.Transparent;
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
           
            if (lblpayment.Text == "✅ Cash on Delivery")
            {
                lblPAID.ForeColor = Color.YellowGreen;
                lblPAID.Text = "🚚 COD";
            }
            else if (lblpayment.Text == "✅ Gcash")
            {
                lblPAID.ForeColor = Color.YellowGreen;
                lblPAID.Text = "✔️ PAID";
            }
            else if(lblpayment.Text == "✅ BDO")
            {
                lblPAID.ForeColor = Color.YellowGreen;
                lblPAID.Text = "✔️ PAID";
            }
            else if (lblpayment.Text == "✅ Master Card")
            {
                lblPAID.ForeColor = Color.YellowGreen;
                lblPAID.Text = "✔️ PAID";
            }
            else if (lblpayment.Text == "✅ PayMaya")
            {
                lblPAID.ForeColor = Color.YellowGreen;
                lblPAID.Text = "✔️ PAID";
            }
            else if (lblpayment.Text == "✅ PayPal")
            {
                lblPAID.ForeColor = Color.YellowGreen;
                lblPAID.Text = "✔️ PAID";
            }


            if (txtFIRST.Text == string.Empty || txtMIDDLE.Text == string.Empty || txtLAST.Text == string.Empty || txtCONTACT.Text == string.Empty || txtPROVINCE.Text == string.Empty
                || txtCITY.Text == string.Empty || txtBRGY.Text == string.Empty || txtCODE.Text == string.Empty)
            {
                notice.Text = "🞽 Please enter value in all field.";
            }
            else
            {
                SWAP();
            }


        }
        public void SWAP()
        {
            //Full Name
            string f = txtFIRST.Text;
            string m = txtMIDDLE.Text;
            string l = txtLAST.Text;
            string con = txtCONTACT.Text;

            //Addresses
            string prov = txtPROVINCE.Text;
            string cty = txtCITY.Text;
            string brgy = txtBRGY.Text;
            string zip = txtCODE.Text;

            fullNAME.Text = f + " " + m + " " + l;
            contactNUM.Text = con;
            provCity.Text = prov + ", " + cty + " " + brgy;
            zipCODE.Text = zip;

            Reciept.Visible = true;
            DeliveryDtl.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFIRST.Text = "";
            txtMIDDLE.Text = "";
            txtLAST.Text = "";
            txtCONTACT.Text = "";
            txtPROVINCE.Text = "";
            txtCITY.Text = "";
            txtBRGY.Text = "";
            txtCODE.Text = "";
            notice.Text = "";
        }

        private void fullNAME_Click(object sender, EventArgs e)
        {
            
        }
    }
}
