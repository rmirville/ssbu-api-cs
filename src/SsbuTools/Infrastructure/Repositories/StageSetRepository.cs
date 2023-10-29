using Microsoft.Extensions.Options;
using SsbuTools.Api.Options;
using SsbuTools.Api.Entities;

namespace SsbuTools.Infrastructure.Repositories;

public class StageSetRepository : BaseStageRepository<StageSetEntity>
{
	protected override string CollectionName { get => "stage_sets"; }
	public StageSetRepository(IOptions<MongoOptions> dbConfigOptions) : base(dbConfigOptions) { }
}
