using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdGatheringApp.Models
{
    public class ProdResultDto
    {
        /// <summary>
        /// 기준이 되는 컬럼.
        /// 일시 또는 텍스트값이 될 수도 있고, 숫자값이 될 수도 있음
        /// </summary>
        public string Id { get; set; } 

        /// <summary>
        /// 품번
        /// </summary>
        public string ItemCode { get; set; }  

        /// <summary>
        /// 바코드 데이터
        /// </summary>
        public string Barcode { get; set; }
        
    }
}
