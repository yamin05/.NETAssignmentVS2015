<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="WebApplication1.Views.ChangePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Change Password</h1>
    </div>
    <div>                   
                        <div class="col-md-10">
                             <asp:Label runat="server"  CssClass="col-md-2 control-label" ID="Label1">Old Password</asp:Label>
                            <asp:TextBox runat="server" ID="TextBox1" TextMode="Password" CssClass="form-control" Height="50px" Width="232px" />
                        </div>
    </div>
    <div>
                        
                        <div class="col-md-10">
                            <asp:Label runat="server"  CssClass="col-md-2 control-label" ID="Label2">New Password</asp:Label>
                            <asp:TextBox runat="server" ID="TextBox2" TextMode="Password" CssClass="form-control" Height="50px" Width="232px" />
                        </div>
    </div>
    <div>
                        
                        <div class="col-md-10">
                            <asp:Label runat="server"  CssClass="col-md-2 control-label" ID="Label3">Confirm New Password</asp:Label>
                            <asp:TextBox runat="server" ID="TextBox3" TextMode="Password" CssClass="form-control" Height="50px" Width="232px" />
                        </div>
    </div>
    <div>
    &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server"  Text="Back" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" OnClick="Button2_click" runat="server" Text="Confirm" />
    </div>

</asp:Content>
