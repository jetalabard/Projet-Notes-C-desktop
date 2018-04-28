
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using Business;

namespace DAOTest
{
    public class CategoryDAO : AbstractCategoryDAO
    {
        List<BusinessObject> Categories = new List<BusinessObject> {
            new Category("title",1)
        };
        public override List<BusinessObject> all(MyConnection connection)
        {
            return Categories;
        }

        public override List<BusinessObject> allUserCategories(MyConnection instance, User user)
        {
            throw new NotImplementedException();
        }

        public override void create(MyConnection connection, BusinessObject obj)
        {
            Categories.Add((Category)obj);
        }

        public override void delete(MyConnection connection, BusinessObject obj)
        {
            Categories.Remove((Category)obj);
        }

        public override BusinessObject get(MyConnection connection, int id)
        {
            List<Category> catego = Categories.Cast<Category>().ToList();
            if(catego != null || catego.Count == 0)
            {
                return null;
            }
            return (Category)catego.Where(category => category.ID == id).ToList().ElementAt(0);
        }

        public override void update(MyConnection connection, BusinessObject obj)
        {
            List<Category> categories = Categories.Cast<Category>().ToList();
            Category CategoryObj = (Category)obj;
            Category theCategory = (Category)categories.Where(category => category.ID == CategoryObj.ID).Take(0);
            theCategory.Title = CategoryObj.Title;

        }
    }
}
