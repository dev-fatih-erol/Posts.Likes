using FluentValidation;
using Posts.Likes.Application.Commands;

namespace Posts.Likes.Application.Validators
{
    public class LikeValidator : AbstractValidator<LikeCommand>
    {
        public LikeValidator()
        {
            RuleFor(l => l.User)
                .NotNull()
                .WithMessage("{PropertyName} is required.");

            RuleFor(l => l.PostId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}