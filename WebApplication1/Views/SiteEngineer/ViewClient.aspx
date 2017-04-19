<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.ViewClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="Current Client List: "></asp:Label>
    </p>
    <p>
        </p>
    
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ClientName" HeaderText="ClientName" SortExpression="ClientName" />
                <asp:BoundField DataField="ClientLocation" HeaderText="ClientLocation" SortExpression="ClientLocation" />
                <asp:BoundField DataField="ClientDistrict" HeaderText="ClientDistrict" SortExpression="ClientDistrict" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ClientName], [ClientLocation], [ClientDistrict] FROM [Clients]"></asp:SqlDataSource>
    </p>
    <p>

        <asp:Button ID="AddClient" runat="server" Text="Add client" OnClick="AddClient_Click" />

    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
