using LFMS.Controllers.FoundItemController;
using LFMS.Controllers.LostItemController;
using LFMS.Controllers.Users;
using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LFMS.Controllers.Departments
{
    // this is the department controller class,
    // it will retrieve data from SQL Server 2012 database by using LINQ
    public class DepartmentController
    {
        // this is our database model object, which is from models created with ADO.NET
        // the db object will be used to make queries to the database such as; insert, update, delete, select, etc.
        lfmsdb_ModelEntities db = new lfmsdb_ModelEntities();
        UserController uc = new UserController();
        

        // this will check if department with depID exists and returns true or false
        // it uses Linq to retrieve data from database
        public bool doesDepartmentExist(int depID)
        {
            var user = (from u in db.departments
                        where u.id == depID
                        select u).FirstOrDefault();

            return user != null;
        }

        // this will return department id from the given employee id (empID)
        // it uses Linq to retrieve data from database
        public int? getDepIDfromEmpID(int empID)
        {
            var user = (from u in db.useraccounts
                        where u.id == empID
                        select u).FirstOrDefault();

            return user.departmentid;
        }

        // this return the name of the department in string from given department id
        // it uses Linq to retrieve data from database
        public string getDepartmentNameByID(int? id)
        {
            var user = (from u in db.departments
                        where u.id == id
                        select u).FirstOrDefault();

            return user.name;
        }

        // this returns the list of all departments in the database
        // it uses Linq to retrieve data from database
        public List<department> getAllDepartments() {

            try
            {
                // Retrieve all departments from the database
                List<department> departments = (from d in db.departments select d).ToList();
                return departments;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to retrieve the list of departments: " + ex.Message);
                return null;
            }
        }

        // this deletes a department from the database from the given department id
        // it will also remove all the associated items and users to the deleted department 
        // it uses Linq to delete data from database
        public bool deleteDepartmentByID(int id)
        {
            int myDepID = 0;
            List<int> depUserIDs = new List<int>();
            try
            {
                var dep = db.departments.FirstOrDefault(li => li.id == id);
                if (dep != null)
                {
                    myDepID = dep.id;
                    db.departments.Remove(dep);
                    db.SaveChanges();

                    // get all users in dep
                    depUserIDs = uc.getUserIDsByDepartment(id);

                    // remove all users in this dep
                        var usersToRemove = db.useraccounts.Where(u => u.departmentid == id).ToList();
                        db.useraccounts.RemoveRange(usersToRemove);
                        db.SaveChanges();


                    // remove all lost items in this dep
                    var lostItems = db.LostItems.Where(u => u.departmentid == id).ToList();
                        db.LostItems.RemoveRange(lostItems);
                        db.SaveChanges();

                    // remove all found items in this dep
                        var foundItems = db.FoundItems.Where(u => u.departmentid == id).ToList();
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

        // this will insert a new department into the database
        // it uses Linq to insert data into the database
        public bool insertDepartment(string depName)
        {
            try
            {
                department dep = new department();
                dep.name = depName;
                db.departments.Add(dep);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}