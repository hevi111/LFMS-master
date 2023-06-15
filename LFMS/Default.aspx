<%@ Page Title="Home Page" Language="C#" enableEventValidation="false" EnableViewState="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LFMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
        <form action="LoginCheck" method="post" class="text-center">
          <h4 class="h4 mb-3">Welcome back!</h4>
          <p class="text-muted mb-3">Enter your email address and password to login to the website</p>

           
         <br />
        

          <div class="form-group">
            <label for="email">Email address</label>
            <asp:TextBox ID="email" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter email" aria-label="Enter email address" />
            <asp:RequiredFieldValidator ControlToValidate="email" Display="Dynamic" runat="server" ErrorMessage="Email is required" CssClass="text-danger" />
            <asp:RegularExpressionValidator ControlToValidate="email" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid email address" CssClass="text-danger" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" />
          </div>



          <div class="form-group mb-5">
            <label for="password">Password</label>
            <asp:TextBox ID="password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter password" aria-label="Enter password" />
            <asp:RequiredFieldValidator ControlToValidate="password" Display="Dynamic" runat="server" ErrorMessage="Password is required" CssClass="text-danger" />
          </div>






          <asp:Button  class="btn btn-primary" text="Sign In" style="width: 100px" runat="server" OnClick="LoginButton_Click"  />
          <br />
          <br />
          <asp:Label ID="messageLabel" runat="server" CssClass="text-danger d-none"  ></asp:Label>
          <br />
          
        </form>
          <br />
          <p class="text-muted mb-0">Don't have an account?</p>
          <asp:Button  ID="SignUpButton" text="Sign Up" runat="server" CausesValidation="false" OnClick="SignUpButton_Click"  class="btn btn-Secondary" />
          
      </div>
    </div>
  </div>
    <% for (int i = 0; i < 9; i++)
            {
                             %>
                     <br />
                    <%    } %>


</asp:Content>
 