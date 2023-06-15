<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Update_item.aspx.cs" Inherits="LFMS.Views.Student.update_items" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
    <h2 class="text-center mb-5">Update <%=ViewState["status"] %> item</h2>
    <hr>
    
        <div class="form-group row">
            <label for="title" class="col-sm-2 col-form-label">Title:</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" type="text" Cssclass="form-control" id="title" placeholder="Item Title"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="description" class="col-sm-2 col-form-label">Description:</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" Cssclass="form-control" id="description" rows="3" placeholder="Write the Description here..."></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="location" class="col-sm-2 col-form-label">Location:</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" Cssclass="form-control" id="location" placeholder="Location"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-5">
                <asp:Button runat="server" Text="Update" class="btn btn-primary" onclick="UpdateButton_Click" />
            </div>
        </div>
    
</div>

</asp:Content>
