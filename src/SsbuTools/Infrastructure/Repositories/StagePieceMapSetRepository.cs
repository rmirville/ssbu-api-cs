using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StagePieceMapSetRepository : BaseStageRepository<StagePieceMapSetEntity>
{
	public StagePieceMapSetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions)
	{
		_collection = _database.GetCollection<StagePieceMapSetEntity>("stage_piece_maps");
	}

	public async Task<List<StagePieceMapSetEntity>> GetAllStagePieceMapSetsAsync()
	{
		return await _collection.Find(FilterDefinition<StagePieceMapSetEntity>.Empty)
		.ToListAsync();
	}

	public async Task<StagePieceMapSetEntity> GetStagePieceMapSetByIdAsync(string id)
	{
		return await _collection.Find(set => set.Id == id).FirstOrDefaultAsync();
	}
}
