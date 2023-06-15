using LFMS.Controllers;
using LFMS.Controllers.SignIn;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS
{
    public partial class _Default : Page
    {
        SignIn sign = new SignIn();
        UserRedirector redirect = new UserRedirector();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is already logged in
            if (Session["UserID"] != null)
            {
                Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
            }

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            useraccount user = sign.SignInNow(email.Text, password.Text);
            if (user != null)
            {
                // Store the user's ID in a session variable
                Session["UserID"] = user.id;
                Session["UserRole"] = user.role;
                Session.Timeout = 60;

                // Set a cookie to remember the user's login
                HttpCookie loginCookie = new HttpCookie("LoginCookie");
                loginCookie["email"] = user.email;
                loginCookie.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Add(loginCookie);

                Response.Redirect(redirect.toHome(user.role));
  
            }
            else
            {
                messageLabel.Text = "Invalid email or password.";
            }
        }
        protected void SignUpButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Views/Shared/SignUp");

        }

    }
}