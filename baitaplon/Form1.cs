using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maPhong = cboMaPhong.Text;
            string loaiPhong = cboLoaiPhong.Text;
            string tang = cboTang.Text;
            string tinhTrang = cboTinhTrang.Text;
            string donGia = cboDonGia.Text;
            string soChoTrong = cboSoChoTrong.Text;
            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui long nhap ma phong!");
                return;
            }
            dgvDanhSachPhong.Rows.Add(maPhong, loaiPhong, tang, soChoTrong,tinhTrang, donGia);
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string maPhong = cboMaPhong.Text;
            string loaiPhong = cboLoaiPhong.Text;
            string tang = cboTang.Text;
            string tinhTrang = cboTinhTrang.Text;
            string donGia = cboDonGia.Text;
            string soChoTrong = cboSoChoTrong.Text;
            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui long nhap ma phong!");
                return;
            }
            dgvDanhSachPhong.Rows.Add(maPhong, loaiPhong, tang, soChoTrong, tinhTrang, donGia);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes) {
                dgvDanhSachPhong.Rows.RemoveAt(dgvDanhSachPhong.CurrentRow.Index);
                MessageBox.Show("Bạn đã xóa thành công!!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
