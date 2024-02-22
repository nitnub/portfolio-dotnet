using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class ProjectLogo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; }
        //[ValidateNever]
        //public Project Project { get; set; }

        [Required]
        public int LogoId { get; set; }
        //[ForeignKey(nameof(LogoId))]
        [ForeignKey("LogoId")]
        [ValidateNever]
        public Logo Logo { get; set; }

        [Required]
        public int Priority { get; set; }
    }
}
