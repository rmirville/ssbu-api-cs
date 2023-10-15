using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Response;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Resources;

public class StageSummaryResource
{
	private string _baseUrl;
	private Dictionary<string, string> _links;
	private IStageClassifications _entity;
	private RestResource<StageSummary> _summaryResponse;
	public StageSummaryResource(StageClassifications entity, string baseUrl)
	{
		_entity = entity;
		_baseUrl = baseUrl;
		var stageUrl = $"{_baseUrl}/{_entity.Id}";
		_links = new Dictionary<string, string>
		{
			{"index", $"{_baseUrl}/classifications"},
			{"stage", stageUrl},
			{"self", $"{stageUrl}/classifications"},
			{"gameData", $"{stageUrl}/game-data"}
		};
		
		var summary = new StageSummary(entity.Id, entity.Name, entity.GameName);
		_summaryResponse = new RestResource<StageSummary>(_links, summary);
	}
	public JsonResult ToJsonResult()
	{
		return new JsonResult(_summaryResponse);
	}
}
