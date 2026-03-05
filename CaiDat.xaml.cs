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
    /// Interaction logic for CaiDat.xaml
    /// </summary>
    public partial class CaiDat : Window
    {
        public CaiDat()
        {
            InitializeComponent();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            txtSqlServer.Text = @"Server=(localdb)\MSSQLLocalDB;Database=QUANLYNHANVIEN;Integrated Security=True;";
            txtMySql.Text = "Server=localhost;Database=PayrollDB;Uid=root;Pwd=1234;";

            chkAutoSync.IsChecked = true;
            chkAnniversary.IsChecked = true;
            chkExportExcel.IsChecked = false;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSqlServer.Text) || string.IsNullOrWhiteSpace(txtMySql.Text))
            {
                MessageBox.Show("Vui lòng không để trống thông tin kết nối Database!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string settingsInfo = $"Đã lưu cấu hình:\n\n" +
                                  $"- SQL HR: {txtSqlServer.Text}\n" +
                                  $"- MySQL Payroll: {txtMySql.Text}\n" +
                                  $"- Auto Sync: {chkAutoSync.IsChecked}\n" +
                                  $"- Cảnh báo kỷ niệm: {chkAnniversary.IsChecked}\n" +
                                  $"- Xuất Excel: {chkExportExcel.IsChecked}";

            MessageBox.Show(settingsInfo, "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnTongQuan_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien winTongQuan = new GiaoDien();
            winTongQuan.Show();
            this.Close();
        }

        private void btnNhanVien_Click(object sender, RoutedEventArgs e)
        {
            NhanVienWindow winNhanVien = new NhanVienWindow();
            winNhanVien.Show();
            this.Close();
        }

        private void btnTuyenDung_Click(object sender, RoutedEventArgs e)
        {
            TuyenDung winTuyenDung = new TuyenDung();
            winTuyenDung.Show();
            this.Close();
        }

        private void btnHieuSuat_Click(object sender, RoutedEventArgs e)
        {
            Window1 winHieuSuat = new Window1();
            winHieuSuat.Show();
            this.Close();
        }

        private void btnLuongThuong_Click(object sender, RoutedEventArgs e)
        {
            Window5 winLuong = new Window5();
            winLuong.Show();
            this.Close();
        }

        private void btnCaiDat_Click(object sender, RoutedEventArgs e)
        {
            CaiDat winCaiDat = new CaiDat();
            winCaiDat.Show();
            this.Close();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
