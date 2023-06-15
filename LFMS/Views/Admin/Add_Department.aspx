<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Add_Department.aspx.cs" Inherits="LFMS.Views.Admin.Add_Department" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
    <br />
<div class="container">
    <div class="row">
        <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">


            <asp:HiddenField ID="hfConfirm" runat="server" />

                <h4 class="h4 mb-3">Add New Department</h4>
                <p class="text-muted mb-3">Enter your name to the department:</p>

                <div class="form-group">
                    <label for="title">Department</label>
                    <asp:TextBox ID="title" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the department name" aria-label="Enter the department name" Width="350px" />
                    
                </div>

                <br />
                <asp:Button ID="postDepartmentButton"  OnClick="postDepartmentButton_Click" class="btn btn-primary" Text="Add Department" runat="server" />
                <br />
                
                <br />
                <asp:Label ID="messageLabel2" runat="server" CssClass="text-danger d-none"  ></asp:Label>
                <asp:Label ID="messageLabel" runat="server" CssClass="d-none"  ></asp:Label>
                <br />

           </div>
        </div>
    </div>

    <h2><b> List Of Departments</b></h2>
<hr />

<asp:GridView ID="AllDepartmentsGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="2px" CellPadding="12" ForeColor="Black" OnRowDeleting="AllDepartmentsGrid_RowDeleting" GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="name" HeaderText="Department Name"  InsertVisible="False" ReadOnly="True" />
    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" ItemStyle-HorizontalAlign="Right" />
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