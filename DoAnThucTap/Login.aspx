<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DoAnThucTap.Login" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <h1 style="text-align: center; color: #ff0000">Đăng Nhập Hệ Thống</h1>
        <div style="margin: 40px auto;">
            <center>
                <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" FailureText="Bạn đăng nhập không thành công, Vui lòng thử lại." InstructionText="Vui lòng nhập tài khoản và mật khẩu" LoginButtonText="Đăng nhập" PasswordLabelText="Mật khẩu:" TitleText="Đăng nhập" UserNameLabelText="Tài khoản:" DestinationPageUrl="~/TrangHeThong" OnAuthenticate="Login1_Authenticate" PasswordRequiredErrorMessage="Mật khẩu không được rỗng." UserNameRequiredErrorMessage="Tài khoản không được rỗng." autocomlete="o">
                    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                </asp:Login>
            </center>
        </div>

        <script>
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
    </form>
</body>
</html>
