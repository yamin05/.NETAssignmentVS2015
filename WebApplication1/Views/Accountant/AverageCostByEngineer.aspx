<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="AverageCostByEngineer.aspx.cs" Inherits="WebApplication1.Views.Accountant.AverageCostByEngineer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="Average Costs By Engineer: "></asp:Label>
    <p>
        </p>
            <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="false" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="User ID" SortExpression="UserId" />
                <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                <asp:BoundField DataField="RoleName" HeaderText="User Role" SortExpression="RoleName" />
                <asp:BoundField DataField="AverageCosts" HeaderText="Average Cost" SortExpression="AverageCosts" />
                <asp:BoundField DataField="AverageHours" HeaderText="Average Hours" SortExpression="AverageHours" />
            </Columns>
        </asp:GridView>


</asp:Content>
