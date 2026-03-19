using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_Nhom9
{
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void btInhd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã in hợp đồng" , "Thông báo" , 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btThemhd_Click(object sender, EventArgs e)
        {
            frmThemHopDong f = new frmThemHopDong();
            f.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhong = cboMaPhong.Text;
            string loaiPhong = cboLoaiPhong.Text;
            string tang = cboTang.Text;
            string soChoTrong = cboSoChoTrong.Text;
            string donGia = cboDonGia.Text;
            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvDanhSachPhong.Rows.Add(maPhong, loaiPhong, tang, soChoTrong, donGia);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào đang được chọn không
            if (dgvDanhSachPhong.CurrentRow != null)
            {
                // 2. Lấy dòng hiện tại
                int index = dgvDanhSachPhong.CurrentRow.Index;

                // 3. Cập nhật giá trị mới từ các Controls vào dòng đó
                dgvDanhSachPhong.Rows[index].Cells["txtLoaiPhong"].Value = cboLoaiPhong.Text;
                dgvDanhSachPhong.Rows[index].Cells["txtTang"].Value = cboTang.Text;
                dgvDanhSachPhong.Rows[index].Cells["txtSoChoTrong"].Value = cboSoChoTrong.Text;
                dgvDanhSachPhong.Rows[index].Cells["txtDonGia"].Value = cboDonGia.Text;
                dgvDanhSachPhong.Rows[index].Cells["txtMaPhong"].Value = cboMaPhong.Text;
              
                MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo");

                // 4. Reset giao diện (mở khóa mã phòng để thêm mới nếu cần)
                txtMaPhong.ReadOnly = false;
                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật!");
            }
        }
    }
}
