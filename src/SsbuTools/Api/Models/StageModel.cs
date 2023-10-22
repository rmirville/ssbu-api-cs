using Microsoft.Extensions.Options;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Dtos;
using SsbuTools.Api.Dtos.Resource;
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

	public async Task<List<StageClassificationsEntity>> GetAllStagesAsync()
	{
		return await _stages.GetAllAsync();
	}

  public Task<StageClassificationsEntity> GetStageByIdAsync(string id) => _stages.GetByIdAsync(id);

	public async Task<List<StageClassificationsEntity>> GetAllStageClassificationsAsync()
	{
		return await _stages.GetAllAsync();
	}

	public async Task<StageClassificationsEntity> GetStageClassificationsByIdAsync(string id)
	{
		return await _stages.GetByIdAsync(id);
	}
	public async Task<List<StageSetEntity>> GetAllStageSetsAsync()
	{
		var allStages = (await _stages.GetAllAsync()).Select(stage => stage.Id).ToList();
		var allSet = new StageSetEntity { Id = "all", Stages =allStages };
		var summaries = (await _stageSets.GetAllStageSetsAsync()).Append(allSet).ToList();
		return summaries;
	}

	public async Task<RestResource<StageClassificationsSet>> GetStageSetByIdAsync(string id)
	{
		var stageSetPath = $"{_baseControllerUrl}/classification-sets";
		var links = new Dictionary<string, string>
		{
			{ "self", stageSetPath + $"/{id}" },
			{ "index", stageSetPath },
			{ "stages", _baseControllerUrl }
		};

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
		var classificationsSet = new StageClassificationsSet(id, classifications);
		return new RestResource<StageClassificationsSet>(links, classificationsSet);
	}

	public async Task<BaseRestResourceWithEmbed<StagePieceMapSetSummariesEmbed>> GetAllStagePieceMapSetsAsync()
	{
		var summaries = (await _stagePieceMapSets.GetAllAsync()).Select(set => IdToIdSummarySetResponse(set.Id, "piece-maps")).ToArray();
		var embedded = new StagePieceMapSetSummariesEmbed(summaries);
		var links = new Dictionary<string, string> {
			{ "self", $"{_baseControllerUrl}/piece-maps" },
			{ "index", _baseControllerUrl }
		};

		return new BaseRestResourceWithEmbed<StagePieceMapSetSummariesEmbed>(links, embedded);
	}

  public async Task<RestResource<StagePieceMapSet>> GetStagePieceMapSetByIdAsync(string id)
	{
		var stagePieceMapSetPath = $"{_baseControllerUrl}/piece-maps";
		var links = new Dictionary<string, string> {
			{ "self", stagePieceMapSetPath + $"/{id}" },
			{ "index", stagePieceMapSetPath },
			{ "stages", _baseControllerUrl }
		};
		var stagePieceMapSetEntity = await _stagePieceMapSets.GetByIdAsync(id);
		var stagePieceMapSet = new StagePieceMapSet(stagePieceMapSetEntity);
		return new RestResource<StagePieceMapSet>(links, stagePieceMapSet);
	}

	public async Task<BaseRestResourceWithEmbed<StageGameDatasetSummariesEmbed>> GetAllStageGameDatasetsAsync()
	{
		var summaries = (await _stageGameDatasets.GetAllAsync()).Select(dataset => {
			var links = new Dictionary<string, string> {
				{
					"self", $"{_baseControllerUrl}/game-data/{dataset.Id}"
				}
			};
			var summary = new StageGameDatasetSummary(dataset.Id, dataset.Data[0].Name);
			return new RestResource<StageGameDatasetSummary>(links, summary);
		}).ToArray();
		var embedded = new StageGameDatasetSummariesEmbed(summaries);
		var links = new Dictionary<string, string> {
			{ "self", $"{_baseControllerUrl}/game-data" },
			{ "index", _baseControllerUrl }
		};
		return new BaseRestResourceWithEmbed<StageGameDatasetSummariesEmbed>(links, embedded);
	}

	private RestResource<IdSummary> IdToIdSummarySetResponse(string id, string path = "")
	{
		var embeddedLinks = new Dictionary<string, string> {
				{
					"self", $"{_baseControllerUrl}/{path}/{id}"
				}
			};
		return new RestResource<IdSummary>(embeddedLinks, new IdSummary(id));
	}
}
