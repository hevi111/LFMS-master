<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="View_profile_se.aspx.cs" Inherits="LFMS.Views.Shared.View_profile_se" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<br />

 <ajaxToolkit:Accordion ID="Accordion1" runat="server"
                HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected"
                ContentCssClass="accordionContent">
                <panes>
                    <ajaxToolkit:AccordionPane ID="paneColors" runat="server">
                        <header>Account Info</header>
                        <content>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                             <b> Name: </b> <label><%= currentUser.firstname + " " + currentUser.lastname %></label>
                            <br />
                            <br />
                            
                           <b> Emaill Address:</b> <label> <%= currentUser.email %></label>
                            <br />
                            <br />
                            
                           <b> Departments:</b> <label> <%= userDepartment %> </label>
                            <br />
                            <br />
                            
                            <b> Phone Number:</b> <label> <%= currentUser.phone %></label>
                            <br />
                           
                            
                  
                </ContentTemplate>
                
            </asp:UpdatePanel>
                           <br />
                        </content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="paneText" runat="server">
                        <header>Update</header>
                        <content>
                             <label>Update your Info here:</label>
                            
                            <br />
                            <label>First name:</label>
                            <asp:TextBox ID="fnameBox" runat="server"
                                Width="194px" AutoPostBack="True">
                            </asp:TextBox>
                            <br />
                            <br />
                            <labe for="lnameBox"l>Last name:</labe>
                            <asp:TextBox ID="lnameBox" runat="server"
                                Width="194px" AutoPostBack="True">
                            </asp:TextBox>
                            <br />
                            <br />

                             <label for="emailBox">Email Address:</label>
                            <asp:TextBox ID="emailBox" runat="server"
                                Width="194px" AutoPostBack="True">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="emailBox" Display="Dynamic" runat="server" ErrorMessage="Email is required" CssClass="text-danger" />
                            <asp:RegularExpressionValidator ControlToValidate="emailBox" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid email address" CssClass="text-danger" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" />

                            <br />
                            <br />
                            <label for="phoneBox">Phone Number</label>
                            <asp:TextBox ID="phoneBox" runat="server"  aria-label="Enter phone number" />
                            <asp:RequiredFieldValidator ControlToValidate="phoneBox" Display="Dynamic" runat="server" ErrorMessage="Phone number is required" CssClass="text-danger" />

                            <br />
                            <br />
                            <asp:Button runat="server" Text="Update" ControlStyle-CssClass="btn btn-success"  OnClick="Update_Click" />
                            <br />
                            
                            <asp:Label ID="errorUpdateLabel" runat="server" Font-Size="Large"></asp:Label>
                        </content>
                    </ajaxToolkit:AccordionPane>
                   
                </panes>
            </ajaxToolkit:Accordion>
            
    
<br />


    <asp:Panel ID="studentPanel" Visible="false" runat="server">
    <h3><b>Your Lost Items</b></h3>
<hr />

<br />

 <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data_XML/profile_lf.xml"></asp:XmlDataSource>
     <asp:Label ID="noLostItemLabel" runat="server" Font-Size="Large"></asp:Label>
 <asp:GridView DataSourceID="XmlDataSource1" ID="AllLostItemsGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" OnRowCommand="AllLostItemsGrid_RowCommand"
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns> 
    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="lostdate" ItemStyle-Width="12%" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy hh:mm tt}" ReadOnly="True" />
    <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
    <asp:ButtonField Text="Edit" ControlStyle-CssClass="btn btn-primary" CommandName="Select" ItemStyle-HorizontalAlign="Right" ButtonType="Button" />
    <asp:ButtonField Text="Delete Item" ControlStyle-CssClass="btn btn-danger"  ButtonType="Button" CommandName="dt" /> 

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
        </asp:Panel>

    <asp:Panel ID="employeePanel" Visible="false" runat="server">
    <h3><b>Your Found Items</b></h3>
<hr />

<br />
 <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data_XML/profile_lf2.xml"></asp:XmlDataSource>
        <asp:Label ID="noFoundItemLabel" runat="server" Font-Size="Large"></asp:Label>
 <asp:GridView DataSourceID="XmlDataSource2" ID="AllFoundItemsGrid" CssClass="table" runat="server" AutoGenerateColumns="False" 
  BorderColor="#cccccc" BorderWidth="1px" CellPadding="10" ForeColor="Black" OnRowCommand="AllFoundItemsGrid_RowCommand"  
  GridLines="None">
  <AlternatingRowStyle BackColor="#f2f2f2" />
  <Columns>
    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <asp:BoundField DataField="title" HeaderText="Title" InsertVisible="False" ReadOnly="True" />
    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True" />
    <asp:BoundField DataField="location" HeaderText="Location" ReadOnly="True" />
    <asp:BoundField DataField="founddate" ItemStyle-Width="12%" HeaderText="Date" ReadOnly="True" />
    <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
    <asp:ButtonField Text="Edit" ControlStyle-CssClass="btn btn-primary" CommandName="Select" ItemStyle-HorizontalAlign="Right" ButtonType="Button" />
    <asp:ButtonField Text="Delete" ControlStyle-CssClass="btn btn-danger"  ButtonType="Button" CommandName="dt" /> 
   
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
        </asp:Panel>


</asp:Content>

