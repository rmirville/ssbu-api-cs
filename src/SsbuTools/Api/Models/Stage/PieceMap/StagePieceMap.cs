namespace SsbuTools.Api.Models.Stage;

public class StagePieceMap : IStagePieceMap
{
	public string Lvd { get; set; }
	public string PieceName { get; set; }
	public StagePieceMap(string lvd, string pieceName)
	{
		Lvd = lvd;
		PieceName = pieceName;
	}
}
