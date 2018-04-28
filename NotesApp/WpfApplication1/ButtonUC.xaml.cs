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
using static AppWindowsWPF.MainPage;

namespace AppWindowsWPF
{
    /// <summary>
    /// Logique d'interaction pour AccessAddNoteUC.xaml
    /// </summary>
    public partial class ButtonUC : UserControl
    {
        public ButtonUC()
        {
            InitializeComponent();
        }

        public string ButtonName
        {
            get { return (string)GetValue(ButtonNameProperty); }
            set { SetValue(ButtonNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Titre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonNameProperty =
            DependencyProperty.Register("ButtonName", typeof(string), typeof(ButtonUC), new PropertyMetadata("name"));



        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(string), typeof(ButtonUC), new PropertyMetadata("notesLogo.png"));


        private void Mouse_Enter(object sender, RoutedEventArgs e)
        {
            Border wrap = sender as Border;
            wrap.Background = System.Windows.Media.Brushes.WhiteSmoke;
        }

        private void Mouse_Leave(object sender, RoutedEventArgs e)
        {
            Border wrap = sender as Border;
            wrap.Background = System.Windows.Media.Brushes.White;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Button btn = DataContext as MainPage.Button;
            new ClickButtonController(btn.ButtonName).execute(Window.GetWindow(this));

        }
    }
}
