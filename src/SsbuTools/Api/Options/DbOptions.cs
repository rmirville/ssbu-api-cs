using MongoDB.Driver;

namespace SsbuTools.Api.Options;

public class DbOptions
{
	public const string ConfigName = "Db";
	public string Url { get; set; } = String.Empty;
	public string DatabaseName { get; set; } = String.Empty;

	public DbOptions()
	{
	}
}
