using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Likes.Application.Commands;
using Posts.Likes.Infrastructure.Entities;
using Posts.Likes.Infrastructure.Services;

namespace Posts.Likes.Application.Handlers
{
    public class LikeHandler : IRequestHandler<LikeCommand, Unit>
    {
        private readonly IMapper _mapper;

        private readonly ILikeService _likeService;

        public LikeHandler(IMapper mapper, ILikeService likeService)
        {
            _mapper = mapper;

            _likeService = likeService;
        }

        public async Task<Unit> Handle(LikeCommand request, CancellationToken cancellationToken)
        {
            var exists = await _likeService.Exists(request.User.Id, request.PostId);

            if (exists)
            {
                var like = new Like();
                var user = _mapper.Map<User>(request.User);
                like.User = user;
                like.CreatedDate = DateTime.UtcNow;
                like.PostId = request.PostId;

                await _likeService.Like(like);
            }

            return Unit.Value;
        }
    }
}