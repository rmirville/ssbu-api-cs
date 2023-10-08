namespace SsbuTools.Api.Models.Stage;

public interface IStagePieceMapSet
{
	string Id { get; set; }
	StagePieceMap[] Maps { get; set; }
}
