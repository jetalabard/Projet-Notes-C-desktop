
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using Business;
using System.Xml.Linq;
using System.Xml;

namespace DAOXml
{
    public class CategoryDAO : AbstractCategoryDAO
    {
        public override List<BusinessObject> all(MyConnection connection)
        {
            var list = connection.mXDoc.Descendants(XmlTags.CATEGORY).Select(elt => ReadCategory(elt));
            return list.Cast<BusinessObject>().ToList();
        }



        /// <summary>
        /// read category in Xelement
        /// </summary>
        /// <param name="categoElement"></param>
        /// <returns></returns>
        internal Category ReadCategory(XElement categoElement)
        {

            string title = null;
            int id = -1;
            if (categoElement.Element(XmlTags.TITLE) != null)
            {
                title = categoElement.Element(XmlTags.TITLE).Value;
            }
            if (categoElement.Element(XmlTags.ID) != null)
            {
                id = XmlConvert.ToInt32(categoElement.Element(XmlTags.ID).Value);
            }

            return new Category(title, id);
        }

        public override List<BusinessObject> allUserCategories(MyConnection connection,User user)
        {
            List<BusinessObject> Categories = new List<BusinessObject>();
            var listXElementCategories = connection.mXDoc.Descendants(XmlTags.CATEGORY);
            UserDAO dao = new UserDAO();
            foreach (XElement element in listXElementCategories)
            {
                XElement parent = element.Parent;
                while (!parent.Name.ToString().Equals(XmlTags.USER))
                {
                    parent = parent.Parent;
                }
                User UserParent= dao.ReadUser(parent);
                if(user.Equals(UserParent) && user.ID == UserParent.ID )
                {
                    Category category = ReadCategory(element);
                    if (!Categories.Contains(category))
                    {
                        Categories.Add(category);
                    }
                    
                }
            }
            return Categories;
        }

        public override void create(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public override BusinessObject get(MyConnection connection, int id)
        {
            throw new NotImplementedException();
        }

        public override void update(MyConnection connection, BusinessObject obj)
        {
            throw new NotImplementedException();
        }

        public XElement writeCategory(Item item)
        {
            XElement categoElement =
               new XElement(XmlTags.CATEGORY,
                   new XElement(XmlTags.ID, item.Type.ID),
                   new XElement(XmlTags.TITLE, item.Type.Title));
                   
            return categoElement;
        }
    }
}
