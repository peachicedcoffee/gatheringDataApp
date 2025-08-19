using CryptoLib;
using ProdGatheringApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProdGatheringApp.Utils
{
    public static class DbConfigLoader
    {
        public static DbConfig Load()
        {
            string configPath = PathResolver.GetConfigPath("dbConfig.json");
            string keyFilePath = PathResolver.GetConfigPath("cryptoKeys.xml");

            if (!File.Exists(configPath))
                throw new FileNotFoundException("DB 설정 파일(dbConfig.json)을 찾을 수 없습니다.", configPath);

            if (!File.Exists(keyFilePath))
                throw new FileNotFoundException("암호화 키 파일(cryptoKeys.xml)을 찾을 수 없습니다.", keyFilePath);

            // 문자열 복호화 (CryptoLib에서 키 로딩 포함)
            string json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<DbConfig>(json)
                         ?? throw new InvalidOperationException("DB 설정을 불러올 수 없습니다.");

            config.ConnectionStrings["Source"] = CryptoHelper.DecryptString(config.ConnectionStrings["Source"], keyFilePath);
            config.ConnectionStrings["Target"] = CryptoHelper.DecryptString(config.ConnectionStrings["Target"], keyFilePath);

            //디버그시 주석 해제해서 확인합니다.
            //Logger.Log("debug", $"복호화된 SourceConn: {config.ConnectionStrings["Source"]}");
            //Logger.Log("debug", $"복호화된 TargetConn: {config.ConnectionStrings["Target"]}");

            return config;
        }
    }
}
