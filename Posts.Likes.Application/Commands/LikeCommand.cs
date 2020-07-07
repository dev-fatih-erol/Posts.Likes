using MediatR;
using Posts.Likes.Application.Dtos;

namespace Posts.Likes.Application.Commands
{
    public class LikeCommand : IRequest<LikeDto>
    {
        public UserDto User { get; }

        public string PostId { get; }

        public LikeCommand(UserDto user, string postId)
        {
            User = user;

            PostId = postId;
        }
    }
}