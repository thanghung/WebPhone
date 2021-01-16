using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS_QLHH;
using DTO_QLHH;

namespace DoAnThucTap
{
    public partial class LoginKH : System.Web.UI.Page
    {
        BUS_DangNhapKhachHang tbl_dnkh = new BUS_DangNhapKhachHang();
        BUS_KhachHang tbl_kh = new BUS_KhachHang();
        DangNhapKhachHang tkdn = new DangNhapKhachHang();
        KhachHang kh = new KhachHang();
        int key = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                Response.Redirect("/TrangChu");
            }

            if (Page.RouteData.Values["modul"] != null)
            {
                PlaceHolder1.Visible = false;
                PlaceHolder2.Controls.Add(LoadControl("/PageShow/DangKy.ascx"));
            }
            else
            {
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = false;
            }
        }

        protected void btnDangNhap_ServerClick(object sender, EventArgs e)
        {
            DangNhapKhachHang dnkh = tbl_dnkh.GetbyUserTK(txtUserDN.Value, txtMatKhauDN.Value);

            if (dnkh == null)
                WebMsgBox.Show("Sai Thông tin tài khoản");
            else
            {
                HttpCookie myCookie = new HttpCookie("User");
                myCookie.Value = txtUserDN.Value.Trim();
                myCookie.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(myCookie);

                Response.Redirect("/TrangChu");
            }
        }

        protected void btnTimTK_ServerClick(object sender, EventArgs e)
        {
            tkdn = tbl_dnkh.CheckKey(Text1.Value.Trim());

            if (tkdn == null)
                Label1.Text = "Không tìm thấy tài khoản";
            else
            {
                kh = tbl_kh.GetbyID(tkdn.MaKH);
                key = new Random().Next(111111, 999999);

                if (key != 0)
                    Session["key"] = key;

                MailMessage mail = new MailMessage();

                mail.To.Add(kh.Email);
                mail.From = new MailAddress("nthung942014@gmail.com");
                mail.Subject = "Mã xác nhận của bạn là: " + key.ToString();

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("nthung942014@gmail.com", "01692762910hung");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MultiView1.ActiveViewIndex = 2;
            }
        }

        #region Di chuyển Trang View
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        #endregion

        protected void btnXacNhan_ServerClick(object sender, EventArgs e)
        {
            if (Text3.Value == Session["key"].ToString())
            {
                tkdn = tbl_dnkh.CheckKey(Text1.Value.Trim());
                kh = tbl_kh.GetbyID(tkdn.MaKH);

                MailMessage mail = new MailMessage();

                mail.To.Add(kh.Email);
                mail.From = new MailAddress("nthung942014@gmail.com");
                mail.Subject = "Mật Khẩu cũa bạn là: " + tkdn.MatKhauDN;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("nthung942014@gmail.com", "01692762910hung");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                MultiView1.ActiveViewIndex = 0;
                WebMsgBox.Show("Hãy kiểm tra hòm thư của bạn");
            }
            else
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Mã xác nhận không hợp lệ";
            }    
        }
    }
}