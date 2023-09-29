namespace SsbuTools.Api.Models.Stage;

public class StageClassifications : StageSummary, IStageClassifications
{
	public string Abbr { get; set; }
	public string Series { get; set; }
	public int TourneyPresence { get; set; }
	public StageClassifications(string id, string gameName, string name, string abbr, string series, int tourneyPresence) : base (id, gameName, name)
	{
		Abbr = abbr;
		Series = series;
		TourneyPresence = tourneyPresence;
	}
	public StageClassifications(IStageClassifications stage) : base(stage)
	{
		Abbr = stage.Abbr;
		Series = stage.Series;
		TourneyPresence = stage.TourneyPresence;
	}
}
