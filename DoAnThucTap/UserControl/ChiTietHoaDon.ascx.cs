using BUS_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class ChiTietHoaDon1 : System.Web.UI.UserControl
    {
        static BUS_ChiTietHoaDon tbl_cthd = new BUS_ChiTietHoaDon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ShowData();
        }

        public void ShowData()
        {
            DataList1.DataSource = tbl_cthd.GetAllData();
            DataList1.DataBind();

            if (DataList1.Rows.Count > 0)
                DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}