using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSProjects.Dtos.Project
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
