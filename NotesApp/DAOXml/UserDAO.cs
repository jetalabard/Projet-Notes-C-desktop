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
using DAOXml;

namespace DAOXml
{
    public class UserDAO : AbstractUserDAO
    {
        public override List<BusinessObject> all(MyConnection connection)
        {
            var list = connection.mXDoc.Descendants(XmlTags.USER).Select(elt => ReadUser(elt));

            return list.Cast<BusinessObject>().ToList();
        }
        internal XElement ReadUser(MyConnection connection, User user)
        {
            IEnumerable<XElement> UsersElements = connection.mXDoc.Descendants(XmlTags.USER);
            for (int i = 0; i < UsersElements.Count(); ++i)
            {
                User u = ReadUser(UsersElements.ElementAt(i));
                if (user.ID == u.ID && user.Password.Equals(u.Password) && user.Name.Equals(u.Name))
                {
                   return UsersElements.ElementAt(i);
                }
            }
            return null;
        }

        /// <summary>
        /// lire un film dans le fichier
        /// </summary>
        /// <param name="userElement"></param>
        /// <returns></returns>
        internal User ReadUser(XElement userElement)
        {

            string name = null;
            string password = null;
            int id = -1;
            if (userElement.Element(XmlTags.NAME) != null)
            {
                name = userElement.Element(XmlTags.NAME).Value;
            }
            if (userElement.Element(XmlTags.PASSWORD) != null)
            {
                password = userElement.Element(XmlTags.PASSWORD).Value;
            }
            if (userElement.Element(XmlTags.ID) != null)
            {
                id = XmlConvert.ToInt32(userElement.Element(XmlTags.ID).Value);
            }

            return new User(id, password, name);
          }

        public override void create(MyConnection connection, BusinessObject obj)
        {
            User user = (User)obj;
            connection.mXDoc.Descendants(XmlTags.USERS)
                 .First()
                 .Add(WriteUser(user));
        }

        private XElement WriteUser(User user)
        {
            XElement userElement =
               new XElement(XmlTags.USER,
                   new XElement(XmlTags.ID, user.ID),
                   new XElement(XmlTags.NAME, user.Name),
                   new XElement(XmlTags.PASSWORD,user.Password),
                   new XElement(XmlTags.ITEMS, WriteItems(user))
            );

            return userElement;
        }

        /// <summary>
        /// écrit les acteurs du film
        /// </summary>
        /// <param name="film">film</param>
        /// <returns>liste de réprésentation xml d'acteurs</returns>
        private IEnumerable<XElement> WriteItems(User user)
        {
            if(user.Items == null || user.Items.Count == 0)
            {
                return null;
            }
            return user.Items.Select(item => new ItemDAO().WriteItem(item));
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
           User user = (User)obj;
            XElement todelete = null;
           IEnumerable<XElement> list = connection.mXDoc.Descendants(XmlTags.USER);
            foreach(XElement element in list)
            {
                if (element.Element(XmlTags.ID) != null && XmlConvert.ToInt32(element.Element(XmlTags.ID).Value) == user.ID)
                {
                    todelete = element;
                }
            }
            todelete.Remove();


        }

        public override BusinessObject get(MyConnection connection, int id)
        {
            List<User> users = all(connection).Cast<User>().ToList();
            if (users == null || users.Count == 0)
            {
                return null;
            }
            return (User)users.Where(user => user.ID == id).ToList().ElementAt(0);
        }

        public override void update(MyConnection connection, BusinessObject obj)
        {
            User user = (User)obj;
            IEnumerable<XElement> list = connection.mXDoc.Descendants(XmlTags.USER);
            foreach (XElement element in list)
            {
                if ( XmlConvert.ToInt32(element.Element(XmlTags.ID).Value) == user.ID)
                {
                    element.ReplaceWith(WriteUser(user));
                    break;
                }
            }
        }
    }
}