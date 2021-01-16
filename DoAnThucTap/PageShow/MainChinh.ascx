<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainChinh.ascx.cs" Inherits="DoAnThucTap.MainChinh" %>
<link href="../Css/indext.css" rel="stylesheet" />
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <div class="header">
        Sản Phẩm Bán Chạy Nhất
    </div>
    <div class="content-listitems">
        <div class="col-md-10">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="100%" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
                        <ItemTemplate>
                            <div class="col-md-4">
                                <div class="panel-body">
                                    <div class="list-item">
                                        <asp:Image ID="Image1" runat="server" Width="160px" ImageUrl='<%# Eval("Anh")%>' Height="170px" />
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenHang")%>' Width="100%"></asp:Label><br />
                                        <asp:Label ID="Label2" runat="server" Text='<%# ChangeSalaryType(Convert.ToDecimal(Eval("GiaBan"))) %>' ForeColor="Red" Font-Bold="True"></asp:Label>&ensp;<b style="color: red;">VNĐ</b><br />
                                        <asp:ImageButton ID="ImageButton1" CssClass="item" runat="server" ImageUrl="https://dietcontrunggayhai.com/wp-content/uploads/2017/10/buy-button.png" Width="100px" OnCommand="ImageButton1_Command" CommandArgument='<%# Eval("MaHang") %>' />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>

                    <div style="overflow: hidden; text-align: center; margin-bottom: 10px;">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <asp:Button ID="Button3" CssClass="btnpaging" runat="server" Text='<%# Container.DataItem %>' CommandName="Page" CommandArgument="<%# Container.DataItem %>" />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:PlaceHolder>

<style>
    .btnpaging {
        background: #ff6a00;
        border: solid 1px #000000;
    }

        .btnpaging:active {
            background: #ffd800;
        }

        .btnpaging:focus {
            background: #ffd800;
        }

        .btnpaging:hover {
            background: #ffd800;
        }
</style>
