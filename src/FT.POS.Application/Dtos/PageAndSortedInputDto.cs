using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace FT.POS.Dtos
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }

       public PagedAndSortedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}
