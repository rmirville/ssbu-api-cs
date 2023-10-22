using Microsoft.AspNetCore.Mvc;
using SsbuTools.Api.Dtos.Resource;

namespace SsbuTools.Api.Responses;

public interface IRestResponse<TResource> where TResource : BaseRestResource
{
	TResource Resource { get; init; }
	JsonResult ToJsonResult();
}
