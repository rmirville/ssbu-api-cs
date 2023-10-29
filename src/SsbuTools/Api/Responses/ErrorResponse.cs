using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;

namespace SsbuTools.Api.Responses;

public class ErrorResponse : IRestResponse<BaseRestResourceWithError<object>>
{
	public BaseRestResourceWithError<object> Resource { get; init; }

	public ErrorResponse(object problem)
	{
		var links = new Dictionary<string, string>() {};
		Resource = new BaseRestResourceWithError<object>(new Dictionary<string, string>(), problem);
	}

	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
