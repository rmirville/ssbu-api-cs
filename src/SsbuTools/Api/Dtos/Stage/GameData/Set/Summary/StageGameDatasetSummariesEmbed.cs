using SsbuTools.Api.Dtos.Resource;

namespace SsbuTools.Api.Dtos.Stage;

public record StageGameDatasetSummariesEmbed(RestResource<StageGameDatasetSummary>[] GameData);
