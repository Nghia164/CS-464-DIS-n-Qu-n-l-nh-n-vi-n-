# CS-464-DIS-n-Qu-n-l-nh-n-vi-n-
Đây là đồ án nhóm 5 về đề tài quản lý nhân viên 

# 🏢 Phần Mềm Quản Lý Nhân Sự (HR Management System)

Đây là ứng dụng quản lý nhân sự toàn diện dành cho doanh nghiệp, được xây dựng trên nền tảng **C# WPF** kết hợp với **Entity Framework**. Ứng dụng cung cấp giao diện trực quan, hiện đại (Material/Flat Design) và xử lý mượt mà các nghiệp vụ từ quản lý hồ sơ, chấm công, tính lương đến đánh giá hiệu suất.

## 🚀 Các Tính Năng Nổi Bật

* **📊 Tổng Quan (Dashboard):** Thống kê số lượng nhân viên, trạng thái nghỉ phép, nhân viên mới và tìm kiếm nhanh.
* **👥 Quản Lý Nhân Viên:** Thêm, Sửa, Xóa hồ sơ nhân viên chi tiết (thông tin cá nhân, phòng ban, ảnh đại diện, trạng thái).
* **📅 Tuyển Dụng:** Quản lý danh sách các vị trí đang tuyển, theo dõi tiến độ và số lượng hồ sơ ứng tuyển.
* **📈 Hiệu Suất & Đánh Giá:** Theo dõi điểm KPI, số lượng dự án hoàn thành, giờ làm việc và vinh danh Top nhân viên xuất sắc nhất.
* **💰 Lương Thưởng & Thâm Niên:** Tự động tính thâm niên, tính lương thực lĩnh dựa trên ngày công/phụ cấp, đánh dấu trạng thái thanh toán và **Xuất báo cáo ra file Excel (.csv)**.
* **⚙️ Cài Đặt Hệ Thống:** Cấu hình chuỗi kết nối Cơ sở dữ liệu (SQL Server, MySQL) và quản lý phân quyền cấp phát tài khoản Admin.

## 🛠️ Công Nghệ Sử Dụng

* **Ngôn ngữ:** C# (.NET Framework / .NET Core)
* **Giao diện:** WPF (Windows Presentation Foundation) - XAML
* **Cơ sở dữ liệu:** SQL Server (LocalDB)
* **ORM:** Entity Framework (LINQ to Entities)

## 💻 Hướng Dẫn Cài Đặt & Chạy Dự Án

1. **Yêu cầu hệ thống:**
   * Cài đặt [Visual Studio 2019/2022](https://visualstudio.microsoft.com/) (có tick chọn module *.NET desktop development*).
   * Cài đặt SQL Server / SQL Server Express (hoặc LocalDB đi kèm Visual Studio).

2. **Khởi tạo cơ sở dữ liệu:**
   * Mở SQL Server Management Studio (SSMS) hoặc cửa sổ SQL Server Object Explorer trong Visual Studio.
   * Chạy file script cơ sở dữ liệu (vd: `Database.sql`) đính kèm trong thư mục dự án để tạo bảng và dữ liệu mẫu.
   * *Lưu ý:* Nếu bạn dùng LocalDB, chuỗi kết nối mặc định trong mã nguồn thường là: `Server=(localdb)\MSSQLLocalDB;Initial Catalog=QUANLYNHANVIEN;Integrated Security=True`.

3. **Chạy ứng dụng:**
   * Mở file solution (`.sln`) bằng Visual Studio.
   * Nhấn `Ctrl + Shift + B` để Rebuild lại toàn bộ dự án.
   * Nhấn `F5` hoặc nút **Start** để chạy ứng dụng.

## 🔐 Tài Khoản Đăng Nhập Mặc Định

Để truy cập vào hệ thống với toàn quyền Quản trị trị viên (Admin), vui lòng sử dụng thông tin đăng nhập sau:

* **Tên đăng nhập:** `admin1`
* **Mật khẩu:** `12345`

> **Lưu ý:** Bạn có thể tạo thêm tài khoản Admin khác từ tính năng *"+ Thêm Admin"* ngay bên trong phần mềm sau khi đăng nhập.

## 📸 Giao Diện Tham Khảo

*(Bạn có thể chụp vài bức ảnh giao diện phần mềm của bạn, lưu vào thư mục `Images` trong code và thay đổi đường dẫn ở đây để README đẹp hơn nhé)*

* Bảng Điều Hành: `![Dashboard](link-anh-tong-quan)`
* Quản Lý Nhân Viên: `![NhanVien](link-anh-nhan-vien)`
* Bảng Lương: `![BangLuong](link-anh-bang-luong)`

---
*Dự án được phát triển nhằm mục đích tối ưu hóa quy trình quản lý nhân sự.*
