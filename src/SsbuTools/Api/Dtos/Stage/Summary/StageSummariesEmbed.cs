using SsbuTools.Api.Dtos.Response;

namespace SsbuTools.Api.Dtos.Stage;

public record StageSummariesEmbed(TypedResponse<StageSummary>[] Stages);
