using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Likes.Application.Commands;
using Posts.Likes.Application.Dtos;
using Posts.Likes.Infrastructure.Entities;
using Posts.Likes.Infrastructure.Services;

namespace Posts.Likes.Application.Handlers
{
    public class LikeHandler : IRequestHandler<LikeCommand, LikeDto>
    {
        private readonly IMapper _mapper;

        private readonly ILikeService _likeService;

        public LikeHandler(IMapper mapper, ILikeService likeService)
        {
            _mapper = mapper;

            _likeService = likeService;
        }

        public async Task<LikeDto> Handle(LikeCommand request, CancellationToken cancellationToken)
        {
            var like = await _likeService.Like(
                new Like
                {
                    User = _mapper.Map<User>(request.User),
                    CreatedDate = DateTime.UtcNow,
                    PostId = request.PostId
                });

            var response = _mapper.Map<LikeDto>(like);

            return response;
        }
    }
}