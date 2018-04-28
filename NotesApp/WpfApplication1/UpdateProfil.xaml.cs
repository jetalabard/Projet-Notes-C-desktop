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
using Business;

namespace AppWindowsWPF
{
    /// <summary>
    /// Logique d'interaction pour UpdateProfil.xaml
    /// </summary>
    public partial class UpdateProfil : Window
    {
        public readonly static string TITLE = "UPDATE_PROFIL_PAGE";
        private User oldUser;

        public MainPage Mainpage { get; private set; }

        public UpdateProfil(MainPage main)
        {
            InitializeComponent();
            oldUser = Manager.Instance.CurrentUser;
            DataContext = Manager.Instance.CurrentUser;
            Mainpage = main;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextName.Text = Manager.Instance.CurrentUser.Name;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Name_changed(object sender, RoutedEventArgs e)
        {
            TextName.BorderBrush = System.Windows.Media.Brushes.DodgerBlue;

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
                Error.Text = "Veuillez saisir le nouveau mot de passe";
                TextPassword.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (string.IsNullOrWhiteSpace(TextPassword1.Password))
            {
                Error.Text = "Veuillez saisir l'ancien mot de passe";
                TextPassword1.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                
                if (Manager.Instance.AccessData.verifIfUserExist(TextName.Text, TextPassword.Password))
                {
                    Error.Text = "Cet utilisateur existe déjà.";
                }
                else
                {

                    if (!Manager.Instance.isThisPage(TITLE) && TextPassword1.Password.Equals(oldUser.Password))
                    {
                        Manager.Instance.CurrentUser.Password = TextPassword.Password;
                        Manager.Instance.CurrentUser.Name =  TextName.Text;
                        Manager.Instance.CurrentUser.Items = Manager.Instance.AccessData.getUserItems(oldUser);
                        Manager.Instance.AccessData.UpdateUser(Manager.Instance.CurrentUser);
                        Manager.Instance.changePage(MainPage.TITLE);
                        Mainpage.reload();
                        this.Close();
                    }
                    else
                    {
                        Error.Text = "Mot de passe incorrect.";
                        TextPassword1.BorderBrush = System.Windows.Media.Brushes.Red;
                    }


                }
            }
        }
    }
}
