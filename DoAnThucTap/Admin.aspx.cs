using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class Admin1 : System.Web.UI.Page
    {
        string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["modul"] != null)
                modul = Page.RouteData.Values["modul"].ToString().Trim();

            switch (modul)
            {
                //Khách Hàng
                case "kh":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/KhachHangLoad.ascx"));
                    break;
                case "td":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/TheDiem.ascx"));
                    break;
                //Hàng hóa
                case "hh":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/HangHoa.ascx"));
                    break;
                case "ncc":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/NhaCungCap.ascx"));
                    break;
                case "grhh":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/GRHangHoa.ascx"));
                    break;
                //Tồn Kho
                case "bnk":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/BangNhapKho.ascx"));
                    break;
                case "ctnk":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/ChiTietNhapKho.ascx"));
                    break;
                //Hóa Đơn
                case "hd":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/HoaDon.ascx"));
                    break;
                case "nhd":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/NhapHoaDon.ascx"));
                    break;
                case "cthd":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/ChiTietHoaDon.ascx"));
                    break;
                //Nhân Viên
                case "nv":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/NhanVien.ascx"));
                    break;
                case "grnv":
                    ImgNen.Visible = false;
                    PlQuanLy.Controls.Add(LoadControl("UserControl/GRNhanVien.ascx"));
                    break;
               
                
            }
        }
    }
}