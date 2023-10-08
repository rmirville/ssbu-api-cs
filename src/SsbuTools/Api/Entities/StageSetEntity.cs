using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SsbuTools.Api.Models.Stage;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class StageSetEntity: IStageSet
{
	[BsonId]
	[BsonElement("_id")]
	public ObjectId DbId { get; set; }

	[BsonElement("id")]
	public string Id { get; set; } = "";

	[BsonElement("stages")]
	public string[] Stages { get; set; } = new string[] { };
}
