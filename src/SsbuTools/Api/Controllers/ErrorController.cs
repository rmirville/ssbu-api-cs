using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SsbuTools.Api.Options;
using SsbuTools.Api.Responses;

namespace SsbuTools.Api.Controllers;

public class ErrorController : BaseSsbuToolsApiController
{
	private readonly ApiOptions _config;
	private readonly string _baseRoute = "/v2";
	private readonly string _baseRedirectUrl;

	public ErrorController(IOptions<ApiOptions> config) {
		_config = config.Value;
		_baseRedirectUrl = _config.BaseUrl + _baseRoute;
	}

	[Route("")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public JsonResult HandleError() => new ErrorResponse(Problem().Value!, _baseRedirectUrl).ToJsonResult();
}
