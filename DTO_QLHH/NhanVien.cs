//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO_QLHH
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVien
    {
        public string UserTK { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string MatKhau { get; set; }
        public bool GioiTinh { get; set; }
        public string Diachi { get; set; }
        public string DienThoai { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string TrangThai { get; set; }
        public int LoiNhuan { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual UserGroup UserGroup { get; set; }
    }
}
