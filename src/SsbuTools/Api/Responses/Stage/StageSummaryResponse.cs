using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageSummaryResponse : SsbuToolsResponse
{
	public StageSummaryResponse(IStageClassifications entity, string baseUrl)
	{
		var stageUrl = $"{baseUrl}/{entity.Id}";
		var links = new Dictionary<string, string>
		{
			{"index", $"{baseUrl}/classifications"},
			{"stage", stageUrl},
			{"self", $"{stageUrl}/classifications"},
			{"gameData", $"{stageUrl}/game-data"}
		};
		var summary = new StageSummary(entity.Id, entity.Name, entity.GameName);
		Result = new JsonResult(new RestResource<StageSummary>(links, summary));
	}
}
