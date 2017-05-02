<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="AssociatedInterventions.aspx.cs" Inherits="WebApplication1.Views.Manager.AssociatedInterventions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="List of Associated Intervention With You "></asp:Label>
    </p>
    <p>
    <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no interventions associated with you">
            <Columns>
               <asp:BoundField DataField="ClientName" HeaderText="Client Name" SortExpression="ClientName" />
                <asp:BoundField DataField="InterventionTypeName" HeaderText="Intervention Name" SortExpression="InterventionTypeName" />
                <asp:BoundField DataField="InterventionHours" HeaderText="Hours" SortExpression="InterventionHours" />
                <asp:BoundField DataField="InterventionCost" HeaderText="Cost" SortExpression="InterventionCost" />
                <asp:BoundField DataField="CreateDate" HeaderText="Date Created" SortExpression="CreateDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
     </asp:GridView>
        
     </p>
</asp:Content>
