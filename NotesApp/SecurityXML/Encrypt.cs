using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecurityXML
{
    public class Encrypt
    {
        public string execute(string unencrypted,string k, string IV)
        {
            /*byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
            byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };*/
            byte[] key = System.Convert.FromBase64String(k);
            byte[] vector = System.Convert.FromBase64String(IV);
            ICryptoTransform encryptor;
            UTF8Encoding encoder;

            RijndaelManaged rm = new RijndaelManaged();
            encryptor = rm.CreateEncryptor(key, vector);
            encoder = new UTF8Encoding();

            return Convert.ToBase64String(Encryptpr(encoder.GetBytes(unencrypted),encryptor));
        }

        public byte[] Encryptpr(byte[] buffer, ICryptoTransform encryptor)
        {
            return Transform(buffer, encryptor);
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
