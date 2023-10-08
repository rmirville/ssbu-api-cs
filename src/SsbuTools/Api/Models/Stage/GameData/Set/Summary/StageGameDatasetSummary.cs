namespace SsbuTools.Api.Models.Stage;

public class StageGameDatasetSummary
{
	public string Id { get; set; }
	public string Name { get; set; }

	public StageGameDatasetSummary(string id, string name)
	{
		Id = id;
		Name = name;
	}

	public StageGameDatasetSummary(IStageGameDatasetSummary summary)
	{
		Id = summary.Id;
		Name = summary.Name;
	}
}
