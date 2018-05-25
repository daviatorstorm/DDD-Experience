using Domain.Aggregates;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Domain.Models
{
    public class MongoContext
    {
        private readonly IMongoDatabase database;
        public MongoContext(IOptions<MongoConnection> options)
        {
            var opts = options.Value;
            var client = new MongoClient(opts.ConnectionString);
            if (client != null)
                database = client.GetDatabase(opts.Database);
        }

        public IMongoCollection<Group> Groups
        {
            get
            {
                return database.GetCollection<Group>(nameof(Group));
            }
        }

        public IMongoCollection<Retailer> Retailers
        {
            get
            {
                return database.GetCollection<Retailer>(nameof(Group));
            }
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return database.GetCollection<T>(nameof(T));
        }
    }
}