using AppWindowsWPF.Vm;
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
    /// Logique d'interaction pour CreateUser.xaml
    /// </summary>
    public partial class CreateUserUC : UserControl
    {

        private AccessData.AccessData access;
        public static readonly string TITLE = "CREATE_PROFIL";

        public CreateUserUC()
        {
            InitializeComponent();

            access = Manager.Instance.AccessData;

        }


        private void Name_changed(object sender, RoutedEventArgs e)
        {
            TextName.BorderBrush = System.Windows.Media.Brushes.DodgerBlue;

        }

        private void Loading(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Title = "Création du Profil";

        }
        

        private void ClickToReturnHome(object sender, RoutedEventArgs e)
        {
            Image image = (Image)sender;
            image.Opacity = 0.1f;
            var myWindow = Window.GetWindow(this);
            myWindow.Content = new LoginUC();

        }

        private void MouseEnterButtonToReturnHome(object sender, RoutedEventArgs e)
        {

            Image image = (Image)sender;
            image.Opacity = 0.1f;

        }
        private void MouseLeaveButtonToReturnHome(object sender, RoutedEventArgs e)
        {

            Image image = (Image)sender;
            image.Opacity = 1;

        }



        private void PassWord_changed(object sender, RoutedEventArgs e)
        {
            TextPassword.BorderBrush = System.Windows.Media.Brushes.DodgerBlue;
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            Error.Text = "";

            if (string.IsNullOrWhiteSpace(TextName.Text) && string.IsNullOrWhiteSpace(TextPassword.Password) && string.IsNullOrWhiteSpace(TextPassword1.Password))
            {
                Error.Text = "Veuillez saisir le nom et le mot de passe";
                TextName.BorderBrush = System.Windows.Media.Brushes.Red;
                TextPassword.BorderBrush = System.Windows.Media.Brushes.Red;
                TextPassword1.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (string.IsNullOrWhiteSpace(TextName.Text))
            {
                Error.Text = "Veuillez saisir le nom";
                TextName.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (string.IsNullOrWhiteSpace(TextPassword.Password))
            {
                Error.Text = "Veuillez saisir le mot de passe";
                TextPassword.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (string.IsNullOrWhiteSpace(TextPassword1.Password))
            {
                Error.Text = "Veuillez confirmer le mot de passe";
                TextPassword1.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (!TextPassword1.Password.Equals(TextPassword.Password))
            {
                Error.Text = "Veuillez confirmer le mot de passe";
                TextPassword.BorderBrush = System.Windows.Media.Brushes.Red;
                TextPassword1.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                if (access.verifIfUserExist(TextName.Text, TextPassword.Password))
                {
                    Error.Text = "Cet utilisateur existe déjà.";
                }
                else
                {
                    
                    if (Manager.Instance.isThisPage(TITLE))
                    {
                        int id = access.GetNewIdUser();
                        Manager.Instance.CurrentUser = new Business.User(id, TextPassword.Password, TextName.Text);
                        access.createUser(Manager.Instance.CurrentUser);
                        MainPage main = new MainPage();
                        main.Show();
                        var myWindow = Window.GetWindow(this);
                        Manager.Instance.changePage(MainPage.TITLE);
                        myWindow.Close();
                    }

                }
            }

        }
    }
}
