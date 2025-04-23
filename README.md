# 🏨 Hệ Thống Quản Lý Khách Sạn (QLKS)

![Platform](https://img.shields.io/badge/platform-Windows-blue)
![.NET](https://img.shields.io/badge/.NET-Framework%204.5+-blue)
![License: MIT](https://img.shields.io/badge/license-MIT-green)

Hệ thống quản lý khách sạn được phát triển bằng **C# .NET** theo mô hình **3 lớp**, hỗ trợ các tính năng quản lý toàn diện cho hoạt động kinh doanh khách sạn hiện đại.

---

## 🧭 Tổng Quan

**QLKS** là phần mềm quản lý khách sạn chuyên nghiệp, thân thiện với người dùng, tích hợp đầy đủ chức năng từ quản lý phòng, khách hàng, dịch vụ đến thanh toán và báo cáo.

---

## 🏗️ Kiến Trúc Hệ Thống

Dự án được xây dựng theo mô hình **3 lớp**:

- **🔵 Presentation Layer**: Giao diện người dùng (Windows Forms)
- **🟢 Business Logic Layer (BLL)**: Xử lý logic nghiệp vụ
- **🟡 Data Access Layer (DAL)**: Tương tác với cơ sở dữ liệu (SQL Server)

---

## 🔧 Công Nghệ Sử Dụng

- 🖥️ Ngôn ngữ lập trình: **C# (.NET Framework)**
- 🗄️ Cơ sở dữ liệu: **Microsoft SQL Server**
- 🎨 Giao diện người dùng: **WinForms + Guna.UI2**
- 🔌 Mô hình kết nối: **ADO.NET**

---

## ✨ Tính Năng Chính

### 🛏️ 1. Quản Lý Phòng
- Thêm, sửa, xóa thông tin phòng
- Quản lý loại phòng và giá phòng
- Theo dõi trạng thái phòng (Trống, Đã đặt, Đang sử dụng)

### 📅 2. Đặt Phòng và Check-in
- Đặt phòng cá nhân hoặc theo nhóm
- Quản lý check-in, check-out, xác nhận đặt phòng

### 🙍‍♂️ 3. Quản Lý Khách Hàng
- Thêm, sửa, xóa thông tin khách hàng
- Tìm kiếm khách hàng, lưu lịch sử sử dụng dịch vụ

### 🍽️ 4. Dịch Vụ và Thanh Toán
- Quản lý các dịch vụ kèm theo
- Tính hóa đơn, xuất hóa đơn nhanh chóng

### 👥 5. Quản Lý Nhân Viên
- Thêm, sửa, xóa nhân viên
- Quản lý tài khoản đăng nhập, phân quyền người dùng

### 📊 6. Báo Cáo và Thống Kê
- Thống kê doanh thu theo ngày/tháng/năm
- Báo cáo tình trạng phòng và dịch vụ sử dụng

---

## 📁 Cấu Trúc Dự Án

```
QLKS/
├── BLL/                 # Business Logic Layer
│   ├── DAO/             # Data Access Objects
│   └── Models           # Business Models
├── DAL/                 # Data Access Layer
├── Forms/               # User Interface
├── Resources/           # Resources files
└── SQL/                 # SQL Scripts
```

--- 

## ⚙️ Cài Đặt và Sử Dụng

### 🖥️ Yêu Cầu Hệ Thống
- Hệ điều hành: Windows 7/8/10/11
- .NET Framework: 4.5 trở lên
- Microsoft SQL Server: 2014 trở lên

### 🧪 Cài Đặt
1. **Cài đặt cơ sở dữ liệu**:
   - Chạy script khởi tạo từ thư mục `SQL/`
   - Cập nhật chuỗi kết nối trong file `DAL/DBConnection.cs`

2. **Chạy ứng dụng**:
   - Mở bằng Visual Studio
   - Cài đặt các gói NuGet (ví dụ: `Guna.UI2`)
   - Build và chạy ứng dụng

### 🔐 Tài Khoản Mặc Định
- **Tên đăng nhập**: `quanghung`
- **Mật khẩu**: `123456`

---

## 👨‍💻 Nhóm Phát Triển

Dự án được phát triển bởi sinh viên trường **Đại học Sư Phạm Kỹ Thuật TP.HCM** trong khuôn khổ môn học **Hệ quản trị cơ sở dữ liệu (Database Management System)**:

- 🧑‍💼 Nguyễn Thành Vinh  
- 🧑‍💼 Lê Quang Hưng  
- 🧑‍💼 Nguyễn Thái Bảo  
- 🧑‍💼 Dương Minh Duy

---

## 📜 Giấy Phép

Phần mềm được phát hành theo giấy phép [MIT](https://opensource.org/licenses/MIT) – sử dụng miễn phí, chỉnh sửa thoải mái.

---

> 💡 *Nếu bạn thấy dự án hữu ích, hãy ⭐ để ủng hộ nhóm nhé!*

