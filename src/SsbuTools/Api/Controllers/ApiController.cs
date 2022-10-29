using Microsoft.AspNetCore.Mvc;

using SsbuTools.Api.Models.Response;
using SsbuTools.Api.Services;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Route("v1")]
[Produces("application/json")]
public class ApiController : ControllerBase {

	private IndexService IndexService;

	public ApiController(IndexService indexService) {
		IndexService = indexService;
	}

	[HttpGet(Name = "ApiIndex")]
	public ResponseModel Get() {
		return IndexService.GetIndex();
	}
}
