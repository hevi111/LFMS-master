using LFMS.Controllers;
using LFMS.Controllers.Departments;
using LFMS.Controllers.FoundItemController;
using LFMS.Controllers.LostItemController;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.Employee
{
    public partial class Employee_home : System.Web.UI.Page
    {
        UserRedirector redirect = new UserRedirector();
        LostItemController lc = new LostItemController();
        FoundItemController fc = new FoundItemController();
        DepartmentController dc = new DepartmentController();
        List<FoundItem> foundItems = new List<FoundItem>();
        List<LostItem> lostItems = new List<LostItem>();
        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if the user is not logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (Session["UserRole"].Equals("admin") || Session["UserRole"].Equals("student"))
                {
                    Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));

                }
                else if (!(Session["UserRole"].Equals("employee")))
                {
                    Response.Redirect(redirect.toError());
                }

            }

            loadAllItems();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        public void loadAllItems()
        {
            int? depid = dc.getDepIDfromEmpID(Int32.Parse(Session["UserID"].ToString()));

            RecentLostGrid.DataKeyNames = new string[] { "id" };
            RecentFoundGrid.DataKeyNames = new string[] { "id" };
            lostItems = lc.getLostItemsInDep(depid);
            RecentLostGrid.DataSource = lostItems;
            foundItems = fc.getFoundItemsInDep(depid);
            RecentFoundGrid.DataSource = foundItems;
            RecentLostGrid.DataBind();
            RecentFoundGrid.DataBind();

            depLabel.Text = dc.getDepartmentNameByID(depid) + " Department";

            if (foundItems.Count < 1)
            {
                noFoundItemLabel.Text = "There are no found items!";
            }
            if (lostItems.Count < 1)
            {
                noLostItemLabel.Text = "There are no lost items!";
            }

        }




        protected void SelectFound_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = RecentFoundGrid.Rows[rowIndex];

                string itemID = RecentFoundGrid.DataKeys[rowIndex]["id"].ToString();

                Response.Redirect("~/Views/Shared/View_one_item.aspx?itemID=" + itemID + "&type=found");

            }
        }

        protected void SelectLost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = RecentLostGrid.Rows[rowIndex];

                string itemID = RecentLostGrid.DataKeys[rowIndex]["id"].ToString();

                Response.Redirect("~/Views/Shared/View_one_item.aspx?itemID=" + itemID + "&type=lost");

            }
        }


        protected void RecentFoundGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = RecentFoundGrid.Rows[e.RowIndex].Cells[0].Text.ToString();
            bool status = fc.deleteFoundItemByID(Int32.Parse(id));
            loadAllItems();
        }

        protected void RecentLostGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = RecentLostGrid.Rows[e.RowIndex].Cells[0].Text.ToString();
            bool status = lc.deleteLostItemByID(Int32.Parse(id));
            loadAllItems();
        }
    }
}