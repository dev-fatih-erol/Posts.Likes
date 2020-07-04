using MediatR;
using Posts.Likes.Application.Dtos;

namespace Posts.Likes.Application.Queries
{
    public class GetLikesQuery : IRequest<PaginatedListDto<LikeDto>>
    {
        public string PostId { get; }

        public int PageIndex { get; }

        public GetLikesQuery(string postId, int pageIndex)
        {
            PostId = postId;

            PageIndex = pageIndex < 1 ? 1 : pageIndex;
        }
    }
}