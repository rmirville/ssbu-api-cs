using Microsoft.Extensions.Options;
using SsbuTools.Api.Options;
using SsbuTools.Api.Models.Response;

namespace SsbuTools.Api.Services;

public class IndexService : IIndexService
{
	private BaseResponse _index;
	private readonly ApiOptions _config;
	private string _baseUrl;
	private readonly string _path = "/v2";
	private Dictionary<string, string> _links;

	public IndexService(IOptions<ApiOptions> config)
	{
		_config = config.Value;
		_baseUrl = _config.BaseUrl;
		_links = new Dictionary<string, string> {
			{ "self", _baseUrl + _path },
			{ "stages", _baseUrl + _path + "/stages" },
			{ "docs", _baseUrl + "/swagger" }
		};
		_index = new BaseResponse(_links);
	}

	public BaseResponse GetIndex()
	{
		return this._index;
	}
}
