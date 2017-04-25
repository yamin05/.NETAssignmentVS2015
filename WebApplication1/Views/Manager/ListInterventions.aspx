<%@ Page Title="Intervention List" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ListInterventions.aspx.cs" Inherits="WebApplication1.Views.Manager.ListInterventions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataKeyNames="UserId" DataSourceID="SqlDataSource1" Height="131px" Width="228px">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" SortExpression="UserId" InsertVisible="False" />
                <asp:HyperLinkField DataNavigateUrlFields="FirstName" DataNavigateUrlFormatString="/Views/Manager/ManagerHome.aspx" DataTextField="FirstName" HeaderText="First Name" NavigateUrl="~/Views/Manager/ManagerHome.aspx" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="MaximunHours" HeaderText="MaximunHours" SortExpression="MaximunHours" />
                <asp:BoundField DataField="MaximunCosts" HeaderText="MaximunCosts" SortExpression="MaximunCosts" />
                <asp:BoundField DataField="District" HeaderText="District" SortExpression="District" />
            </Columns>
        </asp:GridView>
                </p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [UserId], [FirstName], [LastName], [MaximunHours], [MaximunCosts], [District] FROM [Users]"></asp:SqlDataSource>
        <asp:Table ID="Table1" runat="server" Height="112px" Width="374px">
        </asp:Table>
        <br />
        <br />
    
    </div>
    

    </asp:Content>