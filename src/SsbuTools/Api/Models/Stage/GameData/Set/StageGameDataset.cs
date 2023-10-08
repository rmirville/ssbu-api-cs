namespace SsbuTools.Api.Models.Stage;

public class StageGameDataset : IStageGameDataset
{
	public string Id { get; set; }
	public string Name { get; set; }
	public List<StageGameData> Data { get; set; }

	public StageGameDataset(string id, string name, List<StageGameData> data)
	{
		Id = id;
		Name = name;
		Data = data;
	}

	public StageGameDataset(IStageGameDataset dataset)
	{
		Id = dataset.Id;
		Name = dataset.Name;
		Data = dataset.Data;
	}
}
