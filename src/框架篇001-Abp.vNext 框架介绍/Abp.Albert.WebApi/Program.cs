using Abp.Albert.WebApi;
using Autofac.Extensions.DependencyInjection;
using Volo.Abp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication<AlbertModule>(opt =>
{
    // 替换默认配置
    opt.Services.ReplaceConfiguration(builder.Configuration);
    // 使用 Autofac
    opt.UseAutofac();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
// 中间件初始化使用
app.InitializeApplication();
app.Run();