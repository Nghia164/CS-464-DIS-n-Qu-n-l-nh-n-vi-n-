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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QUANLYNHANVIENEntities db = new QUANLYNHANVIENEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string taiKhoan = txtUser.Text.Trim();
            string matKhau = txtPass.Password.Trim();

            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (KiemTraDangNhap(taiKhoan, matKhau))
            {
                GiaoDien manHinhChinh = new GiaoDien();
                manHinhChinh.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPass.Clear();
                txtPass.Focus();
            }
        }

        private bool KiemTraDangNhap(string user, string pass)
        {
            try
            {
                bool hopLe = db.TaiKhoan.Any(t => t.TenTK == user && t.MK == pass);
                return hopLe;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }

        private void TextBlock_ForgotPass_Click(object sender, MouseButtonEventArgs e)
        {
            QuenMKWindown quenMk = new QuenMKWindown();
            quenMk.ShowDialog();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
