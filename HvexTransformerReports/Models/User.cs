using MongoDB.Bson;
using Realms;

namespace HvexTransformerReports.Models
{
    public class User : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        [Required]
        public string Name { get; set; }

        [MapTo("email")]
        [Required]
        public string Email { get; set; }

        public IList<Transformer> Transformers { get; } = null!;
    }
}
