using SsbuTools.Api.Models;
using SsbuTools.Api.Options;
using SsbuTools.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.Configure<SsbuToolsOptions>(builder.Configuration.GetSection(SsbuToolsOptions.ConfigName));
builder.Services.Configure<MongoOptions>(builder.Configuration.GetSection(MongoOptions.ConfigName));
builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection(ApiOptions.ConfigName));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<StageModel>();
builder.Services.AddSingleton<StageClassificationsRepository>();
builder.Services.AddSingleton<StageSetRepository>();
builder.Services.AddSingleton<StagePieceMapSetRepository>();
builder.Services.AddSingleton<StageGameDatasetRepository>();

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
