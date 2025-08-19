using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace CryptoLib
{
    public static class CryptoHelper
    {
        public static void EncryptFile(string inputPath, string outputPath, byte[] key, byte[] iv)
        {
            var plainText = File.ReadAllText(inputPath);
            var encrypted = AesEncryption.Encrypt(plainText, key, iv);
            File.WriteAllText(outputPath, encrypted);
        }

        public static void DecryptFile(string inputPath, string outputPath, byte[] key, byte[] iv)
        {
            var cipherText = File.ReadAllText(inputPath);
            var decrypted = AesEncryption.Decrypt(cipherText, key, iv);
            File.WriteAllText(outputPath, decrypted);
        }

        public static string EncryptString(string plainText, string keyFilePath)
        {
            (byte[] key, byte[] iv) = LoadKey(keyFilePath);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string DecryptString(string encryptedText, string keyFilePath)
        {
            // 1) Base64 문자열인지 먼저 확인
            if (!IsBase64String(encryptedText))
                return encryptedText; // 암호화 안 된 평문이면 그대로 반환

            (byte[] key, byte[] iv) = LoadKey(keyFilePath);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                try
                {
                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }

                catch (CryptographicException ex)
                {
                    throw new InvalidOperationException("복호화 실패: 키 파일이 일치하지 않거나 암호화된 문자열이 잘못되었습니다.", ex);
                }
            }
        }

        private static (byte[] key, byte[] iv) LoadKey(string keyFilePath)
        {
            if (!File.Exists(keyFilePath))
                throw new FileNotFoundException("암호화 키 파일을 찾을 수 없습니다.", keyFilePath);

            var doc = XDocument.Load(keyFilePath);
            var key = Convert.FromBase64String(doc.Root.Element("Key").Value);
            var iv = Convert.FromBase64String(doc.Root.Element("IV").Value);

            return (key, iv);
        }

        private static bool IsBase64String(string input)
        {
            // Base64 판별: 길이가 4의 배수이고, 잘 디코딩되면 암호문으로 간주
            if (string.IsNullOrWhiteSpace(input) || input.Length % 4 != 0)
                return false;

            try
            {
                Convert.FromBase64String(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
