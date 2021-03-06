﻿using BUS_QLHH;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class MainChinh : System.Web.UI.UserControl
    {
        BUS_HangHoa tbl_hh = new BUS_HangHoa();
        int CurrentPage, count;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["ID"] != null)
            {
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(LoadControl("/PageShow/Formitems.ascx"));
            }
            if (!IsPostBack)
            {
                ViewState["vs"] = 0;
            }

            CurrentPage = (int)ViewState["vs"];
            DatalistPaging();
        }

        public void DatalistPaging()
        {
            PagedDataSource PD = new PagedDataSource();
            PD.DataSource = tbl_hh.GetAllData();

            PD.PageSize = 6;
            PD.AllowPaging = true;
            PD.CurrentPageIndex = CurrentPage;
            count = PD.PageCount;

            if (PD.PageCount > 1)
            {
                Repeater1.Visible = true;
                System.Collections.ArrayList pages = new System.Collections.ArrayList();
                for (int i = 0; i < PD.PageCount; i++)
                    pages.Add((i + 1).ToString());

                Repeater1.DataSource = pages;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
            }

            DataList1.DataSource = PD;
            DataList1.DataBind();
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            string Url;
            Url = "/ThongTinSanPham/" + e.CommandArgument.ToString().Trim();
            Response.Redirect(Url);
        }

       
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CurrentPage = (int)ViewState["vs"];
            CurrentPage = Convert.ToInt32(e.CommandArgument) - 1;
            ViewState["vs"] = CurrentPage;
            DatalistPaging();
        }

        public static string ChangeSalaryType(decimal number)
        {
            return number.ToString("N0");
        }
    }
}