using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FT.POS.MultiTenancy.Dto;

namespace FT.POS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
