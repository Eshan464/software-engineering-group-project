﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certificate_Generator
{
    public partial class Add_Student4 : Form
    {
        public Add_Student4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm To Exit?","Alert",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void nametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((!char.IsLetter(e.KeyChar))&&(!char.IsWhiteSpace(e.KeyChar))&&(!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void idtextbox_TextChanged(object sender, EventArgs e)
        {
            enrolltextbox.BackColor = Color.White;
        }

        private void idtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void contacttextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void institutetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void countrytextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            nametextbox.Clear();
            enrolltextbox.Clear();
            contacttextbox.Clear();
            emailtextbox.Clear();
            institutetextbox.Clear();
            countrytextbox.Clear();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if(nametextbox.Text=="")
            {
                nametextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametextbox.Focus();
                return;
            }
            if (enrolltextbox.Text == "")
            {
                enrolltextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Enroll", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enrolltextbox.Focus();
                return;
            }
            if (!((malebutton.Checked)||(femalebutton.Checked)))
            {
                MessageBox.Show("Please enter your Gender", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (contacttextbox.Text == "")
            {
                contacttextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Contact", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }
            if (emailtextbox.Text == "")
            {
                emailtextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Email", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }
            if (institutetextbox.Text == "")
            {
                institutetextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Institute Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                institutetextbox.Focus();
                return;
            }
            if (countrytextbox.Text == "")
            {
                countrytextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Country Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                countrytextbox.Focus();
                return;
            }

            

              String sname = nametextbox.Text;
              String senroll = enrolltextbox.Text;
              String sgender;
             
            if(malebutton.Checked)
            {
                sgender = "Male";
            }
            else
            {
                sgender = "Female";
            }

            String scontact =contacttextbox.Text;
            String semail = emailtextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;

            int a=contacttextbox.Text.Length;
            if(!(a==11))
            {
                MessageBox.Show("Invalid Contact", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }

            int n=semail.Length;
            if(!(semail==semail.ToLower()))
            {
                MessageBox.Show("Invalid Email!! all alphabet will be in lower case", "email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }

            if (!(semail[n-1]=='m'&& semail[n - 2] == 'o' && semail[n - 3] == 'c' && semail[n - 4] == '.' && semail[n - 5] == 'l' && semail[n - 6] == 'i' && semail[n - 7] == 'a' && semail[n - 8] == 'm' && semail[n - 9] == 'g' && semail[n - 10] == '@'))
            {
                MessageBox.Show("Invalid Email","email",MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }


            // cheaking if the student enroll is already exist in database


            int count = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addstudentcourse4 where senroll = '" + enrolltextbox.Text + "'";
          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            if(count > 0)
            {
                MessageBox.Show("Student Enroll aleady exists in database.. Choose Another", "Enroll Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                enrolltextbox.Focus();
                return;
            }


            // cheaking if the student email is already exist in database

            int count2;


            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;

            cmd2.CommandText = "select * from addstudentcourse4 where semail = '" + emailtextbox.Text + "'";
           
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            count2 = Convert.ToInt32(ds2.Tables[0].Rows.Count.ToString());

            if (count2 > 0)
            {
                MessageBox.Show("Student Email aleady exists in database.. Choose Another", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailtextbox.Focus();
                return;
            }



            // cheaking if the student contact is already exist in database

            int count3;


            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;

            cmd3.CommandText = "select * from addstudentcourse4 where scontact = '"+contacttextbox.Text+"' ";

            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            count3 = Convert.ToInt32(ds3.Tables[0].Rows.Count.ToString());

            if (count3 > 0)
            {
                MessageBox.Show("Student Contact aleady exists in database.. Choose Another", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                contacttextbox.Focus();
                return;
            }


            // inerting neew student in databse


            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con4;

            con4.Open();
            cmd4.CommandText = " insert into addstudentcourse4(sname,senroll,sgender,scontact,semail,sinstitute,scountry) values ('" + sname + "','" + senroll + "','" + sgender + "','" + scontact + "','" + semail + "','" + sinstitute + "','" + scountry + "')";
            cmd4.ExecuteNonQuery();
            con4.Close();

            MessageBox.Show("data saved!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void nametextbox_TextChanged(object sender, EventArgs e)
        {
            nametextbox.BackColor = Color.White;
        }

        private void malebutton_CheckedChanged(object sender, EventArgs e)
        {
            malebutton.BackColor = Color.White;
        }

        private void femalebutton_CheckedChanged(object sender, EventArgs e)
        {
            femalebutton.BackColor = Color.White;
        }

        private void contacttextbox_TextChanged(object sender, EventArgs e)
        {
            contacttextbox.BackColor = Color.White;
        }

        private void emailtextbox_TextChanged(object sender, EventArgs e)
        {
            emailtextbox.BackColor = Color.White;
        }

        private void institutetextbox_TextChanged(object sender, EventArgs e)
        {
            institutetextbox.BackColor = Color.White;
        }

        private void countrytextbox_TextChanged(object sender, EventArgs e)
        {
            countrytextbox.BackColor = Color.White;
        }
    }
}
