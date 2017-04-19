<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInterventions.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.ViewInterventions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Intervention List: "></asp:Label>
    </p>
    <p>


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="InterventionTypeName" HeaderText="InterventionTypeName" SortExpression="InterventionTypeName" />
                <asp:BoundField DataField="InterventionTypeHour" HeaderText="InterventionTypeHour" SortExpression="InterventionTypeHour" />
                <asp:BoundField DataField="InterventionTypeCost" HeaderText="InterventionTypeCost" SortExpression="InterventionTypeCost" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [InterventionTypeName], [InterventionTypeHour], [InterventionTypeCost] FROM [InterventionType]"></asp:SqlDataSource>


    </p>
</asp:Content>
