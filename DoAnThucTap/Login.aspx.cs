using BUS_QLHH;
using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class Login : System.Web.UI.Page
    {
        static BUS_NhanVien tbl_nv = new BUS_NhanVien();
        public static NhanVien _nv;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                Response.Redirect("/TrangHeThong");
            }
            
            if (!this.IsPostBack)
                ViewState["LoginErrors"] = 0;
        }

        private bool CheckAccount(string UserName, string Password)
        {
            _nv = tbl_nv.CheckAccount(UserName, Password);
           
            if (_nv != null)
            {
                HttpCookie ck = new HttpCookie("Login");
                ck["id"] = _nv.UserTK;
                ck.Expires = DateTime.Now.AddDays(15d);
                Response.Cookies.Add(ck);
                return true;
            }
            else
                return false;

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (CheckAccount(Login1.UserName, Login1.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                e.Authenticated = true;
                // Response.Redirect();
                Login1.Visible = false;
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}