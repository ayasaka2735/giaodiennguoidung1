<%@ Page Title="" Language="C#" MasterPageFile="~/QuantriHT.master" AutoEventWireup="true" CodeFile="ChitietLK.aspx.cs" Inherits="ChitietLK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>CHI TIẾT LIÊN KẾT</h2>
    Ảnh cũ: <asp:Image ID="img_Anh_Cu"  runat="server" Height="300px" Width="600px" /> <br />
    Ảnh mới: <asp:FileUpload ID="ful_Anh_Moi" runat="server" /> <br />
    Địa chỉ liên kết:<asp:TextBox ID="txt_Link" runat="server" Width="223px"></asp:TextBox> <br />
    <asp:Label ID="lb_ThongBao" runat="server" Text="" ForeColor="Red"></asp:Label> <br />
    <asp:Button ID="btn_CapNhat" runat="server" Text="Cập nhật" Width="103px" OnClick="btn_CapNhat_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_LamLai" runat="server" Text="Làm lại" />
</asp:Content>

