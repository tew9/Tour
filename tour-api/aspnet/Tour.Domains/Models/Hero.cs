using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tour.Domains.Models {
  public class Hero
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }
  }
}