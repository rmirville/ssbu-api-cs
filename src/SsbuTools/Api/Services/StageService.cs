using Microsoft.Extensions.Options;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Dtos;
using SsbuTools.Api.Dtos.Resource;
using SsbuTools.Api.Dtos.Stage;
using SsbuTools.Api.Options;
using SsbuTools.Infrastructure.Repositories;

namespace SsbuTools.Api.Services;

public class StageService
{
	private readonly ApiOptions _config;
	private readonly string _baseControllerUrl;
	private readonly string _path = "/v2/stages";
	private readonly Dictionary<string, string> _indexLinks;
	private readonly StageClassificationsRepository _stages;
	private readonly StageSetRepository _stageSets;
	private readonly StagePieceMapSetRepository _stagePieceMapSets;
	private readonly StageGameDatasetRepository _stageGameDatasets;

	public StageService(IOptions<ApiOptions> config, StageClassificationsRepository stages, StageSetRepository stageSets, StagePieceMapSetRepository stagePieceMapSets, StageGameDatasetRepository stageGameDatasets)
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

	public async Task<BaseRestResourceWithEmbed<StageSummariesEmbed>> GetAllStagesAsync()
	{
		var summaries = (await _stages.GetAllAsync()).Select(stage =>
		{
			var links = new Dictionary<string, string> {
				{
					"self", $"{_baseControllerUrl}/{stage.Id}"
				}
			};
			return new RestResource<StageSummary>(links, new StageSummary(stage));
		}
		).ToArray();
		var embedded = new StageSummariesEmbed(summaries);
		return new BaseRestResourceWithEmbed<StageSummariesEmbed>(_indexLinks, embedded);
	}

  public async Task<RestResource<StageSummary>> GetStageByIdAsync(string id)
	{
		var stage = await _stages.GetByIdAsync(id);
		var summary = new StageSummary(stage.Id, stage.Name, stage.GameName);
		var stagePath = $"{_baseControllerUrl}/{stage.Id}";
		var links = new Dictionary<string, string>
		{
			{ "self", stagePath },
			{ "index", _baseControllerUrl },
			{ "classifications", stagePath + "/classifications" },
			{ "gameData", stagePath + "/game-data" }
		};
		return new RestResource<StageSummary>(links, summary);
	}

	public async Task<BaseRestResourceWithEmbed<StageClassificationsEmbed>> GetAllStageClassificationsAsync()
	{
		var classifications = (await _stages.GetAllAsync()).Select(stage =>
		{
			var links = new Dictionary<string, string> {
				{
					"self", $"{_baseControllerUrl}/{stage.Id}/classifications"
				}
			};
			return new RestResource<StageClassifications>(links, new StageClassifications(stage));
		}
		).ToArray();
		var embedded = new StageClassificationsEmbed(classifications);
		var links = new Dictionary<string, string> {
			{ "self", _baseControllerUrl + "/classifications" },
			{ "index", _baseControllerUrl },
		};
		return new BaseRestResourceWithEmbed<StageClassificationsEmbed>(links, embedded);
	}

	public async Task<RestResource<StageClassifications>> GetStageClassificationsByIdAsync(string id)
	{
		var stage = await _stages.GetByIdAsync(id);
		var classifications = new StageClassifications(stage);
		var stagePath = $"{_baseControllerUrl}/{stage.Id}";
		var links = new Dictionary<string, string>
		{
			{ "self", stagePath + "/classifications" },
			{ "index", stagePath },
			{ "stages", _baseControllerUrl }
		};
		return new RestResource<StageClassifications>(links, classifications);
	}
	public async Task<BaseRestResourceWithEmbed<StageClassificationsSetSummariesEmbed>> GetAllStageSetsAsync()
	{
		var summaries = (await _stageSets.GetAllStageSetsAsync()).Select(set =>
		{
			return IdToIdSummarySetResponse(set.Id, "classification-sets");
		}
		).Append(IdToIdSummarySetResponse("all", "classification-sets"))
		.ToArray();
		var embedded = new StageClassificationsSetSummariesEmbed(summaries);
		var links = new Dictionary<string, string> {
			{ "self", $"{_baseControllerUrl}/classification-sets" },
			{ "index", _baseControllerUrl }
		};
		return new BaseRestResourceWithEmbed<StageClassificationsSetSummariesEmbed>(links, embedded);
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
