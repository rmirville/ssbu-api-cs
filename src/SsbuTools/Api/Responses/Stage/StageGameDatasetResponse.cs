using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Responses;

public class StageGameDatasetResponse : IRestResponse<RestResource<StageGameDataset>>
{
	public RestResource<StageGameDataset> Resource { get; init; }
	public StageGameDatasetResponse(IStageGameDataset dataset, string baseStagesUrl)
	{
		var links = new Dictionary<string, string> {
			{
				"self", $"{baseStagesUrl}/{dataset.Id}/game-data"
			},
			{
				"index", $"{baseStagesUrl}/{dataset.Id}"
			},
			{
				"gameData", $"{baseStagesUrl}/game-data"
			},
			{
				"stages", $"{baseStagesUrl}"
			}
		};
		var stageGameDataset = new StageGameDataset(dataset);
		Resource = new RestResource<StageGameDataset>(links, stageGameDataset);
	}
	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
