using SsbuTools.Api.Dtos.Resource;

namespace SsbuTools.Api.Dtos.Stage;

public record StageSummariesEmbed(RestResource<StageSummary>[] Stages);
