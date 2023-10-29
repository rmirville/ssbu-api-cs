using Microsoft.Extensions.Options;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Dtos.Stage;
using SsbuTools.Api.Options;
using SsbuTools.Infrastructure.Repositories;

namespace SsbuTools.Api.Models;

public class StageModel
{
	private readonly ApiOptions _config;
	private readonly string _baseControllerUrl;
	private readonly string _path = "/v2/stages";
	private readonly Dictionary<string, string> _indexLinks;
	private readonly StageClassificationsRepository _stages;
	private readonly StageSetRepository _stageSets;
	private readonly StagePieceMapSetRepository _stagePieceMapSets;
	private readonly StageGameDatasetRepository _stageGameDatasets;

	public StageModel(IOptions<ApiOptions> config, StageClassificationsRepository stages, StageSetRepository stageSets, StagePieceMapSetRepository stagePieceMapSets, StageGameDatasetRepository stageGameDatasets)
	{
		_stages = stages;
		_stageSets = stageSets;
		_stagePieceMapSets = stagePieceMapSets;
		_stageGameDatasets = stageGameDatasets;
		_config = config.Value;
		_baseControllerUrl = _config.BaseUrl + _path;
		_indexLinks = new Dictionary<string, string> {
			{ "self", _baseControllerUrl },
			{ "classifications", _baseControllerUrl + "/classifications" },
			{ "classificationSets", _baseControllerUrl + "/classification-sets" },
			{ "gameData", _baseControllerUrl + "/game-data" },
			{ "pieceMaps", _baseControllerUrl + "/piece-maps" },
		};
	}

	public Task<List<StageClassificationsEntity>> GetAllAsync()
	{
		return _stages.GetAllAsync();
	}

  public Task<StageClassificationsEntity> GetByIdAsync(string id) => _stages.GetByIdAsync(id);

	public Task<List<StageClassificationsEntity>> GetAllStageClassificationsAsync()
	{
		return _stages.GetAllAsync();
	}

	public Task<StageClassificationsEntity> GetClassificationsByIdAsync(string id)
	{
		return _stages.GetByIdAsync(id);
	}
	public async Task<List<StageSetEntity>> GetAllSetsAsync()
	{
		var allStages = (await _stages.GetAllAsync()).Select(stage => stage.Id).ToList();
		var allSet = new StageSetEntity { Id = "all", Stages = allStages };
		var summaries = (await _stageSets.GetAllStageSetsAsync()).Append(allSet).ToList();
		return summaries;
	}

	public async Task<StageClassificationsSet> GetSetByIdAsync(string id)
	{
		Task<List<StageClassificationsEntity>> classificationsTask;
		if (id == "all")
		{
			classificationsTask = _stages.GetAllAsync();
		}
		else
		{
			var stageSet = await _stageSets.GetStageSetByIdAsync(id);
			classificationsTask = _stages.GetManyByIdsAsync(stageSet.Stages);
		}
		var classifications = (await classificationsTask)
			.Select(classifications => new StageClassifications(classifications))
			.ToArray();
		return new StageClassificationsSet(id, classifications);
	}

	public Task<List<StagePieceMapSetEntity>> GetAllPieceMapSetsAsync()
	{
		return _stagePieceMapSets.GetAllAsync();
	}

  public Task<StagePieceMapSetEntity> GetPieceMapSetByIdAsync(string id)
	{
		return _stagePieceMapSets.GetByIdAsync(id);
	}

	public Task<List<StageGameDatasetEntity>> GetAllGameDatasetsAsync()
	{
		return _stageGameDatasets.GetAllAsync();
	}

	public Task<StageGameDatasetEntity> GetGameDataByIdAsync(string id)
	{
		return _stageGameDatasets.GetByIdAsync(id);
	}
}
