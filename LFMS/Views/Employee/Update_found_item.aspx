<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update_found_item.aspx.cs" Inherits="LFMS.Views.Employee.Update_found_item" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <h2><b>Update <=Title> item</b></h2>
    <hr />
<div class="form-group">
        <div class="col-sm-4">
            <b style="font-size: 20px">Title:</b> <br /><br />
            <asp:TextBox runat="server" ID="text" type="text" class="form-control" placeholder="title"/>
        </div>
        <div class="col-sm-4">
           <b style="font-size: 20px">Description</b> <br /><br />
            <asp:TextBox runat="server" ID="TextBox1" TextMode="MultiLine"  type="text" class="form-control" placeholder="MinVal"/>
            <br />
        </div>

    
  
        <div class="col-sm-4">
           <b style="font-size: 20px">Location:</b> <br /><br />
            <asp:TextBox runat="server" ID="textStart" type="text" class="form-control" placeholder="Location"/>
            <br />
            <br />
        </div>
    <h3><b><=Title/></b></h3>
<hr />

<br />

<asp:UpdatePanel ID="UpdatePanel1"  runat="server">
 <ContentTemplate>

 <asp:GridView ID="AllFoundItemsGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" 
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="lostdate" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
      
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

    </ContentTemplate>
                
</asp:UpdatePanel>
 
</asp:Content>

