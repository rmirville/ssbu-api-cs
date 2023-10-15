using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class StagePieceMapSetEntity : MongoEntity, IStagePieceMapSet
{
	[BsonElement("maps")]
	public StagePieceMap[] Maps { get; set; } = Array.Empty<StagePieceMap>();
}
