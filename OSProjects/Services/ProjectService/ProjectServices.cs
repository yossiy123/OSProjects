using OSProjects.Dtos.Project;
using OSProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSProjects.Services.ProjectService
{
    public class ProjectServices : IProjectServices
    {
        private List<Project> _Projects;

        public ProjectServices()
        {
            this._Projects = new List<Project>()
            {
                new Project() { Id = 1, Name = "Important project", Description = "Very important project"},
                new Project() { Id = 2, Name = "Interesting project", Description = "Very interesting project"},
                new Project() { Id = 3, Name = "Bad project", Description = "Very bad project"},
            };
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects()
        {
            ServiceResponse<List<GetProjectDto>> response = new ServiceResponse<List<GetProjectDto>>();
            try
            {
                List<GetProjectDto> projects = this._Projects.Select(i_Project => i_Project.ToGetDto()).ToList();
                response.Data = projects;
            }
            catch (Exception ee)
            {
                response.Success = false;
                response.Message = ee.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetProjectDto>> GetProject(int id)
        {
            ServiceResponse<GetProjectDto> response = new ServiceResponse<GetProjectDto>();
            try
            {
                GetProjectDto project = this._Projects.First(i_Project => i_Project.Id == id).ToGetDto();
                response.Data = project;
            }
            catch (Exception ee)
            {
                response.Success = false;
                response.Message = ee.Message;
            }

            return response;
        }
    }
}
