using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Posts.Likes.Infrastructure.Entities;

namespace Posts.Likes.Infrastructure.Services
{
    public interface ILikeService
    {
        IMongoQueryable<Like> GetLikes(string postId);

        Task<Like> GetLike(string id);

        Task<Like> Unlike(int userId, string postId);

        Task<Like> Like(Like like);
    }
}