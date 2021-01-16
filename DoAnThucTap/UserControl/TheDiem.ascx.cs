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
    public partial class TheDiem1 : System.Web.UI.UserControl
    {
        static BUS_TheDiem tbl_td = new BUS_TheDiem();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowDuLieu();  
        }

        public void ShowDuLieu()
        {
            DataList1.DataSource = tbl_td.GetAllData();
            DataList1.DataBind();
            DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }
}