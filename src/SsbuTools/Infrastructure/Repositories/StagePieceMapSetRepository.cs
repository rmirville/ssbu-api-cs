using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StagePieceMapSetRepository : BaseStageRepository<StagePieceMapSetEntity>
{
	public StagePieceMapSetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions)
	{
		Collection = Database.GetCollection<StagePieceMapSetEntity>("stage_piece_maps");
	}

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
