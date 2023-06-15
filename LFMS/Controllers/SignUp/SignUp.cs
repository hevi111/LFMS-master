using LFMS.Controllers.Users;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;

namespace LFMS.Controllers.SignUpController
{
    public class SignUpController
    {
        // this is our database model object, which is from models created with ADO.NET
        // the db object will be used to make queries to the database such as; insert, update, delete, select, etc.
        lfmsdb_ModelEntities db = new lfmsdb_ModelEntities();

        // this function is the sign up controller
        // it will insert the new user credentials into the database
        // it uses Linq to insert the users into the database
        public bool SignUpNow(string e, string fn, string ln, string ph, string pw, int did, string user) {

            try
            {
                // Create a new user object
                useraccount newUser = new useraccount();
                newUser.firstname = fn;
                newUser.lastname = ln;
                newUser.email = e;
                newUser.password = pw;
                newUser.phone = ph;
                newUser.departmentid = did;
                newUser.role = user;

                // Insert the new user object into the database
                db.useraccounts.Add(newUser);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to create the account: " + ex.Message);
                return false;
                
            }

        }



    }
}