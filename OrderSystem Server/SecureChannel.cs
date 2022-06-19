using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem_Server
{
    public class SecureChannel
    {
        private ICryptoTransform _encryptor;
        private ICryptoTransform _decryptor;
        private readonly string _key = "c33ac5988a4e4331ccbe2ea2315a2564";


        public SecureChannel()
        {
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.None;
                aes.Key = Encoding.UTF8.GetBytes(_key);
                _encryptor = aes.CreateEncryptor(aes.Key, new byte[16]);
                _decryptor = aes.CreateDecryptor(aes.Key, new byte[16]);
            }
        }

        public byte[] Encrypt(string data)
        {
            byte[] encryptedData;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memStream, _encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(cryptoStream))
                    {
                        writer.Write(data);
                    }
                    encryptedData = memStream.ToArray();
                }
            }

            // Return encrypted data    
            return encryptedData;
        }
        public string Decrypt(byte[] data)
        {
            string decryptedData = null;
            // Create the streams used for decryption.    
            using (MemoryStream memStream = new MemoryStream(data))
            {
                // Create crypto stream    
                using (CryptoStream cryptoStream = new CryptoStream(memStream, _decryptor, CryptoStreamMode.Read))
                {
                    // Read crypto stream    
                    using (StreamReader reader = new StreamReader(cryptoStream))
                        decryptedData = reader.ReadLine();
                }
            }
            return decryptedData;
        }
    }
}
