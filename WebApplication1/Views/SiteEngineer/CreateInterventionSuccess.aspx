<%@ Page Title="Create Intervention Success" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="CreateInterventionSuccess.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.CreateInterventionSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="New Intervention was successfully created !"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="View Intervention List" OnClick="Button1_Click" />
    </p>
</asp:Content>
