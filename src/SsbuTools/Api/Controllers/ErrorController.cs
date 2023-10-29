using Microsoft.AspNetCore.Mvc;

namespace SsbuTools.Api.Controllers;

public class ErrorController : BaseSsbuToolsApiController
{
	[Route("")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public IActionResult HandleError() => Problem();
}
