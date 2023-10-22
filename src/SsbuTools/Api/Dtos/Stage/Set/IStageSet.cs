namespace SsbuTools.Api.Dtos.Stage;

public interface IStageSet
{
  string Id { get; set; }
  List<string> Stages { get; set; }
}
