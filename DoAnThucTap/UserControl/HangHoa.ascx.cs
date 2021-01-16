using BUS_QLHH;
using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class HangHoaLoad : System.Web.UI.UserControl
    {
        static BUS_HangHoa tbl_hh = new BUS_HangHoa();
        static BUS_GRHangHoa tbl_grhh = new BUS_GRHangHoa();
        static BUS_NhaCungCap tbl_ncc = new BUS_NhaCungCap();
        static BUS_NhanVien tbl_nv = new BUS_NhanVien();
        static BUS_NhapKho tbl_nk = new BUS_NhapKho();
        static BUS_ChiTietNhapKho tbl_ctnk = new BUS_ChiTietNhapKho();

        NhapKho nk = new NhapKho();
        ChiTietNhapKho ctnk = new ChiTietNhapKho();

        public static int SoLuong;
        decimal SoLuongDau, SoLuongCuoi, SoLuongLuuTam;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetItemsDropdownlist();
            ShowData();
            if (!IsPostBack)
            {
                HienThiFormInputHang();
            }
        }

        public void ShowData()
        {
            //Thông tin Nhân Viên
            if (Login._nv.ChucVu != "KT")
            {
                Button1.Visible = false;
                ttbSoLuongMax.Enabled = false;
            }
            else
            {
                Button1.Visible = true;
                ttbSoLuongMax.Enabled = true;
            }

            ttbLoiNhuan.Text = Login._nv.LoiNhuan.ToString();
            ttbSoLuongMax.Text = tbl_nv.LayDuLieu1NV().SoLuong.ToString();

            tableHang.DataSource = tbl_hh.GetAllData();
            tableHang.DataBind();
            tableHang.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void GetItemsDropdownlist()
        {
            //Tạo 3 danh sách lưu dữ liệu 3 bảng
            List<GroupHangHoa> ligr = tbl_grhh.GetAllData();
            List<NhaCungCap> lincc = tbl_ncc.GetAllData();

            //Lấy giá trị MaGRHang của Bảng Group Hàng Hóa
            ddlMaNCC.Items.Clear();
            ddlMaGRHang.Items.Clear();

            foreach (GroupHangHoa gr in ligr)
                ddlMaGRHang.Items.Add(gr.TenGroupHang);

            //Lấy giá trị Mã Nhà Cung Cấp từ Bảng Nhà Cung Cấp
            foreach (NhaCungCap ncc in lincc)
                ddlMaNCC.Items.Add(ncc.TenNCC);

            ddlMaNCC.DataBind();
            ddlMaGRHang.DataBind();
        }

        public void HienThiFormInputHang()
        {
            if (Page.RouteData.Values["id"] != null)
            {
                //ẩn hiện buttun
                btnSudmit.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = true;

                //hien thi form hang hoa
                string id = Page.RouteData.Values["id"].ToString().Trim();
                HangHoa hh = tbl_hh.GetbyID(id);

                ttbTenHang.Text = hh.TenHang;
                ttbSoLuong.Text = hh.TonKho.ToString();
                if (hh.Anh.Trim() != "")
                {
                    output.Src = hh.Anh;
                }
                ttbGhiChu.Text = hh.GhiChu;

                ddlMaGRHang.ClearSelection();
                ddlMaGRHang.Items.FindByValue(hh.TenGRH.ToString().Trim()).Selected = true;
                ddlMaNCC.ClearSelection();
                ddlMaNCC.Items.FindByValue(hh.TenNCC.ToString().Trim()).Selected = true;

                //hien thi form chi tiet nhap kho
                ctnk = LayThongTinNhapKho(hh);
                nk = tbl_nk.GetbyID(ctnk.MaNK);
                ttbGiaNhap.Text = ctnk.GiaNhap.ToString();
                ttbGiamGia.Text = ctnk.GiamGia.ToString();
                ttbNgayNhap.Text = nk.NgayNhapKho.ToString("dd/MM/yyyy");
            }
            else
            {
                //Ẩn hiện button
                btnSudmit.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = false;

            }
        }

        private void InputNhapKho(NhapKho nk, ChiTietNhapKho ctnk)
        {
            //Nhập dữ liệu bảng nhập kho
            nk.MaNK = CreateKeyNK();
            nk.NgayNhapKho = DateTime.Parse(ttbNgayNhap.Text.Trim()).Date;
            nk.NgayTao = DateTime.Now;
            nk.NguoiTao = Login._nv.TenNV;
            nk.IDNVT = Login._nv.MaNV;
            tbl_nk.Insert(nk);

            //Nhập dữ liệu bảng chi tiết nhập kho
            ctnk.MaNK = nk.MaNK;
            ctnk.TenHH = ttbTenHang.Text.Trim();
            ctnk.TenNCC = ddlMaNCC.SelectedValue.Trim();
            ctnk.SoLuong = decimal.Parse(ttbSoLuong.Text.Trim());
            ctnk.GiaNhap = decimal.Parse(ttbGiaNhap.Text.Trim());
            ctnk.GiamGia = decimal.Parse(ttbGiamGia.Text.Trim());

            tbl_ctnk.Insert(ctnk);
        }

        public void InputHangHoa(HangHoa hh)
        {
            if (ttbTenHang.Text.Trim() != "" && ttbSoLuong.Text.Trim() != "")
            {
                //input Nhân Viên
                Login._nv.LoiNhuan = Int32.Parse(ttbLoiNhuan.Text);
                tbl_nv.Update(Login._nv);

                //input hàng hóa
                hh.MaHang = CreateKeyHH();
                hh.TenHang = ttbTenHang.Text.Trim();
                hh.TonKho = decimal.Parse(ttbSoLuong.Text.Trim()); ;

                hh.NgayNhap = nk.NgayNhapKho;
                GroupHangHoa gr = tbl_grhh.GetbyName(ddlMaGRHang.Text); ;
                hh.TenGRH = gr.TenGroupHang;
                hh.TenNCC = ddlMaNCC.SelectedValue.Trim();
                hh.IDNV = Login._nv.MaNV;
                hh.TenNV = Login._nv.TenNV;
                hh.luu = false;
                hh.GhiChu = ttbGhiChu.Text.Trim();
                LuuAnh(hh);

                TinhGiaHH(hh);
                //đưa thông tin của bảng vào database và lưu lại
                tbl_hh.Insert(hh);

                WebMsgBox.Show("Đã nhập xong");
                Response.Redirect("/QuanLyHangHoa/hh");
            }
            else
                WebMsgBox.Show("Hãy nhập đầy đủ thông tin Hàng Hóa");
        }

        public void TinhGiaHH(HangHoa hh)
        {
            List<NhanVien> linv = tbl_nv.GetAllData();

            decimal _giaBan, _giaNhap;
            //số lượng nhân viên
            decimal sumnv = linv.Count;

            //Lấy giá trị giá nhập
            _giaNhap = ctnk.GiaNhap;
            decimal thue = ((decimal)10 / 100), loinhuan = (decimal.Parse(Login._nv.LoiNhuan.ToString()) / 100), tong = (sumnv * ((decimal)1.2 / 100));
            //tính giá bán  
            _giaBan = _giaNhap * thue + _giaNhap * loinhuan + _giaNhap * tong;
            hh.GiaBan = _giaBan;
        }

        private void UpdateNhapKho(NhapKho nk, ChiTietNhapKho ctnk)
        {
            //cập nhật bảng nhập kho
            nk.NgayCapNhat = DateTime.Now;
            nk.NguoiCapNhat = Login._nv.TenNV;
            nk.IDNVCN = Login._nv.MaNV;
            tbl_nk.Update(nk);

            //cập nhật bảng chi tiết nhập kho
            ctnk.TenHH = ttbTenHang.Text.Trim();
            ctnk.TenNCC = ddlMaNCC.SelectedValue.Trim();
            ctnk.GiaNhap = decimal.Parse(ttbGiaNhap.Text);
            ctnk.GiamGia = decimal.Parse(ttbGiamGia.Text);
            ctnk.SoLuong += SoLuongLuuTam;

            tbl_ctnk.Update(ctnk);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string mahh = Page.RouteData.Values["id"].ToString().Trim();
            HangHoa hh = tbl_hh.GetbyID(mahh);

            if (Int32.Parse(ttbSoLuong.Text) > Login._nv.SoLuong)
                WebMsgBox.Show("Số lượng mặt hàng vượt mức cho phép. Hãy nhập lại");
            else
            {
                //Cập nhật nhân viên
                Login._nv.LoiNhuan = Int32.Parse(ttbLoiNhuan.Text.Trim());
                tbl_nv.Update(Login._nv);

                //Cập nhật bảng nhập kho và chi tiết nhập kho
                ctnk = LayThongTinNhapKho(hh);
                nk = tbl_nk.GetbyID(ctnk.MaNK);
                UpdateNhapKho(nk, ctnk);

                SoLuongDau = hh.TonKho;
                //Cập nhật hàng hóa
                hh.TenHang = ttbTenHang.Text;
                hh.TonKho = decimal.Parse(ttbSoLuong.Text);
                SoLuongCuoi = hh.TonKho;
                hh.GhiChu = ttbGhiChu.Text;
                LuuAnh(hh);

                NhaCungCap ncc = tbl_ncc.GetbyName(ddlMaNCC.SelectedValue);
                GroupHangHoa grhh = tbl_grhh.GetbyName(ddlMaGRHang.SelectedValue);
                hh.TenGRH = grhh.TenGroupHang;
                hh.TenNCC = ncc.TenNCC;
                hh.IDNV = Login._nv.MaNV;
                hh.TenNV = Login._nv.TenNV;
                TinhGiaHH(hh);
                tbl_hh.Update(hh);

                //Tính toán cập nhật lại số lượng hàng
                SoLuongLuuTam = SoLuongCuoi - SoLuongDau;

                WebMsgBox.Show("Cập nhật hàng hóa thành công");
                Response.Redirect("/QuanLyHangHoa/hh");
            }
        }

        public static ChiTietNhapKho LayThongTinNhapKho(HangHoa hh)
        {
            List<ChiTietNhapKho> lictnk = tbl_ctnk.GetListByName(hh.TenHang.Trim());
            List<NhapKho> link = new List<NhapKho>();
            NhapKho nk_Luu = new NhapKho();

            //Lấy thông tin bảng nhập kho từ bảng chi tiết nhập kho đê tính toán
            foreach (ChiTietNhapKho items in lictnk)
                link.Add(tbl_nk.GetbyID(items.MaNK));

            //Bắt đầu tính toán để lấy ra dữ liệu nhập nko gần đây nhất
            DateTime dau = DateTime.Now, cuoi;
            TimeSpan time, min = TimeSpan.MaxValue;
            foreach (NhapKho items in link)
            {
                cuoi = items.NgayNhapKho;
                time = dau - cuoi;

                if (time <= min)
                {
                    nk_Luu = items;
                    min = time;
                }
            }

            return tbl_ctnk.GetbyID(nk_Luu.MaNK);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string mahh = Page.RouteData.Values["id"].ToString().Trim();
            HangHoa hh = tbl_hh.GetbyID(mahh);

            hh.luu = !hh.luu;
            tbl_hh.Update(hh);
            WebMsgBox.Show("Lưu hàng hóa thành công");
            Response.Redirect("/QuanLyHangHoa/hh");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string mahh = Page.RouteData.Values["id"].ToString().Trim();
            HangHoa hh = tbl_hh.GetbyID(mahh);

            //Xóa thông tin nhập
            List<ChiTietNhapKho> li_ctnk = tbl_ctnk.GetListByName(hh.TenHang);
            foreach (ChiTietNhapKho ctnk in li_ctnk)
            {
                NhapKho nk = tbl_nk.GetbyID(ctnk.MaNK);
                tbl_nk.Delete(nk);
                tbl_ctnk.Delete(ctnk);
            }

            XoaAnh(hh);
            tbl_hh.Delete(hh);

            WebMsgBox.Show("Xóa hàng hóa thành công");
            Response.Redirect("/QuanLyHangHoa/hh");
        }

        protected void btnSudmit_Click(object sender, EventArgs e)
        {
            HangHoa hh = new HangHoa();
            InputNhapKho(nk, ctnk);
            InputHangHoa(hh);

            WebMsgBox.Show("Thêm hàng hóa thành công");
        }

        //Cài đặt số lượng tồn kho cho phép
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ttbSoLuongMax.Text.Trim() != "")
            {
                List<NhanVien> li_nv = tbl_nv.LayNVKT();
                int SoLuong = Int32.Parse(ttbSoLuongMax.Text);

                foreach (NhanVien nv in li_nv)
                {
                    nv.SoLuong = SoLuong;
                    tbl_nv.Update(nv);
                }

                WebMsgBox.Show("Thay Đổi thành công");
            }
        }

        #region Lưu và xóa File Ảnh
        //Lưu Ảnh
        protected void LuuAnh(HangHoa hh)
        {
            String ten = FileUpload1.FileName;

            if (hh.Anh == null)
            {
                //Thực hiện chép tập tin lên thư mục Upload
                FileUpload1.SaveAs(Server.MapPath("~/Images/") + ten);
                hh.Anh = "~/Images/" + ten;
            }
            else
            {
                if (hh.Anh.Contains(ten.Trim()) == false)
                {
                    XoaAnh(hh);
                    //Thực hiện chép tập tin lên thư mục Upload
                    FileUpload1.SaveAs(Server.MapPath("~/Images/") + ten);
                    hh.Anh = "~/Images/" + ten;
                }
            }
        }

        //Xóa Ảnh
        protected void XoaAnh(HangHoa hh)
        {
            if (hh.Anh != null)
            {
                String ten = Server.MapPath(hh.Anh);

                if (System.IO.File.Exists(ten))
                    System.IO.File.Delete(ten);

                hh.Anh = "";
            }
        }

        #endregion

        #region Tạo Khóa Chính Hàng Hóa
        private string CreateKeyHH()
        {
            string Key = RanDomKeyHH();
            while (tbl_hh.GetbyID(Key) != null)
            {
                Key = RanDomKeyHH();
            }

            return Key;
        }

        private string RanDomKeyHH()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "HH0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "HH000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "HH00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "HH0" + number.ToString();
            else
                Key = "HH" + number.ToString();

            return Key;
        }
        #endregion

        #region Tạo Khóa Chính Thông Tin Nhập Kho
        private string CreateKeyNK()
        {
            string Key = RandomKeyNK();
            while (tbl_nk.GetbyID(Key) != null)
            {
                Key = RandomKeyNK();
            }

            return Key;
        }

        private string RandomKeyNK()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "NK0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "NK000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "NK00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "NK0" + number.ToString();
            else
                Key = "NK" + number.ToString();

            return Key;
        }
        #endregion
    }
}