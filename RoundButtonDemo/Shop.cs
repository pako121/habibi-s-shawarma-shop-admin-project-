using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RoundButtonDemo
{
    public partial class Shop : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public static Shop instance;
        public Label userName;

        public Shop()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nielm\OneDrive\Documents\SHAWARMA.accdb;
Persist Security Info=False;";
            instance = this;
            userName = accNAME;
           
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            cbxPayment.Enabled = false;
            lblNum.Enabled = false;
            //Shawarma
            shawarmaCOMBO.Items.Add("✅ Shawarma-Small                  ₱ 39.99");
            shawarmaCOMBO.Items.Add("✅ Shawarma-Large                  ₱ 49.99");
            shawarmaCOMBO.Items.Add("✅ Shawarma-XL                     ₱ 59.99");

            //Shawarma Burger
            burgerCOMBO.Items.Add("✅ Shawarma Burger-Small         ₱ 29.99");
            burgerCOMBO.Items.Add("✅ Shawarma Burger-Large         ₱ 39.99");

            //Shawarma Rice
            riceCOMBO.Items.Add("✅ Shawarma Rice-Large           ₱ 49.99");
            riceCOMBO.Items.Add("✅ Shawarma Rice-XL              ₱ 79.99");

            //Shawarma Fries
            friesCOMBO.Items.Add("✅ Shawarma Fries-Small           ₱ 39.99");
            friesCOMBO.Items.Add("✅ Shawarma Fries-Large           ₱ 49.99");

            //Shawarma Nachos
            nachosCOMBO.Items.Add("✅ Shawarma Nachos-Small         ₱ 39.99");
            nachosCOMBO.Items.Add("✅ Shawarma Nachos-Large         ₱ 49.99");

            //Drinks
            waterCOMBO.Items.Add("✅ Mineral Water              ₱ 17.99");
            cocaCOMBO.Items.Add("✅ Coca-Cola              ₱ 17.99");
            dewCOMBO.Items.Add("✅ Mountain Dew                 ₱ 17.99");
            stingCOMBO.Items.Add("✅ Sting                 ₱ 17.99");

            //Payment
            cbxPayment.Items.Add("✅ Cash on Delivery");
            cbxPayment.Items.Add("✅ Gcash");
            cbxPayment.Items.Add("✅ BDO");
            cbxPayment.Items.Add("✅ Master Card");
            cbxPayment.Items.Add("✅ PayMaya");
            cbxPayment.Items.Add("✅ PayPal");


            accountINFO.Visible = false;

        }

        public double CostofITEM()
        {
            Double sum = 0;

            for (int i = 0; i < (dataGRID.Rows.Count); i++)
            {
                sum = sum + Convert.ToDouble(dataGRID.Rows[i].Cells[2].Value);
            }
            return sum;
        }

        public void Shippment()
        {
            Double tax, q;
            tax = 60.05;

            if (dataGRID.Rows.Count > 0)
            {
                lblshippment.Text = String.Format(new CultureInfo("fil-PH"), "{0:c2}", (((tax))));
                lblsubtotal.Text = String.Format(new CultureInfo("fil-PH"), "{0:c2}", (CostofITEM()));
                q = ((CostofITEM() + tax));
                lbltotal.Text = String.Format(new CultureInfo("fil-PH"), "{0:c2}", (q));
                codeBAR.Text = Convert.ToString(q + CostofITEM());
            }
            else
            {
                // LABEL Clear
                cbxPayment.Enabled = false;
                codeBAR.Text = "";
                lblstatus.Text = "";
                lblNum.Text = "";
                lblshippment.Text = "";
                lblsubtotal.Text = "";
                lbltotal.Text = "";
                lblNum.Text = "";
                cbxPayment.Text = "";
                notice.Text = "";
                lblnumber.Text = "#";
                lblS.Text = "";
            }
        }
        public void TotalItem()
        {
           
            
        }
       

        public void Deliver()
        {
            DeliverPROCEED dlvr =  new DeliverPROCEED();
            dlvr.Show();

            DeliverPROCEED.instance.subtotal.Text = lblsubtotal.Text;
            DeliverPROCEED.instance.shipp.Text = lblshippment.Text;
            DeliverPROCEED.instance.total.Text = lbltotal.Text;
            DeliverPROCEED.instance.code.Text = codeBAR.Text;
            DeliverPROCEED.instance.mPayment.Text = cbxPayment.Text;
            DeliverPROCEED.instance.nPayemnt.Text = lblNum.Text;
            DeliverPROCEED.instance.check.Text = lblS.Text;
            DeliverPROCEED.instance.fS.Text = lblstatus.Text;
        }
        //❌✔️
        private void STATUS()
        {
            Double c = Convert.ToDouble(lblNum.Text);

            if(c == 0)
            {
                lblS.ForeColor = Color.Red;
                lblS.Text = "[❌]";
                lblstatus.ForeColor = Color.Red;
                lblstatus.Text = "Failed";
                notice.Text = "";
            }
            else
            {
                lblS.ForeColor = Color.YellowGreen;
                lblS.Text = "[✔️]";
                lblstatus.ForeColor = Color.YellowGreen;
                lblstatus.Text = "Successful";
                notice.Text = "";
                Deliver();
            }

            if(lblNum.Enabled == false)
            {
                lblS.ForeColor = Color.YellowGreen;
                lblS.Text = "[✔️]";
                lblstatus.ForeColor = Color.YellowGreen;
                lblstatus.Text = "Successful";
                notice.Text = "";
                Deliver();
            }

        }

        public void CostENABLE()
        {
            cbxPayment.Enabled = true;
            if(cbxPayment.Text == "✅ Gcash" || cbxPayment.Text == "✅ BDO" || cbxPayment.Text == "✅ Master Card" || cbxPayment.Text == "✅ PayMaya" || cbxPayment.Text == "✅ PayPal")
            {
                lblNum.Enabled = true;
            }
           
        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void ExitBTN_MouseEnter(object sender, EventArgs e)
        {
            ExitBTN.BackColor = Color.Red;
        }

        private void ExitBTN_MouseLeave(object sender, EventArgs e)
        {
            ExitBTN.BackColor= Color.Transparent;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            HomePanel.Location = new Point(3, 269);
           

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HomePanel.Location = new Point(3, 269);
            HomePanel.Visible = true;
            HOME.Visible = true;
            MENU.Visible = false;
            ABOUT.Visible = false;
            CONTACT.Visible = false;
            HISTORY.Visible = false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            HomePanel.Location = new Point(3, 383);
            HomePanel.Visible = true;
            HOME.Visible = false;
            MENU.Visible = true;
            ABOUT.Visible = false;
            CONTACT.Visible = false;
            HISTORY.Visible = false;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            HomePanel.Location = new Point(3, 497);
            HomePanel.Visible = true;
            HOME.Visible = false;
            MENU.Visible = false;
            ABOUT.Visible = true;
            CONTACT.Visible = false;
            HISTORY.Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            HomePanel.Location = new Point(3, 609);
            HomePanel.Visible = true;
            HOME.Visible = false;
            MENU.Visible = false;
            ABOUT.Visible = false;
            CONTACT.Visible = true;
            HISTORY.Visible = false;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            notice.Text = "";
            if(shawarmaCOMBO.Text == "✅ Shawarma-Small                  ₱ 39.99")
            {
                Double cost = 39.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma-Small"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma-Small", "1", cost, "  ✓");
                Shippment();
            }
            else if(shawarmaCOMBO.Text == "✅ Shawarma-Large                  ₱ 49.99")
            {
                Double cost = 49.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma-Large"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma-Large", "1", cost, "  ✓");
                Shippment();
            }
            else if(shawarmaCOMBO.Text == "✅ Shawarma-XL                     ₱ 59.99")
            {
                Double cost = 59.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma-XL"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma-XL", "1", cost, "  ✓");
                Shippment();
            }


            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled= true;
            }



            /*foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Shawarma"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                }
            }
            dataGRID.Rows.Add("Shawarma", "1", cost);
            Shippment();*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            lblNum.Enabled = false;

            // LABEL Clear
            codeBAR.Text = "";
            lblstatus.Text = "";
            lblNum.Text = "";
            lblshippment.Text = "";
            lblsubtotal.Text = "";
            lbltotal.Text = "";
            lblNum.Text = "";
            cbxPayment.Text = "";
            notice.Text = "";
            lblnumber.Text = "#";
            lblS.Text = "";
            // Picking Item Clear
            shawarmaCOMBO.Text = "";
            burgerCOMBO.Text = "";
            riceCOMBO.Text = "";
            friesCOMBO.Text = "";
            nachosCOMBO.Text = "";
            waterCOMBO.Text = "";
            cocaCOMBO.Text = "";
            dewCOMBO.Text = "";
            stingCOMBO.Text = "";
            //DATAGRID Clear
            dataGRID.Rows.Clear();
            dataGRID.Refresh();

            cbxPayment.Enabled = false;
            lblNum.Enabled = false;
            
        }

        private void pckBTN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void button_WOC10_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (cbxPayment.Text != string.Empty || lblNum.Text != string.Empty)
            {

                if (lblNum.Text != string.Empty)
                {

                    if (cbxPayment.Text == "✅ Gcash" || cbxPayment.Text == "✅ BDO" || cbxPayment.Text == "✅ Master Card" || cbxPayment.Text == "✅ PayMaya" || cbxPayment.Text == "✅ PayPal" || cbxPayment.Text == "✅ Cash on Delivery")
                    {
                        STATUS();
                    }
                    else if (dataGRID.Rows.Count == 0)
                    {
                        notice.Text = "🞽 Order foods and drinks to continue.";
                    }
                    else
                    {
                        lblNum.Text = "0";
                        notice.Text = "🞽 Please, select payment method to continue.";
                    }
                }
                else 
                { 
                    notice.Text = "🞽 Please, input your payment number to continue";
                }
            }
            else
            {
                notice.Text = "🞽 Please, select payment method to continue.";
            }
            

        }

        private void button_WOC1_Click_1(object sender, EventArgs e)
        {
            notice.Text = "";
            if (burgerCOMBO.Text == "✅ Shawarma Burger-Small         ₱ 29.99")
            {
                Double cost = 29.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma Burger-Small"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma Burger-Small", "1", cost, "  ✓");
                Shippment();
            }
            else if (burgerCOMBO.Text == "✅ Shawarma Burger-Large         ₱ 39.99")
            {
                Double cost = 39.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma Burger-Large"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma Burger-Large", "1", cost, "  ✓");
                Shippment();
            }

            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled = true;
            }

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {

            notice.Text = "";
            if (riceCOMBO.Text == "✅ Shawarma Rice-Large           ₱ 49.99")
            {
                Double cost = 49.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma Rice-Large"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma Rice-Large", "1", cost, "  ✓");
                Shippment();
            }
            else if (riceCOMBO.Text == "✅ Shawarma Rice-XL              ₱ 79.99")
            {
                Double cost = 79.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma Rice-XL"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma Rice-XL", "1", cost, "  ✓");
                Shippment();
            }

            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled = true;
            }
        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {

            notice.Text = "";
            if (friesCOMBO.Text == "✅ Shawarma Fries-Small           ₱ 39.99")
            {
                Double cost = 39.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma Fries-Small"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma Fries-Small", "1", cost, "  ✓");
                Shippment();
            }
            else if (friesCOMBO.Text == "✅ Shawarma Fries-Large           ₱ 49.99")
            {
                Double cost = 49.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma Fries-Large"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma Fries-Large", "1", cost, "  ✓");
                Shippment();
            }

            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled = true;
            }
        }

        private void button_WOC5_Click(object sender, EventArgs e)
        {
            notice.Text = "";

            if (nachosCOMBO.Text == "✅ Shawarma Nachos-Small         ₱ 39.99")
            {
                Double cost = 39.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma Nachos-Small"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma Nachos-Small", "1", cost, "  ✓");
                Shippment();
            }
            else if (nachosCOMBO.Text == "✅ Shawarma Nachos-Large         ₱ 49.99")
            {
                Double cost = 49.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Shawarma Nachos-Large"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Shawarma Nachos-Large", "1", cost, "  ✓");
                Shippment();
            }

            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled = true;
            }
        }


        private void button_WOC6_Click(object sender, EventArgs e)
        {
            notice.Text = "";
            if (waterCOMBO.Text == "✅ Mineral Water              ₱ 17.99")
            {
                Double cost = 17.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Mineral Water"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Mineral Water", "1", cost, "  ✓");
                Shippment();
            }

            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled = true;
            }
        }

        private void button_WOC7_Click(object sender, EventArgs e)
        {
            notice.Text = "";
            if (cocaCOMBO.Text == "✅ Coca-Cola              ₱ 17.99")
            {
                Double cost = 17.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Coca-Cola"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Coca-Cola", "1", cost, "  ✓");
                Shippment();
            }

            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled = true;
            }
        }

        private void button_WOC8_Click(object sender, EventArgs e)
        {
            notice.Text = "";
            if (dewCOMBO.Text == "✅ Mountain Dew                 ₱ 17.99")
            {
                Double cost = 17.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Mountain Dew"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Mountain Dew", "1", cost, "  ✓");
                Shippment();
            }

            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled = true;
            }
        }

        private void button_WOC9_Click(object sender, EventArgs e)
        {
            notice.Text = "";
            if (stingCOMBO.Text == "✅ Sting                 ₱ 17.99")
            {
                Double cost = 17.99;
                foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
                {
                    if ((bool)(row.Cells[0].Value = "Sting"))
                    {
                        row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                        row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * cost;
                    }
                }
                dataGRID.Rows.Add("Sting", "1", cost, "  ✓");
                Shippment();
            }

            if (dataGRID.Rows.Count == 0)
            {
                cbxPayment.Enabled = false;
                lblNum.Enabled = false;
            }
            else
            {
                cbxPayment.Enabled = true;
            }
        }

        private void lblCost_TextChanged(object sender, EventArgs e)
        {
            lblNum.MaxLength = 11;

            if (System.Text.RegularExpressions.Regex.IsMatch(lblNum.Text, "[^0-9]"))
            {
                notice.Text = "🞽 Only accept numbers. Try Again.";
                lblNum.Text = lblNum.Text.Remove(lblNum.Text.Length - 1);
            }

            /*if(lbltotal.Text == string.Empty)
            {
                lblNum.Text = "";
            }

            if (cbxPayment.Text == "✅ Gcash")
            {
                lblNum.MaxLength = 11;
                lblNum.Text = "0";
            }
            else if (cbxPayment.Text == "✅ BDO")
            {
                lblNum.MaxLength = 13;
                lblNum.Text = "0";
            }
            else if (cbxPayment.Text == "✅ Master Card")
            {
                lblNum.MaxLength = 16;
                lblNum.Text = "0";
            }
            else if (cbxPayment.Text == "✅ PayMaya")
            {
                lblNum.MaxLength = 12;
                lblNum.Text = "0";
            }
            else if (cbxPayment.Text == "✅ PayPal")
            {
                lblNum.MaxLength = 9;
                lblNum.Text = "0";
            }*/

        }

        private void COD()
        {
            
        }

        private void cbxPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbltotal.Text == string.Empty)
            {
                cbxPayment.Text = "None";
            }

            cbxPayment.Enabled = true;
            if (cbxPayment.Text == "✅ Gcash" || cbxPayment.Text == "✅ BDO" || cbxPayment.Text == "✅ Master Card" || cbxPayment.Text == "✅ PayMaya" || cbxPayment.Text == "✅ PayPal")
            {
                lblNum.Text = "0";
                lblNum.Enabled = true;
            }
            else
            {
                lblNum.Text = "0";
                lblNum.Enabled=false;
            }

            if (cbxPayment.Text == "✅ Cash on Delivery") 
            {
                lblnumber.Text = "🚚 COD";
                lblNum.Enabled = false;
                
            }
            else if (cbxPayment.Text == "✅ Gcash")
            {
                lblnumber.Text = "Gcash #";
            }
            else if(cbxPayment.Text == "✅ BDO")
            {
                lblnumber.Text = "BDO #";
            }
            else if(cbxPayment.Text == "✅ Master Card")
            {
                lblnumber.Text = "Master Card #";
            }
            else if(cbxPayment.Text == "✅ PayMaya")
            {
                lblnumber.Text = "PayMaya #";
            }
            else if(cbxPayment.Text == "✅ PayPal")
            {
                lblnumber.Text = "PayPal #";
            }

            
        }

        private void codeBAR_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in this.dataGRID.SelectedRows)
            {
                dataGRID.Rows.Remove(row);
            }
            Shippment();

        }

        private void dataGRID_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void shawarmaCOMBO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void shawarmaCOMBO_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void accNAME_Click(object sender, EventArgs e)
        {
            accountINFO.Visible = true;
            accountINFO.Location = new Point(298, 39);
            accountINFO.Size = new Size(272, 261);

            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            string sql = "select * from Accounts where emailadd= '" + accNAME.Text + "'";
            cmd.CommandText = sql;

            OleDbDataReader reader = null;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nameD.Text = reader["name"].ToString();
                genderD.Text = reader["gender"].ToString();
            }

            connection.Close();
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            accountINFO.Location = new Point(298, 39);
            accountINFO.Size = new Size(272, 10);
        }

        private void PaymentLOADING_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblstatus_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            HomePanel.Location = new Point(3, 609);
            HomePanel.Visible = false;
            HOME.Visible = false;
            MENU.Visible = false;
            ABOUT.Visible = false;
            CONTACT.Visible = false;
            HISTORY.Visible = true;

            string connDATA = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nielm\OneDrive\Documents\SHAWARMA.accdb";
            string query = "SELECT * From History";

            using (OleDbConnection conn = new OleDbConnection(connDATA))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    showHISTORYDATA.DataSource = ds.Tables[0];
                }
            }
        }

        private void showHISTORYDATA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void doneBTN_Click(object sender, EventArgs e)
        {
            string connD = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nielm\OneDrive\Documents\SHAWARMA.accdb";
            OleDbCommand conn = new OleDbCommand(connD);
            connection.Open();

            //Thinking that the first cell in every row contains the primary key, it will get the primary key from the first selected row
            string key = showHISTORYDATA.SelectedRows[0].Cells[0].Value.ToString();
            OleDbCommand cmd = new OleDbCommand("Delete * from History WHERE First_Name = '" + key + "'", connection);
            cmd.ExecuteNonQuery();

            //Get the index of the selected row and delete it from the rows
            int indexOfSelectedRow = showHISTORYDATA.SelectedRows[0].Index;
            showHISTORYDATA.Rows.RemoveAt(indexOfSelectedRow);
            connection.Close();
        }

        private void HOME_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HomePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

