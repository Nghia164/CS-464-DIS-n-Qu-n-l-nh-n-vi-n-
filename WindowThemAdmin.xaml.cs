using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoAn
{
    /// <summary>
    /// Interaction logic for WindowThemAdmin.xaml
    /// </summary>
    public partial class WindowThemAdmin : Window
    {
        QUANLYNHANVIENEntities db = new QUANLYNHANVIENEntities();

        public WindowThemAdmin()
        {
            InitializeComponent();
            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            try
            {
                var listNV = db.NhanVien.Select(nv => new
                {
                    MaNhanVien = nv.MaNhanVien,
                    HoVaTen = nv.HoVaTen
                }).ToList();

                cboNhanVien.ItemsSource = listNV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void BtnTao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUser.Text.Trim();
                string password = txtPass.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || cboNhanVien.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ Tên tài khoản, Mật khẩu và Chọn nhân viên!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int maNV = (int)cboNhanVien.SelectedValue;
                bool isExist = db.TaiKhoan.Any(t => t.TenTK == username);
                if (isExist)
                {
                    MessageBox.Show("Tên tài khoản này đã tồn tại. Vui lòng chọn tên đăng nhập khác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                TaiKhoan taiKhoanMoi = new TaiKhoan()
                {
                    TenTK = username,
                    MK = password,
                    Quyen = "Admin",
                    MaNhanVien = maNV
                };

                db.TaiKhoan.Add(taiKhoanMoi);
                db.SaveChanges();

                MessageBox.Show("Thêm Admin thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                ChuyenVeManHinhNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            ChuyenVeManHinhNhanVien();
        }
        private void ChuyenVeManHinhNhanVien()
        {
           NhanVienWindow winNhanVien = new NhanVienWindow();
            winNhanVien.Show();
            this.Close(); 
        }

        private void cboNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}