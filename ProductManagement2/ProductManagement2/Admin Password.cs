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
    public partial class Admin_Password : Form
    {
        AdminInfo ai;
        public Admin_Password()
        {
            InitializeComponent();
        }
        public Admin_Password(AdminInfo ai)
        {
            InitializeComponent();
            this.ai = ai;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
           if (textBox1.Text == "")
            {
                textBox1.Text = "Enter current password Here";
            }
            else
            {
                UpdateDBlink ul = new UpdateDBlink();
                ai = ul.getAdmin(textBox1.Text);
                if (textBox1.Text == ai.Pword)
                {
                    MessageBox.Show("current password matched", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                   
                }
                else 
                {
                    MessageBox.Show("Enter valid current password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Select();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHome h = new AdminHome(ai);
            h.Show();
            this.Visible = false;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 3)
            {
                MessageBox.Show("Password is too short !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.Select();
            }
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Fillup All Text Boxs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Enter Valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    UpdateDBlink ul = new UpdateDBlink();
                    string x = ul.UpdateAdminPassword(textBox1.Text, textBox2.Text, textBox3.Text);
                    MessageBox.Show(x);

                    Login l = new Login();
                    l.Show();
                    this.Visible=false;


                }
            }

        }
    
    
    
    
    }

}
