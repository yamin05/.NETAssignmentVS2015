<%@ Page Title="Create Intervention" Language="C#" MasterPageFile="~/Site.Main.Master" AutoEventWireup="true" CodeBehind="CreateIntervention.aspx.cs" Inherits="WebApplication1.Views.SiteEngineer.CreateIntervention" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <p>
        <asp:Label ID="Label5" font-size="Large" runat="server" Text="Create New Intervention: "></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" font-Size="Small" runat="server" Text="Intervention Name: "></asp:Label>
        <asp:DropDownList id="InterventionType"
                    AutoPostBack="True"
            OnSelectedIndexChanged="InterventionType_SelectedIndexChanged"
                    runat="server"/>
    </p>
    <p>
        <asp:Label ID="Label2" font-Size="Small" runat="server" Text="Client Name: "></asp:Label>
        <asp:DropDownList id="ClientName"
                    AutoPostBack="True"
                    runat="server"/>
    </p>
    <p>
        <asp:Label ID="Label7" font-Size="Small" runat="server" Text="Hours: "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="NewInterventionHours" runat="server" Width="300px"></asp:TextBox>
    </p>
       <p>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="NewInterventionHours"  ErrorMessage="The Hours is required." 
            style="color:brown"/>
    </p>
    <p>
     <asp:RangeValidator  runat="server" 
            ControlToValidate="NewInterventionHours" ErrorMessage="please enter correct hours" MaximumValue="10000" 
            MinimumValue="0" Type="Double" style="color:brown" ></asp:RangeValidator>
    </p>
    <p>
        <asp:Label ID="Label8" font-Size="Small" runat="server" Text="Cost: "></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="NewInterventionCost" runat="server" Width="300px"></asp:TextBox>
    </p>
      <p>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="NewInterventionCost"  ErrorMessage="The Cost Amount is required." 
            style="color:brown"/>
    </p>
    <p>
    <asp:RangeValidator  runat="server" 
            ControlToValidate="NewInterventionCost" ErrorMessage="please enter correct amount" MaximumValue="10000" 
            MinimumValue="0" Type="Currency" style="color:brown" ></asp:RangeValidator>
        </p>
    
    <p>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="NewInterventionSubmit_Click" />
    </p>
    
</asp:Content>
