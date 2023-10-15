using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Options;
using SsbuTools.Api.Responses;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Route("v2")]
[Produces("application/json")]
public class ApiController : ControllerBase
{

	private readonly ApiOptions _config;
	private readonly string _path = "v2";

	public ApiController(IOptions<ApiOptions> apiOptions)
	{
		_config = apiOptions.Value;
	}

	[HttpGet(Name = "ApiIndex")]
	public ActionResult<BaseRestResource> Get()
	{
		return new ApiIndexResponse(_config.BaseUrl, _path).ToJsonResult();
	}
}
