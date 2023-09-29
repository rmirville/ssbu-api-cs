namespace SsbuTools.Api.Models.Stage;

public interface IStageClassificationsSet
{
	string Id { get; set; }
	IStageClassifications[] Classifications { get; set; }
}
