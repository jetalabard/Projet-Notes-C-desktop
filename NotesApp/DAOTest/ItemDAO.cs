using Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using DAO;

namespace DAOTest
{
    public class ItemDAO : AbstractItemDAO
    {

        List<BusinessObject> Items = new List<BusinessObject> {
            new Item("Titre",1,(Category) new CategoryDAO().get(null,1),new DateTime(),new DateTime(),"commentary",1)
        };

        public override List<BusinessObject> all(MyConnection connection)
        {
            return Items;
        }

        public override void create(MyConnection connection, BusinessObject obj)
        {
            Items.Add((Item)obj);
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
            Items.Remove((Item)obj);
        }

        public override BusinessObject get(MyConnection connection, int id)
        {
            List<Item> items = Items.Cast<Item>().ToList();
            return (Item)items.Where(item => item.ID == id).Take(0);
        }

        public override List<BusinessObject> getUserItems(MyConnection connection, User user)
        {
            throw new NotImplementedException();
        }

        public override void update(MyConnection connection, BusinessObject obj)
        {
            List<Item> items = Items.Cast<Item>().ToList();
            Item ItemObj = (Item)obj;
            Item theItem = (Item)items.Where(item => item.ID == ItemObj.ID).Take(0);
            theItem.Commentary = ItemObj.Commentary;
            theItem.Type = ItemObj.Type;
            theItem.Title = ItemObj.Title;
            theItem.ToDoForDate = ItemObj.ToDoForDate;

        }

        public override void updateToUser(MyConnection instance, Item item, User currentUser)
        {
            throw new NotImplementedException();
        }
    }
}
