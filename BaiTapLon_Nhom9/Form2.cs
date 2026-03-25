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

            // Gán sự kiện cho nút Sửa/Xóa ở tab Thông tin sinh viên
            btnSua.Click += btnSua_Click;
            buttonXoa.Click += buttonXoa_Click;

            // Chọn theo cả dòng để thao tác Sửa/Xóa dễ hơn
            dgvThongTinSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongTinSinhVien.MultiSelect = false;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (txtMSV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập Mã SV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMSV.Focus();
                return;
            }

            if (txtHoVaTen.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập Họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }

            if (!rbNam.Checked && !rbNu.Checked)
            {
                MessageBox.Show("Bạn chưa chọn Giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboQue.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn Quê quán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboQue.Focus();
                return;
            }

            if (cboKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return;
            }

            if (cboLop.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn Lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLop.Focus();
                return;
            }

            if (cboPhong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn Phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhong.Focus();
                return;
            }

            if (cboToa.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn Tòa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboToa.Focus();
                return;
            }

            string gioiTinh;
            if (rbNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "Nữ";
            }

            dgvThongTinSinhVien.Rows.Add(
                txtMSV.Text.Trim(),
                txtHoVaTen.Text.Trim(),
                dtpNgaySinh.Value.ToString("dd/MM/yyyy"),
                gioiTinh,
                cboQue.Text.Trim(),
                cboKhoa.Text.Trim(),
                cboLop.Text.Trim(),
                cboPhong.Text.Trim(),
                cboToa.Text.Trim());

            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThongTinSinhVien.Rows.Count == 0 ||
                (dgvThongTinSinhVien.Rows.Count == 1 && dgvThongTinSinhVien.Rows[0].IsNewRow))
            {
                MessageBox.Show("Bảng chưa có dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvThongTinSinhVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMSV.Text.Trim() == "" ||
                txtHoVaTen.Text.Trim() == "" ||
                cboQue.Text.Trim() == "" ||
                cboKhoa.Text.Trim() == "" ||
                cboLop.Text.Trim() == "" ||
                cboPhong.Text.Trim() == "" ||
                cboToa.Text.Trim() == "" ||
                (!rbNam.Checked && !rbNu.Checked))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvThongTinSinhVien.SelectedRows[0];
            if (row.IsNewRow)
            {
                MessageBox.Show("Dòng đang chọn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gioiTinhMoi;
            if (rbNam.Checked)
            {
                gioiTinhMoi = "Nam";
            }
            else
            {
                gioiTinhMoi = "Nữ";
            }

            string ngaySinhMoi = dtpNgaySinh.Value.ToString("dd/MM/yyyy");

            bool khongCoThayDoi =
                Convert.ToString(row.Cells[0].Value).Trim() == txtMSV.Text.Trim() &&
                Convert.ToString(row.Cells[1].Value).Trim() == txtHoVaTen.Text.Trim() &&
                Convert.ToString(row.Cells[2].Value).Trim() == ngaySinhMoi &&
                Convert.ToString(row.Cells[3].Value).Trim() == gioiTinhMoi &&
                Convert.ToString(row.Cells[4].Value).Trim() == cboQue.Text.Trim() &&
                Convert.ToString(row.Cells[5].Value).Trim() == cboKhoa.Text.Trim() &&
                Convert.ToString(row.Cells[6].Value).Trim() == cboLop.Text.Trim() &&
                Convert.ToString(row.Cells[7].Value).Trim() == cboPhong.Text.Trim() &&
                Convert.ToString(row.Cells[8].Value).Trim() == cboToa.Text.Trim();

            if (khongCoThayDoi)
            {
                MessageBox.Show("Không có thông tin mới để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            row.Cells[0].Value = txtMSV.Text.Trim();
            row.Cells[1].Value = txtHoVaTen.Text.Trim();
            row.Cells[2].Value = ngaySinhMoi;
            row.Cells[3].Value = gioiTinhMoi;
            row.Cells[4].Value = cboQue.Text.Trim();
            row.Cells[5].Value = cboKhoa.Text.Trim();
            row.Cells[6].Value = cboLop.Text.Trim();
            row.Cells[7].Value = cboPhong.Text.Trim();
            row.Cells[8].Value = cboToa.Text.Trim();

            MessageBox.Show("Sửa thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongTinSinhVien.Rows.Count == 0 ||
                (dgvThongTinSinhVien.Rows.Count == 1 && dgvThongTinSinhVien.Rows[0].IsNewRow))
            {
                MessageBox.Show("Bảng chưa có dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvThongTinSinhVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvThongTinSinhVien.SelectedRows[0];
            if (row.IsNewRow)
            {
                MessageBox.Show("Dòng đang chọn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dgvThongTinSinhVien.Rows.RemoveAt(row.Index);
                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            if (dgvDanhSachPhong.CurrentRow != null && !dgvDanhSachPhong.CurrentRow.IsNewRow)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int index = dgvDanhSachPhong.CurrentRow.Index;
                    dgvDanhSachPhong.Rows.RemoveAt(index);

                    MessageBox.Show("Đã xóa phòng thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng hợp lệ để xóa!", "Thông báo");
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

        private void btnThem1_Click(object sender, EventArgs e)
        {
            Themhoadon f = new Themhoadon();
            if(f.ShowDialog() == DialogResult.OK)
            {
                dgvHoaDon.Rows.Add(f.maHoaDon,f.MaSV,f.HoTen,f.Phong,f.Toa,f.Ngay.ToString("dd/MM/yyyy"),f.ThanhTien,f.TrangThai,f.NgayLap.ToString("dd/MM/yyyy"),f.NguoiLap);
            }
            
    }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0) // kiểm tra có dòng được chọn
            {
                DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa dòng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                foreach (DataGridViewRow row in dgvHoaDon.SelectedRows)
                {
                    if (!row.IsNewRow) // không xóa dòng mới (dòng thêm)
                        dgvHoaDon.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
