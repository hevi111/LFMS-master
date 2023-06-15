using LFMS.Controllers.Departments;
using LFMS.Controllers.Users;
using LFMS.Controllers;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LFMS.Controllers.LostItemController;
using LFMS.Controllers.FoundItemController;
using System.Xml.Linq;
using System.Globalization;

namespace LFMS.Views.Shared
{
    public partial class View_profile_se : System.Web.UI.Page
    {
        UserController uc = new UserController();
        DepartmentController dc = new DepartmentController();
        public static useraccount currentUser = new useraccount();
        public static string userDepartment = "null";
        UserRedirector redirect = new UserRedirector();
        LostItemController lic = new LostItemController();
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
                if (Session["UserRole"].Equals("admin"))
                {
                    Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));

                }
                else if ((Session["UserRole"].Equals("student")) || (Session["UserRole"].Equals("employee")))
                {
                    // all is fine
                }
                else
                {
                    Response.Redirect(redirect.toError());
                }

            }

            currentUser = uc.getUserByID(Int32.Parse(Session["UserID"].ToString()));
            userDepartment = dc.getDepartmentNameByID(currentUser.departmentid);

            if (!Page.IsPostBack)
            {
                fnameBox.Text = currentUser.firstname;
                lnameBox.Text = currentUser.lastname;
                emailBox.Text = currentUser.email;
                phoneBox.Text = currentUser.phone;
            }

            

            if (currentUser.role.Equals("student"))
            {
                studentPanel.Visible = true;

                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/App_Data_XML/profile_lf.xml"));


                List<LostItem> myLostItems = lic.getLostItemByUserID(currentUser.id);
                AllLostItemsGrid.DataKeyNames = new string[] { "id" };
               /* AllLostItemsGrid.DataSource = myLostItems;
                AllLostItemsGrid.DataBind();*/


                var oldItems = xmlDoc.Root.Elements("item");
                int h = oldItems.ToList().Count;


                for (int i = 0; i < h; i++)
                {
                    oldItems.ElementAt(0).Remove();
                }





                for (int i = 0; i < myLostItems.Count; i++)
                {
                   
                    XElement newItem = new XElement("item",
                        new XAttribute("id", myLostItems[i].id),
                        new XAttribute("title", myLostItems[i].title),
                        new XAttribute("description", myLostItems[i].description),
                        new XAttribute("location", myLostItems[i].location),
                        new XAttribute("lostdate",  string.Format("{0:MM/dd/yyyy hh:mm tt}", myLostItems[i].lostdate)),
                        new XAttribute("status", myLostItems[i].status)); 


                    xmlDoc.Root.Add(newItem);

                }

                xmlDoc.Save(Server.MapPath("~/App_Data_XML/profile_lf.xml"));

                if (myLostItems.Count < 0)
                {
                    noLostItemLabel.Text = "You have no lost items, take care of your things. :) ";
                }
                   

            }else if (currentUser.role.Equals("employee"))
            {
                employeePanel.Visible = true;

                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/App_Data_XML/profile_lf2.xml"));


                List<FoundItem> myFoundItems = fic.getFoundItemByUserID(currentUser.id);
                AllFoundItemsGrid.DataKeyNames = new string[] { "id" };
  /*              AllFoundItemsGrid.DataSource = myFoundItems;
                AllFoundItemsGrid.DataBind();*/

                var oldItems = xmlDoc.Root.Elements("item");
                int h = oldItems.ToList().Count;


                for (int i = 0; i < h; i++)
                {
                    oldItems.ElementAt(0).Remove();
                }





                for (int i = 0; i < myFoundItems.Count; i++)
                {

                    XElement newItem = new XElement("item",
                        new XAttribute("id", myFoundItems[i].id),
                        new XAttribute("title", myFoundItems[i].title),
                        new XAttribute("description", myFoundItems[i].description),
                        new XAttribute("location", myFoundItems[i].location),
                        new XAttribute("founddate", string.Format("{0:MM/dd/yyyy hh:mm tt}", myFoundItems[i].founddate)),
                        new XAttribute("status", myFoundItems[i].status));


                    xmlDoc.Root.Add(newItem);

                }

                xmlDoc.Save(Server.MapPath("~/App_Data_XML/profile_lf2.xml"));



                if (myFoundItems.Count < 0)
                {
                    noLostItemLabel.Text = "You have not posted any found items. ";
                }
            }


        }

        protected void Update_Click(object sender, EventArgs e)
        {
            useraccount updatedUserInfo = new useraccount();
            updatedUserInfo.firstname = fnameBox.Text;
            updatedUserInfo.lastname = lnameBox.Text;
            updatedUserInfo.email = emailBox.Text;
            updatedUserInfo.phone = phoneBox.Text;
           
            bool status = uc.updateProfile(updatedUserInfo, Int32.Parse(Session["UserID"].ToString()));

            if (status)
            {
                Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
            }
            else
            {
                errorUpdateLabel.Text = "Could not update your info";
            }
        }

        protected void AllLostItemsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllLostItemsGrid.Rows[rowIndex];
                string itemID = AllLostItemsGrid.DataKeys[rowIndex]["id"].ToString();
                Response.Redirect("~/Views/Shared/Update_item.aspx?itemID=" + itemID + "&type=lost");

            }
            if(e.CommandName == "dt")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllLostItemsGrid.Rows[rowIndex];
                string itemID = AllLostItemsGrid.DataKeys[rowIndex]["id"].ToString();

                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/App_Data_XML/profile_lf.xml"));

                var oldItems = xmlDoc.Root.Elements("item");
                int h = oldItems.ToList().Count;

                oldItems.ElementAt(rowIndex).Remove();


                xmlDoc.Save(Server.MapPath("~/App_Data_XML/profile_lf.xml"));

                bool status = lic.deleteLostItemByID(Int32.Parse(itemID));

                Response.Redirect("~/");

            }

        }

        protected void AllFoundItemsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllFoundItemsGrid.Rows[rowIndex];
                string itemID = AllFoundItemsGrid.DataKeys[rowIndex]["id"].ToString();
                Response.Redirect("~/Views/Shared/Update_item.aspx?itemID=" + itemID + "&type=found");

            }
            if(e.CommandName == "dt")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllFoundItemsGrid.Rows[rowIndex];
                string itemID = AllFoundItemsGrid.DataKeys[rowIndex]["id"].ToString();

                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/App_Data_XML/profile_lf2.xml"));

                var oldItems = xmlDoc.Root.Elements("item");
                int h = oldItems.ToList().Count;

                oldItems.ElementAt(rowIndex).Remove();


                xmlDoc.Save(Server.MapPath("~/App_Data_XML/profile_lf.xml"));

                bool status = fic.deleteFoundItemByID(Int32.Parse(itemID));

                Response.Redirect("~/");
            }
        }

    }
}