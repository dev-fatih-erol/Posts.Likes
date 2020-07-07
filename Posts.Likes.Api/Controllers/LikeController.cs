using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posts.Likes.Application.Commands;
using Posts.Likes.Application.Queries;

namespace Posts.Likes.Api.Controllers
{
    public class LikeController : Controller
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Post/{postId:length(24)}/Like")]
        public async Task<IActionResult> GetLikes([FromRoute]string postId, [FromQuery]int pageIndex = 1)
        {
            return Ok(await _mediator.Send(new GetLikesQuery(postId, pageIndex)));
        }

        [HttpDelete]
        [Route("Like/{postId:length(24)}")]
        public async Task<IActionResult> Unlike([FromRoute]string postId)
        {
            int userId = 3;
            await _mediator.Send(new UnlikeCommand(userId, postId));

            return NoContent();
        }

        [HttpPost]
        [Route("Like")]
        public async Task<IActionResult> Like([FromBody]LikeCommand command)
        {
            var like = await _mediator.Send(command);

            return Created($"Like/{like.Id}", like);
        }
    }
}