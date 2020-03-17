using Blockchain.Core.Commands;
using FluentValidation;

namespace Blockchain.Core.Validators
{
    public class CreatePackageCommandValidator : AbstractValidator<CreatePackageCommand>
    {
        public CreatePackageCommandValidator()
        {
            RuleFor(p => p.MaxNumberOfSplits).GreaterThanOrEqualTo(0).WithMessage("Number of Splits is incorrect");
        }
    }
}