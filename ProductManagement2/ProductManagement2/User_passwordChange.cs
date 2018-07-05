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
    public partial class User_passwordChange : Form
    {
        User ui;

        public User_passwordChange()
        {
            InitializeComponent();
        }
        public User_passwordChange(User ui)
        {
            InitializeComponent();
            this.ui = ui;
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
                    string x = ul.UpdateUserPassword(textBox1.Text, textBox2.Text, textBox3.Text);
                    MessageBox.Show(x);

                    UserHome uh = new UserHome(ui);
                    uh.Show();
                    this.Visible = false;


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserHome uh = new UserHome(ui);
            uh.Show();
            this.Visible = false;
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
               string pa = ul.getPassword(textBox1.Text);
                if (textBox1.Text == pa)
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
    }
}
