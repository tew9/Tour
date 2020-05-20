using Tour.Domains.interfaces;

namespace Tour.Domains.Models
{
  public class HeroDatabaseSetting: IHeroDatabaseSetting
  {
    public string HeroCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }
}