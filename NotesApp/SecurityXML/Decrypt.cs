using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SecurityXML
{
    public class Decrypt
    {
        public string execute(string encrypted,string k, string IV)
        {
            
          /*  byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
            byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };
            */
            byte[] key = System.Convert.FromBase64String(k);
            byte[] vector = System.Convert.FromBase64String(IV);

            ICryptoTransform decryptor;
            UTF8Encoding encoder;

            RijndaelManaged rm = new RijndaelManaged();
            decryptor = rm.CreateDecryptor(key, vector);
            encoder = new UTF8Encoding();

            try
            {
                return encoder.GetString(Decryptor(Convert.FromBase64String(encrypted), decryptor));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return encrypted;
            }


        }
        public byte[] Decryptor(byte[] buffer, ICryptoTransform decryptor)
        {
            return Transform(buffer, decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }

    }
}
