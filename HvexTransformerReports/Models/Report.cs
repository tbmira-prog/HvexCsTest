using MongoDB.Bson;
using Realms;

namespace HvexTransformerReports.Models
{
    public class Report : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        public string Name { get; set; } = null!;

        [MapTo("status")]
        [Required]
        public string Status { get; set; }

        public IList<Transformer> Transformers { get; }

        public Test Test { get; set; }
    }
}
