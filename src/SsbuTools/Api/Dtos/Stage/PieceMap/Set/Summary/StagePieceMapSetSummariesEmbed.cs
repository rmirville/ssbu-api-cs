using SsbuTools.Api.Dtos.Response;

namespace SsbuTools.Api.Dtos.Stage;

public record StagePieceMapSetSummariesEmbed(TypedResponse<IdSummary>[] PieceMaps);
