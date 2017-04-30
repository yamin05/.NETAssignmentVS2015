<%@ Page Title="Edit Quality Management Info" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="EditQMInfoIntervention.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.EditQMInfoIntervention" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    </p>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" font-size="Large" runat="server" Text="Edit Quality Management Information: "></asp:Label>

    <p>
        <asp:Label ID="Label2" font-size="Small" runat="server" Text="Comments: "></asp:Label>
    </p>
    <p>
        <asp:TextBox id="Comments" TextMode="multiline" Columns="100" Rows="10" runat="server" />
    </p>
    <p>
        <asp:Label ID="Label3" font-size="Small" runat="server" Text="Remaining Life in %: "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="Condition" runat="server" Width="300px"></asp:TextBox>    
    </p>
    <p>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Condition"  ErrorMessage="The Remaining Life is required." style="color:brown" />
    </p>
        <p>
        <asp:RangeValidator  runat="server" 
            ControlToValidate="Condition" ErrorMessage="Please enter correct number" MaximumValue="100" 
            MinimumValue="0" style="color:brown" ></asp:RangeValidator>
</p>
    
    <p>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="NewClientSubmit_Click" />
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="PreviousUpdatesLabel" font-size="Small" runat="server" Text="Previous Updates: "></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="InterventionUpdateId" HeaderText="Intervention Update ID" SortExpression="InterventionUpdateId" />
                <asp:BoundField DataField="Condition" HeaderText="Condition" SortExpression="Condition" />
                <asp:BoundField DataField="ModifyDate" HeaderText="Date Modified" SortExpression="ModifyDate" />
                <asp:BoundField DataField="InterventionCommments" HeaderText="Commments" SortExpression="InterventionCommments" />
            </Columns>
            <selectedrowstyle backcolor="LightCyan"
                forecolor="DarkBlue"
                font-bold="true"/> 
        </asp:GridView>
    </p>
</asp:Content>
