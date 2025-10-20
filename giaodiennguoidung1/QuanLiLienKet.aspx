<%@ Page Title="" Language="C#" MasterPageFile="~/QuantriHT.master" AutoEventWireup="true" CodeFile="QuanLiLienKet.aspx.cs" Inherits="QuanLiLienKet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Quản lí Liên kết</h1>

    <asp:GridView ID="grv_LienKet" DataKeyNames = "ID_LienKet" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grv_LienKet_RowDeleting" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>

            <asp:ImageField DataImageUrlField="Anh" DataImageUrlFormatString="../{0}" HeaderText="Hình ảnh">
                <ControlStyle Height="40px" Width="80px" />
                <ItemStyle Width="25%" />
            </asp:ImageField>

            <asp:BoundField DataField="Link" HeaderText="Liên kết">
            <ItemStyle Width="45%" />
            </asp:BoundField>

            <asp:TemplateField HeaderText="Sửa">
                <ItemTemplate>
                    <asp:ImageButton runat="server" CommandName = "Edit" Height="10px" ImageUrl="~/Images/EDIT.JPG" Width="10px"></asp:ImageButton>
                </ItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:ImageButton runat="server" CommandName = "Delete" Height="10px" ImageUrl="~/Images/DELETE.JPG" Width="10px"  ></asp:ImageButton>
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
    <div> </div>

</asp:Content>

