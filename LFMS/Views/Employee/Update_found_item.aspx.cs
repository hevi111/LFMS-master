using LFMS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.Employee
{
    public partial class Update_found_item : System.Web.UI.Page
    {
        UserRedirector redirect = new UserRedirector();
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

        }
    }
}