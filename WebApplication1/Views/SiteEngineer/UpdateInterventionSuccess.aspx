<%@ Page Title="Update Intervention Success" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="UpdateInterventionSuccess.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.UpdateInterventionSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Intervention was successfully updated!"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="View Intervention List" OnClick="Button1_Click" />
    </p>
</asp:Content>
