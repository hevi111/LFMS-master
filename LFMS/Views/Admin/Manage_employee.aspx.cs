using LFMS.Controllers;
using LFMS.Controllers.Departments;
using LFMS.Controllers.SignUpController;
using LFMS.Controllers.Users;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.Admin
{
    public partial class Add_Employee : System.Web.UI.Page
    {
        UserRedirector redirect = new UserRedirector();
        DepartmentController dc = new DepartmentController();
        SignUpController su = new SignUpController();
        UserController uc = new UserController();

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
            
           
                if (!Page.IsPostBack)
                {
                List<department> myDepartments = dc.getAllDepartments();
                foreach (var d in myDepartments)
                {
                    department.Items.Add(new ListItem(d.name, d.id.ToString()));
                }
                loadAllEmployees();
                }
            

        }

        protected void CreateEmployee_Click(object sender, EventArgs e)
        {
            if (uc.doesUserExist(email.Text))
            {
                messageLabel.Text = "An account exists on this email, Please use another.";
                messageLabel.CssClass = "text-danger";
            }
            else
            {

                bool createdStatus = su.SignUpNow(email.Text, firstname.Text, lastname.Text, phone.Text, password.Text, Int32.Parse(department.SelectedValue), "employee");
                if (createdStatus)
                {
                    messageLabel.Text = "";
                    messageLabel2.Text = "Successfully created employee account";
                    email.Text = "";
                    firstname.Text = "";
                    lastname.Text = ""; 
                    phone.Text = "";
                    password.Text = "";
                    loadAllEmployees();


                }
                else
                {
                    messageLabel2.Text = "";
                    messageLabel.Text = "An error occurred while trying to create the account. Please try again later.";
                    messageLabel.CssClass = "text-danger";
                }
            }
        }

        public void loadAllEmployees()
        {

            AllEmployeeGrid.DataSource = uc.getAllEmployees();
            AllEmployeeGrid.DataKeyNames = new string[] { "id" };
            AllEmployeeGrid.DataBind();

        }

        protected void AllEmployeeGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = AllEmployeeGrid.Rows[e.RowIndex].Cells[0].Text.ToString();

            bool status = uc.deleteUserByID(Int32.Parse(id));

            if (status)
            {
                loadAllEmployees();
                messageLabel.Text = "Successfully deleted employee account and related posts!";
                messageLabel.CssClass = "";
                
            }
            else
            {
                messageLabel.Text = "An Error Occured! Could not delete employee account";
                messageLabel.CssClass = "text-danger";
            }
        }
    }
}