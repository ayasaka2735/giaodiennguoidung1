<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sua_Lien_Ket.aspx.cs" Inherits="Sua_Lien_Ket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 26px;
            width: 130px;
        }
        .auto-style3 {
            width: 130px;
        }
        .auto-style4 {
            width: 100%;
            height: 392px;
        }
        .auto-style5 {
            width: 74px;
        }
        </style>
</head>
<body>
<form runat="server">
    <table>
        <tr>
            <td>Thay đổi</td>
        </tr>

        <tr>
            <td><strong>Hình Ảnh Cũ</strong> </td>
            <td><asp:Image ID="Image1" runat="server" Height="162px" Width="130px" /></td>
            <td></td>       
        </tr>

        <tr>
            <td> <strong>Hình Ảnh Mới: </strong> </td>
            <td> <asp:FileUpload ID="FileUpload1" runat="server" /> </td>
            <td></td>
        </tr>
        
        <tr>
            <td> Địa chỉ URL </td>
            <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btn_Cap_Nhat" runat="server" Text="Cập nhật" OnClick="btn_Cap_Nhat_Click" /> 
                <asp:Button ID="btn_Lam_Lai" runat="server" Text="Làm lại" />
            </td>
         </tr> 

            </table>
</form>
</body>
</html>
