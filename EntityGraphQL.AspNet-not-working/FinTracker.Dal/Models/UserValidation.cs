using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace FinTracker.Models
{
    /* How to use it
     * 
     * var user = new User { FirstName = "A", LastName = "A", Email = "aaa" };
     * 
     * var validationResults = new List<ValidationResult>();
     * var vc = new ValidationContext(user, null, null);
     * Validator.TryValidateObject(user, vc, validationResults, validateAllProperties: true);
     *
     */

    public partial class User : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var res = new List<ValidationResult>();

            // Custom validation

            if (FirstName == LastName)
            {
                res.Add(new ValidationResult(
                    "First Name and Last Name must not match",
                    new[] { nameof(FirstName), nameof(LastName) }));
            }

            // Fluent validation

            var validator = new UserValidator();
            var validationResult = validator.Validate(this);
            res.AddRange(validationResult.Errors.Select(r => new ValidationResult(
                    r.ErrorMessage,
                    new[] { r.PropertyName })));

            return res;

            // Validiation, based on EF type builder config

            // can't reuse it here :(
            // need to implement validation again
        }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(e => e.FirstName)
                .MaximumLength(100);

            RuleFor(e => e.LastName)
                .MaximumLength(100);

            RuleFor(e => e.Email)
                .MaximumLength(300);

            RuleFor(e => e.PasswordHash)
                .MaximumLength(100);

            RuleFor(e => e.Email)
                .MaximumLength(300).WithMessage("Maximum length of Email exceeded")
                .EmailAddress().WithMessage("Email not in valid format")
                .NotEmpty().WithMessage("Email can't be empty");
        }
    }
}
