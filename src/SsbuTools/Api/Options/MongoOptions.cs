namespace SsbuTools.Api.Options;

public sealed class MongoOptions
{
	public const string ConfigName = "SsbuTools:Db:Mongo";
	public string Url { get; set; }
	public string DatabaseName { get; set; }
}
