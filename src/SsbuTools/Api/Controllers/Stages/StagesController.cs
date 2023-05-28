/*  using Microsoft.AspNetCore.Mvc;

using SsbuTools.Api.Models.Response;
using SsbuTools.Core.Repositories;

namespace SsbuTools.Api.Controllers;

[ApiController]
[Route("v1")]
[Produces("application/json")]
public class StagesController : ControllerBase {

	private IStageRepository Stages;

	public StagesController(IStageRepository stages) {
		Stages = stages;
	}

	[HttpGet(Name = "StageIndex")]
	public ResponseModel Get() {
		return Stages.GetIndex();
	}
}
 */