<%@ Page Title="" Language="C#" MasterPageFile="~/QuantriHT.master" ValidateRequest ="False" AutoEventWireup="true" CodeFile="ThemTin.aspx.cs" Inherits="ThemTin" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Thêm Tin Mới</h1>

    Nhóm tin: <asp:DropDownList ID="drl_NhomTin" runat="server" Width="276px" AppendDataBoundItems="True"></asp:DropDownList>
    <br />
    Tên tin:<asp:TextBox ID="txt_TenTin" runat="server" Width="354px"></asp:TextBox>
    <br />
    Ảnh tin:<asp:FileUpload ID="ful_Anh" runat="server" Width="357px" />
    <br />
    Tóm tắt:<FTB:FreeTextBox ID="ftb_TomTat" runat="server"></FTB:FreeTextBox>
    Nội dung:<FTB:FreeTextBox ID="ftb_NoiDung" runat="server" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertRule|Cut,Copy,Paste;Undo,Redo,Print, InsertImageFromGallery" ImageGalleryUrl = "ftb.imagegallery.aspx?rif=~/images/&cif=~/Anh_Lien_Ket/" ToolbarImagesLocation="InternalResource" ></FTB:FreeTextBox>
    <br />

    <asp:Button ID="btn_ThemMoi" runat="server" Text="Thêm mới" OnClick="btn_ThemMoi_Click" /> &nbsp;
    <asp:Button ID="btn_LamLai" runat="server" Text="Làm lại" />
</asp:Content>

