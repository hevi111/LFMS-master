<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="View_department_items.aspx.cs" Inherits="LFMS.Views.Student.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%= departmentName %> Department</h1>
<br />
    <h2><b>All Lost Items</b></h2>
<hr />
    <asp:Label ID="noLostItemLabel" runat="server" Font-Size="Large"></asp:Label>
 <asp:GridView ID="AllLostItemsDepartmentGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black"  OnRowCommand="SelectLost_RowCommand"
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2"/>
  <Columns>
    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="lostdate" ItemStyle-Width="12%" HeaderText="Date"  ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary" CommandName="Select" ItemStyle-HorizontalAlign="Right" ButtonType="Button" />

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

    <h2><b>All Found Items</b></h2>
<hr />
    <asp:Label ID="noFoundItemLabel" runat="server" Font-Size="Large"></asp:Label>
 <asp:GridView ID="AllFoundItemsDepartmentGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" OnRowCommand="SelectFound_RowCommand"
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2"/>
  <Columns>
      <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="founddate" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary" CommandName="Select" ItemStyle-HorizontalAlign="Right" ButtonType="Button" />


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