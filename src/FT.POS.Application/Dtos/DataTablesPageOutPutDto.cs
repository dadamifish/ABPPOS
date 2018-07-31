using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace FT.POS.Dtos
{
   [Serializable]
     public class DataTablesPagedOutputDto<T> : PagedResultDto<T>
     {
        public int Draw { get; set; }
 
         /// <summary>
         /// 过滤后的记录数（没有就是全部），这个是必须的参数
         /// </summary>
         public int RecordsFiltered { get; set; }
 
         public int RecordsTotal { get { return this.TotalCount; } }
       
         public DataTablesPagedOutputDto(int totalCount, IReadOnlyList<T> items)
          : base(totalCount, items)
         {
             this.RecordsFiltered = totalCount;
         }
     }
}
