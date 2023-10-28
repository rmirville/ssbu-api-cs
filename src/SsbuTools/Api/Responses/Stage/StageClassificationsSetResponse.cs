using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageClassificationsSetResponse : IRestResponse<RestResource<StageClassificationsSet>>
{
	public RestResource<StageClassificationsSet> Resource { get; init; }

	public StageClassificationsSetResponse(StageClassificationsSet stageSet, string baseStagesUrl)
	{
		var stageSetUrl = $"{baseStagesUrl}/classifications-sets";
		var links = new Dictionary<string, string>
		{
			{ "self", stageSetUrl + $"/{stageSet.Id}" },
			{ "index", stageSetUrl },
			{ "stages", baseStagesUrl }
		};
		Resource = new RestResource<StageClassificationsSet>(links, stageSet);
	}

	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
