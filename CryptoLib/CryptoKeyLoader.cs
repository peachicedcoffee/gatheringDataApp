using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CryptoLib
{
    public static class CryptoKeyLoader
    {
        public static byte[] GetKey(string cryptoKeyPath)
        {
            var doc = XDocument.Load(cryptoKeyPath);
            var base64 = doc.Element("EncryptionKeys")?.Element("AES")?.Element("Key")?.Value
                ?? throw new Exception("Key 값이 없습니다.");
            return Convert.FromBase64String(base64);
        }

        public static byte[] GetIV(string cryptoKeyPath)
        {
            var doc = XDocument.Load(cryptoKeyPath);
            var base64 = doc.Element("EncryptionKeys")?.Element("AES")?.Element("IV")?.Value
                ?? throw new Exception("IV 값이 없습니다.");
            return Convert.FromBase64String(base64);
        }
    }
}
