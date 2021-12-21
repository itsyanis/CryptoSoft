using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptoSoft
{

    class Encryption
    {

        // This method will Encrypt file using Rijndael Algorithm
        public void EncryptFile(string SourcePath, string DestinationPath)
        {
            if (File.Exists(SourcePath))
            {
                try
                {
                    string password = "$p@ss_2$";

                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);            // Encrypt our password into a sequence of bytes.

                    FileStream CryptedFile = new FileStream(DestinationPath, FileMode.Create);   // Create the CryptedFile in destination Path (The file is empty, not yet encrypted) 

                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    CryptoStream DestinationFile = new CryptoStream(CryptedFile, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);    // Cryptage Algorithm

                    FileStream SouceFile = new FileStream(SourcePath, FileMode.Open);    // Open the source File

                    int data;
                    while ((data = SouceFile.ReadByte()) != -1)    // Loop on the source file byte by byte 
                    {
                        DestinationFile.WriteByte((byte)data);        // Encrypt and write into DestinationFile File 
                    }

                    SouceFile.Close();      // Close files
                    DestinationFile.Close();
                    CryptedFile.Close();

                    Console.WriteLine("\n File Crypted successfully !");

                }
                catch (Exception e)
                {
                    Console.WriteLine("\n Error" + e.ToString());
                }
            }
            else
            {
                Console.WriteLine("\n The source path : " + SourcePath + "doesn't exists.");
            }
        }



        // This method will Dencrypt file using Rijndael Algorithm
        public void DecryptFile(string SourcePath, string DestinationPath)
        {
            if (File.Exists(SourcePath))
            {
                try
                {
                    string password = "$p@ss_2$";
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);

                    FileStream SouceFile = new FileStream(SourcePath, FileMode.Open);

                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    CryptoStream Source = new CryptoStream(SouceFile, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

                    FileStream DestinationFile = new FileStream(DestinationPath, FileMode.Create);

                    int data;
                    while ((data = Source.ReadByte()) != -1)
                    {
                        DestinationFile.WriteByte((byte)data);
                    }

                    DestinationFile.Close();
                    Source.Close();
                    SouceFile.Close();

                    Console.WriteLine("\n File Decrypted successfully !");

                }
                catch (Exception e)
                {
                    Console.WriteLine("\n Error" + e);
                }

            }
            else
            {
                Console.WriteLine("\n The source path : " + SourcePath + "doesn't exists.");
            }


        }

    }
}

