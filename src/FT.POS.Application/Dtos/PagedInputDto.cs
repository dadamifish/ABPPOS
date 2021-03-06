﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;

namespace FT.POS.Dtos
{
    public class PagedInputDto : IPagedResultRequest
    {
        /// <summary>
        /// 每页显示的行数
        /// </summary>
        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }
        /// <summary>
        /// 跳过数量=MaxResultCount*页数
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public PagedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}
