using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;


namespace RSA
{
    internal class RSAEncryption
    {
        private string _plainText, _cipherText;
        private int e, d, n;

        public RSAEncryption(string plainText, int e, int d, int n)
        {
            _plainText = plainText;
            this.e = e;
            this.d = d;
            this.n = n;
        }

        public string GetPlainText() { return _plainText; }
        public string GetCipherText() { return _cipherText; }
        public void SetCipherText(string cipher) { _cipherText = cipher; }

        public void SetEDN (int e, int d, int n)
        {
            this.e = e;
            this.d = d;
            this.n = n;
        }

        public void Encrypt()
        {
            int eValue = e;
            int dValue = d;
            int nValue = n;

            string plainText = _plainText;
            BigInteger[] encryptedMessage = new BigInteger[plainText.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                BigInteger character = (int)plainText[i];
                encryptedMessage[i] = BigInteger.ModPow(character, eValue, nValue);
            }

            string encryptedMessageString = string.Join(",", encryptedMessage);
            _cipherText = encryptedMessageString;
        }

        public void Decrypt()
        {
            int dValue = d;
            int nValue = n;

            string[] encryptedMessageString = _cipherText.Split(',');
            BigInteger[] encryptedMessage = new BigInteger[encryptedMessageString.Length];

            for (int i = 0; i < encryptedMessageString.Length; i++)
            {
                encryptedMessage[i] = BigInteger.Parse(encryptedMessageString[i]);
            }

            char[] decryptedMessage = new char[encryptedMessage.Length];

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                BigInteger character = BigInteger.ModPow(encryptedMessage[i], dValue, nValue);
                decryptedMessage[i] = (char)character;
            }

            string plainText = new string(decryptedMessage);
            _plainText = plainText;
        }
    }
}

