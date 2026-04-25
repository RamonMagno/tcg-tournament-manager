using FluentValidation;
using tcg_tournament_manager.application.Training.Commands;

namespace tcg_tournament_manager.application.Training.Validators
{
    internal sealed class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
    {
        public CreateTrainingCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
