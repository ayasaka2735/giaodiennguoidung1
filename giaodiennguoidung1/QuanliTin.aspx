<%@ Page Title="" Language="C#" MasterPageFile="~/QuantriHT.master" AutoEventWireup="true" CodeFile="QuanLiTin.aspx.cs" Inherits="QuanLiTin" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Quản lí Tin tức</h1>
    Nhóm tin: <asp:DropDownList ID="drl_NhomTin" runat="server" Height="27px" Width="288px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="drl_NhomTin_SelectedIndexChanged">
        <asp:ListItem Value="0">Tất Cả Tin </asp:ListItem>
    </asp:DropDownList>
    <br />

  Danh sách tin tức: 
     
<br />
    <asp:GridView ID="grv_Tin" DataKeyNames="ID_Tin" runat="server" AutoGenerateColumns="False" CellPadding  ="4" ForeColor="#333333" GridLines="None" Width="683px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>

            <asp:ImageField DataImageUrlField="Anh" DataImageUrlFormatString="../{0}" HeaderText="Ảnh Tin">
                <ControlStyle Height="40px" Width="80px" />
                <ItemStyle Width="25%" />
            </asp:ImageField>

            <asp:BoundField DataField="TenTin" HeaderText="Tên tin tức">
            <ItemStyle Width="45%" />
            </asp:BoundField>
            
            <asp:TemplateField HeaderText="Sửa">
                <ItemTemplate>
                    <asp:ImageButton ID="btn_Sua" runat="server" CommandName="Edit" ImageUrl="~/Images/EDIT.JPG" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:ImageButton ID="btn_Xoa" runat="server" CommandName="Delete" ImageUrl="~/Images/DELETE.JPG" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
         
</asp:Content>


