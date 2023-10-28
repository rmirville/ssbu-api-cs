using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class StageGameDatasetEntity : MongoEntity, IStageGameDataset
{
	[BsonElement("data")]
	public List<MongoStageGameData> Data { get; set; } = new List<MongoStageGameData>();
}
