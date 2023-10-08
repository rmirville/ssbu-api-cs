namespace SsbuTools.Api.Models.Stage;

public class StageGameData : IStageGameData
{
	public string Stage { get; set; }
	public string Name { get; set; }
	public string Lvd { get; set; }

	public StageGameData(string stage, string name, string lvd)
	{
		Stage = stage;
		Name = name;
		Lvd = lvd;
	}

	public StageGameData(IStageGameData data)
	{
		Stage = data.Stage;
		Name = data.Name;
		Lvd = data.Lvd;
	}
}
