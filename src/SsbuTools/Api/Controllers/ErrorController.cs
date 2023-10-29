using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Responses;

namespace SsbuTools.Api.Controllers;

public class ErrorController : BaseSsbuToolsApiController
{
	[Route("")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public JsonResult HandleError() => new ErrorResponse(Problem().Value!).ToJsonResult();
}
