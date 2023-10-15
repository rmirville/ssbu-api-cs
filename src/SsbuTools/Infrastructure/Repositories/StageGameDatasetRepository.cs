using Microsoft.Extensions.Options;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Options;

namespace SsbuTools.Infrastructure.Repositories;

public class StageGameDatasetRepository : BaseStageRepository<StageGameDatasetEntity>
{
	protected override string CollectionName { get => "stage_game_data"; }
	public StageGameDatasetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions) { }
}
