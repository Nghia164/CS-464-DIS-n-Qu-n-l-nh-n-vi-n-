using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Window5 : Window
    {
        QUANLYNHANVIENEntities db = new QUANLYNHANVIENEntities();

        public Window5()
        {
            InitializeComponent();
            LoadDuLieuLuong();
        }

        private void LoadDuLieuLuong()
        {
            try
            {
                var rawData = (from bl in db.BangLuong
                               join nv in db.NhanVien on bl.MaNhanVien equals nv.MaNhanVien
                               join pb in db.PhongBan on nv.MaPhongBan equals pb.MaPhongBan into pbGroup
                               from pb in pbGroup.DefaultIfEmpty()
                               select new
                               {
                                   bl.MaNhanVien,
                                   nv.HoVaTen,
                                   TenPhongBan = pb != null ? pb.TenPhongBan : "Chưa phân bổ",
                                   bl.Thang,
                                   bl.Nam,
                                   bl.SoNgayCong,
                                   bl.PhuCap,
                                   bl.Thuong,
                                   bl.KhauTru,
                                   bl.ThucLinh,
                                   bl.TrangThaiThanhToan
                               }).ToList();

                var dataHienThi = rawData.Select(x => new
                {
                    x.MaNhanVien,
                    x.HoVaTen,
                    x.TenPhongBan,
                    KyLuong = $"{x.Thang:D2}/{x.Nam}",
                    x.SoNgayCong,
                    x.PhuCap,
                    x.Thuong,
                    x.KhauTru,
                    x.ThucLinh,
                    x.TrangThaiThanhToan
                }).ToList();

                dgDanhSachLuong.ItemsSource = dataHienThi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTinhLuong_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int m = DateTime.Now.Month;
                int y = DateTime.Now.Year;
                var list = db.BangLuong.Where(b => b.Thang == m && b.Nam == y).ToList();

                foreach (var item in list)
                {
                    double baseL = Convert.ToDouble(item.SoNgayCong) * 300000;
                    double pc = item.PhuCap.HasValue ? Convert.ToDouble(item.PhuCap) : 0;
                    double th = item.Thuong.HasValue ? Convert.ToDouble(item.Thuong) : 0;
                    double kt = item.KhauTru.HasValue ? Convert.ToDouble(item.KhauTru) : 0;
                    item.ThucLinh = (decimal)(baseL + pc + th - kt);
                }

                db.SaveChanges();
                LoadDuLieuLuong();
                MessageBox.Show("Đã tính xong lương tháng hiện tại!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            dynamic row = dgDanhSachLuong.SelectedItem;
            if (row == null) return;

            try
            {
                int id = row.MaNhanVien;
                string ky = row.KyLuong;
                int m = int.Parse(ky.Split('/')[0]);
                int y = int.Parse(ky.Split('/')[1]);

                var record = db.BangLuong.FirstOrDefault(b => b.MaNhanVien == id && b.Thang == m && b.Nam == y);
                if (record != null)
                {
                    record.TrangThaiThanhToan = "Đã thanh toán";
                    db.SaveChanges();
                    LoadDuLieuLuong();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnXuatExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = "BangLuong.csv" };
                if (sfd.ShowDialog() == true)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        sw.WriteLine("MaNV,HoTen,PhongBan,KyLuong,NgayCong,PhuCap,Thuong,ThucLinh,TrangThai");
                        foreach (dynamic item in dgDanhSachLuong.ItemsSource)
                        {
                            sw.WriteLine($"{item.MaNhanVien},{item.HoVaTen},{item.TenPhongBan},{item.KyLuong},{item.SoNgayCong},{item.PhuCap},{item.Thuong},{item.ThucLinh},{item.TrangThaiThanhToan}");
                        }
                    }
                    MessageBox.Show("Xuất file thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnTongQuan_Click(object sender, RoutedEventArgs e)
        {
            GiaoDien win = new GiaoDien();
            win.Show();
            this.Close();
        }

        private void btnNhanVien_Click(object sender, RoutedEventArgs e)
        {
            NhanVienWindow win = new NhanVienWindow();
            win.Show();
            this.Close();
        }

        private void btnTuyenDung_Click(object sender, RoutedEventArgs e)
        {
            TuyenDung win = new TuyenDung();
            win.Show();
            this.Close();
        }

        private void btnHieuSuat_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Close();
        }

        private void btnLuongThuong_Click(object sender, RoutedEventArgs e)
        {
            Window5 win = new Window5();
            win.Show();
            this.Close();
        }

        private void btnCaiDat_Click(object sender, RoutedEventArgs e)
        {
            CaiDat win = new CaiDat();
            win.Show();
            this.Close();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}