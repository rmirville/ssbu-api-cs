using SsbuTools.Api.Models.Response;

namespace SsbuTools.Api.Models.Stage;

public record StageGameDatasetSummariesEmbed(TypedResponse<StageGameDatasetSummary>[] GameData);
