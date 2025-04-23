# Hệ Thống Quản Lý Khách Sạn (QLKS)

Hệ thống quản lý khách sạn được phát triển bằng C# .NET với mô hình 3 lớp, hỗ trợ các tính năng quản lý toàn diện cho hoạt động kinh doanh khách sạn.

## Tổng Quan

QLKS là một phần mềm quản lý khách sạn chuyên nghiệp được thiết kế để đáp ứng nhu cầu quản lý thông tin, dịch vụ và các hoạt động nghiệp vụ tại khách sạn. Hệ thống cung cấp giao diện người dùng thân thiện, trực quan với đầy đủ chức năng quản lý từ đặt phòng, quản lý khách hàng đến thanh toán và báo cáo thống kê.

## Kiến Trúc Hệ Thống

Dự án được xây dựng theo mô hình 3 lớp:

- **Presentation Layer**: Các form giao diện người dùng (UI)
- **Business Logic Layer (BLL)**: Xử lý logic nghiệp vụ
- **Data Access Layer (DAL)**: Kết nối và tương tác với cơ sở dữ liệu

### Công Nghệ Sử Dụng

- **Ngôn ngữ lập trình**: C# .NET Framework
- **Cơ sở dữ liệu**: Microsoft SQL Server
- **Giao diện người dùng**: Windows Forms với Guna.UI2
- **Mô hình kết nối**: ADO.NET

## Tính Năng Chính

### 1. Quản Lý Phòng
- Thêm, sửa, xóa thông tin phòng
- Quản lý loại phòng và giá phòng
- Theo dõi trạng thái phòng (Trống, Đã đặt, Đang sử dụng)

### 2. Đặt Phòng và Check-in
- Đặt phòng cho khách hàng
- Quản lý thông tin check-in, check-out
- Xác nhận đặt phòng
- Hỗ trợ đặt phòng cho nhóm khách

### 3. Quản Lý Khách Hàng
- Thêm, sửa, xóa thông tin khách hàng
- Tìm kiếm thông tin khách hàng
- Lưu trữ lịch sử sử dụng dịch vụ của khách

### 4. Dịch Vụ và Thanh Toán
- Quản lý các dịch vụ của khách sạn
- Tính toán và xuất hóa đơn
- Quản lý dịch vụ sử dụng cho từng phòng

### 5. Quản Lý Nhân Viên
- Thêm, sửa, xóa thông tin nhân viên
- Phân quyền người dùng
- Quản lý tài khoản đăng nhập

### 6. Báo Cáo và Thống Kê
- Thống kê doanh thu theo thời gian
- Báo cáo tình trạng phòng
- Thống kê sử dụng dịch vụ

## Cấu Trúc Dự Án

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

## Cài Đặt và Sử Dụng

### Yêu Cầu Hệ Thống
- Windows 7/8/10/11
- .NET Framework 4.5 trở lên
- Microsoft SQL Server 2014 trở lên

### Cài Đặt

1. **Cài đặt cơ sở dữ liệu**:
   - Chạy script khởi tạo database từ thư mục SQL
   - Cấu hình chuỗi kết nối trong file `DAL/DBConnection.cs`

2. **Biên dịch và chạy ứng dụng**:
   - Mở dự án bằng Visual Studio
   - Cài đặt các gói NuGet cần thiết (Guna.UI2)
   - Build và chạy ứng dụng

### Tài Khoản Mặc Định
- **Tên đăng nhập**: quanghung
- **Mật khẩu**: 123456

## Phát Triển

### Cấu Trúc Mã Nguồn
- **Form Files**: Chứa giao diện và xử lý sự kiện
- **DAO Files**: Chứa các phương thức truy xuất dữ liệu
- **Model Files**: Định nghĩa cấu trúc đối tượng dữ liệu

### Quy Ước Đặt Tên
- **Class**: PascalCase (ví dụ: RoomDAO)
- **Method**: PascalCase (ví dụ: GetRoomList)
- **Variable**: camelCase (ví dụ: roomType)
- **Control**: Prefix tương ứng với loại control (ví dụ: btnSave, txtName)

## Đóng Góp

Dự án được phát triển và duy trì bởi nhóm sinh viên thuộc **trường đại học Sư Phạm Kỹ Thuật thành phố Hồ Chí Minh** phục vụ cho môn học **Hệ quản trị cơ sở dữ liệu (Database Management System)**
Danh sách thành viên đóng góp cho dự án (Nguyễn Thành Vinh, Lê Quang Hưng, Nguyễn Thái Bảo, Dương Minh Duy)

## Giấy Phép

Phần mềm được phát hành dưới giấy phép MIT.
