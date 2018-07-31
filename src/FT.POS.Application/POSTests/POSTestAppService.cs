using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using FT.POS.POSTests.Dto;
using FT.POS.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FT.POS.POSTests
{
    public class POSTestAppService : POSAppServiceBase
    {
        private readonly IRepository<POSTest> _repository;

        public async Task<PagedResultDto<POSTest>> GetListAsync(POSTestDto input)
        {
            var query = _repository.GetAll();
            var totalCount = await query.CountAsync();
            //var models = await query.OrderBy(input.Sorting).AsNoTracking().PageBy(input).ToListAsync();
            var models = await query.OrderBy(c=>c.Id).AsNoTracking().PageBy(input).ToListAsync();
            if (models.Count() == 0)
            {
                return new DataTablesPagedOutputDto<POSTest>(0, new List<POSTest>());
            }
            var items = models.MapTo<List<POSTest>>();
            return new DataTablesPagedOutputDto<POSTest>(totalCount, items);
        }
        public POSTestAppService(IRepository<POSTest> repository)
        {
            _repository = repository;
        }
        public async Task<List<POSTest>> GetList(POSTestDto input)
        {
            return await _repository.GetAllListAsync();
        }

        public async Task Update(POSTestDto input)
        {
            Debug.Assert(input.Id != null, "input.Language.Id != null");

            var postest = await _repository.GetAsync(input.Id.Value);
            postest.TenantId = AbpSession.TenantId;
            postest.Name = input.Name;
            postest.Sex = input.Sex;
            postest.Age = input.Age;
            postest.Hight = input.Hight;

            await _repository.UpdateAsync(postest);
        }

        public async Task Create(POSTestDto input)
        {
            var inputInfo = input.MapTo<POSTest>();
            inputInfo.TenantId = AbpSession.TenantId;
            await _repository.InsertAsync(inputInfo);
        }

        public async Task Delete(EntityDto<int> input)
        {
            var postest = await _repository.GetAsync(input.Id);
            postest.TenantId = AbpSession.TenantId;
            await _repository.DeleteAsync(postest);
        }

    }
}
