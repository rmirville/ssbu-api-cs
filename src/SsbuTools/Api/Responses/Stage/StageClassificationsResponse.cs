using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageClassificationsResponse : IRestResponse<RestResource<StageClassifications>>
{
	public RestResource<StageClassifications> Resource { get; init; }

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
		Resource = new RestResource<StageClassifications>(links, classifications);
	}

	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
