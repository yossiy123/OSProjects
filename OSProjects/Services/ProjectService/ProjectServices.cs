using OSProjects.Data;
using OSProjects.Dtos.Project;
using OSProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OSProjects.Services.ProjectService
{
    public class ProjectServices : IProjectServices
    {
        private readonly DataContext _Context;

        public ProjectServices(DataContext context)
        {
            this._Context = context;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects()
        {
            ServiceResponse<List<GetProjectDto>> response = new ServiceResponse<List<GetProjectDto>>();
            try
            {
                List<GetProjectDto> projects = await this._Context.Projects.Select(i_Project => i_Project.ToGetDto()).ToListAsync();
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
                Project project = await this._Context.Projects.FirstAsync(i_Project => i_Project.Id == id);
                response.Data = project.ToGetDto();
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
