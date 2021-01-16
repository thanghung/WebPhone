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
    public partial class indext1 : System.Web.UI.Page
    {
        string modul;
        static BUS_HangHoa tbl_hh = new BUS_HangHoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["modul"] != null)
            {
                modul = Page.RouteData.Values["modul"].ToString().Trim();

                if (modul == "Profile")
                    PlaceHolder1.Controls.Add(LoadControl("/PageShow/Profile.ascx"));
                else
                    PlaceHolder1.Controls.Add(LoadControl("/PageShow/GroupItems.ascx"));
            }
            else
            {
                PlaceHolder1.Controls.Add(LoadControl("PageShow/MainChinh.ascx"));
            }
        }

        public static List<string> GetItem(string Name)
        {
            List<HangHoa> li_hh = tbl_hh.Search(Name);

            List<string> li_Ten = new List<string>();
            foreach (HangHoa hh in li_hh)
                li_Ten.Add(hh.TenHang);

            return li_Ten;
        }
    }
}