using Volo.Abp.DependencyInjection;

namespace NET_FiveMinutes_010_AbpModuleDev.Services
{
    [Dependency(ServiceLifetime.Transient)]
    public class ReadAppSettingsService
    {
        public string ReadAppSetttingsJson()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory+"appsettings.json";
            return File.ReadAllText(path);
        }
    }
}
