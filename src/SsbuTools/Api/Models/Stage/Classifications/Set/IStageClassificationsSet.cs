namespace SsbuTools.Api.Models.Stage;

public interface IStageClassificationsSet
{
	string Id { get; set; }
	StageClassifications[] Classifications { get; set; }
}
