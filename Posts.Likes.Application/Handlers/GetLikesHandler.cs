using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver.Linq;
using Posts.Likes.Application.Dtos;
using Posts.Likes.Application.Helpers;
using Posts.Likes.Application.Queries;
using Posts.Likes.Infrastructure.Entities;
using Posts.Likes.Infrastructure.Services;

namespace Posts.Likes.Application.Handlers
{
    public class GetLikesHandler : IRequestHandler<GetLikesQuery, PaginatedListDto<LikeDto>>
    {
        private readonly IMapper _mapper;

        private readonly ILikeService _likeService;

        public GetLikesHandler(IMapper mapper, ILikeService likeService)
        {
            _mapper = mapper;

            _likeService = likeService;
        }

        public async Task<PaginatedListDto<LikeDto>> Handle(GetLikesQuery request, CancellationToken cancellationToken)
        {
            var query = _likeService.GetLikes(request.PostId);
            var likes = from l in query
                        orderby l.CreatedDate
                        select l;

            var pageSize = 5;
            var paginatedLikes = await PaginatedList<Like>.CreateAsync(likes, request.PageIndex, pageSize);

            var response = _mapper.Map<PaginatedListDto<LikeDto>>(paginatedLikes);

            return response;
        }
    }
}