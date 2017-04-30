<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="WebApplication1.Views.Accountant.UsersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="Current Users List: "></asp:Label>
    <p>
        </p>
            <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="true" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="User ID" SortExpression="UserId" />
                <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                <asp:BoundField DataField="RoleName" HeaderText="User Role" SortExpression="RoleName" />
                <asp:BoundField DataField="MaximumCost" HeaderText="Maximum Cost" SortExpression="MaximumCost" />
                <asp:BoundField DataField="MaximumHours" HeaderText="Maximum Hours" SortExpression="MaximumHours" />
                <asp:BoundField DataField="District" HeaderText="District" SortExpression="District" />
                <asp:BoundField DataField="DistrictName" HeaderText="District Name" SortExpression="DistrictName" />
            </Columns>
            <selectedrowstyle backcolor="LightCyan"
                forecolor="DarkBlue"
                font-bold="true"/> 
        </asp:GridView>

    <hr />
    <p>
        <asp:Button ID="ChangeDistrict" runat="server" Text="Change District" OnClick="ChangeDistrict_Click" Width="300px" />
        <asp:DropDownList id="District" AutoPostBack="True" runat="server" Visible="false"/>
        <asp:Button ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" Width="300px" Visible="false"/>
        <asp:Button ID="Cancel" runat="server" Text="Cancel" Width="300px" Visible="false"/>
    </p>
</asp:Content>
