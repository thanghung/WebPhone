using BUS_QLHH;
using DTO_QLHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace DoAnThucTap
{
    public partial class NhanVien1 : System.Web.UI.UserControl
    {
        static BUS_NhanVien tbl_nv = new BUS_NhanVien();
        static BUS_UserGroup tbl_usergr = new BUS_UserGroup();
        static BUS_HangHoa tbl_hh = new BUS_HangHoa();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();
            if (!IsPostBack)
            {
                HienThiFormInput();
            }
        }

        public void ShowData()
        {
            DataList1.DataSource = tbl_nv.GetAllData();
            DataList1.DataBind();
            DataList1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void HienThiFormInput()
        {
            if (Page.RouteData.Values["id"] != null)
            {
                //ẩn hiện buttun
                btnSudmit.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                //Hiển thị
                string id = Page.RouteData.Values["id"].ToString().Trim();
                NhanVien nv = tbl_nv.GetbyID(id);
                UserGroup user = tbl_usergr.GetbyID(nv.UserTK);
                ttbUserID.Text = user.UserTK;
                ttbUserName.Text = user.UserName;
                ttbTenNV.Text = nv.TenNV;
                ttbChucVu.Text = nv.ChucVu;
                ttbMatKhau.Text = nv.MatKhau;
                if (nv.GioiTinh == true)
                {
                    rblGioiTinh.Items[0].Selected = true;
                    rblGioiTinh.Items[1].Selected = false;
                }
                else
                    if (nv.GioiTinh == false)
                {
                    rblGioiTinh.Items[1].Selected = true;
                    rblGioiTinh.Items[0].Selected = false;
                }
                else
                {
                    rblGioiTinh.Items[0].Selected = false;
                    rblGioiTinh.Items[1].Selected = false;
                }

                ttbDiaChi.Text = nv.Diachi;
                ttbSDT.Text = nv.DienThoai;
                ttbNgaySinh.Text = nv.NgaySinh.ToString();
                ttbTrangThai.Text = nv.TrangThai;

            }
            else
            {
                //enable button
                btnSudmit.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }    
        }

        public bool KTUserID()
        {
            UserGroup user = tbl_usergr.GetbyID(ttbUserID.Text);

            if (user != null)
                return true;
            return false;
        }

        protected void btnSudmit_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            UserGroup userGR = new UserGroup();
            InputNhanVien(nv, userGR);

            List<HangHoa> lihh = tbl_hh.GetbyIDNV(Login._nv.MaNV);
            HangHoaLoad hhl = new HangHoaLoad();

            foreach (HangHoa hh in lihh)
            {
                hhl.TinhGiaHH(hh);
                tbl_hh.Update(hh);
            }

            WebMsgBox.Show("Thêm nhân viên thành công");
        }

        public void InputNhanVien(NhanVien nv, UserGroup userGR)
        {
            if (ttbUserID.Text.Trim() != "" && ttbUserName.Text.Trim() != "" && ttbTenNV.Text.Trim() != "" && ttbSDT.Text.Trim() != "" && ttbChucVu.Text.Trim() != "" && ttbDiaChi.Text.Trim() != "" && ttbMatKhau.Text.Trim() != "" && ttbNgaySinh.Text.Trim() != "" && ttbTrangThai.Text.Trim() != "" && (rblGioiTinh.Items[0].Selected == false || rblGioiTinh.Items[1].Selected == false))
            {
                //NVai báo đối tượng lấy thông tin nhập vào bảng Nhân Viên
                //Kiểm tra xem UserID đã tồn tại hay chưa
                if (!KTUserID())
                {
                    WebMsgBox.Show("Nhập Thành Công");
                    nv.UserTK = ttbUserID.Text;
                    nv.MaNV = CreateKeyNV();
                    nv.TenNV = ttbTenNV.Text;
                    nv.ChucVu = ttbChucVu.Text;
                    nv.MatKhau = ttbMatKhau.Text;
                    if (rblGioiTinh.Items[0].Selected)
                        nv.GioiTinh = true;
                    else
                        nv.GioiTinh = false;

                    nv.Diachi = ttbDiaChi.Text;
                    nv.DienThoai = ttbSDT.Text;
                    nv.NgaySinh = DateTime.Parse(ttbNgaySinh.Text);
                    nv.TrangThai = ttbTrangThai.Text;
                    nv.SoLuong = HangHoaLoad.SoLuong;
                    nv.LoiNhuan = 30;

                    //NVai báo đối tượng lấy thông tin nhập vào bảng UserGroup
                    userGR.UserTK = ttbUserID.Text;
                    userGR.UserName = ttbUserName.Text;

                    //lưu vào database
                    tbl_usergr.Insert(userGR);
                    tbl_nv.Insert(nv);

                    Response.Redirect("/QuanLyNhanVien/nv");
                }
                else
                {
                    WebMsgBox.Show("User ID đã tồn tại. Hãy nhập UserID NVác");
                }
            }
            else
                WebMsgBox.Show("Hãy nhập đầy đủ thông tin Nhân Viên");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string manv = Page.RouteData.Values["id"].ToString().Trim();
            NhanVien nv = tbl_nv.GetbyID(manv);

            if (nv.MaNV == Login._nv.MaNV)
                WebMsgBox.Show("Tài NVoản nhân viên này đang đăng nhập hệ thống. Nếu muốn xóa nhân viên này thì bạn hãy đăng nhập hệ thông với tài NVoản NVác");
            else
            {
                UserGroup userGroup = tbl_usergr.GetbyID(nv.UserTK);
                List<HangHoa> lihh = tbl_hh.GetbyIDNV(Login._nv.MaNV);
                tbl_nv.Delete(nv);
                tbl_usergr.Delete(userGroup);
                //Tính lại giá bán sản phẩm
                HangHoaLoad hhl = new HangHoaLoad();

                foreach (HangHoa hh in lihh)
                {
                    hhl.TinhGiaHH(hh);
                    tbl_hh.Update(hh);
                }

                WebMsgBox.Show("Xóa nhân viên thành công");
                Response.Redirect("/QuanLyNhanVien/nv");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ttbUserID.Text.Trim() != "" && ttbUserName.Text.Trim() != "" && ttbSDT.Text.Trim() != "" && ttbChucVu.Text.Trim() != "" && ttbDiaChi.Text.Trim() != "" && ttbMatKhau.Text.Trim() != "" && ttbTrangThai.Text.Trim() != "" && (rblGioiTinh.Items[0].Selected == false || rblGioiTinh.Items[1].Selected == false))
            {
                string manv = Page.RouteData.Values["id"].ToString().Trim();
                NhanVien nv = tbl_nv.GetbyID(manv);
                UserGroup _user = tbl_usergr.GetbyID(nv.UserTK);
                nv.UserTK = ttbUserID.Text;
                _user.UserTK = nv.UserTK;
                _user.UserName = ttbUserName.Text;
                nv.TenNV = ttbTenNV.Text;
                nv.ChucVu = ttbChucVu.Text;
                nv.MatKhau = ttbMatKhau.Text;
                if (rblGioiTinh.Items[0].Selected)
                    nv.GioiTinh = true;
                else
                    nv.GioiTinh = false;
                nv.Diachi = ttbDiaChi.Text;
                nv.DienThoai = ttbSDT.Text;
                nv.NgaySinh = DateTime.Parse(ttbNgaySinh.Text);
                nv.TrangThai = ttbTrangThai.Text;

                tbl_nv.Update(nv);
                tbl_usergr.Update(_user);
                WebMsgBox.Show("Cập nhật nhân viên thành công");
                Response.Redirect("/QuanLyNhanVien/nv");
            }
            else
                WebMsgBox.Show("Hãy nhập đầy đủ thông tin Nhân Viên");
        }

        #region Tạo Khóa Chính Nhân Viên
        private string CreateKeyNV()
        {
            string Key = RanDomKeyNV();
            while (tbl_nv.GetbyID(Key) != null)
            {
                Key = RanDomKeyNV();
            }

            return Key;
        }

        private string RanDomKeyNV()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "NV0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "NV000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "NV00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "NV0" + number.ToString();
            else
                Key = "NV" + number.ToString();

            return Key;
        }
        #endregion
    }
}