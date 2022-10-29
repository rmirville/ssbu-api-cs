using MongoDB.Driver;

namespace SsbuTools.Api.Config;

public class MongoDbConfig {

	public MongoDbConfig() {
		string? url = Environment.GetEnvironmentVariable("SSBUTOOLS_DB_MONGO_R_URL");
		string? databaseName = Environment.GetEnvironmentVariable("SSBUTOOLS_DB_MONGO_R_DB");
		var settings = MongoClientSettings.FromConnectionString(url);
		settings.ServerApi = new ServerApi(ServerApiVersion.V1);
		var client = new MongoClient(settings);
		IMongoDatabase database = client.GetDatabase(databaseName);
	}
}
