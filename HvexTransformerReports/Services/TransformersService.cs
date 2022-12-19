using HvexTransformerReports.Data;
using HvexTransformerReports.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HvexTransformerReports.Services
{
    public class TransformersService
    {
        private readonly IMongoCollection<Transformer> _transformersCollection;

        public TransformersService(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

             _transformersCollection = mongoDatabase.GetCollection<Transformer>(
                databaseSettings.Value.CollectionName);
        }

        public async Task<List<Transformer>> GetAsync() =>
            await _transformersCollection.Find(_ => true).ToListAsync();

        public async Task<Transformer?> GetAsync(string id) =>
            await _transformersCollection.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Transformer newTransformer) =>
            await _transformersCollection.InsertOneAsync(newTransformer);

        public async Task UpdateAsync(string id, Transformer updatedTransformer) =>
            await _transformersCollection.ReplaceOneAsync(x => x.Id.ToString() == id, updatedTransformer);

        public async Task RemoveAsync(string id) =>
            await _transformersCollection.DeleteOneAsync(x => x.Id.ToString() == id);
    }
}