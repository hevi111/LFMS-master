using LFMS.Controllers;
using LFMS.Controllers.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.Admin
{
    public partial class Add_Department : System.Web.UI.Page
    {
        UserRedirector redirect = new UserRedirector();
        DepartmentController dc = new DepartmentController();
        public static bool confirmValue = false;
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

            loadAllDepartments();
        }

        public void loadAllDepartments()
        {

            AllDepartmentsGrid.DataSource = dc.getAllDepartments();
            AllDepartmentsGrid.DataKeyNames = new string[] { "id" };
            AllDepartmentsGrid.DataBind();
            

        }

        protected void AllDepartmentsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = AllDepartmentsGrid.Rows[e.RowIndex].Cells[0].Text.ToString();

            bool status = dc.deleteDepartmentByID(Int32.Parse(id));
            if (status)
            {
                messageLabel.Text = "Successfully deleted " + title.Text + " department!";
                title.Text = "";
                loadAllDepartments();
            }
            else
            {
                messageLabel2.Text = "Something was wrong, could not delete department!";
            }

        }

        protected void postDepartmentButton_Click(object sender, EventArgs e)
        {
            if(title.Text != "")
            {
                bool status = dc.insertDepartment(title.Text);
                if (status)
                {
                    messageLabel.Text = "Successfully Added " + title.Text + " department!";
                    title.Text = "";
                    loadAllDepartments();
                }
                else
                {
                    messageLabel2.Text = "Something was wrong, could not add department!";
                }
            }
            else
            {
                messageLabel2.Text = "Please enter the department name!";
            }
            
        }
    }
}