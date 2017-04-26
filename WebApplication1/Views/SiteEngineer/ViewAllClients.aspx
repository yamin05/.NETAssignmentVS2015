<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ViewAllClients.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.ViewAllClients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="Current Client List: "></asp:Label>
    </p>
    <p>
        </p>
    <p>
        <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="true" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ClientId" HeaderText="Client ID" SortExpression="ClientName" />
                <asp:BoundField DataField="ClientName" HeaderText="Client Name" SortExpression="ClientName" />
                <asp:BoundField DataField="ClientLocation" HeaderText="Client Location" SortExpression="ClientLocation" />
                <asp:BoundField DataField="ClientDistrict" HeaderText="Client District" SortExpression="ClientDistrict" />
            </Columns>
            <selectedrowstyle backcolor="LightCyan"
                forecolor="DarkBlue"
                font-bold="true"/> 
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="AddClient" runat="server" Text="Add client" OnClick="AddClient_Click" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="View associated Interventions" OnClick="ViewAssociatedInterventions_Click" Width="300px" />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
