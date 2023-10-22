using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Entities;

[BsonIgnoreExtraElements]
public class StageSetEntity : MongoEntity, IStageSet
{
	[BsonElement("stages")]
	public List<string> Stages { get; set; } = new List<string>();
}
