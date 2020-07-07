using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Likes.Application.Dtos;
using Posts.Likes.Application.Exceptions;
using Posts.Likes.Application.Queries;
using Posts.Likes.Infrastructure.Entities;
using Posts.Likes.Infrastructure.Services;

namespace Posts.Likes.Application.Handlers
{
    public class GetLikeHandler : IRequestHandler<GetLikeQuery, LikeDto>
    {
        private readonly IMapper _mapper;

        private readonly ILikeService _likeService;

        public GetLikeHandler(IMapper mapper, ILikeService likeService)
        {
            _mapper = mapper;

            _likeService = likeService;
        }

        public async Task<LikeDto> Handle(GetLikeQuery request, CancellationToken cancellationToken)
        {
            var like = await _likeService.GetLike(request.Id);

            if (like == null)
            {
                throw new NotFoundException(nameof(Like));
            }

            var response = _mapper.Map<LikeDto>(like);

            return response;
        }
    }
}