using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing.Layout;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;


namespace ProductManagement2
{
    public partial class UserHome : Form
    {
        User ui;
        Product p = new Product();
        Cart cp = new Cart();
        UpdateDBlink db = new UpdateDBlink();
        ProductManagementDataContext pd = new ProductManagementDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Imran Imo\Desktop\projectimo2\projectimo1\projectimo\Project\ProductManagement2\ProductManagement2\ProdectM.mdf;Integrated Security=True;Connect Timeout=30");
          
         
        PdfDocument pdf = new PdfDocument();
        

        double ans;
        double a, b, d;
        int pdfsl = 1;
        double grandTotal = 0;
        string location;


        public UserHome()
        {
            InitializeComponent();

        }

        public UserHome(User ui)
        {
            InitializeComponent();

            this.ui = ui;
            textBox1.Text = ui.Name;
            textBox2.Text = Convert.ToString(ui.Id);
            textBox3.Text = ui.FirstName;
            textBox4.Text = ui.LastName;
            textBox5.Text = ui.MobileNo;
            textBox6.Text = ui.Email;
            textBox7.Text = ui.Address;
            textBox8.Text = ui.Gender;
            groupBox6.Visible = false;
            textBox24.ReadOnly = true;
        }

        // logout button 
        private void button1_Click(object sender, EventArgs e)
        {
            var x = from az in pd.Carts
                    select az;
            
            foreach (Cart c in x)
            {
                pd.Carts.DeleteOnSubmit(c);
            }
            pd.SubmitChanges();
            
            Login l = new Login();
            l.Show();
            this.Visible = false;
        }

        private void UserHome_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = pd.ProductInfos;
            dataGridView1.Columns["BuyingPrice"].Visible = false;
            dataGridView1.Columns["Profit"].Visible = false;

            dataGridView2.DataSource = p.GetProducts();
            dataGridView4.DataSource = pd.Carts;
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox13.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[0].Value.ToString();

            textBox12.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            textBox11.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
            textBox14.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[8].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // logout from menu bar

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = from az in pd.Carts
                    select az;

