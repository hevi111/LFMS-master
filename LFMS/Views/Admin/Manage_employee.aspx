<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_employee.aspx.cs" Inherits="LFMS.Views.Admin.Add_Employee" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


   <div class="container">
    <div class="row">
        <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
     


                <h4 class="h4 mb-3">Manage Employees</h4>
                <p class="text-muted mb-3">Enter your details to create a new account:</p>

                <div class="form-group">
                    <label for="email">Email address</label>
                    <asp:TextBox ID="email" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter email" aria-label="Enter email address" />
                    <asp:RequiredFieldValidator ControlToValidate="email" Display="Dynamic" runat="server" ErrorMessage="Email is required" CssClass="text-danger" />
                    <asp:RegularExpressionValidator ControlToValidate="email" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid email address" CssClass="text-danger" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" />

                </div>

                <div class="form-group">
                    <label for="firstname">First Name</label>
                    <asp:TextBox ID="firstname" runat="server" CssClass="form-control" placeholder="Enter First Name" aria-label="Enter first name" />
                    <asp:RequiredFieldValidator ControlToValidate="firstname" Display="Dynamic" runat="server" ErrorMessage="First Name is required" CssClass="text-danger" />
                </div>

                <div class="form-group">
                    <label for="lastname">Last Name</label>
                    <asp:TextBox ID="lastname" runat="server" CssClass="form-control" placeholder="Enter Last Name" aria-label="Enter Last name" />
                    <asp:RequiredFieldValidator ControlToValidate="lastname" Display="Dynamic" runat="server" ErrorMessage="Last Name is required" CssClass="text-danger" />
                </div>

                <div class="form-group mb-5">
                    <label for="department">Department</label>
                    <asp:DropDownList ID="department" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="department" Display="Dynamic" runat="server" ErrorMessage="Department is required" CssClass="text-danger" />
                </div>

                <div class="form-group">
                    <label for="phone">Phone</label>
                    <asp:TextBox ID="phone" runat="server" CssClass="form-control" placeholder="Enter Phone Number" aria-label="Enter phone number" />
                    <asp:RequiredFieldValidator ControlToValidate="phone" Display="Dynamic" runat="server" ErrorMessage="Phone number is required" CssClass="text-danger" />
                </div>

                <div class="form-group mb-5">
                    <label for="password">Password</label>
                    <asp:TextBox ID="password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter password" aria-label="Enter password" />
                    <asp:RequiredFieldValidator ControlToValidate="password" Display="Dynamic" runat="server" ErrorMessage="Password is required" CssClass="text-danger" />
                </div>
            <asp:Label ID="messageLabel" runat="server" CssClass="text-danger d-none"  ></asp:Label>
            <asp:Label ID="messageLabel2" runat="server" CssClass="d-none"  ></asp:Label>
            <br />
                <asp:Button  OnClick="CreateEmployee_Click" class="btn btn-primary" Text="Create Employee" runat="server" />
                <br />
                <br />

        </div>
    </div>
</div>



 <h2><b> All Employees</b></h2>
<hr />

<br />
 <asp:GridView ID="AllEmployeeGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" OnRowDeleting="AllEmployeeGrid_RowDeleting"
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
      <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="firstname" HeaderText="First Name" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="lastname" HeaderText="Last Name" ReadOnly="True" />
    <asp:BoundField DataField="email" HeaderText="Email" ReadOnly="True" />
    <asp:BoundField DataField="departmentid" ItemStyle-Width="12%" Visible="false" HeaderText="Date" ReadOnly="True" />
    <asp:BoundField DataField="role" ItemStyle-Width="12%" HeaderText="Date" Visible="false" ReadOnly="True" />
    <asp:BoundField DataField="phone" ItemStyle-Width="12%" HeaderText="Phone" ReadOnly="True" />
    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" ButtonType="Button" ItemStyle-HorizontalAlign="Right"   />
      
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