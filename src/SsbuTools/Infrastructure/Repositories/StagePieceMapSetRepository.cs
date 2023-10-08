using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StagePieceMapSetRepository
{
	private readonly MongoOptions _mongoConfig;

	private static IMongoCollection<StagePieceMapSetEntity>? _stagePieceMapSetCollection;

	public StagePieceMapSetRepository(IOptions<MongoOptions> dbConfigOptions)
	{
		_mongoConfig = dbConfigOptions.Value;
		var settings = MongoClientSettings.FromConnectionString(_mongoConfig.Url);
		settings.ServerApi = new ServerApi(ServerApiVersion.V1);

		// Establish the connection to MongoDB
		var client = new MongoClient(settings);
		var database = client.GetDatabase(_mongoConfig.DatabaseName);

		_stagePieceMapSetCollection = database.GetCollection<StagePieceMapSetEntity>("stage_piece_maps");

		// This allows automapping of the camelCase database fields to our models. 
		var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
		ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
	}

	public async Task<List<StagePieceMapSetEntity>> GetAllStagePieceMapSetsAsync()
	{
		return await _stagePieceMapSetCollection.Find(FilterDefinition<StagePieceMapSetEntity>.Empty)
		.ToListAsync();
	}

	public async Task<StagePieceMapSetEntity> GetStagePieceMapSetByIdAsync(string id)
	{
		return await _stagePieceMapSetCollection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}

}
