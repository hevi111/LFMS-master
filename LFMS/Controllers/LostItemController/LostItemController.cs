using LFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Helpers;

namespace LFMS.Controllers.LostItemController
{
    public class LostItemController
    {
        // this is our database model object, which is from models created with ADO.NET
        // the db object will be used to make queries to the database such as; insert, update, delete, select, etc.
        lfmsdb_ModelEntities db = new lfmsdb_ModelEntities();

        // this function will return the list of all found items in the database
        // it uses Linq to retrieve data from database
        public List<LostItem> getAllLostItems()
        {
            var lostItems = (from li in db.LostItems orderby li.lostdate descending select li).ToList(); 
          
            return lostItems;
        }

        // this function will get a particular lost item by given itemID
        // it uses Linq to retrieve data from database
        public LostItem getLostItemByID(int itemID)
        {
           
                var lostItem = (from li in db.LostItems
                                where li.id == itemID
                                select li).FirstOrDefault();

                return lostItem;
        }

        // this function will get the list of lost items posted by a user from the userID parameter
        // it uses Linq to retrieve data from database
        public List<LostItem> getLostItemByUserID(int userID)
        {

            var lostItem = (from li in db.LostItems
                            where li.ownerid == userID
                            orderby li.lostdate descending
                            select li).ToList();

            return lostItem;
        }

        // this furenction returns all lost items in a department and sorts them by date
        // it uses Linq to retrieve data from database
        public List<LostItem> getLostItemsInDep(int? depID)
        {

            var lostItems = (from li in db.LostItems
                              where li.departmentid == depID
                             orderby li.lostdate descending
                             select li).ToList();

            return lostItems;
        }

        // this function returns list of 5 latest posted lost items by date
        // it uses Linq to retrieve data from database
        public List<LostItem> getRecentLostItems() {
            var lostItems = (from li in db.LostItems
                             orderby li.lostdate descending
                             select li).Take(5).ToList();
            return lostItems;
        }

        // this function will insert new lost item to the database from given fi object
        // it uses Linq to insert data into database
        public bool insertLostItem(LostItem li)
        {
            try
            {
                db.LostItems.Add(li);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // this function will delete lost item by given id
        // it uses Linq to delete data from database
        public bool deleteLostItemByID(int id)
        {

            try
            {
                var lostItem = db.LostItems.FirstOrDefault(li => li.id == id);
                if (lostItem != null)
                {
                    db.LostItems.Remove(lostItem);
                    db.SaveChanges();
                }

                return true;


            }
            catch (Exception)
            {

                return false;
            }

        }

        // this function will return the list of lost items from given keyword for search
        // it uses Linq to retrieve data from database
        public List<LostItem> searchLostItems(String search)
        {
            var lostItems = (from li in db.LostItems where li.title.Contains(search) orderby li.lostdate descending select li).ToList();

            return lostItems;
        }

        // this function will update a lost item details by the given myItem object
        // it uses Linq to update data from database
        public bool updateLostItemByID(LostItem myItem)
        {
            try
            {
                var updatedItem = db.LostItems.FirstOrDefault(u => u.id == myItem.id);

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