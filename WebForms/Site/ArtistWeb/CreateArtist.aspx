<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantainTemplate.master" AutoEventWireup="true" CodeBehind="CreateArtist.aspx.cs" Inherits="WebForms.Site.ArtistWeb.CreateArtist" %>

<asp:Content ID="ButtonContent" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="ListArtist.aspx">
        <span class="glyphicon glyphicon-hand-left"></span>Return 
    </a>
</asp:Content>
<asp:Content ID="ArtistContent" ContentPlaceHolderID="ArtistContent" runat="server">
    <div id="success" class="alert alert-success" role="alert">
        <strong>Success!</strong> The record was created.
    </div>
    <div id="error" class="alert alert-danger" role="alert">
        <strong>Error!</strong> The record was not created, contact an administrator.
    </div>
    <div class="row">
        <div>
            <label>Artist Name:" </label>
            <input type="text" required="required" id="Name" />
        </div>
    </div>
    <div class="row">
        <div>
            <button class="btn btn-submit" onclick="insertArtist(); return false;">Create</button>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('.alert').hide();                      
        })

        function insertArtist() {
            $('.alert').hide();
            var name = document.getElementById('Name').value;
            $.ajax({
                type: "POST",
                url: 'CreateArtist.aspx/InsertArtist',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: "{ 'name':'" + name + "' }",
                success: function (data, status, xhr) {
                    if(data.d==true)
                    {                        
                        $('#success').show();
                    }
                },
                error: function (xhr, status, error) {
                    $('#error').show();
                }
            });
        }
    </script>
</asp:Content>
