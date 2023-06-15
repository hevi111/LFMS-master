<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="Student_home.aspx.cs" Inherits="LFMS.Views.WebForm1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<h2><b> List Of Departments</b></h2>
<hr />

<asp:GridView ID="AllDepartmentsGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="2px" CellPadding="12" ForeColor="Black" OnRowCommand="SelectDep_RowCommand" GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
    <asp:BoundField DataField="id" HeaderText="id" Visible="false" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="name" HeaderText="Department Name"  InsertVisible="False" ReadOnly="True" />
   <asp:ButtonField Text="View Items" CommandName="Select" ControlStyle-CssClass="btn btn-primary" ItemStyle-HorizontalAlign="Right"  ButtonType="Button" />

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

<h2><b> Recent Lost Items</b></h2>
<hr />

<br />
 <asp:GridView ID="RecentLostGrid" runat=server CssClass="table"  AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" 
  GridLines="None" OnRowCommand="SelectLost_RowCommand">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="lostdate" DataFormatString="{0:MM/dd/yyyy hh:mm tt}" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary" CommandName="Select"  ButtonType="Button" />

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

    <h2><b> Recent Found Items</b></h2>
<hr />

<br />
 <asp:GridView ID="RecentFoundGrid" runat=server CssClass="table"  AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" 
  GridLines="None" OnRowCommand="SelectFound_RowCommand">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="founddate" DataFormatString="{0:MM/dd/yyyy hh:mm tt}" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary" CommandName="Select"  ButtonType="Button" />
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