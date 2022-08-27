using ProjectBL5.Models;
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
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaHang.Text = "";
            txtGia.Text = "";
            txtTenHang.Text = "";
            txtTenHang.Enabled = true;
            txtMaHang.Enabled = true;
            txtGia.Enabled = true;
            cbxDonvi.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if (txtGia.Text.Equals("") || txtMaHang.Text.Equals("") || txtTenHang.Equals(""))
                {
                    MessageBox.Show("Bạn chưa nhập hết thông tin");
                }
                else
                {
                    TblMatHang cus = new TblMatHang
                    {
                        MaHang = txtMaHang.Text,
                        TenHang = txtTenHang.Text,
                        Gia = Convert.ToInt32(txtGia.Text),
                        Dvt = cbxDonvi.SelectedItem.ToString()
                    };
                    context.TblMatHangs.Add(cus);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Insert successfully");
                        loadData();
                    }
                    txtTenHang.Enabled = false;
                    txtMaHang.Enabled = false;
                    txtGia.Enabled = false;
                    cbxDonvi.Enabled = false;
                }
                
            }
        }

        private void loadData()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var data = context.TblMatHangs.Select(item => new
                {
                    MaHang = item.MaHang,
                    TenHang = item.TenHang,
                    Gia = item.Gia,
                    DVT = item.Dvt
                }).ToList();
                dataGridView1.DataSource = data;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTenHang.Enabled = true;
            txtMaHang.Enabled = true;
            txtGia.Enabled = true;
            cbxDonvi.Enabled = true;
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if (txtGia.Text.Equals("") || txtMaHang.Text.Equals("") || txtTenHang.Equals(""))
                {
                    MessageBox.Show("Bạn chưa nhập hết thông tin");
                }
                else
                {
                    TblMatHang pro = context.TblMatHangs.SingleOrDefault(item => item.MaHang.Equals(txtMaHang.Text));
                    pro.TenHang = txtTenHang.Text;
                    pro.MaHang = txtMaHang.Text;
                    pro.Gia = Convert.ToInt32(txtGia.Text);
                    pro.Dvt = cbxDonvi.SelectedItem.ToString();
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Update successfully");
                        loadData();
                    }
                    txtTenHang.Enabled = false;
                    txtMaHang.Enabled = false;
                    txtGia.Enabled = false;
                    cbxDonvi.Enabled = false;
                }
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                TblMatHang pro = context.TblMatHangs.SingleOrDefault(item => item.MaHang.Equals(txtMaHang.Text));
                context.TblMatHangs.Remove(pro);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Delete successfully");
                    loadData();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("May co muon thoat?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHang.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtTenHang.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtGia.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            cbxDonvi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
        }
    }
}
