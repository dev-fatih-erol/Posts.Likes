using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Posts.Likes.Infrastructure.Entities;

namespace Posts.Likes.Infrastructure.Services
{
    public interface ILikeService
    {
        Task<bool> Exists(int userId, string postId);

        IMongoQueryable<Like> GetLikes(string postId);

        Task Unlike(string id);

        Task Like(Like like);
    }
}