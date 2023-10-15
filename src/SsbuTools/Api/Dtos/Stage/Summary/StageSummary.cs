namespace SsbuTools.Api.Dtos.Stage;

public class StageSummary
{
	public string Id { get; set; }
	public string GameName { get; set; }
	public string Name { get; set; }
	public StageSummary(string id, string gameName, string name)
	{
		Id = id;
		GameName = gameName;
		Name = name;
	}
	public StageSummary(IStageSummary stage)
	{
		Id = stage.Id;
		GameName = stage.GameName;
		Name = stage.Name;
	}
}
