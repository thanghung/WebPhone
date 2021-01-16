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
    public partial class NhaCungCap1 : System.Web.UI.UserControl
    {
        static BUS_NhaCungCap tbl_ncc = new BUS_NhaCungCap();

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
            DataList1.DataSource = tbl_ncc.GetAllData();
            DataList1.DataBind();
            DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void HienThiFormInput()
        {
            if (Page.RouteData.Values["id"] != null)
            {
                //ẩn hiện buttun
                btnSudmit.Visible = false;
                btnDelete.Visible = true;

                //Hiển Thị dữ liệu Input
                string id = Page.RouteData.Values["id"].ToString().Trim();
                NhaCungCap ncc = tbl_ncc.GetbyID(id);
                ttbTenNCC.Text = ncc.TenNCC;
                ttbDiaChi.Text = ncc.DiaChi;
                ttbSDT.Text = ncc.DienThoai.ToString();  
            }
            else
            {
                //ẩn hiện buttun
                btnSudmit.Visible = true;
                btnDelete.Visible = false;

            }
        }
       
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["id"].ToString().Trim();
            NhaCungCap ncc = tbl_ncc.GetbyID(id);

            tbl_ncc.Delete(ncc);
            WebMsgBox.Show("Xóa nhà cung cấp thành công");
            Response.Redirect("/QuanLyNhaCungCap/ncc");
        }

        protected void btnSudmit_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            InputNCC(ncc);

            WebMsgBox.Show("Thêm nhà cung cấp thành công");
        }

        public void InputNCC(NhaCungCap ncc)
        {
            if (ttbTenNCC.Text.Trim() != "" && ttbDiaChi.Text.Trim() != "" && ttbSDT.Text.Trim() != "")
            {
                ncc.MaNCC = CreateKey();
                ncc.TenNCC = ttbTenNCC.Text;
                ncc.DiaChi = ttbDiaChi.Text;
                ncc.DienThoai = ttbSDT.Text;
                ncc.IDNV = Login._nv.MaNV;
                ncc.TenNV = Login._nv.TenNV;


                //đưa thông tin của bảng vào database và lưu lại
                tbl_ncc.Insert(ncc);
                Response.Redirect("/QuanLyNhaCungCap/ncc");
            }
            else
                WebMsgBox.Show("Hãy nhập đầy đủ thông tin nhà cung cấp");
        }

        #region Tạo Khóa Chính
        private string CreateKey()
        {
            string Key = RanDomKey();
            while (tbl_ncc.GetbyID(Key) != null)
            {
                Key = RanDomKey();
            }

            return Key;
        }

        private string RanDomKey()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "NCC0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "NCC000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "NCC00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "NCC0" + number.ToString();
            else
                Key = "NCC" + number.ToString();

            return Key;
        }
        #endregion
    }
}