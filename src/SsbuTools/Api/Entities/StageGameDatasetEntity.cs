using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SsbuTools.Api.Models.Stage;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class StageGameDatasetEntity : MongoEntity
{
	[BsonElement("data")]
	public List<StageGameData> Data { get; set; } = new List<StageGameData>();
}
