namespace PubgTournament.Helpers
{
   public interface IAppSettings
{
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
}

public class AppSettings : IAppSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
}
}