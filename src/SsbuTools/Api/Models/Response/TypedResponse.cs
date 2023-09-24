namespace SsbuTools.Api.Models.Response;

public class TypedResponse<T> : BaseResponse
{
  public T Result { get; set; }
  public TypedResponse(Dictionary<string, string> links, T result) : base(links)
  {
	Result = result;
  }
}
