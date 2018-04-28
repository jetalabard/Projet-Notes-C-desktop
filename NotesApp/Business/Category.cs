using System;

namespace Business
{
    public class Category : BusinessObject, IComparable<Category>
    {
        public string Title
        {
            get;
            set;
        }

        public int ID
        {
            get;
        }


        public override string ToString()
        {
            return Title;
        }

        public Category(string Title, int id)
        {
            this.Title = Title;
            this.ID = id;
        }

        public override bool Equals(object obj)
        {
            Category category = obj as Category;

            return category.ID == this.ID && category.Title == this.Title;
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public int CompareTo(Category other)
        {
            return Title.CompareTo(other.Title);
        }
    }
}