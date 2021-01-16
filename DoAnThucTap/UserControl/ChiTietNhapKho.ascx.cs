using BUS_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class ChiTietNhapKho1 : System.Web.UI.UserControl
    {
        static BUS_ChiTietNhapKho tbl_ctnk = new BUS_ChiTietNhapKho();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        public void ShowData()
        {
            DataList1.DataSource = tbl_ctnk.GetAllData();
            DataList1.DataBind();
            DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}