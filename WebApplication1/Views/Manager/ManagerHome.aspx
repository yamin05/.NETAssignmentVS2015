<%@ Page Title="Manager Home Page" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="ManagerHome.aspx.cs" Inherits="WebApplication1.Views.Manager.ManagerHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<p>
<br/>
        <asp:Label ID="Label1" runat="server" font-size="X-Large" Text="Manager Home Page"></asp:Label>
    </p>
         <div class="form-horizontal">
              <p>
             <asp:Button ID="ChangePassword" runat="server" Text="Change Password" OnClick="ChangePassword_Click" Width="400px" />
                </p>
             <p>
             <asp:Button ID="ListOfIntervention" runat="server" Text="List of Proposed Interventions" OnClick="Manager_Intervention_List_Click" Width="400px" />
            </p>
          </div>
    

</asp:Content>
