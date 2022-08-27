using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectBL5
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
        }

        private void Product_Click(object sender, EventArgs e)
        {
            UpdateProduct pro = new UpdateProduct();
            pro.Show();
        }

        private void Sale_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            sale.Show();
        }

        private void Report_click(object sender, EventArgs e)
        {
            Report rp = new Report();
            rp.Show();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ số điện thoại 0888.888.888 để được trợ giúp");
        }
    }
}
