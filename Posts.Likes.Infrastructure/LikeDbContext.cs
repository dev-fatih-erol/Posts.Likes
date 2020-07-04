using MongoDB.Driver;
using Posts.Likes.Infrastructure.Configurations;
using Posts.Likes.Infrastructure.Entities;

namespace Posts.Likes.Infrastructure
{
    public class LikeDbContext
    {
        private readonly IMongoDatabase _database;

        public LikeDbContext(IMongoConfiguration configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);

            _database = client.GetDatabase(MongoUrl.Create(configuration.ConnectionString).DatabaseName);
        }

        public IMongoCollection<Like> Likes => _database.GetCollection<Like>(nameof(Like));
    }
}