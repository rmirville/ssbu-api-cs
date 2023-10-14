using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Options;

namespace SsbuTools.Infrastructure.Repositories;

public abstract class SsbuToolsRepository<T>
{
	protected readonly MongoOptions _mongoConfig;
	protected readonly IMongoDatabase _database;

	protected IMongoCollection<T>? _collection;

	public SsbuToolsRepository(IOptions<MongoOptions> dbConfigOptions)
	{
		_mongoConfig = dbConfigOptions.Value;
		var settings = MongoClientSettings.FromConnectionString(_mongoConfig.Url);
		settings.ServerApi = new ServerApi(ServerApiVersion.V1);

		// Establish the connection to MongoDB
		var client = new MongoClient(settings);
		_database = client.GetDatabase(_mongoConfig.DatabaseName);

		// This allows automapping of the camelCase database fields to our models. 
		var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
		ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
	}
}
