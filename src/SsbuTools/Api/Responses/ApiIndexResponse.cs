using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
namespace SsbuTools.Api.Responses;
public class ApiIndexResponse : SsbuToolsResponse
{
	private readonly JsonResult _result;
	public ApiIndexResponse(string hostname, string apiPath) {
		var baseUrl = $"{hostname}/{apiPath}";
		var links = new Dictionary<string, string> {
			{ "self", baseUrl },
			{ "stages", $"{baseUrl}/stages" },
			{ "docs", $"{hostname}/swagger" }
		};
		_result = new JsonResult(new BaseRestResource(links));
	}

	public override JsonResult ToJsonResult() => _result;
}
