<%@ Page Title="Manager Home Page" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ManagerHome.aspx.cs" Inherits="WebApplication1.Views.Manager.ManagerHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Manager Home Page</h1>
         <div class="form-horizontal">
              
             <asp:Button ID="ChangePassword" runat="server" Text="Change Password" OnClick="ChangePassword_Click" />
             <asp:Button ID="ListOfIntervention" runat="server" Text="Change Password" OnClick="Manager_Intervention_List_Click" />
            
          </div>
    </div>

</asp:Content>
