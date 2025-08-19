using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdGatheringApp.Utils
{
    /// <summary>
    /// 디렉토리 생성 여부를 확인합니다.
    /// </summary>
    public static class PathResolver
    {
        /// <summary>
        /// 베이스 디렉토리
        /// </summary>
        private static readonly string BaseDir = @"C:\ComMate\GatheringApp";

        public static string GetLogPath()
        {            
            string path = Path.Combine(BaseDir, "Logs", DateTime.Now.ToString("yyyy-MM-dd"));
            Directory.CreateDirectory(path);
            return path;
        }

        public static string GetLastIdPath()
        {
            string lastIdDir = Path.Combine(BaseDir, "Logs", "LastId");
            Directory.CreateDirectory(lastIdDir);
            return Path.Combine(lastIdDir, "ProdResults_LastId.txt");
        }

        public static string GetBackupPath()
        {
            string path = Path.Combine(BaseDir, "DataBackup", DateTime.Now.ToString("yyyy-MM-dd"));
            Directory.CreateDirectory(path);
            return path;
        }

        public static string GetConfigPath(string fileName)
        {
            string configDir = Path.Combine(BaseDir, "DbConfig");
            Directory.CreateDirectory(configDir);

            return Path.Combine(configDir, fileName);
        }

    }
}
