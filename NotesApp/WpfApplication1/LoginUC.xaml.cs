
using AccessData;
using AppWindowsWPF.Vm;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {
        private List<User> Users;
        private AccessData.AccessData access;
        public static readonly string TITLE = "LOGIN";

        public LoginUC()
        {

            InitializeComponent();
            access = Manager.Instance.AccessData;
            Users = access.getUsers();

        }

        

        private void uc_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            Keyboard.Focus(this);
            btn.Focusable = true;


        }

        private void CreateUserClick(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            Manager.Instance.changePage(CreateUserUC.TITLE);
            myWindow.Content = new CreateUserUC();

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

            if (string.IsNullOrWhiteSpace(TextName.Text) && string.IsNullOrWhiteSpace(TextPassword.Password))
            {
                Error.Text = "Veuillez saisir le nom et le mot de passe";
                TextName.BorderBrush = System.Windows.Media.Brushes.Red;
                TextPassword.BorderBrush = System.Windows.Media.Brushes.Red;
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
            else
            {
                if (Users != null)
                {

                    foreach (User u in Users)
                    {
                        Console.WriteLine(u.ToString());
                        if (u.Name.Equals(TextName.Text) && u.Password.Equals(TextPassword.Password))
                        {
                            if (Manager.Instance.isThisPage(TITLE))
                            {
                                Manager.Instance.CurrentUser = u;
                                MainPage main = new MainPage();
                                main.Show();
                                Manager.Instance.changePage(MainPage.TITLE);
                                var myWindow = Window.GetWindow(this);
                                myWindow.Close();
                            }
                            
                        }
                    }
                    Error.Text = "Un des champs n'est pas valide.";
                }
                else
                {
                    MessageBox.Show("Il est impossible de se connecter aux données. Réessayez plus tard.");
                }
            }




        }
    }
}
