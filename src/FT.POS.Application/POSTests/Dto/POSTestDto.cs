using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FT.POS.Dtos;

namespace FT.POS.POSTests.Dto
{
    [AutoMapTo(typeof(POSTest))]
    public class POSTestDto :  PagedSortedAndFilteredInputDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public string Age { get; set; }

        public string Hight { get; set; }
    }
}
