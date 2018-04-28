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
    public partial class SeeAndUpdateNote : Window
    {
        private Item item;
        public readonly static string TITLE = "UPDATE_NOTE_PAGE";

        public MainPage MainPage { get; private set; }

        public SeeAndUpdateNote(Item item,MainPage page)
        {
            InitializeComponent();
            this.item = item;
            Title = item.Title;
            DataContext = this.item;
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
            Manager.Instance.AccessData.UpdateItem(item, Manager.Instance.CurrentUser);
            Manager.Instance.changePage(MainPage.TITLE);
            MainPage.reload();
            this.Close();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Closing += new CancelEventHandler(Window_Closing);
            Closed += new EventHandler(Window_Closed);
            listCategory.ItemsSource = Manager.Instance.AccessData.getCategories(Manager.Instance.CurrentUser);
            TextBoxCommentary.AcceptsReturn = true;
            listCategory.SelectedItem = this.item.Type;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker datePicker = (DatePicker)sender;
            if (datePicker.SelectedDate > this.item.CreationDate)
            {
                this.item.ToDoForDate = Convert.ToDateTime(datePicker.SelectedDate.ToString());
            }
            else
            {
                datePicker.SelectedDate = this.item.ToDoForDate;
            }

        }
        
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
