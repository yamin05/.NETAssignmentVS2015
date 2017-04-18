<%@ Page Title="Manager Home Page" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ManagerOperation.aspx.cs" Inherits="WebApplication1.Views.Manager.ManagerHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Manager Operation</h1>
    </div>
    <div>
        
        <div>
            Intervention<div class="col-md-10">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Enabled="False" Height="50px" TextMode="Password" Width="232px" />
            </div>
        </div>
        
    </div>

    <br />
    <div >
        Cost<div class="col-md-10">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Enabled="False" Height="50px" TextMode="Password" Width="232px" />
        </div>
    </div>
    <div >
        Hour<div class="col-md-10">
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Enabled="False" Height="50px" TextMode="Password" Width="229px" />
        </div>
    </div>
    <br />
    <div style="width: 728px">
        Status<div class="col-md-10">
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Proposed</asp:ListItem>
                <asp:ListItem>Approved</asp:ListItem>
                <asp:ListItem>Cancelled</asp:ListItem>
            </asp:DropDownList>
        </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Submit" runat="server" Text="Submit" />
    </div>

    <div style="width: 728px">

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    </div>

</asp:Content>
