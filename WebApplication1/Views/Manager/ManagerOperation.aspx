<%@ PreviousPageType VirtualPath="ListInterventions.aspx" %>
<%@ Page Title="Approve or cancel the below intervention" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ManagerOperation.aspx.cs" Inherits="WebApplication1.Views.Manager.ManagerOperation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Please Approve or cancel the below intervention "></asp:Label>
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
            </Columns>
        </asp:GridView>
        </p>
        <div>
        <asp:Panel ID="Panel1" runat="server"> 
                <asp:button id="approve" runat="server"  Text="Approve" OnClick="Approve"/>
                &nbsp;&nbsp;
                <asp:button id="Button1" runat="server"  Text="Cancel" OnClick="Cancel"/>
            &nbsp;&nbsp;
                <asp:button id="Button2" runat="server"  Text="Back To Prposed Interventions" OnClick="GotoList"/>
        </asp:Panel>
            </div>
</asp:Content>

