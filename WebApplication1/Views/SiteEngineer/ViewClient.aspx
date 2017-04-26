<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.ViewClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="Current Client List: "></asp:Label>
    </p>
    <p>
        </p>
    <p>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ClientId" HeaderText="Client ID" SortExpression="ClientName" />
                <asp:BoundField DataField="ClientName" HeaderText="Client Name" SortExpression="ClientName" />
                <asp:BoundField DataField="ClientLocation" HeaderText="Client Location" SortExpression="ClientLocation" />
                <asp:BoundField DataField="ClientDistrict" HeaderText="Client District" SortExpression="ClientDistrict" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="AddClient" runat="server" Text="Add client" OnClick="AddClient_Click" />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
