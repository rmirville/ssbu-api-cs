using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;
using SsbuTools.Core.Repositories;

namespace SsbuTools.Infrastructure.Repositories;

public class StageSetRepository : IStageSetRepository {

	private readonly MongoOptions _mongoConfig;

	private static IMongoCollection<StageSetEntity>? _stageSetCollection;

	public StageSetRepository(IOptions<MongoOptions> dbConfigOptions)
	{
		_mongoConfig = dbConfigOptions.Value;
		var settings = MongoClientSettings.FromConnectionString(_mongoConfig.Url);
		settings.ServerApi = new ServerApi(ServerApiVersion.V1);

		// Establish the connection to MongoDB
		var client = new MongoClient(settings);
		var database = client.GetDatabase(_mongoConfig.DatabaseName);

		_stageSetCollection = database.GetCollection<StageSetEntity>("stage_sets");

		// This allows automapping of the camelCase database fields to our models. 
		var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
		ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
	}

	public async Task<List<StageSetEntity>> GetAllStageSetsAsync()
	{
		return await _stageSetCollection.Find(FilterDefinition<StageSetEntity>.Empty)
		.ToListAsync();
	}

	public async Task<StageSetEntity> GetStageSetByIdAsync(string id)
	{
		return await _stageSetCollection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}

}
