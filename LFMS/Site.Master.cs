using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignOutButton_Click(object sender, EventArgs e)
        {
            Session.Remove("UserID");
            Session.Remove("UserRole");

            HttpCookie loginCookie = new HttpCookie("LoginCookie");
            loginCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(loginCookie);

            Response.Redirect("~/Default.aspx");
        }
    }
}