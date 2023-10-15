using SsbuTools.Api.Dtos.Response;

namespace SsbuTools.Api.Dtos.Stage;

public record StageGameDatasetSummariesEmbed(TypedResponse<StageGameDatasetSummary>[] GameData);
