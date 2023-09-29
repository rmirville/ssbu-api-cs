namespace SsbuTools.Api.Models.Stage;

public interface IStageClassifications : IStageSummary
{
	public string Abbr { get; set; }
	public string Series { get; set; }
	public int TourneyPresence { get; set; }
}
