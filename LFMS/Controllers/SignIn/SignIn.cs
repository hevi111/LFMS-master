using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace LFMS.Controllers.SignIn
{
    public class SignIn
    {
        // this is our database model object, which is from models created with ADO.NET
        // the db object will be used to make queries to the database such as; insert, update, delete, select, etc.
        lfmsdb_ModelEntities db = new lfmsdb_ModelEntities();

        // this function is the sign in controller
        // it will check if the user credentials are corrent in order to sign in 
        // it uses Linq to check the users info from the database
        public useraccount SignInNow(String e, String p)
        {
            try
            {
                // Check if the entered username and password are correct
                var user = (from u in db.useraccounts
                            where u.email == e && u.password == p
                            select u).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to sign in: " + ex.Message);
                return null;
            }
        }

    }





}