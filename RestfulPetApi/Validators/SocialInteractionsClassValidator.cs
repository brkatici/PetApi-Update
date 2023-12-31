using FluentValidation;
using RestfulPetApi.Models;

namespace RestfulPetApi.Validators
{
    public class SocialInteractionsClassValidator:AbstractValidator<SocialInteraction>
    {
        public SocialInteractionsClassValidator()
        {
            RuleFor(social => social.Pet1)
           .NotEmpty().WithMessage("Pet1 id cannot be empty.");

            RuleFor(social => social.Pet2)
                .NotEmpty().WithMessage("Pet2 id cannot be empty.");
        }
    }
}
