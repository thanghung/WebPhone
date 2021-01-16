<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Profile.ascx.cs" Inherits="DoAnThucTap.Profile" %>

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<link href="Css/cssAdmin.css" rel="stylesheet" />

<div style="margin: 10px 10px;">
    <table class="table table-responsive">
        <tr>
            <td>Tên KH</td>
            <td>
                <asp:TextBox ID="ttbTenKH" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Hãy Nhập tên khách hàng" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbTenKH"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="ttbEmail" runat="server" CssClass="input" MaxLength="30" autocomplete="off" Enabled="false"></asp:TextBox>
                &emsp;<asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail1" runat="server" ErrorMessage="Email Không hợp lệ" ForeColor="Red" ControlToValidate="ttbEmail" ValidationGroup="Check" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </tr>
        <tr>
            <td>SĐT</td>
            <td>
                <asp:TextBox ID="ttbSDT" runat="server" CssClass="input" MaxLength="10" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="số điện thoại không hợp lệ" ForeColor="Red" ControlToValidate="ttbSDT" ValidationGroup="Check" ValidationExpression="(09|03|07|08|05)+([0-9]{8})"></asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td>Địa Chỉ</td>
            <td>
                <asp:TextBox ID="ttbDiaChi" runat="server" CssClass="input"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>Điểm Số</td>
            <td>
                <asp:TextBox ID="ttbDiemSo" Enabled="false" Text="0" runat="server" CssClass="input" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" ValidationGroup="Check" Text="Cập nhật hồ sơ" OnClick="btnSave_Click" />&emsp;&emsp;&emsp;
                    <asp:Button ID="btnExit" runat="server" Text="Đăng xuất" CssClass="btn btn-danger" OnClick="btnExit_Click" />
            </td>
        </tr>
    </table>
</div>
