using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models.ViewModels
{
    public class ProjectUpsertVM
    {
        public required Project Project { get; set; }
        public required List<ProjectLogo> ProjectLogos { get; set; }
        public required List<Logo>? Logos { get; set; }
    }
}
