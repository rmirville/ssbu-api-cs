using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageSummaryCollectionResponse : SsbuToolsResponse
{
	private readonly JsonResult _result;
	public StageSummaryCollectionResponse(List<IStageClassifications> stages, string baseStagesUrl)
	{
		var summaries = stages.Select(stage =>
		{
			var links = new Dictionary<string, string> {
				{
					"self", $"{baseStagesUrl}/{stage.Id}"
				}
			};
			return new RestResource<StageSummary>(links, new StageSummary(stage));
		}).ToArray();
		
		var embed = new StageSummariesEmbed(summaries);

		var links = new Dictionary<string, string> {
			{ "self", baseStagesUrl },
			{ "classifications", $"{baseStagesUrl}/classifications" },
			{ "classificationSets", $"{baseStagesUrl}/classification-sets" },
			{ "gameData", $"{baseStagesUrl}/game-data" },
			{ "pieceMaps", $"{baseStagesUrl}/piece-maps" },
		};
		
		_result = new JsonResult(new RestResource<StageSummariesEmbed>(links, embed));
	}

	public override JsonResult ToJsonResult() => _result;
}
