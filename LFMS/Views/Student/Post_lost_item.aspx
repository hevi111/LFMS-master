<%@ Page Title="Post_new_items" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Post_lost_item.aspx.cs" Inherits="LFMS.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   
<br />
<div class="container">
    <div class="row">
        <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
    <form class="text-center">


                <h4 class="h4 mb-3">Post lost items</h4>
                <p class="text-muted mb-3">Enter your details to the losted item:</p>

                <div class="form-group">
                    <label for="title">Title</label>
                    <asp:TextBox ID="title" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter your lost items title" aria-label="Enter your lost items" />
                    <asp:RequiredFieldValidator ControlToValidate="title" Display="Dynamic" runat="server" ErrorMessage="Title is required" CssClass="text-danger" />

                </div>

                <div class="form-group">
                    <label for="description">Description</label>
                    <asp:TextBox ID="description" runat="server" CssClass="form-control" placeholder="Enter Description" aria-label="Enter Description" />
                    <asp:RequiredFieldValidator ControlToValidate="description" Display="Dynamic" runat="server" ErrorMessage="Description is required" CssClass="text-danger" />
                </div>

        <div class="form-group mb-5">
                    <label for="departmentDDB">Department</label>
                    <asp:DropDownList ID="departmentDDB" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="departmentDDB" Display="Dynamic" runat="server" ErrorMessage="Department is required" CssClass="text-danger" />
                </div>

                <div class="form-group">
                    <label for="location">Location</label>
                    <asp:TextBox ID="location" runat="server" CssClass="form-control" placeholder="Enter Location" aria-label="Enter Location" />
                    <asp:RequiredFieldValidator ControlToValidate="location" Display="Dynamic" runat="server" ErrorMessage="Location is required" CssClass="text-danger" />
                </div>
                <br />
                <asp:Button ID="postLostItemButton" class="btn btn-primary" Text="Post Item" runat="server" OnClick="postLostItemButton_Click" />
                <br />
                
                <br />
                <asp:Label ID="messageLabel" runat="server" CssClass="text-danger d-none"  ></asp:Label>
                <br />
            </form>
    </div>
        </div>
    </div>

</asp:Content>
