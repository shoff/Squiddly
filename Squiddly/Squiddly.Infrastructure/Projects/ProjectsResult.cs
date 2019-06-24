namespace Squiddly.Infrastructure.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Dtos;
    using Dtos.Projects;
    using Zatoichi.Common.Infrastructure.Services;

    public class ProjectsResult : ApiResult<ICollection<ProjectDto>>
    {
        public ProjectsResult(HttpStatusCode statusCode, 
            ICollection<ProjectDto> data, 
            bool isSuccessStatusCode = false,
            string location = null,
            string message = null,
            Exception exceptionObject = null) 
            : base(statusCode, data, isSuccessStatusCode, location, message, exceptionObject)
        {
        }
    }
}