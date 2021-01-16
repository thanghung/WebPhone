<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KhachHangLoad.ascx.cs" Inherits="DoAnThucTap.KhachHangLoad1" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<link href="../Css/cssAdmin.css" rel="stylesheet" />

<%--Datatable--%>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="head">Chỉnh sửa thông tin Khách Hàng</div>
<div class="Container" style="margin: 20px 30px;">
    <table class="table table-responsive">
        <tr>
            <td>Tên KH</td>
            <td>
                <asp:TextBox ID="ttbTenKH" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Hãy Nhập tên khách hàng" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbTenKH"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="ttbEmail" runat="server" CssClass="input" MaxLength="30" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbEmail"></asp:RequiredFieldValidator>
                &emsp;<asp:RegularExpressionValidator ID="REVemail" runat="server" ValidationGroup="Check" ErrorMessage="Email không hợp lệ" ControlToValidate="ttbEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </tr>
        <tr>
            <td>SĐT</td>
            <td>
                <asp:TextBox ID="ttbSDT" runat="server" CssClass="input" MaxLength="10" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ValidationGroup="Check" ForeColor="Red" ControlToValidate="ttbSDT"></asp:RequiredFieldValidator>
                &emsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="số điện thoại không hợp lệ" ForeColor="Red" ControlToValidate="ttbSDT" ValidationGroup="Check" ValidationExpression="(09|03|07|08|05)+([0-9]{8})"></asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td>Địa Chỉ</td>
            <td>
                <asp:TextBox ID="ttbDiaChi" runat="server" CssClass="input"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hãy Nhập địa chỉ" ValidationGroup="Check" ForeColor="Red" ControlToValidate="ttbDiaChi"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Điểm Số</td>
            <td>
                <asp:TextBox ID="ttbDiemSo" runat="server" CssClass="input" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="Check" ForeColor="Red" ControlToValidate="ttbDiaChi"></asp:RequiredFieldValidator>
                &emsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Phải nhập số nguyên dương 0" ForeColor="Red" ControlToValidate="ttbDiemSo" ValidationGroup="Check" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSudmit" runat="server" Text="Thêm" OnClick="btnSudmit_Click" ValidationGroup="Check" CssClass="btn btn-info" title="Thêm Khách Hàng" OnClientClick="if(!confirm('Bạn muốn thêm khách hàng ?')) return false;" />&emsp;
                   
                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="btn btn-info" ValidationGroup="Check" OnClick="btnUpdate_Click" title="Chỉnh sửa dữ liệu" OnClientClick="if(!confirm('dữ liệu của khách hàng sẽ được cập nhật ?')) return false;" />&emsp;
                   
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-success" ValidationGroup="Check" OnClick="btnSave_Click" title="Sao lưu và ẩn dữ liệu" OnClientClick="if(!confirm('Dữ liệu khách hàng này sẽ được ẩn và lưu trữ để phục vụ mục đích sau này?')) return false;" />&emsp;
                   
                <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="btn btn-danger" ValidationGroup="Check" OnClick="btnDelete_Click" title="Xóa vĩnh viễn dữ liệu" OnClientClick="if(!confirm('Dữu liệu sẽ bị xóa vĩnh viễn')) return false;" />

            </td>
        </tr>
    </table>
</div>

<div class="head">thông tin Khách Hàng</div>
<br />
<div class="Container" style="margin: 10px 20px">
    <div style="position: relative; height: 500px; overflow: auto; display: block;">
        <asp:GridView class="display cell-border" ClientIDMode="Static" Border="1" runat="server" ID="DataList1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MaKH" HeaderText="Mã Khách Hàng" />
                <asp:BoundField DataField="TenKH" HeaderText="Tên Khách Hàng" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="SDT" HeaderText="Số Điện Thoại" />
                <asp:BoundField DataField="DiaChi" HeaderText="Địa Chỉ" />
                <asp:BoundField DataField="DiemSo" HeaderText="Điểm Số" />
            </Columns>
        </asp:GridView>
    </div>
</div>

<%-- <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                $('.table-hover tr').click(function (e) {
                    e.preventDefault();
                    var s = $(this).closest("tr").find("td").first().text().trim();
                    window.location.href = "Admin.aspx?modul=kh&id=" + s;
                });
            });

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                $("#myInput").on("keyup", function () {
                    var value = $(this).val().toLowerCase().trim();
                    $(".table-hover tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                    });
                });
            });
        </script>--%>

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

    $(function () {
        $('#DataList1 tbody').on('click', 'tr', function () {
            var s = $(this).closest("tr").find("td").eq(0).text().trim();

            window.location.href = "/QuanLyKhachHang/kh/" + s;
        });
    });
</script>
