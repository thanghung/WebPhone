using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace DoAnThucTap
{
    public class Global : System.Web.HttpApplication
    {
        //Trang Chủ tương tác sản phẩm với khách hàng
        public static void TrangTuongTacKhachHang(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("TrangChuIndext", "TrangChu", "~/indext.aspx");
            routeCollection.MapPageRoute("ThongTinSanPham", "ThongTinSanPham/{ID}", "~/indext.aspx");
            routeCollection.MapPageRoute("LoginKhachHang", "DangNhapKhachHang", "~/LoginKH.aspx");
            routeCollection.MapPageRoute("DangKy", "DangNhapKhachHang/{modul}", "~/LoginKH.aspx");
            routeCollection.MapPageRoute("NhomSanPham", "NhomSanPham/{modul}", "~/indext.aspx");
            routeCollection.MapPageRoute("ThanhToan", "ThanhToan", "~/ThanhToan.aspx");
            routeCollection.MapPageRoute("HoSo", "HoSo/{modul}", "~/indext.aspx");
        }

        //Hệ thống
        public static void TrangHeThong(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("TrangHeThong", "TrangHeThong", "~/Admin.aspx");
            routeCollection.MapPageRoute("TrangDangNhap", "DangNhapHeThong", "~/Login.aspx");

            //Modul
            routeCollection.MapPageRoute("QuanLyKhachHang", "QuanLyKhachHang/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyTheDiem", "QuanLyTheDiem/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyNhaCungCap", "QuanLyNhaCungCap/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyNhomHangHoa", "QuanLyNhomHangHoa/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyHangHoa", "QuanLyHangHoa/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyNhapKho", "QuanLyNhapKho/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyChiTietNhapKho", "QuanLyChiTietNhapKho/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("NhapHoaDon", "NhapHoaDon/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyHoaDon", "QuanLyHoaDon/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyChiTietHoaDon", "QuanLyChiTietHoaDon/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyNhanVien", "QuanLyNhanVien/{modul}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyTaiKhoanNhanVien", "QuanLyTaiKhoanNhanVien/{modul}", "~/Admin.aspx");

            //ID 
            routeCollection.MapPageRoute("QuanLyKhachHang_Control", "QuanLyKhachHang/{modul}/{id}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyNhaCungCap_Control", "QuanLyNhaCungCap/{modul}/{id}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyNhomHangHoa_Control", "QuanLyNhomHangHoa/{modul}/{id}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyHangHoa_Control", "QuanLyHangHoa/{modul}/{id}", "~/Admin.aspx");
            routeCollection.MapPageRoute("NhapHoaDon_Control", "NhapHoaDon/{modul}/{id}", "~/Admin.aspx");
            routeCollection.MapPageRoute("QuanLyNhanVien_Control", "QuanLyNhanVien/{modul}/{id}", "~/Admin.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            TrangTuongTacKhachHang(RouteTable.Routes);
            TrangHeThong(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}