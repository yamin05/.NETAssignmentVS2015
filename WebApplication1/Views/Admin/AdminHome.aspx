<%@ Page Title="Admin Home Page" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="WebApplication1.Views.Admin.AdminHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Admin Home Page</h1>
         <div class="form-horizontal">
              
             <asp:Button ID="ChangePassword" runat="server" Text="Change Password" OnClick="ChangePassword_Click" />
              
          </div>
    </div>

</asp:Content>
