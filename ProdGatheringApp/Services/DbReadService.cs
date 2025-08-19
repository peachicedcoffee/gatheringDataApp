using Dapper;
using Microsoft.Data.SqlClient;
using ProdGatheringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdGatheringApp.Services
{
    public class DbReadService
    {
        private readonly string _sourceConnectionString;

        public DbReadService(string sourceConnectionString)
        {
            _sourceConnectionString = sourceConnectionString;
        }

        public async Task<List<ProdResultDto>> GetProdResultsAsync(string lastId)
        {
            using var conn = new SqlConnection(_sourceConnectionString);
            
            string sql = @"
SELECT PRINT_TIME AS Id, ITEM_CODE AS ItemCode, BARCODE_DATA AS Barcode
                   FROM HKMC_KKL_4674
                   WHERE PRINT_TIME LIKE '2025%'
                    AND PRINT_TIME > @LastId
                   ORDER BY PRINT_TIME ASC
";
            var results = await conn.QueryAsync<ProdResultDto>(sql, new { LastId = lastId });
            return results.ToList();
        }

    }
}
