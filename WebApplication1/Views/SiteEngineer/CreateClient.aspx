<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="CreateClient.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.CreateClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Create New Client: "></asp:Label>

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
