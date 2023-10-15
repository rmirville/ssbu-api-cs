using SsbuTools.Api.Dtos.Resource;

namespace SsbuTools.Api.Dtos.Stage;

public record StageClassificationsSetSummariesEmbed(RestResource<IdSummary>[] ClassificationSets);
