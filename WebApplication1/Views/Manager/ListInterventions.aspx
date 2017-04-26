<%@ Page Title="Intervention List" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ListInterventions.aspx.cs" Inherits="WebApplication1.Views.Manager.ListInterventions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  EmptyDataText="There are no interventions to Approve Or Cancel" Height="131px" Width="228px" >
        
        <Columns>
        <asp:BoundField DataField="InterventionId" HeaderText="InterventionId" />
        <asp:BoundField DataField="ClientId" HeaderText="ClientId" />
        <asp:BoundField DataField="InterventionCost" HeaderText="InterventionCost" />
        <asp:BoundField DataField="InterventionHour" HeaderText="Date" />
        <asp:BoundField DataField="CreateDate" HeaderText="InterventionHour" />
        <asp:BoundField DataField="Status" HeaderText="Status" />            
        </Columns>
        
        </asp:GridView>
        </p>
        <br />
        <br />
    
    </div>
    

    </asp:Content>