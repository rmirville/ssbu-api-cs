using Microsoft.Extensions.Options;
using SsbuTools.Api.Models.Response;
using SsbuTools.Api.Models.Stage;
using SsbuTools.Api.Options;
using SsbuTools.Core.Repositories;

namespace SsbuTools.Api.Services;

public class StagesService : IStagesService
{
	private BaseResponse _index;

	private readonly ApiOptions _config;
	private string _baseControllerUrl;
	private readonly string _path = "/v2/stages";
	private Dictionary<string, string> _indexLinks;
	private IStageClassificationsRepository _stages;

	public StagesService(IOptions<ApiOptions> config, IStageClassificationsRepository stages)
	{
		_stages = stages;
		_config = config.Value;
		_baseControllerUrl = _config.BaseUrl + _path;
		_indexLinks = new Dictionary<string, string> {
			{ "self", _baseControllerUrl },
			{ "classifications", _baseControllerUrl + "/classifications" },
			{ "gameData", _baseControllerUrl + "/game-data" },
			{ "pieceMaps", _baseControllerUrl + "/piece-maps" },
		};
		_index = new BaseResponse(_indexLinks);
	}

	public async Task<BaseResponseWithEmbed<StageSummariesEmbed>> GetAllStagesAsync()
	{
		var summaries = (await _stages.GetAllStagesAsync()).Select(stage =>
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
		var classifications = (await _stages.GetAllStagesAsync()).Select(stage =>
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
}