using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Posts.Likes.Infrastructure.Entities;

namespace Posts.Likes.Infrastructure.Services
{
    public class LikeService : ILikeService
    {
        private readonly LikeDbContext _dbContext;

        public LikeService(LikeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Exists(int userId, string postId)
        {
            return await _dbContext.Likes.Find(l => l.User.Id == userId && l.PostId == postId).AnyAsync();
        }

        public IMongoQueryable<Like> GetLikes(string postId)
        {
            return _dbContext.Likes.AsQueryable().Where(l => l.PostId == postId);
        }

        public async Task Unlike(string id)
        {
            await _dbContext.Likes.DeleteOneAsync(l => l.Id == id);
        }

        public async Task Like(Like like)
        {
            await _dbContext.Likes.InsertOneAsync(like);
        }
    }
}