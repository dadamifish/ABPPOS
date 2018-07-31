using System.Threading.Tasks;
using FT.POS.Configuration.Dto;

namespace FT.POS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
