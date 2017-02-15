<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantainTemplate.master" AutoEventWireup="true" CodeBehind="CreateArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.CreateArtist" %>

<asp:Content ID="ButtonContent" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="ListArtist.aspx">
        <span class="glyphicon glyphicon-hand-left"></span> Return 
    </a>
</asp:Content>
<asp:Content ID="ArtistContent" ContentPlaceHolderID="ArtistContent" runat="server">
    <h2>Create New Artist</h2>    
</asp:Content>
