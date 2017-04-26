﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ViewInterventions.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.ViewInterventions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Intervention List: "></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ClientName" HeaderText="Client Name" SortExpression="ClientName" />
                <asp:BoundField DataField="InterventionTypeName" HeaderText="Type Name" SortExpression="InterventionTypeName" />
                <asp:BoundField DataField="InterventionHours" HeaderText="Hours" SortExpression="InterventionHours" />
                <asp:BoundField DataField="InterventionCost" HeaderText="Cost" SortExpression="InterventionCost" />
                <asp:BoundField DataField="CreateDate" HeaderText="Date Created" SortExpression="CreateDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="Change State" OnClick="ChangeState_Click" Width="300px" />
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" Text="Edit Quality Management Information" OnClick="EditQMInfo_Click" Width="300px" />
    </p>
</asp:Content>
