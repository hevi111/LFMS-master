<%@ Page Language="C#"  EnableViewState="true" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="View_one_item.aspx.cs" Inherits="LFMS.Views.Shared.View_one_item" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <asp:Panel ID="pnlLostItem" runat="server">
            <asp:Panel ID="pnlDefault" runat="server" CssClass="panel panel-default">
                <asp:Panel ID="pnlHeading" runat="server" CssClass="panel-heading">

                  
                    <h4 class="panel-title" style="font-size:2.2em; line-height:1.5">
                        <asp:Label ID="lblTitle" runat="server"><b><%=ViewState["status"] %> Item Report</b></asp:Label>
                        <%
                            if (!Session["UserRole"].Equals("student"))
                            {
                            %>
                        <div class="pull-right">
                            <asp:Button runat="server" Text="Delete Item" ShowDeleteButton="True" OnClick="DeleteThisItem_Click" ControlStyle-CssClass="btn btn-danger"   />
                        </div>
                        <% } %>
                    </h4>
                  
                </asp:Panel>
                <asp:Panel ID="pnlBody" runat="server" CssClass="panel-body">
                    <asp:Panel ID="pnlLeft" runat="server" CssClass="col-md-6">
                        <asp:Image ID="imgLostItem" runat="server" ImageUrl="https://i0.wp.com/lost-found.org/wp-content/uploads/lost-item.png?resize=500%2C304&ssl=1" CssClass="img-thumbnail" AlternateText="Lost Backpack" ></asp:Image>
                    </asp:Panel>
                    <asp:Panel ID="pnlRight" runat="server" CssClass="col-md-6">
                        <asp:Label ID="lblItemTitle" runat="server" CssClass="h4" Style="font-size:1.7em; line-height:1.5"><%=ViewState["title"] %></asp:Label>
                        <br />
                        <asp:Label ID="lblDescription" runat="server" Style="font-size:1.2em; line-height:1.5"><b>Description:</b> <%= ViewState["description"] %></asp:Label>
                        <br />
                        <asp:Label ID="lblLostDate" runat="server" Style="font-size:1.2em; line-height:1.5"><b>Posted Date:</b> <%= ViewState["date"] %></asp:Label>
                        <br />
                        <asp:Label ID="depNameLabel" runat="server" Style="font-size:1.2em; line-height:1.5"><b><%=ViewState["status"] %> at Department:</b> <%= ViewState["depName"] %></asp:Label>
                        <br />
                        <asp:Label ID="lblLocation" runat="server" Style="font-size:1.2em; line-height:1.5"><b>Location:</b> <%= ViewState["location"] %></asp:Label>
                        <br />
                        <asp:Label ID="lblStatus" runat="server" Style="font-size:1.2em; line-height:1.5"><b>Status:</b> <%= ViewState["status"] %></asp:Label>
                                            </asp:Panel>
                    <br /> 
                 
                    <br />
                    <asp:Panel ID="pnlRow" runat="server" CssClass="row mt-3">
                        <asp:Panel ID="pnlReportedBy" runat="server" CssClass="col-md-6">
                            <br />
                            <asp:Label ID="lblReportedBy" runat="server" Text="Reported by:" Style="font-size:1.7em; line-height:1.5"></asp:Label>
                            <br />
                            <asp:Label ID="lblFullName" runat="server" Style="font-size:1.2em; line-height:1.5"><b>Full Name:</b> <%= ViewState["fullname"] %></asp:Label>
                            <br />
                            <asp:Label ID="lblDepartment" runat="server" Style="font-size:1.2em; line-height:1.5"><b>Department:</b> <%= ViewState["department"] %></asp:Label>
                            <br />
                            <asp:Label ID="lblEmail" runat="server" Text="" Style="font-size:1.2em; line-height:1.5"><b>Email:</b> <%= ViewState["email"] %></asp:Label>
                            <br />
                            <asp:Label ID="lblPhone" runat="server"  Style="font-size:1.2em; line-height:1.5"><b>Phone:</b> <%= ViewState["phone"] %></asp:Label>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>

<br />

</asp:Content>