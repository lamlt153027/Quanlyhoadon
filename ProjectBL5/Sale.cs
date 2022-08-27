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
    public partial class Sale : Form
    {
        int count = 0;
        float tong = 0;
        float tongMax = 0;
        private List<int> Chon = new List<int>();
        private List<int> TongChon = new List<int>();
            
        public Sale()
        {
            InitializeComponent();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var data = context.TblMatHangs.ToList();
                cbxMatHang.DataSource = data;
                cbxMatHang.DisplayMember = "TenHang";
                cbxMatHang.ValueMember = "MaHang";
                txtGia.Text = "" + context.TblMatHangs.SingleOrDefault(item => item.MaHang.Equals(cbxMatHang.SelectedValue.ToString())).Gia;

            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtDiachi.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtMaHD.Text = "";
        }

        private void btnDatMua_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if(txtMaKH.Text.Equals("") || txtTenKH.Text.Equals("") || txtDiachi.Text.Equals(""))
                {
                    MessageBox.Show("Bạn phải nhập đủ thông tin");
                }
                else
                {
                    if(checkMaKhExist(txtMaKH) == 0)
                    {
                        MessageBox.Show("Mã khách hàng không tồn tài, xin vui lòng đăng ký");
                        List<TblKhachHang> kh = context.TblKhachHangs.ToList();
                        DangKyKH dk = new DangKyKH(txtMaKH.Text,txtTenKH.Text,txtDiachi.Text);
                        dk.Show();
                        kh = context.TblKhachHangs.ToList();
                        
                    }
                    else
                    {
                        TblHoadon hd = new TblHoadon
                        {
                            MaHd = Convert.ToInt32(txtMaHD.Text),
                            MaKh = txtMaKH.Text,
                            NgayHd = dtpNgayDatHang.Value
                        };
                        context.TblHoadons.Add(hd);
                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Đặt mua thành công");
                        }
                        button1.Enabled = true;
                        button2.Enabled = true;
                    }                   
                    
                }
                
            }
        }

        private int checkMaKhExist(TextBox txtMaKH)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                int check = 0;
                List<TblKhachHang> list = context.TblKhachHangs.ToList();
                foreach(TblKhachHang item in list)
                {
                    if (item.MaKh.Equals(txtMaKH.Text))
                    {
                        check = 1;
                    }
                }
                return check;
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                TblKhachHang kh = context.TblKhachHangs.SingleOrDefault(item => item.MaKh.Equals(txtMaKH.Text));
                if (kh != null)
                {
                    txtDiachi.Text = kh.Diachi;
                    txtTenKH.Text = kh.TenKh;
                }
            }
        }
        
        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            if(count == 0)
            {
                DataGridViewButtonColumn clm = new DataGridViewButtonColumn();
                clm.Name = "Choose";
                clm.HeaderText = "Chọn";
                clm.Text = "Chọn";
                clm.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(clm);
                count++;
            }
            using (MyOrderContext context = new MyOrderContext())
            {
                
                if (txtMaHD.Text != "")
                {
                    List<TblHoadon> list = context.TblHoadons.Where(item => item.MaHd == Convert.ToInt32(txtMaHD.Text)).ToList();
                    var data = (from a in context.TblChiTietHds
                               join b in context.TblHoadons
                               on a.MaHd equals b.MaHd
                               where b.MaHd == Convert.ToInt32(txtMaHD.Text)
                               select new
                               {
                                   MaChiTietHD = a.MaChiTietHd,
                                   MaHD = a.MaHd,
                                   MaHang = a.MaHang,
                                   Soluong = a.Soluong
                               }).ToList();
                    if (list.Count != 0)
                    {
                        dataGridView1.DataSource = data;
                        btnDatMua.Enabled = false;
                        button1.Enabled = true;
                        button2.Enabled = true;
                        lbTinhTien.Text = "Tinh tien: " + tongTienHoaDon(Convert.ToInt32(txtMaHD.Text));
                        tongMax = tongTienHoaDon(Convert.ToInt32(txtMaHD.Text));
                    }
                    else
                    {
                        btnDatMua.Enabled = true;
                        dataGridView1.DataSource = null;
                        button1.Enabled = false;
                        button2.Enabled = false;
                    }
                    loadData();
                }
                else
                {
                    dataGridView1.DataSource = null;
                    btnDatMua.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                }               
            }
        }

        private float tongTienHoaDon(int v)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var list = context.TblChiTietHds.Where(item => item.MaHd == v).ToList();
                dataGridView1.DataSource = list;
                float tien = 0;
                foreach(TblChiTietHd a in list)
                {
                    tien += context.TblMatHangs.SingleOrDefault(item => item.MaHang.Equals(a.MaHang)).Gia;
                }
                return tien;

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("May co muon thoat?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cbxMatHang_SelectedValueChanged(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if(context.TblMatHangs.SingleOrDefault(item => item.MaHang.Equals(cbxMatHang.SelectedValue.ToString())) != null)
                {
                    txtGia.Text = "" + context.TblMatHangs.SingleOrDefault(item => item.MaHang.Equals(cbxMatHang.SelectedValue.ToString())).Gia;
                }
                

            }
        }

        private int maxMaChiTietHD()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                List<TblChiTietHd> list = context.TblChiTietHds.ToList();
                int max = 0;
                foreach(TblChiTietHd item in list)
                {
                    if(item.MaChiTietHd > max)
                    {
                        max = Convert.ToInt32(item.MaChiTietHd);
                    }
                }
                return max;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if(txtSoluong.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số lượng");
                }
                else
                {
                    if (findChiTietHdExist(Convert.ToInt32(txtMaHD.Text), cbxMatHang.SelectedValue.ToString()) == 1)
                    {
                        TblChiTietHd a = context.TblChiTietHds.SingleOrDefault(item => item.MaHd == Convert.ToInt32(txtMaHD.Text) && item.MaHang.Equals(cbxMatHang.SelectedValue.ToString()));
                        a.Soluong = a.Soluong + Convert.ToInt32(txtSoluong.Text);
                        context.SaveChanges();
                        var data = context.TblChiTietHds.Where(item => item.MaHd == Convert.ToInt32(txtMaHD.Text))
                                .Select(item => new {
                                    MaChiTietHD = item.MaChiTietHd,
                                    MaHD = item.MaHd,
                                    MaHang = item.MaHang,
                                    Soluong = item.Soluong
                                }).ToList();
                        dataGridView1.DataSource = data;
                    }
                    else
                    {
                        TblChiTietHd ct = new TblChiTietHd
                        {
                            MaChiTietHd = maxMaChiTietHD() + 1,
                            MaHd = Convert.ToInt32(txtMaHD.Text),
                            MaHang = cbxMatHang.SelectedValue.ToString(),
                            Soluong = Convert.ToInt32(txtSoluong.Text)
                        };
                        context.TblChiTietHds.Add(ct);
                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Thêm vào chi tiết hóa đơn thành công");
                        }
                        var data = context.TblChiTietHds.Where(item => item.MaHd == Convert.ToInt32(txtMaHD.Text))
                                .Select(item => new {
                                    MaChiTietHD = item.MaChiTietHd,
                                    MaHD = item.MaHd,
                                    MaHang = item.MaHang,
                                    Soluong = item.Soluong
                                }).ToList();
                        dataGridView1.DataSource = data;
                    }
                    
                }
                
            }
        }

        private int findChiTietHdExist(int v1, string v2)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                int check = 0;
                List<TblChiTietHd> list = context.TblChiTietHds.ToList();
                foreach (TblChiTietHd item in list)
                {
                    if (item.MaHang.Equals(v2) && item.MaHd == v1)
                    {
                        check = 1;
                    }
                }
                return check;
            }
        }

        int MaChiTietHD = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                if(MaChiTietHD >= 0 && checkMaChiTietHdExist(MaChiTietHD) == 1)
                {
                    
                    TblChiTietHd hd = context.TblChiTietHds.SingleOrDefault(item => item.MaChiTietHd == MaChiTietHD);
                    context.TblChiTietHds.Remove(hd);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Xóa chi tiết hóa đơn thành công");
                        var data = context.TblChiTietHds.Where(item => item.MaHd == Convert.ToInt32(txtMaHD.Text))
                        .Select(item => new {
                            MaChiTietHD = item.MaChiTietHd,
                            MaHD = item.MaHd,
                            MaHang = item.MaHang,
                            Soluong = item.Soluong
                        }).ToList();
                        dataGridView1.DataSource = data;
                    }
                }
                
            }
        }

        private int checkMaChiTietHdExist(int maChiTietHD)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                int check = 0;
                List<TblChiTietHd> list = context.TblChiTietHds.ToList();
                foreach (TblChiTietHd item in list)
                {
                    if (item.MaChiTietHd == maChiTietHD)
                    {
                        check = 1;
                    }
                }
                return check;
            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MaChiTietHD = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
            using (MyOrderContext context = new MyOrderContext())
            {
                int SoLuong = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                string MaHang = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Choose")
                {
                    if (checkChon(MaChiTietHD) == 1)
                    {
                        Chon.Add(MaChiTietHD);
                        tong += context.TblMatHangs.SingleOrDefault(item => item.MaHang.Equals(MaHang)).Gia * SoLuong;
                        lbThanhPhan.Text = "Tổng tiền bạn muốn thanh toán: " + tong;
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã chọn rồi");
                    }
                    
                }
            }
        }

        private int checkChon(int maChiTietHD)
        {
            int check = 1;
            foreach(int item in Chon)
            {
                if(item == maChiTietHD)
                {
                    check = 0;
                }
            }
            return check;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                foreach (int a in Chon)
                {
                    TblChiTietHd tb = context.TblChiTietHds.SingleOrDefault(item => item.MaChiTietHd == a);
                    context.TblChiTietHds.Remove(tb);
                    context.SaveChanges();
                }
                MessageBox.Show("Thanh toan thanh cong");
                var data = context.TblChiTietHds.Where(item => item.MaHd == Convert.ToInt32(txtMaHD.Text))
                                .Select(item => new {
                                    MaChiTietHD = item.MaChiTietHd,
                                    MaHD = item.MaHd,
                                    MaHang = item.MaHang,
                                    Soluong = item.Soluong
                                }).ToList();
                dataGridView1.DataSource = data;
            }
        }

        private void btnThanhToanAll_Click(object sender, EventArgs e)
        {
            
            using (MyOrderContext context = new MyOrderContext())
            {
                List<TblChiTietHd> hh = context.TblChiTietHds.Where(item => item.MaHd == Convert.ToInt32(txtMaHD.Text)).ToList();
                foreach(TblChiTietHd item in hh)
                {
                    TongChon.Add(Convert.ToInt32(item.MaChiTietHd));
                }
                foreach (int a in TongChon)
                {
                    TblChiTietHd tb = context.TblChiTietHds.SingleOrDefault(item => item.MaChiTietHd == a);
                    context.TblChiTietHds.Remove(tb);
                    context.SaveChanges();
                }
                MessageBox.Show("Thanh toan thanh cong");
                var data = context.TblChiTietHds.Where(item => item.MaHd == Convert.ToInt32(txtMaHD.Text))
                                .Select(item => new {
                                    MaChiTietHD = item.MaChiTietHd,
                                    MaHD = item.MaHd,
                                    MaHang = item.MaHang,
                                    Soluong = item.Soluong
                                }).ToList();
                dataGridView1.DataSource = data;
            } 
        }
    }
}
