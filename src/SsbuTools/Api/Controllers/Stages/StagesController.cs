using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Services;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Produces("application/json")]
public class StagesController : BaseSsbuToolsApiController {

	private IStagesService _stagesService;

	public StagesController(IStagesService stagesService) {
		_stagesService = stagesService;
	}

	[HttpGet(Name = "StageIndex")]
	public async Task<JsonResult> GetAsync() {
		// get list of stages
		var stages = await _stagesService.GetAllStagesAsync();

		// put them in responseModel format
		// return the response
		return new JsonResult(stages);
	}
	[HttpGet("{id}")]
	public async Task<JsonResult> GetByIdAsync(string id)
	{
		var stage = await _stagesService.GetStageByIdAsync(id);
		return new JsonResult(stage);
	}

	[HttpGet("{id}/classifications")]
	public async Task<JsonResult> GetClassificationsByIdAsync(string id)
	{
		var stage = await _stagesService.GetStageClassificationsByIdAsync(id);
		return new JsonResult(stage);
	}
}
