using BUS_QLHH;
using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class indext : System.Web.UI.MasterPage
    {
        BUS_HangHoa tbl_hh = new BUS_HangHoa();
        public static string key = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            form1.Action = Request.RawUrl;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Value.Trim() != "")
            {
                string Url;
                HangHoa hh = tbl_hh.GetbyName(txtSearch.Value.Trim());

                if (hh != null)
                    Url = "/ThongTinSanPham/" + hh.MaHang.ToString().Trim();
                else
                    Url = "/ThongTinSanPham/" + "TimKiem";

                key = txtSearch.Value.Trim();
                Response.Redirect(Url);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TxTEmail.Text = "";
            TxTCauHoi.Text = "";
            WebMsgBox.Show("Gửi Thành Công");
        }

        protected void btnDangKyEmail_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add(ttbEmail.Text.Trim());
            mail.From = new MailAddress("nthung942014@gmail.com");
            mail.Subject = "Cảm ơn bạn đã đăng ký nhận email từ tôi";

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("nthung942014@gmail.com", "01692762910hung");
            smtp.EnableSsl = true;

            smtp.Send(mail);

            WebMsgBox.Show("Đăng ký thành công");
            ttbEmail.Text = "";
        }
    }
}