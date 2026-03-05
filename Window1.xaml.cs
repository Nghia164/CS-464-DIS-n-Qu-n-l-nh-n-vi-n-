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
    public partial class Window1 : Window
    {
        QUANLYNHANVIENEntities db = new QUANLYNHANVIENEntities();

        public class TopNhanVienModel
        {
            public string RankIcon { get; set; }
            public string RankColor { get; set; }
            public string HoVaTen { get; set; }
            public string TenPhongBan { get; set; }
            public double DiemKPI { get; set; }
        }

        public Window1()
        {
            InitializeComponent();
            LoadDataHieuSuat();
        }

        private void LoadDataHieuSuat()
        {
            try
            {
                txtDiemTB.Text = "4.8";
                txtDuAn.Text = "92";
                pbDuAn.Value = 92;
                txtGioLam.Text = "1,240h";

                var nvList = (from nv in db.NhanVien
                              join pb in db.PhongBan on nv.MaPhongBan equals pb.MaPhongBan into pbGroup
                              from pb in pbGroup.DefaultIfEmpty()
                              where nv.TrangThaiLamViec == "Đang làm" || nv.TrangThaiLamViec == "Đang làm việc"
                              select new
                              {
                                  HoVaTen = nv.HoVaTen,
                                  TenPhongBan = pb != null ? pb.TenPhongBan : "Chưa phân bổ"
                              }).Take(3).ToList();

                var topList = new List<TopNhanVienModel>();
                double[] kpis = { 9.8, 9.5, 9.2 };
                string[] icons = { "🥇", "🥈", "🥉" };
                string[] colors = { "#FEF08A", "#E2E8F0", "#FED7AA" };

                for (int i = 0; i < nvList.Count && i < 3; i++)
                {
                    topList.Add(new TopNhanVienModel
                    {
                        RankIcon = icons[i],
                        RankColor = colors[i],
                        HoVaTen = nvList[i].HoVaTen,
                        TenPhongBan = nvList[i].TenPhongBan,
                        DiemKPI = kpis[i]
                    });
                }

                dgTopNhanVien.ItemsSource = topList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu hiệu suất: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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