using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StageClassificationsRepository : BaseStageRepository<StageClassificationsEntity>
{
	public StageClassificationsRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions)
	{
		Collection = Database.GetCollection<StageClassificationsEntity>("stage_classifications");
	}

	public async Task<List<StageClassificationsEntity>> GetAllStagesAsync()
	{
		return await Collection.Find(FilterDefinition<StageClassificationsEntity>.Empty)
		.ToListAsync();
	}

	public async Task<StageClassificationsEntity> GetStageByIdAsync(string id)
	{
		return await Collection.Find(stage => stage.Id == id).FirstOrDefaultAsync();
	}

	public async Task<List<StageClassificationsEntity>> GetStagesByIdsAsync(string[] ids)
	{
		return await Collection.Find(stage => ids.Contains(stage.Id)).ToListAsync();
	}
}
