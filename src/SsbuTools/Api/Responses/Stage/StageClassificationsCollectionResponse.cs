using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageClassificationsCollectionResponse : SsbuToolsResponse
{
	private readonly JsonResult _result;

	public StageClassificationsCollectionResponse(List<IStageClassifications> stages, string baseStagesUrl)
	{
		var collection = stages.Select(stage =>
		{
			var links = new Dictionary<string, string> {
				{
					"self", $"{baseStagesUrl}/{stage.Id}/classifications"
				}
			};
			return new RestResource<StageSummary>(links, new StageClassifications(stage));
		}).ToArray();
		var embed = new StageSummariesEmbed(collection);
		var links = new Dictionary<string, string> {
			{ "self", $"{baseStagesUrl}/classifications" },
			{ "index", baseStagesUrl },
		};
		_result = new JsonResult(new BaseRestResourceWithEmbed<StageSummariesEmbed>(links, embed));
	}
	public override JsonResult ToJsonResult() => _result;
}
