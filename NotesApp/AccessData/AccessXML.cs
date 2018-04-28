using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Connection;
using System.Xml;
using System.IO;
using System.Net;
using System.Xml.Linq;
using DAOXml;
using SecurityXML;

namespace AccessData
{
    public class AccessXML : AccessData
    {
       

        /// <summary>
        /// constructor
        /// </summary>
        public AccessXML()
        {
            this.ItemDao = new DAOXml.ItemDAO();
            this.UserDao = new DAOXml.UserDAO();
            this.CategoryDao = new DAOXml.CategoryDAO();

           
        }
        public string FilePath()
        {
            DirectoryInfo dirInfo = Directory.GetParent((Directory.GetCurrentDirectory()));
            string dirData = dirInfo.FullName + "\\DAOXml\\data\\";


            return dirData + XmlTags.XML_FILE;
        }

        public override void CloseConnect()
        {
            if (Security)
            {
                string textDecrypted = ConverterStringFile.XDocumentToString(MyConnection.Instance.mXDoc);
                string textEncrypted = new Encrypt().execute(textDecrypted,this.Key,this.IV);
                ConverterStringFile.StringToFile(FilePath(), textEncrypted);
            }
            else
            {
                MyConnection.Instance.mXDoc.Save(FilePath());
            }
        }


        public override void Connect()
        {
            if (!MyConnection.Instance.HasXMLConnection())
            {
                MyConnection.Instance.InitXML(FilePath(),this.Security, this.Key, this.IV);
            }
            
            
        }

       

    }
}
