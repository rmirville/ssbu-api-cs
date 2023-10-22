using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageSummaryResponse : IRestResponse<RestResource<StageSummary>>
{
	public RestResource<StageSummary> Resource { get; init; }

	public StageSummaryResponse(IStageClassifications stage, string baseStagesUrl)
	{
		var stageUrl = $"{baseStagesUrl}/{stage.Id}";
		var links = new Dictionary<string, string>
		{
			{"self", stageUrl},
			{"index", baseStagesUrl},
			{"classifications", $"{stageUrl}/classifications"},
			{"gameData", $"{stageUrl}/game-data"}
		};
		var summary = new StageSummary(stage.Id, stage.Name, stage.GameName);
		Resource = new RestResource<StageSummary>(links, summary);
	}

  public JsonResult ToJsonResult() => new JsonResult(Resource);
}
