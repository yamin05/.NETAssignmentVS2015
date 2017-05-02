<%@ Page Title="Intervention List" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Main.Master" CodeBehind="ListInterventions.aspx.cs" Inherits="WebApplication1.Views.Manager.ListInterventions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="List of Proposed Interventions: "></asp:Label>
    </p>
    <p>
    <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no interventions to Approve Or Cancel">
            <Columns>
               <asp:BoundField DataField="ClientName" HeaderText="Client Name" SortExpression="ClientName" />
                <asp:BoundField DataField="InterventionTypeName" HeaderText="Intervention Name" SortExpression="InterventionTypeName" />
                <asp:BoundField DataField="InterventionHours" HeaderText="Hours" SortExpression="InterventionHours" />
                <asp:BoundField DataField="InterventionCost" HeaderText="Cost" SortExpression="InterventionCost" />
                <asp:BoundField DataField="CreateDate" HeaderText="Date Created" SortExpression="CreateDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        <asp:TemplateField HeaderText="Select Intervention to Apprrove Or Cancel ">
                <ItemTemplate>
                <asp:HyperLink ID="lnkSelect" runat='server' NavigateUrl='<%# String.Format("ManagerOperation.aspx?ID={0}&Status={1}&UID={2}", Eval("InterventionId"), Eval("Status"), HttpContext.Current.User.Identity.GetUserId()) %>'>Select Intervention</asp:HyperLink>
                </ItemTemplate>
        </asp:TemplateField>
            </Columns>
     </asp:GridView>
        
     </p>
    </asp:Content>