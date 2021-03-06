﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.POS.Localization.Dto
{
    public class ApplicationLanguageListDto : FullAuditedEntityDto
    {
        public virtual int? TenantId { get; set; }

        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Icon { get; set; }

        public bool IsDisabled { get; set; }
    }
}
