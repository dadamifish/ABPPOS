using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FT.POS.Roles.Dto;
using FT.POS.Users.Dto;

namespace FT.POS.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
