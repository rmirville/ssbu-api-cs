using SsbuTools.Api.Models.Response;

namespace SsbuTools.Api.Models.Stage;

public record StagePieceMapSetSummariesEmbed(TypedResponse<IdSummary>[] PieceMaps);