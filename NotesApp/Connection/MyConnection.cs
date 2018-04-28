using MySql.Data.MySqlClient;
using SecurityXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connection
{
    public class MyConnection
    {

        private static MyConnection instance;

        /// <summary>
        /// document
        /// </summary>
        public XDocument mXDoc
        {
            get;
            set;
        }

        private MyConnection() { }

        public static MyConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyConnection();
                }
                return instance;
            }
        }

        public MySqlConnection ConnectionMysql
        {
            get;
            set;
        }

        public void InitXML(string file,bool Security,string key, string IV)
        {
            
            if (Security)
            {
                string encodedString = ConverterStringFile.FileToString(file);
                string textDecrypted = new Decrypt().execute(encodedString,key,IV);
                mXDoc = ConverterStringFile.StringToXDocument(textDecrypted);
            }
            else
            {
                LoadXMLFile(file);
            }
        }


        public void InitSQL(string dATABASE_NAME, string pASSWORD, string pORT, string sERVOR, string uSER_ID)
        {
            string connstring = string.Format("SERVER={0};PORT={1}; DATABASE={2}; UID={3}; PASSWORD={4};", sERVOR, pORT,
                dATABASE_NAME, uSER_ID, pASSWORD);
            try
            {
                ConnectionMysql = new MySqlConnection(connstring);
                ConnectionMysql.Open();
            }
            catch (MySqlException ex)
            {
                ConnectionMysql = null;
                Console.WriteLine(ex.ToString());
            }
        }

        public bool HasMySQLConnection()
        {
            return ConnectionMysql != null;
        }

        public bool HasXMLConnection()
        {
            return mXDoc != null; ;
        }

        /// <summary>
        /// charge un fichier xml
        /// </summary>
        /// <param name="xml_file">chemin du fichier</param>
        private void LoadXMLFile(string xml_file)
        {
            try
            {
                mXDoc = XDocument.Load(xml_file);
            }
            catch (SystemException e)
            {
                Console.WriteLine(e);
            }
            
        }

    }
}
