using LFMS.Controllers.Departments;
using LFMS.Controllers.FoundItemController;
using LFMS.Controllers.LostItemController;
using LFMS.Controllers;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.Admin
{
    public partial class View_dep_items : System.Web.UI.Page
    {
        public static string departmentName = "Null";
        DepartmentController dc = new DepartmentController();
        UserRedirector redirect = new UserRedirector();
        LostItemController lic = new LostItemController();
        FoundItemController fic = new FoundItemController();
        public static int depid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is not logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (Session["UserRole"].Equals("student") || Session["UserRole"].Equals("employee"))
                {
                    Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
                }
                else if (!(Session["UserRole"].Equals("admin")))
                {
                    Response.Redirect(redirect.toError());
                }

            }

            depid = Int32.Parse(Request.QueryString["depID"]);
            if (!(depid > 0))
            {
                Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
            }
            departmentName = dc.getDepartmentNameByID(depid);
            loadDepItems(depid);

        }

        public void loadDepItems(int depid)
        {
            List<LostItem> lostItems = lic.getLostItemsInDep(depid);
            AllLostItemsDepartmentGrid.DataKeyNames = new string[] { "id" };
            AllLostItemsDepartmentGrid.DataSource = lostItems;
            AllLostItemsDepartmentGrid.DataBind();

            List<FoundItem> foundItems = fic.getFoundItemsInDep(depid);

            AllFoundItemsDepartmentGrid.DataKeyNames = new string[] { "id" };
            AllFoundItemsDepartmentGrid.DataSource = foundItems;
            AllFoundItemsDepartmentGrid.DataBind();

            if (lostItems.Count < 1)
            {
                noLostItemLabel.Text = "There are no lost items!";
            }

            if (foundItems.Count < 1)
            {
                noFoundItemLabel.Text = "There are no found items!";
            }

        }

        protected void SelectLost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllLostItemsDepartmentGrid.Rows[rowIndex];

                string itemID = AllLostItemsDepartmentGrid.DataKeys[rowIndex]["id"].ToString();

                Response.Redirect("~/Views/Shared/View_one_item.aspx?itemID=" + itemID + "&type=lost");

            }
        }

        protected void SelectFound_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllFoundItemsDepartmentGrid.Rows[rowIndex];

                string itemID = AllFoundItemsDepartmentGrid.DataKeys[rowIndex]["id"].ToString();

                Response.Redirect("~/Views/Shared/View_one_item.aspx?itemID=" + itemID + "&type=found");

            }
        }

        protected void AllLostItemsDepartmentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = AllLostItemsDepartmentGrid.Rows[e.RowIndex].Cells[0].Text.ToString();
            bool status = lic.deleteLostItemByID(Int32.Parse(id));
            loadDepItems(depid);
        }

        protected void AllFoundItemsDepartmentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = AllFoundItemsDepartmentGrid.Rows[e.RowIndex].Cells[0].Text.ToString();
            bool status = fic.deleteFoundItemByID(Int32.Parse(id));
            loadDepItems(depid);
        }
    }
}