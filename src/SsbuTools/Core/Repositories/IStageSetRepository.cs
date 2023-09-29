using SsbuTools.Api.Entities;

namespace SsbuTools.Core.Repositories;

public interface IStageSetRepository {
	public Task<List<StageSetEntity>> GetAllSetsAsync();
	public Task<StageSetEntity> GetSetByIdAsync(string id);
}
