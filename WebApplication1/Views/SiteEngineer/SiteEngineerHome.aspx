<%@ Page Title="Site Engineer Home Page" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="SiteEngineerHome.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.SiteEngineerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" font-size="Large" Text="Site Engineer Home Page"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Create New Client" OnClick="CreateClient_Click" Width="400px" />
    </p>
    
    <p>
        <asp:Button ID="Button2" runat="server" Text="View All Clients" Width="400px" OnClick="ViewClient_Click" />
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="View All Clients In Same District" OnClick="ViewAllClientsInSameDistrict_Click" Width="400px" />
    </p>

    <hr/>

    <p>
        <asp:Button ID="Button3" runat="server" Text="Create New Intervention" Width="400px" OnClick="CreateIntervention_Click" />
   
    </p>

    <p>
        <asp:Button ID="Button5" runat="server" Text="View Interventions" Width="400px" OnClick="ViewInterventions_Click" />
    </p>

    <hr />

    <p>
        <asp:Button ID="Button7" runat="server" Onclick="Button7_Click" Text="Change Password" Width="400px" />
    </p>
    <p>
        &nbsp;</p>


</asp:Content>