using FluentValidation;
using RestfulPetApi.Models;

namespace RestfulPetApi.Validators
{
    public class ActivityClassValidator : AbstractValidator<Activity>
    {
        public ActivityClassValidator()
        {
            RuleFor(activity => activity.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

            RuleFor(activity => activity.PetId)
                .NotNull().WithMessage("PetId cannot be null to track activity for each pet.");


            // Diğer özellikler için kurallar...
        }
    }

}
