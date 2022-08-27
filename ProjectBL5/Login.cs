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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                TblUser user = context.TblUsers.SingleOrDefault(item => item.Username.Equals(txtUser.Text));
                if(user != null)
                {
                    if (user.Pass.Equals(Convert.ToInt32(txtPass.Text)))
                    {
                        MessageBox.Show("Đăng nhập thành công, chào mừng đến với chương trình");
                        Main m = new Main();
                        m.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã nhập sai mật khẩu, xin vui lòng kiểm tra lại");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập sai tài khoản, xin vui lòng kiểm tra lại");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("May co muon thoat?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
