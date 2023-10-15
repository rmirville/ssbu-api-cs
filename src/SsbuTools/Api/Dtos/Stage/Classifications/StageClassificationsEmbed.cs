using SsbuTools.Api.Dtos.Response;

namespace SsbuTools.Api.Dtos.Stage;

public record StageClassificationsEmbed(TypedResponse<StageClassifications>[] Stages);
