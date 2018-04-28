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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWindowsWPF
{
    /// <summary>
    /// Logique d'interaction pour NotesUC.xaml
    /// </summary>
    public partial class NotesUC : UserControl
    {
        public NotesUC()
        {
            InitializeComponent();
            

        }
        
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Titre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(NotesUC), new PropertyMetadata("Title"));




        public string Commentary
        {
            get { return (string)GetValue(CommentaryProperty); }
            set { SetValue(CommentaryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Note.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentaryProperty =
            DependencyProperty.Register("Commentary", typeof(string), typeof(NotesUC), new PropertyMetadata("Commentary"));



        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CategoryProperty =
            DependencyProperty.Register("Category", typeof(string), typeof(NotesUC), new PropertyMetadata("Category"));

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(string), typeof(NotesUC), new PropertyMetadata("06/08/2017"));


        private void Mouse_Enter(object sender, RoutedEventArgs e)
        {
            StackPanel stack = sender as StackPanel;
            stack.Background = System.Windows.Media.Brushes.WhiteSmoke;
        }

        private void Mouse_Leave(object sender, RoutedEventArgs e)
        {
            StackPanel stack = sender as StackPanel;
            stack.Background = System.Windows.Media.Brushes.White;
        }

        private void Open_Note(object sender, RoutedEventArgs e)
        {
            Item item = DataContext as Item;
            MainPage myWindow = (MainPage) Window.GetWindow(this);
            new ClickButtonController().Open_Note(item, myWindow);
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Item item = DataContext as Item;
            string str = item.Commentary;
            TextCommentary.Text = str.Length > 40 ? str.Substring(0, 40) : str;
            if (TextCommentary.Text.Length == 40)
            {
                TextCommentary.Text += "...";
            }
        }

        private void StackPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Item item = DataContext as Item;
            ContextMenu cm = new ContextMenu();
            MenuItem remove = new MenuItem();
            remove.Header = "Supprimer";
            MenuItem update = new MenuItem();
            update.Header = "Modifier";
            cm.Items.Add(update);
            cm.Items.Add(remove);

            this.ContextMenu = cm;
            MainPage myWindow = (MainPage)Window.GetWindow(this);
            update.Click += delegate { new ClickButtonController().Open_Note(item, myWindow); };
           remove.Click += delegate { new ClickButtonController().Remove_Note(item, myWindow); };
        }
    }
}
