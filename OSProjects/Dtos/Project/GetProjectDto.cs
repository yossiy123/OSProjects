using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSProjects.Dtos.Project
{
    public class GetProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public OSProjects.Models.Project ToProject()
        {
            return new OSProjects.Models.Project() { Id = this.Id, Name = this.Name, Description = this.Description };
        }
    }
}
