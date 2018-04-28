using AccessData;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWindowsWPF.Vm
{
    public sealed class Manager
    {
        private static Manager instance;

        
        
        private string Page;

        public static Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manager();
                }
                return instance;
            }
        }
        private Manager() {
            AccessData = new AccessXML();
            Page = LoginUC.TITLE;
            AccessData.Key =  Properties.Settings.Default.Key;
            AccessData.IV = Properties.Settings.Default.IV;

            AccessData.Security = false;
        }

        public AccessData.AccessData AccessData
        {
            get;
        }

        public User CurrentUser
        {
            get;
            set;
        }

        public void changePage(string NewPage)
        {
            Page = NewPage;
        }

        public bool isThisPage(string PageToTest)
        {
            if (string.IsNullOrEmpty(Page))
            {
                return false;
            }
            return Page.Equals(PageToTest);
        }





    }
}
