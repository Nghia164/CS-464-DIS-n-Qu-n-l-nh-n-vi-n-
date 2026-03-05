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
    public partial class TuyenDung : Window
    {
        public class TinTuyenDungModel
        {
            public string ViTri { get; set; }
            public int SoLuong { get; set; }
            public string PhongBan { get; set; }
            public string MauPhongBan { get; set; }
            public double PhanTram { get; set; }
            public int DaNhan { get; set; }
        }

        public TuyenDung()
        {
            InitializeComponent();
            LoadDuLieuTuyenDung();
        }

        private void LoadDuLieuTuyenDung()
        {
            try
            {
                var danhSachTin = new List<TinTuyenDungModel>
                {
                    new TinTuyenDungModel
                    {
                        ViTri = "Lập trình viên C#/.NET",
                        SoLuong = 5,
                        PhongBan = "Phòng Kỹ Thuật",
                        MauPhongBan = "#2563EB",
                        PhanTram = 40,
                        DaNhan = 12
                    },
                    new TinTuyenDungModel
                    {
                        ViTri = "Chuyên viên Digital MKT",
                        SoLuong = 2,
                        PhongBan = "Phòng Marketing",
                        MauPhongBan = "#D97706",
                        PhanTram = 80,
                        DaNhan = 45
                    },
                    new TinTuyenDungModel
                    {
                        ViTri = "Software Tester (QC)",
                        SoLuong = 3,
                        PhongBan = "Phòng Kỹ Thuật",
                        MauPhongBan = "#2563EB",
                        PhanTram = 20,
                        DaNhan = 4
                    },
                    new TinTuyenDungModel
                    {
                        ViTri = "Chuyên viên Tuyển dụng",
                        SoLuong = 1,
                        PhongBan = "Phòng Nhân Sự",
                        MauPhongBan = "#10B981",
                        PhanTram = 10,
                        DaNhan = 2
                    },
                    new TinTuyenDungModel
                    {
                        ViTri = "Intern ReactJS/NodeJS",
                        SoLuong = 10,
                        PhongBan = "Phòng Đào Tạo",
                        MauPhongBan = "#8B5CF6",
                        PhanTram = 95,
                        DaNhan = 80
                    }
                };

                icTuyenDung.ItemsSource = danhSachTin;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tuyển dụng: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnTaoTinTuyenDung_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tính năng Tạo Tin Tuyển Dụng chưa có!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
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
