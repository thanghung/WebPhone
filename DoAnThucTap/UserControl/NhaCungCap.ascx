<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhaCungCap.ascx.cs" Inherits="DoAnThucTap.NhaCungCap1" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<link href="../Css/cssAdmin.css" rel="stylesheet" />

<%--Datatable--%>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="head">Chỉnh Sửa thông Tin Nhà Cung Cấp</div>
<div class="Container" style="margin: 20px 30px;">
    <table class="table table-responsive">
        <tr>
            <td>Tên NCC</td>
            <td>
                <asp:TextBox ID="ttbTenNCC" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Hãy Nhập tên nhà cung cấp" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbTenNCC"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Địa Chỉ</td>
            <td>
                <asp:TextBox ID="ttbDiaChi" runat="server" CssClass="input" MaxLength="100" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hãy Nhập địa chỉ nhà cung cấp" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbDiaChi"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>SĐT</td>
            <td>
                <asp:TextBox ID="ttbSDT" runat="server" CssClass="input" MaxLength="10" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbSDT"></asp:RequiredFieldValidator>
                &emsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="số điện thoại không hợp lệ" ValidationGroup="Check" ForeColor="Red" ControlToValidate="ttbSDT" ValidationExpression="(09|03|07|08|05)+([0-9]{8})"></asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button ID="btnSudmit" runat="server" Text="Thêm" OnClick="btnSudmit_Click" ValidationGroup="Check" CssClass="btn btn-info" title="Thêm Khách Hàng" OnClientClick="if(!confirm('Bạn muốn thêm 1 nhà cung cấp ?')) return false;" />&emsp;                         
               
                <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="btn btn-danger" ValidationGroup="Check" OnClick="btnDelete_Click" title="Xóa vĩnh viễn dữ liệu" OnClientClick="if(!confirm('Dữu liệu sẽ bị xóa vĩnh viễn')) return false;" />
            </td>
        </tr>
    </table>
</div>

<div class="head">Thông Tin Nhà Cung Cấp</div>
<br />
<div class="Container" style="margin: 10px 20px">
    <div style="position: relative; height: 500px; overflow: auto; display: block;">
        <asp:GridView class="display cell-border" ClientIDMode="Static" Border="1" runat="server" ID="DataList1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MaNCC" HeaderText="Mã Nhà Cung Cấp"  />
                <asp:BoundField DataField="TenNCC" HeaderText="Tên Nhà Cung Cấp"  />
                <asp:BoundField DataField="DiaChi" HeaderText="Địa Chỉ"  />
                <asp:BoundField DataField="DienThoai" HeaderText="Điện Thoại"  />
                <asp:BoundField DataField="TenNV" HeaderText="Người Nhập"  />
            </Columns>
        </asp:GridView>
    </div>
</div>

<script>
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

            window.location.href = "/QuanLyNhaCungCap/ncc/" + s;
        });
    });
</script>
