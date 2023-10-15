using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Models;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Route("v2/stages")]
[Produces("application/json")]
public class StageController : BaseSsbuToolsApiController {

	private StageModel _stageModel;

	public StageController(StageModel stageModel) {
		_stageModel = stageModel;
	}

	[HttpGet(Name = "StageIndex")]
	public async Task<JsonResult> GetAsync() {
		var stages = await _stageModel.GetAllStagesAsync();
		return new JsonResult(stages);
	}
	[HttpGet("{id}")]
	public async Task<JsonResult> GetByIdAsync(string id)
	{
		var stage = await _stageModel.GetStageByIdAsync(id);
		return new JsonResult(stage);
	}

	[HttpGet("classifications")]
	public async Task<JsonResult> GetAllClassificationsAsync()
	{
		var stage = await _stageModel.GetAllStageClassificationsAsync();
		return new JsonResult(stage);
	}

	[HttpGet("{id}/classifications")]
	public async Task<JsonResult> GetClassificationsByIdAsync(string id)
	{
		var stage = await _stageModel.GetStageClassificationsByIdAsync(id);
		return new JsonResult(stage);
	}

	[HttpGet("classification-sets")]
	public async Task<JsonResult> GetAllStageClassificationSetsAsync()
	{
		var stageSets = await _stageModel.GetAllStageSetsAsync();
		return new JsonResult(stageSets);
	}

	[HttpGet("classification-sets/{id}")]
	public async Task<JsonResult> GetStageClassificationsSetByIdAsync(string id)
	{
		var stageSet = await _stageModel.GetStageSetByIdAsync(id);
		return new JsonResult(stageSet);
	}

	[HttpGet("piece-maps")]
	public async Task<JsonResult> GetAllStagePieceMapSetsAsync()
	{
		var pieceMapSets = await _stageModel.GetAllStagePieceMapSetsAsync();
		return new JsonResult(pieceMapSets);
	}

	[HttpGet("piece-maps/{id}")]
	public async Task<JsonResult> GetStagePieceMapSetByIdAsync(string id)
	{
		var pieceMapSet = await _stageModel.GetStagePieceMapSetByIdAsync(id);
		return new JsonResult(pieceMapSet);
	}

	[HttpGet("game-data")]
	public async Task<JsonResult> GetAllStageGameDatasetsAsync()
	{
		var gameDatasets = await _stageModel.GetAllStageGameDatasetsAsync();
		return new JsonResult(gameDatasets);
	}
}
