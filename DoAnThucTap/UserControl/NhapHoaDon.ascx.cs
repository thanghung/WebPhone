using BUS_QLHH;
using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAnThucTap
{
    public partial class NhapHoaDon : System.Web.UI.UserControl
    {
        static BUS_HoaDon tbl_hd = new BUS_HoaDon();
        static BUS_ChiTietHoaDon tbl_cthd = new BUS_ChiTietHoaDon();
        static BUS_HangHoa tbl_hh = new BUS_HangHoa();
        static BUS_ChiTietNhapKho tbl_ctnk = new BUS_ChiTietNhapKho();
        static BUS_NhapKho tbl_nk = new BUS_NhapKho();
        static BUS_KhachHang tbl_kh = new BUS_KhachHang();
        static BUS_TheDiem tbl_td = new BUS_TheDiem();

        HoaDon hd = new HoaDon();
        HangHoa hh = new HangHoa();
        List<ChiTietHoaDon> licthd = new List<ChiTietHoaDon>();
        List<HangHoa> lihh = new List<HangHoa>();
        TheDiem td = new TheDiem();
        DataTable dt = new DataTable();

        decimal TongTien = 0, ThanhTien, DiemSo_Cout;
        List<String> li_MaKH = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetItemsHH();
            GetItemsKH();
            if (!IsPostBack)
            {
                if (Page.RouteData.Values["id"] != null)
                    HienThiThongTin();
                else
                {
                    hd.MaHD = CreateKeyHD();
                    Label2.Text = hd.MaHD.ToString().Trim();
                }
            }
        }

        #region Khởi tạo datatable
        private void CreateTable(DataTable dt)
        {
            dt.Columns.Add("STT");
            dt.Columns.Add("TenHang");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonGia");
            dt.Columns.Add("GiamGia");
            dt.Columns.Add("ThanhTien");

        }
        #endregion

        #region Hiển Thị Thông Tin Hóa Đơn
        public void HienThiThongTin()
        {
            string id = Page.RouteData.Values["id"].ToString().Trim();
            hd = tbl_hd.GetbyID(id);
            Label2.Text = hd.MaHD.ToString().Trim();
            ttbNgayBan.Text = hd.NgayBan.Date.ToString();
            ddlKhachHang.SelectedValue = hd.TenKH;


            LbDiemSo.Text = hd.DiemDH.ToString("N0");
            Label1.Text = hd.TongTien.ToString("N0");

            List<ChiTietHoaDon> li_cthd = tbl_cthd.GetListbyID(hd.MaHD);
            CreateTable(dt);
            int stt = 1;
            foreach (ChiTietHoaDon item in li_cthd)
                dt.Rows.Add(stt++, item.TenHang, item.SoLuong, item.DonGia, item.GiamGia, item.ThanhTien);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            LbTenKH.Text = ddlKhachHang.SelectedValue.Trim();
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        #endregion


        #region Lấy giá trị Hàng hóa trong dropdownlist
        private void GetItemsHH()
        {
            List<HangHoa> lihh = tbl_hh.GetAllData();

            ddlTenHang.Items.Clear();
            ddlTenHang.Items.Add("===Chọn Hàng===");
            foreach (HangHoa hh in lihh)
                ddlTenHang.Items.Add(hh.TenHang);
        }

        #endregion

        #region tương tác dữ liệu khách hàng với DropdowList
        #region Đưa giá trị khách hàng vào dropdownlist
        private void GetItemsKH()
        {
            List<KhachHang> lihh = tbl_kh.GetAllData();
            int dem = 1;
            ddlKhachHang.Items.Clear();
            ddlKhachHang.Items.Add("===Chọn Khách Hàng===");
            foreach (KhachHang kh in lihh)
            {
                ddlKhachHang.Items.Add(kh.TenKH);
                li_MaKH.Add(kh.MaKH);
                string s = "=======THÔNG TIN KHÁCH HÀNG=======\n\n" + "Mã Khách Hàng: " + kh.MaKH + "\t " + "Tên Khách Hàng: " + kh.TenKH + "\n" + "SĐT: " + kh.SDT.ToString() + "\t\t\t" + "CMND: " + kh.Email + "\n" + "Địa Chỉ: " + kh.DiaChi;
                ddlKhachHang.Items[dem++].Attributes.Add("Title", s);
            }
        }
        #endregion

        #region Thêm Khách Hàng
        protected void ThemKH_Click(object sender, EventArgs e)
        {
            KhachHang kh_save = new KhachHang();
            //Khai báo đối tượng lấy thông tin nhập vào bảng
            kh_save.MaKH = KhachHangLoad1.CreateKeyKH();
            kh_save.TenKH = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(ttbTenKH.Text.ToLower().Trim());
            kh_save.Email = ttbEmail.Text.Trim();
            kh_save.SDT = ttbSDT.Text;
            kh_save.DiemSo = 0;
            kh_save.DiaChi = ttbDiaChi.Text;

            LuuDiemKH(kh_save);
            //đưa thông tin của bảng vào database và lưu lại
            if (tbl_kh.CheckKey(ttbEmail.Text.Trim(), ttbTenKH.Text.Trim(), ttbSDT.Text.Trim()) == null)
            {
                tbl_kh.Insert(kh_save);
            }
            else
            {
                tbl_kh.Update(kh_save);
            }

            GetItemsKH();

            //reset
            ttbTenKH.Text = "";
            ttbEmail.Text = "";
            ttbSDT.Text = "";
            ttbDiaChi.Text = "";
        }
        #endregion
        #endregion

        #region Hủy Hóa Đơn
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["id"] == null)
                Response.Redirect("/NhapHoaDon/nhd");
            else
            {
                //Xóa dữ liệu hóa đơn
                string id = Page.RouteData.Values["id"].ToString().Trim();
                HoaDon _hd = tbl_hd.GetbyID(id);
                List<ChiTietHoaDon> li_cthd = tbl_cthd.GetListbyID(id);

                //hoàn trả số lượng hàng hóa
                foreach (ChiTietHoaDon _cthd in li_cthd)
                {
                    HangHoa _hh = tbl_hh.GetbyName(_cthd.TenHang);
                    _hh.TonKho += _cthd.SoLuong;
                    tbl_cthd.Delete(_cthd);
                }

                //hoàn trả lại điểm khách hàng
                KhachHang _kh = tbl_kh.GetbyID(_hd.IDKH);
                _kh.DiemSo -= _hd.DiemDH;
                LuuDiemKH(_kh);
                tbl_hd.Delete(_hd);

                WebMsgBox.Show("Hủy Hóa Đơn thành Cônng");
                Response.Redirect("/NhapHoaDon/nhd");
            }
        }

        #endregion

        #region Tạo Hóa Đơn
        protected void btnSudmit_Click(object sender, EventArgs e)
        {
            if (ddlKhachHang.SelectedValue == "===Chọn Khách Hàng===")
                WebMsgBox.Show("Hãy chọn khách hàng");
            else
            {
                Input(licthd);
                WebMsgBox.Show("Tạo hóa đơn thành công");
                Response.Redirect("~/NhapHoaDon/nhd");
            }
        }

        #region input Hóa Đơn
        private void Input(List<ChiTietHoaDon> licthd)
        {
            KhachHang kh = tbl_kh.GetbyID(li_MaKH[ddlKhachHang.SelectedIndex - 1]);
            //Lưu điểm KH
            kh.DiemSo = decimal.Parse(LbDiemSo.Text);
            tbl_kh.Update(kh);
            //Lưu Điểm KH
            LuuDiemKH(kh);

            //Nhập dữ liệu Hóa đơn
            hd.MaHD = Label2.Text.Trim();
            hd.NgayBan = DateTime.Parse(ttbNgayBan.Text);
            hd.IDKH = kh.MaKH;
            hd.TenKH = ddlKhachHang.SelectedValue;
            hd.TongTien = decimal.Parse(Label1.Text);
            hd.DiemDH = (int)kh.DiemSo;
            hd.NgayTao = DateTime.Now;
            hd.IDNVT = Login._nv.MaNV;
            hd.NguoiTao = Login._nv.TenNV;

            //Nhập dữ liệu chi tiết hóa đơn
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                HangHoa hh = tbl_hh.GetbyName(GridView1.Rows[i].Cells[1].Text.Trim());
                ChiTietNhapKho ctnk = new ChiTietNhapKho();
                ChiTietHoaDon cthd = new ChiTietHoaDon();

                Lay_ThongTinNhapKho(ctnk, hh);
                cthd.MaCTHD = CreateKeyCTHD();
                cthd.MaHD = hd.MaHD;
                cthd.TenHang = hh.TenHang;
                cthd.SoLuong = Int32.Parse(GridView1.Rows[i].Cells[2].Text);
                hh.TonKho = hh.TonKho - cthd.SoLuong;
                cthd.DonGia = hh.GiaBan;
                cthd.GiamGia = ctnk.GiamGia;
                cthd.ThanhTien = decimal.Parse(GridView1.Rows[i].Cells[5].Text.Trim());

                lihh.Add(hh);
                licthd.Add(cthd);
            }

            //Cạp nhật hàng, hóa đơn
            foreach (HangHoa item in lihh)
                tbl_hh.Update(item);
            foreach (ChiTietHoaDon item in licthd)
                tbl_cthd.Insert(item);
            tbl_hd.Insert(hd);

        }

        #endregion
        #endregion

        //Chọn Hàng để hiện trị trong form nhập
        protected void Select_Onclick(object sender, EventArgs e)
        {
            hh = tbl_hh.GetbyName(ddlTenHang.SelectedValue);
            ShowHangHoa(hh);
        }

        #region Lấy thông tin hàng từ bảng nhập kho
        public ChiTietNhapKho Lay_ThongTinNhapKho(ChiTietNhapKho ctnk, HangHoa hh)
        {
            List<ChiTietNhapKho> lictnk = tbl_ctnk.GetListByName(hh.TenHang);
            List<NhapKho> link = new List<NhapKho>();

            foreach (ChiTietNhapKho item in lictnk)
            {
                NhapKho nk = tbl_nk.GetbyID(item.MaNK);
                link.Add(nk);
            }

            DateTime _day = DateTime.Now;
            long min = 100000;
            foreach (NhapKho item in link)
            {
                long temp = _day.Ticks - item.NgayNhapKho.Ticks;
                if (temp < min)
                {
                    min = temp;
                    ctnk = tbl_ctnk.GetbyID(item.MaNK);
                }
            }

            return ctnk;
        }
        #endregion

        #region Lưu điểm KH
        public void LuuDiemKH(KhachHang kh)
        {
            td = tbl_td.GetbyIDKH(kh.MaKH);
            bool flag = false;

            if (td != null)
            {
                td.DiemThe = kh.DiemSo;
                td.TenNV = Login._nv.TenNV;
                flag = true;
            }
            else
            {
                td = new TheDiem();
                td.ID = KhachHangLoad1.CreateKeyTD();
                td.DiemThe = kh.DiemSo;
                td.IDNV = Login._nv.MaNV;
                td.TenNV = Login._nv.TenNV;
                td.TenKH = kh.TenKH;
                td.IDKH = kh.MaKH;
            }

            if (kh.DiemSo > 3000 && kh.DiemSo < 5000)
            {
                td.TenTD = "Vàng";
            }
            else
                if (kh.DiemSo > 5000)
            {
                td.TenTD = "Bạch Kim";
            }
            else
            {
                td.TenTD = "Thường";
            }

            if (flag)
                tbl_td.Update(td);
            else
                tbl_td.Insert(td);
        }

        #endregion

        #region Tính Toán Tiền Hàng
        public void ShowHangHoa(HangHoa hh)
        {
            ChiTietNhapKho ctnk = HangHoaLoad.LayThongTinNhapKho(hh);

            ttbDonGia.Text = hh.GiaBan.ToString();
            ttbGiamGia.Text = ctnk.GiamGia.ToString();
        }

        public void TinhTien()
        {
            if (decimal.Parse(ttbSoLuong.Text) > hh.TonKho)
                WebMsgBox.Show("Số lượng hàng trong kho chỉ còn " + hh.TonKho.ToString() + " Số lượng mua phải ít hơn số lượng còn trong kho");
            else
            {
                TongTien = decimal.Parse(Label1.Text);
                decimal soluong = Convert.ToDecimal(ttbSoLuong.Text), dongia = decimal.Parse(ttbDonGia.Text), giamgia = decimal.Parse(ttbGiamGia.Text);
                ThanhTien = (soluong * dongia) - (giamgia * soluong);
                TongTien += ThanhTien;
                DiemSo_Cout = (TongTien * 0.1M);
                DiemSo_Cout = Math.Round(DiemSo_Cout, 0);
                LbDiemSo.Text = DiemSo_Cout.ToString("N0");
                Math.Round(Convert.ToDecimal(TongTien), 0);
                Label1.Text = TongTien.ToString("N0");
            }
        }

        #endregion

        #region tương tác dữ liệu với GridView

        #region Thêm danh sách hàng hóa bằng gridview

        public void AddItem()
        {
            CreateTable(dt);
            for (int row = 0; row < GridView1.Rows.Count; row++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = GridView1.Rows[row].Cells[0].Text;
                dr[1] = GridView1.Rows[row].Cells[1].Text;
                dr[2] = GridView1.Rows[row].Cells[2].Text;
                dr[3] = GridView1.Rows[row].Cells[3].Text;
                dr[4] = GridView1.Rows[row].Cells[4].Text;
                dr[5] = GridView1.Rows[row].Cells[5].Text;
                dt.Rows.Add(dr);
            }

            dt.Rows.Add(dt.Rows.Count + 1, ddlTenHang.SelectedValue, ttbSoLuong.Text, ttbDonGia.Text, ttbGiamGia.Text, ThanhTien);
            ViewState["dt"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        #endregion

        #region Thêm hàng hiển thị vào bảng
        protected void ThemHang_Click(object sender, EventArgs e)
        {
            TinhTien();
            AddItem();
            //Reset Value
            ddlTenHang.ClearSelection();
            ttbSoLuong.Text = "";
            ttbDonGia.Text = "";
            ttbGiamGia.Text = "";
        }
        #endregion

        #region Xóa Hàng
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable table = (DataTable)ViewState["dt"];
            DataTable temp = new DataTable();
            CreateTable(temp);

            int indext = e.RowIndex;
            TongTien = decimal.Parse(Label1.Text.Trim());
            TongTien -= decimal.Parse(GridView1.Rows[indext].Cells[5].Text.Trim());
            Label1.Text = TongTien.ToString();
            LbDiemSo.Text = (TongTien * 0.1M).ToString("N0");
            table.Rows[indext].Delete();

            for (int row = 0; row < table.Rows.Count; row++)
            {
                DataRow dt_row = table.Rows[row];
                temp.Rows.Add(row + 1, dt_row[1], dt_row[2], dt_row[3], dt_row[4], dt_row[5]);
            }

            ViewState["dt"] = temp;
            GridView1.DataSource = temp;
            GridView1.DataBind();

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        #endregion

        #endregion

        #region Tạo Khóa Chính Hóa Đơn
        private string CreateKeyHD()
        {
            string Key = RandomKeyHD();
            while (tbl_hd.GetbyID(Key) != null)
            {
                Key = RandomKeyHD();
            }

            return Key;
        }

        private string RandomKeyHD()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "HD0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "HD000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "HD00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "HD0" + number.ToString();
            else
                Key = "HD" + number.ToString();

            return Key;
        }

        #endregion

        #region Tạo Khóa Chính Chi Tiết Hóa Đơn
        private string CreateKeyCTHD()
        {
            string Key = RandomKeyCTHD();
            while (tbl_cthd.GetbyID(Key) != null)
            {
                Key = RandomKeyCTHD();
            }

            return Key;
        }

        public static string RandomKeyCTHD()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "CTHD0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "CTHD000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "CTHD00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "CTHD0" + number.ToString();
            else
                Key = "CTHD" + number.ToString();

            return Key;
        }
        #endregion

        protected void ddlKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbTenKH.Text = ddlKhachHang.SelectedValue.Trim();
        }
    }
}