<%@ Page Title="Intervention List" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ListInterventions.aspx.cs" Inherits="WebApplication1.Views.Manager.ListInterventions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  EmptyDataText="There are no interventions to Approve Or Cancel" Height="131px" Width="228px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
               
            </Columns>
        </asp:GridView>
        <asp:Table ID="Table1" runat="server" Height="112px" Width="374px">
        </asp:Table>
        <br />
        <br />
    
    </div>
    

    </asp:Content>