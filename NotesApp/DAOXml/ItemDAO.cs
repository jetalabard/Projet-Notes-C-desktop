using Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using DAO;
using System.Xml.Linq;
using System.Xml;

namespace DAOXml
{
    public class ItemDAO : AbstractItemDAO
    {
        public override List<BusinessObject> all(MyConnection connection)
        {
            var list = connection.mXDoc.Descendants(XmlTags.ITEM).Select(elt => ReadItem(elt));
            return list.Cast<BusinessObject>().ToList();
        }

        public override List<BusinessObject> getUserItems(MyConnection connection, User user)
        {
            List<Item> Items = all(MyConnection.Instance).Cast<Item>().ToList();
            IEnumerable<Item> filteredItems = Items.Where(item => item.User == user.ID);
            return filteredItems.Cast<BusinessObject>().ToList();
        }

        private Item ReadItem(XElement elt)
        {
            string Title = null;
            string Commentary = null;
            Category Catego = null;
            DateTime creationDate = new DateTime();
            DateTime ToDoFor = new DateTime();
            int user =-1;
            int id = -1;
            UserDAO dao = new UserDAO();
            CategoryDAO daoCategory = new CategoryDAO();
            if (elt.Element(XmlTags.TITLE) != null)
            {
                Title = elt.Element(XmlTags.TITLE).Value;
            }
            if (elt.Element(XmlTags.COMMENTARY) != null)
            {
                Commentary = elt.Element(XmlTags.COMMENTARY).Value;
            }
            if (elt.Element(XmlTags.ID) != null)
            {
                id = XmlConvert.ToInt32(elt.Element(XmlTags.ID).Value);
            }
            if (elt.Element(XmlTags.CREATIONDATE) != null)
            {
                creationDate = Convert.ToDateTime(elt.Element(XmlTags.CREATIONDATE).Value);
            }
            if (elt.Element(XmlTags.TODOFOR) != null)
            {
                ToDoFor = Convert.ToDateTime(elt.Element(XmlTags.TODOFOR).Value);
            }

            //we try to go on User node which is the parent of parent of item
            XElement parent = elt.Parent;
            while (!parent.Name.ToString().Equals(XmlTags.USER))
            {
                parent = parent.Parent;
            }
            user = dao.ReadUser(parent).ID;

            if (elt.Element(XmlTags.CATEGORY) != null)
            {
                Catego = daoCategory.ReadCategory(elt.Element(XmlTags.CATEGORY));
            }

            return new Item(Title, id,Catego,creationDate,ToDoFor,Commentary,user);
        }

        public override void create(MyConnection connection, BusinessObject obj)
        {
            Item CurentItem = (Item)obj;
            UserDAO daoUser = new UserDAO();
            User user = (User)daoUser.get(connection, CurentItem.User);
            XElement userItemsElement = daoUser.ReadUser(connection, user).Element(XmlTags.ITEMS);
            userItemsElement.Add(WriteItem(CurentItem));
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
            Item CurentItem = (Item)obj;
            IEnumerable<XElement> ItemsElements = connection.mXDoc.Descendants(XmlTags.ITEM);
            for (int i = 0; i < ItemsElements.Count(); ++i)
            {
                Item item = ReadItem(ItemsElements.ElementAt(i));
                if (CurentItem.ID == item.ID)
                {
                    ItemsElements.ElementAt(i).Remove();
                }
            }
        }

        public override BusinessObject get(MyConnection connection, int id)
        {
            IEnumerable<XElement> ItemsElements = connection.mXDoc.Descendants(XmlTags.ITEM);
            for (int i = 0; i < ItemsElements.Count(); ++i)
            {
                Item item = ReadItem(ItemsElements.ElementAt(i));
                if (id == item.ID)
                {
                    return item;
                }
            }
            return null;
        }


        public XElement WriteItem(Item item)
        {
            XElement itemElement =
               new XElement(XmlTags.ITEM,
                   new XElement(XmlTags.ID, item.ID),
                   new XElement(XmlTags.TITLE, item.Title),
                   new XElement(XmlTags.COMMENTARY, item.Commentary),
                   new CategoryDAO().writeCategory(item),
                   new XElement(XmlTags.CREATIONDATE, item.CreationDate),
                   new XElement(XmlTags.TODOFOR, item.ToDoForDate));

            return itemElement;
        }

        private IEnumerable<XElement> allItems(MyConnection connection, User CurrentUser)
        {
            var listXElementUser = connection.mXDoc.Descendants(XmlTags.USER);
            UserDAO dao = new UserDAO();
            foreach (XElement element in listXElementUser)
            {
                User UserParent = dao.ReadUser(element);
                if (UserParent.Equals(CurrentUser) && CurrentUser.ID == UserParent.ID)
                {
                    return element.Descendants(XmlTags.ITEM);
                }
            }
            return null;
        }


        public override void updateToUser(MyConnection connection, Item CurentItem, User currentUser)
        {
            UserDAO dao = new UserDAO();
            IEnumerable<XElement> ItemsElements = allItems(connection, currentUser);
            for (int i = 0; i < ItemsElements.Count(); ++i)
            {
                Item item = ReadItem(ItemsElements.ElementAt(i));
                if (CurentItem.ID == item.ID)
                {
                    ItemsElements.ElementAt(i).ReplaceWith(WriteItem(CurentItem));
                }
           }
        }

        public override void update(MyConnection connection, BusinessObject obj)
        {
            Item CurentItem = (Item)obj;
            IEnumerable<XElement> ItemsElements = connection.mXDoc.Elements(XmlTags.ITEM);
            for (int i = 0; i < ItemsElements.Count(); ++i)
            {
                Item item = ReadItem(ItemsElements.ElementAt(i));
                if (CurentItem.ID == item.ID)
                {
                    ItemsElements.ElementAt(i).ReplaceWith(WriteItem(CurentItem));
                }
            }
        }
    }
}
