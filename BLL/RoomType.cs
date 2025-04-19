using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomType
    {
        private string maLoaiPhong; // MaLoaiPhong
        private string tenLoaiPhong; // TenLoaiPhong
        private decimal donGia; // DonGia
        private string tienNghi; // TienNghi
        private int sucChua; // SucChua
        private bool khaNangKeThemGiuong; // KhaNangKeThemGiuong
        private string moTa; // MoTa
        private byte[] hinhAnh; // HinhAnh

        public RoomType() { }

        public RoomType(string maLoaiPhong, string tenLoaiPhong, decimal donGia, string tienNghi, int sucChua, bool khaNangKeThemGiuong, string moTa, byte[] hinhAnh)
        {
            this.maLoaiPhong = maLoaiPhong;
            this.tenLoaiPhong = tenLoaiPhong;
            this.donGia = donGia;
            this.tienNghi = tienNghi;
            this.sucChua = sucChua;
            this.khaNangKeThemGiuong = khaNangKeThemGiuong;
            this.moTa = moTa;
            this.hinhAnh = hinhAnh;
        }

        public RoomType(DataRow row)
        {
            MaLoaiPhong = row["MaLoaiPhong"].ToString();
            TenLoaiPhong = row["TenLoaiPhong"].ToString();
            DonGia = row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : 0;
            TienNghi = row["TienNghi"].ToString();
            SucChua = row["SucChua"] != DBNull.Value ? Convert.ToInt32(row["SucChua"]) : 0;
            KhaNangKeThemGiuong = row["KhaNangKeThemGiuong"] != DBNull.Value && Convert.ToBoolean(row["KhaNangKeThemGiuong"]);
            MoTa = row["MoTa"] == DBNull.Value ? null : row["MoTa"].ToString();
            HinhAnh = row["HinhAnh"] == DBNull.Value ? null : (byte[])row["HinhAnh"];
        }

        public string MaLoaiPhong { get => maLoaiPhong; set => maLoaiPhong = value; }
        public string TenLoaiPhong { get => tenLoaiPhong; set => tenLoaiPhong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public string TienNghi { get => tienNghi; set => tienNghi = value; }
        public int SucChua { get => sucChua; set => sucChua = value; }
        public bool KhaNangKeThemGiuong { get => khaNangKeThemGiuong; set => khaNangKeThemGiuong = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public byte[] HinhAnh { get => hinhAnh; set => hinhAnh = value; }
    }
}
