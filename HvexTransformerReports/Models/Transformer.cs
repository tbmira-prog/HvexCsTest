using MongoDB.Bson;
using Realms;

namespace HvexTransformerReports.Models
{
    public class Transformer : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; init; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        public string Name { get; init; } = null!;

        [MapTo("internal_number")]
        public int InternalNumber { get; init; }

        [MapTo("tension_class")]
        public string TensionClass { get; init; } = null!;

        [MapTo("potency")]
        public string Potency { get; init; } = null!;

        [MapTo("current")]
        public string Current { get; init; } = null!;

        public IList<Test> Tests { get; }

        public Transformer()
        {
            this.Tests = new List<Test>();
        }
    }
}
