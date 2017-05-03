﻿<%@ Page Title="Accountant Home Page" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="AccountantHome.aspx.cs" Inherits="WebApplication1.Views.Accountant.AccountantHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" font-size="Large" Text="Accountant Home Page"></asp:Label>
    </p>

             <p>
             <asp:Button ID="ChangePassword" runat="server" Text="Change Password" OnClick="ChangePassword_Click" Width="400px" />
             </p>
             <p>
             <asp:Button ID="UsersList" runat="server" Text="UsersList" OnClick="UsersList_Click" Width="400px" />
             </p>
             <p>
             <asp:Button ID="TotalCostByEngineer" runat="server" Text="Total Costs by Engineer Report" OnClick="TotalCostByEngineer_Click" Width="400px" />
             </p>
             <p>
             <asp:Button ID="AverageCostByEngineer" runat="server" Text="Average Costs by Engineer Report" OnClick="AverageCostByEngineer_Click" Width="400px" />
             </p>
             <p>
             <asp:Button ID="CostByDistrict" runat="server" Text="Costs by District Report" OnClick="CostByDistrict_Click" Width="400px" />
             </p>
             <p>
             <asp:Button ID="MonthlyCostForDistrict" runat="server" Text="Monthly Costs for District Report" OnClick="MonthlyCostForDistrict_Click" Width="400px" />
             </p>
  

</asp:Content>
