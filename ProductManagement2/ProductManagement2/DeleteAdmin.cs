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
    public partial class DeleteAdmin : Form
    {
        AdminInfo ai;
        ProductManagementDataContext pd = new ProductManagementDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Imran Imo\Desktop\projectimo2\projectimo1\projectimo\Project\ProductManagement2\ProductManagement2\ProdectM.mdf;Integrated Security=True;Connect Timeout=30");
          
        public DeleteAdmin()
        {
            InitializeComponent();
        }

        public DeleteAdmin(AdminInfo ai)
        {
            InitializeComponent();
            this.ai = ai;
        }
        private void DeleteAdmin_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = pd.Admins;
        }
        void UpdateGridView()
        {
            dataGridView1.DataSource = pd.Admins;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminHome h = new AdminHome(ai);
            h.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pd.Admins;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[8].Value.ToString();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var x = from a in pd.Admins
                    where a.AdminId == int.Parse(textBox4.Text)
                    select a;

            textBox2.Text = x.FirstOrDefault().user_name;
            textBox3.Text = x.First().First_Name;

            dataGridView1.DataSource = x.ToList();
            UpdateGridView();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.Text = "Search Admin By id";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }
    }
}
