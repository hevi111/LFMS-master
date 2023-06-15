using LFMS.Controllers.FoundItemController;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Xml.Linq;

namespace LFMS.Controllers.Users
{
    public class UserController
    {
        // this is our database model object, which is from models created with ADO.NET
        // the db object will be used to make queries to the database such as; insert, update, delete, select, etc.
        lfmsdb_ModelEntities db = new lfmsdb_ModelEntities();

        // this function will check if user with parameter email exists
        // it uses Linq to retrieve data from database
        public bool doesUserExist(string email)
        {
            var user = (from u in db.useraccounts
                        where u.email == email
                        select u).FirstOrDefault();

            return user != null;
        }

        // this function will return a user object from parameter email
        // it uses Linq to retrieve data from database
        public useraccount getUserByEmail(string email)
        {
            var user = (from u in db.useraccounts
                        where u.email == email
                        select u).FirstOrDefault();

            return user;
        }

        // this function will return a user object from given id
        // it uses Linq to retrieve data from database
        public useraccount getUserByID(int id)
        {
            var user = (from u in db.useraccounts
                        where u.id == id
                        select u).FirstOrDefault();

            return user;
        }

        // this function will update user account from myUser object which should hold the new user data
        // it uses Linq to update data from database
        public bool updateProfile(useraccount myUser, int userID)
        {
            try
            {
                var user = db.useraccounts.FirstOrDefault(u => u.id == userID);

                // if email is not modified
                if(user.email == myUser.email)
                {
                    if (user != null)
                    {
                        user.firstname = myUser.firstname;
                        user.lastname = myUser.lastname;
                        user.phone = myUser.phone;
                        db.SaveChanges();
                    }

                // if user has a new email
                }else if(user.email != myUser.email)
                {
                    if (user != null)
                    {
                        // check if email is not duplicate
                        if (doesUserExist(myUser.email))
                        {
                            return false;
                        }
                        else
                        {
                            user.firstname = myUser.firstname;
                            user.lastname = myUser.lastname;
                            user.email = myUser.email;
                            user.phone = myUser.phone;
                            db.SaveChanges();
                        }
                    }
                }
             
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // this function return the list of user ID from a particular depaertment by depID
        // it uses Linq to retrieve data from database
        public List<int> getUserIDsByDepartment(int depID)
        {
            var userIDs = (from u in db.useraccounts
                           where u.departmentid  == depID
                           select u.id).ToList();
            return userIDs;
        }
        // this function will return the list of users whose roles are employee
        // it uses Linq to retrieve data from database
        public List<useraccount> getAllEmployees()
        {
            var employees = (from u in db.useraccounts
                             where u.role == "employee"
                             select u).ToList();
            return employees;
        }

        // this function will remove a specific user from given id, note: this is used for employee
        // it uses Linq to delete data from database
        public bool deleteUserByID(int id)
        {
            
            try
            {
                // get user by id
                var user = db.useraccounts.FirstOrDefault(li => li.id == id);

                // check if user exists
                if (user != null)
                {
                    // remove user
                    db.useraccounts.Remove(user);
                    db.SaveChanges();

                    // remove all found items for this user
                    var foundItems = db.FoundItems.Where(u => u.finderid == id).ToList();
                    db.FoundItems.RemoveRange(foundItems);
                    db.SaveChanges();
                }

                return true;


            }
            catch (Exception)
            {

                return false;
            }

        }



    }
}