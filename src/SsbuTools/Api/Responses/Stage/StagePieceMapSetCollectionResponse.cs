using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;
using SsbuTools.Api.Entities;

namespace SsbuTools.Api.Responses;

public class StagePieceMapSetCollectionResponse : IRestResponse<BaseRestResourceWithEmbed<StagePieceMapSetSummariesEmbed>>
{
	public BaseRestResourceWithEmbed<StagePieceMapSetSummariesEmbed> Resource { get; init; }

	public StagePieceMapSetCollectionResponse(List<StagePieceMapSetEntity> sets, string baseStagesUrl)
	{
		var pieceMapResponses = sets.Select(set => new IdSummaryResponse(set.Id, "piece-maps", baseStagesUrl).Resource).ToArray();
		var embed = new StagePieceMapSetSummariesEmbed(pieceMapResponses);
		var links = new Dictionary<string, string> {
			{ "self", $"{baseStagesUrl}/piece-maps" },
			{ "index", baseStagesUrl },
		};
		Resource = new BaseRestResourceWithEmbed<StagePieceMapSetSummariesEmbed>(links, embed);
	}

	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
