using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LFMS.Controllers
{
    // this is the route controller, we call it UserRedirector
    // it is called to get the link of the different pages that we have
    public class UserRedirector
    {

        public string toHome(string userRole)
        {

            if (userRole.Equals("student"))
            {
                return "~/Views/Student/Student_home.aspx";

            }
            else if (userRole.Equals("employee"))
            {

                return "~/Views/Employee/Employee_home.aspx";

            }
            else if (userRole.Equals("admin"))
            {

                return "~/Views/Admin/Admin_home.aspx";

            }
            else
            {
                return "~/Views/Shared/Error_page.aspx";
            }

        }
        public string toError()
        {
            return "~/Views/Shared/Error_page.aspx";
        }

    }
}