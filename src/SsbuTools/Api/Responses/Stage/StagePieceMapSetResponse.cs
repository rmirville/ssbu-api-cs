using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;
using SsbuTools.Api.Entities;

namespace SsbuTools.Api.Responses;

public class StagePieceMapSetResponse : IRestResponse<RestResource<StagePieceMapSet>>
{
	public RestResource<StagePieceMapSet> Resource { get; init; }

	public StagePieceMapSetResponse(StagePieceMapSetEntity pieceMapSet, string baseStagesUrl)
	{
		var stagePieceMapSetsUrl = $"{baseStagesUrl}/piece-maps";
		var links = new Dictionary<string, string> {
			{ "self", $"{stagePieceMapSetsUrl}/{pieceMapSet.Id}" },
			{ "index", stagePieceMapSetsUrl },
			{ "stages", baseStagesUrl }
		};
		var stagePieceMapSet = new StagePieceMapSet(pieceMapSet);
		Resource = new RestResource<StagePieceMapSet>(links, stagePieceMapSet);
	}

  public JsonResult ToJsonResult() => new JsonResult(Resource);
}
