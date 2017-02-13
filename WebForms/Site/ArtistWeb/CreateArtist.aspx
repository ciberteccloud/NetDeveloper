<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.CreateArtist" %>

<asp:Content ID="ArtistContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Artist Name:" />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>        
    </div>
    <div class="row">
        <div>
            <asp:Button CssClass="btn btn-submit" runat="server" ID="btnCreate" Text="Create" OnClick="btnCreate_Click" />
        </div>
    </div>
</asp:Content>
