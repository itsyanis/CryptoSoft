using System;

namespace CryptoSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            Encryption CryptoSoft = new Encryption();

            if(args.Length != 0)
            {
                switch (args[0])
                {
                    case "Crypt":
                        CryptoSoft.EncryptFile(args[1], args[2]);
                        break;

                    case "Decrypt":
                        CryptoSoft.EncryptFile(args[1], args[2]);
                        break;
                }
            }

        }
    }
}
