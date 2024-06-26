﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [DisplayName("Image Alt Text")]
        public string ImageAltText { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        [ValidateNever]
        [DisplayName("Git URL")]
        public string? GitUrl { get; set; }
        public string? Port { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        [ValidateNever]
        [DisplayName("Demo URL")]
        public string? DemoUrl { get; set; }
        public List<Video>? Videos { get; set; }

        [ValidateNever]
        public List<ProjectLogo> ProjectLogos{ get; set; }
    }
}
