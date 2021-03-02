using Microsoft.AspNetCore.Mvc;
using OSProjects.Dtos.Project;
using OSProjects.Models;
using OSProjects.Services.ProjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace OSProjects.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _ProjectServices;

        public ProjectController(IProjectServices projectServices)
        {
            this._ProjectServices = projectServices;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllProjects()
        {
            IActionResult actionResult;
            ServiceResponse<List<GetProjectDto>> response;

            response = await this._ProjectServices.GetAllProjects();

            if (response.Success)
            {
                actionResult = Ok(response);
            }
            else
            {
                actionResult = BadRequest(response);
            }

            return actionResult;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            IActionResult actionResult;
            ServiceResponse<GetProjectDto> response;

            response = await this._ProjectServices.GetProject(id);

            if (response.Success)
            {
                actionResult = Ok(response);
            }
            else
            {
                actionResult = BadRequest(response);
            }

            return actionResult;
        }
    }
}
