using LFMS.Controllers;
using LFMS.Controllers.FoundItemController;
using LFMS.Controllers.LostItemController;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views.Student
{
    public partial class update_items : System.Web.UI.Page
    {
        FoundItem myFoundItem = new FoundItem();
        LostItem myLostItem = new LostItem();
        LostItemController lic = new LostItemController();
        FoundItemController fic = new FoundItemController();
        UserRedirector redirect = new UserRedirector();
        public static string itemType = "";
        public static int itemID = 0;
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

                if (!Page.IsPostBack)
                {
                    if (itemType.Equals("lost"))
                    {

                        myLostItem = lic.getLostItemByID(itemID);

                        ViewState["title"] = myLostItem.title;
                        title.Text = myLostItem.title;
                        description.Text = myLostItem.description;
                        location.Text = myLostItem.location;


                    }
                    else if (itemType.Equals("found"))
                    {
                        myFoundItem = fic.getFoundItemByID(itemID);

                        ViewState["title"] = myFoundItem.title;
                        title.Text = myFoundItem.title;
                        description.Text = myFoundItem.description;
                        location.Text = myFoundItem.location;

                    }
                    else
                    {
                        Response.Redirect(redirect.toError());
                    }
                }

            }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (itemType.Equals("lost"))
            {
                myLostItem.id = itemID;
                myLostItem.title = title.Text;
                myLostItem.description = description.Text;
                myLostItem.location = location.Text;
                bool status = lic.updateLostItemByID(myLostItem);
                if (!status)
                {
                    Response.Redirect(redirect.toError());
                }
                else
                {
                    Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
                }

            }else if(itemType.Equals("found"))
            {
                myFoundItem.id = itemID;
                myFoundItem.title = title.Text;
                myFoundItem.description = description.Text;
                myFoundItem.location = location.Text;
                bool status = fic.updateFoundItemByID(myFoundItem);
                    if (!status)
                    {
                        Response.Redirect(redirect.toError());
                    }
                    else
                    {
                        Response.Redirect(redirect.toHome(Session["UserRole"].ToString()));
                    }
            }
        }
    }
}