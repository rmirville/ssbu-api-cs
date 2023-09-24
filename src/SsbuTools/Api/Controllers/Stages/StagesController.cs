using Microsoft.AspNetCore.Mvc;
using SsbuTools.Core.Repositories;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Produces("application/json")]
public class StagesController : BaseSsbuToolsApiController {

	private IStageClassificationsRepository _stages;

	public StagesController(IStageClassificationsRepository stages) {
		_stages = stages;
	}

	[HttpGet(Name = "StageIndex")]
	public async Task<JsonResult> GetAsync() {
		// get list of stages
		var stages = await _stages.GetAllStagesAsync();

		// put them in responseModel format
		// return the response
		return new JsonResult(stages);
	}
	[HttpGet("{id}")]
	public async Task<JsonResult> GetByIdAsync(string id)
	{
		var stage = await _stages.GetStageByIdAsync(id);
		return new JsonResult(stage);
	}
}
