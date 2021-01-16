using BUS_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class BangNhapKho : System.Web.UI.UserControl
    {
        static BUS_NhapKho tbl_nk = new BUS_NhapKho();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowDuLieu();
        }

        public void ShowDuLieu()
        {
            DataList1.DataSource = tbl_nk.GetAllData();
            DataList1.DataBind();
            DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}