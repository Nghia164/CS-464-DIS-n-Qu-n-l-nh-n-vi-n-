using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace DoAn
{
    /// <summary>
    /// Interaction logic for WindowNhanVienChiTiet.xaml
    /// </summary>
    public partial class WindowNhanVienChiTiet : Window
    {
        QUANLYNHANVIENEntities db = new QUANLYNHANVIENEntities();

        public WindowNhanVienChiTiet()
        {
            InitializeComponent();
            LoadDuLieuCombobox();
        }

        private void LoadDuLieuCombobox()
        {
            try
            {
                cboPhongBan.ItemsSource = db.PhongBan.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu phòng ban: " + ex.Message);
            }
        }

        private bool KiemTraHopLe()
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và Tên nhân viên!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtTen.Focus();
                return false;
            }

            if (cboPhongBan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Phòng Ban!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                cboPhongBan.Focus();
                return false;
            }

            string sdt = txtSDT.Text.Trim();
            if (!string.IsNullOrEmpty(sdt))
            {
                if (sdt.Length < 9 || sdt.Length > 11 || !sdt.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ (phải là số và từ 9-11 ký tự)!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtSDT.Focus();
                    return false;
                }
            }

            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            return true; 
        }

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTraHopLe()) return;

            try
            {
                NhanVien nvMoi = new NhanVien()
                {
                    HoVaTen = txtTen.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    DuongDanAnh = txtAnh.Text.Trim(),
                    TrangThaiLamViec = cboTrangThai.Text,
                    NgaySinh = dpNgaySinh.SelectedDate,
                    NgayVaoLam = dpNgayVaoLam.SelectedDate,
                    MaPhongBan = (int)cboPhongBan.SelectedValue 
                };

                db.NhanVien.Add(nvMoi);
                db.SaveChanges();

                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ChuyenVeManHinhDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm mới: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên hợp lệ (số nguyên) để sửa!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!KiemTraHopLe()) return;

            try
            {
                var nvSua = db.NhanVien.FirstOrDefault(x => x.MaNhanVien == maNV);

                if (nvSua == null)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại trong hệ thống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                nvSua.HoVaTen = txtTen.Text.Trim();
                nvSua.Email = txtEmail.Text.Trim();
                nvSua.SoDienThoai = txtSDT.Text.Trim();
                nvSua.DiaChi = txtDiaChi.Text.Trim();
                nvSua.DuongDanAnh = txtAnh.Text.Trim();
                nvSua.TrangThaiLamViec = cboTrangThai.Text;
                nvSua.NgaySinh = dpNgaySinh.SelectedDate;
                nvSua.NgayVaoLam = dpNgayVaoLam.SelectedDate;
                nvSua.MaPhongBan = (int)cboPhongBan.SelectedValue;

                db.SaveChanges();

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ChuyenVeManHinhDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên hợp lệ để xóa!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa nhân viên có mã {maNV}?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }

            try
            {
                var nvXoa = db.NhanVien.FirstOrDefault(x => x.MaNhanVien == maNV);

                if (nvXoa != null)
                {
                    db.NhanVien.Remove(nvXoa);
                    db.SaveChanges();

                    MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ChuyenVeManHinhDanhSach();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Mã NV này để xóa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa (có thể do nhân viên này đang liên kết với dữ liệu tài khoản/lương): \n" + ex.Message, "Lỗi Ràng Buộc", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnChonAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (openDlg.ShowDialog() == true)
            {
                txtAnh.Text = openDlg.FileName;
            }
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            ChuyenVeManHinhDanhSach();
        }

        private void ChuyenVeManHinhDanhSach()
        {
            NhanVienWindow winNV = new NhanVienWindow();
            winNV.Show();
            this.Close();
        }
    }
}