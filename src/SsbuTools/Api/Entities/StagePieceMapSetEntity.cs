using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SsbuTools.Api.Models.Stage;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class StagePieceMapSetEntity: IStagePieceMapSet
{
	[BsonId]
	[BsonElement("_id")]
	public ObjectId DbId { get; set; }

	[BsonElement("id")]
	public string Id { get; set; } = "";

	[BsonElement("maps")]
	public StagePieceMap[] Maps { get; set; } = Array.Empty<StagePieceMap>();
}
