using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookingRecord
    {
        public BookingRecord() { }

        private int maHoSoDatPhong; // MaHoSoDatPhong
        private int maPhong;        // MaPhong
        private int maKhachHang;    // MaKhachHang
        private decimal tienDatCoc; // TienDatCoc
        private int soDem;          // SoDem
        private string trangThaiDatPhong; // TrangThaiDatPhong
        private DateTime thoiGianCheckinDuKien; // ThoiGianCheckinDuKien
        private DateTime thoiGianCheckoutDuKien; // ThoiGianCheckoutDuKien
        private DateTime? thoiGianCheckinThucTe; // ThoiGianCheckinThucTe
        private DateTime? thoiGianCheckoutThucTe; // ThoiGianCheckoutThucTe
        private DateTime thoiGianDatPhong; // ThoiGianDatPhong
        private string soTheTinDung; // SoTheTinDung
        private string ghiChu; // GhiChu

        public BookingRecord(int maHoSoDatPhong, int maPhong, int maKhachHang, decimal tienDatCoc, int soDem, string trangThaiDatPhong, DateTime thoiGianCheckinDuKien, DateTime thoiGianCheckoutDuKien, DateTime? thoiGianCheckinThucTe, DateTime? thoiGianCheckoutThucTe, DateTime thoiGianDatPhong, string soTheTinDung, string ghiChu)
        {
            this.maHoSoDatPhong = maHoSoDatPhong;
            this.maPhong = maPhong;
            this.maKhachHang = maKhachHang;
            this.tienDatCoc = tienDatCoc;
            this.soDem = soDem;
            this.trangThaiDatPhong = trangThaiDatPhong;
            this.thoiGianCheckinDuKien = thoiGianCheckinDuKien;
            this.thoiGianCheckoutDuKien = thoiGianCheckoutDuKien;
            this.thoiGianCheckinThucTe = thoiGianCheckinThucTe;
            this.thoiGianCheckoutThucTe = thoiGianCheckoutThucTe;
            this.thoiGianDatPhong = thoiGianDatPhong;
            this.soTheTinDung = soTheTinDung;
            this.ghiChu = ghiChu;
        }

        public BookingRecord(DataRow row)
        {
            MaHoSoDatPhong = (int)row["MaHoSoDatPhong"];
            MaPhong = (int)row["MaPhong"];
            MaKhachHang = (int)row["MaKhachHang"];
            TienDatCoc = row["TienDatCoc"] != DBNull.Value ? Convert.ToDecimal(row["TienDatCoc"]) : 0;
            SoDem = (int)row["SoDem"];
            TrangThaiDatPhong = row["TrangThaiDatPhong"].ToString();
            ThoiGianCheckinDuKien = (DateTime)row["ThoiGianCheckinDuKien"];
            ThoiGianCheckoutDuKien = (DateTime)row["ThoiGianCheckoutDuKien"];
            ThoiGianCheckinThucTe = row["ThoiGianCheckinThucTe"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ThoiGianCheckinThucTe"];
            ThoiGianCheckoutThucTe = row["ThoiGianCheckoutThucTe"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ThoiGianCheckoutThucTe"];
            ThoiGianDatPhong = (DateTime)row["ThoiGianDatPhong"];
            SoTheTinDung = row["SoTheTinDung"].ToString();
            GhiChu = row["GhiChu"] == DBNull.Value ? null : row["GhiChu"].ToString();
        }

        public int MaHoSoDatPhong { get => maHoSoDatPhong; set => maHoSoDatPhong = value; }
        public int MaPhong { get => maPhong; set => maPhong = value; }
        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public decimal TienDatCoc { get => tienDatCoc; set => tienDatCoc = value; }
        public int SoDem { get => soDem; set => soDem = value; }
        public string TrangThaiDatPhong { get => trangThaiDatPhong; set => trangThaiDatPhong = value; }
        public DateTime ThoiGianCheckinDuKien { get => thoiGianCheckinDuKien; set => thoiGianCheckinDuKien = value; }
        public DateTime ThoiGianCheckoutDuKien { get => thoiGianCheckoutDuKien; set => thoiGianCheckoutDuKien = value; }
        public DateTime? ThoiGianCheckinThucTe { get => thoiGianCheckinThucTe; set => thoiGianCheckinThucTe = value; }
        public DateTime? ThoiGianCheckoutThucTe { get => thoiGianCheckoutThucTe; set => thoiGianCheckoutThucTe = value; }
        public DateTime ThoiGianDatPhong { get => thoiGianDatPhong; set => thoiGianDatPhong = value; }
        public string SoTheTinDung
        {
            get => soTheTinDung;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 16 || value.Length > 19)
                    throw new ArgumentException("SoTheTinDung phải có độ dài từ 16 đến 19 ký tự.");
                soTheTinDung = value;
            }
        }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
