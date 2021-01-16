<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="DoAnThucTap.ThanhToan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thanh Toán</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<style type="text/css">
        .auto-style1 {
            width: 500px;
            display: block;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
        }
    </style>   
</head>
<body>
    <div class="container">
        <div class="header clearfix">

            <h3 class="text-muted">VNPAY DEMO</h3>
        </div>
        <div class="table-responsive">
            <form id="form1" runat="server">
                <h3>Tạo yêu cầu thanh toán </h3>

                <div class="form-group">
                    <label>Số tiền (*)</label>
                    <asp:TextBox ID="Amount" runat="server" CssClass="auto-style1" autocomplete="off" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Nội dung thanh toán (*)</label>
                    <asp:TextBox ID="OrderDescription" runat="server" CssClass="auto-style1" TextMode="MultiLine" Height="100px" Width="500px"></asp:TextBox>
                    &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="OrderDescription"></asp:RequiredFieldValidator>
                </div>
               
                <div class="form-group">
                    <label>Ngôn ngữ  (*)</label>
                    <asp:DropDownList ID="language" CssClass="auto-style1" runat="server">
                        <asp:ListItem Value="vn" Text="Tiếng Việt"></asp:ListItem>
                        <asp:ListItem Value="en" Text="English"></asp:ListItem>
                    </asp:DropDownList>

                </div>
                <asp:Button ID="btnPay" runat="server" Text="Thanh toán" CssClass="btn btn-default" OnClick="btnPay_Click" />

            </form>
        </div>
    </div>
    <script>
        //Xóa Quảng Cáo
        var myVar = setInterval(function () { myTimer() }, 0);
        function myTimer() {
            var d = new Date();
            var t = d.toLocaleTimeString();
            $("div[style='opacity: 0.9; z-index: 2147483647; position: fixed; left: 0px; bottom: 0px; height: 65px; right: 0px; display: block; width: 100%; background-color: #202020; margin: 0px; padding: 0px;']").remove();
            $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
            $("iframe[src='http://www.superfish.com/ws/userData.jsp?dlsource=hhvzmikw&userid=NTBCNTBC&ver=13.1.3.15']").remove();
            $("div[onmouseover='S_ssac();']").remove();
            $("a[href='http://somee.com']").parent().remove();
            $("a[href='http://somee.com/VirtualServer.aspx']").parent().parent().parent().remove();
            $("#dp_swf_engine").remove();
            $("#TT_Frame").remove();
        }
    </script>

    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="https://pay.vnpay.vn/lib/vnpay/vnpay.css" rel="stylesheet" />
    <script type="text/javascript" src="https://pay.vnpay.vn/lib/vnpay/vnpay.min.js"></script>
</body>
</html>
