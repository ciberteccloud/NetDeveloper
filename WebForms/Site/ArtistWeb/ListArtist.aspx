<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantainTemplate.master" AutoEventWireup="true" CodeBehind="ListArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.ListArtist" %>

<asp:Content ID="ButtonContent" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="CreateArtist.aspx">
        <span class="glyphicon glyphicon-plus"></span> Create Artist
    </a>
</asp:Content>
<asp:Content ID="ListContent" ContentPlaceHolderID="ArtistContent" runat="server">
    <div class="row">
        <h3>Artist List</h3>
    </div>    
</asp:Content>
