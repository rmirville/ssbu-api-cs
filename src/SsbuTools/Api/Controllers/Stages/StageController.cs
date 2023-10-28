using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SsbuTools.Api.Dtos.Stage;
using SsbuTools.Api.Models;
using SsbuTools.Api.Options;
using SsbuTools.Api.Responses;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Route("v2/stages")]
[Produces("application/json")]
public class StageController : BaseSsbuToolsApiController {

	private readonly StageModel _stageModel;
	private readonly ApiOptions _config;
	private readonly string _baseRoute = "/v2/stages";
	private readonly string _baseControllerUrl;

	public StageController(IOptions<ApiOptions> config, StageModel stageModel) {
		_config = config.Value;
		_stageModel = stageModel;
		_baseControllerUrl = _config.BaseUrl + _baseRoute;
	}

	[HttpGet(Name = "StageIndex")]
	public async Task<JsonResult> GetAsync() {
		var stages = (await _stageModel.GetAllStagesAsync()).ToList<IStageClassifications>();
		return new StageSummaryCollectionResponse(stages, _baseControllerUrl).ToJsonResult();
	}
	[HttpGet("{id}")]
	public async Task<JsonResult> GetByIdAsync(string id)
	{
		var stage = await _stageModel.GetStageByIdAsync(id);
		return new StageSummaryResponse(stage, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("classifications")]
	public async Task<JsonResult> GetAllClassificationsAsync()
	{
		var stages = (await _stageModel.GetAllStageClassificationsAsync()).ToList<IStageClassifications>();
		return new StageClassificationsCollectionResponse(stages, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("{id}/classifications")]
	public async Task<JsonResult> GetStageClassificationsByIdAsync(string id)
	{
		var stage = await _stageModel.GetStageClassificationsByIdAsync(id);
		return new StageClassificationsResponse(stage, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("classification-sets")]
	public async Task<JsonResult> GetAllStageClassificationSetsAsync()
	{
		var stageSets = (await _stageModel.GetAllStageSetsAsync()).ToList<IStageSet>();
		return new StageSetCollectionResponse(stageSets, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("classification-sets/{id}")]
	public async Task<JsonResult> GetStageClassificationsSetByIdAsync(string id)
	{
		var stageSet = await _stageModel.GetStageSetByIdAsync(id);
		return new StageClassificationsSetResponse(stageSet, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("piece-maps")]
	public async Task<JsonResult> GetAllStagePieceMapSetsAsync()
	{
		var pieceMapSets = await _stageModel.GetAllStagePieceMapSetsAsync();
		return new StagePieceMapSetCollectionResponse(pieceMapSets, _baseControllerUrl).ToJsonResult();
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
