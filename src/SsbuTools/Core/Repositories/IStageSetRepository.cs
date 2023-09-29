using SsbuTools.Api.Entities;

namespace SsbuTools.Core.Repositories;

public interface IStageSetRepository {
	public Task<List<StageSetEntity>> GetAllStageSetsAsync();
	public Task<StageSetEntity> GetStageSetByIdAsync(string id);
}
