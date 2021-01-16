<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HoaDon.ascx.cs" Inherits="DoAnThucTap.HoaDon1" %>
<%--Datatable--%>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="head">Quản Lý Hóa Đơn</div>
<br />
<div id="Container" style="margin: 10px 20px">
    <div style="position: relative; height: 500px; overflow: auto; display: block;">
        <asp:GridView class="display cell-border" ClientIDMode="Static" Border="1" runat="server" ID="DataList1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MaHD" HeaderText="Mã Hóa Đơn" />
                <asp:BoundField DataField="NgayBan" HeaderText="Ngày Bán" />
                <asp:BoundField DataField="TenKH" HeaderText="Tên Khách Hàng" />
                <asp:TemplateField HeaderText="Tổng Tiền">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("TongTien")))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Điểm Số">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("DiemDH")))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NgayTao" HeaderText="Ngày Tạo" />
                <asp:BoundField DataField="NgayCapNhat" HeaderText="Ngày Cập Nhật" />
                <asp:BoundField DataField="NguoiTao" HeaderText="Người Tạo" />
                <asp:BoundField DataField="NguoiCapNhat" HeaderText="Người Cập Nhật" />
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
        $('#tableHang tbody').on('click', 'tr', function () {
            var s = $(this).closest("tr").find("td").eq(0).text().trim();

            window.location.href = "/NhapHoaDon/nhd/" + s;
        });
    });
</script>
