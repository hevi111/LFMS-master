using LFMS.Controllers;
using LFMS.Controllers.Departments;
using LFMS.Controllers.FoundItemController;
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
    public partial class View_all_found : System.Web.UI.Page
    {
        FoundItemController fc = new FoundItemController();
        UserRedirector redirect = new UserRedirector();
        List<FoundItem> foundItems = new List<FoundItem>();
        UserController uc = new UserController();
        DepartmentController dc = new DepartmentController();
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
                    loadAllFoundItems();
                    if (!Session["UserRole"].Equals("student"))
                    { 
                        showButton = true;
                    }
                    foreach (DataControlField column in AllFoundItemsGrid.Columns)
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

        public void loadAllFoundItems()
        {

            if (Session["UserRole"].Equals("employee"))
            {
                useraccount tempUser = uc.getUserByID(Int32.Parse(Session["UserID"].ToString()));
                foundItems = fc.getFoundItemsInDep(tempUser.departmentid);
                empLabel.Text = dc.getDepartmentNameByID(tempUser.departmentid);
            }
            else
            {
                foundItems = fc.getAllFoundItems();
            }
            

            AllFoundItemsGrid.DataKeyNames = new string[] { "id" };
            AllFoundItemsGrid.DataSource = foundItems;
            AllFoundItemsGrid.DataBind();

           

            if (foundItems.Count < 1)
            {
                noFoundItemLabel.Text = "There are no found items!";
            }

        }

        protected void SelectFound_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllFoundItemsGrid.Rows[rowIndex];

                string itemID = AllFoundItemsGrid.DataKeys[rowIndex]["id"].ToString();

                Response.Redirect("~/Views/Shared/View_one_item.aspx?itemID=" + itemID + "&type=found");

            }
        }

        protected void RecentFoundGrid_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            string id = AllFoundItemsGrid.Rows[e.RowIndex].Cells[0].Text.ToString();
            bool status = fc.deleteFoundItemByID(Int32.Parse(id));
            loadAllFoundItems();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            var searchBoxText = text.Text;
            List<FoundItem> myItems = new List<FoundItem>();
            myItems = fc.searchFoundItems(searchBoxText);
            AllFoundItemsGrid.DataSource = myItems;
            AllFoundItemsGrid.DataBind();
            if(myItems.Count < 1)
            {
                noFoundItemLabel.Text = "No Result for " + searchBoxText + ", Try another keyword.";
            }
            else { noFoundItemLabel.Text = ""; }
        }
    }
}