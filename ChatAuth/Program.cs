// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ChatAuth
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization());
            //Application.Run(new Chat("admin"));
            //MessageBox.Show(Dec(""));
            //byte[] enc = EncryptStringToBytes_Aes("357538782F413F4428472B4B62506453357538782F413F4428472B4B62506453357538782F413F4428472B4B62506453357538782F413F4428472B4B625064", key);
            //MessageBox.Show(enc.ToString());
            //string enc1 = System.Text.Encoding.Default.GetString(enc.Where(x => x != 0).ToArray());

            //enc = System.Text.Encoding.Default.GetBytes(enc1);
            //string text = DecryptStringFromBytes_Aes(enc, key);
            //MessageBox.Show(text);
        }

        public static string Enc(string text)
        {
            string encryptedText = "123";
            byte[] key = System.Text.Encoding.Default.GetBytes("357538782F413F4428472B4B62506453");

            byte[] enc = EncryptStringToBytes_Aes(text, key);
            encryptedText = System.Text.Encoding.Default.GetString(enc.Where(x => x != 0).ToArray());

            encryptedText = encryptedText.Replace("'", "111111");
            encryptedText = encryptedText.Replace(" ", "222222");
            encryptedText = encryptedText.Replace("\"", "333333");
            encryptedText = encryptedText.Replace(" ", "444444");
            MessageBox.Show("Enc:" + encryptedText);

            return encryptedText;

        }

        public static string Dec(string text)
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("357538782F413F4428472B4B62506453");

            text = text.Replace("111111", "'");
            text = text.Replace("222222", " ");
            text = text.Replace("333333", "\"");
            text = text.Replace("444444", " ");

            byte[] enc = System.Text.Encoding.Default.GetBytes(text);
            string decryptedText = DecryptStringFromBytes_Aes(enc, key);

            return decryptedText;
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key)    
        {
            byte[] encrypted;
            byte[] IV;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;

                aesAlg.GenerateIV();
                IV = aesAlg.IV;

                aesAlg.Mode = CipherMode.CBC;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption. 
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            var combinedIvCt = new byte[IV.Length + encrypted.Length];
            Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
            Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

            // Return the encrypted bytes from the memory stream. 
            return combinedIvCt;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherTextCombined, byte[] Key)
        {

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an Aes object 
            // with the specified key and IV. 
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;

                byte[] IV = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[cipherTextCombined.Length - IV.Length];

                Array.Copy(cipherTextCombined, IV, IV.Length);
                Array.Copy(cipherTextCombined, IV.Length, cipherText, 0, cipherText.Length);

                aesAlg.IV = IV;

                aesAlg.Mode = CipherMode.CBC;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption. 
                try
                {
                    using (var msDecrypt = new System.IO.MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.

                                plaintext = srDecrypt.ReadToEnd();


                            }
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("Произошла ошибка длины блока");
                }
                

            }

            return plaintext;

        }
    }
}
