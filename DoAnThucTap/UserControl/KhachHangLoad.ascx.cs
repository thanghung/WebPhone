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
    public partial class KhachHangLoad1 : System.Web.UI.UserControl
    {
        static BUS_KhachHang tbl_kh = new BUS_KhachHang();
        static BUS_TheDiem tbl_td = new BUS_TheDiem();

        TheDiem td = new TheDiem();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();
            if (!IsPostBack)
            {
                HienThiFormInput();
            }
        }

        public void ShowData()
        {
            DataList1.DataSource = tbl_kh.GetAllData();
            DataList1.DataBind();

            if (DataList1.Rows.Count > 0)
                DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void HienThiFormInput()
        {
            if (Page.RouteData.Values["id"] != null)
            {
                //ẩn hiện buttun
                btnSudmit.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = true;

                //Hiển Thị dữ liệu Input
                string id = Page.RouteData.Values["id"].ToString().Trim();
                KhachHang kh = tbl_kh.GetbyID(id);
                ttbTenKH.Text = kh.TenKH;
                ttbEmail.Text = kh.Email;
                ttbSDT.Text = kh.SDT.ToString();
                ttbDiaChi.Text = kh.DiaChi;
                ttbDiemSo.Text = kh.DiemSo.ToString();
            }
            else
            {
                //ẩn hiện buttun
                btnSudmit.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = false;

            }
        }

        protected void btnSudmit_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            InputKhachHang(kh);

            WebMsgBox.Show("Thêm khách hàng thành công");
        }

        public void InputKhachHang(KhachHang kh)
        {

            //Khai báo đối tượng lấy thông tin nhập vào bảng
            kh.MaKH = CreateKeyKH();
            kh.TenKH = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(ttbTenKH.Text.ToLower().Trim());
            kh.Email = ttbEmail.Text.Trim();
            kh.SDT = ttbSDT.Text;
            kh.DiemSo = Decimal.Parse(ttbDiemSo.Text);
            kh.DiaChi = ttbDiaChi.Text;

            TinhDiem(kh);
            //đưa thông tin của bảng vào database và lưu lại
            if (tbl_kh.CheckKey(ttbEmail.Text.Trim(), ttbTenKH.Text.Trim(), ttbSDT.Text.Trim()) == null)
            {
                tbl_kh.Insert(kh);
            }
            else
            {
                tbl_kh.Update(kh);
            }

            Response.Redirect("~/QuanLyKhachHang/kh");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string makh = Page.RouteData.Values["id"].ToString().Trim();
            KhachHang kh = tbl_kh.GetbyID(makh);
            TheDiem td = tbl_td.GetbyIDKH(kh.MaKH);

            tbl_kh.Delete(kh);
            tbl_td.Delete(td);

            WebMsgBox.Show("Xóa khách hàng thành công");
            Response.Redirect("~/QuanLyKhachHang/kh");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string makh = Page.RouteData.Values["id"].ToString().Trim();
            KhachHang kh = tbl_kh.GetbyID(makh);
            kh.TenKH = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(ttbTenKH.Text.ToLower());
            kh.Email = ttbEmail.Text.Trim();
            kh.SDT = ttbSDT.Text;
            kh.DiemSo = Int32.Parse(ttbDiemSo.Text);
            kh.DiaChi = ttbDiaChi.Text;
            tbl_kh.Update(kh);

            //Cập nhật điểm
            TinhDiem(kh);

            WebMsgBox.Show("Cập nhật khách hàng thành công");
            Response.Redirect("~/QuanLyKhachHang/kh");
        }

        public void TinhDiem(KhachHang kh)
        {
            td = tbl_td.GetbyIDKH(kh.MaKH);
            bool flag = false;

            if (td != null)
            {
                td.DiemThe = kh.DiemSo;
                td.TenNV = Login._nv.TenNV;
                flag = true;
            }
            else
            {
                td = new TheDiem();
                td.ID = CreateKeyTD();
                td.DiemThe = kh.DiemSo;
                td.IDNV = Login._nv.MaNV;
                td.TenNV = Login._nv.TenNV;
                td.TenKH = kh.TenKH;
                td.IDKH = kh.MaKH;
            }

            if (kh.DiemSo > 3000 && kh.DiemSo < 5000)
            {
                td.TenTD = "Vàng";
            }
            else
                if (kh.DiemSo > 5000)
            {
                td.TenTD = "Bạch Kim";
            }
            else
            {
                td.TenTD = "Thường";
            }

            if (flag)
                tbl_td.Update(td);
            else
                tbl_td.Insert(td);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string makh = Page.RouteData.Values["id"].ToString().Trim();
            KhachHang kh = tbl_kh.GetbyID(makh);

            kh.Luu = true;
            tbl_kh.Update(kh);

            WebMsgBox.Show("Lưu khách hàng thành công");
            Response.Redirect("~/QuanLyKhachHang/kh");
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

        #region Tạo Khóa Chính Thẻ Điểm
        public static string CreateKeyTD()
        {
            string Key = RandomKeyTD();
            while (tbl_td.GetByID(Key) != null)
            {
                Key = RandomKeyTD();
            }

            return Key;
        }

        public static string RandomKeyTD()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "TD0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "TD000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "TD00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "TD0" + number.ToString();
            else
                Key = "TD" + number.ToString();

            return Key;
        }
        #endregion
    }
}