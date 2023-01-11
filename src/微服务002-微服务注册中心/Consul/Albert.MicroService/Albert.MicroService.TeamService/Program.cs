using Albert.MicroService.Core.Consul.Registry.Extentions;
using Albert.MicroService.TeamService.Context;
using Albert.MicroService.TeamService.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region 注册服务
// 1. 注册数据库服务
builder.Services.AddDbContext<TeamContext>(option =>
{
    var strDbConnect = builder.Configuration.GetConnectionString("DefaultConnection");
    option.UseMySql(strDbConnect, new MySqlServerVersion(new Version(8, 0, 13)));
});

// 2. 注册 TeamService 服务
builder.Services.AddTeamService();

// 3. 注册 TeamRepository 服务
builder.Services.AddTeamRepository();

// 4. 添加 Consul 注册服务
builder.Services.AddConsulRegistry(builder.Configuration);
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region 使用中间件
//  1. 使用 Consul 注册服务
app.UseConsulRegistry(builder.Configuration);
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();