<%@ Page Title="Approve or cancel the below intervention" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ManagerOperation.aspx.cs" Inherits="WebApplication1.Views.Manager.ManagerOperation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
      <p>
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Please Approve or cancel the below intervention " CssClass="Manager"></asp:Label>
    </p>
    <asp:Label ID="Label2" font-size="Large" runat="server"></asp:Label>
    <p>
       <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no interventions to Approve Or Cancel" AlternatingRowStyle-HorizontalAlign="Justify" Font-Bold="true" CssClass="Manager">
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
        <div>
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Justify"> 
                <asp:button id="approve" runat="server"  Text="Approve" OnClick="Approve" CssClass="Button"/>
                <asp:button id="cancel" runat="server"  Text="Cancel" OnClick="Cancel" CssClass="Button"/>
                <asp:button id="backtolist" runat="server"  Text="Back To Prposed Interventions" OnClick="GotoList" CssClass="Manager"/>
                <asp:button id="backtolist1" runat="server"  Text="Back To Prposed Interventions" OnClick="GotoList" CssClass="Manager"/>
        </asp:Panel>
        </div>
     <style>
    .Manager 
    {
        margin-top:15px;
        margin-left:5px;
    }
    </style>
</asp:Content>

