using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos;
using SsbuTools.Api.Dtos.Resource;

namespace SsbuTools.Api.Responses;

public class IdSummaryResponse : SsbuToolsResponse
{
	public RestResource<IdSummary> Resource { get; init; }

	public IdSummaryResponse(string id, string path, string baseUrl)
	{
		var links = new Dictionary<string, string> {
			{ "self", $"{baseUrl}/{path}/{id}"},
		};
		Resource = new RestResource<IdSummary>(links, new IdSummary(id));
	}

	public override JsonResult ToJsonResult() => new JsonResult(Resource);
}
