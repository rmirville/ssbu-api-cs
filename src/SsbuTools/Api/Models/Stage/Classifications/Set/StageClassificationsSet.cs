namespace SsbuTools.Api.Models.Stage.Classifications.Set;

public class StageClassificationsSet : IStageClassificationsSet
{
	public string Id { get; set; }
	public StageClassifications[] Classifications { get; set; }
	public StageClassificationsSet(string id, StageClassifications[] classifications)
	{
		Id = id;
		Classifications = classifications;
	}
}
