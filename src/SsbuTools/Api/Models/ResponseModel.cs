using System.Text.Json.Serialization;

namespace SsbuTools.Api.Models;

public class ResponseModel {

	[JsonPropertyName("_links")]
	public Dictionary<string, object>? Links { get; set; } = new Dictionary<string, object>();

	public ResponseModel(Dictionary<string, string> links) {
		foreach (KeyValuePair<string, string> link in links) {
			this.Links.Add(link.Key, new {href = link.Value});
		}
	}
}
