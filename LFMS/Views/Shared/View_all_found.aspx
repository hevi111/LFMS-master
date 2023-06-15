<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_all_found.aspx.cs" Inherits="LFMS.Views.Employee.View_all_found" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<br />
    <div class="form-group">
       
        <div class="col-sm-12">
            <asp:TextBox style ="min-width:60%" runat="server" ID="text" type="text" class="form-control" placeholder="Search for item (title based)"/>
            <br />
            <br />
        </div>

    </div>
<br />

    <h2><b> All Found Items</b></h2> <asp:Label ID="empLabel" runat="server" Font-Size="Large"></asp:Label>
<hr />

<br />
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="noFoundItemLabel" runat="server" Font-Size="Large"></asp:Label>
 <asp:GridView ID="AllFoundItemsGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" OnRowCommand="SelectFound_RowCommand" OnRowDeleting="RecentFoundGrid_RowDeleting1"
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="founddate" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:ButtonField Text="View Details" ControlStyle-CssClass="btn btn-primary" CommandName="Select" ItemStyle-HorizontalAlign="Right" ButtonType="Button" />
    <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger"  ButtonType="Button" />
  
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
               <asp:Timer ID="Timer1" runat="server" Interval="500" OnTick="Timer1_Tick"></asp:Timer>
                </ContentTemplate>
                    </asp:UpdatePanel>
                    

</asp:Content>
