using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SsbuTools.Api.Models.Stage;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class StageGameDatasetEntity
{
	[BsonId]
	[BsonElement("_id")]
	public ObjectId DbId { get; set; }
	
	[BsonElement("id")]
	public string Id { get; set; } = "";

	[BsonElement("data")]
	public List<StageGameData> Data { get; set; } = new List<StageGameData>();
}
