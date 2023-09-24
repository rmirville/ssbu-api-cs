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
	private string _baseUrl;
	private readonly string _path = "/v2/stages";
	private Dictionary<string, string> _indexLinks;
	private IStageClassificationsRepository _stages;

	public StagesService(IOptions<ApiOptions> config, IStageClassificationsRepository stages)
	{
		_stages = stages;
		_config = config.Value;
		_baseUrl = _config.BaseUrl + _path;
		_indexLinks = new Dictionary<string, string> {
			{ "self", _baseUrl },
			{ "classifications", _baseUrl + "/classifications" },
			{ "gameData", _baseUrl + "/game-data" },
			{ "pieceMaps", _baseUrl + "/piece-maps" },
		};
		_index = new BaseResponse(_indexLinks);
	}

	public async Task<BaseResponseWithEmbed<StageSummariesEmbed>> GetAllStagesAsync()
	{
		var summaries = (await _stages.GetAllStagesAsync()).Select(stage =>
		{
			var links = new Dictionary<string, string> {
				{
					"self", $"{_baseUrl}/{stage.Id}"
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
		var stagePath = $"{_baseUrl}/{stage.Id}";
		var links = new Dictionary<string, string>
		{
			{ "self", stagePath },
			{ "index", _baseUrl },
			{ "classifications", stagePath + "/classifications" },
			{ "gameData", stagePath + "/game-data" }
		};
		return new TypedResponse<StageSummary>(links, summary);
	}
}
