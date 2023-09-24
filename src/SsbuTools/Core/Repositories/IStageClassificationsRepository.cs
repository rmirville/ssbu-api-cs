using SsbuTools.Api.Entities;

namespace SsbuTools.Core.Repositories;

public interface IStageClassificationsRepository {
	public Task<List<StageClassifications>> GetAllStagesAsync();
	public Task<StageClassifications> GetStageByIdAsync(string id);
}
