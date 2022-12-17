using MongoDB.Bson;
using Realms;

namespace HvexTransformerReports.Models
{
    public class Test : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        public string Name { get; set; } = null!;

        [MapTo("status")]
        public string Status { get; set; } = null!;

        [MapTo("duration_in_seconds")]
        public float DurationInSeconds { get; set; }
    }
}
