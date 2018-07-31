using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FT.POS.Authorization;

namespace FT.POS
{
    [DependsOn(
        typeof(POSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class POSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<POSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(POSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
