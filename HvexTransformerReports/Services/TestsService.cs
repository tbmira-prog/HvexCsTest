using HvexTransformerReports.Data;
using HvexTransformerReports.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HvexTransformerReports.Services
{
    public class TestsService
    {
        private readonly IMongoCollection<Test> _testsCollection;

        public TestsService(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            // _testsCollection = mongoDatabase.GetCollection<Test>(
            //    databaseSettings.Value.TestsCollectionName);
        }

        public async Task<List<Test>> GetAsync() =>
            await _testsCollection.Find(_ => true).ToListAsync();

        public async Task<Test?> GetAsync(string id) =>
            await _testsCollection.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Test newTest) =>
            await _testsCollection.InsertOneAsync(newTest);

        public async Task UpdateAsync(string id, Test updatedTest) =>
            await _testsCollection.ReplaceOneAsync(x => x.Id.ToString() == id, updatedTest);

        public async Task RemoveAsync(string id) =>
            await _testsCollection.DeleteOneAsync(x => x.Id.ToString() == id);
    }
}