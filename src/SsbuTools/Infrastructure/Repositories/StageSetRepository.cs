using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StageSetRepository : BaseStageRepository<StageSetEntity>
{
	public StageSetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions)
	{
		_collection = _database.GetCollection<StageSetEntity>("stage_sets");
	}

	public async Task<List<StageSetEntity>> GetAllStageSetsAsync()
	{
		return await _collection.Find(FilterDefinition<StageSetEntity>.Empty)
		.ToListAsync();
	}

	public async Task<StageSetEntity> GetStageSetByIdAsync(string id)
	{
		return await _collection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}
}
