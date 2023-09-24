using SsbuTools.Api.Models.Response;

namespace SsbuTools.Api.Models.Stage;

public record StageSummariesEmbed(TypedResponse<StageSummary>[] Stages);
