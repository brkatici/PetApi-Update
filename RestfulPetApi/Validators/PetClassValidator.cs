using FluentValidation;
using RestfulPetApi.DTOs;
using RestfulPetApi.Models;

namespace RestfulPetApi.Validators
{
    public class PetClassValidator:AbstractValidator<PetDTO>
    {
        public PetClassValidator()
        {
            RuleFor(pet => pet.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

            RuleFor(pet => pet.Species)
                .NotEmpty().WithMessage("Species is required.")
                .MaximumLength(50).WithMessage("Species cannot be longer than 50 characters.");
            RuleFor(pet => pet.Age)
                .NotEmpty().WithMessage("Pet age cannot be null or empty");

            RuleFor(pet => pet.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .MaximumLength(50).WithMessage("Gender cannot be longer than 50 characters.")
            .Must(gender => gender == "Male" || gender == "Female")
                .WithMessage("Invalid gender. Gender should be Male or Female.");


            // Add other validation rules for properties...
        }
    }
}
