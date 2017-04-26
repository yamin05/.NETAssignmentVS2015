<%@ Page Title="Intervention List" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Main.Master" CodeBehind="ListInterventions.aspx.cs" Inherits="WebApplication1.Views.Manager.ListInterventions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="List of Proposed Interventions: "></asp:Label>
    </p>
    <p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  EmptyDataText="There are no interventions to Approve Or Cancel"  >
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