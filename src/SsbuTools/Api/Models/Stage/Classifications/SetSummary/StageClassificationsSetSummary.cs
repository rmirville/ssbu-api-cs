using System.Xml.Linq;

namespace SsbuTools.Api.Models.Stage;

public class StageClassificationsSetSummary : IStageClassificationsSetSummary
{
	public string Id { get; set; }
	public StageClassificationsSetSummary(string id)
	{
		Id = id;
	}
}
