using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models.ViewModels
{
    public class ProjectUpsertVM
    {
        
        public int? Id { get; set; }
        public Project Project { get; set; }
        [ValidateNever]
        public List<ProjectLogo> ProjectLogos { get; set; }
        public List<Logo>? Logos { get; set; }
    }
}
