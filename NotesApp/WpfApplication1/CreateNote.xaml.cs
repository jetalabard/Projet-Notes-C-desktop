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
using Business;
using AppWindowsWPF.Vm;
using System.ComponentModel;

namespace AppWindowsWPF
{
    /// <summary>
    /// Logique d'interaction pour SeeAndUpdateNote.xaml
    /// </summary>
    public partial class CreateNote : Window
    {
        private Item item;
        public readonly static string TITLE = "CREATE_NOTE_PAGE";

        public MainPage MainPage { get; private set; }

        public CreateNote(MainPage page)
        {
            User user = Manager.Instance.CurrentUser;
            DateTime now = DateTime.Today;
            item = new Item("Titre", Manager.Instance.AccessData.GetNewIdItem(user), null, now
                , now, "", user.ID);
            InitializeComponent();
            
            
            DataContext = item;
            Title = "Création d'une Note";
            this.MainPage = page;
            
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Manager.Instance.changePage(MainPage.TITLE);
        }
        
        private void Window_Closed(object sender, EventArgs e)
        {
            Manager.Instance.changePage(MainPage.TITLE);
        }

        private void Validate(object sender, EventArgs e)
        {
            Manager.Instance.AccessData.CreateItem(item, Manager.Instance.CurrentUser);
            Manager.Instance.changePage(MainPage.TITLE);
            MainPage.reload();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Closing += new CancelEventHandler(Window_Closing);
            Closed += new EventHandler(Window_Closed);
            listCategory.ItemsSource = Manager.Instance.AccessData.getCategories(Manager.Instance.CurrentUser);
            TextBoxCommentary.AcceptsReturn = true;
            listCategory.SelectedIndex = 0;
            this.item.Type = (Category)listCategory.SelectedValue;
            CreationDate.Text = (string) new Converter.DateTimeConverter().Convert(item.CreationDate,null,null,null);
            DatePickerToDoForDate.SelectedDate = this.item.ToDoForDate;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker datePicker = (DatePicker)sender;
            if(datePicker.SelectedDate > this.item.CreationDate)
            {
                this.item.ToDoForDate = Convert.ToDateTime(datePicker.SelectedDate.ToString());
            }
            else
            {
                datePicker.SelectedDate = this.item.ToDoForDate;
            }
            
        }

        private void listCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            this.item.Type = (Category) combo.SelectedValue;
        }

        private void Button_Click_Add_Category(object sender, RoutedEventArgs e)
        {
            InputDialog input = new InputDialog("Veuillez saisir une nouvelle Catégorie");
            if(input.ShowDialog()== true)
            {
                List<Category> categories = listCategory.ItemsSource.Cast<Category>().ToList();
                int idCategory = Manager.Instance.AccessData.GetNewIdCategory(Manager.Instance.CurrentUser);
                Category category = new Category(input.Answer, idCategory);
                categories.Add(category);
                listCategory.ItemsSource = categories;
                listCategory.SelectedItem = category;
            }
        }

        private void TextBoxCommentary_TextChanged(object sender, TextChangedEventArgs e)
        {
            item.Commentary = ((TextBox)sender).Text;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            item.Title = ((TextBox)sender).Text;
        }
    }
}
