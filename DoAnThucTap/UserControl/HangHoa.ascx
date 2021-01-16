<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HangHoa.ascx.cs" Inherits="DoAnThucTap.HangHoaLoad" %>
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

<div class="Container" style="margin: 20px 30px;">
    <table class="table table-responsive">
        <tr>
            <td>Số lượng tồn kho cho phép</td>
            <td>
                <asp:TextBox ID="ttbSoLuongMax" runat="server" CssClass="input" MaxLength="5" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Change" ControlToValidate="ttbSoLuongMax"></asp:RequiredFieldValidator>
                &emsp;<asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Số lượng tồn kho tối đa cho mỗi mặt hàng từ 100-99999" ForeColor="Red" MinimumValue="10" MaximumValue="99999" Type="Integer" ValidationGroup="Change" ControlToValidate="ttbSoLuongMax"></asp:RangeValidator>
                <hr />
                <asp:Button ID="Button1" runat="server" Text="Thay đổi" CssClass="btn-primary" ValidationGroup="Change" OnClientClick="if(!confirm('Bạn muốn thay đổi số lượng tồn kho cho phép trong kho ?')) return false;" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</div>

<div class="head">Chỉnh sửa thông tin Hàng Hóa</div>
<div class="Container" style="margin: 20px 30px;">
    <table class="table table-responsive">
        <tr>
            <td>Ngày Nhập</td>
            <td>
                <asp:TextBox ID="ttbNgayNhap" runat="server" CssClass="input datepicker" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hãy chọn ngày tháng năm" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbNgayNhap"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Tên Hàng</td>
            <td>
                <asp:TextBox ID="ttbTenHang" runat="server" CssClass="input" MaxLength="40" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Hãy Nhập tên hàng" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbTenHang"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Số Lượng</td>
            <td>
                <asp:TextBox ID="ttbSoLuong" runat="server" CssClass="input" MaxLength="5" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbSoLuong"></asp:RequiredFieldValidator>
                &emsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Số lượng nhập phải nhỏ hơn số lượng tồn kho cho phép" ValidationGroup="Check" ControlToValidate="ttbSoLuong" Type="Integer" ControlToCompare="ttbSoLuongMax" ForeColor="Red" Operator="LessThan"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Giá Nhập</td>
            <td>
                <asp:TextBox ID="ttbGiaNhap" runat="server" CssClass="input" MaxLength="9" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbGiaNhap"></asp:RequiredFieldValidator>
                &emsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="chỉ được nhập từ 1000-900 triệu" ForeColor="Red" ControlToValidate="ttbGiaNhap" Type="Integer" ValidationGroup="Check" MinimumValue="1" MaximumValue="999999999"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>Giảm Giá</td>
            <td>
                <asp:TextBox ID="ttbGiamGia" runat="server" CssClass="input" MaxLength="7" autocomplete="off"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbGiamGia"></asp:RequiredFieldValidator>
                &emsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Giá giảm phải bé hơn giá nhập" ValidationGroup="Check" ForeColor="Red" ControlToValidate="ttbGiamGia" ControlToCompare="ttbGiaNhap" Type="Integer" Operator="LessThan"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Mong muốn lợi nhuận</td>
            <td>
                <asp:TextBox ID="ttbLoiNhuan" runat="server" CssClass="input" MaxLength="2"></asp:TextBox>
                &emsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Check" ControlToValidate="ttbLoiNhuan"></asp:RequiredFieldValidator>
                &emsp;<asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="chỉ được nhập từ 1-80%" ForeColor="Red" ControlToValidate="ttbLoiNhuan" Type="Integer" ValidationGroup="Check" MinimumValue="1" MaximumValue="80"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>Ảnh</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" onchange="loadFile(event)" />
                <hr>
                <img id="output" alt="your image" width="150" runat="server">
            </td>
        </tr>
        <tr>
            <td>Ghi Chú</td>
            <td>
                <asp:TextBox ID="ttbGhiChu" runat="server" CssClass="input" autocomplete="off" TextMode="MultiLine" Height="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>GR Hàng</td>
            <td>
                <asp:DropDownList ID="ddlMaGRHang" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>Nhà Cung Cấp</td>
            <td>
                <asp:DropDownList ID="ddlMaNCC" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSudmit" runat="server" Text="Thêm" OnClick="btnSudmit_Click" CssClass="btn btn-info" ValidationGroup="Check" OnClientClick="if(!confirm('Mặt hàng sẽ được thêm vào kho ?')) return false;" />&emsp;
               
                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="btn btn-info" OnClick="btnUpdate_Click" ValidationGroup="Check" OnClientClick="if(!confirm('Bạn muốn cập nhật dữ liệu ?')) return false;" />&emsp;
               
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btnSave_Click" ValidationGroup="Check" OnClientClick="if(!confirm('Dữ liệu này sẽ được ẩn để phục vụ mục đích lưu trữ cho sau này ?')) return false;" />&emsp;
               
                <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnDelete_Click" ValidationGroup="Check" OnClientClick="if(!confirm('Dữu liệu sẽ bị xóa vĩnh viễn')) return false;" />

            </td>
        </tr>
    </table>
</div>

<div class="head">thông tin Hàng Hóa</div>

<div class="Container" style="margin: 10px 20px">
    <asp:GridView class="display cell-border" Border="1" ClientIDMode="Static" runat="server" ID="tableHang" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="MaHang" HeaderText="Mã Hàng"/>
            <asp:BoundField DataField="TenHang" HeaderText="Tên Hàng" />
            <asp:BoundField DataField="TonKho" HeaderText="Số Lượng" />
            <asp:TemplateField HeaderText="Giá Bán">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# DoAnThucTap.MainChinh.ChangeSalaryType(Convert.ToDecimal(Eval("GiaBan")))%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NgayNhap" HeaderText="Ngày Nhập" />
            <asp:ImageField DataImageUrlField="Anh" HeaderText="Ảnh" ItemStyle-Width="50px" ItemStyle-Height="50px" ControlStyle-Width="50px" ControlStyle-Height="50px">
            </asp:ImageField>
            <asp:BoundField DataField="GhiChu" HeaderText="Ghi Chú" />
            <asp:BoundField DataField="TenGRH" HeaderText="Tên Nhóm Hàng" />
            <asp:BoundField DataField="TenNCC" HeaderText="Tên Nhà Cung Cấp" />
            <asp:BoundField DataField="TenNV" HeaderText="Tên Nhân Viên Nhập" />
        </Columns>
    </asp:GridView>
</div>

<script type="text/javascript">
    //code chay table
    $(document).ready(function () {
        $("#tableHang").DataTable({
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

    
    $('#tableHang tbody').on('click', 'tr', function () {
        var s = $(this).closest("tr").find("td").eq(0).text().trim();

        window.location.href = "/QuanLyHangHoa/hh/" + s;
    });

    //Update Ảnh
    var loadFile = function (event) {
        var image = document.getElementById('output');
        image.src = URL.createObjectURL(event.target.files[0]);
    };
 </script>
