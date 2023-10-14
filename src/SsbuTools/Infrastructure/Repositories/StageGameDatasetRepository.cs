using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Options;

namespace SsbuTools.Infrastructure.Repositories;

public class StageGameDatasetRepository : BaseStageRepository<StageGameDatasetEntity>
{
	public StageGameDatasetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions)
	{
		_collection = _database.GetCollection<StageGameDatasetEntity>("stage_game_data");
	}

	public async Task<List<StageGameDatasetEntity>> GetAllStageGameDatasetsAsync()
	{
		return await _collection.Find(FilterDefinition<StageGameDatasetEntity>.Empty).ToListAsync();
	}

	public async Task<StageGameDatasetEntity> GetStageGameDatasetByIdAsync(string id)
	{
		return await _collection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}
}
