namespace Squiddly.Domain.Deployments
{
    using AutoMapper;
    using ChaosMonkey.Guards;
    using Infrastructure.Deployments;
    using Zatoichi.Common.Infrastructure.Services;

    public class DeploymentResult : ApiResult<DeploymentDto>
    {
        private readonly IMapper mapper;

        public DeploymentResult(IMapper mapper)
        {
            this.mapper = Guard.IsNotNull(mapper, nameof(mapper));
        }

        public DeploymentDto Convert()
        {
            return this.mapper.Map<DeploymentDto>(this);
        }
    }
}