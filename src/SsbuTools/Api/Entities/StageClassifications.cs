using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class StageClassifications
{
	[BsonId]
	[BsonElement("_id")]
	public ObjectId DbId { get; set; }

	[BsonElement("id")]
	public string Id { get; set; }

	[BsonElement("abbr")]
	public string Abbr { get; set; }

	[BsonElement("gameName")]
	public string GameName { get; set; }

	[BsonElement("name")]
	public string Name { get; set; }

	[BsonElement("series")]
	public string Series { get; set; }

	[BsonElement("tourneyPresence")]
	public int TourneyPresence { get; set; }
}
