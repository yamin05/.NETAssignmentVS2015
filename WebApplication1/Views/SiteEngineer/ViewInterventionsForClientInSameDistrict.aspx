<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ViewInterventionsForClientInSameDistrict.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.ViewInterventionsForClientInSameDistrict" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
        <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Intervention List For Client: "></asp:Label>
        <asp:Label ID="ClientName" font-size="Large" runat="server" Text=""></asp:Label>

    <p>
        <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="true" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="InterventionTypeName" HeaderText="Type Name" SortExpression="InterventionTypeName" />
                <asp:BoundField DataField="InterventionHours" HeaderText="Hours" SortExpression="InterventionHours" />
                <asp:BoundField DataField="InterventionCost" HeaderText="Cost" SortExpression="InterventionCost" />
                <asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="CreatedBy" />
                <asp:BoundField DataField="CreateDate" HeaderText="Date Created" SortExpression="CreateDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
            <selectedrowstyle backcolor="LightCyan"
                forecolor="DarkBlue"
                font-bold="true"/> 
        </asp:GridView>
    </p>
    <hr />
    <p>
        <asp:Button ID="Button2" runat="server" Text="Change State" OnClick="ChangeState_Click" Width="300px" />
        <asp:DropDownList id="Status" AutoPostBack="True" runat="server" Visible="false"/>
        <asp:Button ID="UpdateButton" runat="server" Text="Update State" OnClick="UpdateButton_Click" Width="300px" Visible="false"/>
    </p>
    <hr />
    <p>
        <asp:Button ID="Button3" runat="server" Text="Edit Quality Management Information" OnClick="EditQMInfo_Click" Width="300px" />
    </p>
</asp:Content>

