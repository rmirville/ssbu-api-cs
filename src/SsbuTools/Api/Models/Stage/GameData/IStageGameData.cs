namespace SsbuTools.Api.Models.Stage;

public interface IStageGameData
{
	string Stage { get; set; }
	string Name { get; set; }
	string Lvd { get; set; }
	List<object> Collisions { get; set; }
	List<object> Platforms { get; set; }
	List<object> BlastZones { get; set; }
	List<object> Camera { get; set; }
	List<object> Center { get; set; }
	List<object> Spawns { get; set; }
	List<object> Respawns { get; set; }
	List<object> Items { get; set; }
}
