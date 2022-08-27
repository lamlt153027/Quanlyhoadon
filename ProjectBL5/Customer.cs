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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

       

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            dtpBirth.Text = "";
            txtDiachi.Text = "";
            txtName.Text = "";
            txtMaKH.Enabled = true;
            dtpBirth.Enabled = true;
            txtDiachi.Enabled = true;
            txtName.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {   
                if(txtName.Text == "" || txtMaKH.Text == "" || txtDiachi.Text == "" || (rbtFemale.Checked == false && rbtMale.Checked == false)) 
                {
                    MessageBox.Show("Bạn chưa nhập hết thông tin");
                }
                else
                {
                    TblKhachHang cus = new TblKhachHang
                    {
                        TenKh = txtName.Text,
                        MaKh = txtMaKH.Text,
                        Gt = rbtMale.Checked,
                        Diachi = txtDiachi.Text,
                        NgaySinh = dtpBirth.Value
                    };
                    context.TblKhachHangs.Add(cus);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        loadData();
                    }
                    txtMaKH.Enabled = false;
                    dtpBirth.Enabled = false;
                    txtDiachi.Enabled = false;
                    txtName.Enabled = false;
                }
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = true;
            dtpBirth.Enabled = true;
            txtDiachi.Enabled = true;
            txtName.Enabled = true;
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if (txtName.Text == "" || txtMaKH.Text == "" || txtDiachi.Text == "" || (rbtFemale.Checked == false && rbtMale.Checked == false))
                {
                    MessageBox.Show("Bạn chưa nhập hết thông tin");
                }
                else
                {
                    TblKhachHang pro = context.TblKhachHangs.SingleOrDefault(item => item.MaKh.Equals(txtMaKH.Text));
                    pro.TenKh = txtName.Text;
                    pro.MaKh = txtMaKH.Text;
                    pro.NgaySinh = dtpBirth.Value;
                    pro.Gt = rbtMale.Checked;
                    pro.Diachi = txtDiachi.Text;
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        loadData();
                    }
                    txtMaKH.Enabled = false;
                    dtpBirth.Enabled = false;
                    txtDiachi.Enabled = false;
                    txtName.Enabled = false;
                }               
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if (txtMaKH.Text == "" )
                {
                    MessageBox.Show("Bạn chưa nhập mã khách hàng");
                }
                else
                {
                    TblKhachHang pro = context.TblKhachHangs.SingleOrDefault(item => item.MaKh.Equals(txtMaKH.Text));
                    context.TblKhachHangs.Remove(pro);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        loadData();
                    }
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

        private void Customer_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var data = context.TblKhachHangs.Select(item => new
                {
                    MaKH = item.MaKh,
                    TenKH = item.TenKh,                  
                    Birth = item.NgaySinh,
                    Diachi = item.Diachi,
                    Gender = item.Gt
                }).ToList();
                dataGridView1.DataSource = data;

            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            dtpBirth.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            txtDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            rbtMale.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue;
            if (rbtMale.Checked == true)
            {
                rbtFemale.Checked = false;
            }
            else
            {
                rbtFemale.Checked = true;
            }
        }
    }
}
