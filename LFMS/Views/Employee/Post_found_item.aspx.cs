using LFMS.Controllers;
using LFMS.Controllers.Departments;
using LFMS.Controllers.FoundItemController;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.employee
{
    public partial class Post_found_item : System.Web.UI.Page
    {
        UserRedirector redirect = new UserRedirector();
        DepartmentController dc = new DepartmentController();
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
                if (Session["UserRole"].Equals("admin") || Session["UserRole"].Equals("student"))
                {
                    Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));

                }
                else if (!(Session["UserRole"].Equals("employee")))
                {
                    Response.Redirect(redirect.toError());
                }

            }

            if (!Page.IsPostBack)
            {
                List<department> myDepartments = dc.getAllDepartments();
                foreach (var d in myDepartments)
                {
                    departmentDDB.Items.Add(new ListItem(d.name, d.id.ToString()));
                }
            }

        }


        
        protected void postButton_Click1(object sender, EventArgs e)
        {

            FoundItem fi = new FoundItem();
            fi.title = title.Text;
            fi.description = description.Text;
            fi.location = location.Text;
            fi.status = "found";
            fi.departmentid = Int32.Parse(departmentDDB.SelectedValue);
            fi.finderid = Int32.Parse(Session["UserID"].ToString());
            fi.founddate = DateTime.Now;


            bool status = fic.insertFoundItem(fi);
            if(status)
            {
                Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
            }
            else
            {
                messageLabel.Text = "Something was wrong, could not post the item!";
            }
            
            

        }

       
    }
}