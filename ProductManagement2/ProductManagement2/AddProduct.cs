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
    public partial class AddProduct : Form
    {
        AdminInfo ai;
        Product pp = new Product();
        ProductManagementDataContext pm = new ProductManagementDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Imran Imo\Desktop\projectimo2\projectimo1\projectimo\Project\ProductManagement2\ProductManagement2\ProdectM.mdf;Integrated Security=True;Connect Timeout=30");
         

        public AddProduct()
        {
            InitializeComponent();


        }
        public AddProduct(AdminInfo ai)
        {
            this.ai = ai;
            InitializeComponent();
            comboBox2.Text = "Select";


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || comboBox1.SelectedIndex.ToString()=="Select" || comboBox2.SelectedIndex.ToString()=="Select" || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Please fill all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
               
                pp.ProductName = textBox1.Text;
                pp.PID = textBox2.Text;
                pp.Quantity = Convert.ToInt32(numericUpDown1.Value);
                pp.BuyingPrice = Convert.ToSingle(textBox3.Text);
                pp.SellingPrice = Convert.ToSingle(textBox4.Text);
                pp.Product_Type = textBox5.Text;
                pp.DivisionP = comboBox1.SelectedItem.ToString();
                pp.DistrictsP = comboBox2.SelectedItem.ToString();


               


                ProductInfo p = new ProductInfo
                {

                    Name = pp.ProductName,
                    ProductType = pp.Product_Type,
                    Division = pp.DivisionP,
                    Districts = pp.DistrictsP,
                    Quantity = pp.Quantity,
                    BuyingPrice = pp.BuyingPrice,
                    SellingPrice = pp.SellingPrice,
                    PId = pp.PID,
                    Profit = Convert.ToSingle(textBox4.Text) - Convert.ToSingle(textBox3.Text),


                };
                pm.ProductInfos.InsertOnSubmit(p);
                pm.SubmitChanges();
                MessageBox.Show("Add Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                AdminHome h = new AdminHome(ai);
                h.Show();
                this.Visible = false;



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHome h = new AdminHome(ai);
            h.Show();
            this.Visible = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select";
            comboBox1.Items.AddRange(new object[] { "Dhaka", "Chittagong", "Rajshahi", "Khulna", "Sylhet", "Mymensingh", "Barisal", "Rangpur" });

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
