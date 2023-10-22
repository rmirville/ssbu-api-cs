using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageSummaryResponse : SsbuToolsResponse
{
	private readonly RestResource<StageSummary> _resource;

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
		_resource = new RestResource<StageSummary>(links, summary);
	}

  public override JsonResult ToJsonResult() => new JsonResult(_resource);
}
