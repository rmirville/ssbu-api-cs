using SsbuTools.Api.Config;
using SsbuTools.Api.Models;

namespace SsbuTools.Api.Services;

public class IndexService : IIndexService
{
	private ResponseModel _index;

	private readonly string _path = "v1";
	private string _baseUrl;

	private Dictionary<string, string> _links;

	public IndexService(ApiConfig config)
	{
		_baseUrl = config.BaseUrl;
		_links = new Dictionary<string, string> {
		{ "self", _baseUrl + _path },
		{ "stages", _baseUrl + _path + "/stages" },
		{ "docs", _baseUrl + "swagger" }
	};
		_index = new ResponseModel(_links);
	}

	public ResponseModel GetIndex()
	{
		return this._index;
	}
}
