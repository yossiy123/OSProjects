using OSProjects.Dtos.Project;
using OSProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSProjects.Services.ProjectService
{
    public interface IProjectServices
    {
        public Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects();
        public Task<ServiceResponse<GetProjectDto>> GetProject(int id);
    }
}
