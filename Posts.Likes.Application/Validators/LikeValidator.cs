using FluentValidation;
using Posts.Likes.Application.Commands;

namespace Posts.Likes.Application.Validators
{
    public class LikeValidator : AbstractValidator<LikeCommand>
    {
        public LikeValidator()
        {
            RuleFor(c => c.User)
                .NotNull()
                .WithMessage("{PropertyName} is required.");

            RuleFor(c => c.PostId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}