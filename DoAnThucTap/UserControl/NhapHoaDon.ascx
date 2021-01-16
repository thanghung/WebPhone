<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhapHoaDon.ascx.cs" Inherits="DoAnThucTap.NhapHoaDon" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<link href="../Css/cssAdmin.css" rel="stylesheet" />

<%--datapicker--%>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="head">Nhập Hóa Đơn</div>
<div class="Container" style="margin: 20px 30px;">
    <p style="float: right; margin-right: 10px;"><b>Mã Hóa Đơn:</b> &emsp;<asp:Label ID="Label2" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black"></asp:Label></p>
    <table class="table table-responsive">
        <tr>
            <td>Ngày Bán</td>
            <td>
                <asp:TextBox ID="ttbNgayBan" runat="server" CssClass="input datepicker" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hãy chọn ngày bán" ForeColor="Red" ControlToValidate="ttbNgayBan" ValidationGroup="Check"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Tên Khách Hàng</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlKhachHang" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlKhachHang_SelectedIndexChanged">
                        </asp:DropDownList>&emsp;&emsp;
                <asp:Button ID="Button5" runat="server" Text="Thêm Khách Hàng" data-toggle="modal" data-target="#Modal-KH" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

    <%--Form Nhập Khách hàng--%>
    <div class="modal fade" id="Modal-KH" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="text-align: center;">Nhập thông tin khách hàng</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="table">
                                <tr>
                                    <td>Tên KH</td>
                                    <td>
                                        <asp:TextBox ID="ttbTenKH" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>
                                        &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Hãy Nhập tên khách hàng" ForeColor="Red" ValidationGroup="KH" ControlToValidate="ttbTenKH"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Email</td>
                                    <td>
                                        <asp:TextBox ID="ttbEmail" runat="server" CssClass="input" MaxLength="30" autocomplete="off"></asp:TextBox>
                                        &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="KH" ControlToValidate="ttbEmail"></asp:RequiredFieldValidator>
                                        &emsp;<asp:RegularExpressionValidator ID="REVemail" runat="server" ValidationGroup="KH" ErrorMessage="Email không hợp lệ" ControlToValidate="ttbEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </tr>
                                <tr>
                                    <td>SĐT</td>
                                    <td>
                                        <asp:TextBox ID="ttbSDT" runat="server" CssClass="input" MaxLength="10" autocomplete="off"></asp:TextBox>
                                        &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="KH" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ttbSDT"></asp:RequiredFieldValidator>
                                        &emsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="số điện thoại không hợp lệ" ForeColor="Red" ControlToValidate="ttbSDT" ValidationGroup="KH" ValidationExpression="(09|03|07|08|05)+([0-9]{8})"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Địa Chỉ</td>
                                    <td>
                                        <asp:TextBox ID="ttbDiaChi" runat="server" CssClass="input"></asp:TextBox>
                                        &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Hãy Nhập địa chỉ" ValidationGroup="KH" ForeColor="Red" ControlToValidate="ttbDiaChi"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlTenHang" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer" runat="server">
                    <asp:Button ID="Button3" runat="server" Text="Thêm Khách Hàng" OnClick="ThemKH_Click" ValidationGroup="KH" CssClass="btn btn-success" />
                    <asp:Button ID="Button4" runat="server" Text="Đóng lại" data-dismiss="modal" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>

    <%--Form hiển thị hàng nhập--%>
    <div class="Container" style="margin: 20px 30px;">
        <asp:GridView ID="GridView1" CssClass="table-responsive table" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AllowPaging="True" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="false" PageIndex="1">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <SelectedRowStyle BackColor="lightblue" />
            <Columns>
                <asp:BoundField DataField="STT" HeaderText="STT" />
                <asp:BoundField DataField="TenHang" HeaderText="Tên Hàng" />
                <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng" />
                <asp:BoundField DataField="DonGia" HeaderText="Đơn Giá" />
                <asp:BoundField DataField="GiamGia" HeaderText="Giảm Giá" />
                <asp:BoundField DataField="ThanhTien" HeaderText="Thành Tiền" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Xóa" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button2" runat="server" Text="Thêm Hàng" data-toggle="modal" data-target="#Mymodal" />&emsp;&emsp;
    </div>

    <%--Form Nhập Hàng Hóa--%>
    <div class="modal fade" id="Mymodal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 style="text-align: center;">Nhập thông tin hàng hóa</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="table">
                                <tr>
                                    <td>Tên Hàng</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTenHang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Select_Onclick">
                                            <asp:ListItem>---Chọn Hàng---</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>Số Lượng</td>
                                    <td>
                                        <asp:TextBox ID="ttbSoLuong" runat="server" CssClass="input" MaxLength="5"></asp:TextBox>
                                        &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ttbSoLuong"></asp:RequiredFieldValidator>
                                        &emsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="chỉ được nhập từ 100-99999" ForeColor="Red" ControlToValidate="ttbSoLuong" Type="Integer" MinimumValue="1" MaximumValue="99999"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Đơn giá</td>
                                    <td>
                                        <asp:Label ID="ttbDonGia" runat="server" CssClass="input" Enabled="false"></asp:Label>&ensp;VNĐ
                                    </td>
                                </tr>

                                <tr>
                                    <td>Giảm Giá</td>
                                    <td>
                                        <asp:Label ID="ttbGiamGia" runat="server" CssClass="input" Enabled="false"></asp:Label>&ensp;VNĐ
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlTenHang" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer" runat="server">
                    <asp:Button ID="Button1" runat="server" Text="Thêm Hàng" OnClick="ThemHang_Click" />
                    <asp:Button ID="btnClose" runat="server" Text="Đóng lại" data-dismiss="modal" />
                </div>
            </div>
        </div>
    </div>
    <div style="text-align: right; margin-right: 20px;">Điểm Khách Hàng: &emsp;<asp:Label ID="LbDiemSo" runat="server" Enabled="False" Text="0"></asp:Label>&ensp;Điểm</div>
    <div style="text-align: right; margin-right: 20px;">Tổng Tiền: &emsp;<asp:Label ID="Label1" Text="0" runat="server" Enabled="False"></asp:Label>&ensp;VNĐ</div>
    <asp:Button ID="btnSudmit" OnClientClick="if(!confirm('Bạn muốn thêm hóa đơn ?')) return false;" runat="server" Text="Thêm Hóa Đơn" OnClick="btnSudmit_Click" CssClass="btn btn-info" title="Thêm Hóa Đơn" ValidationGroup="Check" />&emsp;&emsp;
    <asp:Button ID="btnHuy" runat="server" Text="Hủy Hóa Đơn" OnClientClick="if(!confirm('Bạn muốn hủy hóa đơn ?')) return false;" OnClick="btnHuy_Click" CssClass="btn btn-danger" title="Hủy Hóa Đơn" ValidationGroup="Check" />&emsp;&emsp;
    <input type="button" value="Xem trước hóa đơn" class="btn btn-success" data-toggle="modal" data-target="#ModalIn" />&emsp;&emsp;
    <input type="button" onclick="printDiv('print')" value="In hóa đơn" class="btn btn-warning" />
