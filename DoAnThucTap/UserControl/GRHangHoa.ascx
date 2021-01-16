<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GRHangHoa.ascx.cs" Inherits="DoAnThucTap.GRHangHoa" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
<link href="../Css/cssAdmin.css" rel="stylesheet" />

<%--Datatable--%>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="head">Chỉnh sửa thông tin Group Hàng Hóa</div>
<div class="Container" style="margin: 20px 30px;">
    <table class="table table-responsive">
        <tr>
            <td>Tên Nhóm Hàng Hóa</td>
            <td>
                <asp:TextBox ID="ttbTenGRHang" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>&emsp;
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hãy nhập tên nhóm hàng hóa" ForeColor="Red" ControlToValidate="ttbTenGRHang" ValidationGroup="Check"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSudmit" runat="server" Text="Thêm" OnClick="btnSudmit_Click" CssClass="btn btn-info " ValidationGroup="Check" OnClientClick="if(!confirm('Bạn muốn thêm 1 nhóm hàng hóa không ?')) return false;" />&emsp;
               
                <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnDelete_Click" ValidationGroup="Check" OnClientClick="if(!confirm('Dữu liệu sẽ bị xóa vĩnh viễn')) return false;" />

            </td>
        </tr>
    </table>
</div>

<div class="head">Thông Tin Nhóm Hàng Hóa</div>
<br />
<div class="Container" style="margin: 10px 20px">
    <div style="height: 10px;"></div>
    <div style="position: relative; height: 500px; overflow: auto; display: block;">
        <asp:GridView class="display cell-border" Border="1" ClientIDMode="Static" runat="server" ID="DataList1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MaGRHang" HeaderText="Mã Nhóm Hàng Hóa" />
                <asp:BoundField DataField="TenGroupHang" HeaderText="Tên Nhóm Hàng Hóa" />
                <asp:BoundField DataField="TenNV" HeaderText="Nhân Viên Nhập" />
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

            window.location.href = "/QuanLyNhomHangHoa/grhh/" + s;
        });
    });
 </script>
