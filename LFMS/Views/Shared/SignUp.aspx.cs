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

namespace LFMS.Views
{
    public partial class SignUp : System.Web.UI.Page
    {

        SignUpController su = new SignUpController();
        UserController uc = new UserController();
        UserRedirector redirect = new UserRedirector();
        DepartmentController dc = new DepartmentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is already logged in
            if (Session["UserID"] != null)
            {
                Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    List<department> myDepartments = dc.getAllDepartments();
                    foreach (var d in myDepartments)
                    {
                        department.Items.Add(new ListItem(d.name, d.id.ToString()));
                    }
                }
            }
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            if (uc.doesUserExist(email.Text))
            {
                messageLabel.Text = "An account exists on this email. Please sign in.";
                messageLabel.CssClass = "text-danger";
            }
            else { 

            bool createdStatus = su.SignUpNow(email.Text, firstname.Text, lastname.Text, phone.Text, password.Text, Int32.Parse(department.SelectedValue), "student");
            if (createdStatus)
            {
                // Retrieve the user id from the database and save it in session
                Session["UserID"] = uc.getUserByEmail(email.Text).id;
                Session["UserRole"] = "student";

                // Set a cookie to remember the user's login
                HttpCookie loginCookie = new HttpCookie("LoginCookie");
                loginCookie["email"] = email.Text;
                loginCookie.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Add(loginCookie);

                Response.Redirect("~/Views/Student/Student_home.aspx");

            }
            else
            {
                messageLabel.Text = "An error occurred while trying to create the account. Please try again later.";
                messageLabel.CssClass = "text-danger";
            }
        }
        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Default.aspx");

        }
    }
}