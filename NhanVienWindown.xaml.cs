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
        /// Interaction logic for NhanVienWindow.xaml
        /// </summary>
        public partial class NhanVienWindow : Window
        {
            QUANLYNHANVIENEntities db = new QUANLYNHANVIENEntities();

            public NhanVienWindow()
            {
                InitializeComponent();
                LoadDuLieu();
            }

            private void LoadDuLieu()
            {
                try
                {
                    var query = from nv in db.NhanVien
                                join pb in db.PhongBan on nv.MaPhongBan equals pb.MaPhongBan into phongBanGroup
                                from pb in phongBanGroup.DefaultIfEmpty()
                                select new
                                {
                                    MaNhanVien = nv.MaNhanVien,
                                    HoVaTen = nv.HoVaTen,
                                    TenPhongBan = pb != null ? pb.TenPhongBan : "Chưa có",
                                    Email = nv.Email,
                                    SoDienThoai = nv.SoDienThoai,
                                    NgayVaoLam = nv.NgayVaoLam,
                                    TrangThaiLamViec = nv.TrangThaiLamViec
                                };

                    dgNhanVien.ItemsSource = query.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }

            private void btnThem_Click(object sender, RoutedEventArgs e)
            {
                WindowNhanVienChiTiet winChiTiet = new WindowNhanVienChiTiet();
                winChiTiet.ShowDialog();
        }

            private void btnSua_Click(object sender, RoutedEventArgs e)
            {
                WindowNhanVienChiTiet winChiTiet = new WindowNhanVienChiTiet();
                winChiTiet.ShowDialog();
        }

            private void btnXoa_Click(object sender, RoutedEventArgs e)
            {
                WindowNhanVienChiTiet winChiTiet = new WindowNhanVienChiTiet();
                winChiTiet.ShowDialog();
        }

            private void btnAdmin_Click(object sender, RoutedEventArgs e)
            {
                WindowThemAdmin winThemA = new WindowThemAdmin();
                winThemA.ShowDialog();
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
