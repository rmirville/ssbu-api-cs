namespace SsbuTools.Api.Dtos.Stage;

public interface IStageClassificationsSet
{
	string Id { get; set; }
	Dictionary<string, StageClassifications> Classifications { get; set; }
}
