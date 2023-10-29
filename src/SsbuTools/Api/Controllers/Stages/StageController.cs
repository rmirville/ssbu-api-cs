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
	public async Task<JsonResult> Get() {
		var stages = (await _stageModel.GetAllAsync()).ToList<IStageClassifications>();
		return new StageSummaryCollectionResponse(stages, _baseControllerUrl).ToJsonResult();
	}
	[HttpGet("{id}")]
	public async Task<JsonResult> GetById(string id)
	{
		var stage = await _stageModel.GetByIdAsync(id);
		return new StageSummaryResponse(stage, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("classifications")]
	public async Task<JsonResult> GetAllClassifications()
	{
		var stages = (await _stageModel.GetAllStageClassificationsAsync()).ToList<IStageClassifications>();
		return new StageClassificationsCollectionResponse(stages, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("{id}/classifications")]
	public async Task<JsonResult> GetClassificationsById(string id)
	{
		var stage = await _stageModel.GetClassificationsByIdAsync(id);
		return new StageClassificationsResponse(stage, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("classification-sets")]
	public async Task<JsonResult> GetAllClassificationsSets()
	{
		var stageSets = (await _stageModel.GetAllSetsAsync()).ToList<IStageSet>();
		return new StageSetCollectionResponse(stageSets, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("classification-sets/{id}")]
	public async Task<JsonResult> GetClassificationsSetById(string id)
	{
		var stageSet = await _stageModel.GetSetByIdAsync(id);
		return new StageClassificationsSetResponse(stageSet, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("piece-maps")]
	public async Task<JsonResult> GetAllPieceMapSets()
	{
		var pieceMapSets = await _stageModel.GetAllPieceMapSetsAsync();
		return new StagePieceMapSetCollectionResponse(pieceMapSets, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("piece-maps/{id}")]
	public async Task<JsonResult> GetPieceMapSetById(string id)
	{
		var pieceMapSet = await _stageModel.GetPieceMapSetByIdAsync(id);
		return new StagePieceMapSetResponse(pieceMapSet, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("game-data")]
	public async Task<JsonResult> GetAllGameDatasets()
	{
		var gameDatasets = await _stageModel.GetAllGameDatasetsAsync();
		return new StageGameDatasetCollectionResponse(gameDatasets, _baseControllerUrl).ToJsonResult();
	}

	[HttpGet("{id}/game-data")]
	public async Task<JsonResult> GetGameDatasetById(string id)
	{
		var gameDataset = await _stageModel.GetGameDataByIdAsync(id);
		return new StageGameDatasetResponse(gameDataset, _baseControllerUrl).ToJsonResult();
	}
}
