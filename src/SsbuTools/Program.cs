using SsbuTools.Api.Config;
using SsbuTools.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var section = builder.Configuration.GetSection(nameof(ApiConfig));
var apiConfig = section.Get<ApiConfig>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IIndexService, IndexService>();
builder.Services.AddSingleton(apiConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
