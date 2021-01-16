using BUS_QLHH;
using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class Profile : System.Web.UI.UserControl
    {
        BUS_DangNhapKhachHang tbl_dnkh = new BUS_DangNhapKhachHang();
        BUS_KhachHang tbl_kh = new BUS_KhachHang();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["User"];

            string id = myCookie.Value.Trim();
            KhachHang kh = tbl_kh.GetbyID(tbl_dnkh.CheckKey(id).MaKH);

            if (kh != null)
            {
                ttbTenKH.Text = kh.TenKH;
                ttbEmail.Text = kh.Email;
                ttbSDT.Text = kh.SDT.ToString();
                ttbDiaChi.Text = kh.DiaChi;
                ttbDiemSo.Text = kh.DiemSo.ToString();
            }

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = new HttpCookie("User");
            myCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(myCookie);

            Response.Redirect("/Trangchu");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["User"];

            string id = myCookie.Value.Trim();
            DangNhapKhachHang tk = tbl_dnkh.CheckKey(id);
            KhachHang kh = tbl_kh.GetbyID(tk.MaKH);

            if (kh == null)
            {
                kh = new KhachHang();

                kh.MaKH = tk.MaKH;
                kh.TenKH = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(ttbTenKH.Text.ToLower().Trim());
                kh.Email = ttbEmail.Text.Trim();
                kh.SDT = ttbSDT.Text;
                kh.DiemSo = Decimal.Parse(ttbDiemSo.Text);
                kh.DiaChi = ttbDiaChi.Text;

                tbl_kh.Insert(kh);
            }

            else 
            {
                kh.TenKH = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(ttbTenKH.Text.ToLower().Trim());
                kh.Email = ttbEmail.Text.Trim();
                kh.SDT = ttbSDT.Text;
                kh.DiemSo = Decimal.Parse(ttbDiemSo.Text);
                kh.DiaChi = ttbDiaChi.Text;

                tbl_kh.Update(kh);
            }
        }
    }
}