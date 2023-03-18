using Microsoft.AspNetCore.Http.Features;
using NET_FiveMinutes_010_AbpModuleDev;
using Volo.Abp;

var builder = WebApplication.CreateBuilder(args);

////配置请求体大小
//builder.WebHost.ConfigureKestrel((context, options) =>
//{
//    options.Limits.MaxRequestBodySize = int.MaxValue;
//});
//builder.Services.Configure<FormOptions>(options =>
//{
//    options.MultipartBodyLengthLimit = int.MaxValue;
//});

// 修正配置错误,必须添加，否则会提示找不到主机服务的错误
builder.Services.ReplaceConfiguration(builder.Configuration);

builder.Services.AddApplication<AppModule>(options=>options.UseAutofac());

var app = builder.Build();
app.InitializeApplication();
app.Run();

