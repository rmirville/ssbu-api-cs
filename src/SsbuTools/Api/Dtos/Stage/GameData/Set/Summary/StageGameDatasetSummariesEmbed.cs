using SsbuTools.Api.Dtos.Response;

namespace SsbuTools.Api.Dtos.Stage;

public record StageGameDatasetSummariesEmbed(RestResource<StageGameDatasetSummary>[] GameData);
