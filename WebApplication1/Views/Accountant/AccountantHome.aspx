<%@ Page Title="Accountant Home Page" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="AccountantHome.aspx.cs" Inherits="WebApplication1.Views.Accountant.AccountantHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Accountant Home Page</h1>
         <div class="form-horizontal">
              
             <asp:Button ID="ChangePassword" runat="server" Text="Change Password" OnClick="ChangePassword_Acc" />
              
          </div>
    </div>

</asp:Content>
