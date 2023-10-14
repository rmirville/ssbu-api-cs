using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class MongoEntity
{
	[BsonId]
	[BsonElement("_id")]
	public ObjectId DbId { get; set; }

	[BsonElement("id")]
	public string Id { get; set; } = "";
}
