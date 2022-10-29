using Newtonsoft.Json;

namespace SsbuTools.Api.Models.Response;

[JsonObject]
public class ResponseModel {

	[JsonProperty]
	public Dictionary<string, object>? _links { get; set; } = new Dictionary<string, object>();

	public ResponseModel(Dictionary<string, string> links) {
		foreach (KeyValuePair<string, string> link in links) {
			this._links.Add(link.Key, new {href = link.Value});
		}
	}
}
