using Microsoft.Extensions.Options;
using SsbuTools.Api.Entities;
using SsbuTools.Api.Models.Response;
using SsbuTools.Api.Models.Stage;
using SsbuTools.Api.Options;
using SsbuTools.Infrastructure.Repositories;

namespace SsbuTools.Api.Services;

public class StageService
{
	private BaseResponse _index;

	private readonly ApiOptions _config;
	private string _baseControllerUrl;
	private readonly string _path = "/v2/stages";
	private Dictionary<string, string> _indexLinks;
	private StageClassificationsRepository _stages;
	private StageSetRepository _stageSets;
	private StagePieceMapSetRepository _stagePieceMapSets;
	private StageGameDatasetRepository _stageGameDatasets;

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
		_index = new BaseResponse(_indexLinks);
	}

	public async Task<BaseResponseWithEmbed<StageSummariesEmbed>> GetAllStagesAsync()
	{
		var summaries = (await _stages.GetAllAsync()).Select(stage =>
		{
			var links = new Dictionary<string, string> {
				{
					"self", $"{_baseControllerUrl}/{stage.Id}"
				}
			};
			return new TypedResponse<StageSummary>(links, new StageSummary(stage));
		}
		).ToArray();
		var embedded = new StageSummariesEmbed(summaries);
		return new BaseResponseWithEmbed<StageSummariesEmbed>(_indexLinks, embedded);
	}

  public async Task<TypedResponse<StageSummary>> GetStageByIdAsync(string id)
	{
		var stage = await _stages.GetStageByIdAsync(id);
		var summary = new StageSummary(stage.Id, stage.Name, stage.GameName);
		var stagePath = $"{_baseControllerUrl}/{stage.Id}";
		var links = new Dictionary<string, string>
		{
			{ "self", stagePath },
			{ "index", _baseControllerUrl },
			{ "classifications", stagePath + "/classifications" },
			{ "gameData", stagePath + "/game-data" }
		};
		return new TypedResponse<StageSummary>(links, summary);
	}

	public async Task<BaseResponseWithEmbed<StageClassificationsEmbed>> GetAllStageClassificationsAsync()
	{
		var classifications = (await _stages.GetAllAsync()).Select(stage =>
		{
			var links = new Dictionary<string, string> {
				{
					"self", $"{_baseControllerUrl}/{stage.Id}/classifications"
				}
			};
			return new TypedResponse<StageClassifications>(links, new StageClassifications(stage));
		}
		).ToArray();
		var embedded = new StageClassificationsEmbed(classifications);
		var links = new Dictionary<string, string> {
			{ "self", _baseControllerUrl + "/classifications" },
			{ "index", _baseControllerUrl },
		};
		return new BaseResponseWithEmbed<StageClassificationsEmbed>(links, embedded);
	}

	public async Task<TypedResponse<StageClassifications>> GetStageClassificationsByIdAsync(string id)
	{
		var stage = await _stages.GetStageByIdAsync(id);
		var classifications = new StageClassifications(stage);
		var stagePath = $"{_baseControllerUrl}/{stage.Id}";
		var links = new Dictionary<string, string>
		{
			{ "self", stagePath + "/classifications" },
			{ "index", stagePath },
			{ "stages", _baseControllerUrl }
		};
		return new TypedResponse<StageClassifications>(links, classifications);
	}
	public async Task<BaseResponseWithEmbed<StageClassificationsSetSummariesEmbed>> GetAllStageSetsAsync()
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
		return new BaseResponseWithEmbed<StageClassificationsSetSummariesEmbed>(links, embedded);
	}

	public async Task<TypedResponse<StageClassificationsSet>> GetStageSetByIdAsync(string id)
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
			classificationsTask = _stages.GetStagesByIdsAsync(stageSet.Stages);
				
		}
		var classifications = (await classificationsTask)
			.Select(classifications => new StageClassifications(classifications))
			.ToArray();
		var classificationsSet = new StageClassificationsSet(id, classifications);
		return new TypedResponse<StageClassificationsSet>(links, classificationsSet);
	}

	public async Task<BaseResponseWithEmbed<StagePieceMapSetSummariesEmbed>> GetAllStagePieceMapSetsAsync()
	{
		var summaries = (await _stagePieceMapSets.GetAllStagePieceMapSetsAsync()).Select(set => IdToIdSummarySetResponse(set.Id, "piece-maps")).ToArray();
		var embedded = new StagePieceMapSetSummariesEmbed(summaries);
		var links = new Dictionary<string, string> {
			{ "self", $"{_baseControllerUrl}/piece-maps" },
			{ "index", _baseControllerUrl }
		};

		return new BaseResponseWithEmbed<StagePieceMapSetSummariesEmbed>(links, embedded);
	}

  public async Task<TypedResponse<StagePieceMapSet>> GetStagePieceMapSetByIdAsync(string id)
	{
		var stagePieceMapSetPath = $"{_baseControllerUrl}/piece-maps";
		var links = new Dictionary<string, string> {
			{ "self", stagePieceMapSetPath + $"/{id}" },
			{ "index", stagePieceMapSetPath },
			{ "stages", _baseControllerUrl }
		};
		var stagePieceMapSetEntity = await _stagePieceMapSets.GetStagePieceMapSetByIdAsync(id);
		var stagePieceMapSet = new StagePieceMapSet(stagePieceMapSetEntity);
		return new TypedResponse<StagePieceMapSet>(links, stagePieceMapSet);
	}

	public async Task<BaseResponseWithEmbed<StageGameDatasetSummariesEmbed>> GetAllStageGameDatasetsAsync()
	{
		var summaries = (await _stageGameDatasets.GetAllStageGameDatasetsAsync()).Select(dataset => {
			var links = new Dictionary<string, string> {
				{
					"self", $"{_baseControllerUrl}/game-data/{dataset.Id}"
				}
			};
			var summary = new StageGameDatasetSummary(dataset.Id, dataset.Data[0].Name);
			return new TypedResponse<StageGameDatasetSummary>(links, summary);
		}).ToArray();
		var embedded = new StageGameDatasetSummariesEmbed(summaries);
		var links = new Dictionary<string, string> {
			{ "self", $"{_baseControllerUrl}/game-data" },
			{ "index", _baseControllerUrl }
		};
		return new BaseResponseWithEmbed<StageGameDatasetSummariesEmbed>(links, embedded);
	}

	private TypedResponse<IdSummary> IdToIdSummarySetResponse(string id, string path = "")
	{
		var embeddedLinks = new Dictionary<string, string> {
				{
					"self", $"{_baseControllerUrl}/{path}/{id}"
				}
			};
		return new TypedResponse<IdSummary>(embeddedLinks, new IdSummary(id));
	}
}
