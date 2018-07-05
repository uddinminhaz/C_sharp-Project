using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace ProductManagement2
{
    public partial class Registration : Form
    {
        User u = new User();
        string status = "User";
        ProductManagementDataContext pd = new ProductManagementDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Imran Imo\Desktop\projectimo2\projectimo1\projectimo\Project\ProductManagement2\ProductManagement2\ProdectM.mdf;Integrated Security=True;Connect Timeout=30");
          

        public Registration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            u.Name = textBox1.Text;
            u.FirstName = textBox2.Text;
            u.LastName = textBox8.Text;
            u.Password = textBox3.Text;
            u.MobileNo = textBox5.Text;
            u.Email = textBox6.Text;
            bool isChecked = radioButton1.Checked;
           
            if (isChecked)
            {
                u.Gender = radioButton1.Text;
            }
            else
            {
                u.Gender = radioButton2.Text;
            }
            u.Address = textBox7.Text;

            if (textBox3.Text.Length <= 3)
            {
                MessageBox.Show("Password is too short !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox3.Text = "";
                textBox4.Text = "";
            }


            if (textBox5.Text.Length == 11 && (textBox5.Text.StartsWith("016") || textBox5.Text.StartsWith("017") || textBox5.Text.StartsWith("018") || textBox5.Text.StartsWith("019") || textBox5.Text.StartsWith("015")))
            {
                
            }
            else
            {
                MessageBox.Show("Wrong Mobile Number  !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox5.Text = "";
            }


            if ((textBox6.Text.Contains("@") && textBox6.Text.Contains(".com")) && (!textBox6.Text.StartsWith("@") || !textBox6.Text.StartsWith(" ")))
            {

               
            }
            else 
            {
                MessageBox.Show("Use Valid Email ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox3.Text == textBox4.Text )
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || textBox8.Text.Length == 0)
                {
                    MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {
                    ////////////////////////
                    try
                    {

                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("uddinminhazaiub121@gmail.com", "zigatola1234");
                        MailMessage msg = new MailMessage();
                        msg.To.Add(textBox6.Text);
                        msg.From = new MailAddress("uddinminhazaiub121@gmail.com");
                        msg.Subject = "Email Validaton . Login accepted for Inventory management";
                        msg.Body = "WELCOME TO INVENTORY MANAGEMENT SYSTEM \n\n\n Your mail address is validet \n\n\n Thank you";
                        client.Send(msg);
                        MessageBox.Show("Email Validation Complete");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////
                   
                    CustomerInfo c = new CustomerInfo
                    {

                        user_name = u.Name,
                        First_name = u.FirstName,
                        Last_name = u.LastName,
                        password = u.Password,
                        mobile = u.MobileNo,
                        address = u.Address,
                        gender = u.Gender,
                        email = u.Email,
                        Status = status

                    };

                    pd.CustomerInfos.InsertOnSubmit(c);
                    pd.SubmitChanges();

                    UserHome h = new UserHome(u);
                    h.Show();
                    this.Visible = false;
                }

                }
                else 
            {

                MessageBox.Show("Wrong Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Visible = false;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter The Password agian";
            }
           
        }
        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Enter Your Valid Email Here";
            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Your User Name Here";
            }
            else
            {
                UpdateDBlink ul = new UpdateDBlink();
                u = ul.getUser(textBox1.Text);
                if (textBox1.Text == u.Name)
                {
                    MessageBox.Show("Invalid Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Select();
                }
            }
            
           
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Your First Name Here";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Enter Your Last Name Here";
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Your Password Here";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Enter Your 11 Digit Phone Number";
            }
        }
        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Enter Your Address Here";
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

      

       

    }
}
