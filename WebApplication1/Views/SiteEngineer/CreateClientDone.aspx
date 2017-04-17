<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateClientDone.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.CreateDone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="New Client was successfullu created !"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Go Back to Client List" OnClick="Button1_Click" />
    </p>
    <p>
    </p>
</asp:Content>
