using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StageSetRepository : BaseStageRepository<StageSetEntity>
{
	protected override string CollectionName { get => "stage_sets"; }
	public StageSetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions) { }

	public async Task<List<StageSetEntity>> GetAllStageSetsAsync()
	{
		return await Collection.Find(FilterDefinition<StageSetEntity>.Empty)
		.ToListAsync();
	}

	public async Task<StageSetEntity> GetStageSetByIdAsync(string id)
	{
		return await Collection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}
}
