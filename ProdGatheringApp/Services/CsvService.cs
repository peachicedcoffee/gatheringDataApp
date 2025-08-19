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
    /// 일자별 백업폴더 생성 후 csv로 저장.
    /// 파일명에 시/분/초 추가해서 중복 방지
    /// 백업 성공 시 로그 기록
    /// </summary>
    public class CsvService
    {
        public string SaveToCsv(List<ProdResultDto> data)
        {
            if (data == null || !data.Any()) return null;

            string dirPath = PathResolver.GetBackupPath();

            string fileName = $"ProdResults_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            string filePath = Path.Combine(dirPath, fileName);

            using var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);

            //헤더
            writer.WriteLine("Id, ItemCode, Barcode");

            // 데이터
            foreach (var row in data)
            {
                writer.WriteLine($"{row.Id},{row.ItemCode},{row.Barcode}");
            }

            Logger.Log("INFO", $"CSV 백업 완료: {filePath}");
            return filePath;
        }
    }
}
