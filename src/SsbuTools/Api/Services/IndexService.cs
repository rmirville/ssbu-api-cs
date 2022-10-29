using SsbuTools.Api.Config;
using SsbuTools.Api.Models.Response;

namespace SsbuTools.Api.Services;

public class IndexService : IIndexService {
	private ResponseModel _index;

	private readonly string _path = "v1";
	private string BaseUrl;

	private Dictionary<string, string> _links;

	public IndexService(ApiConfig config) {
		BaseUrl = config.BaseUrl;
		_links = new Dictionary<string, string> {
		{ "self", BaseUrl + _path },
		{ "stages", BaseUrl + _path + "/stages" },
		{ "docs", BaseUrl + "swagger" }
	};
		_index = new ResponseModel(_links);
	}

	public ResponseModel GetIndex() {
		return this._index;
	}
}
