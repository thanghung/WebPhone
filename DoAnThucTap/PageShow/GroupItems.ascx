<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupItems.ascx.cs" Inherits="DoAnThucTap.ItemsASUS" %>

<link href="../Css/indext.css" rel="stylesheet" />
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <div class="header">
        Sản Phẩm <%= Page.RouteData.Values["modul"].ToString().Trim()%>
    </div>
    <div class="content-listitems">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="100%" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <div class="list-item">
                            <asp:Image ID="Image1" runat="server" Width="160px" Height="170px" ImageUrl='<%# Eval("Anh")%>' />
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenHang")%>' Width="100%"></asp:Label><br />
                            <asp:Label ID="Label2" runat="server" Text='<%# DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("GiaBan")))%>' ForeColor="Red" Font-Bold="True"></asp:Label>&ensp;<b style="color: red;">VNĐ</b><br />
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("MaHang")%>' OnCommand="ImageButton1_Command" ImageUrl="https://dietcontrunggayhai.com/wp-content/uploads/2017/10/buy-button.png" Width="100px" />
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                
                 <div style="overflow: hidden; text-align:center; margin-bottom: 10px;">
                    <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <asp:Button ID="Button3" CssClass="btnpaging" runat="server" Text='<%# Container.DataItem %>' CommandName="Page" CommandArgument="<%# Container.DataItem %>" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:PlaceHolder>

<style>
    .btnpaging {
        background:#ff6a00; 
        border: solid 1px #000000;
    }

    .btnpaging:hover{
        background: #ffd800;
    }

    .btnpaging:active{
        background: #ffd800;
    }
</style>
