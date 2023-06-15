using LFMS.Controllers;
using LFMS.Controllers.Departments;
using LFMS.Controllers.LostItemController;
using LFMS.Controllers.Users;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.Employee
{
    public partial class View_all_items : System.Web.UI.Page
    {
        UserRedirector redirect = new UserRedirector();
        LostItemController lc = new LostItemController();
        UserController uc = new UserController();
        DepartmentController dc = new DepartmentController();
        List<LostItem> lostItems= new List<LostItem>();
        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if the user is not logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    bool showButton = false;
                    loadAllLostItems();
                    if (!Session["UserRole"].Equals("student"))
                    {
                        showButton = true;
                    }
                    foreach (DataControlField column in AllLostItemsGrid.Columns)
                    {
                        if (column is CommandField)
                        {
                            CommandField commandField = (CommandField)column;
                            commandField.Visible = showButton;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(text.Text))
                {
                    Timer1.Enabled = true;
                }

            }

        }

        public void loadAllLostItems()
        {

            if (Session["UserRole"].Equals("employee"))
            {
                useraccount tempUser = uc.getUserByID(Int32.Parse(Session["UserID"].ToString()));
                lostItems = lc.getLostItemsInDep(tempUser.departmentid);
                empLabel.Text = dc.getDepartmentNameByID(tempUser.departmentid);
            }
            else
            {
                lostItems = lc.getAllLostItems();
            }


            AllLostItemsGrid.DataKeyNames = new string[] { "id" };
            AllLostItemsGrid.DataSource = lostItems;
            AllLostItemsGrid.DataBind();



            if (lostItems.Count < 1)
            {
                noLostItemLabel.Text = "There are no found items!";
            }

        }

        protected void SelectLost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllLostItemsGrid.Rows[rowIndex];
                string itemID = AllLostItemsGrid.DataKeys[rowIndex]["id"].ToString();
                Response.Redirect("~/Views/Shared/View_one_item.aspx?itemID=" + itemID + "&type=lost");

            }
        }

        protected void RecentLostGrid_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            string id = AllLostItemsGrid.Rows[e.RowIndex].Cells[0].Text.ToString();
            bool status = lc.deleteLostItemByID(Int32.Parse(id));
            loadAllLostItems();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            var searchBoxText = text.Text;
            List<LostItem> myItems = new List<LostItem>();
            myItems = lc.searchLostItems(searchBoxText);
            AllLostItemsGrid.DataSource = myItems;
            AllLostItemsGrid.DataBind();
            if (myItems.Count < 1)
            {
                noLostItemLabel.Text = "No Result for " + searchBoxText + ", Try another keyword.";
            }
            else { noLostItemLabel.Text = ""; }
        }
    }
}