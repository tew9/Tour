namespace Tour.Domains.interfaces
{
  public interface IHeroDatabaseSetting
  {
    string HeroCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}