using SsbuTools.Api.Options;
using SsbuTools.Api.Services;
using SsbuTools.Core.Repositories;
using SsbuTools.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DbOptions>(builder.Configuration.GetSection(DbOptions.ConfigName));
builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection(ApiOptions.ConfigName));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IIndexService, IndexService>();
builder.Services.AddSingleton<IStageClassificationsRepository, StageClassificationsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
else
{
	app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
