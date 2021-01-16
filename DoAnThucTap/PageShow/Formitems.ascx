<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Formitems.ascx.cs" Inherits="DoAnThucTap.FormItems" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<script src="https://unpkg.com/js-image-zoom@0.4.1/js-image-zoom.js" type="application/javascript"></script>

<div class="header">
    Thông Tin Sản Phẩm
</div>

<asp:Panel ID="Panel1" runat="server">
    <asp:FormView ID="FormView1" runat="server" CssClass="table">
        <ItemTemplate>
            <td>
                <div id="img-container" style="width: 300px">
                    <img id="img" src='<%# Eval("Anh")%>' runat="server" />
                </div>
            </td>

            <td>
                <div style="text-align: center;">
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("TenHang")%>' Font-Size="15px" Font-Bold="true"></asp:Label><br />
                    <asp:Label ID="Label4" runat="server" Text='<%# DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("GiaBan")))%>' ForeColor="Red" Font-Bold="True" Font-Size="17px"></asp:Label>&ensp;<b style="color: red;">VNĐ</b><br />
                    <br />
                    <button id="btnHH" type="button" class="btn btn-warning my-cart-btn" data-id='<%# Eval("MaHang")%>' data-name='<%# Eval("TenHang")%>' data-summary="" data-price='<%# Eval("GiaBan")%>' data-quantity="1" data-image='<%# RewriteUrlImg(Eval("Anh").ToString().Trim())%>' runat="server">Thêm vào giỏ hàng</button>
                    <br />
                </div>
            </td>
        </ItemTemplate>
    </asp:FormView>

    <script>
        var options = {
            width: 300,
            zoomWidth: 250,

        };
        new ImageZoom(document.getElementById("img-container"), options);

            </script>
</asp:Panel>

<asp:Panel ID="Panel2" runat="server">
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="100%" RepeatDirection="Horizontal">
        <ItemTemplate>
            <div style="margin-left: 5px; margin-top: 5px; text-align: center;">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Anh")%>' style="max-width: 160px; width: 100%; max-height: 240px;"/>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenHang")%>' Width="100%"></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text='<%#  DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("GiaBan"))) %>' ForeColor="Red" Font-Bold="True"></asp:Label>&ensp;<b style="color: red;">VNĐ</b><br />
                <asp:ImageButton ID="ImageButton1" CssClass="item" runat="server" ImageUrl="https://dietcontrunggayhai.com/wp-content/uploads/2017/10/buy-button.png" Width="100px" OnCommand="ImageButton1_Command" CommandArgument='<%# Eval("MaHang") %>' />
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Panel>
