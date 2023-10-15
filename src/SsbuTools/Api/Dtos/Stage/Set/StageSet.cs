namespace SsbuTools.Api.Dtos.Stage;

public class StageSet : IStageSet
{
	public string Id { get; set; }
	public string[] Stages { get; set; }

	public StageSet(string id, string[] stages)
	{
		Id = id;
		Stages = stages;
	}

	public StageSet(IStageSet stageSet)
	{
		Id = stageSet.Id;
		Stages = stageSet.Stages;
	}
}
