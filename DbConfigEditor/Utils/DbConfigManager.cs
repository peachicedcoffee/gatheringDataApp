using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using CryptoLib;

namespace DbConfigEditor
{
    public class DbConfigManager
    {
        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "DbConfig", "dbConfig.json");

        public static void SaveConfig(string sourceConnStr, string targetConnStr, string keyFilePath)
        {
            string encryptedSource = Encrypt(sourceConnStr, keyFilePath);
            string encryptedTarget = Encrypt(targetConnStr, keyFilePath);

            var config = new
            {
                SourceDB = new { EncryptedConnectionString = encryptedSource },
                TargetDB = new { EncryptedConnectionString = encryptedTarget }
            };

            Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigPath, json);
        }

        private static string Encrypt(string plainText, string keyFilePath)
        {
            var keyDoc = XDocument.Load(keyFilePath);
            byte[] key = Convert.FromBase64String(keyDoc.Root.Element("Key").Value);
            byte[] iv = Convert.FromBase64String(keyDoc.Root.Element("IV").Value);

            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var encryptor = aes.CreateEncryptor();
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return Convert.ToBase64String(encryptedBytes);
        }

    }
}
