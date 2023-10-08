using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Options;

namespace SsbuTools.Infrastructure.Repositories;

public class StageGameDatasetRepository
{
	private readonly MongoOptions _mongoConfig;

	private static IMongoCollection<StageGameDatasetEntity>? _stageGameDatasetCollection;

	public StageGameDatasetRepository(IOptions<MongoOptions> dbConfigOptions)
	{
		_mongoConfig = dbConfigOptions.Value;
		var settings = MongoClientSettings.FromConnectionString(_mongoConfig.Url);
		settings.ServerApi = new ServerApi(ServerApiVersion.V1);

		// Establish the connection to MongoDB
		var client = new MongoClient(settings);
		var database = client.GetDatabase(_mongoConfig.DatabaseName);

		_stageGameDatasetCollection = database.GetCollection<StageGameDatasetEntity>("stage_game_data");

		// This allows automapping of the camelCase database fields to our models. 
		var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
		ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
	}

	public async Task<List<StageGameDatasetEntity>> GetAllStageGameDatasetsAsync()
	{
		return await _stageGameDatasetCollection.Find(FilterDefinition<StageGameDatasetEntity>.Empty).ToListAsync();
	}

	public async Task<StageGameDatasetEntity> GetStageGameDatasetByIdAsync(string id)
	{
		return await _stageGameDatasetCollection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}
}
