namespace SsbuTools.Api.Dtos.Stage;

public class StagePieceMapSet : IStagePieceMapSet
{
	public string Id { get; set; }
	public StagePieceMap[] Maps { get; set; }

	public StagePieceMapSet(string id, StagePieceMap[] maps)
	{
		Id = id;
		Maps = maps;
	}
	public StagePieceMapSet(IStagePieceMapSet stagePieceMapSet)
	{
		Id = stagePieceMapSet.Id;
		Maps = stagePieceMapSet.Maps;
	}
}
