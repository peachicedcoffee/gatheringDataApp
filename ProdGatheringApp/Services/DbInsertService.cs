using ProdGatheringApp.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProdGatheringApp.Utils;

namespace ProdGatheringApp.Services
{
    /// <summary>
    /// Dapper -> db insert 에 사용합니다
    /// </summary>
    public class DbInsertService
    {
        private readonly string _targetConnectionString;
        
        public DbInsertService(string targetConnecitonString)
        {
            _targetConnectionString = targetConnecitonString;
        }

        /// <summary>
        /// Dapper로 ProdResultDto를 Bulk Insert 합니다
        /// </summary>
        /// <param name="results"></param>
        public async Task InsertProdResults(List<ProdResultDto> data) 
        {
            if (data == null || !data.Any()) return;

            using var conn = new SqlConnection(_targetConnectionString);
            await conn.OpenAsync();

            using var tran = conn.BeginTransaction();
            string sql = @" 
INSERT INTO TBL_TEST (ITEMCD, BARCODE, PRINTTIME)
VALUES (@ItemCode, @Barcode, @Id);
";

            await conn.ExecuteAsync(sql, data, tran);

            tran.Commit();
        }
    }
}
