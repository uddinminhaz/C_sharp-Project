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
    public partial class DeleteProduct : Form
    {
        AdminInfo ai;
        ProductManagementDataContext pd = new ProductManagementDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Imran Imo\Desktop\projectimo2\projectimo1\projectimo\Project\ProductManagement2\ProductManagement2\ProdectM.mdf;Integrated Security=True;Connect Timeout=30");
           
        public DeleteProduct()
        {
            InitializeComponent();
        }
        public DeleteProduct(AdminInfo ai)
        {
            InitializeComponent();
            this.ai = ai;
        }
        void UpdateGridView()
        {
            dataGridView1.DataSource = pd.ProductInfos;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            
            var x = from a in pd.ProductInfos
                    where a.PId == (textBox1.Text)
                    select a;

            textBox2.Text = x.First().Name;
            textBox3.Text = x.First().ProductType;

            dataGridView1.DataSource = x.ToList();
            UpdateGridView();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var x = from a in pd.ProductInfos
                    where a.PId == textBox1.Text
                    select a;
            foreach (ProductInfo p in x)
            {
                pd.ProductInfos.DeleteOnSubmit(p);
            }

            pd.SubmitChanges();
            UpdateGridView();
            MessageBox.Show("Successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AdminHome h = new AdminHome(ai);
            h.Show();
            this.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteProduct_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pd.ProductInfos;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Search Product By Id To Delete";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
        }
    }
}
