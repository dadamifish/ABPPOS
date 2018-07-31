﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;

namespace FT.POS.Dtos
{
    public class PagedAndFilteredInputDto : IPagedResultRequest
     {
         [Range(1, AppConsts.MaxPageSize)]
         public int MaxResultCount { get; set; }
 
         [Range(0, int.MaxValue)]
         public int SkipCount { get; set; }
 
         public string Filter { get; set; }
 
        public PagedAndFilteredInputDto()
         {
             MaxResultCount = AppConsts.DefaultPageSize;
         }
     }
}
