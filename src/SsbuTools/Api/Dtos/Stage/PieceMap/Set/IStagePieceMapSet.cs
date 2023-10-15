namespace SsbuTools.Api.Dtos.Stage;

public interface IStagePieceMapSet
{
	string Id { get; set; }
	StagePieceMap[] Maps { get; set; }
}
