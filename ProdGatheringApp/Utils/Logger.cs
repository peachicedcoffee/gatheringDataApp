using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdGatheringApp.Utils
{
    /// <summary>
    /// 로그를 남길 때 사용합니다
    /// </summary>
    public static class Logger
    {
        private static readonly object _lock = new();

        public static event Action<string>? LogAppended;

        public static void Log(string type, string message)
        {
            lock (_lock)
            {
                try
                {                    
                    string logDirPath = PathResolver.GetLogPath();
                    string logFilePath = Path.Combine(logDirPath, "app.log");

                    string time = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                    string logMessage = $"[{time}] [{type.ToUpper()}] | {message}";

                    File.AppendAllText(logFilePath, $"{logMessage}{Environment.NewLine}");

                    // 이벤트 발생 → UI로 전달
                    LogAppended?.Invoke(logMessage);
                }
                catch 
                {
                    //로그 기록 중 예외는 무시 (로그 기록 실패로 프로그램 중단 방지)
                }
            }
        }

    }
}
