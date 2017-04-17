<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateIntervention.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.CreateIntervention" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <br />
        <p>
        <asp:Label ID="Label5" font-size="Large" runat="server" Text="Create New Intervention: "></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" font-Size="Small" runat="server" Text="Intervention Name: "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="NewInterventionName" runat="server" Width="300px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label7" font-Size="Small" runat="server" Text="Hours: "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="NewInterventionHours" runat="server" Width="300px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label8" font-Size="Small" runat="server" Text="Cost: "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="NewInterventionCost" runat="server" Width="300px"></asp:TextBox>
    </p>
    
    <p>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="NewInterventionSubmit_Click" />
    </p>
</asp:Content>
