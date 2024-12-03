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
using System.Data.SqlClient;

namespace RoundButtonDemo
{
    public partial class Registration : Form

    {
        string Gender;
        private OleDbConnection connection = new OleDbConnection();
        public Registration()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nielm\OneDrive\Documents\SHAWARMA.accdb;
Persist Security Info=False;";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor= Color.Transparent;
        }

        private void button_WOC1_MouseEnter(object sender, EventArgs e)
        {
            button_WOC1.BackColor = Color.Green;
        }

        private void button_WOC1_MouseLeave(object sender, EventArgs e)
        {
            button_WOC1.BackColor= Color.Transparent;
        }

        private void btnEXIT_MouseEnter(object sender, EventArgs e)
        {
            btnEXIT.BackColor = Color.Red;
        }

        private void btnEXIT_MouseLeave(object sender, EventArgs e)
        {
            btnEXIT.BackColor= Color.Transparent;
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox4.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty)
            {
                if (femaleButton.Checked == true || maleButton.Checked == true)
                {

                    if (textBox2.Text == textBox3.Text)
                    {
                        connection.Open();
                        OleDbCommand com = new OleDbCommand();
                        com.Connection = connection;
                        com.CommandText = "select * from Accounts where emailadd ='" + textBox1.Text + "'";
                        OleDbDataReader or = com.ExecuteReader();

                        if (or.Read())
                        {
                            noticeREG.Text = "🞽 Email Address already exist.";
                            connection.Close();
                        }
                        else if(textBox1.Text == string.Empty || textBox4.Text == string.Empty)
                        {
                            noticeREG.Text = "🞽 Please enter value in all field.";
                            connection.Close();
                        }
                        else
                        {
                            OleDbCommand con = new OleDbCommand();
                            con.Connection = connection;
                            con.CommandText = "insert into Accounts (emailadd, pass, confirmpass, name, gender) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Gender + "')";
                            con.ExecuteNonQuery();
                            noticeREG.Text = "";
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            maleButton.Checked = false;
                            femaleButton.Checked = false;

                            noticeREG.Text = "✔️ Account Created Successfully.";
                            connection.Close();
                        }
                    }
                    else
                    {
                        noticeREG.Text = "🞽 Please enter same password. Try again.";
                    }
                }
                else
                {
                    noticeREG.Text = "🞽 Please enter value in all field.";
                }
            }
            else
            {
                noticeREG.Text = "🞽 Please enter value in all field.";
            }


           



            //connection.Open();
            //OleDbCommand comm = new OleDbCommand();
            //comm.Connection = connection;
            //comm.CommandText = "insert into Accounts (emailadd, pass, confirmpass, name, gender) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Gender + "')";
            //comm.ExecuteNonQuery();
            //MessageBox.Show("Account Saved");

        }

        private void label7_Click(object sender, EventArgs e)
        {
            loadREG2 lg2 = new loadREG2();
            lg2.Show();
            this.Hide();
        }

        private void maleButton_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadREG2 lg2 = new loadREG2();
            lg2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            noticeREG.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maleButton.Checked = false;
            femaleButton.Checked = false;
        }

        private void noticeLOGIN_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void passCLOSE2_Click(object sender, EventArgs e)
        {
            
        }

        private void passSHOW_Click(object sender, EventArgs e)
        {
            
        }

        private void passSHOW2_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Visible = true;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                checkBox1.Visible = false;
                checkBox3.Visible = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Visible = false;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                checkBox1.Visible = true;
                checkBox3.Visible = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Visible = true;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                checkBox2.Visible = false;
                checkBox4.Visible = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox4.Visible = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                checkBox2.Visible = true;
                checkBox4.Visible = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
