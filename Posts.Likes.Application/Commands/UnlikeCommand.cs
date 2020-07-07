using MediatR;

namespace Posts.Likes.Application.Commands
{
    public class UnlikeCommand : IRequest<Unit>
    {
        public int UserId { get; }

        public string PostId { get; }

        public UnlikeCommand(int userId, string postId)
        {
            UserId = userId;

            PostId = postId;
        }
    }
}