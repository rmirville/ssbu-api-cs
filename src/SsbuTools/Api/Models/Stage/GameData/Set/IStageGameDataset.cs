namespace SsbuTools.Api.Models.Stage;

public interface IStageGameDataset
{
	string Id { get; set; }
	string Name { get; set; }
	List<StageGameData> Data { get; set;}
}
