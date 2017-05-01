<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="MonthlyCostForDistrict.aspx.cs" Inherits="WebApplication1.Views.Accountant.MonthlyCostForDistrict" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DropDownList id="District" AutoPostBack="True" runat="server" Visible="true"/>
    <asp:Button ID="Confirm" runat="server" Text="Confirm"  OnClick="Confirm_Click"  Width="300px" Visible="true"/>


    <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="False" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DistrictId" HeaderText="District ID" SortExpression="DistrictId" />
                <asp:BoundField DataField="DistrictName" HeaderText="District Name" SortExpression="DistrictName" />
                <asp:BoundField DataField="Month" HeaderText="User Role" SortExpression="RoleName" />
                <asp:BoundField DataField="MonthlyCosts" HeaderText="Costs" SortExpression="MonthlyCosts" />
                <asp:BoundField DataField="MonthlyHours" HeaderText="Hours" SortExpression="MonthlyHours" />
            </Columns>
            <selectedrowstyle backcolor="LightCyan"
                forecolor="DarkBlue"
                font-bold="true"/> 
        </asp:GridView>
</asp:Content>
