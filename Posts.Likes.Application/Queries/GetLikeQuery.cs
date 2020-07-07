using MediatR;
using Posts.Likes.Application.Dtos;

namespace Posts.Likes.Application.Queries
{
    public class GetLikeQuery : IRequest<LikeDto>
    {
        public string Id { get; }

        public GetLikeQuery(string id)
        {
            Id = id;
        }
    }
}