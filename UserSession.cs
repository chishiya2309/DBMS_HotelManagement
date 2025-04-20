using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS
{
    /// <summary>
    /// Lưu thông tin người dùng đăng nhập hiện tại để dùng cho phân quyền và truy xuất dữ liệu.
    /// </summary>
    public static class UserSession
    {
        public static int Id { get; set; }
        public static string Role { get; set; }
    }
}

