using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;

namespace SsbuTools.Api.Responses;

public class ErrorResponse : IRestResponse<BaseRestResourceWithError<object>>
{
	public BaseRestResourceWithError<object> Resource { get; init; }

	public ErrorResponse(object problem, string baseRedirectUrl)
	{
		var links = new Dictionary<string, string> {
			{ "index", baseRedirectUrl }
		};
		Resource = new BaseRestResourceWithError<object>(links, problem);
	}

	public JsonResult ToJsonResult() => new JsonResult(Resource);
}
