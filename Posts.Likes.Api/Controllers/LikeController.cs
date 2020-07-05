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

        [HttpPost]
        [Route("Like")]
        public async Task Like([FromBody]LikeCommand command) =>
            await _mediator.Send(command);
    }
}