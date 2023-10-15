namespace SsbuTools.Api.Dtos.Stage;

public class StageClassificationsSet : IStageClassificationsSet
{
	public string Id { get; set; }
	public Dictionary<string, StageClassifications> Classifications { get; set; }
	public StageClassificationsSet(string id, StageClassifications[] classificationsArray)
	{
		Id = id;
		var classifications = new Dictionary<string, StageClassifications>();
		foreach (StageClassifications classificationsItem in classificationsArray)
		{
			classifications.Add(classificationsItem.Id, classificationsItem);
		}
		Classifications = classifications;
	}
}
