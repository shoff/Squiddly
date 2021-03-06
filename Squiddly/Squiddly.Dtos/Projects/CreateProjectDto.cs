﻿namespace Squiddly.Messages.Projects
{
    using MediatR;
    using Zatoichi.Common.Infrastructure.Services;

    public class CreateProjectDto : IRequest<ApiResult>
    {
        public string Name { get; set; }
    }
}