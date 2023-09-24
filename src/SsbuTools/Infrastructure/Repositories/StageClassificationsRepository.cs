using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;
using SsbuTools.Core.Repositories;

namespace SsbuTools.Infrastructure.Repositories;

public class StageClassificationsRepository : IStageClassificationsRepository {

	private readonly MongoOptions _mongoConfig;

	private static IMongoCollection<StageClassifications>? _stageClassificationsCollection;

	public StageClassificationsRepository(IOptions<MongoOptions> dbConfigOptions)
	{
		_mongoConfig = dbConfigOptions.Value;
		var settings = MongoClientSettings.FromConnectionString(_mongoConfig.Url);
		settings.ServerApi = new ServerApi(ServerApiVersion.V1);

		// Establish the connection to MongoDB
		var client = new MongoClient(settings);
		var database = client.GetDatabase(_mongoConfig.DatabaseName);

		_stageClassificationsCollection = database.GetCollection<StageClassifications>("stage_classifications");

		// This allows automapping of the camelCase database fields to our models. 
		var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
		ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
	}

	public async Task<List<StageClassifications>> GetAllStagesAsync()
	{
		return await _stageClassificationsCollection.Find(FilterDefinition<StageClassifications>.Empty)
		.ToListAsync();
	}

	public async Task<StageClassifications> GetStageByIdAsync(string id)
	{
		FindOptions options = new();
		return await _stageClassificationsCollection.Find(stage => stage.Id == id).FirstOrDefaultAsync();
	}

}