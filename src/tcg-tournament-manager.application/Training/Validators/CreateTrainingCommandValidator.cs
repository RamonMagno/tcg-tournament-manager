using FluentValidation;
using tcg_tournament_manager.application.Training.Commands;

namespace tcg_tournament_manager.application.Training.Validators
{
    internal class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
    {
        public CreateTrainingCommandValidator()
        {
            
        }
    }
}
