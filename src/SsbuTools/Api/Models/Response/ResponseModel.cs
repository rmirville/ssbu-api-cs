using System.Text.Json.Serialization;

namespace SsbuTools.Api.Models.Response;

public class ResponseModel
{

  [JsonPropertyName("_links")]
  public Dictionary<string, object>? Links { get; set; } = new Dictionary<string, object>();

  public ResponseModel(Dictionary<string, string> links)
  {
	foreach (var link in links)
	{
	  Links.Add(link.Key, new { href = link.Value });
	}
  }
}
