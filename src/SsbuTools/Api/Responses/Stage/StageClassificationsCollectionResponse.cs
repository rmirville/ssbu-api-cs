using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageClassificationsCollectionResponse : IRestResponse<BaseRestResourceWithEmbed<StageSummariesEmbed>>
{
	public BaseRestResourceWithEmbed<StageSummariesEmbed> Resource { get; init; }

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
		Resource = new BaseRestResourceWithEmbed<StageSummariesEmbed>(links, embed);
	}
	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
