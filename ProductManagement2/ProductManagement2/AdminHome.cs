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
    public partial class AdminHome : Form
    {
        Product p = new Product();
        AdminInfo ai = new AdminInfo();
        ProductManagementDataContext pd = new ProductManagementDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Imran Imo\Desktop\projectimo2\projectimo1\projectimo\Project\ProductManagement2\ProductManagement2\ProdectM.mdf;Integrated Security=True;Connect Timeout=30");
          
        
        public AdminHome()
        {
            InitializeComponent();
            
        }

        public AdminHome(AdminInfo ai)
        {
            
            this.ai = ai;
            InitializeComponent();
            textBox1.Text = ai.UName;
            textBox2.Text = ai.UFirstName;
            textBox3.Text = ai.ULastName;
            textBox4.Text = ai.Pword;

            textBox5.Text = ai.UName;
            textBox6.Text = Convert.ToString(ai.AID);
            this.disableA();
            this.disableP();
           

        }

        public void disableA()
        {
            button4.Visible = false;
            button10.Visible = false;
            button3.Visible = false;
            button9.Visible = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        
           
        
        }
        public void disableP()
        {
            button4.Visible = false;
            button10.Visible = false;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;

           // numericUpDown1.ReadOnly = true;
            comboBox1.TabStop = true;
        }

        public void enableP()
        {
            button4.Visible = true;
            button10.Visible = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;

           // numericUpDown1.ReadOnly = false;
            comboBox1.TabStop = false;
        
        
        }
        public void enableA()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;

            textBox1.Text = ai.UName;
            textBox2.Text = ai.UFirstName;
            textBox3.Text = ai.ULastName;
            textBox4.Text = ai.Pword;

            textBox5.Text = ai.UName;
            textBox6.Text = Convert.ToString(ai.AID);

        }


   

        private void AdminHome_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = pd.Admins;
            dataGridView2.DataSource = pd.CustomerInfos;
            dataGridView3.DataSource = pd.ProductInfos;
            //dataGridView3.DataSource = pd.DiscountProducts;
            dataGridView4.DataSource = p.GetProducts();
            comboBox1.Text = "Select";
            comboBox1.Items.AddRange(new object[] { "Dhaka", "Chittagong", "Rajshahi", "Khulna", "Sylhet", "Mymensingh", "Barisal", "Rangpur" });
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Visible = false;
        }


       
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ai.UFirstName = textBox2.Text;
                ai.ULastName = textBox3.Text;
                UpdateDBlink ul = new UpdateDBlink();
                string x = ul.UpdateAdmin(textBox1.Text, textBox2.Text, textBox3.Text);
                MessageBox.Show(x);


                AdminHome h = new AdminHome(ai);
                h.Show();
                this.Visible = false;

                

                button1.Show();
                button3.Hide();
                this.disableA();

            }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddAdmin a = new AddAdmin(ai);
            a.Show();
            this.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddProduct n = new AddProduct(ai);
            n.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteAdmin d = new DeleteAdmin(ai);
            d.Show();
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteProduct d = new DeleteProduct(ai);
            d.Show();
            this.Visible = false;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Password a = new Admin_Password(ai);
            a.Show();
            this.Visible = false;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button9.Visible = true;
            button1.Hide();
            enableA();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            button1.Show();
            button9.Hide();
            this.disableA();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            button10.Visible = true;
            button2.Hide();
            enableP();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 0 || textBox8.Text.Length == 0 || textBox9.Text.Length == 0 || textBox12.Text.Length == 0 || textBox10.Text.Length == 0 || textBox11.Text.Length == 0 || comboBox1.Text.Length == 0 || comboBox2.Text.Length == 0)
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                UpdateDBlink ul = new UpdateDBlink();
                string x = ul.UpdateProduct(textBox7.Text, textBox8.Text, textBox9.Text, textBox12.Text, textBox10.Text, textBox11.Text, comboBox1.Text, comboBox2.Text);
                MessageBox.Show(x);
                button2.Show();
                button4.Hide();
                this.disableP();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button2.Show();
            button4.Hide();
            button10.Hide();
            this.disableP();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView3.Rows[(dataGridView3.SelectedCells[0].RowIndex)].Cells[0].Value.ToString();
            textBox8.Text = dataGridView3.Rows[(dataGridView3.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            textBox9.Text = dataGridView3.Rows[(dataGridView3.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
            textBox10.Text = dataGridView3.Rows[(dataGridView3.SelectedCells[0].RowIndex)].Cells[3].Value.ToString();
            textBox11.Text = dataGridView3.Rows[(dataGridView3.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
            textBox12.Text = dataGridView3.Rows[(dataGridView3.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView3.Rows[(dataGridView3.SelectedCells[0].RowIndex)].Cells[7].Value.ToString();
            comboBox2.Text = dataGridView3.Rows[(dataGridView3.SelectedCells[0].RowIndex)].Cells[8].Value.ToString();      
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Dhaka")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    comboBox2.Items.AddRange(new object[] { "Dhaka", "Faridpur", "Gazipur", "Gopalganj", "Kishoreganj", "Madaripur", "Manikganj", "Munshiganj", "Narayanganj", "Narsingdi", "Rajbari", "Shariatpur", "Tangail" });
                }
                else if (comboBox1.SelectedItem.ToString() == "Chittagong")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    comboBox2.Items.AddRange(new object[] { "Bandarban", "Brahmanbaria", "Chandpur", "Chittagong", "Comilla", "Cox's Bazar", "Feni", "Khagrachhari", "Lakshmipur", "Noakhali", "Rangamati" });
                }
                else if (comboBox1.SelectedItem.ToString() == "Rajshahi")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    comboBox2.Items.AddRange(new object[] { "Bogra", "Jaipurhat", "Naogaon", "Natore", "Chapai", "Nawabganj", "Pabna", "Rajshahi", "Sirajganj" });
                }
                else if (comboBox1.SelectedItem.ToString() == "Khulna")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    comboBox2.Items.AddRange(new object[] { "Bagerhat", "Chuadanga", "Jessore", "Jhenaidah", "Khulna", "Kushtia", "Magura", "Meherpur", "Narail", "Satkhira" });
                }
                else if (comboBox1.SelectedItem.ToString() == "Sylhet")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    comboBox2.Items.AddRange(new object[] { "Habiganj", "Moulvibazar", "Sunamganj", "Sylhet" });
                }
                else if (comboBox1.SelectedItem.ToString() == "Mymensingh")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    comboBox2.Items.AddRange(new object[] { "Jamalpur", "Mymensingh", "Netrokona", "Sherpur" });
                }
                else if (comboBox1.SelectedItem.ToString() == "Barisal")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    comboBox2.Items.AddRange(new object[] { "Barguna", "Barisal", "Bhola", "Jhalokati", "Patuakhali", "Pirojpur" });
                }
                else if (comboBox1.SelectedItem.ToString() == "Rangpur")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    comboBox2.Items.AddRange(new object[] { "Dinajpur", "Gaibandha", "Kurigram", "Lalmonirhat", "Nilphamari", "Panchagarh", "Rangpur", "Thakurgaon" });
                }
                else if (comboBox1.SelectedItem.ToString() == "Select")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "Select";
                    MessageBox.Show("Fill The DropDown Box", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fill The DropDown Box", "Exception Message: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedItem.ToString() == "Select")
                {

                    MessageBox.Show("Fill The DropDown Box", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fill The DropDown Box", "Exception Message: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Visible = false;
        }

       
    }
}
