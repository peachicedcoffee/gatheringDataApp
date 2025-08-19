using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdGatheringApp.Utils
{
    /// <summary>
    /// 마지막으로 저장한 db row id를 추적합니다
    /// </summary>
    public static class LastIdTracker
    {
        private static readonly object _lock = new();

        public static void SaveLastId(string lastId)
        {
            lock (_lock)
            {
                File.WriteAllText(PathResolver.GetLastIdPath(), lastId);
                Logger.Log("info", $"[LastIdTracker] Last ID 저장됨: {lastId}");
            }
        }

        public static string LoadLastId()
        {
            lock (_lock)
            {
                string path = PathResolver.GetLastIdPath();
                if (!File.Exists(path))
                    return string.Empty;

                string lastId = File.ReadAllText(path);
                Logger.Log("info", $"[LastIdTracker] Last ID 로드됨: {lastId}");
                return lastId;
            }
        }

    }
}
