using System.Text.Json.Serialization;

namespace SsbuTools.Api.Dtos.Response;

public class BaseRestResource
{

  [JsonPropertyName("_links")]
  public Dictionary<string, object> Links { get; set; } = new Dictionary<string, object>();

  public BaseRestResource(Dictionary<string, string> links)
  {
		Links = CreateLinks(links);
  }

	private static Dictionary<string, object> CreateLinks(Dictionary<string, string> links)
	{
		var linksDict = new Dictionary<string, object>();
		foreach (var link in links)
		{
			linksDict.Add(link.Key, new { href = link.Value });
		}
		return linksDict;
	}
}
