using AppWindowsWPF.Vm;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static AppWindowsWPF.MainPage;

namespace AppWindowsWPF
{
    public class ClickButtonController
    {
        public ClickButtonController()
        {
        }

        public ClickButtonController(String btn)
        {
            this.Button = btn;
        }

        public String Button { get; private set; }

        public void execute(Window Main)
        {
            if (string.IsNullOrEmpty(Button))
            {
                throw new Exception("Click on Button without parameter");
            }


            if (Button.Equals(XmlTags.ADD_BUTTON))
            {
                CreateNote createPage = new CreateNote((MainPage)Main);
                createPage.ShowDialog();

            }
            if (Button.Equals(XmlTags.PROFIL_BUTTON))
            {
                UpdateProfil update = new UpdateProfil((MainPage)Main);
                update.ShowDialog();
            }
            if (Button.Equals(XmlTags.LOGOFF))
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else
            {

            }
        }

        public void Open_Note(Item item,MainPage mainpage)
        {
            if (Manager.Instance.isThisPage(MainPage.TITLE))
            {
                SeeAndUpdateNote main = new SeeAndUpdateNote(item, mainpage);

                Manager.Instance.changePage(SeeAndUpdateNote.TITLE);
                main.ShowDialog();
                
            }

        }

        internal void Remove_Note(Item item, MainPage myWindow)
        {
            Manager.Instance.AccessData.deleteItem(item,Manager.Instance.CurrentUser);
            myWindow.reload();
        }
    }
}
