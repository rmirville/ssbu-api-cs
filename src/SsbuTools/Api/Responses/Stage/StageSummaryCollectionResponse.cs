using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageSummaryCollectionResponse : SsbuToolsResponse
{
	private readonly RestResource<StageSummariesEmbed> _resource;
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
		
		_resource = new RestResource<StageSummariesEmbed>(links, embed);
	}

	public override JsonResult ToJsonResult() => new JsonResult(_resource);
}
