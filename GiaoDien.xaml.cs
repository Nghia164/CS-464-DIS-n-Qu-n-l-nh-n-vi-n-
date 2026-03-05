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
    /// Interaction logic for GiaoDien.xaml
    /// </summary>
    public partial class GiaoDien : Window
    {
        QUANLYNHANVIENEntities db = new QUANLYNHANVIENEntities();

        public GiaoDien()
        {
            InitializeComponent();
            LoadDataFromDB();
        }

        private void ThongKeSoLuong()
        {
            try
            {
                txtTongNV.Text = db.NhanVien.Count().ToString();
                txtNVMoi.Text = db.NhanVien.Count(nv => nv.NgayVaoLam.HasValue && nv.NgayVaoLam.Value.Year == 2026).ToString();
                txtNghiPhep.Text = db.NhanVien.Count(nv => nv.TrangThaiLamViec == "Nghỉ phép").ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thống kê: " + ex.Message);
            }
        }

        private void LoadDataFromDB(string keyword = "")
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
                                TenPhongBan = pb != null ? pb.TenPhongBan : "Chưa phân bổ",
                                Email = nv.Email,
                                SoDienThoai = nv.SoDienThoai,
                                NgayVaoLam = nv.NgayVaoLam,
                                TrangThaiLamViec = nv.TrangThaiLamViec
                            };

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(nv => nv.HoVaTen.ToLower().Contains(keyword.ToLower()));
                }

                dgDanhSachNV.ItemsSource = query.ToList();

                ThongKeSoLuong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi kết nối", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            WindowNhanVienChiTiet winChiTiet = new WindowNhanVienChiTiet();
            winChiTiet.ShowDialog();
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string keyword = txtSearch.Text.Trim();

                LoadDataFromDB(keyword);

                if (dgDanhSachNV.Items.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy nhân viên nào phù hợp với từ khóa: '{keyword}'",
                                    "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtSearch.Text = "";
                    LoadDataFromDB(); 
                }
            }
        }
    }
}
