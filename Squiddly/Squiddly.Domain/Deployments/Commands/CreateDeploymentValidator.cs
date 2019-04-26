namespace Squiddly.Domain.Deployments.Commands
{
    using FluentValidation;

    public class CreateDeploymentValidator : AbstractValidator<CreateDeployment>
    {
        public CreateDeploymentValidator()
        {
            this.RuleFor(x => x.DeploymentName).MaximumLength(256);
        }
    }
}