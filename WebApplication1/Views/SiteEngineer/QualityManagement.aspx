<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="QualityManagement.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.QualityManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <p>
        <br />
        <asp:Label ID="Label1" runat="server" font-size="Large" Text="Quality Management: "></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" font-size="Small" Text="Notes: "></asp:Label>
    </p>

    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="218px" Width="375px"></asp:TextBox>
    </p>
       <p>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"  ErrorMessage="The Notes is required." style="color:brown" />
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" font-size="Small" Text="Remaining hours: "></asp:Label>
    </p>
   <p>
        <asp:Label ID="Label4" runat="server" font-size="Small" Text="Date: "></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Submit" Width="200" OnClick="Button1_Click" />
    </p>
    <p>
    </p>
</asp:Content>
