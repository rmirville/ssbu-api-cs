using System.Text.Json.Serialization;

namespace SsbuTools.Api.Dtos.Resource;

public class BaseRestResourceWithError<T> : BaseRestResource
{
	[JsonPropertyName("error")]
	public T Error { get; set; }
	
	public BaseRestResourceWithError(Dictionary<string, string> links, T error) : base(links)
	{
		Error = error;
	}
}
