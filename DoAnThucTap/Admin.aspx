<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="DoAnThucTap.Admin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Css/cssAdmin.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="left">
            <div class="head">
                Quản Lý
            </div>
            <div id="menu">
                <ul>
                    <li><i class="fas fa-users"></i><a href="#">Khách Hàng</a>
                        <ul class="sub-menu">
                            <li><i class="fas fa-user-edit"></i><a href="/QuanLyKhachHang/kh">Quản lí Khách Hàng</a></li>
                            <li><i class="fas fa-user-shield"></i><a href="/QuanLyTheDiem/td">Thẻ Điểm Khách Hàng</a></li>
                        </ul>
                    </li>
                    <li><i class="fas fa-box"></i><a href="#">Hàng Hóa</a>
                        <ul class="sub-menu">
                            <li><i class="fas fa-address-card"></i><a href="/QuanLyNhaCungCap/ncc">Quản Lý Nhà Cung Cấp</a></li>
                            <li><i class="fas fa-boxes"></i><a href="/QuanLyNhomHangHoa/grhh">Quản Lý Nhóm Hàng Hóa</a></li>
                            <li><i class="fas fa-box"></i><a href="/QuanLyHangHoa/hh">Quản Lý Hàng Hóa</a></li>
                        </ul>
                    </li>
                    <li><i class="fas fa-warehouse"></i><a href="#">Quản Lý Kho</a>
                        <ul class="sub-menu">
                            <li><i class="fas fa-warehouse"></i><a href="/QuanLyNhapKho/bnk">Quản Lý Nhập Kho</a></li>
                            <li><i class="fas fa-warehouse"></i><a href="/QuanLyChiTietNhapKho/ctnk">Chi Tiếp Nhập Kho</a></li>
                        </ul>
                    </li>
                    <li><i class="far fa-clipboard"></i><a href="#">Hóa Đơn</a>
                        <ul class="sub-menu">
                            <li><i class="far fa-clipboard"></i><a href="/NhapHoaDon/nhd">Nhập Hóa Đơn</a></li>
                            <li><i class="fas fa-clipboard-check"></i><a href="/QuanLyHoaDon/hd">quản Lý Hóa Đơn</a></li>
                            <li><i class="fas fa-clipboard-list"></i><a href="/QuanLyChiTietHoaDon/cthd">Chi Tiết Hóa Đơn</a></li>
                        </ul>
                    </li>
                    <li><i class="fas fa-users-cog"></i><a href="#">Nhân Viên</a>
                        <ul class="sub-menu">
                            <li><i class="fas fa-user-cog"></i><a href="/QuanLyNhanVien/nv">Quản Lý Nhân Viên</a></li>
                            <li><i class="fas fa-users-cog"></i><a href="/QuanLyTaiKhoanNhanVien/grnv">Quản Lý Tài Khoản Nhân Viên</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>

        <div class="right">
            <center><asp:Image ID="ImgNen" runat="server" ImageUrl="Images/Nen.jpg"/></center>
            <asp:PlaceHolder ID="PlQuanLy" runat="server"></asp:PlaceHolder>
        </div>

        <div class="cb">
        </div>
    </div>
</asp:Content>
