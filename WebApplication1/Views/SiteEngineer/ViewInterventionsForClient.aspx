<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ViewInterventionsForClient.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.ViewInterventionsForClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Intervention List For Client: "></asp:Label>
        <asp:Label ID="ClientName" font-size="Large" runat="server" Text=""></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="InterventionTypeName" HeaderText="Type Name" SortExpression="InterventionTypeName" />
                <asp:BoundField DataField="InterventionHours" HeaderText="Hours" SortExpression="InterventionHours" />
                <asp:BoundField DataField="InterventionCost" HeaderText="Cost" SortExpression="InterventionCost" />
                <asp:BoundField DataField="CreateDate" HeaderText="Date Created" SortExpression="CreateDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>

