using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Options;

namespace SsbuTools.Infrastructure.Repositories;

public abstract class BaseStageRepository<TEntity> where TEntity : MongoEntity
{
	protected MongoOptions MongoConfig { get; init; }
	protected IMongoDatabase Database { get; init; }

	protected abstract string CollectionName { get; }

	protected IMongoCollection<TEntity>? Collection { get; init; }

	public BaseStageRepository(IOptions<MongoOptions> dbConfigOptions)
	{
		MongoConfig = dbConfigOptions.Value;
		var settings = MongoClientSettings.FromConnectionString(MongoConfig.Url);
		settings.ServerApi = new ServerApi(ServerApiVersion.V1);

		// Establish the connection to MongoDB
		var client = new MongoClient(settings);
		Database = client.GetDatabase(MongoConfig.DatabaseName);

		// This allows automapping of the camelCase database fields to our models. 
		var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
		ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
		Collection = Database.GetCollection<TEntity>(CollectionName);
	}

	public async Task<List<TEntity>> GetAllAsync()
	{
		return await Collection.Find(FilterDefinition<TEntity>.Empty).ToListAsync();
	}

	public async Task<TEntity> GetAsync(string id)
	{
		return await Collection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}
}
