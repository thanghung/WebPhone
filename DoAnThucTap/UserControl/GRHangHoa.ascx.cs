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
    public partial class GRHangHoa : System.Web.UI.UserControl
    {
        static BUS_GRHangHoa tbl_grhh = new BUS_GRHangHoa();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();
            if (!IsPostBack)
            {
                HienThiFormInput();
            }
        }

        public void HienThiFormInput()
        {
            if (Page.RouteData.Values["id"] != null)
            {
                //điều chỉnh button ẩn hiện
                btnSudmit.Visible = false;
                btnDelete.Visible = true;

                string id = Page.RouteData.Values["id"].ToString().Trim();
                GroupHangHoa grhh = tbl_grhh.GetbyID(id);

                ttbTenGRHang.Text = grhh.TenGroupHang.ToString();
            }
            else
            {
                //điều chỉnh button ẩn hiện
                btnSudmit.Visible = true;
                btnDelete.Visible = false;

            }
        }

        public void ShowData()
        {
            DataList1.DataSource = tbl_grhh.GetAllData();
            DataList1.DataBind();
            DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void btnSudmit_Click(object sender, EventArgs e)
        {
            GroupHangHoa grhh = new GroupHangHoa();
            InputGRHangHoa(grhh);

            WebMsgBox.Show("Thêm nhóm hàng thành công");
        }

        public void InputGRHangHoa(GroupHangHoa grhh)
        {
            grhh.MaGRHang = CreateKey();
            grhh.TenGroupHang = ttbTenGRHang.Text;
            grhh.IDNV = Login._nv.MaNV;
            grhh.TenNV = Login._nv.TenNV;

            //Đưa vào CSDL
            tbl_grhh.Insert(grhh);
            Response.Redirect("/QuanLyNhomHangHoa/grhh");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["id"].ToString().Trim();
            GroupHangHoa grhh = tbl_grhh.GetbyID(id);

            tbl_grhh.Delete(grhh);
            WebMsgBox.Show("Xóa nhóm hàng thành công");
            Response.Redirect("/QuanLyNhomHangHoa/grhh");
        }

        #region Tạo Khóa Chính
        private string CreateKey()
        {
            string Key = RanDomKey();
            while (tbl_grhh.GetbyID(Key) != null)
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
                Key = "GH0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "GH000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "GH00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "GH0" + number.ToString();
            else
                Key = "GH" + number.ToString();

            return Key;
        }
        #endregion
    }
}