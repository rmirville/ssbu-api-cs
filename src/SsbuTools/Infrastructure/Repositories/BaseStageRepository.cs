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

	public Task<List<TEntity>> GetAllAsync()
	{
		return Collection.Find(FilterDefinition<TEntity>.Empty).ToListAsync();
	}

	public Task<TEntity> GetByIdAsync(string id)
	{
		return Collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
	}

	public Task<List<TEntity>> GetManyByIdsAsync(List<string> ids)
	{
		return Collection.Find(entity => ids.Contains(entity.Id)).ToListAsync();
	}
}
