using LFMS.Controllers;
using LFMS.Controllers.Departments;
using LFMS.Controllers.LostItemController;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS
{
    public partial class Contact : Page
    {
        UserRedirector redirect = new UserRedirector();
        LostItemController lic = new LostItemController();
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
                if (Session["UserRole"].Equals("admin") || Session["UserRole"].Equals("employee"))
                {
                    Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));

                }
                else if (!(Session["UserRole"].Equals("student")))
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

        protected void postLostItemButton_Click(object sender, EventArgs e)
        {

            LostItem li = new LostItem();
            li.title = title.Text;
            li.description = description.Text;
            li.location = location.Text;
            li.status = "lost";
            li.departmentid = Int32.Parse(departmentDDB.SelectedValue);
            li.ownerid = Int32.Parse(Session["UserID"].ToString());
            li.lostdate = DateTime.Now;

            bool status = lic.insertLostItem(li);
            if (status)
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