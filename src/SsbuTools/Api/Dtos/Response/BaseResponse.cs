using System.Text.Json.Serialization;

namespace SsbuTools.Api.Dtos.Response;

public class BaseResponse
{

  [JsonPropertyName("_links")]
  public Dictionary<string, object> Links { get; set; } = new Dictionary<string, object>();

  public BaseResponse(Dictionary<string, string> links)
  {
		Links = CreateLinks(links);
  }

	public static Dictionary<string, object> CreateLinks(Dictionary<string, string> links)
	{
		var linksDict = new Dictionary<string, object>();
		foreach (var link in links)
		{
			linksDict.Add(link.Key, new { href = link.Value });
		}
		return linksDict;
	}
}
