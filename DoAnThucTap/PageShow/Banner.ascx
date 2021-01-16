<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Banner.ascx.cs" Inherits="DoAnThucTap.Banner" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

<style>
    #myCarousel{
        width: 100%;
        height: 200px;
    }
    .carousel-control.right, .carousel-control.left {
        background-image: none;
        color: #f4511e;
    }

    .carousel-indicators li {
        border-color: #f4511e;
    }

        .carousel-indicators li.active {
            background-color: #f4511e;
        }

</style>

<div id="myCarousel" class="carousel slide text-center" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner" role="listbox">
        <div class="item active">
           <img src="https://ae01.alicdn.com/kf/HTB13zVGN7zoK1RjSZFlq6yi4VXaW.jpg"/>
        </div>
        <div class="item">
           <img src="https://cellphones.com.vn/media/wysiwyg/mobile/asus/asus-zenfone.jpg"/>
        </div>
        <div class="item">
            <asp:Image ID="Image1" runat="server" ImageUrl="https://cellphones.com.vn/media/wysiwyg/mobile/dien-thoai-android.jpg"/>
        </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>
</div>
