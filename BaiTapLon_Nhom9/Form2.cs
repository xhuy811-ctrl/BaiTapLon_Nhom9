using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_Nhom9
{
    public partial class frmQuanLy : Form
    {
        //tạo biến cục bộ 
        SqlConnection conn = new SqlConnection(
    @"Data Source=DESKTOP-AVCDQS6\SQLEXPRESS;Initial Catalog=QUANLYHOPDONGKTX;Integrated Security=True");
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void btInhd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã in hợp đồng", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM hdktx", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btThemhd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = @"INSERT INTO hdktx 
        (MaHD, MaSV, TenSV, NgaySinh, GioiTinh, SoPhong, NgayLap, NgayHan)
        VALUES (@MaHD, @MaSV, @TenSV, @NgaySinh, @GioiTinh, @SoPhong, @NgayLap, @NgayHan)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                cmd.Parameters.AddWithValue("@TenSV", txtTenSV.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@SoPhong", txtSoPhong.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                cmd.Parameters.AddWithValue("@NgayHan", dtpNgayHan.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
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

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qUANLYHOPDONGKTXDataSet6.hdktx' table. You can move, or remove it, as needed.
            this.hdktxTableAdapter2.Fill(this.qUANLYHOPDONGKTXDataSet6.hdktx);
            // TODO: This line of code loads data into the 'qUANLYHOPDONGKTXDataSet5.hdktx' table. You can move, or remove it, as needed.
            this.hdktxTableAdapter1.Fill(this.qUANLYHOPDONGKTXDataSet5.hdktx);
            // TODO: This line of code loads data into the 'qUANLYHOPDONGKTXDataSet4.hdktx' table. You can move, or remove it, as needed.
            this.hdktxTableAdapter.Fill(this.qUANLYHOPDONGKTXDataSet4.hdktx);
            //TODO: This line of code loads data into the 'qUANLYHOPDONGKTXDataSet3.HopDongktx' table.You can move, or remove it, as needed.
            //this.hopDongktxTableAdapter3.Fill(this.qUANLYHOPDONGKTXDataSet3.HopDongktx);
            //// TODO: This line of code loads data into the 'qUANLYHOPDONGKTXDataSet2.HopDongktx' table. You can move, or remove it, as needed.
            //this.hopDongktxTableAdapter2.Fill(this.qUANLYHOPDONGKTXDataSet2.HopDongktx);
            //// TODO: This line of code loads data into the 'qUANLYHOPDONGKTXDataSet1.HopDongktx' table. You can move, or remove it, as needed.
            //this.hopDongktxTableAdapter1.Fill(this.qUANLYHOPDONGKTXDataSet1.HopDongktx);
            //// TODO: This line of code loads data into the 'qUANLYHOPDONGKTXDataSet.HopDongktx' table. You can move, or remove it, as needed.
            //this.hopDongktxTableAdapter.Fill(this.qUANLYHOPDONGKTXDataSet.HopDongktx);

        }

        private void tpHopDong_Click(object sender, EventArgs e)
        {

        }

        private void btSuahd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = @"UPDATE hdktx SET 
            MaSV=@MaSV,
            TenSV=@TenSV,
            NgaySinh=@NgaySinh,
            GioiTinh=@GioiTinh,
            SoPhong=@SoPhong,
            NgayLap=@NgayLap,
            NgayHan=@NgayHan
        WHERE MaHD=@MaHD";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                cmd.Parameters.AddWithValue("@TenSV", txtTenSV.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@SoPhong", txtSoPhong.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                cmd.Parameters.AddWithValue("@NgayHan", dtpNgayHan.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btXoahd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = "DELETE FROM hdktx WHERE MaHD=@MaHD";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
