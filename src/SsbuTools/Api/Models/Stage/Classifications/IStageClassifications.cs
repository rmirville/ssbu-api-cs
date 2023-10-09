namespace SsbuTools.Api.Models.Stage;

public interface IStageClassifications : IStageSummary
{
	public string Abbr { get; set; }
	public string Series { get; set; }
	public TourneyPresence TourneyPresence { get; set; }
}

public enum TourneyPresence
{
	Unknown = 0,
	CommonlyLegal = 1,
	UncommonlyLegal = 2,
	RarelyLegal = 3,
	PotentiallyLegal = 4,
}
