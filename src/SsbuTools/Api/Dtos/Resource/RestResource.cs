namespace SsbuTools.Api.Dtos.Resource;

public class RestResource<T> : BaseRestResource
{
  public T Result { get; set; }
  public RestResource(Dictionary<string, string> links, T result) : base(links)
  {
	Result = result;
  }
}
