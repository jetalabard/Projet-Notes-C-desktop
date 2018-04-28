using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Item : BusinessObject, IComparable<Item>
    {
        public string Title
        {
            get;
            set;
        }

        public string Commentary
        {
            get;
            set;
        }

        public int ID
        {
            get;
        }

        public Category Type
        {
            get;
            set;
        }


        public DateTime CreationDate
        {
            get;
        }

        public DateTime ToDoForDate
        {
            get;
            set;
        }

        public int User
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Title;
        }

        public Item(string title, int id, Category type, DateTime dateCreation, DateTime toDoDate,string commentary, int user)
        {
            this.Commentary = commentary;
            this.CreationDate = dateCreation;
            this.ID = id;
            this.Title = title;
            this.Type = type;
            this.ToDoForDate = toDoDate;
            this.User = user;
        }

        public override bool Equals(object obj)
        {
            Item item = obj as Item;
            if(item == null)
            {
                return false;
            }
            return item.ID == this.ID && item.Title == this.Title;
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public int CompareTo(Item other)
        {
            return Title.CompareTo(other.Title);
        }

    }

   
}
