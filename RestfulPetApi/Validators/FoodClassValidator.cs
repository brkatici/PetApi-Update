using FluentValidation;
using RestfulPetApi.Models;

namespace RestfulPetApi.Validators
{
    public class FoodClassValidator : AbstractValidator<Food>
    {
        public FoodClassValidator()
        {
            RuleFor(food => food.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

            RuleFor(food => food.Description)
                .NotEmpty().WithMessage("Description is required for your pet health.")
                .MaximumLength(120).WithMessage("Food description cannot be longer than 120 characters. ");


            // Diğer özellikler için kurallar...
        }
    }

}
