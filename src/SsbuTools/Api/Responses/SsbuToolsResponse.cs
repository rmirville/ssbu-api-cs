using Microsoft.AspNetCore.Mvc;

namespace SsbuTools.Api.Responses;

public class SsbuToolsResponse
{
	protected JsonResult Result { get; set; } = new JsonResult(new {});
	public JsonResult ToJsonResult() => Result;
}
