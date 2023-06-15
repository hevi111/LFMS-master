using LFMS.Controllers.Departments;
using LFMS.Controllers.FoundItemController;
using LFMS.Controllers.LostItemController;
using LFMS.Controllers.Users;
using LFMS.Controllers;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.Shared
{
    public partial class View_one_item : System.Web.UI.Page
    {

        public static useraccount itemUser = new useraccount();
        FoundItem myFoundItem = new FoundItem();
        LostItem myLostItem = new LostItem();
        UserRedirector redirect = new UserRedirector();
        LostItemController lic = new LostItemController();
        FoundItemController fic = new FoundItemController();
        UserController uc = new UserController();
        DepartmentController dc = new DepartmentController();
        public static string itemType = "";
        public static int itemID = 0;


        // static items for viewstate
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {

                itemID = Int32.Parse(Request.QueryString["itemID"]);
                itemType = Request.QueryString["type"];


                if (itemType.Equals("lost"))
                {

                    myLostItem = lic.getLostItemByID(itemID);
                    itemUser = uc.getUserByID(myLostItem.ownerid);
                    string userDepartment = dc.getDepartmentNameByID(itemUser.departmentid);

                    ViewState["title"] = myLostItem.title;
                    ViewState["description"] = myLostItem.description;
                    ViewState["location"] = myLostItem.location;
                    ViewState["date"] = myLostItem.lostdate.ToString();
                    ViewState["status"] = "Lost";
                    ViewState["fullname"] = itemUser.firstname + " " + itemUser.lastname;
                    ViewState["department"] = userDepartment;
                    ViewState["email"] = itemUser.email;
                    ViewState["phone"] = itemUser.phone;
                    ViewState["depName"] = dc.getDepartmentNameByID(myLostItem.departmentid);
                    


                }
                else if (itemType.Equals("found"))
                {
                    myFoundItem = fic.getFoundItemByID(itemID);
                    itemUser = uc.getUserByID(myFoundItem.finderid);
                    string userDepartment = dc.getDepartmentNameByID(itemUser.departmentid);

                    ViewState["title"] = myFoundItem.title;
                    ViewState["description"] = myFoundItem.description;
                    ViewState["location"] = myFoundItem.location;
                    ViewState["date"] = myFoundItem.founddate.ToString();
                    ViewState["status"] = "Found";
                    ViewState["fullname"] = itemUser.firstname + " " + itemUser.lastname;
                    ViewState["department"] = userDepartment;
                    ViewState["email"] = itemUser.email;
                    ViewState["phone"] = itemUser.phone;
                    ViewState["depName"] = dc.getDepartmentNameByID(myFoundItem.departmentid);

                }
                else
                {
                    Response.Redirect(redirect.toError());
                }

            }

        }

        protected void DeleteThisItem_Click(object sender, EventArgs e)
        {

            if (itemType.Equals("lost"))
            {

                lic.deleteLostItemByID(itemID);
                Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));


            }
            else if (itemType.Equals("found"))
            {
                fic.deleteFoundItemByID(itemID);
                Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
            }
            else
            {
                Response.Redirect(redirect.toError());
            }

        }
    }
}