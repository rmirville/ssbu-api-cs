using SsbuTools.Api.Models.Response;

namespace SsbuTools.Api.Models.Stage;

public record StageClassificationsEmbed(TypedResponse<StageClassifications>[] Stages);
