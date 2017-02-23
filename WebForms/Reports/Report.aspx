<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WebForms.Reports.Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="asp-dropdown row">
                <span class="col-md-2">Select User Email: </span>
                <span class="col-md-6">
                    <asp:DropDownList AutoPostBack="true" CssClass="dropdown" ID="EmailDropDown" runat="server"
                        OnSelectedIndexChanged="EmailDropDown_SelectedIndexChanged"
                        OnTextChanged="EmailDropDown_SelectedIndexChanged">
                    </asp:DropDownList>
                </span>
            </div>
            <div class="asp-dropdown row">
                <span class="col-md-2">Select Invoice: </span>
                <span class=" col-md-6">
                    <asp:DropDownList AutoPostBack="true" CssClass="dropdown" ID="InvoiceDropDown" runat="server" OnSelectedIndexChanged="InvoiceDropDown_SelectedIndexChanged"></asp:DropDownList>
                </span>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <rsweb:ReportViewer ID="InvoiceReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ShowFindControls="False" ShowPrintButton="False" ShowZoomControl="False" Width="832px">
    </rsweb:ReportViewer>
</asp:Content>
