using HvexTransformerReports.Data;
using HvexTransformerReports.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HvexTransformerReports.Services
{
    public class ReportsService
    {
        private readonly IMongoCollection<Report> _reportsCollection;

        public ReportsService(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            // _reportsCollection = mongoDatabase.GetCollection<Report>(
            //    databaseSettings.Value.ReportsCollectionName);
        }

        public async Task<List<Report>> GetAsync() =>
            await _reportsCollection.Find(_ => true).ToListAsync();

        public async Task<Report?> GetAsync(string id) =>
            await _reportsCollection.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Report newReport) =>
            await _reportsCollection.InsertOneAsync(newReport);

        public async Task UpdateAsync(string id, Report updatedReport) =>
            await _reportsCollection.ReplaceOneAsync(x => x.Id.ToString() == id, updatedReport);

        public async Task RemoveAsync(string id) =>
            await _reportsCollection.DeleteOneAsync(x => x.Id.ToString() == id);
    }
}