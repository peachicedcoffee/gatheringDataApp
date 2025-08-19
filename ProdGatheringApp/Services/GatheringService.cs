using ProdGatheringApp.Models;
using ProdGatheringApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdGatheringApp.Services
{
    /// <summary>
    /// 전체 워크플로우를 관리합니다
    /// </summary>
    public class GatheringService
    {
        private readonly DbInsertService _dbInsertService;
        private readonly DbReadService _dbReadService;
        private readonly CsvService _csvService;

        public GatheringService(string sourceConn, string targetConn)
        {
            _dbReadService = new DbReadService(sourceConn);
            _dbInsertService = new DbInsertService(targetConn);
            _csvService = new CsvService(); 
        }

        public async Task RunAsync()
        {
            try
            {
                Logger.Log("info", "데이터 수집 시작");

                //1. 마지막 id 로드
                string lastId = LastIdTracker.LoadLastId();

                //2. 신규 데이터 조회
                var data = await _dbReadService.GetProdResultsAsync(lastId);

                if (data.Any())
                {
                    //3. csv 백업 저장
                    string csvPath = _csvService.SaveToCsv(data);

                    //4. db insert
                    await _dbInsertService.InsertProdResults(data);

                    //5. last id 갱신
                    string newLastId = data[^1].Id;
                    LastIdTracker.SaveLastId(newLastId);

                    //6. 로그 기록
                    Logger.Log("info", $"수집 완료:{data.Count}건 / CSV:{csvPath} / 마지막 ID : {newLastId}");
                }
                else
                {
                    Logger.Log("info", "신규 데이터 없음");
                }
            }
            catch (Exception ex)
            {
                Logger.Log("error", $"오류 발생:{ex.Message}");
            }
        }

    }
}
