using Microsoft.AspNetCore.Mvc;

namespace SsbuTools.Api.Responses;

public abstract class SsbuToolsResponse
{
	public abstract JsonResult ToJsonResult();
}
