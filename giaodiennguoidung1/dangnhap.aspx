<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dangnhap.aspx.cs" Inherits="dangnhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Đăng nhập</h2>
            Tên đăng nhập: <asp:TextBox ID="txt_tendangnhap" runat="server"></asp:TextBox>
            <br />
            Mật khẩu: <asp:TextBox ID="txt_matkhau" runat="server" TextMode="Password" Width="199px"></asp:TextBox>
            <br />
            <asp:Label ID="lb_thongbao" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="btn_dangnhap" runat="server" Text="Đăng nhập" ForeColor="Red" OnClick="btn_dangnhap_Click" />
        </div>
    </form>
</body>
</html>
