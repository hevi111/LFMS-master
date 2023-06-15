﻿using LFMS.Controllers;
using LFMS.Controllers.Departments;
using LFMS.Controllers.FoundItemController;
using LFMS.Controllers.LostItemController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LFMS.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UserRedirector redirect = new UserRedirector();
        DepartmentController dc = new DepartmentController();
        LostItemController lc = new LostItemController();
        FoundItemController fc = new FoundItemController();

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

            loadAllDepartments();
            loadAllItems();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        } 

        public void loadAllDepartments()
        {

            AllDepartmentsGrid.DataSource = dc.getAllDepartments();
            AllDepartmentsGrid.DataKeyNames = new string[] { "id" };
            AllDepartmentsGrid.DataBind();

        }

        public void loadAllItems()
        {
            AllDepartmentsGrid.DataKeyNames = new string[] { "id" };
            RecentLostGrid.DataKeyNames= new string[] { "id" };
            RecentFoundGrid.DataKeyNames = new string[] { "id" };
            RecentLostGrid.DataSource = lc.getRecentLostItems();
            RecentFoundGrid.DataSource = fc.getRecentFoundItems();


            RecentLostGrid.DataBind();
            RecentFoundGrid.DataBind();

        }


        protected void SelectDep_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = AllDepartmentsGrid.Rows[rowIndex];
        
                string depid = AllDepartmentsGrid.DataKeys[rowIndex]["id"].ToString();


                //Fetch value of Country
                Response.Redirect("~/Views/Student/View_department_items.aspx?depID=" + depid);
            }
        }

        protected void SelectLost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = RecentLostGrid.Rows[rowIndex];

                string itemID = RecentLostGrid.DataKeys[rowIndex]["id"].ToString();

                Response.Redirect("~/Views/Shared/View_one_item.aspx?itemID=" + itemID + "&type=lost");

            }
        }

        protected void SelectFound_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = RecentFoundGrid.Rows[rowIndex];

                string itemID = RecentFoundGrid.DataKeys[rowIndex]["id"].ToString();

                Response.Redirect("~/Views/Shared/View_one_item.aspx?itemID=" + itemID + "&type=found");

            }
        }



    }
}