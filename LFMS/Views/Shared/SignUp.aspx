<%@ Page Language="C#" MasterPageFile="~/Site.Master" enableEventValidation="false" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LFMS.Views.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 
    <div class="container">
    <div class="row">
        <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
            <form class="text-center">


                <h4 class="h4 mb-3">Welcome to LFMS!</h4>
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

                <asp:Button  class="btn btn-primary" Text="Sign Up" runat="server" OnClick="SignUpButton_Click"  />
                <br />
                <br />
                <asp:Label ID="messageLabel" runat="server" CssClass="text-danger d-none"  ></asp:Label>
                <br />
                <p class="text-muted">Already have an account? </p>
         <asp:Button ID="SignInButton" CausesValidation="false" Text="Login" runat="server" OnClick="SignInButton_Click"  class="btn btn-secondary" />

            </form>
        </div>
    </div>
</div>


    </asp:Content>
