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
    public partial class AddAdmin : Form
    {
        AdminInfo ai = new AdminInfo();
        User u;
        ProductManagementDataContext pd = new ProductManagementDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Imran Imo\Desktop\projectimo2\projectimo1\projectimo\Project\ProductManagement2\ProductManagement2\ProdectM.mdf;Integrated Security=True;Connect Timeout=30");
           

        string status = "Admin";

        public AddAdmin()
        {
            InitializeComponent();
        }

        public AddAdmin(AdminInfo ai)
        {
            this.ai = ai;
            InitializeComponent();
            UpdateDBlink db = new UpdateDBlink();

            textBox1.Text = Convert.ToString(db.getLatAdminId() + 1);
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {
          dataGridView1.DataSource = pd.Admins;    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0)
            {
                MessageBox.Show("Please filled all the field properly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                if (textBox3.Text.Length <= 3)
                {
                    MessageBox.Show("password too short", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {

                    Admin a = new Admin
                    {

                        user_name = textBox2.Text,
                        First_Name = textBox5.Text,
                        Last_name = textBox4.Text,
                        AdminPassword = textBox3.Text,
                        AdminId = Convert.ToInt32(textBox1.Text),
                        Status = status

                    };
                    MessageBox.Show("New Admin Added Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    pd.Admins.InsertOnSubmit(a);
                    pd.SubmitChanges();
                    //dataGridView1.DataSource = pd.Admins;
                    AdminHome h = new AdminHome(ai);
                    h.Show();
                    this.Visible = false;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminHome h = new AdminHome(ai);
            h.Show();
            this.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            UpdateDBlink ul = new UpdateDBlink();
            u = ul.getUser(textBox2.Text);
            ai = ul.getAdmin(textBox2.Text);
            if (textBox2.Text == u.Name || textBox2.Text == ai.UName)
            {
                MessageBox.Show("Invalid Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                textBox2.Select();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pd.Admins;
        }

        




    }
}
