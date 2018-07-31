using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FT.POS.POSTests.Dto;

namespace FT.POS.POSTests
{
    public interface IPOSTestAppService : IApplicationService
    {
        Task<List<POSTest>> GetListAsync(POSTestDto input);

        Task Create(POSTestDto input);
        Task Update(POSTestDto input);
        Task Delete(EntityDto<int> input);
    }
}
