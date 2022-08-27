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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var data = context.TblMatHangs.ToList();
                cbxMaHang.DataSource = data;
                cbxMaHang.DisplayMember = "MaHang";
                cbxMaHang.ValueMember = "TenHang";
                txtTen.Text = "" + context.TblMatHangs.SingleOrDefault(item => item.TenHang.Equals(cbxMaHang.SelectedValue.ToString())).TenHang;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var data = (from a in context.TblChiTietHds
                           join p in context.TblHoadons on a.MaHd equals p.MaHd
                           join b in context.TblMatHangs on a.MaHang equals b.MaHang
                           where p.NgayHd > dtpDateFrom.Value && p.NgayHd < dtpDateTo.Value && b.TenHang.Equals(cbxMaHang.SelectedValue.ToString())
                           select new
                           {
                               MaHD = a.MaHd,
                               MaHang = a.MaHang,
                               TenHang = b.TenHang,
                               NgayHD = p.NgayHd,                
                               SoLuong = a.Soluong,
                               Gia = b.Gia
                           }).ToList();
                dataGridView1.DataSource = data;             
            }
        }

        private void cbxMaHang_SelectedValueChanged(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if(context.TblMatHangs.SingleOrDefault(item => item.TenHang.Equals(cbxMaHang.SelectedValue.ToString())) != null)
                {
                    txtTen.Text = "" + context.TblMatHangs.SingleOrDefault(item => item.TenHang.Equals(cbxMaHang.SelectedValue.ToString())).TenHang;
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

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {

        }
    }
}
