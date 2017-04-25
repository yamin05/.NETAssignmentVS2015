<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateClient.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.CreateClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Create New Client: "></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" font-size="Small" runat="server" Text="Name: "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="NewClientName" runat="server" Width="300px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" font-size="Small" runat="server" Text="Address or Other Location Information: "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="NewClientAddress" runat="server" Width="300px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label4" font-Size="Small" runat="server" Text="District: "></asp:Label>
    </p>
    <p>
        <%--<asp:DropDownList ID="NewClientDistrict" runat="server">
        <asp:ListItem Value=1>Urban Indonesia</asp:ListItem>
        <asp:ListItem Value=2>Rural Indonesia</asp:ListItem>
        <asp:ListItem Value=3>Urban Papua New Guinea</asp:ListItem>
        <asp:ListItem Value=4>Rural Papua New Guinea</asp:ListItem>
        <asp:ListItem Value=5>Sydney</asp:ListItem>
            
        <asp:ListItem Value=6>Rural New South Wales</asp:ListItem>
        </asp:DropDownList>--%>
        <asp:DropDownList id="NewClientDistrict"
                    AutoPostBack="True"
                    runat="server"/>
    </p>
    <p>
    </p>
    
    <p>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="NewClientSubmit_Click" />
    </p>
    <p>
    </p>
</asp:Content>