            foreach (Cart cp in x)
            {
                pd.Carts.DeleteOnSubmit(cp);
            }
            pd.SubmitChanges();
            
            
            Login l = new Login();
            l.Show();
            this.Visible = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        //User Info Update Button

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (button3.Text == "Update")
            {
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                button3.Text = "Confirm Update";

            }
            else
            {
                var x = from a in pd.CustomerInfos
                        where a.user_name == (textBox1.Text)
                        select a;

                x.First().First_name = textBox3.Text;
                x.First().Last_name = textBox4.Text;

                ////
            if (textBox5.Text.Length == 11 && (textBox5.Text.StartsWith("016") || textBox5.Text.StartsWith("017") || textBox5.Text.StartsWith("018") || textBox5.Text.StartsWith("019") || textBox5.Text.StartsWith("015")))
            {
                 x.First().mobile = textBox5.Text;
            }
            else
            {
                MessageBox.Show("Wrong Mobile Number  !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox5.Text = "";
            }
            if ((textBox6.Text.Contains("@") && textBox6.Text.Contains(".com")) && (!textBox6.Text.StartsWith("@") || !textBox6.Text.StartsWith(" ")))
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
                        msg.Subject = "Email Change Request from Inventory management";
                        msg.Body = "WELCOME TO INVENTORY MANAGEMENT SYSTEM \n\n\n Your mail address is validet \n\n\n Thank you";
                        client.Send(msg);
                        MessageBox.Show("Email Validation Complete");
                        x.First().email = textBox6.Text;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                ////
               
            }
            else 
            {
                MessageBox.Show("Use Valid Email ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            x.First().address = textBox7.Text;
            x.First().gender = textBox8.Text;

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || textBox8.Text.Length == 0)
            {
                  MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }     
      
                pd.SubmitChanges();
                dataGridView3.DataSource = x.ToList();

                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                button3.Text = "Update";
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //Product Total price calculation is here 

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("Please Mention Your Purchasing Quantity Here", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox15.Text = "Enter Your Purchasing Quantity";


            }
            else
            {
                try
                {
                    a = Double.Parse(textBox15.Text);
                    b = Double.Parse(textBox9.Text);
                    d = double.Parse(textBox11.Text);
                    if (d <= a)
                    {
                        MessageBox.Show("Sorry Sir !This Quantity isn't available right now. :( ", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox15.Text = "Enter Your Purchasing Quantity";
                    }
                    else
                    {
                        ans = a * b;
                        textBox23.Text = ans.ToString();
                    }

                }
                catch
                {
                   
                   MessageBox.Show("Select A Product First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBox15.Text = "Enter Your Purchasing Quantity";
                }
            }

        }

        //Product Add to cart button


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox15.Text != "Enter Your Purchasing Quantity")
            {
                textBox20.Text = textBox15.Text;
                textBox21.Text = textBox12.Text;
                textBox22.Text = textBox13.Text;
                textBox19.Text = textBox10.Text;
                textBox16.Text = textBox9.Text;
                textBox23.Text = textBox18.Text;
                textBox17.Text = textBox14.Text;
                textBox18.Text = ans.ToString();
                textBox15.Text = "Enter Your Purchasing Quantity";
                Cart cp = new Cart
                {
                    CPId = Convert.ToInt32(textBox22.Text),
                    CPName = textBox21.Text,
                    CProductType = textBox19.Text,
                    Quantity = Convert.ToInt32(textBox20.Text),
                    Price = textBox16.Text,
                    TotalPrice = textBox18.Text,
                    District = textBox17.Text,

                };
                 try
                {
                    pd.Carts.InsertOnSubmit(cp);
                    pd.SubmitChanges();
                    MessageBox.Show("Product Added In The Cart Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dataGridView4.DataSource = pd.Carts;
                    dataGridView5.DataSource = pd.Carts;
                }
                catch
                {

                }
            }
            else 
            {
                MessageBox.Show("Enter Valid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox15.Text = "Enter Your Purchasing Quantity";
            }
            
           
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            textBox23.Text = ans.ToString();
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            textBox15.Text = "";
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {

        }

        //variable declare

        string receipt = "", receipt1, receipt2;
        int SL = 1;

        ////button confirm order , pdf , cart table value delete

        private void button4_Click(object sender, EventArgs e)
        {

            var x = from az in pd.Carts
                    select az;

            foreach (Cart cp in x)
            {
                receipt += (SL + "      " +cp.CPId + "      " + cp.CPName + "          " + cp.Quantity + "             " + cp.Price + "             "+cp.TotalPrice+"\n");
                SL++;
                grandTotal += double.Parse(cp.TotalPrice);
                MessageBox.Show("in the loop" +cp.TotalPrice, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           
            }

            //pdf starts here

            pdf.Info.Title = "Receipt Of Products";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(graph);
            receipt1 = "                         AIUB Product Delevary Farm LTD.\n";
            receipt1 += "                           Kuratoli Bazar, Bishaw Road\n";
            receipt1 += "                              Vat reg. No= 123456789\n";
            receipt1 += "User Name :" + ui.Name + "\nName  :" + ui.FirstName + " " + ui.LastName;
            receipt1 += "\nSL.   " + "ID     " + "Name               " + "Quantity   " + "Price     " + "TotalPrice\n";
           
            receipt2 =  "\n\n                          Grand Total=" + grandTotal;
            receipt1 = receipt1 + receipt + receipt2;
            tf.DrawString(receipt1, font, XBrushes.Black,new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
           
            string pdffilename = "Receipt of "+ui.Name+pdfsl+".pdf";
            pdfsl++;
            pdf.Save(pdffilename);
            location = "C:/Users/Imran Imo/Desktop/projectimo2/projectimo1/projectimo/Project/ProductManagement2/ProductManagement2/bin/Debug/"+pdffilename;
           
            //pdf ends here 

            // cart table data delete starts

            var y = from az in pd.Carts
                    select az;

           foreach (Cart cp in y)
            {
                pd.Carts.DeleteOnSubmit(cp);
               
            }
            pd.SubmitChanges();

            // cart table data delete ends
            //Cart details Groupbox textfield clear

            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox19.Text = "";
            textBox16.Text = "";
            textBox23.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            
            MessageBox.Show("Ordered Confirmed For Mr."+ui.Name, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            groupBox6.Visible = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox13.Text = dataGridView2.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[0].Value.ToString();

            textBox12.Text = dataGridView2.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            textBox11.Text = dataGridView2.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();
            textBox9.Text = dataGridView2.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
            textBox10.Text = dataGridView2.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
            textBox14.Text = dataGridView2.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[8].Value.ToString();
        
        }

       
        //payment button//

        private void button6_Click(object sender, EventArgs e)
        {
            bool isChecked = radioButton1.Checked;
            if (isChecked) 
            {
                // admin balance increment for cash on delivery
                var y = from b in pd.Accounts
                        where b.AccountNo == "01677333203"
                        select b;
                foreach (Account ac in y)
                {
                    ac.AccountBalance = ac.AccountBalance + grandTotal;

                }
                pd.SubmitChanges();
            }
            else
            {   
                //User Balance Deduction

                var x = from a in pd.Accounts
                        where a.AccountNo == textBox24.Text
                        select a;
                foreach (Account ac in x)
                {
                    ac.AccountBalance = ac.AccountBalance - grandTotal;
                    MessageBox.Show("." + ac.AccountNo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                pd.SubmitChanges();

                //Admin Balance Increment for bkash credit debit card Mcash

                var y = from b in pd.Accounts
                        where b.AccountNo == "01677333203"
                        select b;
                foreach (Account ac in y)
                {
                    ac.AccountBalance = ac.AccountBalance + grandTotal;

                }
                pd.SubmitChanges();
            }

            
            System.Diagnostics.Process.Start(location);
        }

        private void textBox24_Enter(object sender, EventArgs e)
        {
            textBox24.Text = "";
        }

        private void textBox24_Leave(object sender, EventArgs e)
        {
            textBox24.Text = "Enter Your Account Number Here";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox24.ReadOnly = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox24.ReadOnly = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox24.ReadOnly = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox24.ReadOnly = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox24.ReadOnly = false;
        }


        // order cancel button 

        private void button5_Click(object sender, EventArgs e)
        {
            var x = from az in pd.Carts
                    select az;
            
            foreach (Cart c in x)
            {
                pd.Carts.DeleteOnSubmit(c);
            }
            pd.SubmitChanges();
            MessageBox.Show("You canceled Your Order Mr." + ui.Name, "Sorry! You Have this Experience", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_passwordChange a = new User_passwordChange(ui);
            a.Show();
            this.Visible = false;
        }

    }
}
