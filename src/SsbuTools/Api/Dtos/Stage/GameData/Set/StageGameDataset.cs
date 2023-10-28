using SsbuTools.Api.Entities;

namespace SsbuTools.Api.Dtos.Stage;

public class StageGameDataset : IStageGameDataset
{
	public string Id { get; set; }
	public List<MongoStageGameData> Data { get; set; }

	public StageGameDataset(string id, List<MongoStageGameData> data)
	{
		Id = id;
		Data = data;
	}

	public StageGameDataset(IStageGameDataset dataset)
	{
		Id = dataset.Id;
		Data = dataset.Data;
	}
}
