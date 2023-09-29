using SsbuTools.Api.Entities;

namespace SsbuTools.Core.Repositories;

public interface IStageClassificationsRepository {
	public Task<List<StageClassificationsEntity>> GetAllStagesAsync();
	public Task<StageClassificationsEntity> GetStageByIdAsync(string id);
}
