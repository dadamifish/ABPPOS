using System.Threading.Tasks;
using Abp.Application.Services;
using FT.POS.Authorization.Accounts.Dto;

namespace FT.POS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
