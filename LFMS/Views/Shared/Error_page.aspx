<%@ Page Language="C#"  AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Error_page.aspx.cs" Inherits="LFMS.Views.Shared.Error_page" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="error-template">
                <h1>Oops!</h1>
                <h2>404 Not Found</h2>
                <div class="error-details">
                    Sorry, an error has occurred, Requested page not found!
                </div>
                <div class="error-actions">
                    <div >
                        <br />
                        <br />
                        <br />
                        <asp:Button  runat="server" Text="Take Me Home" class="btn btn-primary btn-lg"  ID="HomeButton" OnClick="HomeButton_Click" Font-Size="Large" Height="79px" Width="363px" />

                    </div>
                    <% for (int i = 0; i < 10; i++)
            {
                             %>
                     <br />
                    <%    } %>
                    
                    
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>
