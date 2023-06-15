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

namespace LFMS.Views.Student
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string departmentName = "Null";
        DepartmentController dc = new DepartmentController();
        UserRedirector redirect = new UserRedirector();
        LostItemController lic = new LostItemController();
        FoundItemController fic = new FoundItemController();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is not logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (Session["UserRole"].Equals("admin") || Session["UserRole"].Equals("employee"))
                {
                    Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
                }
                else if (!(Session["UserRole"].Equals("student")))
                {
                    Response.Redirect(redirect.toError());
                }

            }

            string id = Request.QueryString["depID"];
            if(!(Int32.Parse(id) > 0))
            {
                Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
            }
            departmentName = dc.getDepartmentNameByID(Int32.Parse(id));
            loadDepItems(Int32.Parse( id));

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

            if(lostItems.Count < 1)
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
    }
}