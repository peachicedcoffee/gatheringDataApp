using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace CryptoLib
{
    public static class CryptoKeyGenerator
    {
        public static void GenerateKeyFile(string filePath)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.GenerateKey();
                    aes.GenerateIV();

                    var xmlDoc = new XDocument(
                        new XElement("CryptoKeys",
                            new XElement("Key", Convert.ToBase64String(aes.Key)),
                            new XElement("IV", Convert.ToBase64String(aes.IV)),
                            new XElement("CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        )
                    );

                    // 경로 보장 후 저장
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    xmlDoc.Save(filePath);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("키 생성 중 오류 발생", ex);
            }
        }
    }
}
