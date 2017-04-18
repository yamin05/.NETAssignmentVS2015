<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListInterventions.aspx.cs" Inherits="WebApplication1.Views.Manager.ListInterventions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" style="margin-right: 595px">
            <ItemTemplate>
                UserName:
                <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                <br />
                UserPassword:
                <asp:Label ID="UserPasswordLabel" runat="server" Text='<%# Eval("UserPassword") %>' />
                <br />
                FirstName:
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                <br />
                LastName:
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                <br />
                MaximunHours:
                <asp:Label ID="MaximunHoursLabel" runat="server" Text='<%# Eval("MaximunHours") %>' />
                <br />
                MaximunCosts:
                <asp:Label ID="MaximunCostsLabel" runat="server" Text='<%# Eval("MaximunCosts") %>' />
                <br />
                Roles:
                <asp:Label ID="RolesLabel" runat="server" Text='<%# Eval("Roles") %>' />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId" DataSourceID="SqlDataSource1" Height="131px" Width="228px">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" SortExpression="UserId" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="UserPassword" HeaderText="UserPassword" SortExpression="UserPassword" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Roles" HeaderText="Roles" SortExpression="Roles" />
                <asp:BoundField DataField="MaximunHours" HeaderText="MaximunHours" SortExpression="MaximunHours" />
                <asp:BoundField DataField="MaximunCosts" HeaderText="MaximunCosts" SortExpression="MaximunCosts" />
                <asp:BoundField DataField="District" HeaderText="District" SortExpression="District" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IMSConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
        <asp:Table ID="Table1" runat="server" Height="112px" Width="374px">
        </asp:Table>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
