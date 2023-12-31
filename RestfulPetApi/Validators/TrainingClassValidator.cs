using FluentValidation;
using RestfulPetApi.Models;

namespace RestfulPetApi.Validators
{
    public class TrainingClassValidator:AbstractValidator<Training>
    {
        public TrainingClassValidator() {
            RuleFor(activity => activity.Name)
                   .NotEmpty().WithMessage("Training name is required.")
                   .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

            RuleFor(activity => activity.PetId)
                .NotNull().WithMessage("PetId cannot be null to track training informations for each pet.");
        } 
    }
}
