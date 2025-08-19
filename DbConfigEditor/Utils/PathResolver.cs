using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConfigEditor.Utils
{
    public static class PathResolver
    {
        public static string GetConfigPath(string fileName)
        {
            string configDir = @"C:\ComMate\GatheringApp\DbConfig";
            Directory.CreateDirectory(configDir);

            return Path.Combine(configDir, fileName);
        }
    }
}
