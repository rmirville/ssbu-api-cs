using System.Text.Json.Serialization;

namespace SsbuTools.Api.Models.Response;

public class BaseResponseWithEmbed<T> : BaseResponse
{
	[JsonPropertyName("_embedded")]
	public T Embedded { get; set; }
	
	public BaseResponseWithEmbed(Dictionary<string, string> links, T embedded) : base(links)
	{
		Embedded = embedded;
	}

}
