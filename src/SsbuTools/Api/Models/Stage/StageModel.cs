namespace SsbuTools.Api.Models.Stage;

public class StageModel
{
  public record StageSummary
  {
	public string Id { get; set; }
	public string GameName { get; set; }
	public string Name { get; set; }
  }
}
