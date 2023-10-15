using SsbuTools.Api.Dtos.Response;

namespace SsbuTools.Api.Dtos.Stage;

public record StageSummariesEmbed(RestResource<StageSummary>[] Stages);
