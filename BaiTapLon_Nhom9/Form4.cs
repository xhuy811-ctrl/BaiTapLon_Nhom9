using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_Nhom9
{
    public partial class Themhoadon : Form
    {
        public string maHoaDon;
        public string MaSV;
        public string HoTen;
        public string Phong;
        public string Toa;
        public string ThanhTien;
        public string TrangThai;
        public DateTime Ngay;
        public DateTime NgayLap;
        public string NguoiLap;

        public Themhoadon()
        {
            InitializeComponent();
        }

        private void btnThemHoadon_Click(object sender, EventArgs e)
        {
            maHoaDon = txtmaHoadon.Text;
            MaSV = txtMaSV.Text;
            HoTen = txthoTen.Text;
            Phong = cBPhong.Text;
            Toa = cbToa.Text;
            Ngay = atpNgay.Value;
            ThanhTien = txtThanhTien.Text;
            TrangThai = cBTrangThai.Text;
            NgayLap = dtpNgayLap.Value;
            NguoiLap = txtNguoiLap.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
