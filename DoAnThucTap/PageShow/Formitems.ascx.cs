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
    public partial class FormItems : System.Web.UI.UserControl
    {
        BUS_HangHoa tbl_hh = new BUS_HangHoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["ID"] != null)
            {
                string id = Page.RouteData.Values["ID"].ToString().Trim();
                List<HangHoa> li_hh = new List<HangHoa>();

                if (tbl_hh.GetbyID(id) != null)
                    li_hh.Add(tbl_hh.GetbyID(id));
                else
                    li_hh = tbl_hh.Search(indext.key);

                if (li_hh.Count > 1)
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    DataList1.DataSource = li_hh;
                    DataList1.DataBind();
                }
                else
                if (li_hh.Count == 0)
                    WebMsgBox.Show("Không tìm thấy sản phẩm");
                else
                    if (li_hh.Count == 1)
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    FormView1.DataSource = li_hh;
                    FormView1.DataBind();
                }
            }
        }

        public static string RewriteUrlImg(string url)
        {
            string s = "";

            for (int i = 1; i < url.Length; i++)
                s += url[i];
            return s;
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            string Url;
            Url = "/ThongTinSanPham/" + e.CommandArgument.ToString().Trim();
            Response.Redirect(Url);
        }
    }
}