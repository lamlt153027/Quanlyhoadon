using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectBL5.Models;

namespace ProjectBL5
{
    public partial class DangKyKH : Form
    {
        private string message;
        public DangKyKH()
        {
        }

        public DangKyKH(string MaKH, string TenKH, string DiaChi): this()
        {
            InitializeComponent();
            message = MaKH;
            txtMaKh.Text = message;
            message = TenKH;
            txtTenKH.Text = message;
            message = DiaChi;
            txtDiaChi.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(MyOrderContext context = new MyOrderContext())
            {
                if(txtTenKH.Text.Equals("") || txtMaKh.Text.Equals("") || txtDiaChi.Text.Equals("") || (rbtMale.Checked == false && rbtFemale.Checked == false))
                {
                    MessageBox.Show("Bạn phải nhập đủ thông tin");
                }
                TblKhachHang kh = new TblKhachHang
                {
                    MaKh = txtMaKh.Text,
                    TenKh = txtTenKH.Text,
                    Diachi = txtDiaChi.Text,
                    NgaySinh = dtpBirth.Value,
                    Gt = rbtMale.Checked
                };
                context.TblKhachHangs.Add(kh);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Đăng ký thành công");
                }
                this.Close();
            }
        }
    }
}
