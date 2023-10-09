using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Services;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Route("v2/stages")]
[Produces("application/json")]
public class StageController : BaseSsbuToolsApiController {

	private StageService _stagesService;

	public StageController(StageService stagesService) {
		_stagesService = stagesService;
	}

	[HttpGet(Name = "StageIndex")]
	public async Task<JsonResult> GetAsync() {
		var stages = await _stagesService.GetAllStagesAsync();
		return new JsonResult(stages);
	}
	[HttpGet("{id}")]
	public async Task<JsonResult> GetByIdAsync(string id)
	{
		var stage = await _stagesService.GetStageByIdAsync(id);
		return new JsonResult(stage);
	}

	[HttpGet("classifications")]
	public async Task<JsonResult> GetAllClassificationsAsync()
	{
		var stage = await _stagesService.GetAllStageClassificationsAsync();
		return new JsonResult(stage);
	}

	[HttpGet("{id}/classifications")]
	public async Task<JsonResult> GetClassificationsByIdAsync(string id)
	{
		var stage = await _stagesService.GetStageClassificationsByIdAsync(id);
		return new JsonResult(stage);
	}

	[HttpGet("classification-sets")]
	public async Task<JsonResult> GetAllStageClassificationSetsAsync()
	{
		var stageSets = await _stagesService.GetAllStageSetsAsync();
		return new JsonResult(stageSets);
	}

	[HttpGet("classification-sets/{id}")]
	public async Task<JsonResult> GetStageClassificationsSetByIdAsync(string id)
	{
		var stageSet = await _stagesService.GetStageSetByIdAsync(id);
		return new JsonResult(stageSet);
	}

	[HttpGet("piece-maps")]
	public async Task<JsonResult> GetAllStagePieceMapSetsAsync()
	{
		var pieceMapSets = await _stagesService.GetAllStagePieceMapSetsAsync();
		return new JsonResult(pieceMapSets);
	}

	[HttpGet("piece-maps/{id}")]
	public async Task<JsonResult> GetStagePieceMapSetByIdAsync(string id)
	{
		var pieceMapSet = await _stagesService.GetStagePieceMapSetByIdAsync(id);
		return new JsonResult(pieceMapSet);
	}

	[HttpGet("game-data")]
	public async Task<JsonResult> GetAllStageGameDatasetsAsync()
	{
		var gameDatasets = await _stagesService.GetAllStageGameDatasetsAsync();
		return new JsonResult(gameDatasets);
	}
}
