using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement2
{
    public partial class Login : Form
    {
        User ui = new User();
        AdminInfo ai= new AdminInfo();
        

        public Login()
        {
            InitializeComponent();
            textBox1.Text = "Enter Username";
            textBox2.Text = "Enter Password";
        }

     
        


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           

        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Password";

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
            this.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDBlink ul = new UpdateDBlink();
            ai = ul.getAdmin(textBox1.Text);

            string pass;

            if(textBox1.Text == ai.UName && ai.UStatus == "Admin")
            {

                if (textBox2.Text == ai.Pword)
                {
                   /* HomeAdmin h = new HomeAdmin(ai);
                    h.Show();
                    this.Visible = false;
                    */
                    AdminHome h = new AdminHome(ai);
                    h.Show();
                    this.Visible = false;

                }
                else
                {
                    MessageBox.Show("Wrong Password or Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {   
                ui=ul.getUser(textBox1.Text);
                pass = ul.getPassword(textBox1.Text);

                if (textBox2.Text == pass)
                {
                   UserHome h = new UserHome(ui);
                    h.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Wrong Password or Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Username";
            }
        }


        private void textBox2_Enter(object sender, EventArgs e)
        {
          
                textBox2.Text = "";
           

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


   }


  

}

