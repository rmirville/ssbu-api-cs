using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Services;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Route("v2")]
[Produces("application/json")]
public class ApiController : ControllerBase
{

	private IndexService _indexService;

	public ApiController(IndexService indexService)
	{
		_indexService = indexService;
	}

	[HttpGet(Name = "ApiIndex")]
	public ActionResult<BaseRestResource> Get()
	{
		return _indexService.GetIndex();
	}
}
