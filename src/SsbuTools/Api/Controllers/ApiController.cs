using Microsoft.AspNetCore.Mvc;

using SsbuTools.Api.Models;
using SsbuTools.Api.Services;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Route("v1")]
[Produces("application/json")]
public class ApiController : ControllerBase
{

	private IIndexService _indexService;

	public ApiController(IIndexService indexService)
	{
		_indexService = indexService;
	}

	[HttpGet(Name = "ApiIndex")]
	public ActionResult<ResponseModel> Get()
	{
		return _indexService.GetIndex();
	}
}
