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
            if (dgvDanhSachPhong.Rows.Count == 1)
            {
                MessageBox.Show("Chưa có dữ liệu trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Dừng hàm tại đây, không chạy các lệnh bên dưới nữa
            }
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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhong.Rows.Count == 1)
            {
                MessageBox.Show("Chưa có dữ liệu trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Dừng hàm tại đây, không chạy các lệnh bên dưới nữa
            }
            // 1. Kiểm tra xem người dùng đã chọn dòng nào chưa
            if (dgvDanhSachPhong.CurrentRow != null)
            {
                // 2. Hiện hộp thoại hỏi lại cho chắc chắn (Tránh bấm nhầm)
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không?",
                                                    "Xác nhận xóa",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // 3. Lấy chỉ số (index) của dòng đang chọn
                    int index = dgvDanhSachPhong.CurrentRow.Index;

                    // 4. Thực hiện lệnh xóa dòng tại vị trí index đó
                    dgvDanhSachPhong.Rows.RemoveAt(index);

                    MessageBox.Show("Đã xóa phòng thành công!", "Thông báo");

                    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng để xóa!", "Thông báo");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
            string maTimKiem = cboMaPhong.Text.Trim(); // Lấy mã từ ô nhập liệu

            if (string.IsNullOrEmpty(maTimKiem))
            {
                MessageBox.Show("Vui lòng nhập Mã phòng cần tìm!", "Thông báo");
                return;
            }

            bool found = false; // Biến kiểm tra xem có tìm thấy không

            // Duyệt qua tất cả các dòng trong bảng
            foreach (DataGridViewRow row in dgvDanhSachPhong.Rows)
            {
                // Kiểm tra nếu ô Mã phòng của dòng đó khớp với mã tìm kiếm
                // Lưu ý: Thay "txtMaPhong" bằng đúng tên Column Name của bạn
                if (row.Cells["txtMaPhong"].Value != null &&
                    row.Cells["txtMaPhong"].Value.ToString() == maTimKiem)
                {
                    // 1. Chọn dòng đó (Bôi xanh)
                    row.Selected = true;

                    // 2. Cuộn màn hình tới dòng đó (nếu bảng quá dài)
                    dgvDanhSachPhong.FirstDisplayedScrollingRowIndex = row.Index;

                    

                    found = true;
                    break; // Tìm thấy rồi thì dừng vòng lặp
                }
            }

            if (!found)
            {
                MessageBox.Show("Không tìm thấy phòng có mã: " + maTimKiem, "Kết quả");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
