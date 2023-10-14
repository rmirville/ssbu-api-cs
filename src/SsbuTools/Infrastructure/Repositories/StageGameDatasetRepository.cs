using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Options;

namespace SsbuTools.Infrastructure.Repositories;

public class StageGameDatasetRepository : BaseStageRepository<StageGameDatasetEntity>
{
	protected override string CollectionName { get => "stage_game_data"; }
	public StageGameDatasetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions) { }

	public async Task<List<StageGameDatasetEntity>> GetAllStageGameDatasetsAsync()
	{
		return await Collection.Find(FilterDefinition<StageGameDatasetEntity>.Empty).ToListAsync();
	}

	public async Task<StageGameDatasetEntity> GetStageGameDatasetByIdAsync(string id)
	{
		return await Collection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}
}
