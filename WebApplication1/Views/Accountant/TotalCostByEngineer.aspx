<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="TotalCostByEngineer.aspx.cs" Inherits="WebApplication1.Views.Accountant.TotalCostByEngineer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="Total Costs By Engineer: "></asp:Label>
    <p>
        </p>
            <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="false" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="User ID" SortExpression="UserId" />
                <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                <asp:BoundField DataField="RoleName" HeaderText="User Role" SortExpression="RoleName" />
                <asp:BoundField DataField="TotalCosts" HeaderText="Total Cost" SortExpression="TotalCosts" />
                <asp:BoundField DataField="TotalHours" HeaderText="Total Hours" SortExpression="TotalHours" />
            </Columns>
        </asp:GridView>



</asp:Content>
