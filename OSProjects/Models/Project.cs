using OSProjects.Dtos.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSProjects.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GetProjectDto ToGetDto()
        {
            return new GetProjectDto() { Id = this.Id, Name = this.Name, Description = this.Description };
        }
    }
}
