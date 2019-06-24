namespace Squiddly.Infrastructure.Deployments
{
    using AutoMapper;
    using ChaosMonkey.Guards;
    using Dtos.Deployments;
    using Zatoichi.Common.Infrastructure.Services;

    public class DeploymentResult : ApiResult<DeploymentDto>
    {
        private readonly IMapper mapper;

        public DeploymentResult(IMapper mapper) 
            : base(System.Net.HttpStatusCode.OK, null)
        {
            this.mapper = Guard.IsNotNull(mapper, nameof(mapper));
        }

        public DeploymentDto Convert()
        {
            return this.mapper.Map<DeploymentDto>(this);
        }
    }
}