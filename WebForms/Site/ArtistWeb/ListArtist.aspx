<%@ Page Title="" Language="C#" MasterPageFile="~/Site/ArtistWeb/ArtistMasterPage.master" AutoEventWireup="true" CodeBehind="ListArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.ListArtist" %>

<asp:Content ID="ButtonContent" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="CreateArtist.aspx">
        <span class="glyphicon glyphicon-plus"></span> Crear Artist
    </a>
</asp:Content>
<asp:Content ID="ListContent" ContentPlaceHolderID="ArtistContent" runat="server">
    <div class="row">
        <h3>Lista de Artistas</h3>
    </div>

    <div class="row">
        <asp:GridView ID="artistGridView" runat="server"
            AllowCustomPaging="True"
            AllowPaging="True"
            AllowSorting="True"
            CellPadding="4"
            ForeColor="#333333"
            GridLines="None" OnPageIndexChanged="GetPage">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
    </div>
</asp:Content>
