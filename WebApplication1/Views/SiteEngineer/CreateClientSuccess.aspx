﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="CreateClientSuccess.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.CreateClientSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" font-size="Larger" runat="server" Text="New Client was successfully created !"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="View Client List" OnClick="Button1_Click" />
    </p>
    <p>
    </p>
</asp:Content>
