using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LFMS.Controllers.FoundItemController
{
    // this is the Found Item controller class,
    // it will retrieve data from SQL Server 2012 database by using LINQ
    public class FoundItemController
    {
        // this is our database model object, which is from models created with ADO.NET
        // the db object will be used to make queries to the database such as; insert, update, delete, select, etc.
        lfmsdb_ModelEntities db = new lfmsdb_ModelEntities();

        // this function will return the list of all found items in the database
        // it uses Linq to retrieve data from database
        public List<FoundItem> getAllFoundItems()
        {
            var foundItems = (from fi in db.FoundItems orderby fi.founddate descending select fi).ToList();

            return foundItems;
        }


        // this function returns list of 5 latest posted found items by date
        // it uses Linq to retrieve data from database
        public List<FoundItem> getRecentFoundItems()
        {
            var foundItems = (from fi in db.FoundItems
                             orderby fi.founddate descending
                             select fi).Take(5).ToList();
            return foundItems;
        }

        // this furenction returns all found items in a department and sorts them by date
        // it uses Linq to retrieve data from database
        public List<FoundItem> getFoundItemsInDep(int? depID)
        {

            var foundItems = (from fi in db.FoundItems
                              where fi.departmentid == depID
                              orderby fi.founddate descending
                              select fi).ToList();

            return foundItems;
        }

        // this function will insert new found item to the database from given fi object
        // it uses Linq to insert data from database
        public bool insertFoundItem(FoundItem fi)
        {
            try
            {
                db.FoundItems.Add(fi);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        // this function will delete found item by given id
        // it uses Linq to delete data from database
        public bool deleteFoundItemByID(int id) {

            try
            {
                var foundItem = db.FoundItems.FirstOrDefault(li => li.id == id);
                if (foundItem != null)
                {
                    db.FoundItems.Remove(foundItem);
                    db.SaveChanges();
                }

                return true;


            }
            catch (Exception)
            {

                return false;        
            }
            
        }

        // this function will get a particular found item by given itemID
        // it uses Linq to retrieve data from database
        public FoundItem getFoundItemByID(int itemID)
        {

            var foundItem = (from fi in db.FoundItems
                            where fi.id == itemID
                             select fi).FirstOrDefault();

            return foundItem;
        }

        // this function will get the list of found items posted by a user from the userID parameter
        // it uses Linq to retrieve data from database
        public List<FoundItem> getFoundItemByUserID(int userID)
        {

            var foundItem = (from fi in db.FoundItems
                             where fi.finderid == userID
                             orderby fi.founddate descending
                             select fi).ToList();

            return foundItem;
        }

        // this function will return the list of found items from given keyword for search
        // it uses Linq to retrieve data from database
        public List<FoundItem> searchFoundItems(String search)
        {
            var foundItems = (from fi in db.FoundItems where fi.title.Contains(search) select fi).ToList();

            return foundItems;
        }

        // this function will update a found item details by the given myItem object
        // it uses Linq to update data from database
        public bool updateFoundItemByID(FoundItem myItem)
        {
            try
            {
                var updatedItem = db.FoundItems.FirstOrDefault(u => u.id == myItem.id);
                
                    if (updatedItem != null)
                    {
                        updatedItem.title = myItem.title;
                        updatedItem.description = myItem.description;
                        updatedItem.location = myItem.location;
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