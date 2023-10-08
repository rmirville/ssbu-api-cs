using MongoDB.Bson.Serialization.Attributes;

namespace SsbuTools.Api.Models.Stage;

public class StageGameData : IStageGameData
{
	[BsonElement("stage")]
	public string Stage { get; set; }

	[BsonElement("name")]
	public string Name { get; set; }

	[BsonElement("lvd")]
	public string Lvd { get; set; }

	[BsonElement("collisions")]
	public List<object> Collisions { get; set; }

	[BsonElement("platforms")]
	public List<object> Platforms	{ get; set; }

	[BsonElement("blast_zones")]
	public List<object> BlastZones { get; set; }

	[BsonElement("camera")]
	public List<object> Camera { get; set; }

	[BsonElement("center")]
	public List<object> Center { get; set; }

	[BsonElement("spawns")]
	public List<object> Spawns { get; set; }

	[BsonElement("respawns")]
	public List<object> Respawns { get; set; }

	[BsonElement("items")]
	public List<object> Items	{ get; set; }

	public StageGameData(string stage, string name, string lvd)
	{
		Stage = stage;
		Name = name;
		Lvd = lvd;
	}

	public StageGameData(IStageGameData data)
	{
		Stage = data.Stage;
		Name = data.Name;
		Lvd = data.Lvd;
	}
}
