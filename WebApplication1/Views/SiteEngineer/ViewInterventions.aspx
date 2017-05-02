<%@ Page Title="View Intervention" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ViewInterventions.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.ViewInterventions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Intervention List: "></asp:Label>
   
    <p>
        <asp:GridView ID="GridView" runat="server" AutoGenerateSelectButton="true" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged1">
            <Columns>
                <asp:BoundField DataField="ClientName" HeaderText="Client Name" SortExpression="ClientName" />
                <asp:BoundField DataField="InterventionTypeName" HeaderText="Type Name" SortExpression="InterventionTypeName" />
                <asp:BoundField DataField="InterventionHours" HeaderText="Hours" SortExpression="InterventionHours" />
                <asp:BoundField DataField="InterventionCost" HeaderText="Cost" SortExpression="InterventionCost" />
                <asp:BoundField DataField="CreateDate" HeaderText="Date Created" SortExpression="CreateDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="InterventionId" HeaderText="InterventionId" SortExpression="InterventionId" />
            </Columns>
            <selectedrowstyle backcolor="LightCyan"
                forecolor="DarkBlue"
                font-bold="true"/> 
        </asp:GridView>
    </p>
    <hr />
    <p>
        <asp:Button ID="Button2" runat="server" Text="Change State" OnClick="ChangeState_Click" Width="300px" />
        <asp:DropDownList id="Sts" AutoPostBack="True" runat="server" Visible="false" />
        <asp:Button ID="UpdateButton" runat="server" Text="Update State" OnClick="UpdateButton_Click" Width="300px" Visible="false"/>
    </p>
    <hr />
    <p>
        <asp:Button ID="QMInfoButton" runat="server" Text="Edit Quality Management Information" OnClick="EditQMInfo_Click" Width="300px" />
    </p>
</asp:Content>
