using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StagePieceMapSetRepository : BaseStageRepository<StagePieceMapSetEntity>
{
	protected override string CollectionName { get => "stage_piece_maps"; }
	public StagePieceMapSetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions) { }

	public async Task<List<StagePieceMapSetEntity>> GetAllStagePieceMapSetsAsync()
	{
		return await Collection.Find(FilterDefinition<StagePieceMapSetEntity>.Empty)
		.ToListAsync();
	}

	public async Task<StagePieceMapSetEntity> GetStagePieceMapSetByIdAsync(string id)
	{
		return await Collection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}
}
