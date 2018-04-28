using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecurityXML
{
    public class ConverterStringFile
    {
        public static string FileToString(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public static XDocument StringToXDocument(string responseData)
        {
            return XDocument.Parse(responseData);
        }

        public static string XDocumentToString(XDocument mxDoc)
        {
            return mxDoc.ToString();
        }

        public static void StringToFile(string fileName,string text)
        {
            File.WriteAllText(fileName, text);
        }

        
    }
}
