<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vnpay_return.aspx.cs" Inherits="DoAnThucTap.vnpay_return" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kết quả</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <style>
        a:hover {
            text-decoration: none;
        }

        a {
            margin: 0 auto;
        }

            a:focus {
                text-decoration: none;
            }
    </style>


</head>
<body>
    <div class="container">
        <div class="header clearfix">

            <h3 class="text-muted">Kết quả thanh toán</h3>
        </div>
        <div class="table-responsive">
            <div runat="server" id="displayMsg"></div>
        </div>
    </div>

    <div style="text-align: center;">
        <a href="/trangchu">Về Trang chủ</a>
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
</body>
</html>
