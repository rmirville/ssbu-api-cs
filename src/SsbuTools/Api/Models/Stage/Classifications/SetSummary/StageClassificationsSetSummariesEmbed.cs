using SsbuTools.Api.Models.Response;

namespace SsbuTools.Api.Models.Stage;

public record StageClassificationsSetSummariesEmbed(TypedResponse<StageClassificationsSetSummary>[] ClassificationSets);
