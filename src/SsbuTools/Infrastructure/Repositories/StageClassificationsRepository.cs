using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StageClassificationsRepository : SsbuToolsRepository<StageClassificationsEntity>
{
	public StageClassificationsRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions)
	{
		_collection = _database.GetCollection<StageClassificationsEntity>("stage_classifications");
	}

	public async Task<List<StageClassificationsEntity>> GetAllStagesAsync()
	{
		return await _collection.Find(FilterDefinition<StageClassificationsEntity>.Empty)
		.ToListAsync();
	}

	public async Task<StageClassificationsEntity> GetStageByIdAsync(string id)
	{
		return await _collection.Find(stage => stage.Id == id).FirstOrDefaultAsync();
	}

	public async Task<List<StageClassificationsEntity>> GetStagesByIdsAsync(string[] ids)
	{
		return await _collection.Find(stage => ids.Contains(stage.Id)).ToListAsync();
	}
}
