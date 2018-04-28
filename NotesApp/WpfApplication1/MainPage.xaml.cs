using AppWindowsWPF.Vm;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppWindowsWPF
{
    /// <summary>
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {

        public static readonly string TITLE = "MAIN_PAGE";

        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        private void Loading(object sender, RoutedEventArgs e)
        {
            Title = "NotesApp - " + Manager.Instance.CurrentUser.Name;
            User current = Manager.Instance.CurrentUser;

            List<Category> categories = Manager.Instance.AccessData.getCategories(current);
            categories.Add(new Category("Toutes les catégories",-1));
            mListBoxCategories.ItemsSource = categories;
            mListBoxCategories.SelectedItem = null;
            var listItems = new List<Item>(Manager.Instance.AccessData.getUserItems(current));

            listNotes.ItemsSource = listItems;
            List<Button> listButtons = new List<Button>()
            {
                new Button( XmlTags.ADD_BUTTON, "add.png" ),
                new Button( XmlTags.PROFIL_BUTTON, "profile-icon-9.png" ),
                new Button( XmlTags.LOGOFF, "logout.png" )
            };
            listButton.ItemsSource = listButtons;

        }

       

        internal void reload()
        {
            DataContext = null;
            Loading(null, null);
        }

        private void Profil(object sender, RoutedEventArgs e)
        {
            new ClickButtonController(XmlTags.PROFIL_BUTTON).execute(this);
        }

        private void AddNote(object sender, RoutedEventArgs e)
        {
            new ClickButtonController(XmlTags.ADD_BUTTON).execute(this);
        }

        public class Button
        {
            public string ButtonName
            {
                get;
                set;
            }
            
            public string Source
            {
                get;
                set;
            }
            
            public Button (string name,string source)
            {
                this.ButtonName = name;
                this.Source = source;
            }
        }

        private void mListBoxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Category selectedCategory = (Category) mListBoxCategories.SelectedItem;
            if (selectedCategory != null && selectedCategory.ID >=0) { 
                listNotes.ItemsSource =Manager.Instance.AccessData.ItemsFilteredByCategory(Manager.Instance.CurrentUser,
                selectedCategory);
            }else
            {
                Loading(null, null);
            }
        }
    }
}
