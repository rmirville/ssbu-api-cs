using System.Text.Json.Serialization;

namespace SsbuTools.Api.Dtos.Resource;

public class BaseRestResourceWithEmbed<T> : BaseRestResource
{
	[JsonPropertyName("_embedded")]
	public T Embedded { get; set; }
	
	public BaseRestResourceWithEmbed(Dictionary<string, string> links, T embedded) : base(links)
	{
		Embedded = embedded;
	}
}
