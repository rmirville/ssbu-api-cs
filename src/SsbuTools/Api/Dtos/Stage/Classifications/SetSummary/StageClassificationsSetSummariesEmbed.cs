using SsbuTools.Api.Dtos.Response;

namespace SsbuTools.Api.Dtos.Stage;

public record StageClassificationsSetSummariesEmbed(RestResource<IdSummary>[] ClassificationSets);
