<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhanVien.ascx.cs" Inherits="DoAnThucTap.NhanVien1" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<link href="../Css/cssAdmin.css" rel="stylesheet" />

<%--datapicker--%>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<link rel="stylesheet" href="/resources/demos/style.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<%--Datatable--%>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="head">Chỉnh sửa thông tin Nhân Viên</div>
<div class="Container" id="section2" style="margin: 20px 30px;">
    <table class="table table-responsive">
        <tr>
            <td>User ID</td>
            <td>
                <asp:TextBox ID="ttbUserID" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hãy nhập tài khoản dùng để đăng nhập đăng nhập" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbUserID"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>User Name</td>
            <td>
                <asp:TextBox ID="ttbUserName" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Hãy nhập Tên tài khoản đăng nhập" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbUserName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Tên Nhân Viên</td>
            <td>
                <asp:TextBox ID="ttbTenNV" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Hãy nhập tên nhân viên" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbTenNV"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Chức Vụ</td>
            <td>
                <asp:TextBox ID="ttbChucVu" runat="server" CssClass="input" MaxLength="40"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Hãy nhập chức vụ nhân viên" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbChucVu"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Mật Khẩu</td>
            <td>
                <asp:TextBox ID="ttbMatKhau" runat="server" CssClass="input" MaxLength="20" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Hãy nhập mật khẩu để đăng nhập" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbMatKhau"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Giới Tính</td>
            <td>
                <asp:RadioButtonList ID="rblGioiTinh" runat="server" Height="20px" RepeatDirection="Horizontal" Width="200px">
                    <asp:ListItem Selected="True">Nam</asp:ListItem>
                    <asp:ListItem>Nữ</asp:ListItem>
                </asp:RadioButtonList>
        </tr>
        <tr>
            <td>Địa Chỉ</td>
            <td>
                <asp:TextBox ID="ttbDiaChi" runat="server" CssClass="input"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Hãy nhập địa chỉ nhân viên" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbDiaChi"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>SĐT</td>
            <td>
                <asp:TextBox ID="ttbSDT" runat="server" CssClass="input" MaxLength="10" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbSDT"></asp:RequiredFieldValidator>
                &emsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="số điện thoại không hợp lệ" ForeColor="Red" ControlToValidate="ttbSDT" ValidationGroup="Check" ValidationExpression="(09|03|07|08|05)+([0-9]{8})"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Ngày Sinh</td>
            <td>
                <asp:TextBox ID="ttbNgaySinh" runat="server" CssClass="input datepicker"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Hãy chọn ngày sinh" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbNgaySinh"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Trạng Thái</td>
            <td>
                <asp:TextBox ID="ttbTrangThai" runat="server" MaxLength="40" CssClass="input"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Hãy nhập trạng thái" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbTrangThai"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSudmit" runat="server" ValidationGroup="Check" Text="Thêm" OnClick="btnSudmit_Click" CssClass="btn btn-info" OnClientClick="if(!confirm('Bạn muốn thêm 1 nhân viên ?')) return false;" />&emsp;
                
                <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Check" Text="Cập nhật" OnClick="btnUpdate_Click" CssClass="btn btn-success" OnClientClick="if(!confirm('Dữ liệu nhân viên sẽ được cập nhật ?')) return false;" />&emsp;
               
                <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnDelete_Click" ValidationGroup="Check" OnClientClick="if(!confirm('Dữ liệu sẽ bị xóa vĩnh viễn')) return false;" />
            </td>
        </tr>
    </table>
</div>

<div class="head">thông tin Nhân Viên</div>
<br />
<div class="Container" style="margin: 10px 20px">
    <div style="position: relative; height: 500px; overflow: auto; display: block;">
        <asp:GridView class="display cell-border" ClientIDMode="Static" Border="1" runat="server" ID="DataList1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MaNV" HeaderText="Mã Nhân Viên"  />
                <asp:BoundField DataField="TenNV" HeaderText="Tên Nhân Viên"  />
                <asp:BoundField DataField="UserTK" HeaderText="TK Đăng Nhập"  />
                <asp:BoundField DataField="MatKhau" HeaderText="Mật Khẩu"  />
                <asp:BoundField DataField="ChucVu" HeaderText="Chức Vụ"  />
                <asp:BoundField DataField="GioiTinh" HeaderText="Giới Tính"  />
                <asp:BoundField DataField="DiaChi" HeaderText="Địa Chỉ"  />
                <asp:BoundField DataField="DienThoai" HeaderText="Số Điện Thoại"  />
                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày Sinh"  />
                <asp:BoundField DataField="TrangThai" HeaderText="Trạng Thái"  />
            </Columns>
        </asp:GridView>
    </div>
</div>

<script type="text/javascript">
    //code chay table
    $(document).ready(function () {
        $("#DataList1").DataTable({
            language: {
                "sProcessing": "Đang xử lý...",
                "sLengthMenu": "Xem _MENU_ mục",
                "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
                "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
                "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
                "sInfoFiltered": "(được lọc từ _MAX_ mục)",
                "sInfoPostFix": "",
                "sSearch": "Tìm Kiếm:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "Đầu",
                    "sPrevious": "Trước",
                    "sNext": "Tiếp",
                    "sLast": "Cuối"
                }
            },
        });
    });

    $(document).ready(function () {
        $('.datepicker').datepicker({ dateFormat: 'dd/mm/yy' });
    });

    $(function () {
        $('#DataList1 tbody').on('click', 'tr', function () {
            var s = $(this).closest("tr").find("td").eq(0).text().trim();

            window.location.href = "/QuanLyNhanVien/nv/" + s;
        });
    });
</script>
