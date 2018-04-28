using Connection;
using DAO;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData
{
    public abstract class AccessData
    {

        public AbstractItemDAO ItemDao
        {
            get;
            set;
        }
        public AbstractCategoryDAO CategoryDao
        {
            get;
            set;
        }
        public AbstractUserDAO UserDao
        {
            get;
            set;
        }

        /**
         * this 3 properties manage cryptographic Security 
         */

        public bool Security { get; set; }
        public string Key { get; set; }
        public string IV { get; set; }

        public abstract void Connect();

        public abstract void CloseConnect();

        public List<User> getUsers()
        {
            Connect();
            List<User> users = UserDao.all(MyConnection.Instance).Cast<User>().ToList();
            CloseConnect();
            return users;

        }

        public List<Item> getUserItems(User user)
        {
            Connect();
            List<Item> Items = ItemDao.getUserItems(MyConnection.Instance, user).Cast<Item>().ToList();
            CloseConnect();
            return Items;
        }


        public List<Category> getCategories(User user)
        {
            Connect();
            List<Category> categories = CategoryDao.allUserCategories(MyConnection.Instance, user).Cast<Category>().ToList();
            CloseConnect();
            return categories;
        }

        public void deleteItem(Item item, User currentUser)
        {
            Connect();
            ItemDao.delete(MyConnection.Instance, item);
            CloseConnect();
        }

        public void CreateItem(Item item, User currentUser)
        {
            Connect();
            item.User = currentUser.ID;
            ItemDao.create(MyConnection.Instance, item);
            CloseConnect();
        }

        public void deleteUser(User user)
        {
            Connect();
            UserDao.delete(MyConnection.Instance,user);
            CloseConnect();
        }

        public void UpdateItem(Item item, User currentUser)
        {
            Connect();
            ItemDao.updateToUser(MyConnection.Instance, item,currentUser);
            CloseConnect();
        }

        public void createUser(User user)
        {
            Connect();
            UserDao.create(MyConnection.Instance, user);
            CloseConnect();
        }

        public bool verifIfUserExist(string name, string password)
        {
            //warning see implementation of Equals of User
            User user = new User(0, password, name);
            foreach(User u in getUsers())
            {
                if (user.Equals(u))
                {
                    return true;
                }
            }
            return false;
        }

        public int GetNewIdUser()
        {
            int id = 0;
            List<User> users = getUsers().OrderBy(user => user.ID).ToList();
            foreach (User u in users)
            {
                if(id == u.ID)
                {
                    id++;
                }
            }
            return id;
        }

        public void UpdateUser(User currentUser)
        {
            Connect();
            UserDao.update(MyConnection.Instance, currentUser);
            CloseConnect();
        }

        public int GetNewIdItem(User user)
        {
            int id = 0;
            List<Item> Items = getUserItems(user).OrderBy(item => item.ID).ToList();
            foreach (Item i in Items)
            {
                if (id == i.ID)
                {
                    id++;
                }
            }
            return id;
        }

        public int GetNewIdCategory(User user)
        {
            int id = 0;
            List<Category> Categories = getCategories(user).OrderBy(catego => catego.ID).ToList();
            foreach (Category i in Categories)
            {
                if (id == i.ID)
                {
                    id++;
                }
            }
            return id;
        }

        public List<Item> ItemsFilteredByCategory(User user,Category category)
        {
            List<Item> Items = getUserItems(user);
            return Items.Where(item => item.Type.ID == category.ID).ToList();
        }


    }
}
