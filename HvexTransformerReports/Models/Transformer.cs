using MongoDB.Bson;
using Realms;

namespace HvexTransformerReports.Models
{
    public class Transformer : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        public string Name { get; set; } = null!;

        [MapTo("internal_number")]
        [Required]
        public int InternalNumber { get; set; }

        [MapTo("tension_class")]
        public string TensionClass { get; set; } = null!;

        [MapTo("potency")]
        public string Potency { get; set; } = null!;

        [MapTo("current")]
        public string Current { get; set; } = null!;

        public IList<Test> Tests { get; } = null!;
    }
}
