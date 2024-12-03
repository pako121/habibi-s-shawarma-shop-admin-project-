using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoundButtonDemo
{
    public partial class LOGIN : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public static LOGIN instance;
        public LOGIN()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nielm\OneDrive\Documents\SHAWARMA.accdb;
Persist Security Info=False;";
            instance = this;
        }
        private void LOGIN_Load(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnEXIT_MouseEnter(object sender, EventArgs e)
        {
            btnEXIT.BackColor = Color.Red;
        }

        private void btnEXIT_MouseLeave(object sender, EventArgs e)
        {
            btnEXIT.BackColor= Color.Transparent;
        }

        private void button_WOC1_MouseEnter(object sender, EventArgs e)
        {
            button_WOC1.BackColor = Color.Green;
        }

        private void button_WOC1_MouseLeave(object sender, EventArgs e)
        {
            button_WOC1.BackColor = Color.Transparent;
        }

       

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {

                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;
                comm.CommandText = "select * from Accounts where emailadd ='" + textBox1.Text + "'and pass ='" + textBox2.Text + "'";

                OleDbDataReader or = comm.ExecuteReader();
                int count = 0;
                while (or.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {

                    STOREload load = new STOREload();
                    load.Show();
                    this.Hide();

                    STOREload.instance.userName.Text = textBox1.Text;
                }
                else
                {
                    noticeLOGIN.Text = "🞽 Wrong email address or password. Try again.";
                }
                connection.Close();

            }
            else
            {
                noticeLOGIN.Text = "🞽 Please enter value in all field.";
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadREG reg = new loadREG();
            reg.Show();
            this.Close();
        }

        private void noticeLOGIN_Click(object sender, EventArgs e)
        {
            //noticeLOGIN.Text = "Wrong email or password. Try again.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                checkBox1.Visible = true;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                checkBox1.Visible = false;
                checkBox2.Visible = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Visible = false;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
