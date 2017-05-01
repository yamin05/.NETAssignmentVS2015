<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="CostByDistrict.aspx.cs" Inherits="WebApplication1.Views.Accountant.CostByDistrict" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="Costs By District Report"></asp:Label>
    <p>
        </p>
            <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="false" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DistrictId" HeaderText="District ID" SortExpression="DistrictId" />
                <asp:BoundField DataField="DistrictName" HeaderText="District Name" SortExpression="DistrictName" />
                <asp:BoundField DataField="Costs" HeaderText="Cost" SortExpression="Costs" />
                <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" />
            </Columns>
        </asp:GridView>


</asp:Content>
