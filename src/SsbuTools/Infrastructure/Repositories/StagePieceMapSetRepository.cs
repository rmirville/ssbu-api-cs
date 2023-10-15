using Microsoft.Extensions.Options;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StagePieceMapSetRepository : BaseStageRepository<StagePieceMapSetEntity>
{
	protected override string CollectionName { get => "stage_piece_maps"; }
	public StagePieceMapSetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions) { }
}
