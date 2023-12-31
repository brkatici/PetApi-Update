using FluentValidation;
using RestfulPetApi.Models;

namespace RestfulPetApi.Validators
{
    public class HealthStatusClassValidator : AbstractValidator<HealthStatus>
    {
        public HealthStatusClassValidator()
        {
            RuleFor(status => status.Weight)
                .GreaterThan(0).WithMessage("Weight should be greater than 0.");

            RuleFor(status => status.LastCheckupDate)
                .NotEmpty().WithMessage("Last visit to vet date is required.");

            RuleFor(status => status.Diseases)
                .NotEmpty().WithMessage("You must write any diseas.İf there`s no disease please write 'None' ");


            // Diğer özellikler için kurallar...
        }
    }

}
