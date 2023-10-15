using Microsoft.AspNetCore.Mvc;

namespace SsbuTools.Api.Responses;

public class SsbuToolsResponse
{
	protected JsonResult _result = new JsonResult(new {});
	public JsonResult ToJsonResult() => _result;
}
