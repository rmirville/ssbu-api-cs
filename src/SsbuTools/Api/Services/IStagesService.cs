using SsbuTools.Api.Models.Response;
using SsbuTools.Api.Models.Stage;

namespace SsbuTools.Api.Services;

public interface IStagesService
{
	public Task<BaseResponseWithEmbed<StageSummariesEmbed>> GetAllStagesAsync();
	public Task<TypedResponse<StageSummary>> GetStageByIdAsync(string id);
	public Task<BaseResponseWithEmbed<StageClassificationsEmbed>> GetAllStageClassificationsAsync();
	public Task<TypedResponse<StageClassifications>> GetStageClassificationsByIdAsync(string id);
	public Task<BaseResponseWithEmbed<StageClassificationsSetSummariesEmbed>> GetAllStageSetsAsync();
}
