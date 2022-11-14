using Abp.Albert.Console;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

using (var app = AbpApplicationFactory.Create<AlbertModule>(opt => { opt.UseAutofac(); }))
{
    app.Initialize();

    // 通过 getservice 方式获取
    app.Services.GetRequiredService<AlbertService>().SayHello();

    // 通过托管服务方式启动
    Host.CreateDefaultBuilder(args).UseAutofac().ConfigureServices((hostContext, services) =>
    {
        services.AddApplication<AlbertModule>();
    }).RunConsoleAsync().Wait();
}
