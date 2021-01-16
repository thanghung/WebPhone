<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DangKy.ascx.cs" Inherits="DoAnThucTap.DangKy" %>

<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" />
<link href="Css/Login/main.css" rel="stylesheet" />
<link href="Css/Login/util.css" rel="stylesheet" />


<div class="limiter">
    <div class="container-login100" style="background-image: url('/Images/bg-01.jpg');">
        <div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-54">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <%-- Đăng kí--%>
                    <div class="login100-form validate-form">
                        <span class="login100-form-title p-b-49">Đăng Ký
                        </span>

                        <div class="wrap-input100 validate-input m-b-23" data-validate="Username is reauired">
                            <span class="label-input100">Tài Khoản</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUserDK"></asp:RequiredFieldValidator>
                            <input class="input100" id="txtUserDK" runat="server" type="text" name="username" placeholder="Nhập Tài Khoản" autocomplete="off" maxlength="20" />
                            <span class="focus-input100 TK"></span>
                        </div>

                        <div class="wrap-input100 validate-input m-b-23" data-validate="Username is reauired">
                            <span class="label-input100">Email</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REVemail" runat="server" ErrorMessage="Email không hợp lệ" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <input class="input100" id="txtEmail" runat="server" type="text" name="username" placeholder="Nhập Tài Khoản" autocomplete="off" maxlength="30" />
                            <span class="focus-input100 TK"></span>
                        </div>

                        <div class="wrap-input100 validate-input" data-validate="Password is required">
                            <span class="label-input100">Mật Khẩu</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMatKhauDK"></asp:RequiredFieldValidator>
                            <input class="input100" id="txtMatKhauDK" runat="server" type="password" name="pass" maxlength="20" placeholder="Nhập Mật Khẩu" />
                            <span class="focus-input100 MK"></span>

                        </div>

                        <div class="wrap-input100 validate-input" data-validate="Password is required">
                            <span class="label-input100">Nhập Lại Mật Khẩu</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNhapMK"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu không trùng khớp" ForeColor="Red" ControlToValidate="txtNhapMK" ControlToCompare="txtMatKhauDK" Operator="Equal"></asp:CompareValidator>
                            <input class="input100" id="txtNhapMK" runat="server" type="password" name="pass" placeholder="Nhập Mật Khẩu" maxlength="20" />
                            <span class="focus-input100 MK"></span>
                        </div>

                        <div class="container-login100-form-btn">
                            <div class="wrap-login100-form-btn">
                                <div class="login100-form-bgbtn"></div>
                                <button class="login100-form-btn" id="btnDangKy" runat="server" type="button" onserverclick="btnDangKy_ServerClick">
                                    Đăng Ký
                                </button>
                            </div>
                        </div>

                        <div class="flex-col-c p-t-155">
                            <span class="txt1 p-b-17">Nếu Đã Có Tài Khoản Hãy Đăng Nhập
                            </span>

                            <a href="/DangNhapKhachHang" class="txt2">Đăng Nhập
                            </a>
                        </div>
                    </div>
                </asp:View>

                <%--Xác nhận Mã--%>
                <asp:View ID="View2" runat="server">
                    <div class="login100-form validate-form">
                        <span class="login100-form-title p-b-49">Nhập Mã Xác Nhận
                        </span>

                        <div class="wrap-input100 validate-input m-b-23" data-validate="Username is reauired">
                            <span class="label-input100">Mã Xác Nhận</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Text3" ValidationGroup="XN"></asp:RequiredFieldValidator>
                            <input class="input100" id="Text3" runat="server" type="text" name="username" placeholder="Nhập Mã Xác Nhận" autocomplete="off" maxlength="6" />
                            <span class="focus-input100 TK"></span>
                        </div>

                        <div class="text-right p-t-8 p-b-31">
                            <asp:Label ID="Label1" runat="server" Text="Hãy kiểm tra hộp thư email của bạn" ForeColor="Blue"></asp:Label><br />
                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Trở về ?</asp:LinkButton>
                        </div>

                        <div class="container-login100-form-btn">
                            <div class="wrap-login100-form-btn">
                                <div class="login100-form-bgbtn"></div>
                                <button class="login100-form-btn" id="btnXacNhan" runat="server" type="button" onserverclick="btnXacNhan_ServerClick" validationgroup="XN">
                                    Xác Nhận
                                </button>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</div>
