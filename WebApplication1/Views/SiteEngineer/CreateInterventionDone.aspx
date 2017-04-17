<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateInterventionDone.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.CreateInterventionDone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="New Intervention was successfullu created !"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Go Back to Intervention List" OnClick="Button1_Click" />
    </p>
</asp:Content>
