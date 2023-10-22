namespace SsbuTools.Api.Responses;
using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

public class StageClassificationsResponse : SsbuToolsResponse
{
	private readonly RestResource<StageClassifications> _resource;

	public StageClassificationsResponse(IStageClassifications stage, string baseStagesUrl)
	{
		var stageUrl = $"{baseStagesUrl}/{stage.Id}";
		var links = new Dictionary<string, string>
		{
			{"self", $"{stageUrl}/classifications"},
			{"index", stageUrl},
			{"stages", baseStagesUrl}
		};
		var classifications = new StageClassifications(stage);
		_resource = new RestResource<StageClassifications>(links, classifications);
	}

	public override JsonResult ToJsonResult() => new JsonResult(_resource);
}
