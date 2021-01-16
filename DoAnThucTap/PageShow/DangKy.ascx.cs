using BUS_QLHH;
using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class DangKy : System.Web.UI.UserControl
    {
        BUS_DangNhapKhachHang tbl_dnkh = new BUS_DangNhapKhachHang();
        static BUS_KhachHang tbl_kh = new BUS_KhachHang();
        DangNhapKhachHang dnkh = new DangNhapKhachHang();
        KhachHang kh = new KhachHang();
        int key;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangKy_ServerClick(object sender, EventArgs e)
        {
            dnkh = new DangNhapKhachHang();

            if (tbl_dnkh.CheckKey(txtUserDK.Value) != null)
            {
                WebMsgBox.Show("Tài khoản đã tồn tại");

                txtMatKhauDK.Value = "";
                txtNhapMK.Value = "";
            }
            else
            {
                key = new Random().Next(111111, 999999);

                if (key != 0)
                    Session["key"] = key;

                MailMessage mail = new MailMessage();

                mail.To.Add(txtEmail.Value.Trim());
                mail.From = new MailAddress("nthung942014@gmail.com");
                mail.Subject = "Mã xác nhận của bạn là: " + key.ToString();

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("nthung942014@gmail.com", "01692762910hung");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MultiView1.ActiveViewIndex = 1;
            }
        }

        #region Tạo Khóa Chính Khách Hàng
        public static string CreateKeyKH()
        {
            string Key = RanDomKeyKH();
            while (tbl_kh.GetbyID(Key) != null)
            {
                Key = RanDomKeyKH();
            }

            return Key;
        }

        public static string RanDomKeyKH()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "KH0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "KH000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "KH00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "KH0" + number.ToString();
            else
                Key = "KH" + number.ToString();

            return Key;
        }
        #endregion

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnXacNhan_ServerClick(object sender, EventArgs e)
        {
            if (Text3.Value == Session["key"].ToString().Trim())
            {
                //Tai Khoan
                dnkh.userDN = txtUserDK.Value;
                dnkh.MatKhauDN = txtMatKhauDK.Value;
                dnkh.MaKH = CreateKeyKH();

                //Khach Hang
                kh.MaKH = dnkh.MaKH;
                kh.Email = txtEmail.Value.Trim();
                kh.TenKH = "";
                kh.SDT = "";
                kh.DiaChi = "";
                kh.DiemSo = 0;
                kh.Luu = false;

                tbl_kh.Insert(kh);
                tbl_dnkh.Insert(dnkh);
                Response.Redirect("/DangNhapKhachHang");
            }
            else
            {
                Label1.Text = "Mã xác nhận không chính xác";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}