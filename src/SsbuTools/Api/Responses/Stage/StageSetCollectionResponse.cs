using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageSetCollectionResponse : SsbuToolsResponse
{
	private readonly BaseRestResourceWithEmbed<StageClassificationsSetSummariesEmbed> _resource;
	public StageSetCollectionResponse(List<IStageSet> stageSets, string baseStagesUrl)
	{
		var summaries = stageSets.Select(set =>
		{
			return new IdSummaryResponse(set.Id, "classification-sets", baseStagesUrl).Resource;
		}).ToList();
		var links = new Dictionary<string, string> {
			{ "self", $"{baseStagesUrl}/classification-sets" },
			{ "index", baseStagesUrl }
		};
		var embed = new StageClassificationsSetSummariesEmbed(summaries);
		_resource = new BaseRestResourceWithEmbed<StageClassificationsSetSummariesEmbed>(links, embed);
	}

	public override JsonResult ToJsonResult() => new JsonResult(_resource);
}
