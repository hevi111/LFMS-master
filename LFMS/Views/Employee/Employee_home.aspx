<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Employee_home.aspx.cs" Inherits="LFMS.Views.Employee.Employee_home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<asp:Label runat="server" Font-Bold="True" Font-Size="XX-Large" ID="depLabel"  >Department Label</asp:Label>
<hr />


    
    <h3><b> Recent Found Items</b></h3>
<hr />
     <asp:Label ID="noFoundItemLabel" runat="server" Font-Size="Large"></asp:Label>
 <asp:GridView ID="RecentFoundGrid" runat=server CssClass="table"  AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" 
  GridLines="None" OnRowDeleting="RecentFoundGrid_RowDeleting" OnRowCommand="SelectFound_RowCommand">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
    <asp:BoundField DataField="id" HeaderText="ID" Visible="true"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="founddate" DataFormatString="{0:MM/dd/yyyy hh:mm tt}" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary" CommandName="Select" ItemStyle-HorizontalAlign="Right" ButtonType="Button" />
    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" ButtonType="Button"   />
  </Columns>
  <FooterStyle BackColor="#cccccc" />
  <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="white"/>
  <PagerStyle BackColor="#cccccc" ForeColor="#333333" HorizontalAlign="Center" />
  <RowStyle BackColor="#ffffff" />
  <SelectedRowStyle BackColor="#333333" ForeColor="white" />
  <SortedAscendingCellStyle BackColor="#f2f2f2" />
  <SortedAscendingHeaderStyle BackColor="#333333" />
  <SortedDescendingCellStyle BackColor="#f2f2f2" />
  <SortedDescendingHeaderStyle BackColor="#333333" />
</asp:GridView>


<br />
<h3><b> Recent Lost Items</b></h3>
<hr />

<br />
    <asp:Label ID="noLostItemLabel" runat="server" Font-Size="Large"></asp:Label>
 <asp:GridView ID="RecentLostGrid" runat=server CssClass="table"  AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" OnRowCommand="SelectLost_RowCommand"
  GridLines="None" OnRowDeleting="RecentLostGrid_RowDeleting">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
     <asp:BoundField DataField="id" HeaderText="ID" Visible="true"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="lostdate" DataFormatString="{0:MM/dd/yyyy hh:mm tt}" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary" CommandName="Select" ItemStyle-HorizontalAlign="Right" ButtonType="Button" />
    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" ButtonType="Button"   />
  </Columns>
  <FooterStyle BackColor="#cccccc" />
  <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="white"/>
  <PagerStyle BackColor="#cccccc" ForeColor="#333333" HorizontalAlign="Center" />
  <RowStyle BackColor="#ffffff" />
  <SelectedRowStyle BackColor="#333333" ForeColor="white" />
  <SortedAscendingCellStyle BackColor="#f2f2f2" />
  <SortedAscendingHeaderStyle BackColor="#333333" />
  <SortedDescendingCellStyle BackColor="#f2f2f2" />
  <SortedDescendingHeaderStyle BackColor="#333333" />
</asp:GridView>

<br />



</asp:Content>
