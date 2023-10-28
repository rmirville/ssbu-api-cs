using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;
using SsbuTools.Api.Entities;

namespace SsbuTools.Api.Responses;

public class StageGameDatasetCollectionResponse : IRestResponse<BaseRestResourceWithEmbed<StageGameDatasetSummariesEmbed>>
{
	public BaseRestResourceWithEmbed<StageGameDatasetSummariesEmbed> Resource { get; init; }

	public StageGameDatasetCollectionResponse(List<StageGameDatasetEntity> datasets, string baseStagesUrl)
	{
		var summaries = datasets.Select(dataset => {
			var links = new Dictionary<string, string> {
				{
					"self", $"{baseStagesUrl}/{dataset.Id}/game-data"
				}
			};
			var summary = new StageGameDatasetSummary(dataset.Id, dataset.Data[0].Name);
			return new RestResource<StageGameDatasetSummary>(links, summary);
		}).ToArray();
		var embedded = new StageGameDatasetSummariesEmbed(summaries);
		var links = new Dictionary<string, string> {
			{ "self", $"{baseStagesUrl}/game-data" },
			{ "index", baseStagesUrl }
		};
		Resource = new BaseRestResourceWithEmbed<StageGameDatasetSummariesEmbed>(links, embedded);
	}

	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
