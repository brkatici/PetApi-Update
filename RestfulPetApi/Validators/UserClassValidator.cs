using FluentValidation;
using RestfulPetApi.DTOs;
using RestfulPetApi.Models;

namespace RestfulPetApi.Validators
{
    public class UserClassValidator: AbstractValidator<UserDTO>
    {
        public UserClassValidator() {
            RuleFor(x => x.UserName)
              .NotEmpty().WithMessage("Username cannot be null or empty")
              .MaximumLength(50).WithMessage("Username cannot be longer then 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("e-Mail cannot be null or empty")
                .EmailAddress().WithMessage("e-Mail is not valid");
        
        } 
      
    }
}
