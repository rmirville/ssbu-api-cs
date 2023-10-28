using MongoDB.Bson.Serialization.Attributes;
using SsbuTools.Api.Dtos.Stage;

namespace SsbuTools.Api.Entities;

public class MongoStageGameData : IStageGameData
{
	[BsonElement("stage")]
	public string Stage { get; set; }

	[BsonElement("name")]
	public string Name { get; set; }

	[BsonElement("lvd")]
	public string Lvd { get; set; }

	[BsonElement("collisions")]
	public List<object> Collisions { get; set; } = new List<object>();

	[BsonElement("platforms")]
	public List<object> Platforms	{ get; set; } = new List<object>();

	[BsonElement("blast_zones")]
	public List<object> BlastZones { get; set; } = new List<object>();

	[BsonElement("camera")]
	public List<object> Camera { get; set; } = new List<object>();

	[BsonElement("center")]
	public List<object> Center { get; set; } = new List<object>();

	[BsonElement("spawns")]
	public List<object> Spawns { get; set; } = new List<object>();

	[BsonElement("respawns")]
	public List<object> Respawns { get; set; } = new List<object>();

	[BsonElement("items")]
	public List<object> Items	{ get; set; } = new List<object>();

	public MongoStageGameData(
		string stage,
		string name,
		string lvd, List<object> collisions,
		List<object> platforms,
		List<object> blastZones,
		List<object> camera,
		List<object> center,
		List<object> spawns,
		List<object> respawns,
		List<object> items
	)
	{
		Stage = stage;
		Name = name;
		Lvd = lvd;
		Collisions = collisions;
		Platforms = platforms;
		BlastZones = blastZones;
		Camera = camera;
		Center = center;
		Spawns = spawns;
		Respawns = respawns;
		Items = items;
	}

	public MongoStageGameData(IStageGameData data)
	{
		Stage = data.Stage;
		Name = data.Name;
		Lvd = data.Lvd;
		Collisions = data.Collisions;
		Platforms = data.Platforms;
		BlastZones = data.BlastZones;
		Camera = data.Camera;
		Center = data.Center;
		Spawns = data.Spawns;
		Respawns = data.Respawns;
		Items = data.Items;
	}
}
