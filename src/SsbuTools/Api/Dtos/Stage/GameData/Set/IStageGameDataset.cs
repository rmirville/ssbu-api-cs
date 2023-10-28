using SsbuTools.Api.Entities;

namespace SsbuTools.Api.Dtos.Stage;

public interface IStageGameDataset
{
	string Id { get; set; }
	List<MongoStageGameData> Data { get; set;}
}
