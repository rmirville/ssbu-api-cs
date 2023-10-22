using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;

namespace SsbuTools.Api.Responses;

public class ApiIndexResponse : IRestResponse<BaseRestResource>
{
	public BaseRestResource Resource { get; init; }

	public ApiIndexResponse(string hostname, string apiPath) {
		var baseUrl = $"{hostname}/{apiPath}";
		var links = new Dictionary<string, string> {
			{ "self", baseUrl },
			{ "stages", $"{baseUrl}/stages" },
			{ "docs", $"{hostname}/swagger" }
		};
		Resource = new BaseRestResource(links);
	}

	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
