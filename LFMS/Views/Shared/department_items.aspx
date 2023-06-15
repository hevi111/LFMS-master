<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="department_items.aspx.cs" Inherits="LFMS.Views.Shared.department_items" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<br />

    <h2><b>All Lost Items in <= departmentName %> Department</b></h2>
<hr />

<br />
 <asp:GridView ID="AllLostItemsDepartmentGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" 
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2"/>
  <Columns>
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="lostdate" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary"   ButtonType="Button" />

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

    <h2><b>All Found Items in < //Deartment> Department</b></h2>
<hr />

<br />
 <asp:GridView ID="AllFoundItemsDepartmentGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" 
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2"/>
  <Columns>
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="lostdate" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary"   ButtonType="Button" />

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
</asp:Content>