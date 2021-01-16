<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GRNhanVien.ascx.cs" Inherits="DoAnThucTap.UserControl.GRNhanVien" %>
<%--Datatable--%>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="head">Group Nhân Viên</div>
<br />
<div class="Container" style="margin: 10px 20px">
    <div style="position: relative; height: 500px; overflow: auto; display: block;">
        <asp:GridView class="display cell-border" ClientIDMode="Static" Border="1" runat="server" ID="DataList1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="UserTK" HeaderText="Tài khoản đăng nhập"/>
                <asp:BoundField DataField="UserName" HeaderText="Tên Đăng Nhập"/>
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
</script>
