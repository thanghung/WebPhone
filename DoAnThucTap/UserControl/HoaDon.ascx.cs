using BUS_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class HoaDon1 : System.Web.UI.UserControl
    {
        static BUS_HoaDon tbl_hd = new BUS_HoaDon();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        public void ShowData()
        {
            DataList1.DataSource = tbl_hd.GetAllData();
            DataList1.DataBind();

            if (DataList1.Rows.Count > 0)
                DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}