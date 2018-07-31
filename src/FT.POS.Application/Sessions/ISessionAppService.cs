using System.Threading.Tasks;
using Abp.Application.Services;
using FT.POS.Sessions.Dto;

namespace FT.POS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