</div>

<%--Form In Hàng Hóa--%>
<div class="modal fade" id="ModalIn" role="dialog">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div id="print">
                <div class="modal-header">
                    <h4 style="text-align: center;">Thông Tin Hóa Đơn</h4>
                </div>

                <div class="modal-body">
                    Tên Khách Hàng: &emsp;
                    <asp:Label ID="LbTenKH" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="GridView2" CssClass="table table-responsive" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" />
                            <asp:BoundField DataField="TenHang" HeaderText="Tên Hàng" />
                            <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng" />
                            <asp:BoundField DataField="DonGia" HeaderText="Đơn Giá" />
                            <asp:BoundField DataField="GiamGia" HeaderText="Giảm Giá" />
                            <asp:BoundField DataField="ThanhTien" HeaderText="Thành Tiền" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />

                    <div style="text-align: right; margin-right: 30px;">
                        Tổng Tiền: &emsp; <%= Label1.Text.Trim()%>VNĐ
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="Button6" runat="server" Text="Đóng" data-dismiss="modal" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</div>
<script>
    $(document).ready(function () {
        $('.datepicker').datepicker({ dateFormat: 'dd/mm/yy' });
    });

    $(function () {
        $("#Button2").click(function (event) {
            $("#Mymodal").show();
        });
    });

    //In
    function printDiv(divName) {
        var printContents = document.getElementById(divName).innerHTML;
        var originalContents = document.body.innerHTML;

        document.body.innerHTML = printContents;

        window.print();

        document.body.innerHTML = originalContents;
    }
</script>
