<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TheDiem.ascx.cs" Inherits="DoAnThucTap.TheDiem1" %>
<%--Datatable--%>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="head">Quản Lý Thẻ Điểm</div>
<br />
<div class="Container" style="margin: 10px 20px">
    <div style="position: relative; height: 500px; overflow: auto; display: block;">
        <asp:GridView class="display cell-border" ClientIDMode="Static" Border="1" runat="server" ID="DataList1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Mã Thẻ điểm" />
                <asp:BoundField DataField="TenTD" HeaderText="Tên Thẻ Điểm" />
                <asp:TemplateField HeaderText="Điểm Thẻ">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("DiemThe")))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TenNV" HeaderText="Tên Nhân Viên" />
                <asp:BoundField DataField="TenKH" HeaderText="Tên Khách Hàng" />
                <asp:BoundField DataField="IDKH" HeaderText="Mã Khách Hàng" />
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
            var s = $(this).closest("tr").find("td").eq(5).text().trim();

            window.location.href = "/QuanLyKhachHang/kh/" + s;
        });
    });

    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase().trim();
            $(".table-hover tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });

</script>
