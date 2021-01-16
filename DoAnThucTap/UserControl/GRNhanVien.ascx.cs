using BUS_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap.UserControl
{
    public partial class GRNhanVien : System.Web.UI.UserControl
    {
        static BUS_UserGroup tbl_grnv = new BUS_UserGroup();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData(); 
        }

        public void ShowData()
        {
            DataList1.DataSource = tbl_grnv.GetAllData();
            DataList1.DataBind();
            DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}