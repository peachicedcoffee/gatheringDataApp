using ProdGatheringApp.Forms;
using ProdGatheringApp.Models;
using ProdGatheringApp.Services;
using ProdGatheringApp.Utils;
using System.Text.Json;

namespace ProdGatheringApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new GatheringMainForm());
        }

        /*
        private static Mutex? _mutex;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== 생산실적 개더링 프로그램 시작 ===");

            // 중복 실행 방지
            bool createdNew;
            _mutex = new Mutex(true, "ProdGatheringApp_Mutex", out createdNew);
            if (!createdNew)
            {
                Console.WriteLine("이미 프로그램이 실행 중입니다.");
                Logger.Log("warn", "중복 실행 방지로 인해 프로그램이 종료됩니다.");
                return;
            }

            // DB 설정 로드
            var dbConfig = DbConfigLoader.Load();
            if (!dbConfig.ConnectionStrings.ContainsKey("Source") ||
                !dbConfig.ConnectionStrings.ContainsKey("Target"))
            {
                Logger.Log("error", "DB 설정에 Source 또는 Target 연결 정보가 없습니다.");
                return;
            }

            Logger.Log("info", "DB 설정 로드 완료");

            string sourceConn = dbConfig.ConnectionStrings["Source"];
            string targetConn = dbConfig.ConnectionStrings["Target"];

            var gatheringService = new GatheringService(sourceConn, targetConn);

            while (true)
            {
                try
                {
                    await gatheringService.RunAsync();
                }
                catch (Exception ex)
                {
                    Logger.Log("error", $"데이터 수집 중 오류 발생: {ex.Message}");
                }

                await Task.Delay(TimeSpan.FromMinutes(1)); // 1분마다 실행
            }
        }
        */
    }
}