using BUS_QLHH;
using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        BUS_UserGroup tbl_user = new BUS_UserGroup();
        BUS_NhanVien tbl_nv = new BUS_NhanVien();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                UserGroup user = tbl_user.GetbyID(Request.Cookies["Login"]["id"].ToString().Trim());
                Login._nv = tbl_nv.TimUserTK(user.UserTK);
                lbUser.Text = "User Name: " + user.UserName;
            }
            else
                Response.Redirect("/DangNhapHeThong");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie ck = new HttpCookie("Login");
            ck.Expires = DateTime.Now.AddDays(-15d);
            Response.Cookies.Add(ck);
            Response.Redirect("/DangNhapHeThong");
        }
    }
}