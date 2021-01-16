<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietNhapKho.ascx.cs" Inherits="DoAnThucTap.ChiTietNhapKho1" %>
<%--Datatable--%>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="head">Chi Tiết Nhập Kho</div>
<br />
<div id="Container" style="margin: 10px 20px">
    <asp:GridView class="display cell-border" Border="1" ClientIDMode="Static" runat="server" ID="DataList1" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="MaNK" HeaderText="Mã Nhập Kho" />
            <asp:BoundField DataField="TenHH" HeaderText="Tên Hàng" />
            <asp:BoundField DataField="TenNCC" HeaderText="Tên Nhà Cung Cấp" />
            <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng" />
            <asp:TemplateField HeaderText="Giá Nhập">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("GiaNhap")))%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Giảm Giá">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("GiamGia")))%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
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
