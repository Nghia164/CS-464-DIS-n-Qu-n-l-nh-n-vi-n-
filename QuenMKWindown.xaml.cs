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

namespace DoAn
{
    /// <summary>
    /// Interaction logic for QuenMKWindown.xaml
    /// </summary>
    public partial class QuenMKWindown : Window
    {
        QUANLYNHANVIENEntities db = new QUANLYNHANVIENEntities();
        public QuenMKWindown()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text.Trim();
            string maNV = txtM.Text.Trim();
            string newPass = txtNewPass.Password.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Tài khoản, Mã NV và Mật khẩu mới!");
                return;
            }

            if (CapNhatMatKhau(user, maNV, newPass))
            {
                MessageBox.Show("Đổi mật khẩu thành công! Hãy đăng nhập lại.", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc Mã nhân viên không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CapNhatMatKhau(string user, string maNV, string newPass)
        {
            try
            {
                if (!int.TryParse(maNV, out int maNhanVienInt))
                {
                    MessageBox.Show("Mã nhân viên phải là số nguyên!");
                    return false;
                }

                var taiKhoan = db.TaiKhoan.FirstOrDefault(t => t.TenTK == user && t.MaNhanVien == maNhanVienInt);

                if (taiKhoan != null)
                {
                    taiKhoan.MK = newPass;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                return false;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
